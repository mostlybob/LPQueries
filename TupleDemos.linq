<Query Kind="Program" />

// some of what's here came from https://riptutorial.com/csharp/example/6329/language-support-for-tuples

void Main()
{
    //Demo1();
    //Demo2();
    
    Demo3();
}

void Demo3()
{
    var name = (first: "John", middle: "Q", last: "Smith");
    
    name.GetType().Name.Dump(); // ValueTuple - since it has named properties
    
    name.Dump();
    
    name.first.Dump();
    name.Item1.Dump();  // ValueTuple extends Tuple, so Item1 is available
    name.first.Equals(name.Item1).Dump();  // they're the same
}

void Demo2()
{
    var (a, b) = TestTuple2();
    a.Dump();
    b.Dump();
    
    (a,b)=(b,a); // switching
    a.Dump();
    b.Dump();
    
    
}

void Demo1()
{
    (string, int, double) test1 = TestTuple();
    test1.Dump();

    (string s, int i, double d) = TestTuple();
    s.Dump();
    i.Dump();
    d.Dump();

    var (s1, i1, d1) = TestTuple();
    s1.Dump();
    i1.Dump();
    d1.Dump();

}

private static (string, int, double) TestTuple()
{
    return ("Test",10, 100.35);
}

private static (int, int) TestTuple2()
{
    return (10,200);
}