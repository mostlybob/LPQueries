<Query Kind="Program" />

/*
https://www.simplethread.com/c-closures-explained/

*/

void Main()
{
    //    SimpleThreadDemo();
    BlackWaspDemo();
}

#region BlackWaspDemo

static Action _closure;
void BlackWaspDemo()
{
    //http://www.blackwasp.co.uk/CSharpClosures.aspx

    SetUpClosure();
    _closure();     // 1 + 1 = 2

    /*
    Although we've seen closures working, they aren't really supported by C# 
    and the .NET framework. What really happens is some behind-the-scenes work 
    by the compiler. When you build your project, the compiler generates a new, 
    hidden class that encapsulates the non-local variables and the code you 
    include in the anonymous method or lambda expression. The code is included 
    in a method and the non-local variables are represented as fields. This new 
    class's method is called when the delegate is executed.
    */

    //Closures Capture Variables, Not Values

    int nonLocal = 1;
    Action closure = delegate
    {
        Console.WriteLine("{0} + 1 = {1}", nonLocal, nonLocal + 1);
    };

    nonLocal = 10;

    // because the variable's value changes between delegate declaration & execution,
    // when the delegate is executed, it uses the later value (not true for all languages)
    closure();      //10 + 1 = 11

    // unlike SimpleThreadDemo(), however, changing the value now affects  
    // subsequent exections, because the variable is still in scope
    nonLocal = 50;

    closure();      //50 + 1 = 51

    // goes both directions too - changes inside the closure affect the variable's value
    int nonLocal2 = 1;
    Action closure2 = delegate
    {
        nonLocal2++;
    };
    closure2();

    Console.WriteLine(nonLocal2);    // 2

    /*
    There are also race conditions to be aware of with threading, 
    if the closure uses a variable shared across threads:
    */
    for (int i = 1; i <= 5; i++)
    {
        new Thread(delegate()
        {
            Thread.Sleep(100);
            Console.Write(i);
        }).Start();
    }

    Thread.Sleep(300);
    Console.WriteLine();
    /*
    Thread-safe solution is to declare a new variable for each thread instance.
    (Interesting that the demo showed "12345" - mine doesn't necessarily, although 
    I suppose at some point it could, just by chance)
    */

    for (int i = 1; i <= 5; i++)
    {
        int value = i;
        new Thread(delegate()
        {
            Thread.Sleep(100);
            
//            Console.Write(value);
            Console.Write($"{value} - {DateTime.Now.ToString("fffff")} | ");    // just for my own curiosity
        }).Start();
    }

}

private static void SetUpClosure()
{
    int nonLocal = 1;
    _closure = () =>
    {
        Console.WriteLine("{0} + 1 = {1}", nonLocal, nonLocal + 1);
    };
}

#endregion

#region CSharpInDepthDemo

public void CSharpInDepthDemo()
{
    // https://csharpindepth.com/articles/Closures
}

#endregion


#region SimpleThreadDemo

public void SimpleThreadDemo()
{
    // https://www.simplethread.com/c-closures-explained/

    //    var inc = GetAFunc();

    var a = 1;
    var inc = GetAFunc(a);      //testing by ref; a's assignment in the func holds its value (I expected that)

    // With the first execution of the func, its local variable, myVal, 
    // now has a persistent value inside the func that lasts, and can be incremented,
    // while the inc variable is in scope.
    Console.WriteLine(inc(5));
    Console.WriteLine(inc(6));
    Console.WriteLine();

    a = 20;       //changing a has no effect

    // my own spin
    for (int i = 0; i < 10; i++)
    {
        var foo = inc(i);
        // notice it keeps the closure's myVar value from the previous two calls to inc()

        $"{i}: {foo} ({foo - i})".Dump();
    }

    Console.WriteLine();

    //what about multiple calls with the same value?
    for (int i = 0; i < 10; i++)
    {
        var foo = inc(3);
        $"{i}: {foo} ({foo - i})".Dump();
        // and it hung onto the value set in the last loop (of course)
    }
}

public static Func<int, int> GetAFunc()
{
    var myVar = 1;
    Func<int, int> inc = delegate (int var1)
                            {
                                myVar = myVar + 1;
                                //                                myVar.Dump("inside GetAFunc()");
                                return var1 + myVar;
                            };

    return inc;
}

public static Func<int, int> GetAFunc(int initVal)
{
    var myVar = initVal;
    Func<int, int> inc = delegate (int var1)
                            {
                                myVar = myVar + 1;
                                //                                myVar.Dump("inside GetAFunc()");
                                return var1 + myVar;
                            };

    return inc;
}

#endregion