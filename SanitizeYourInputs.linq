<Query Kind="Program" />

// but maybe look at this too: https://kevinsmith.io/sanitize-your-inputs

void Main()
{
    var dict = new Dictionary<int, string>
    {
        {1, null},
        {2, ""},
        {3, " "},
        {4, "\t"},
        {5, $"{Environment.NewLine}"},
        {6, "abc"},
        {7, "123"},
        {8, "abc123"},
        {9, "\tabc\n123"},
        {10, "();"},
        {11, ";;;"},
        {12, "('hi'"},
        {13, '\u0001'.ToString()},
        {14, '\u0002'.ToString()},
        {15, '\u0003'.ToString()},
        {16, '\u0004'.ToString()},
        {17, '\u0005'.ToString()},
        {18, "Robert'); DROP TABLE Students;--"}, // the classic
        {19, '\u0006'.ToString()},
        {20, '\u0007'.ToString()},
        {21, '\u0008'.ToString()},
        {22, '\u0009'.ToString()},
    };


    "values".Dump();
    foreach (var key in dict.Keys)
    {
        $"|{key}|{dict[key]}|".Dump();
    }


    "\nRunning comparison".Dump();
    foreach (var key in dict.Keys)
    {
        if(RemoveNonAlphaNumeric(dict[key]) != RemoveNonAlphaNumeric2(dict[key]))
            key.Dump();
    }
    "Done comparison".Dump();
    
    "\nDumped values, using regex".Dump();
    foreach (var key in dict.Keys)
    {
        $"|{key}|{dict[key]}|{RemoveNonAlphaNumeric(dict[key])}|".Dump();
    }
    
    "\nDone".Dump();
}

// Define other methods and classes here
Regex rgx = new Regex("[^a-zA-Z0-9]", RegexOptions.Compiled);

public string RemoveNonAlphaNumeric(string arg) => arg is null
    ? null
    : rgx.Replace(arg, string.Empty);


private static string RemoveNonAlphaNumeric2(string arg)
{
    // pretty basic, but fills the immediate need
    // eventually maybe replace with regex

    if (arg==null)
        return null;

    char[] characters = arg.ToArray();

    int[] numerics = Enumerable.Range('0', 10).ToArray();
    int[] alphasUpper = Enumerable.Range('A', 26).ToArray();
    int[] alphasLower = Enumerable.Range('a', 26).ToArray();

    int[] alphanumerics = numerics.Concat(alphasUpper.Concat(alphasLower)).ToArray();

    bool codeIsAlphanumeric(char code) => alphanumerics.Contains(code);

    return new string(characters
        .Where(codeIsAlphanumeric)
        .ToArray());
}