<Query Kind="Program">
  <Namespace>System.Reflection.Emit</Namespace>
</Query>


/*

https://stackoverflow.com/questions/4803272/in-c-is-expression-api-better-than-reflection

see also linked article by Jon Skeet:
  https://stackoverflow.com/questions/597819/delegate-createdelegate-vs-dynamicmethod-vs-expression
*/

public class Foo
{
    public string Bar(int value) { return value.ToString(); }
}

void Main()
{
    object foo = new Foo();

    // We have an instance of something and want to call a method with this signature on it :
    // public string Bar(int value);

    const string a="Cast and Direct method call";
    Console.WriteLine(a);
    {
        Start(a);
        var result = ((Foo)foo).Bar(42);
        result.Dump();
        Stop(a);
    }
    Console.WriteLine("Create a lambda closing on the local scope.");
    {
        // Useless but i'll do it at the end by manual il generation

        Func<int, string> func = i => ((Foo)foo).Bar(i);
        var result = func(42);
        result.Dump();
    }
    Console.WriteLine("Using MethodInfo.Invoke");
    {
        var method = foo.GetType().GetMethod("Bar");
        var result = (string)method.Invoke(foo, new object[] { 42 });
        result.Dump();
    }
    Console.WriteLine("Using the dynamic keyword");
    {
        var dynamicFoo = (dynamic)foo;
        var result = (string)dynamicFoo.Bar(42);
        result.Dump();
    }
    Console.WriteLine("Using CreateDelegate");
    {
        var method = foo.GetType().GetMethod("Bar");
        var func = (Func<int, string>)Delegate.CreateDelegate(typeof(Func<int, string>), foo, method);
        var result = func(42);
        result.Dump();
    }
    Console.WriteLine("Create an expression and compile it to call the delegate on one instance.");
    {
        var method = foo.GetType().GetMethod("Bar");
        var thisParam = Expression.Constant(foo);
        var valueParam = Expression.Parameter(typeof(int), "value");
        var call = Expression.Call(thisParam, method, valueParam);
        var lambda = Expression.Lambda<Func<int, string>>(call, valueParam);
        var func = lambda.Compile();
        var result = func(42);
        result.Dump();
    }
    Console.WriteLine("Create an expression and compile it to a delegate that could be called on any instance.");
    {
        // Note that in this case "Foo" must be known at compile time, obviously in this case you want
        // to do more than call a method, otherwise just call it !
        var type = foo.GetType();
        var method = type.GetMethod("Bar");
        var thisParam = Expression.Parameter(type, "this");
        var valueParam = Expression.Parameter(typeof(int), "value");
        var call = Expression.Call(thisParam, method, valueParam);
        var lambda = Expression.Lambda<Func<Foo, int, string>>(call, thisParam, valueParam);
        var func = lambda.Compile();
        var result = func((Foo)foo, 42);
        result.Dump();
    }
    Console.WriteLine("Create a DynamicMethod and compile it to a delegate that could be called on any instance.");
    {
        // Same thing as the previous expression sample. Foo need to be known at compile time and need
        // to be provided to the delegate.

        var type = foo.GetType();
        var method = type.GetMethod("Bar");

        var dynamicMethod = new DynamicMethod("Bar_", typeof(string), new[] { typeof(Foo), typeof(int) }, true);
        var il = dynamicMethod.GetILGenerator();
        il.DeclareLocal(typeof(string));
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Call, method);
        il.Emit(OpCodes.Ret);
        var func = (Func<Foo, int, string>)dynamicMethod.CreateDelegate(typeof(Func<Foo, int, string>));
        var result = func((Foo)foo, 42);
        result.Dump();
    }
    Console.WriteLine("Simulate closure without closures and in a lot more lines...");
    {
        var type = foo.GetType();
        var method = type.GetMethod("Bar");

        // The Foo class must be public for this to work, the "skipVisibility" argument of
        // DynamicMethod.CreateDelegate can't be emulated without breaking the .Net security model.

        var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
            new AssemblyName("MyAssembly"), AssemblyBuilderAccess.Run);
        var module = assembly.DefineDynamicModule("MyModule");
        var tb = module.DefineType("MyType", TypeAttributes.Class | TypeAttributes.Public);

        var fooField = tb.DefineField("FooInstance", type, FieldAttributes.Public);
        var barMethod = tb.DefineMethod("Bar_", MethodAttributes.Public, typeof(string), new[] { typeof(int) });
        var il = barMethod.GetILGenerator();
        il.DeclareLocal(typeof(string));
        il.Emit(OpCodes.Ldarg_0); // this
        il.Emit(OpCodes.Ldfld, fooField);
        il.Emit(OpCodes.Ldarg_1); // arg
        il.Emit(OpCodes.Call, method);
        il.Emit(OpCodes.Ret);

        var closureType = tb.CreateType();

        var instance = closureType.GetConstructors().Single().Invoke(new object[0]);

        closureType.GetField(fooField.Name).SetValue(instance, foo);

        var methodOnClosureType = closureType.GetMethod("Bar_");

        var func = (Func<int, string>)Delegate.CreateDelegate(typeof(Func<int, string>), instance,
            closureType.GetMethod("Bar_"));
        var result = func(42);
        result.Dump();
    }
}

string FormattedTimeSpan(TimeSpan stamp)
{
    return stamp.ToString(@"d\d\ hh\:mm\:ss\.fffffff");
}

bool timerIsRunning = false;
bool timerIsNotRunning => timerIsRunning == false;

DateTime startTime;


string Start(string timerId = null)
{
    if (timerId == null)
        timerId = Guid.NewGuid().ToString();

    if (timerIsRunning)
    {
        var runningMessage = "Timer already running. Stopping it and starting a new timer. This may lose previous timer id.";
        runningMessage.Dump();
        Stop(timerId, true);
    }

    var startMessage = $"Starting timer for timer id {timerId}";
    startMessage.Dump();

    startTime = DateTime.Now;
    timerIsRunning = true;

    return timerId;
}

string Stop(string timerId = null, bool restart = false)
{
    if (timerIsNotRunning)
    {
        "Timer is not running currently".Dump();
        return string.Empty;
    }

    timerIsRunning = false;

    var elapsed = DateTime.Now - startTime;
    var localTimerId = timerId ?? string.Empty;

    var timerIdMessage = string.IsNullOrEmpty(localTimerId)
        ? string.Empty
        : $"for timer id {localTimerId}";

    var stopMessage = $"Stopping timer {timerIdMessage}";
    stopMessage.Dump();

    var elapsedMessage = $"Elapsed time: {FormattedTimeSpan(elapsed)} {timerIdMessage}\n";
    elapsedMessage.Dump();

    if (restart)
    {
        var restartMessage = "Restarting timer";
        restartMessage.Dump();
        return Start();
    }

    return localTimerId;
}
