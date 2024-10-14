<Query Kind="Program" />

/*

true
494 
false
506 

true
482 
false
518 

true
505 
false
495 







*/

int countFalse = 0;
int countTrue = 0;

void Main()
{
    Random rnd;
    var list = new List<int>();
    
    for (int i = 0; i < 1000; i++)
    {
        rnd = BuildRandom();
        
        var zzz=BuildRandom().Next(0,2);
        
        list.Add(zzz);
        
        if (zzz == 0)
            countTrue++;
        else
            countFalse++;    
    }

    countTrue.Dump("true");
    countFalse.Dump("false");
    list.Dump("audit");
}

int seed = -1;
static object locker = new Object();

Random BuildRandom()
{
    lock (locker)
    {
        while (seed == DateTime.Now.Millisecond)
        { }

        seed = DateTime.Now.Millisecond;
    }
    
    return new Random(seed);
}