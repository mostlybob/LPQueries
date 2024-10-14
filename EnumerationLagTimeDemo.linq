<Query Kind="Program" />

void Main()
{
    $"{DateTime.Now} - getting data".Dump();
    var foo=GetData();
    
    $"{DateTime.Now} - waiting".Dump();
    Thread.Sleep(5000);


    $"{DateTime.Now} - assigning bar; only defines where filter - doesn't actually execute it".Dump();
    var bar = foo.Where(x =>
    {
        if (x.TestVal<=3)
            return false;
        
        // this demos that the where only gets executed when bar is enumerated
        // not when it's assigned
        x.Date2=DateTime.Now;
        Thread.Sleep(1000);
        
        return x.TestVal > 3;
    });
    
    $"{DateTime.Now} - dumping foo".Dump();
    foo.Dump();

    $"{DateTime.Now} - waiting some more".Dump();
    Thread.Sleep(5000);

    $"{DateTime.Now} - dumping bar (enumerating)".Dump();
    bar.Dump();

/*
    $"{DateTime.Now} - ".Dump();

    $"{DateTime.Now} - ".Dump();
    $"{DateTime.Now} - ".Dump();
    */
}

// You can define other methods, fields, classes and namespaces here
public class TestingDataModel
{
    public TestingDataModel()
    {
        Id=Guid.NewGuid();
    }
    public Guid Id{get;private set;}
    public DateTime? Date { get; set; }
    public DateTime? Date2 { get; set; }
    public int TestVal{get;set;}
}

IEnumerable<TestingDataModel> GetData()
{
    var list = new List<TestingDataModel>();
    
    for (int i = 0; i < 6; i++)
    {
        var now=DateTime.Now;
        list.Add(new TestingDataModel{Date=now, Date2=now,TestVal=i});
        Thread.Sleep(1000);
    }
    
    return list;
}