<Query Kind="Program" />

//https://docs.microsoft.com/en-us/dotnet/csharp/deconstruct

void Main()
{
    Example1();
    Example2();

}

private void Example2()
{

    // ways of declaring/assigning variables
    // explicit
    (string city, int population, double area) = QueryCityData("New York City");

    // inferred
    var (city2, population2, area2) = QueryCityData("New York City");

    // using previously assigned variables (with all the baggage of string immutability)
    string city3 = "Raleigh";
    int population3 = 458880;
    double area3 = 144.8;

    (city3, population3, area3) = QueryCityData("New York City");
}

private void Example1()
{
    var result = QueryCityData("New York City");

    var city = result.Item1;
    var pop = result.Item2;
    var size = result.Item3;

    // Do something with the data.
}

private static (string, int, double) QueryCityData(string name)
{
    if (name == "New York City")
        return (name, 8175133, 468.48);

    return ("", 0, 0);
}