<Query Kind="Program">
  <NuGetReference>NuGet.Core</NuGetReference>
  <Namespace>System.Runtime.Versioning</Namespace>
  <Namespace>NuGet</Namespace>
</Query>

/*
borrowed & modified from:
    https://stackoverflow.com/questions/6653715/view-nuget-package-dependency-hierarchy
*/
static void Main(string[] args)
{
    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    StringBuilder messages = new StringBuilder();

    var frameworkName = new FrameworkName(".NETFramework, Version=4.0");

    // var packageSource = "https://www.nuget.org/api/v2/";
    //var packageSource = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), "NuGet", "Cache");
    var packageSource = @"C:\autoalert\work\motofuze\branches\ft-im\packages";

    var repository = PackageRepositoryFactory.Default.CreateRepository(packageSource);
    const bool prerelease = false;

    var packages = repository.GetPackages()
        .Where(p => prerelease ? p.IsAbsoluteLatestVersion : p.IsLatestVersion)
        .Where(p => VersionUtility.IsCompatible(frameworkName, p.GetSupportedFrameworks()));

    "getting package count...".Dump();

    var packageTotal = packages.Count();
    var currentPackage = 0;

    Util.ClearResults();

    string buildMessage = "Building package parentage dictionary..." + Environment.NewLine;

    foreach (IPackage package in packages)
    {
        $"{buildMessage}package ({++currentPackage} / {packageTotal}): {package.ToString()}".Dump();

        if (currentPackage == packageTotal)
        {
            var foobar="testing";
        }
        
        GetValue(repository, frameworkName, package, null, prerelease, 0, dict, messages);
        Util.ClearResults();
    }

    Util.ClearResults();

    var dependencyDictionary = new Dictionary<string, List<string>>();
    foreach (var key in dict.Keys.OrderBy(x => x))
    {
        List<string> collection = dict[key];

        dependencyDictionary[key] = dict[key]
                                .Distinct()
                                .OrderBy(x => x)
                                .ToList();
    }

    var formattedDictionary = GetFormattedDictionary(dependencyDictionary);

    formattedDictionary.Dump();
    messages.ToString().Dump();
}

const string TopLevel = "<root>";

static Dictionary<string, object> GetFormattedDictionary(Dictionary<string, List<string>> dict)
{
    var dependencyDictionary = new Dictionary<string, object>();
    foreach (var key in dict.Keys.OrderBy(x => x))
    {
        object value = dict[key].Count() == 1
            ? (object)"This is top-level dependency"
            : dict[key]
                .Where(x => x != TopLevel)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

        dependencyDictionary[key] = value;
    }


    return dependencyDictionary;
}

private static void GetValue(IPackageRepository repository, FrameworkName frameworkName, IPackage package, IPackage packageParent, bool prerelease, int level, Dictionary<string, List<string>> dict, StringBuilder messages)
{
    if (package == null)
    {
        //        Console.WriteLine($"***** Null package called with {frameworkName.FullName} *****");
        messages.Append($"***** Null package called with {frameworkName.FullName} *****");
        return;
    }

    var key = package.ToString();

    if (dict.Keys.Contains(key) == false)
        dict[key] = new List<string>();

    var parentName = packageParent == null
        ? TopLevel
        : packageParent.ToString();

    dict[key].Add(parentName);

    //    Console.WriteLine("{0}{1}", new string(' ', level * 3), package);
    messages.Append($"{new string(' ', level * 3)}{package}{System.Environment.NewLine}");
    foreach (PackageDependency dependency in package.GetCompatiblePackageDependencies(frameworkName))
    {
        IPackage subPackage = repository.ResolveDependency(dependency, prerelease, true);
        GetValue(repository, frameworkName, subPackage, package, prerelease, level + 1, dict, messages);
    }
}