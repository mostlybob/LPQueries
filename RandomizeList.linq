<Query Kind="Program" />

void Main()
{
    Method1();
    Method2();
}

void Method2()
{
// a bit more efficient i.e. takes an order of magnitude fewer iterations to get all the hits
    var ints = new List<int>();
    for (int i = 0; i < 25; i++)
    {
        ints.Add(i + 1);
    }

    //ints.ToArray().Dump();

    int size = ints.Count();

    object[] randomized = new object[size];

    //randomized.Dump();

    var rnd = new Random();

    var iteration = 0;
    var hit = 0;

    while (randomized.Contains(null))
    {
        if (iteration > 100000)
        {
            // just a precaution
            "exceeded safety limit".Dump();
            break;
        }

        iteration++;
        int index = rnd.Next(size);

        if (randomized[index] == null)
        {
            hit++;
            var unassigned = ints.First(x => randomized.Contains(x) == false);

            randomized[index] = unassigned;
        }
    }

    $"iterations: {iteration}".Dump();
    $"hits: {hit}".Dump();
    randomized.Dump();
    randomized.OrderBy(r => r).Dump();
}

void BadMethod()
{
    // just produces a dictionary of the values in random order, which is ok, but overkill for what I want
    var ints = new List<int>();
    for (int i = 0; i < 25; i++)
    {
        ints.Add(i + 1);
    }

    int size = ints.Count();
    var rnd = new Random();
    var dict = new Dictionary<int, object>();

    //for (int i = 0; i < 25; i++)
    //{
    //    dict.Add(i + 1, i);
    //}

    var iterations = 0;
    while (dict.Keys.Count() < ints.Count())
    {
        iterations++;

        if (iterations > 100000)
        {
            "exceeded safety limit".Dump();
            break;
        }

        int index = rnd.Next(size);

        dict[index + 1] = ints[index];
    }
    iterations.Dump();
    dict.Dump();
}

void Method1()
{
    // this works, but Method2 does it with fewer iterations
    
    var ints = new List<int>();
    for (int i = 0; i < 25; i++)
    {
        ints.Add(i + 1);
    }

    //ints.ToArray().Dump();

    int size = ints.Count();

    object[] randomized = new object[size];

    //randomized.Dump();

    var rnd = new Random();

    var iterations = 0;
    var hit = 0;

    while (randomized.Contains(null))
    {
        iterations++;
        int index = rnd.Next(size);

        if (randomized[index] == null)
        {
            int i2 = rnd.Next(size);

            if (randomized.Contains(ints[i2]))
                continue;

            hit++;
            randomized[index] = ints[i2];
        }
    }

    $"iterations: {iterations}".Dump();
    $"hits: {hit}".Dump();
    randomized.Dump();
}