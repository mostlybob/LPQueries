<Query Kind="Program" />

/*
https://www.c-sharpcorner.com/UploadFile/3d39b4/difference-between-operator-and-equals-method-in-C-Sharp/

The Equality Operator ( ==)  is the comparison operator and the 
Equals() method compares the contents of a string. The == Operator 
compares the reference identity while the Equals() method compares 
only contents.
*/
void Main()
{
    object name = "sandeep";  
    char[] values = {'s','a','n','d','e','e','p'};  
    object myName = new string(values);
    
    name.Dump("string object");
    myName.Dump("string constructed from character array");
    (name == myName).Dump("==");
    name.Equals(myName).Dump(".Equals()");
}