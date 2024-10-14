<Query Kind="Program" />

void Main()
{
    var foo=new List<int>();
    for (int i = 0; i < 10000; i++)
    {
        for (int j = 0; j < 6; j++)
        {
            foo.Add(i+j);
        }
    }

//    foo.Count().Dump();
    

    var bar = foo.GroupBy(f => f)
        .Select(x => new
        {
            x.Key,
            Count = x.Count()
        });
    
    bar.Dump();
    
    
}

// Define other methods and classes here