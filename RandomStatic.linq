<Query Kind="Program" />

static Random rando = new Random();

void Main()
{
    var foo = new Foo();

    for (int i = 0; i < 20; i++)
    {
        //does randoms
        //rando.Next(1,100).Dump();

        var local = rando.Next(1,100);
        var one = foo.Test1();
        var two = foo.Test2();
        var three = foo.Test3();

        //        $"{one} | {two}".Dump();
        $"{local} | {one} | {two} | {three}".Dump();

    }

    "\ntry it again with my fancy dancy non-static RNG\n".Dump();

    var rnd = BuildNewRandom();
    for (int i = 0; i < 20; i++)
    {
        var locala = rando.Next(1, 100);
        var localb = rando.Next(1, 100);
        var one = foo.Test1();
        var two = foo.Test2();
        var three = foo.Test3();
        var local2 = rnd.Next(100);
        var local3 = rnd.Next(100);

        //        $"{one} | {two}".Dump();
        $"({locala}:{localb}) | ({local2}:{local3}) | {one} | {two} | {three}".Dump();
        
        /*
        Interesting & I'm sure there's some distinction(s) to make, but I think
        using the static local variable should be workable for most of the scenarios 
        I'm likely to see
        */
    }
 }

int seed = -1;

Random BuildNewRandom()
{
    while (seed == DateTime.Now.Millisecond)
    { }

    seed = DateTime.Now.Millisecond;

    return new Random(seed);
}

// Define other methods and classes here

public class Foo
{
    private static Random rando1;
    private static Random rando2 = new Random();

    public Foo()
    {
        rando1 = new Random();
    }

    public int Test1()
    {
        return rando1.Next(1, 100);
    }

    public int Test2()
    {
        return rando2.Next(1, 100);
    }

    public string Test3()
    {
        var rnd = new Random();
        var one = rnd.Next(1, 100);
        var two = rnd.Next(1, 100);
        return $"{one} - {two}";
    }
}