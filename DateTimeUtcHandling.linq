<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
    //Round1();

    //UtcCasting();
    
    var date=DateTime.Parse("2022-06-01");
    var dateUtc=date.ToUniversalTime();
    
    date.IsDaylightSavingTime().Dump();
    dateUtc.IsDaylightSavingTime().Dump();

}

void UtcCasting()
{
/*
Ideally, there would be one DateTime variable which would be cast to universal & local time
*/

    var now = DateTime.Now;
    var utcNow = now.ToUniversalTime();

    now.Dump("Now");
    utcNow.Dump("Now, cast to Universal time");

}

void Round1()
{
    var now = DateTime.Now;
    var utcNow = DateTime.UtcNow;

    now.Dump("Now");
    utcNow.Dump("UtcNow");

    now.ToUniversalTime().Dump("Now - ToUniversalTime");
    utcNow.ToUniversalTime().Dump("UtcNow - ToUniversalTime");

    now.ToLocalTime().Dump("Now - ToLocalTime");
    utcNow.ToLocalTime().Dump("UtcNow - ToLocalTime");

    now.ToString("yyyy-MM-dd T HH:mm:ss K").Dump("Now - formatted with UTC offset");
    utcNow.ToString("yyyy-MM-dd T HH:mm:ss K").Dump("UtcNow - formatted with UTC offset");
}

// Define other methods and classes here