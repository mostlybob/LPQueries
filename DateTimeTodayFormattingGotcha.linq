<Query Kind="Program" />

void Main()
{
    // shows 00:00:00
    DateTime.Today.Dump();
    DateTime.Today.ToString().Dump();
    $"{ DateTime.Today}".Dump();
    
    // shows 12:00:00
    $"{ DateTime.Today:yyyy-MM-dd hh:mm:ss}".Dump();
    DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss").Dump();
    
    // and for grins
    var s=DateTime.Today.ToString();
    var d = DateTime.Parse(s);
    $"{d:yyyy-MM-dd hh:mm:ss}".Dump();
    d.Hour.Dump();
}

// Define other methods and classes here
