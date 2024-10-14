<Query Kind="Program" />

void Main()
{
    //GetQrCodeUrl("http://test.com/testslug/ti").Dump();
    //GetQrCodeUrl("http://test.com/testslug/ti/foobar").Dump();

    GetPublicConstantValues<IMCategoryAbbreviation>().Dump();

    const string baseUrl = "http://test.com";
    var tests = new  []
    {
        $"{baseUrl}",
        $"{baseUrl}/",
        $"{baseUrl}/a",
        $"{baseUrl}/ab",
        $"{baseUrl}/abc",
        $"{baseUrl}/abc/ab",
        $"{baseUrl}/ab/abc",
        $"{baseUrl}/bbbb",
        $"{baseUrl}/ii/iii",
        $"{baseUrl}/ii",
        $"{baseUrl}/i/i",
        $"{baseUrl}/i",
        $"{baseUrl}/tippy",
        $"{baseUrl}/i/ti",
        $"{baseUrl}/ti/i",
        $"{baseUrl}/ti/aaa",
        $"{baseUrl}/ti/titi",
        $"{baseUrl}/ti/fbti",
        $"{baseUrl}/ti/ti",
        $"{baseUrl}/ti/",
        
        $"{baseUrl}/qr",
    };
    
    foreach (var test in tests)
    {
        var result=GetQrCodeUrl(test);

        $@"
{test} (test)
{result} (result)".Dump();
    }
    
    
    
    
}


private string GetQrCodeUrl(string fullPurl)
{
    if (string.IsNullOrEmpty(fullPurl))
    {
        return string.Empty;
    }
    
    Dictionary<string, string> categoryAbbreviations = GetPublicConstantValues<IMCategoryAbbreviation>();
    
    string qrAbbreviation=categoryAbbreviations["FromQRCode"];

    var fullPurlDoesNotContainAnyCategoryAbbreviations = 
        categoryAbbreviations
            .Values
            .Any(x => fullPurl.Contains($"/{x}")) == false;

    if (fullPurlDoesNotContainAnyCategoryAbbreviations)
    {
        return GetUrlWithTrailingAbbreviation(fullPurl, qrAbbreviation);
    }

    foreach (var abbreviation in categoryAbbreviations.Values.Where(x=>x != qrAbbreviation))
    {
        if (fullPurl.Contains($"/{abbreviation}"))
        {
            return SeachAndReplaceAbbreviation(fullPurl,abbreviation,qrAbbreviation);
        }
        
        
        
        
        
//        if (fullPurl.EndsWith($"/{abbreviation}"))
//        {
//            return SearchAndReplaceTrailingAbbreviation(fullPurl,abbreviation,qrAbbreviation);
//        }
//
//        // route on LP index is  [Route("{id?}/{s?}/{culture?}/{preferredCulture?}")]
//        // where s is the category abbreviation, so this is to handle that
//        if (fullPurl.Contains($"/{abbreviation}/"))
//        {
//            //return SearchAndReplaceCategoryAbbreviation(fullPurl,abbreviation,qrAbbreviation);
//            
//            var chunkLength=fullPurl.LastIndexOf($"/{abbreviation}/");
//            var chunk=fullPurl.Substring(0,chunkLength);
//            var chunk2=fullPurl.Substring(chunkLength + $"/{abbreviation}/".Length);
//
//            return $"{chunk}/{qrAbbreviation}/{chunk2}";
//        }
    }

    return fullPurl;







//    if (fullPurl.EndsWith("/"))
//    {
//        return $"{fullPurl}{QR}";
//    }
//
//    return $"{fullPurl}/{QR}";

    throw new NotImplementedException();
}

private string SeachAndReplaceAbbreviation(string fullPurl, string abbreviation, string qrAbbreviation)
{
    if (fullPurl.EndsWith($"/{abbreviation}"))
    {
        return fullPurl.Replace($"/{abbreviation}",$"/{qrAbbreviation}");
    }

    // route on LP index is  [Route("{id?}/{s?}/{culture?}/{preferredCulture?}")]
    // where s is the category abbreviation, so this is to handle that
    if (fullPurl.Contains($"/{abbreviation}/"))
    {
        return fullPurl.Replace($"/{abbreviation}/",$"/{qrAbbreviation}/");
    }
    
    return fullPurl;
}

private string SearchAndReplaceTrailingAbbreviation(string fullPurl, string searchAbbreviation, string replaceAbbreviation)
{
    var chunkLength = fullPurl.LastIndexOf($"/{searchAbbreviation}");
    var chunk = fullPurl.Substring(0, chunkLength);

    return $"{chunk}/{replaceAbbreviation}";
}

private string GetUrlWithTrailingAbbreviation(string fullPurl, string categoryAbbreviation)
{
    var slash = fullPurl.EndsWith("/")
        ? string.Empty
        : "/";

    return $"{fullPurl}{slash}{categoryAbbreviation}";
}

void Test1()
{
    var zz = new IMCategoryAbbreviation();
    zz.Dump();

    //GetPropsVals(zz).Dump();


    GetPublicConstantValues<IMCategoryAbbreviation>().Dump();
}

Dictionary<string, string> GetPublicConstantValues<T>()
{
    Type type= typeof(T);  
    FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static);
    
    return fieldInfos
        .Select(x => new 
        {
            Name = x.Name, 
            Value = x.GetValue(null).ToString()
        })
        .ToDictionary(x => x.Name, y => y.Value);
}



Dictionary<string, object> GetPropsVals(Object obj)
{
    var dict = new Dictionary<string, object>();

    if (obj == null)
        return dict;

    Type t = obj.GetType();

    // I'm seeing errors, so let's treat string like how the others (appear to) behave
    if (t.FullName.Equals("System.String"))
        return dict;

    PropertyInfo[] props = t.GetProperties();

    foreach (var prop in props)
    {
        var foobar = prop.DeclaringType;
        dict[$"{prop.Name}|{prop.PropertyType.Name}"] = prop.GetValue(obj);
    }

    return dict;
}


public class IMCategoryAbbreviation
{
    public const string InternalTesting = "i";

    //landing page / print offer sources
    public const string FromEmail = "e";
    public const string FromPrintOffer = "p";
    public const string FromTypeIn = "ti";
    public const string FromLandingPage = "lp";
    public const string FromFacebook = "fb";
    public const string FromDealerWebsite = "dw";
    public const string FromQRCode = "qr";
}