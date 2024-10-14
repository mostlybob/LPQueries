<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main(string[] args)
{
    
    SynchronizationContext.SetSynchronizationContext(new MyContext());
    MethodA().Wait();
    Console.WriteLine("Completed");

    /*
    https://vkontech.com/exploring-the-async-await-state-machine-nested-async-calls-and-configureawaitfalse/
    
    With no ConfigureAwait anywhere (note the two invocations of MyContext):
        MyContext invoked
        MethodB Continuation
        MyContext invoked
        MethodA Continuation
        Completed

    With ConfigureAwait(false) only applied to MethodB() call within MethodA():
        MyContext invoked
        MethodB Continuation
        MethodA Continuation
        Completed
    
    With ConfigureAwait(false) only applied to Task.Delay(100) statement in MethodB():
        MethodB Continuation
        MyContext invoked
        MethodA Continuation
        Completed    

    With both of the above cases ie. ConfigureAwait(false) on both:
        MethodB Continuation
        MethodA Continuation
        Completed
    */
    
    
    
    
    
    
    
}

private class MyContext : SynchronizationContext
{
    public override void Post(SendOrPostCallback d, object state)
    {
        Console.WriteLine($"{nameof(MyContext)} invoked");
        d(state);
    }
}
public static async Task MethodA()
{
    await MethodB().ConfigureAwait(false);
    Console.WriteLine("MethodA Continuation");
}

public static async Task MethodB()
{
    await Task.Delay(100).ConfigureAwait(false);
    Console.WriteLine("MethodB Continuation");
}