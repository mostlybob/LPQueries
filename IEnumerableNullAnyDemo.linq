<Query Kind="Program" />

void Main()
{
    var nullFoos=GetFoos(true);
    var emptyFoos=GetFoos(false,0);
    var defaultFoos=GetFoos();
    var abunch=GetFoos(false,10);
    
    //nullFoos.Dump("null");
    //emptyFoos.Dump("empty");
    //defaultFoos.Dump("default");
    //abunch.Dump("a bunch");

    var allofem = new List<IEnumerable<Foo>>
    {
        nullFoos,
        emptyFoos,
        defaultFoos,
        abunch
    };
    
    //allofem.Dump();
    
 //   foreach (var salesForceRecords in allofem)
 //   {
 //       salesForceRecords.Dump();
 //       if (salesForceRecords != null && salesForceRecords.Any())
 //       {
 //           //return salesForceRecords;
 //           "something".Dump();
 //           
 //       }
 //else       
 //           "nothing".Dump();
 //       "--------------------------------------------------".Dump();
 //   }

    foreach (var item in allofem)
    {
        item.Dump("raw");
        GetRecs(item).Dump("processed");
        
        "--------------------------------------------------".Dump();
    }
    
}

IEnumerable<Foo> GetRecs(IEnumerable<Foo> test)
{
    
        if (test != null && test.Any())
            return test;

        "nothing to show".Dump();
        return new List<Foo>();
}



/*
        private IEnumerable<CampaignPrintMetadatum> FoozGetRecs(long jobId, SalesforceCampaignCreationService.SalesforceCampaignCreationServiceParameters parms)
        {
            IEnumerable<CampaignPrintMetadatum> salesForceRecords = _salesforceCampaignCreationService.GetCampaignCreationSalesForceRecords(parms);

            if (salesForceRecords != null && salesForceRecords.Any())
            {
                return salesForceRecords;
            }

            logJobMessage($"Salesforce record not found for Oem : {parms.Oem} , Month : {parms.Month} , Year : {parms.Year}", jobId);
            return new List<CampaignPrintMetadatum>();
        }

*/




// You can define other methods, fields, classes and namespaces here
class Foo
{
    public Foo()
    {
        MyProperty=Guid.NewGuid().ToString();
    }
    public string MyProperty { get; set; }
}

IEnumerable<Foo> GetFoos(bool returnNull = false, int size=2)
{
    if(returnNull)
        return null;

    //return Enumerable.Repeat(new Foo(),size);
    // noteworthy: this statement returns two objecs with the same GUID value
    
    var foos=new List<Foo>();
    
    for (int i = 0; i < size; i++)
    {
        foos.Add(new Foo());
    }
    
    return foos;
}