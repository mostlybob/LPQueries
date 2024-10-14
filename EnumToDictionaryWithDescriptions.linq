<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
    Suit.Spades.GetDescription().Dump();
    
    ((Suit[])Enum.GetValues(typeof(Suit))).Select(x => x.ToString()).Dump();
    
    ((Suit[])Enum.GetValues(typeof(Suit))).Select(x => x.GetDescription()).Dump();
    
    
    var suits=((Suit[])Enum.GetValues(typeof(Suit))).Select(x => x);

    var zzz = suits.Select(x => new {Key = x, Value = x.GetDescription()});
    zzz.Dump();
    
    var yyy=suits.ToDictionary(key => key, value=>value.GetDescription());
    yyy.Dump();
    
    //Dictionary<Suit,string>
}

// Define other methods and classes here


public enum Suit
{
    [Description("Spades suit")]
    Spades,
    [Description("Hearts suit")]
    Hearts,
    [Description("Clubs suit")]
    Clubs,
    [Description("Diamonds suit")]
    Diamonds
}

// compliments of Arjun Pandavathu
public static class EnumExtensions
{
    /// <summary>
    /// If available, returns the Description attribute text, otherwise returns the string value of the enum.
    /// </summary>
    public static string GetDescription(this Enum enumType)
    {
        FieldInfo fieldInfo = enumType.GetType().GetField(enumType.ToString());
        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes?.Length > 0 ? attributes[0].Description : enumType.ToString();
    }
}