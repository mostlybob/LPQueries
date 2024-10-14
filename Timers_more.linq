<Query Kind="Program" />


/*
WIP
Just messing around with Timer() and TimeSpan objects. Prolly nothing to come of it.
*/

void Main()
{
    var zzz=new RdcTimer.TimerAttributes();
    
    for (int i = 0; i < 5; i++)
    {
        //Thread.Sleep(250);
    }
}

// perhaps make the dictionary a property of the timer class?
static Dictionary<string, RdcTimer> timers = new Dictionary<string, RdcTimer>();

string TimerStart(string id = null)
{
    var timer = new RdcTimer(id);

    timers[timer.TimerId] = timer;

    return timer.TimerId;
}

void TimerStop(string timerId)
{
    if (timers.Keys.Contains(timerId))
        timers[timerId].Stop();
        
    // do I want to do anything if the timerId isn't in the collection?
}

public class RdcTimer
{
    private TimeSpan timeSpan;
    private List<object> splits;    // don't know what these will look like

    // might as well be ambitious, although to start, it will just be a stopwatch
    public enum TimerType
    {
        Stopwatch,
        Countdown,
        AlarmClock
    }

    public string TimerId { get; }

    public RdcTimer(string timerId = null, bool startTimerNow=false)
    {
        string TimerId = timerId == null
            ? Guid.NewGuid().ToString()
            : timerId;

        if (startTimerNow)
            Start();
    }

    public void Start()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

    public class TimerAttributes
    {
        //not sure what all will go here, but it's basically a POCO for displaying stuff
    }
}