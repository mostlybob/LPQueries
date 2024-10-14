<Query Kind="Program" />

void Main()
{
    string a = null;
    string b = null;
    var c = "hi";
    var d="there";

    (a ?? c).Dump("testing coalescing a null and a variable");
    (c ?? a).Dump("testing coalescing a null and a variable - reversed");
    (a ?? b).Dump("testing coalescing two nulls");
    (a ?? b ?? c).Dump("testing coalescing three variables");
    (a ?? c ?? b).Dump("testing three variables, switched order");
    (b ?? a ?? c).Dump("testing three variables, switched order 2");
    (a ?? b ?? c ?? d).Dump("testing coalescing four variables, with two not null");
    (d ?? b ?? c ?? a).Dump("testing coalescing four variables, with two not null, reversed");

/*  

- docs show the ??= expression, but the version of C# LP uses doesn't support it

    List<int> numbers = null;
    int? d = null;

    (numbers ??= new List<int>()).Add(5);
    Console.WriteLine(string.Join(" ", numbers));  // output: 5

    numbers.Add(d ??= 0);
    Console.WriteLine(string.Join(" ", numbers));  // output: 5 0
    Console.WriteLine(d);  // output: 0
*/
}

// Define other methods and classes here