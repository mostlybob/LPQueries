<Query Kind="Program" />

void Main()
{
    UsingTimer();


    // this seems laggy
    //MSDocsExample();
}

private static void UsingTimer()
{

    /********************************************************
    TO CANCEL IN LINQPAD, USE Shift-Ctrl-F5 TO UNLOAD PROCESS
    ********************************************************/


    aTimer = new System.Timers.Timer();
    aTimer.Interval = 1000;

    aTimer.Elapsed += CountDown;
    aTimer.Enabled = true;
}

//static DateTime target = DateTime.Parse("2030-1-1");
static DateTime target = DateTime.Parse("2022-6-15");
static int currentPeriod = 0;

const int updatePeriod = 20;

private static void CountDown(Object source, System.Timers.ElapsedEventArgs e)
{
    var msg = string.Empty;
    var resetCondition = currentPeriod == 0 || currentPeriod == updatePeriod;
    var now = DateTime.Now;

    if (resetCondition)
    {
        var nowMsg = now.ToString("dddd, dd MMMM yyyy, HH:mm:ss");
        currentPeriod = 0;
        msg = $"until {target.ToShortDateString()} (current date/time is {nowMsg})";
    }

    currentPeriod++;

    var diff = target - now;

    var d = diff.Days;
    var h = diff.Hours;
    var m = diff.Minutes;
    var s = diff.Seconds;

    $"{d.ToString("00")} days and {h.ToString("00")}:{m.ToString("00")}:{s.ToString("00")} {msg}".Dump();

}


private static void MSDocsExample()
{
    // Create a timer and set a two second interval.
    aTimer = new System.Timers.Timer();
    aTimer.Interval = 2000;

    // Hook up the Elapsed event for the timer. 
    aTimer.Elapsed += OnTimedEvent;

    // Have the timer fire repeated events (true is the default)
    aTimer.AutoReset = true;

    // Start the timer
    aTimer.Enabled = true;

    Console.WriteLine("Press the Enter key to exit the program at any time... ");
    Console.ReadLine();


    // - tutorial didn't actually get rid of the timer, though.
    // - appears to leave the timer thread running, at least in Linqpad
    //   prolly cause aTimer is static and LP (maybe?) holds the shell open
    Console.WriteLine("Disposing of timer.");
    //    aTimer.Enabled=false;
    aTimer.Dispose();
    aTimer = null;

    Console.WriteLine("Quitting.");

}

private static System.Timers.Timer aTimer;

private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
{
    Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
}