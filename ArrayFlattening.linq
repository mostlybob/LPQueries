<Query Kind="Program" />

void Main()
{
    var arrayOfArrays = new[] { new[] { 1, 2, 3, 4 }, new[] {4,5,6}};
    
    
    var array = arrayOfArrays
        .SelectMany(item => item)
        .Distinct()
        .ToArray();

    arrayOfArrays.Dump();
    array.Dump();

    var sarrayOfArrays = new[] { new[] { "ab","bc", "cd" }, new[] { "cd", "de", "ef" } };


    var sarray = sarrayOfArrays
        .SelectMany(item => item)
        .Distinct()
        .ToArray();

    sarrayOfArrays.Dump();
    sarray.Dump();

}

// Define other methods and classes here
