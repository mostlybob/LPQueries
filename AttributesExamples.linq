<Query Kind="Program" />

/*
https://www.tutorialspoint.com/csharp/csharp_attributes.htm
https://www.tutorialspoint.com/csharp/csharp_reflection.htm
*/

void Main()
{
    AttributeTest02();
}

#region https://www.tutorialspoint.com/csharp/csharp_reflection.htm

void AttributeTest02()
{
    System.Reflection.MemberInfo info = typeof(MyClass);
    object[] attributes = info.GetCustomAttributes(true);

    for (int i = 0; i < attributes.Length; i++)
    {
        System.Console.WriteLine(attributes[i]);
        System.Console.WriteLine(attributes[i] as MyClass);
    }
}

[HelpAttribute("Information on the class MyClass")]
class MyClass
{

}


[AttributeUsage(AttributeTargets.All)]
public class HelpAttribute : System.Attribute
{
    public readonly string Url;

    public string Topic 
    {   // Topic is a named parameter
      get { return topic; }
      set { topic = value;}
    }
    public HelpAttribute(string url) {   // url is a positional parameter
      this.Url = url;
    }
    private string topic;
}





#endregion


#region https://www.tutorialspoint.com/csharp/csharp_attributes.htm

void AttributeTest01()
{
    System.Reflection.MemberInfo info = typeof(MyClass);
    object[] attributes = info.GetCustomAttributes(true);

    for (int i = 0; i < attributes.Length; i++)
    {
        System.Console.WriteLine(attributes[i]);
    }
}

[DeBugInfo(45, "Zara Ali", "12/8/2012", Message = "Return type mismatch")]
[DeBugInfo(49, "Nuha Ali", "10/10/2012", Message = "Unused variable")]
class Rectangle
{
    //member variables
    protected double length;
    protected double width;
    public Rectangle(double l, double w)
    {
        length = l;
        width = w;
    }
    [DeBugInfo(55, "Zara Ali", "19/10/2012", Message = "Return type mismatch")]

    public double GetArea()
    {
        return length * width;
    }
    [DeBugInfo(56, "Zara Ali", "19/10/2012")]

    public void Display()
    {
        Console.WriteLine("Length: {0}", length);
        Console.WriteLine("Width: {0}", width);
        Console.WriteLine("Area: {0}", GetArea());
    }
}

//a custom attribute BugFix to be assigned to a class and its members
[AttributeUsage(
   AttributeTargets.Class |
   AttributeTargets.Constructor |
   AttributeTargets.Field |
   AttributeTargets.Method |
   AttributeTargets.Property,
   AllowMultiple = true)]
public class DeBugInfo : System.Attribute
{
    private int bugNo;
    private string developer;
    private string lastReview;
    public string message;

    public DeBugInfo(int bg, string dev, string d)
    {
        this.bugNo = bg;
        this.developer = dev;
        this.lastReview = d;
    }
    public int BugNo
    {
        get
        {
            return bugNo;
        }
    }
    public string Developer
    {
        get
        {
            return developer;
        }
    }
    public string LastReview
    {
        get
        {
            return lastReview;
        }
    }
    public string Message
    {
        get
        {
            return message;
        }
        set
        {
            message = value;
        }
    }
}
#endregion