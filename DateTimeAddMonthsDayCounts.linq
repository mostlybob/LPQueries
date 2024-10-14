<Query Kind="Program" />

void Main()
{
   const int day=4;
    
    for (int mon = 1; mon <= 12; mon++)
    {
        var year=DateTime.Today.Year;
        
        var thism=new DateTime(year,mon,day);
        var nextm=thism.AddMonths(1);
        
        (nextm-thism).TotalDays.Dump();
    }
}

// You can define other methods, fields, classes and namespaces here