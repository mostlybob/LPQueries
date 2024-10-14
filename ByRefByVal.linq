<Query Kind="Program" />

void Main()
{
    /*
    One of the other LP queries (RefVariablesMutability) touches on this
    having to do with instances a class 
    */

    int a = 10;
    int b = a;

    new { a, b}.Dump("int init");

    b=20;

    new { a, b}.Dump("int after update");
    
    string c="abc";
    string d=c;
    
    new { c, d}.Dump("string init");
    
    d="hello";
    
    new { c, d}.Dump("string after update");
}

void PlayingWithRefParms()
{
    string test = "abc";
    test.Dump("string init");

    StrByVal(test);
    test.Dump("string default");

    StrByRef(ref test);
    test.Dump("string explicit ref");

    int test2 = 5;
    test2.Dump("int init");
    Int(test2);
    test2.Dump("int default");
    IntByRef(ref test2);
    test2.Dump("int explicit ref");
}

void IntByRef(ref int test)
{
    test=10;
}

void Int(int test)
{
    test=10;
}

void StrByVal(string test)
{
    test="def";
}

void StrByRef(ref string test)
{
    test="def";
}

void FirstChunk()
{
    var c1 = new Consumer();
    var c2 = new Consumer();
    var c3 = c2;

    (c1 == c2).Dump();
    c1.Equals(c2).Dump();

    (c3 == c2).Dump();
    c3.Equals(c2).Dump();

    (new { Consumer = c3, HashCode = c3.GetHashCode() }).Dump();
    c3.FirstName = "abc";
    c3.Equals(c2).Dump();

    (new { Consumer = c2, HashCode = c2.GetHashCode() }).Dump();
    (new { Consumer = c3, HashCode = c3.GetHashCode() }).Dump();
}



// Define other methods and classes here
class Consumer
{
    public string FirstName { get; set; }
}