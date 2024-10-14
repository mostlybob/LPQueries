<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/*
I saw a pattern in a refactor Arjun did that caught my attention and I wanted to play with it.
https://upsource.autoalert.com/motofuze-git/review/MFZ-CR-741

Rather than reference the libraries, I'm going to replicate as much as I can for portability and isolation.

I put the original code and refactored in methods named as such below. I'm curious if there's a performance difference,
as I *might* expect, but which might actually be some residual misunderstanding about what async/await actually does.
*/

void Main()
{
    
}

public class Common
{
    protected DateTime today => DateTime.Today;
    protected DateTime dayBefore30Days => today.AddDays(-30);
    
    protected ILogger _logger=new Logger();
    protected IAurora _aurora=new Aurora();
    protected IAACoreDb _aaCoreDb=new AACoreDb();
    protected IAASyn _aasyn=new AASyn();
    protected IImDb _imdb=new ImDb();
    
    
}

public class Original : Common
{

    public async Task<EngagementStudioStatistics> GetStatistics(int dealerId)
    {
        EngagementStudioStatistics statistics = new EngagementStudioStatistics();
        var tasks = new List<Task>();
        tasks.Add(Task.Run(() =>
        {
            statistics.PartnerExportActivity = this.GetPartnerExportActivityFor30DaysByDealerId(dealerId);
        }));

        tasks.Add(Task.Run(() =>
        {
            statistics.PartnerMailedActivity = this.GetPartnerMailedActivityFor30DaysByDealerId(dealerId);
        }));

        tasks.Add(Task.Run(() =>
        {
            statistics.O2OEmailDelivered = this.GetO2OEmailsDeliveredInLast30DaysByDealerId(dealerId);
        }));

        tasks.Add(Task.Run(() =>
        {
            statistics.O2OEmailOpened = this.GetO2OEmailsOpenedInLast30DaysByDealerId(dealerId);
        }));

        tasks.Add(Task.Run(() =>
        {
            statistics.AutoAssistantConversationsSent = this.GetAutoAssistantConversationsSentByDealerIdAndMinScheduledDate(dealerId, this.dayBefore30Days);
        }));

        tasks.Add(Task.Run(() =>
        {
            statistics.AutoAssistantHotLeadsGenerated = this.GetAutoAssistantHotLeadsGeneratedIn30DaysByDealerId(dealerId);
        }));

        tasks.Add(Task.Run(() =>
        {
            statistics.TargetedGeoAlert = this.GetTargetedGeoAlertIn30DaysByDealerId(dealerId);
        }));

        tasks.Add(Task.Run(() =>
        {
            statistics.GeoAlerts = this.GetGeoAlertsIn30DaysByDealerId(dealerId);
        }));

        tasks.Add(Task.Run(() =>
        {
            statistics.ServiceMarketingEmailsDelivered = this.GetServiceMarketingEmailsDelivered(dealerId);
        }));

        tasks.Add(Task.Run(() =>
        {
            statistics.ServiceMarketingROsGenerated = this.GetServiceMarketingROsGenerated(dealerId);
        }));

        await Task.WhenAll(tasks).ConfigureAwait(false);

        return statistics;
    }

    #region Private Methods

    /// <summary>
    /// To map roi_campaign_rollup with PartnerExportByDealerDto
    /// </summary>
    /// <param name="rollupList"></param>
    /// <returns></returns>
    private static IEnumerable<PartnerExportByDealerDto> MapCampaignRollup(IEnumerable<roi_campaign_rollup> rollupList)
    {
        // This need to be replaced with AutoMapper. But currently its in Common and it can't refer service project due to Circular dependency.
        if (rollupList.NullSafeAny())
        {
            List<PartnerExportByDealerDto> result = new List<PartnerExportByDealerDto>();
            foreach (var item in rollupList)
            {
                result.Add(new PartnerExportByDealerDto
                {
                    CampaignId = Convert.ToInt64(item.campaign_id),
                    CampaignName = item.campaign_name,
                    CustomerCount = item.external_customer_count ?? 0,
                    DealerId = item.dealer_id ?? 0
                });
            }
            return result;
        }
        else
        {
            return Enumerable.Empty<PartnerExportByDealerDto>();
        }
    }

    #region Partner Export - External Campaigns
    private IEnumerable<roi_campaign_rollup> GetPartnerExportByDealerId(int dealerId)
    {
        string sql = $@"SELECT campaign_name, external_customer_count
                            FROM roi_reporting.roi_campaign_rollup
                            WHERE is_external_campaign = true AND dealer_id = { dealerId } AND scheduled_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return this._aurora.Select<roi_campaign_rollup>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Partner Export Activity by DealerId", ex);
        }
        return Enumerable.Empty<roi_campaign_rollup>();
    }

    private int GetPartnerExportActivityFor30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT coalesce(sum(external_customer_count), 0) as customerCount
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE dealer_id = { dealerId } AND is_external_campaign = true AND scheduled_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return this._aurora.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Partner Export Activity", ex);
        }
        return 0;
    }

    private int GetPartnerMailedActivityFor30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT sum(coalesce(direct_mail_count, 0))
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE dealer_id = { dealerId } AND is_external_campaign = true AND scheduled_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return this._aurora.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Partner Export Activity", ex);
        }
        return 0;
    }
    #endregion

    #region One to One
    private int GetO2OEmailsDeliveredInLast30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT sum(coalesce(email_sent_count,0)) - sum(coalesce(email_bounce_count,0)) 
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE {this.GetO2OEmailWhereClause(dealerId)}";
        try
        {
            return this._aurora.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting O2O Email Activity", ex);
        }
        return 0;
    }

    private int GetO2OEmailsOpenedInLast30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT sum(coalesce(email_open_count,0)) 
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE {this.GetO2OEmailWhereClause(dealerId)}";
        try
        {
            return this._aurora.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting O2O Email Activity", ex);
        }
        return 0;
    }

    private string GetO2OEmailWhereClause(int dealerId)
    {
        return $"dealer_id = { dealerId } AND is_one_2_one_campaign = true AND scheduled_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
    }

    #endregion

    #region AutoAssistant
    private int GetAutoAssistantConversationsSentByDealerIdAndMinScheduledDate(int dealerId, DateTime minDate)
    {
        string sql = $@"SELECT coalesce(sum(autoassistant_count), 0) as customerCount
                            FROM roi_reporting.roi_campaign_rollup
                            WHERE dealer_id = { dealerId } AND is_auto_assistant_campaign = true
                                  AND scheduled_date > '{minDate:yyyy-MM-dd}'";
        try
        {
            return this._aurora.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting AutoAssistant Activity", ex);
        }
        return 0;
    }

    private int GetAutoAssistantHotLeadsGeneratedIn30DaysByDealerId(int dealerId)
    {
        string activityIds = $@"{(int)Enums.Customer.CustomerActivityEventTypes.AutoAssistantHotLeadTag}";
        string sql = $@"SELECT count(1) FROM
                              (SELECT EntityID FROM AutoAlert.dbo.CustomerActivity
                                                        WHERE CustomerActivityEventID in ({ activityIds })
                                                              AND DealerID = {dealerId}
                                                              AND ActivityDate > '{this.dayBefore30Days:yyyy-MM-dd}'
			                            GROUP BY EntityID) a";
        try
        {
            return this._aaCoreDb.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting AutoAssistant Hot Leads", ex);
        }
        return 0;
    }

    private int GetTargetedGeoAlertIn30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT COUNT(DISTINCT EntityID) FROM AutoAlert.dbo.CustomerActivity
                            WHERE CustomerActivityEventID = { (int)Enums.Customer.CustomerActivityEventTypes.GeoAlertAdded }
                                  AND DealerID = {dealerId} AND ActivityDate > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return this._aaCoreDb.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Targeted GeoAlert", ex);
        }
        return 0;
    }

    /// <summary>
    /// Conversations Started (this is the count of audience sent to Conversica so far)
    /// </summary>
    /// <param name="dealerId"></param>
    /// <param name="minDate"></param>
    /// <returns></returns>
    private int GetAutoAssistantConversationsStartedByDealerIdAndMinScheduledDate(int dealerId, DateTime minDate)
    {
        string sql = $@"SELECT COUNT(DISTINCT EntityID) FROM AutoAlert.dbo.CustomerActivity
                            WHERE CustomerActivityEventID in ({ (int)Enums.Customer.CustomerActivityEventTypes.AutoAssistantHotLead },
                                                              { (int)Enums.Customer.CustomerActivityEventTypes.AutoAssistantHotLeadTag })
                                  AND DealerID = { dealerId } AND ActivityDate > '{minDate:yyyy-MM-dd}'";
        try
        {
            return this._aaCoreDb.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Auto Assistant Conversations Started", ex);
        }
        return 0;
    }

    /// <summary>
    /// Leads Generated (this is a sum of Hot, At Risk, or Needs Follow up leads generated so far this month)
    /// </summary>
    /// <param name="dealerId"></param>
    /// <param name="minDate"></param>
    /// <returns></returns>
    private int GetAutoAssistantLeadsGeneratedByDealerIdAndMinScheduledDate(int dealerId, DateTime minDate)
    {
        string activityIds = $@"{(int)Enums.Customer.CustomerActivityEventTypes.AutoAssistantHotLeadTag},
                                    {(int)Enums.Customer.CustomerActivityEventTypes.AutoAssistantActionRequiredTag},
                                    {(int)Enums.Customer.CustomerActivityEventTypes.AutoAssistantActionLeadAtRiskTag}";
        string sql = $@"SELECT count(1) FROM
                              (SELECT EntityID FROM AutoAlert.dbo.CustomerActivity
                                                        WHERE CustomerActivityEventID in ({ activityIds })
                                                              AND DealerID = {dealerId}
                                                              AND ActivityDate > '{minDate:yyyy-MM-dd}'
			                            GROUP BY EntityID) a";
        try
        {
            return this._aaCoreDb.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting AutoAssistant Leads Generated", ex);
        }
        return 0;
    }

    #endregion

    #region GeoAlert

    private int GetGeoAlertsIn30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT COUNT(DISTINCT EntityID) FROM AutoAlert.dbo.CustomerActivity
                            WHERE CustomerActivityEventID in ({ (int)Enums.Customer.CustomerActivityEventTypes.GeoAlertActiveTag },{ (int)Enums.Customer.CustomerActivityEventTypes.GeoAlertActive })
                                  AND DealerID = {dealerId} AND ActivityDate > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return this._aaCoreDb.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Targeted GeoAlert", ex);
        }
        return 0;
    }

    private int GetGeoAlertAdsRunningByDealerIdAndMinDate(int dealerId, DateTime minDate)
    {
        string sql = $@"SELECT COUNT(1)
                            FROM GeoAlertElToroStatusLog GTSL
                            INNER JOIN ElToroOrderlineDetails E on GTSL.StatusLogID = E.StatusLogID
                            WHERE GTSL.DealerID = {dealerId} and E.StatusDate > '{minDate:yyyy-MM-dd}'";
        try
        {
            return this._imdb.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting GeoAlert Ads Running", ex);
        }
        return 0;
    }

    private int GetGeoAlertAudienceSentByDealerIdAndMinDate(int dealerId, DateTime minDate)
    {
        string sql = $@"SELECT COUNT(DISTINCT EntityID) FROM AutoAlert.dbo.CustomerActivity
                            WHERE CustomerActivityEventID in ({ (int)Enums.Customer.CustomerActivityEventTypes.GeoAlertAdded })
                                  AND DealerID = { dealerId } AND ActivityDate > '{minDate:yyyy-MM-dd}'";
        try
        {
            return this._aaCoreDb.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting GeoAlert Audience Sent", ex);
        }
        return 0;
    }

    private int GetGeoAlertsCapturedByDealerIdAndMinDate(int dealerId, DateTime minDate)
    {
        string sql = $@"SELECT COUNT(DISTINCT EntityID) FROM AutoAlert.dbo.CustomerActivity
                            WHERE CustomerActivityEventID in ({ (int)Enums.Customer.CustomerActivityEventTypes.GeoAlertActiveTag },
                                                              { (int)Enums.Customer.CustomerActivityEventTypes.GeoAlertActive })
                                  AND DealerID = { dealerId } AND ActivityDate > '{minDate:yyyy-MM-dd}'";
        try
        {
            return this._aaCoreDb.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting GeoAlert Captured", ex);
        }
        return 0;
    }

    #endregion

    #region Service Marketing

    private int GetServiceMarketingEmailsDelivered(int dealerId)
    {
        string sql = $@"SELECT sum(coalesce(email_sent_count,0) - coalesce(email_bounce_count,0)) 
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE dealer_id = { dealerId } AND is_service_campaign = true AND scheduled_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return this._aurora.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Service Marketing Email Activity", ex);
        }
        return 0;
    }

    private int GetServiceMarketingROsGenerated(int dealerId)
    {
        string sql = $@"SELECT count(ro_id)
                            FROM roi_reporting.roi_service_ro 
                            WHERE dealer_id = { dealerId } AND open_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return this._aurora.FetchSingle<int>(sql);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Service Marketing ROs", ex);
        }
        return 0;
    }

    #endregion

    #region Subscriptions

    private bool GetAudienceBuilderSubscription(string dealerCode)
    {
        if (string.IsNullOrWhiteSpace(dealerCode))
        {
            return false;
        }
        int AudienceBuilderAssets = _aasyn?.Select<int>($@"SELECT COUNT(1) 
                                                      FROM[CRM].[dbo].[Asset]
                                                      WHERE Account_Acronym__c = '{dealerCode}'
                                                      AND Status IN('Installed', 'Pending Cancel')
                                                      AND Name IN('FORD One to One Marketing', 'FORD One to One Digital Marketing',
                                                                  'Ford One to One Social Marketing', 'FORD One to One Direct Marketing',
                                                                  'FORD One to One Direct Marketing - Monthly',
                                                                  'FORD One to One Direct Marketing - Quarterly',
                                                                  'One to One Marketing',
                                                                  'One to One Digital Marketing',
                                                                  'One to One Direct Marketing - Monthly',
                                                                  'One to One Social Marketing')").FirstOrDefault() ?? 0;

        return AudienceBuilderAssets > 0;
    }

    private bool GetAutoAssitantSubscription(string dealerCode)
    {
        if (string.IsNullOrWhiteSpace(dealerCode))
        {
            return false;
        }
        int AutoAssitantAssets = _aasyn?.Select<int>($@"SELECT COUNT(1) 
                                                      FROM[CRM].[dbo].[Asset]
                                                      WHERE Account_Acronym__c = '{dealerCode}'
                                                      AND Status IN('Installed', 'Pending Cancel')
                                                      AND Name IN('FORD AutoAssistant', 'AutoAssistant')").FirstOrDefault() ?? 0;

        return AutoAssitantAssets > 0;
    }

    private bool GetGeoAlertSubscription(string dealerCode)
    {
        if (string.IsNullOrWhiteSpace(dealerCode))
        {
            return false;
        }
        int GeoAlertAssets = _aasyn?.Select<int>($@"SELECT COUNT(1) 
                                                      FROM[CRM].[dbo].[Asset]
                                                      WHERE Account_Acronym__c = '{dealerCode}'
                                                      AND Status IN('Installed', 'Pending Cancel')
                                                      AND Name IN('FORD GeoAlert', 'GeoAlert')").FirstOrDefault() ?? 0;

        return GeoAlertAssets > 0;
    }

    private bool GetOneToOneSubscription(string dealerCode)
    {
        if (string.IsNullOrWhiteSpace(dealerCode))
        {
            return false;
        }
        int O2OAssets = _aasyn?.Select<int>($@"SELECT COUNT(1) 
                                                      FROM[CRM].[dbo].[Asset]
                                                      WHERE Account_Acronym__c = '{dealerCode}'
                                                      AND Status IN('Installed', 'Pending Cancel')
                                                      AND Name IN('FORD One to One Marketing', 'FORD One to One Digital Marketing',
                                                                  'Ford One to One Social Marketing', 'FORD One to One Direct Marketing',
                                                                  'FORD One to One Direct Marketing - Monthly',
                                                                  'FORD One to One Direct Marketing - Quarterly',
                                                                  'One to One Marketing',
                                                                  'One to One Digital Marketing',
                                                                  'One to One Direct Marketing - Monthly',
                                                                  'One to One Social Marketing')").FirstOrDefault() ?? 0;

        return O2OAssets > 0;
    }

    private bool GetServiceMarketingSubscription(string dealerCode)
    {
        if (string.IsNullOrWhiteSpace(dealerCode))
        {
            return false;
        }
        int ServiceMarketingAssets = _aasyn?.Select<int>($@"SELECT COUNT(1)
                                                      FROM[CRM].[dbo].[Asset]
                                                      WHERE Account_Acronym__c = '{dealerCode}'
                                                      AND Status IN ('Cancelled', 'On Hold', 'Installed', 'Purchased')
                                                      AND Name IN ('Service Marketing Digital', 'Service Marketing Direct',
                                                                  'FORD Service Marketing Digital',
                                                                  'FORD Service Marketing Direct')").FirstOrDefault() ?? 0;

        return ServiceMarketingAssets > 0;
    }

    #endregion

    #endregion












}

public class Refactored : Common
{


    public async Task<EngagementStudioStatistics> GetStatistics(int dealerId)
    {
        var partnerExportActivityTask = this.GetPartnerExportActivityFor30DaysByDealerId(dealerId);
        var partnerMailActivityTask = this.GetPartnerMailedActivityFor30DaysByDealerId(dealerId);
        var o2oEmailDeliveredTask = this.GetO2OEmailsDeliveredInLast30DaysByDealerId(dealerId);
        var o2oEmailOpenedTask = this.GetO2OEmailsOpenedInLast30DaysByDealerId(dealerId);
        var autoAssistantConversationsSentTask = this.GetAutoAssistantConversationsSentByDealerIdAndMinScheduledDate(dealerId, this.dayBefore30Days);
        var autoAssistantHotLeadsGeneratedTask = this.GetAutoAssistantHotLeadsGeneratedIn30DaysByDealerId(dealerId);
        var targetedGeoAlertTask = this.GetTargetedGeoAlertIn30DaysByDealerId(dealerId);
        var geoAlertListTask = this.GetGeoAlertsIn30DaysByDealerId(dealerId);
        var serviceMarketingEmailsDeliveredTask = this.GetServiceMarketingEmailsDelivered(dealerId);
        var serviceMarketingROsGeneratedTask = this.GetServiceMarketingROsGenerated(dealerId);

        EngagementStudioStatistics statistics = new EngagementStudioStatistics
        {
            PartnerExportActivity = await partnerExportActivityTask.ConfigureAwait(false),
            PartnerMailedActivity = await partnerMailActivityTask.ConfigureAwait(false),
            O2OEmailDelivered = await o2oEmailDeliveredTask.ConfigureAwait(false),
            O2OEmailOpened = await o2oEmailOpenedTask.ConfigureAwait(false),
            AutoAssistantConversationsSent = await autoAssistantConversationsSentTask.ConfigureAwait(false),
            AutoAssistantHotLeadsGenerated = await autoAssistantHotLeadsGeneratedTask.ConfigureAwait(false),
            TargetedGeoAlert = await targetedGeoAlertTask.ConfigureAwait(false),
            GeoAlerts = await geoAlertListTask.ConfigureAwait(false),
            ServiceMarketingEmailsDelivered = await serviceMarketingEmailsDeliveredTask.ConfigureAwait(false),
            ServiceMarketingROsGenerated = await serviceMarketingROsGeneratedTask.ConfigureAwait(false)
        };

        return statistics;
    }

    private async Task<int> GetPartnerExportActivityFor30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT coalesce(sum(external_customer_count), 0) as customerCount
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE dealer_id = { dealerId } AND is_external_campaign = true AND scheduled_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return await this._aurora.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Partner Export Activity", ex);
        }
        return 0;
    }

    private async Task<int> GetPartnerMailedActivityFor30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT sum(coalesce(direct_mail_count, 0))
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE dealer_id = { dealerId } AND is_external_campaign = true AND scheduled_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return await this._aurora.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Partner Export Activity", ex);
        }
        return 0;
    }

    private async Task<int> GetO2OEmailsDeliveredInLast30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT sum(coalesce(email_sent_count,0)) - sum(coalesce(email_bounce_count,0)) 
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE {this.GetO2OEmailWhereClause(dealerId)}";
        try
        {
            return await this._aurora.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting O2O Email Activity", ex);
        }
        return 0;
    }

    object GetO2OEmailWhereClause(int dealerId)
    {
        throw new NotImplementedException();
    }

    private async Task<int> GetO2OEmailsOpenedInLast30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT sum(coalesce(email_open_count,0)) 
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE {this.GetO2OEmailWhereClause(dealerId)}";
        try
        {
            return await this._aurora.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting O2O Email Activity", ex);
        }
        return 0;
    }

    private async Task<int> GetAutoAssistantConversationsSentByDealerIdAndMinScheduledDate(int dealerId, DateTime minDate)
    {
        string sql = $@"SELECT coalesce(sum(autoassistant_count), 0) as customerCount
                            FROM roi_reporting.roi_campaign_rollup
                            WHERE dealer_id = { dealerId } AND is_auto_assistant_campaign = true
                                  AND scheduled_date > '{minDate:yyyy-MM-dd}'";
        try
        {
            return await this._aurora.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting AutoAssistant Activity", ex);
        }
        return 0;
    }

    private async Task<int> GetAutoAssistantHotLeadsGeneratedIn30DaysByDealerId(int dealerId)
    {
        string activityIds = $@"{(int)Enums.Customer.CustomerActivityEventTypes.AutoAssistantHotLeadTag}";
        string sql = $@"SELECT count(1) FROM
                              (SELECT EntityID FROM AutoAlert.dbo.CustomerActivity
                                                        WHERE CustomerActivityEventID in ({ activityIds })
                                                              AND DealerID = {dealerId}
                                                              AND ActivityDate > '{this.dayBefore30Days:yyyy-MM-dd}'
			                            GROUP BY EntityID) a";
        try
        {
            return await this._aaCoreDb.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting AutoAssistant Hot Leads", ex);
        }
        return 0;
    }

    private async Task<int> GetTargetedGeoAlertIn30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT COUNT(DISTINCT EntityID) FROM AutoAlert.dbo.CustomerActivity
                            WHERE CustomerActivityEventID = { (int)Enums.Customer.CustomerActivityEventTypes.GeoAlertAdded }
                                  AND DealerID = {dealerId} AND ActivityDate > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return await this._aaCoreDb.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Targeted GeoAlert", ex);
        }
        return 0;
    }

    private async Task<int> GetGeoAlertsIn30DaysByDealerId(int dealerId)
    {
        string sql = $@"SELECT COUNT(DISTINCT EntityID) FROM AutoAlert.dbo.CustomerActivity
                            WHERE CustomerActivityEventID in ({ (int)Enums.Customer.CustomerActivityEventTypes.GeoAlertActiveTag },{ (int)Enums.Customer.CustomerActivityEventTypes.GeoAlertActive })
                                  AND DealerID = {dealerId} AND ActivityDate > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return await this._aaCoreDb.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Targeted GeoAlert", ex);
        }
        return 0;
    }

    private async Task<int> GetServiceMarketingEmailsDelivered(int dealerId)
    {
        string sql = $@"SELECT sum(coalesce(email_sent_count,0) - coalesce(email_bounce_count,0)) 
                            FROM roi_reporting.roi_campaign_rollup 
                            WHERE dealer_id = { dealerId } AND is_service_campaign = true AND scheduled_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return await this._aurora.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Service Marketing Email Activity", ex);
        }
        return 0;
    }

    private async Task<int> GetServiceMarketingROsGenerated(int dealerId)
    {
        string sql = $@"SELECT count(ro_id)
                            FROM roi_reporting.roi_service_ro 
                            WHERE dealer_id = { dealerId } AND open_date > '{this.dayBefore30Days:yyyy-MM-dd}'";
        try
        {
            return await this._aurora.FetchSingleAsync<int>(sql).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            this._logger.Log("Studio : Failed getting Service Marketing ROs", ex);
        }
        return 0;
    }


}

public class Enums
{
    public class Customer
    {
        public enum CustomerActivityEventTypes
        {
            AutoAssistantHotLeadTag,
            GeoAlertAdded,
            GeoAlertActiveTag,
            GeoAlertActive,
            AutoAssistantHotLead,
            AutoAssistantActionRequiredTag,
            AutoAssistantActionLeadAtRiskTag
        }
    }
}

public interface ILogger
{
    void Log(string v, Exception ex);
}

public class Logger : ILogger
{
    public void Log(string v, Exception ex)
    {
        throw new NotImplementedException();
    }
}

public interface IAurora
{
    T FetchSingle<T>(string sql);
    Task<T> FetchSingleAsync<T>(string sql);
    IEnumerable<T> Select<T>(string sql);
}

public class Aurora : IAurora
{
    public T FetchSingle<T>(string sql)
    {
        throw new NotImplementedException();
    }

    public Task<T> FetchSingleAsync<T>(string sql)
{
    throw new NotImplementedException();
}

    public IEnumerable<T> Select<T>(string sql)
    {
        throw new NotImplementedException();
    }
}

public interface IAACoreDb
{
    T FetchSingle<T>(string sql);
    Task<T> FetchSingleAsync<T>(string sql);
}

public class AACoreDb : IAACoreDb
{
    public T FetchSingle<T>(string sql)
    {
        throw new NotImplementedException();
    }

    public Task<T> FetchSingleAsync<T>(string sql)
    {
        throw new NotImplementedException();
    }
}

public interface IAASyn
{
    Task<T> FetchSingleAsync<T>(string sql);
    IEnumerable<T> Select<T>(string sql);
}

public class AASyn : IAASyn
{
    public Task<T> FetchSingleAsync<T>(string sql)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Select<T>(string sql)
    {
        throw new NotImplementedException();
    }
}

public interface IImDb
{
    T FetchSingle<T>(string sql);
}

public class ImDb : IImDb
{
    public T FetchSingle<T>(string sql)
    {
        throw new NotImplementedException();
    }
}

public class EngagementStudioStatistics
{
    public int O2OEmailDelivered { get; set; }
    public int O2OEmailOpened { get; set; }

    public int AutoAssistantConversationsSent { get; set; }
    public int AutoAssistantHotLeadsGenerated { get; set; }

    public int TargetedGeoAlert { get; set; }
    public int GeoAlerts { get; set; }

    public int PartnerExportActivity { get; set; }
    public int PartnerMailedActivity { get; set; }

    public int ServiceMarketingEmailsDelivered { get; set; }
    public int ServiceMarketingROsGenerated { get; set; }
}

public class PartnerExportByDealerDto
{
    public long CampaignId { get; set; }
    public int DealerId { get; set; }
    public string CampaignName { get; set; }
    public int CustomerCount { get; set; }
}

public partial class roi_campaign_rollup
{
    public roi_campaign_rollup()
    {
    }

    public int? dealer_id { get; set; }
    public int? campaign_id { get; set; }
    public string campaign_name { get; set; }
    public string campaign_type { get; set; }
    public DateTime? scheduled_date { get; set; }
    public int? sent_to_selligent_count { get; set; }
    public int? email_sent_count { get; set; }
    public int? email_bounce_count { get; set; }
    public int? email_open_count { get; set; }
    public int? email_unique_open_count { get; set; }
    public int? email_click_count { get; set; }
    public int? direct_mail_count { get; set; }
    public int? landing_page_lead_generated_count { get; set; }
    public int? landing_page_view_count { get; set; }
    public int? purl_click_count { get; set; }
    public DateTime? expire_date { get; set; }
    public int? email_unsub_count { get; set; }
    public int? email_unique_click_count { get; set; }
    public int? casl_count { get; set; }
    public int? product_type_id { get; set; }
    public decimal? budget { get; set; }
    public string external_id { get; set; }
    public bool? is_one_2_one_campaign { get; set; }
    public bool? is_auto_assistant_campaign { get; set; }
    public bool? is_geo_alert_campaign { get; set; }
    public bool? is_intelligent_marketing_campaign { get; set; }
    public bool? is_external_campaign { get; set; }
    public int? external_customer_count { get; set; }
    public int? autoassistant_count { get; set; }
    public bool? is_service_campaign { get; set; }
}




public static class ExtensionMethods
{
    /// <summary>
    /// Determines whether a sequence contains any elements.
    /// </summary>
    public static bool NullSafeAny<T>(this IEnumerable<T> collection, Func<T, bool> predicate = null)
    {
        if (predicate == null)
        {
            return collection != null && collection.Any();
        }

        return collection != null && collection.Any(predicate);
    }
}
