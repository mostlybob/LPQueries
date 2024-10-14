<Query Kind="Program" />

void Main()
{
    var yyyy = new[] 
    {
        new[] {"a"}, 
        new[] {"a","b"}, 
        new[] {"a", "b", "c"}
    };

    yyyy.Dump("Array of arrays");

    yyyy
        .Select(x => x.Select(y => $"'{y}'"))
        .Select(x => string.Join(",",x))
        .Dump("Array of arrays - formatted");
    
    //var test = new List<string>
    //{
    //    "Service Marketing Digital",
    //    "FORD Service Marketing Digital"
    //
    //};
    //
    //var a=GetEnabledDealerQuery(test);
    //var b=GetServiceMarketingEmailEnabledDealerQuery();
    //
    //a.Equals(b).Dump();
}

// Define other methods and classes here
public string GetEnabledDealerQuery(IEnumerable<string> assets)
{
    var cleanedAndFormatted = assets
        .Where(x => string.IsNullOrEmpty(x) == false)
        .Select(x => $"'{x}'");

    var assetList = string.Join(",", cleanedAndFormatted);

    return $@"
                SELECT DISTINCT asset.Account_Acronym__c AS DealerAcronym
                FROM [CRM].[dbo].[Asset] AS asset
                WHERE asset.Name IN ({assetList})
                AND asset.UsageEndDate IS NULL
                AND asset.Status IN ('Installed', 'Pending Cancel', 'On Hold')
                AND asset.Billing_Start_Date__c <= '{ DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss")}';
            ";
}

public string GetServiceMarketingEmailEnabledDealerQuery()
{
    return $@"
                SELECT DISTINCT asset.Account_Acronym__c AS DealerAcronym
                FROM [CRM].[dbo].[Asset] AS asset
                WHERE asset.Name IN ('Service Marketing Digital','FORD Service Marketing Digital')
                AND asset.UsageEndDate IS NULL
                AND asset.Status IN ('Installed', 'Pending Cancel', 'On Hold')
                AND asset.Billing_Start_Date__c <= '{ DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss")}';
            ";
}