<Query Kind="Program" />

void Main()
{
    
    
//    double foo=8;
//    for (int i = 0; i < 100; i++)
//    {
//        foo = foo / 2;
//        var result = $"5 ^ {foo} = {Math.Pow(5,foo)}";
//        result.Dump();
//    }
//    
//    "zzzzzzzzzzz".Dump();
    
    // sort of a differential-y way of showing 0 ^ 0 == 1
    // got the idea from a youtube video about the subject (mathies and their riddles :P)
    
    double foo=32;
    for (int i = 0; i < 65; i++)
    {
        foo = foo / 2;
        var result = $"{foo} ^ {foo} = {Math.Pow(foo,foo)}";
        result.Dump();
    }
    
    
}

// Define other methods and classes here
