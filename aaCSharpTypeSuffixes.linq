<Query Kind="Program" />

/*
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types

Default constructors

All value types implicitly declare a public parameterless instance 
constructor called the default constructor. The default constructor 
returns a zero-initialized instance known as the default value for 
the value type:

    For all simple_types, the default value is the value produced by a bit pattern of all zeros:
        For sbyte, byte, short, ushort, int, uint, long, and ulong, the default value is 0.
        For char, the default value is '\x0000'.
        For float, the default value is 0.0f.
        For double, the default value is 0.0d.
        For decimal, the default value is 0.0m.
        For bool, the default value is false.
    For an enum_type E, the default value is 0, converted to the type E.
    For a struct_type, the default value is the value produced by setting all value type fields to their default value and all reference type fields to null.
    For a nullable_type the default value is an instance for which the HasValue property is false and the Value property is undefined. The default value is also known as the null value of the nullable type.

Char type examples:

    '\x0058';   // Hexadecimal
    '\u0058';   // Unicode

https://www.c-sharpcorner.com/article/data-type-suffixes-in-c-sharp/

There are data type suffixes given below.

    L or l for long
        (l in small letters should be avoided as it confuses you with digit 1)
    D or d for double
    F or f for float
    M or m for decimal
        (D is already taken for double, so M is best representation for decimal)
    U or u for unsigned integer
    UL or ul for unsigned long



*/

void Main()
{
    var dictionary = new Dictionary<string, object>
    {
        {"Char", '\x0041'},
        {"Char (Unicode)", '\u0058'},
        {"Float", 0.1f},
        {"Double", 0.22d},
        {"Decimal", 0.333m},
        {"Long", 44L},
        {"Unsigned int", 42U},
        {"Unsigned Long", 55UL}
    };

    dictionary.Dump();
    
    $"{"Key".PadRight(20,' ')} {"Type".PadRight(10,' ')} Value".Dump();
    $"{"".PadRight(20,'-')} {"".PadRight(10,'-')} -----".Dump();
    // yeah, I know there's a better way, but I'm already longer into this than necessary
    
    foreach (var key in dictionary.Keys)
    {
        var type = dictionary[key].GetType().Name;

        $"{key.PadRight(20,' ')} {type.PadRight(10,' ')} {dictionary[key]}".Dump();
    }
}

// Define other methods and classes here
