<Query Kind="Program" />

void Main()
{
    var test1=new RandomTest2();
    
    test1.RunTest();
}

class RandomTest
{
    private int seed = -1;

    private Random BuildNewRandom()
    {
        while (seed == DateTime.Now.Millisecond)
        { }

        seed = DateTime.Now.Millisecond;

        return new Random(seed);
    }
    
    public void RunTest()
    {
        var rnd = BuildNewRandom();

        var ids = new List<int>();
        var id = 0;

        var retries = 0;

        const int TopValue = 10000000;

        for (int i = 0; i < 1000; i++)
        {
            id = rnd.Next(TopValue);

            while (ids.Contains(id))
            {
                retries++;
                id = rnd.Next(TopValue);
            }

            ids.Add(id);
        }

        retries.Dump("number of retries");
        ids.Count.Dump("list size");
        ids.Take(100).Dump("first 100");
    }
}

class RandomTest2
{
    /*
    This implementation is pulled from the method Arjun put in place 
    for tests getting random ints for use in tests. For test usages
    on non-ID fields it's alright, but there is a significant chance
    of collisions for automated building of collections where the 
    GetRandom() is called repeatedly in quick succession.
    */
    public void RunTest()
    {
        var ids = new List<int>();

        var id = GetRandom();
        var retries = 0;

        for (int i = 0; i < 1000; i++)
        {
            while (ids.Contains(id))
            {
                retries++;
                id = GetRandom();
            }

            ids.Add(id);
        }

        retries.Dump("number of retries");
        ids.Count.Dump("list size");
        ids.Take(100).Dump("first 100");
    }
    static readonly Random _random = new Random();

    static int GetRandom()
    {
        lock (_random)
        {
            return _random.Next();
        }
    }
}