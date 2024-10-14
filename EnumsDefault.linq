<Query Kind="Program" />

void Main()
{
    default(FooBar).Dump("FooBar");
    default(NoZeroes).Dump("NoZeroes");
    default(OneZero).Dump("OneZero");
    default(OneLiteral).Dump("OneLiteral");

    var existingNoZero=(NoZeroes)20;
    existingNoZero.Dump("Casting value existing in NoZeroes");
    
    var defaultNoZero = (NoZeroes)0;
    defaultNoZero.Dump("Casting 0 to NoZeros");
    defaultNoZero.GetType().FullName.Dump("Default when Enum has no zeroes");
    
    
}

// Define other methods and classes here

public enum FooBar
{
    Foo,
    Bar,
    Baz
}

public enum NoZeroes
{
    Fizz=10,
    Buzz=20
}

public enum OneZero
{
    Here,
    There=0
}

public enum OneLiteral
{
    Up=20,
    Down
}