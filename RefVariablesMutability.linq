<Query Kind="Program" />

void Main()
{
    int i = 1;
    int j = i;

    j = 2;

    i.Dump();
    j.Dump();

    string k = "Hi";
    string l = k;

    k = "There";

    k.Dump("string1");
    l.Dump("string2");

    Foo foo = new Foo { MyProperty = 10 };
    Foo bar = foo;

    foo.MyProperty = 20;

    foo.Dump();
    bar.Dump();
}

// Define other methods and classes here


class Foo
{
    public int MyProperty { get; set; }
}