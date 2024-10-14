<Query Kind="Program" />

void Main()
{
    var foo = new Foo { FooBar = new Bar() };

    var fizzies = foo.FooBar.Zeus.Select(x => x.Fizz());

    //    fizzies.Dump();
    //    fizzies.Dump();

    var yyz = foo.FooBar.ZeusEnumerable("1");

    yyz.Select(x => x.Fizz()).Dump();
    yyz.Select(x => x.Fizz()).Dump();
    yyz.Select(x => x.Fizz()).Dump();
    yyz.Select(x => x.Fizz()).Dump();

    "-----------------------------------------------------".Dump();

    /*
 Probably a better and closer-to-real-life demonstration
 of this can be had, but this shows how the same variable,
 with an IEnumerable attribute, can be forced to enumerate
 the collection for each call.
 
 Actually, I need a better example, since all this is showing 
 is that the method is getting called over and over again, not
 that the IEnumerable is getting re-enumerated.
 */

    var yyz2 = foo.FooBar;

    yyz2.ZeusEnumerable("2a").Select(x => x.Fizz()).Dump();
    yyz2.ZeusEnumerable("2b").Select(x => x.Fizz()).Dump();
    yyz2.ZeusEnumerable("2c").Select(x => x.Fizz()).Dump();
    yyz2.ZeusEnumerable("2d").Select(x => x.Fizz()).Dump();


}

public class Foo
{
    public Bar FooBar { get; set; }
}

public class Bar : IBar
{
    private IEnumerable<IZoo> zeus = null;

    public int Baz()
    {
        return 10;
    }

    public string Fuzz { get; set; }

    public IEnumerable<IZoo> Zeus { get => GetBarZeus(); set => SetBarZeus(value); }

    private IEnumerable<IZoo> SetBarZeus(IEnumerable<IZoo> value)
    {
        throw new NotImplementedException();
    }

    private IEnumerable<IZoo> GetBarZeus()
    {
        return zeus ?? CreateNewZeus();
    }

    private IEnumerable<IZoo> CreateNewZeus()
    {
        zeus = new[]
        {
            new Zoo(),
            new Zoo(),
            new Zoo()
        };

        return zeus;
    }

    public IEnumerable<IZoo> ZeusEnumerable(string msg = null)
    {
        if (msg != null)
            msg.Dump("ZeusEnumerable");

        // this checks if instance variable is null populates it if so, then returns it
        return GetBarZeus();
    }
}

public class Zoo : IZoo
{
    private readonly string zoo;
    public Zoo()
    {
        zoo = $"zoo id: {Guid.NewGuid()} created: {DateTime.Now.ToString("HH:mm:ss.fffffff")}";
    }
    public string Fizz()
    {
        return zoo;
    }
}

public interface IBar
{
    int Baz();
    string Fuzz { get; set; }
    IEnumerable<IZoo> Zeus { get; set; }
    IEnumerable<IZoo> ZeusEnumerable(string msg = null);
}

public interface IZoo
{
    string Fizz();
}

