<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    //    FirstExample();

    Console.WriteLine("Begin");
    ThisWouldNormallyBeAnEventHandler2();
    Console.WriteLine("End");

}


void FirstExample()
{
    Console.WriteLine("Begin");
    ThisWouldNormallyBeAnEventHandler();
    Console.WriteLine("End");
}

async Task<int> FooBar2()
{
    "FooBar2 !!".Dump();
    return 55;
}

Task<int> FooBar()
{
    "FooBar()".Dump();
    return new Task<int>(() => 55);
}

async void ThisWouldNormallyBeAnEventHandler2()
{
    bool result = await LoopAsyncWReturn().ConfigureAwait(false);
    result.Dump("the result");
}

async void ThisWouldNormallyBeAnEventHandler()
{
    await LoopAsync();
    "after LoopAsync".Dump();

    await LoopAsync(20);
    "after second LoopAsync".Dump();
}

async Task<bool> LoopAsyncWReturn()
{
    for (int i = 0; i < 20; i++)
    {
        Console.WriteLine(i);
        await Task.Delay(1);

        // adding this breaks things (at least Linqpad stops following the execution)
        //int foobar = await FooBar();
        
        // this does not!
        int foobar=await FooBar2();
        
        
        Console.WriteLine($"foobar ({i})");
    }
    $"end of loop".Dump();

    return true;
}

async Task LoopAsync(int offset = 0)
{
    for (int i = 0; i < 20; i++)
    {
        Console.WriteLine(i + offset);
        await Task.Delay(1);
    }
    $"end of loop ({offset})".Dump();
}