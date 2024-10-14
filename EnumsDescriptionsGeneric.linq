<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{

    foreach (Enum item in Enum.GetValues(typeof(  ServiceMarketingCustomerSegment)))
    {
        //new { item, item.GetType().Name}.Dump();
        new {d= item.GetDescription(),dx=item.GetDescriptionx()}.Dump();
    }

    foreach (Enum item in Enum.GetValues(typeof(JustAPlainEum)))
    {
        //new { item, item.GetType().Name}.Dump();
        new { d = item.GetDescription(), dx = item.GetDescriptionx() }.Dump();
    }


}

void Test04()
{

    Enum.Parse(typeof(ServiceMarketingCustomerSegment), "SoldNeverServiced").Dump();

    ServiceMarketingCustomerSegment zz;
    Enum.TryParse("SoldNeverServiced", out zz).Dump();
    zz.Dump();

}


void Test02()
{
    var stringBuilder = new StringBuilder();
    foreach (string colorEnum in Enum.GetNames(typeof(ServiceMarketingCustomerSegment)))
    {
        stringBuilder.Append(colorEnum + "|");
    }
    stringBuilder.ToString().Dump();
}

void Test03()
{
    var a = ServiceMarketingCustomerSegment.SoldNeverServiced;
    var b = ServiceMarketingCustomerSegment.SoldAndServiced;
    var c = ServiceMarketingCustomerSegment.ServicedNeverSold;

    new { a, zz = GetSegmentDescription(a) }.Dump();
    new { b, zz = GetDescription(b) }.Dump();
    b.Dump();
    c.Dump();
}

private static string GetDescription<T>(T enumName) where T: Enum
{
    var descriptionAttribute = enumName
    .GetType()
    .GetMember(enumName.ToString())
    .First()
    .GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)
    .OfType<DescriptionAttribute>()
    .FirstOrDefault(x => x != null);

    return descriptionAttribute?.Description ?? "NO SEGMENT DESCRIPTION";
}

private static string GetSegmentDescription(ServiceMarketingCustomerSegment segment)
{
    var descriptionAttribute = segment
        .GetType()
        .GetMember(segment.ToString())
        .First()
        .GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)
        .OfType<DescriptionAttribute>()
        .FirstOrDefault(x => x != null);

    return descriptionAttribute?.Description ?? "NO SEGMENT DESCRIPTION";
}


// and a nice extension method, just 'cause
public static class EnumExtensions
{
    /// <summary>
    /// If available, returns the Description attribute text, otherwise returns the string value of the enum.
    /// </summary>
    public static string GetDescription(this Enum enumType)
    {
        FieldInfo fieldInfo = enumType
            .GetType()
            .GetField(enumType.ToString());

        DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo
            .GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes?.Length > 0 ? attributes[0].Description : enumType.ToString();
    }
    public static string GetDescriptionx(this Enum enumType)
    {
        var descriptionAttribute = enumType
            .GetType()
            .GetMember(enumType.ToString())
            .First()
            .GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)
            .OfType<DescriptionAttribute>()
            .FirstOrDefault(x => x != null);

        return descriptionAttribute?.Description?? enumType.ToString();


//        FieldInfo fieldInfo = enumType
//            .GetType()
//            .GetField(enumType.ToString());
//
//        DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo
//            .GetCustomAttributes(typeof(DescriptionAttribute), false);
//
//        return attributes?.Length > 0 ? attributes[0].Description : enumType.ToString();
    }
}


void Test01()
{
    var test = new[] { new Foo(), new Foo { MyProperty = 110 } };

    test.Dump();
}

class Foo
{
    public string Name { get; set; }
    public int? MyProperty
    {
        get
        { //this.Dump();
            return 777;
        }
        set { value.Dump(); }
    }
}

enum JustAPlainEum
{
    Foo,
    Bar
}

public enum ServiceMarketingCustomerSegment
{
    //Native
    [Description("Sold Never Serviced")]
    SoldNeverServiced = 1,

    //Native Conquest
    [Description("Sold and Serviced")]
    SoldAndServiced = 2,

    //Conquest
    [Description("Serviced Never Sold")]
    ServicedNeverSold = 3,
}