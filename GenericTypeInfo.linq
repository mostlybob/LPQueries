<Query Kind="Program" />

void Main()
{
    GetSomething<Foo>();
    GetSomething<Bar>();
    
    TestInstantiation<Foo>();
}

void TestInstantiation<T>()
{
    T zz=(T)Activator.CreateInstance(typeof(T));
    zz.Dump("creating instance");
}

void GetSomething<T>()
{
    typeof(T).Dump();
    typeof(T).Name.Dump();
}

class Foo
{ 
    public int Age { get; set; }
    public string Name { get; set; }
    
}

class Bar 
{ 
    public int Height { get; set; }
    public int Width { get; set; }
    
}