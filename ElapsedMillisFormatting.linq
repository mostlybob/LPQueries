<Query Kind="Program" />

//DateTime timeIndex;
long fooIndex;

void Main()
{
        var runLoop = true;
    //    var runLoop = false;

    const long OneS = 1000;
    long OneMin = 60 * OneS;
    long OneHr = 60 * OneMin;
    long OneD = 24 * OneHr;
    /*
    reference ms:
    1s = 1000
    1m = 60000
    1h = ‭3600000‬
    1d = 86400000
    */


    

    if (runLoop)
    {
        var buildForMillis = OneS * 20;
        var lower = OneHr + OneMin * 59 + OneS * 50;
        var upper = lower + buildForMillis;
        
        var rnd = BuildNewRandom();

        for (long i = lower; i < upper; i += rnd.Next(500))
        {

            RunFormatter(i);
        }
    }
    else
    {


        var d = 2;
        var h = 6;
        var m = 37;
        var s = 9;
        var ms = 8;

        $"testing {d} days, {h} hours, {m} min, {s} sec, {ms} milliseconds".Dump();

        var testval = OneD * d + OneHr * h + OneMin * m + OneS * s + ms;

        RunFormatter(testval);
    }

    "\nDone".Dump();
}

private string BuildFormattedTime(long elapsedMilliseconds)
{
    long OneSecond = 1000;
    long OneMinute = 60 * OneSecond;
    long OneHour = 60 * OneMinute;
    long OneDay = 24 * OneHour;

    var days = elapsedMilliseconds / OneDay;

    var hoursPartMilliseconds = elapsedMilliseconds % OneDay;
    var hours = hoursPartMilliseconds / OneHour;

    var minutesPartMilliseconds = hoursPartMilliseconds % OneHour;
    var minutes = minutesPartMilliseconds / OneMinute;
    var secondsPartMilliseconds = minutesPartMilliseconds % OneMinute;

    var seconds = secondsPartMilliseconds / OneSecond;
    var milliseconds = secondsPartMilliseconds % OneSecond;

    return $"{days.ToString("000")}:{hours.ToString("00")}:{minutes.ToString("00")}:{seconds.ToString("00")}.{milliseconds.ToString("000")}";
}

private string zzBuildFormattedTime(long elapsedMillis)
{
    var days = string.Empty;
    var hours = string.Empty;
    var minutes = string.Empty;
    var seconds = string.Empty;
    var millis = string.Empty;

    long OneSecond = 1000;
    long OneMinute = 60 * OneSecond;
    long OneHour = 60 * OneMinute;
    long OneDay = 24 * OneHour;

    elapsedMillis.Dump();

    var dxx = elapsedMillis / OneDay;
    
    var hModxx=elapsedMillis % OneDay;
    var hxx=hModxx / OneHour;
    
    var mModxx=hModxx % OneHour;
    var mxx=mModxx / OneMinute;
    var sModxx=mModxx % OneMinute;
    
    var sxx=sModxx/OneSecond;
    var msxx=sModxx%OneSecond;

    $"{dxx.ToString("000")}:{hxx.ToString("00")}:{mxx.ToString("00")}:{sxx.ToString("00")}.{msxx.ToString("000")}".Dump();
    dxx.Dump("dxx");
    hxx.Dump("hxx");
    mxx.Dump("mxx");
    sxx.Dump("sxx");
    msxx.Dump("msxx");
    
    hModxx.Dump("hModxx");
    mModxx.Dump("mModxx");
    sModxx.Dump("sModxx");


    var h = elapsedMillis / OneHour;
    var hMod = elapsedMillis % OneHour;
    var hMod24 = h % 24;
    var hDiv24 = h / 24;
    h.Dump("h");
    hMod.Dump("hMod");
    hMod24.Dump("hMod24");
    hDiv24.Dump("hDiv24");

    var min = elapsedMillis / OneMinute;
    var minMod = elapsedMillis % OneMinute;
    var minMod60 = min % 60;
    var minDiv60 = min / 60;
    min.Dump("min");
    minMod.Dump("minMod");
    minMod60.Dump("minMod60");
    minDiv60.Dump("minDiv60");


    var s = elapsedMillis / OneSecond;
    var sMod = elapsedMillis % OneSecond;
    var sMod60 = s % 60;
    var sDiv60 = s / 60;
    s.Dump("s");
    sMod.Dump("sMod");
    sMod60.Dump("sMod60");
    sDiv60.Dump("sDiv60");

    var dFoo = dxx.ToString("000");
    var hFoo = hMod24.ToString("00");
    var mFoo = minMod60.ToString("00");
    var sFoo = sMod60.ToString("00");
    var msFoo = sMod.ToString("000");

    $"{dFoo}:{hFoo}:{mFoo}:{sFoo}.{msFoo}".Dump();
    /*
    if (elapsedMillis < OneSecond)
    {
        hours = "00";
        minutes = "00";
        seconds = "00";
        millis = elapsedMillis.ToString("000");

        return $"{hours}:{minutes}:{seconds}.{millis}";
    }

    if (elapsedMillis < OneMinute)
    {
        hours = "00";
        minutes = "00";
        seconds = (elapsedMillis / OneSecond).ToString("00");
        millis = (elapsedMillis % OneSecond).ToString("000");

        return $"{hours}:{minutes}:{seconds}.{millis}";
    }

    if (elapsedMillis < OneHour)
    {
        

        hours = "00";
        minutes = (elapsedMillis / OneMinute).ToString("00"); ;
        seconds = (elapsedMillis / OneSecond).ToString("00");
        millis = (elapsedMillis % OneSecond).ToString("000");

        return $"{hours}:{minutes}:{seconds}.{millis}";
    }


*/

    return elapsedMillis.ToString();

}

void RunFormatter(long val)
{
    var formatted = BuildFormattedTime(val);

    $"{formatted} - {val}".Dump();
}

void FooBar3()
{
    long index = DateTime.Now.Ticks;

    var rnd = BuildNewRandom();

    for (int i = 0; i < 1000; i++)
    {
        //        var timeToSleep = rnd.Next(500);
        var timeToSleep = 500;
        Thread.Sleep(timeToSleep);

        var ticks = DateTime.Now.Ticks;
        var elapsedMillis = ((ticks - index) / 10000);  //it's not exactly milliseconds, but it will do

        var formatted = zzBuildFormattedTime(elapsedMillis);

        $"{formatted} - {i}".Dump();
    }
}

int seed = -1;

Random BuildNewRandom()
{
    while (seed == DateTime.Now.Millisecond)
    { }

    seed = DateTime.Now.Millisecond;

    return new Random(seed);
}

void FooBar2()
{
    long index = DateTime.Now.Ticks;

    var rnd = BuildNewRandom();
    var accum = 0;

    for (int i = 0; i < 100; i++)
    {
        var timeToSleep = rnd.Next(500);
        Thread.Sleep(timeToSleep);

        var ticks = DateTime.Now.Ticks;
        var elapsedRaw = ((ticks - index) / 10000);

        accum += timeToSleep;
        var elapsed = elapsedRaw % 1000 >= 500
            ? elapsedRaw + 1000 - elapsedRaw % 1000
            : elapsedRaw - elapsedRaw % 1000;

        //        $"{elapsed} - {elapsedRaw}".Dump();
        $"{timeToSleep} - {elapsedRaw} - {accum}".Dump();
    }
}

void FooBar()
{
    var foo = new List<long>();

    fooIndex = DateTime.Now.Ticks;

    for (int i = 0; i < 100; i++)
    {
        Thread.Sleep(1000);
        foo.Add(DateTime.Now.Ticks);
    }


    //    for (int i = 0; i < foo.Count(); i++)
    //    {
    //        var bar = foo.ToArray()[i] - fooIndex;
    //
    //        bar.Dump();
    //
    //        if (i > 0)
    //        {
    //            var baz = foo.ToArray()[i] - foo.ToArray()[i - 1];
    //            long baz2 = baz / 10000;
    //
    //            $"  diff: {baz} - {baz2}".Dump();
    //        }
    //    }


    var correction = -10000;

    /*
    int x = 1500;

    int result = x % 1000 >= 500 ? x + 1000 - x % 1000 : x - x % 1000;
    */

    for (int i = 0; i < foo.Count(); i++)
    {
        long boo = ((foo.ToArray()[i] - fooIndex) / 10000);

        var bb = boo % 1000 >= 500
            ? boo + 1000 - boo % 1000
            : boo - boo % 1000;

        $"{bb} - ({boo})".Dump();
    }


    // ----------------------------------------------
    //    startIndex = DateTime.Now.Ticks;
    //
    //    DateTime.Now.Ticks.Dump();
    //
    //    Thread.Sleep(1000);
    //
    //    DateTime.Now.Ticks.Dump();
    // ----------------------------------------------
    // ----------------------------------------------
    //    timeIndex=DateTime.Now;
    //    timeIndex.Millisecond.Dump();
    //    
    //    var rnd=BuildNewRandom();
    //    
    //    var ms=rnd.Next(2000);
    //    
    //    Thread.Sleep(ms);
    //    
    //    ms.Dump();
    // ----------------------------------------------    

}