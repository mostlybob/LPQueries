<Query Kind="Program" />

void Main()
{
    foreach (TestEnum segment in Enum.GetValues(typeof(TestEnum)))
    {
        var segmentInt = (int)segment;

        $"{segment} - {segmentInt}".Dump();
    }

    "---------------------------------------------------".Dump();
    TestEnum.Ghi.Dump("Ghi");
    ((int)TestEnum.q).Dump("Ghi cast to int");

    "---------------------------------------------------".Dump();
    TestEnum.q.Dump("q");
    ((int)TestEnum.q).Dump("q cast to int");

    "---------------------------------------------------".Dump();
    TestEnum.q.ToString().Dump("q to string, but it shows Ghi");

    "---------------------------------------------------".Dump();
    // bit of a gotcha to watch for with assigned enum values
    (TestEnum.q == TestEnum.Ghi).Dump("Should this be true? Seems to me like it shouldn't.");
}

enum TestEnum
{
    Abc,
    Def,
    Ghi = 10,
    Jkl = 5,
    m,
    n,
    o,
    p,
    q,
    r,
    s
}
