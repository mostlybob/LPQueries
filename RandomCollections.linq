<Query Kind="Program" />

void Main()
{
    // It doesn't quite do what I had in mind, so it might need more work.
    
    
    
    
    byte[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
    var subset = arr.Skip(2).Take(2);

    for (int i = 0; i < arr.Length; i++)
    {
        var li = arr.Skip(i).Take(arr.Length - i);

        for (int j = 0; j < arr.Length; j++)
        {
            var lj = arr.Skip(j).Take(arr.Length - j);
            
            for (int k = 0; k < arr.Length; k++)
            {
                var lk =arr.Skip(k).Take(arr.Length - k);

                var foo = new {li,lj,lk};
                
                foo.Dump($"{i}-{j}-{k}");
            }
        }
    }


    subset.Dump();
}

// Define other methods and classes here
