<Query Kind="Program" />

void Main()
{
    List<IGrouping<int, int>> groups = intArray
        .GroupBy(x => x)
        .ToList();
    
    foreach (var group in groups)
    {
        group.ToList().Dump($"List for {group.Key}");
    }
}


private static int[] intArray = new[] {1,
                                       2,2,
                                       3,
                                       4,4,4,
                                       5,
                                       6,
                                       7,7,7,7,
                                       8};


