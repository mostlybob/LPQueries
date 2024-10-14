<Query Kind="Program" />

// https://stackoverflow.com/questions/105372/how-to-enumerate-an-enum

void Main()
{
    Enum.GetValues(typeof(Suit)).Dump("Enum.GetValues");
    
    ((Suit[])Enum.GetValues(typeof(Suit))).Select(x => x.ToString()).Dump("ToString()");
    ((Suit[])Enum.GetValues(typeof(Suit))).Select(x => (int)x).Dump("(int)");
    ((Suit[])Enum.GetValues(typeof(Suit))).Dump("Suit array");
    
    
    var dict=new Dictionary<string, int>();
    
    var suitArray=((Suit[])Enum.GetValues(typeof(Suit)));
    
    // I know there's a nice declarative way to build a dictionary from this array, but I'm lazy
    foreach (var element in suitArray)
    {
        dict[element.ToString()]=(int)element;
    }
    
    dict.Dump("created dictionary");
}

// You can define other methods, fields, classes and namespaces here
public enum Suit
{
    Spades,
    Hearts,
    Clubs,
    Diamonds
}