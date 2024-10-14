<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var start=DateTime.Now.TimeOfDay;
    $"{start}".Dump("Start");

    const double multplier=0.010;
    const int callerCount=100;
    
    var paraCount = (int)Math.Round(callerCount*multplier); // default Math.Round appears to round .5 down
                                                            // don't particularly care in this case, but remember it
    var callers = new List<int>();
    
    for (int i = 0; i < callerCount; i++)
    {
        callers.Add(i);
    }

    Parallel.ForEach(callers, new ParallelOptions() { MaxDegreeOfParallelism = paraCount }, x => DumpThreadId(x));

    var end=DateTime.Now.TimeOfDay;
    $"{start}".Dump("End");

    var diff = end - start;
    diff.Dump($"Elapsed - caller count: {callerCount}; parallelism: {paraCount}");
}


void DumpThreadId(int callerId)
{
    //$"          {callerId} starting".Dump();
    var time = DateTime.Now.TimeOfDay;
    var id = System.Threading.Thread.CurrentThread.ManagedThreadId;
    $"{time} - caller: {callerId} | ThreadId: {id}".Dump();
    Thread.Sleep(500);
    //$"                {callerId} ending".Dump();
}