<Query Kind="Program" />

//https://www.geeksforgeeks.org/pattern-matching-in-c-sharp/

void Main()
{

}

void RelationalPatternDemo()
{
    
}

// doesn't work in this version of C#

//static string GetNumberSign(int number)
//{
//    switch (number)
//    {
//        case < 0:
//            return "Negative";
//        case 0:
//            return "Zero";
//        case >= 1:
//            return "Positive";
//    }
//}

void TypePatternDemo()
{
    string str = "Geeks For Geeks";
    int number = 42;
    object o1 = str;
    object o2 = number;

    PrintUppercaseIfString(o1);
    PrintUppercaseIfString(o2);
}

void PrintUppercaseIfString(object arg)
{
    // If arg is a string:
    // convert it to a string
    // and assign it to variable message
    if (arg is string message)
    {
        Console.WriteLine($"{message.ToUpper()}");
    }
    else
    {
        Console.WriteLine($"{arg} is not a string");
    }
}