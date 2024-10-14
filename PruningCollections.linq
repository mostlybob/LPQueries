<Query Kind="Program">
  <Namespace>System.Collections.ObjectModel</Namespace>
</Query>

void Main()
{
//    var array1 = new Collection<int> { 1, 2, 3,4,5,6 };
//    
//    array1.Dump();
//    
//    array1.Remove(3);
//    
//    array1.Dump();
    
    
    var foo=new Foo();
    
    foo.Widgets.Dump("before");
    
    var toRemove=new List<Bar>();
    
    foreach (var w in foo.Widgets)
    {
        if (w.Rank == 5)
        {
            toRemove.Add(w);
        }
    }
    
    foreach (var el in toRemove)
    {
        foo.Widgets.Remove(el);
    }
    
    foo.Widgets.Dump("after");
}

// Define other methods and classes here


class Foo
{
    public Foo() : this(10, "default")
    { }

    public Foo(int collectionSize, string objectName)
    {
        Name = objectName;

        var widgets = new Collection<Bar>();

        for (int i = 0; i < collectionSize; i++)
        {
            widgets.Add(new Bar { Rank = i + 1});
        }

        Widgets = widgets;
    }

    public Collection<Bar> Widgets { get; private set; }
    public string Name { get; private set; }
}

class Bar
{
    public Bar()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
    public int Rank{get; set;}
}