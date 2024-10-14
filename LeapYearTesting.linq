<Query Kind="Program" />

void Main()
{
    /*
    - from the wikipedia page
        if (year is not divisible by 4) then (it is a common year)
        else if (year is not divisible by 100) then (it is a leap year)
        else if (year is not divisible by 400) then (it is a common year)
        else (it is a leap year) 
    
        The years 1600, 2000 and 2400 are leap years, 
        while 1700, 1800, 1900, 2100, 2200 and 2300 are not leap years    
    */

    var testYears = new int[] { 1970, 1972, 1975, 1980, 1983, 1988, 2000, 2002, 2004, 2010, 2100, 2200 };
    //    var testYears = new int[] { 1600, 2000, 2400, 1700, 1800, 1900, 2100, 2200  };


    foreach (var year in testYears)
    {

        var rule1 = year % 4 == 0;
        var rule2 = year % 100 == 0;
        var rule3 = year % 400 == 0;

        var isLeapYear = rule1
            ? (rule2 && rule3) || (rule2 == false && rule3 == false)
            : false;

        $"Calculated: {isLeapYear}\n  mod 4 == 0 - {rule1}\n  mod 100 == 0 - {rule2}\n  mod 400 == 0 - {rule3}\n".Dump(year.ToString());
        

    }


}

// Define other methods and classes here