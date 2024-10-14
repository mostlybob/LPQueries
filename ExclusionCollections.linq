<Query Kind="Program" />

// just a simple comparison of two arrays
// - worked up as part of O2O-5716
void Main()
{
    //RoiRollupDto.Dump();
    //ModelsCampaign.Dump();
    
    RoiRollupDto.Where(x=>ModelsCampaign.Contains(x) == false).Dump();
    ModelsCampaign.Where(x=>RoiRollupDto.Contains(x) == false).Dump();
}

// Define other methods and classes here

private static string[] RoiRollupDto = new[]{
"CRMLeads",
"CampaignCount",
"CaslCount",
"DealerSiteVisits",
"DirectMailConversion",
"EmailUniqueOpen",
"EmailDelivered",
"EmailOpened",
"EmailTransferred",
"Model",
"PURLVisitsCount",
"SoldNewBackGross",
"SoldNewCount",
"SoldNewFrontGross",
"SoldNewGross",
"SoldUsedBackGross",
"SoldUsedCount",
"SoldUsedFrontGross",
"SoldUsedGross",
"TotalBackGross",
"TotalDirectMailSent",
"TotalEmailSent",
"TotalFrontGross",
"TotalGross",
"TotalSold",
"EmailDeployments",
"VerifiedSoldVehicle",
"PendingSoldVehicle",
"CMA"
};


private static string[] ModelsCampaign = new[]{
"CRMLeads",
"CampaignCount",
"CaslCount",
"DealerSiteVisits",
"DirectMailConversion",
"EmailUniqueOpen",
"EmailDelivered",
"EmailOpened",
"EmailTransferred",
"Model",
"MarketedModel",
"PURLVisitsCount",
"SoldNewBackGross",
"SoldNewCount",
"SoldNewFrontGross",
"SoldNewGross",
"SoldUsedBackGross",
"SoldUsedCount",
"SoldUsedFrontGross",
"SoldUsedGross",
"TotalBackGross",
"TotalDirectMailSent",
"TotalEmailSent",
"TotalFrontGross",
"TotalGross",
"TotalSold",
"EmailDeployments",
"VerifiedSoldVehicle",
"PendingSoldVehicle",
"CMA"
};