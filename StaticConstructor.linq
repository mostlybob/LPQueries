<Query Kind="Program" />

void Main()
{
    //OrderMatters();
    
    DividedScope();
}

void DividedScope()
{
    /*

it looks like scope is (sorta?) global
    
-----------------------------------------------------

    CallStaticMethod();
    string.Empty.Dump();
    CreateInstance();

CallStaticMethod()
inside the static ctor
calling static method

CreateInstance()
inside the empty ctor    

-----------------------------------------------------

    CreateInstance();
    string.Empty.Dump();
    CallStaticMethod();
    
CreateInstance()
inside the static ctor
inside the empty ctor

CallStaticMethod()
calling static method    
    */
    
    CreateInstance();
    string.Empty.Dump();
    CallStaticMethod();
}

void CallStaticMethod()
{
    "CallStaticMethod()".Dump();
    Foo.Bar();
}

void CreateInstance()
{
    "CreateInstance()".Dump();
    var foo = new Foo();
}

void OrderMatters()
{
    /*
    The static constructor gets called the first time the class is referenced, 
    whether as an instance or through a static method call.

    This is from when the static method is called before an instance of Foo is created:
    
---------------- static method call ----------------
inside the static ctor
calling static method
------------ instantiating Foo ----------------
inside the empty ctor
    
    and this is from when the class is instantiated before having its static method called:
    
------------ instantiating Foo ----------------
inside the static ctor
inside the empty ctor
---------------- static method call ----------------
calling static method
    
    
    */

    "------------ instantiating Foo ----------------".Dump();
    var foo = new Foo();

    "---------------- static method call ----------------".Dump();
    Foo.Bar();
}

// Define other methods and classes here
public class Foo
{
    static Foo()
    {
        "inside the static ctor".Dump();
    }
    
    public Foo()
    {
        "inside the empty ctor".Dump();
    }
    
    public static void Bar()
    {
        "calling static method".Dump();
    }
}