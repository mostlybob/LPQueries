<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net</Namespace>
</Query>


// borrowed and modified version of "Note on async Main and LINQPad" in the Samples

/* 2022-07-14
-------------

what I've learned, after a somewhat maddening couple of days
- starting with a plain void
- call an async void method to wrap the code to test

- with the nested await method calls have signature `Task<T>`,
    e.g. the FooBar() method
  LINQPad detaches the debugger and runs the process outside of LINQPad

- with the nested await method calls have signature `async Task<T>`
    e.g. the FooBar2() method
  LINQPad stays attached, however setting a breakpoint only stops 
  at the breakpoint; any continuation runs the rest of the code (similar to F5)
  instead of sequentially stepping (like F10/F11)
  
- would probably need to go at it old-school, dropping debugger comments
  to the console to inspect the values at runtime

*/

async Task Main()
//void Main()
{
    Fooz();
}

async void Fooz()
{
    "Starting".Dump();
    string[] uris =
    {
        "http://linqpad.net",
        "http://linqpad.net/downloadglyph.png",
	};

    int result = await GetTotalLength(uris);
    result.Dump("result");

    "Finishing Fooz".Dump();
}

async Task<int> GetTotalLength(string[] uris)   // This now returns a Task<int>
{
    "Working...".Dump();
    int totalLength = 0;
    foreach (string uri in uris)
    {
        string html = await new WebClient().DownloadStringTaskAsync(new Uri(uri));
        totalLength += html.Length;

        //var foo = await FooBar();
        var foo = await FooBar2();

        foo.Dump("foo");
    }

    return totalLength;    // We must return an integer if our method returns Task<int>
}

Task<int> FooBar()
{
    "FooBar()".Dump();
    return new Task<int>(() => 55);
}

async Task<int> FooBar2()
{
    "FooBar2 !!".Dump();
    return 55;
}

//--------------------------------------