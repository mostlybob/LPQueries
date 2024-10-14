<Query Kind="Program" />

void Main()
{
    //    var start=DateTime.Now;
    //    
    //    Thread.Sleep(100023);
    //    
    //    var end=DateTime.Now;
    //
    //    var diff=end-start;
    //    diff.Dump();
    //    
    //    $"{FormattedTime(start)} - {FormattedTime(end)}".Dump();
    //    

    // ----------------------------------------------------------------------

    //FormattedTimeSpan(Spinner(20)).Dump();    //.Dump($"200 times");

    // ----------------------------------------------------------------------

    string.Empty.Dump("TestHappy(true) - no timer id");
    TestHappy(true);

    string.Empty.Dump("TestHappy()");
    TestHappy();

    string.Empty.Dump("TestHappy(false, \"Id from main\")");
    TestHappy(false, "Id from main");
    
    string.Empty.Dump("TestDoubleStop()");
    TestDoubleStop();
    
    string.Empty.Dump("TestDoubleStart()");
    TestDoubleStart();
    
    // ----------------------------------------------------------------------
}

void TestDoubleStop()
{
    Stop();
    Stop();
}

void TestDoubleStart(bool restart=false)
{
    var s1 = Start();
    Spinner(10);
    var s2 = Start();
    Spinner(10);
    Stop(s2, restart);
}

void TestHappy( bool noTimerId= false, string timerId=null)
{
    if (noTimerId)
    {
        Start();
        Spinner(10);
        Stop();
        
        return;
    }

    // assumes to use timer id

    if (string.IsNullOrEmpty(timerId))
    {
        var s1=Start();
        Spinner(10);
        Stop(s1);
        
        return;
    }
    
    timerId="TestHappy timer";

    var s2 = Start(timerId);
    Spinner(10);
    Stop(s2);

}

// Define other methods and classes here
string FormattedTimeSpan(TimeSpan stamp)
{
    return stamp.ToString(@"d\d\ hh\:mm\:ss\.fffffff");
}
string FormattedTime(DateTime stamp)
{
    return stamp.ToString("HH:mm:ss.fffffff");
}

bool timerIsRunning = false;
bool timerIsNotRunning => timerIsRunning == false;

DateTime startTime;


string Start(string timerId=null)
{
    if (timerId==null)
        timerId=Guid.NewGuid().ToString();
        
    if (timerIsRunning)
    {
        var runningMessage="Timer already running. Stopping it and starting a new timer. This may lose previous timer id.";
        runningMessage.Dump();
        Stop(timerId, true);
    }

    var startMessage = $"Starting timer for timer id {timerId}";
    startMessage.Dump();
    
    startTime = DateTime.Now;
    timerIsRunning=true;
    
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

TimeSpan Spinner(int spinFactor)
{
    "(starting spinner)".Dump();
    const int multiplier = 100000000;
    var start = DateTime.Now;

    for (int i = 0; i < spinFactor; i++)
    {
        for (int m = 0; m < multiplier; m++)
        {
            // sit 'n spin
        }
    }

    var end = DateTime.Now;

    "(stopping spinner)".Dump();
    
    return end - start;
}