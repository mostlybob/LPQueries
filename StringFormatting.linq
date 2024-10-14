<Query Kind="Program" />

// http://blog.stevex.net/string-formatting-in-csharp/
// http://blog.stevex.net/2007/09/string-formatting-faq/
void Main()
{
    //    var foo =String.Format("->{1,10}<-", "Hello");
    //    Index (zero based) must be greater than or equal to zero and less than the size of the argument list.
    // see below; looks like the 1 should be a zero

    var foo = string.Format("{0:000}", 25);
    $"|{foo}|".Dump();
    
    
    var intValue=1000;
    var bar=string.Format("{0:#,0}", intValue); 
    bar.Dump();

    String.Format("{0:yes;;no}", 0).Dump();
    String.Format("{0:yes;;no}", 1).Dump();
    String.Format("{0:yes;;no}", 2).Dump();

    String.Format("->{0,10}<-", "Hello").Dump();
    String.Format("->{0,-10}<-", "Hello").Dump();;

    String.Format("{0,10}", "x").Dump();
    String.Format("{0,10}", "xx").Dump();
    String.Format("{0,10}", "xxx").Dump();
    String.Format("{0,10}", "xxxx").Dump();
    String.Format("{0,10}", "xxxxx").Dump();
    String.Format("{0,10}", "xxxxxx").Dump();
    String.Format("{0,10}", "xxxxxxx").Dump();
    String.Format("{0,10}", "xxxxxxxx").Dump();
    String.Format("{0,10}", "xxxxxxxxx").Dump();
    String.Format("{0,10}", "xxxxxxxxxx").Dump();
    String.Format("{0,10}", "xxxxxxxxxxx").Dump();
    String.Format("{0,10}", "xxxxxxxxxxxxx").Dump();


    //https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-pad-a-number-with-leading-zeros
    double[] dblValues = { 9034521202.93217412, 9034521202 };
    foreach (double dblValue in dblValues)
    {
        string decSeparator = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
        string fmt, formatString;

        if (dblValue.ToString().Contains(decSeparator))
        {
            int digits = dblValue.ToString().IndexOf(decSeparator);
            fmt = new String('0', 5) + new String('#', digits) + ".##";
        }
        else
        {
            fmt = new String('0', dblValue.ToString().Length);
        }
        formatString = "{0,20:" + fmt + "}";

        Console.WriteLine(dblValue.ToString(fmt));
        Console.WriteLine(formatString, dblValue);
    }
}

// Define other methods and classes here
