<Query Kind="Program" />

/*
using material from: 
  - https://stackoverflow.com/questions/6942477/what-does-single-pipe-equal-and-single-ampersand-equal-mean
    - OP asked about `Folder.Attributes |= FileAttributes.Directory | FileAttributes.Hidden | FileAttributes.System | FileAttributes.ReadOnly;`
      - means setting folder attribs to Directory, Hidden, Sytstem and ReadOnly
      - per comment on SO, |= (bitwise "OR") adds to a value; &= (bitwise "AND") removes from a value

  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#compound-assignment
  
*/
void Main()
{
    var x = 1;
    var y = 2;

#region bitwise "OR"
    (x |= y).Dump("x |= y");
    // although one SO comment said `x = x | (y)` would be more accurate
    
    (x | y).Dump("x | y");

    ((x |= y) == (x | y)).Dump("check equivalence");
    
    var zzz = x |= y;
    zzz.Dump("variable assignment");
    // yeah, it's redundant - humour me
    
#endregion
    
#region bitwise "AND"
    var yyy = x &= y;
    yyy.Dump("AND");

#endregion

#region MS docs example
    uint a = 0b_1111_1000;
    a &= 0b_1001_1101;
    Display(a);  // output: 10011000

    a |= 0b_0011_0001;
    Display(a);  // output: 10111001

    a ^= 0b_1000_0000;
    Display(a);  // output:   111001

    a <<= 2;
    Display(a);  // output: 11100100

    a >>= 4;
    Display(a);  // output:     1110

    void Display(uint xx) => Console.WriteLine($"{Convert.ToString(xx, toBase: 2),8}");

#endregion

}

// You can define other methods, fields, classes and namespaces here