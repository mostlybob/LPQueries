<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
    var values = new[] {5,5.0,5.01,5.2,5.25, 5.625};
    
    foreach (var value in values)
    {
        var perc=FormatPercent(value);
        var perc2=FormatPercent2(value);

        $"Value: {value}   Percent1: {perc}   Percent2: {perc2}".Dump();
        
        //double.Parse(perc).Dump();  // throws
    }
    
    
    
//    double number = 0.1234;
//    Console.WriteLine("The percent format is as : " + number.ToString("P", CultureInfo.InvariantCulture));
//    double no = 0.05;
//    Console.WriteLine("The percent format is as : " + no.ToString("P", CultureInfo.InvariantCulture));
//    double no2 = 0.052;
//    Console.WriteLine("The percent format is as : " + no2.ToString("P", CultureInfo.InvariantCulture));
//    double no3 = 0.0525;
//    Console.WriteLine("The percent format is as : " + no3.ToString("P", CultureInfo.InvariantCulture));
//
//    // Gets a NumberFormatInfo associated with the en-US culture.  
//    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
//    // Displays a value with the default number of decimal digits (2).  
////    Double myInt = 0.1234;
//    Double myInt = 0.0525;
//    Console.WriteLine("Percent Format : " + myInt.ToString("P", nfi));
//    
//    for (int i = 0; i < 10; i++)
//    {
//        nfi.PercentDecimalDigits = i;
//        Console.WriteLine($"Percent Format with {i} Decimal digits : {myInt.ToString("P", nfi)}");
//    }
    
//    // Displays the same value with four decimal digits.  
//    nfi.PercentDecimalDigits = 4;
//    Console.WriteLine("Percent Format with 4 Decimal digits : " + myInt.ToString("P", nfi));
//    // Displays the same value with eight decimal digits.  
//    nfi.PercentDecimalDigits = 8;
//    Console.WriteLine("Percent Format with 8 Decimal digits : " + myInt.ToString("P", nfi));
//    nfi.PercentDecimalDigits = 1;
//    Console.WriteLine("Percent Format with 8 Decimal digits : " + myInt.ToString("P", nfi));

}

// Define other methods and classes here

public string FormatPercent(double value)
{
    var percentValue = value / 100;
    
    return percentValue.ToString("P", CultureInfo.InvariantCulture);


}
public string FormatPercent2(double value)
{
    var percentValue = value / 100;

    return $"{value:G} %";


}

