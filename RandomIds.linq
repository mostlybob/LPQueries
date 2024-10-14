<Query Kind="Program" />

void Main()
{
    const string PREFIX="10:";
    
    var codes = BuildCodeList();

    for (int i = 0; i < 100; i++)
    {
        var foo = $"{PREFIX}{GenerateRandomString(10, codes)}";
        foo.Dump();
    }
}

int seed = -1;

Random BuildNewRandom()
{
    while (seed == DateTime.Now.Millisecond)
    { }

    seed = DateTime.Now.Millisecond;

    return new Random(seed);
}

public string GenerateRandomString(int idLength, IEnumerable<int> codeList)
{
    var rnd=BuildNewRandom();

    var foo = new StringBuilder();
    for (int i = 0; i < idLength; i++)
    {
        var code = codeList.ToList()[rnd.Next(codeList.Count())];
        var character = (char)code;
        foo.Append(character);
    }

    return foo.ToString();
}
IEnumerable<int> BuildCodeList()
{
    var asciiCodes = new List<int>();

    for (int i = 48; i < 58; i++)   //numbers
    {
        asciiCodes.Add(i);
    }

    for (int i = 65; i < 91; i++)   //upper case
    {
        asciiCodes.Add(i);
    }

    for (int i = 97; i < 123; i++)  //lower case
    {
        asciiCodes.Add(i);
    }

    return asciiCodes;
}