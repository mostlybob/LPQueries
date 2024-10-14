<Query Kind="Program" />

void Main()
{
    var foo=Enumerable.Repeat('x',20).ToArray();
    
    new String(foo).Dump();
    foo.Dump();
    
    /*
    var foo = Enumerable.Range(1, 100);
    foo.Dump();

    double[] array_repeat = Enumerable.Repeat(Math.PI, 20).ToArray();
    array_repeat.Dump();
    */
}