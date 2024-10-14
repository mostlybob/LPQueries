<Query Kind="Program" />

void Main()
{
    Program.OutputHeader("running SimpleInstanceDemo");
    Program.OutputHeader(SimpleDemoExplanation);
    Program.SimpleInstanceDemo();

    Program.OutputHeader("running ExpressionsDemo");
    Program.OutputHeader(ExpressionsDemoExplanation);
    Program.ExpressionsDemo();

}

const string SimpleDemoExplanation = 
@"This demo shows that when using concretes for injection at runtime, the object comes
in fully hydrated. Regardless of which methods on the injected instance are subsequently
called (or not called), the object has been fully instantiated, having invoked and now 
carrying whatever overhead that involves.";

const string ExpressionsDemoExplanation =
@"This demo shows how using Func<interface> for injection at runtime, the injected 
expression doesn't actually do anything, including any of the overhead of instantiation, 
until it's invoked. No matter how many expressions are injected into the class, at runtime,
only the injected Funcs that are invoked to run a method actually go through instantiation.";

class Program
{
    public static void ExpressionsDemo()
    {
        OutputMessage("new up the expressions demos");

        var demoNone = GetNewExpressionsDemoExample();
        var demoFoo = GetNewExpressionsDemoExample();
        var demoBar = GetNewExpressionsDemoExample();
        var demoBoth = GetNewExpressionsDemoExample();

        OutputMessage("call that only calls Foo's method");
        demoFoo.CallFoo();

        OutputMessage("call that only calls Bar's method");
        demoBar.CallBar();

        OutputMessage("call that only calls both Foo's and Bar's methods");
        demoBoth.CallFooAndBar();

        OutputMessage("call that doesn't call any of the expressions' methods");
        demoNone.CallNothing();
    }

    public static DemoWithExpressions GetNewExpressionsDemoExample()
    {
        return new DemoWithExpressions(() => new Foo(), () => new Bar());
    }

    public static void SimpleInstanceDemo()
    {
        OutputMessage("instantiating Foo - notice that the constructor's code runs immediately");
        IFoo foo = new Foo();
        OutputMessage("calling Foo's method");
        foo.SomethingFooDoes();

        OutputMessage("creating expression variable - just like Foo, only it's Func<IFoo> !!!");
        Func<IFoo> fooExpression = () => new Foo();
        
        Sleep5s();
        /* 
        This pause is just to demonstrate that despite the variable 
        being created, Foo's constructor isn't actually invoked until 
        the expression gets evaluated.
        */

        OutputMessage("calling Func<IFoo> expression variable's method (Foo isn't actually instantiated until now)");
        fooExpression().SomethingFooDoes();

        OutputMessage("Voilà!");
    }

    public static void Sleep5s()
    {
        OutputMessage("sleeping for 5s");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"{i + 1}  ");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine("");
    }

    public static string GetCurrentTime()
    {
        return DateTime.Now.ToLongTimeString();
    }

    public static void OutputMessage(string message, bool includeTimeStamp = true)
    {
        var stamp = includeTimeStamp
            ? $"{GetCurrentTime()} - "
            : string.Empty;

        Console.WriteLine($"{stamp}{message}");
    }

    const int LineWidth = 120;
    const char HeaderLeader = '=';

    public static void OutputHeader(string message)
    {
        var diff = LineWidth - message.Length;
        var nl = Environment.NewLine;

        if (diff <= 1)
        {
            OutputMessage($"{nl}{message}{nl}", false);
            return;
        }

        var lengthLeader = diff / 2 - 1;

        var leader = new String(Enumerable.Repeat(HeaderLeader, lengthLeader).ToArray());

        var newMessage = $"{leader} {message} {leader}";

        var even = false;

        while (newMessage.Length > LineWidth)
        {
            newMessage = even
                ? newMessage.Substring(1)
                : newMessage.Substring(0, newMessage.Length - 1);
        }

        while (newMessage.Length < LineWidth)
        {
            newMessage = even
                ? newMessage + HeaderLeader
                : HeaderLeader + newMessage;
        }

        OutputMessage($"{nl}{newMessage}{nl}", false);
    }
}

public class DemoWithExpressions
{
    private Func<IFoo> foo;
    private Func<IBar> bar;
    public DemoWithExpressions(Func<IFoo> foo, Func<IBar> bar)
    {
        this.foo = foo;
        this.bar = bar;
    }

    public void CallNothing()
    {
        Program.OutputMessage("\t\t\t(neither foo nor bar had their methods called - and hence no constructors ran)");

        /*
        Using expresssions for the injections means that no constructors
        get called in this method. If this is the only method that gets
        called during the lifetime of this object, the expressions for
        foo & bar instance variables never get evaluated and the respective
        constructors never get called, since they're never needed. As a 
        result, that overhead is never incurred, which makes for better
        resource allocation.
        */
    }

    public void CallFoo()
    {
        Program.OutputMessage("\t\tcalling foo now");
        foo().SomethingFooDoes();

        /*
        When the foo expression is evaluated, the constructor gets invoked,
        and only then. Despite the fact that IBar has been injected in this
        class, its constructor has not been invoked yet. If this is the only 
        method called during this object's lifespan, or if other methods 
        in this class only call methods on foo, the IBar instance expression 
        variable will never be invoked and the app will not incur that overhead.
        */
    }

    public void CallBar()
    {
        Program.OutputMessage("\t\tcalling bar now");
        bar().SomethingBarDoes();

        /*
        Similar to the previous method, if this is the only method called,
        foo's expression will not be evaluated and the app will not incur
        that overhead
        */
    }

    public void CallFooAndBar()
    {
        Program.OutputMessage("\t\tcalling Foo's method now. Bar's method is called after the pause.");
        foo().SomethingFooDoes();

        Program.Sleep5s();

        Program.OutputMessage("\t\tcalling Bar's method now (notice Bar's constructor isn't called until now)");
        bar().SomethingBarDoes();

        /*
        This method evaluates both expressions and executes their methods; however
        even with both expressions being invoked, their respective constructors
        are still only called immediately before the method invocation happens.
        */
    }
}

public interface IFoo
{
    void SomethingFooDoes();
}

public class Foo : IFoo
{
    public Foo()
    {
        Program.OutputMessage("\t\t\t\tFoo constructor code");
    }

    public void SomethingFooDoes()
    {
        Program.OutputMessage("\t\t\t\tFoo.SomethingFooDoes() method code");
    }
}

public interface IBar
{
    void SomethingBarDoes();
}

public class Bar : IBar
{
    public Bar()
    {
        Program.OutputMessage("\t\t\t\tBar constructor code");
    }

    public void SomethingBarDoes()
    {
        Program.OutputMessage("\t\t\t\tBar.SomethingBarDoes() method code");
    }
}
