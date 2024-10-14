<Query Kind="Program" />

void Main()
{
 //   const string DTest = "2022-12-13";
    const string DTest = "2023-02-24";
    const int daysTo = 30;

    var targetDate2 = DateTime
        .Parse(DTest)
        .AddDays(daysTo)
        .ToShortDateString();

    var ctDays = DateTime.Parse(targetDate2) - DateTime.Today;
    var dd = $"{ctDays.ToString("dd")} days from today";

    $"{daysTo} days from {DTest}:\t\t{targetDate2}\n\n\t\t******  {dd}  ******".Dump(divider);

    // ----------------------------------------------------------------------------------------

    var targetDate = DateTime
        .Today
        .AddDays(daysTo)
        .ToShortDateString();

    $"{daysTo} days from today ({DateTime.Today.ToShortDateString()}):\t\t\t{targetDate}".Dump(divider);

    // ----------------------------------------------------------------------------------------

    var d1 = DateTime.Today;
    var d2 = DateTime.Parse("9/17/2005");

    var zz = d2 - d1;

    $"There are {zz.ToString("dd")} days between {d1.ToShortDateString()} and {d2.ToShortDateString()}".Dump(divider);


    string.Empty.Dump(divider);

    // ----------------------------------------------------------------------------------------
//
//    DateTime dt1 = DateTime.Now;
//    string toDate = "7/27/2021";
//    // override, if you want to
//    //dt1=DateTime.Parse("4/28/2020");
//    DateTime dt2 = DateTime.Parse(toDate);
//
//    var diff = (dt2 - dt1);
//
//    diff.Dump("raw format");
//
//    //diff.ToString("HH:mm:ss").Dump("HH:mm:ss");
//    diff.Days.Dump($"Days from {dt1.ToString("yyyy-MM-dd")} to {dt2.ToString("yyyy-MM-dd")}");  //.GetType().Dump(); //ToString().Dump();
//
//    var today = "2022-04-29";
//    var startDate = DateTime.Parse(today);
//    var endDate = startDate.AddDays(daysTo);
//
//    endDate.Dump($"{daysTo} days from {today}");
}

const string divider = "----------------------------------------------------------------------------------------";
// Define other methods and classes here