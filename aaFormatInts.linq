<Query Kind="Program" />

void Main()
{
    var a = 19;
    var b = 6;
    var c = ((float)a / (float)b);
    
    c.Dump();
    string.Format("Format: {0:0.00}",c).Dump();
    c.ToString("ToString: 0.0").Dump();
    $"Interpolated: {c:0.00}".Dump();
    
    
    int noOfDecimals=5;
    
    var zeroes=new String('0',noOfDecimals);

    var fmtString = $"{{0:0.{zeroes}}}";

    string.Format(fmtString,c).Dump(fmtString);

    var fmtString2 = $"0.{zeroes}";
    
    c.ToString(fmtString2).Dump(fmtString2);
    
    
}

// Define other methods and classes here
