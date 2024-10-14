<Query Kind="Program" />

void Main()
{
    var yearStart=2000;
    var yearEnd=2030;
    
    for (int i = yearStart; i <= yearEnd; i++)
    {
        ShowDSTDates(i);
        "".Dump();              
    }
    
}

// Define other methods and classes here
void ShowDSTDates(int year)
{
    var date=new DateTime(year,1,1);

    var dayNo = 0;
    var currentDate = date;
    var isDST=currentDate.IsDaylightSavingTime();

    while (currentDate.Year == year)
    {
        var currentIsDST=currentDate.IsDaylightSavingTime();
        if (currentIsDST != isDST)
        {
            var msg=currentIsDST
                ? "DST Starts"
                : "DST Ends";
                
            $"{currentDate.ToShortDateString()}  {msg}".Dump();
            isDST = currentIsDST;
        }
        

        currentDate = date.AddDays(dayNo++);
    }

//    do
//    {
//        currentDate=date.AddDays(dayNo++);
//
//        $"{currentDate}".Dump();
//    } while (currentDate.Year == year);


}