<Query Kind="Program" />

// lifted from https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params
void Main()
{
    // no parms is ok
    VariadicDemo.UseParams();
    
    // You can send a comma-separated list of arguments of the 
    // specified type.
    VariadicDemo.UseParams(1, 2, 3, 4);
    VariadicDemo.UseParams2(1, 'a', "test");

    // A params parameter accepts zero or more arguments.
    // The following calling statement displays only a blank line.
    VariadicDemo.UseParams2();

    // An array argument can be passed, as long as the array
    // type matches the parameter type of the method being called.
    int[] myIntArray = { 5, 6, 7, 8, 9 };
    VariadicDemo.UseParams(myIntArray);

    object[] myObjArray = { 2, 'b', "test", "again" };
    VariadicDemo.UseParams2(myObjArray);

    // The following call causes a compiler error because the object
    // array cannot be converted into an integer array.
    //UseParams(myObjArray);

    // The following call does not cause an error, but the entire 
    // integer array becomes the first element of the params array.
    VariadicDemo.UseParams2(myIntArray);
}

public class VariadicDemo
{
    public static void UseParams(params int[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }

    public static void UseParams2(params object[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }
}