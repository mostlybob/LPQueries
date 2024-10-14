<Query Kind="Program" />

void Main()
{
    var collection = BuildComplexCollection();

    collection.Dump();
    
    
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