<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
    Planet jupiter = new Planet("Jupiter", 3.65e08);
    
    var props2=GetPropertyValues2(jupiter);
    props2.Dump("GetPropertyValues2");

    var propTypes=GetPropertyTypes(jupiter);
    propTypes.Dump("propTypes");


    var dict = GetPropsVals(jupiter);

    dict.Dump("dict");
    dict.ToArray().Dump("dict.ToArray()");
    dict.ElementAt(1).Dump("dict.ElementAt(1)");

    //Things to do: 
    // - using the dictionary to create a signature for compariing instances of classes for equality
    //   - could also use type checking, whether they implement a common interface etc

    // errors out:
    GetPropsVals("hi there").Dump("GetPropsVals for 'hi there'");
    //GetPropsVals(null).Dump();
    //GetPropsVals((dynamic) 22).Dump(); // this one looks like an issue with linqpad - complains about the Dump method

    // empty dictionary:
    //GetPropsVals(10).Dump();
    //GetPropsVals(10.0).Dump();
    //GetPropsVals(10D).Dump();
    //GetPropsVals(10F).Dump();
    //GetPropsVals(10M).Dump();
    //GetPropsVals('a').Dump();

}

// another way to do it
IEnumerable<(string, Type, object)> GetPropertyValues2(Object obj)
{
    var propValues = new List<(string, Type, object)>();

    if (obj == null)
        return propValues;

    Type t = obj.GetType();

    if (t.IsPrimitive || t.FullName.Equals("System.String"))
        // good ol' .Net strings. The primitive that's not a primitive
        //https://stackoverflow.com/questions/636932/in-c-why-is-string-a-reference-type-that-behaves-like-a-value-type)
        return propValues;

    PropertyInfo[] props = t.GetProperties();

    return props.Select(prop => (name: prop.Name, type: prop.PropertyType, value: prop.GetValue(obj)));
    //return props.Select(prop=> ("hi",typeof(string),"there" as object));


}

Dictionary<string, object> GetPropsVals(Object obj)
{
    var dict = new Dictionary<string, object>();

    if (obj == null)
        return dict;

    Type t = obj.GetType();

    if (t.IsPrimitive || t.FullName.Equals("System.String"))
        // good ol' .Net strings. The primitive that's not a primitive
        //https://stackoverflow.com/questions/636932/in-c-why-is-string-a-reference-type-that-behaves-like-a-value-type)
        return dict;
    
    PropertyInfo[] props = t.GetProperties();

    return props.ToDictionary(prop => $"{prop.Name}|{prop.PropertyType.Name}", prop => prop.GetValue(obj));
}

Dictionary<string, Type> GetPropertyTypes(Object obj)
{
    var dict = new Dictionary<string, Type>();

    if (obj == null)
        return dict;

    Type t = obj.GetType();

    // I'm seeing errors, so let's treat string like how the others (appear to) behave
    if (t.FullName.Equals("System.String"))
        return dict;

    PropertyInfo[] props = t.GetProperties();

    return props.ToDictionary(prop => $"{prop.Name}", prop => prop.GetType());
}

// from https://docs.microsoft.com/en-us/dotnet/api/system.reflection.propertyinfo.getvalue?view=netframework-4.8
private static void GetPropertyValues(Object obj)
{

    Type t = obj.GetType();
    PropertyInfo[] props = t.GetProperties();

    Console.WriteLine("Type is: {0}", t.Name);
    Console.WriteLine("Properties (N = {0}):",
                      props.Length);
    foreach (var prop in props)
        if (prop.GetIndexParameters().Length == 0)
            Console.WriteLine("   {0} ({1}): {2}", prop.Name,
                              prop.PropertyType.Name,
                              prop.GetValue(obj));
        else
            Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name,
                              prop.PropertyType.Name);
}

class Planet
{
    private String planetName;
    private Double distanceFromEarth;

    public Planet(String name, Double distance)
    {
        planetName = name;
        distanceFromEarth = distance;
    }

    public String Name
    { get { return planetName; } }

    public Double Distance
    {
        get { return distanceFromEarth; }
        set { distanceFromEarth = value; }
    }
}