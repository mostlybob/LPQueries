<Query Kind="Program" />

void Main()
{
    var collection = BuildComplexCollection();
    //collection.Dump();

    collection.SelectMany(c => c.Bars).Dump("c.Bars");

    /*
    Notes
    - SelectMany requires its Func input parm
      to have a property of IEnumerable which
      is selected to return
    - by default, it looks like it sorts by 
      top-level collection, then next level down
    
    Next, try another layer of collection
    
    */

    var moreFoos = Enumerable.Range(0, 4).Select(e => BuildComplexCollection(e));

    var moreBars = moreFoos.SelectMany(f => f.SelectMany(g => g.Bars));
    // nested SelectMany calls, by the look of it - makes sense

    moreBars.Count().Dump("How many bars?");
    moreBars.Select(x => x.Name).Distinct().Count().Dump("Distinct Names");
    // just want to check my builder wasn't doing dupes


    /*
    var hmmm=new Dictionary<int,IEnumerable<Foo>>();
    hmmm[0]=collection;
    
    Enumerable.Range(1,4).Select(i=>hmmm[i]=BuildComplexCollection(i));
    
    hmmm.Dump();
    // interesting, but not what I had in mind
    */
}

public IEnumerable<Foo> BuildComplexCollection()
{
    return BuildComplexCollection(0);
}

public IEnumerable<Foo> BuildComplexCollection(int offset)
{
    var foos = new List<Foo>();
    for (int i = 0; i < 5; i++)
    {
        var fooName = $"{i.ToString("00")} + {offset}";
        var foo = new Foo
        {
            Name = fooName,
            Age = (i + offset) * 3
        };

        var bars = new List<Bar>();

        for (int j = 0; j < 10; j++)
        {
            bars.Add(new Bar
            {
                Name = $"Foo({fooName}) Bar({j.ToString("00")})",
                Height = (j + 1 + offset) * 2 + i * j,
                Width = (j + 2 + offset) * 3 + i * j
            });
        }
        foo.Bars = bars;

        foos.Add(foo);
    }

    return foos;
}

// Define other methods and classes here
public class Foo
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public IEnumerable<Bar> Bars { get; set; }

    public Foo()
    {
        Id = Guid.NewGuid();
        Bars = new List<Bar>();
    }
}

public class Bar
{
    public string Name { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
}