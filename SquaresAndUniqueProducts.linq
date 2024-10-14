<Query Kind="Program" />

void Main()
{
    /*
    - just a curiosity
    - noticing what looks like a pattern:
      - foo gets the product of each combination 
        i.e. multiple occurrences of the product value
      - bar holds the last i * j combination for each product i.e.
        i.e. unique instances of the product value

      - elements in ii are progress regularly
        i.e. {1,2,3 ... n} and n equals the array size

      - counts of foo follow predictable squaring pattern

      - what about bar?

      ii (n)    foo (n) bar (n)
      ------    ------- --------
      2         4       3
      3         9       6
      4         16      9
      5         25      14
      6         36      18
      7         49      25

      I suspect primes, because it's always about primes.
      Either that or an aspect of the matrix
    */

    var ii = new[] { 1, 2, 3, 4, 5, 6, 7 };
    var jj = ii;


    var foo = new Dictionary<string, int>();
    var bar = new Dictionary<int, string>();


    foreach (var i in ii)
    {
        foreach (var j in jj)
        {
            foo[$"{i}-{j}"] = i * j;
            bar[i * j] = $"{i}-{j}";
        }
    }

    $"ii: {ii.Length}\nfoo: {foo.Count()}\nbar: {bar.Count()}".Dump("counts of the result");

    bar.Dump();
    foo.Dump();
}

// Define other methods and classes here
