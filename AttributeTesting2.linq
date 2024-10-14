<Query Kind="Program" />

void Main()
{
    //"starting".Dump();
    //
    //var test=new Test();
    //
    //"done".Dump();
    
    UseCheckStatus();
}

private void UseCheckStatus()
{
    var test=new Testing();
    test.RunTest();
}

[CheckStatus(true)]
class Testing
{
    public void RunTest()
    {
        Type type = this.GetType();
    
        CheckStatus[] attrib =
           (CheckStatus[])type.GetCustomAttributes(typeof(CheckStatus), false);
           
        attrib.Dump();
        
        
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
public class ObsoleteInIntelligentMarketing : Attribute
{
    public string Name { get; set; }

    public ObsoleteInIntelligentMarketing()
    { }

    // testing past this point

    public override bool Match(object obj)
    {
        "inside ObsoleteInIntelligentMarketing.Match".Dump();
        return base.Match(obj);
    }
}

// borrowed from https://www.c-sharpcorner.com/UploadFile/84c85b/using-attributes-with-C-Sharp-net/
public class CheckStatus : Attribute
{
    private bool val = false;
    public bool status
    {
        get { return val; }
    }
    public CheckStatus(bool val)
    {
        this.val = val;
    }
}

[ObsoleteInIntelligentMarketing(Name="Test")]
public class Test
{
    
}