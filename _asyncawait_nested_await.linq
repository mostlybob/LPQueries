<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
    // trying to figure out how to get values from nested async methods that return values
    // LinqPAD detaches the debugger and shows status bar message about running the query asynchronously
    
    
    "Starting".Dump();






//    Task<int> lengthTask = GetTotalLength();
//
//    await Task.WhenAll(lengthTask);
//
//    int length1 = lengthTask.Result;
//
//    int length = await lengthTask.ConfigureAwait(true);
//    length.Dump("result");

    
    Task<string> numericString = GetNumericString();
    await Task.WhenAll(numericString);
    string zzz=numericString.Result;
    zzz.Dump();
    
    
    "Done".Dump();
}

async Task<int> GetTotalLength()
{
    "GetTotalLength".Dump();
    string s = await GetNumericString().ConfigureAwait(false);

    return int.Parse(s);
}

async Task<string> GetNumericString()
{
    "GetNumericString".Dump();
    return await new Task<string>(() => { "inside task declaration".Dump();  return "42"; });
}
