<Query Kind="Program" />

int countFalse = 0;
int countTrue = 0;

void Main()
{
    //StaticRandomDealerId();
    Arjuns();
}

void Arjuns()
{
    Random r = new Random();
    List<int> numbers = new List<int>();
    int next;
    int dupeCounter = 0;
    for (int i = 0; i < 50000; i++)
    {
        next = r.Next();
        if (numbers.Contains(next))
        {
            "duplicate found".Dump();
            dupeCounter++;
        }
        numbers.Add(next);
    }

    dupeCounter.Dump();
}

void StaticRandomDealerId()
{
    for (int i = 0; i < 1000; i++)
    {
        GetRandomDealerId().Dump();
    }
}


static readonly Random _Random = new Random();

protected static int GetRandomDealerId()
{
    lock (_Random)
    {
        return _Random.Next();
    }
}

void Seeded()
{
    Random rnd;
    var list = new List<int>();

    for (int i = 0; i < 1000; i++)
    {
        rnd = BuildRandom();

        var zzz = BuildRandom().Next(0, 2);

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