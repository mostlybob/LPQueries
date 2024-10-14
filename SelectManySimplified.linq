<Query Kind="Program" />

void Main()
{
    var bazzes = BuildBazzes();
    
    bazzes.Dump("Primary");
    bazzes.SelectMany(b => b.Bars).Dump("Secondary");
    bazzes.SelectMany(b => b.Bars.SelectMany(ba => ba.Foos)).Dump("Tertiary");
}

List<Baz> BuildBazzes()
{
    var bazzes = new List<Baz>();
    for (int i = 0; i < 5; i++)
    {
        var bazName = $"Baz {i}";
        var baz = new Baz { Name = bazName };
        var bars = new List<Bar>();
        for (int j = 0; j < 5; j++)
        {
            var barName = $"{bazName} | Bar {j}";
            var bar = new Bar { Name = barName };
            var foos = new List<Foo>();
            for (int k = 0; k < 5; k++)
            {
                var fooName = $"{barName} | Foo {k}";
                foos.Add(new Foo { Name = fooName });
            }
            bar.Foos = foos;
            bars.Add(bar);
        }
        baz.Bars = bars;
        bazzes.Add(baz);
    }
    
    return bazzes;
}


class Foo
{
    public string Name { get; set; }
}

class Bar
{
    public string Name { get; set; }
    public IEnumerable<Foo> Foos { get; set; }
}

class Baz
{
    public string Name { get; set; }
    public IEnumerable<Bar> Bars { get; set; }
}