<Query Kind="Program" />

void Main()
{
    var foo = GetTotals();

    foo.Dump("foo");
    //    foo.Dump();
    //    foo.Select(MapResultzzz).Dump();
    //
    //    foo.Select(MapResultzzz).GroupBy(x => x, (key, value) => { return new { Code = key, Count = value.Sum(z => z.Count)};}).Dump();
    //    foo.Select(MapResultzzz).GroupBy(x => x, (key, value) => { return value.Sum(y => y.Count); }).Dump();
//    foo.Select(MapResultzzz)
//    .GroupBy(x => x.NcoaCode, (key, value) => 
//    { 
//        return new 
//        {
//            NCOACode = key, 
//            Total = value.Select(z => z.Count)
//                .Sum(a => a)
//        };
//    }).Dump();

    var ncoaCodesByDealer = foo.Select(MapResultzzz)
        .GroupBy(x => x.NcoaCode, (key, value) =>
            new
            {
                NcoaCode = key,
                Total = value
                    .Select(z => z.Count)
                    .Sum(a => a)
            }
        );
    
    var ncoaOther = ncoaCodesByDealer
                .Where(x => x.NcoaCode == "Other");

    var ncoaCodesSorted = ncoaCodesByDealer
        .Where(x => x.NcoaCode != "Other")
        .OrderBy(x => x.NcoaCode)
        .ToList();

    ncoaCodesSorted.AddRange(ncoaOther);
       
    ncoaCodesSorted.Dump("ncoaCodesSorted");




}

private NcoaCountRecord MapResultzzz(NcoaCountRecord ncoaCountRecord)
{
    var ncoaCode = ncoaCountRecord.NcoaCode ?? string.Empty;

    if (NcoaCodeLookup.Keys.Contains(ncoaCode))
        return new NcoaCountRecord { NcoaCode = NcoaCodeLookup[ncoaCode], Count = ncoaCountRecord.Count };    // NcoaCodeLookup[ncoaCountRecord.NcoaCode];

    return new NcoaCountRecord { NcoaCode = "Other", Count = ncoaCountRecord.Count };
}

private static Dictionary<string, string> NcoaCodeLookup = new Dictionary<string, string>
{
    { "10", "Invalid Address" },
    { "11", "Invalid City/State/ZIP" },
    { "12", "Invalid State" },
    { "13", "Invalid City/State/ZIP" },
    { "17", "Insufficient Address Data" },
    { "26", "PO Box Closed" },
    { "27", "No Forwarding Address" },
    { "28", "Foreign Move" },
    { "33", "Non-deliverable" },
    { "98", "Non-USPS ZIP" }
};


class NcoaCountRecord
{
    public string NcoaCode { get; set; }
    public int Count { get; set; }
}


List<NcoaCountRecord> GetTotals()
{
    return new List<NcoaCountRecord>
    {
        new NcoaCountRecord{NcoaCode=null,Count=    0},
        new NcoaCountRecord{NcoaCode="10",Count=3351},
        new NcoaCountRecord{NcoaCode="11",Count=  7997},
        new NcoaCountRecord{NcoaCode="12",Count=  720},
        new NcoaCountRecord{NcoaCode="13",Count=  7933},
        new NcoaCountRecord{NcoaCode="17",Count=  83775},
        new NcoaCountRecord{NcoaCode="21",Count=  2522242},
        new NcoaCountRecord{NcoaCode="22",Count=  158658},
        new NcoaCountRecord{NcoaCode="23",Count=  268073},
        new NcoaCountRecord{NcoaCode="26",Count=  10366},
        new NcoaCountRecord{NcoaCode="27",Count=  156694},
        new NcoaCountRecord{NcoaCode="28",Count=  4947},
        new NcoaCountRecord{NcoaCode="31",Count=  49293347},
        new NcoaCountRecord{NcoaCode="32",Count=  1954316},
        new NcoaCountRecord{NcoaCode="33",Count=  7022},
        new NcoaCountRecord{NcoaCode="36",Count=  5657927},
        new NcoaCountRecord{NcoaCode="37",Count=  1637496},
        new NcoaCountRecord{NcoaCode="38",Count=  147563},
        new NcoaCountRecord{NcoaCode="39",Count=  45869},
        new NcoaCountRecord{NcoaCode="98",Count=  31427}
    };
}


/*

NULL,0
10,3351
11,7997
12,720
13,7933
17,83775
21,2522242
22,158658
23,268073
26,10366
27,156694
28,4947
31,49293347
32,1954316
33,7022
36,5657927
37,1637496
38,147563
39,45869
98,31427


*/



// -----------------------------------------