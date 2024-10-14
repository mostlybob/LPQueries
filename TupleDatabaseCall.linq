<Query Kind="Program" />

void Main()
{
    var foo = new {Name="foo",Age=10};
    
    foo.Dump();
    
    GetList().Dump();
    
    
    
    
    /**************************************************************************************
    
    // this is how the database call might look
    // note that what's coming back is a collection of tuples, sort of like anonymous objects
    
    //IEnumerable<(int, string)> jobData = imDb.Select<(int, string)>("SELECT JobID, JobName FROM Job");

    **************************************************************************************/
    
    var limit = 0;
    foreach ((string name, int jobId) in GetList())
    {
        if (limit++ < 20)
            Console.WriteLine($"ID: {jobId}, Name: {name}");
    }

}

private IEnumerable<(string, int)> GetList()
{
    var objx = new List<(string, int)>();
    for (int i = 0; i < 100; i++)
    {
        objx.Add(ListData(i));
    }
    
    return objx;
}

private static (string, int) ListData(int index)
{
    return ($"foo{index}", index);

}
