<Query Kind="Program" />

void Main()
{
    "starting Main".Dump();
    
    var test=new Test();

    var foo=test.Foo("yo!");
    
    foo.Dump("foo");
    
    "ending Main".Dump();
 
    
    
    //$"testing nameof: {nameof(ExceptionFilterForLogging)}".Dump();
}

// 2020-12-29
// - borrowed name from  AutoAlert.IntelligentMarketing.RestApi.Filters
// - wanting use constructor injection for ILogger
public class ExceptionFilterForLogging : Attribute           //ExceptionFilterAttribute
{
    
    public override bool Match(object obj)
    {
        obj.Dump("inside Match()");
        return base.Match(obj);
    }
}


// this is is just to show how to define/limit the applicable scope for the attribute
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
public class TestMultiscopeAttribute : Attribute
{}


public class MethodAttribute: Attribute
{
    
    public override bool Match(object obj)
    {
        var baseMatch = base.Match(obj);
        obj.Dump($"inside MethodAttribute.Match() = {baseMatch}");
        return baseMatch;
    }
}

public class TestInjectable
{
    public TestInjectable()
    {
        "TestInjectable ctor".Dump("TestInjectable");
    }
    
}

public class ClassxAttribute : Attribute
{
    private readonly string fooz;
    
    /*
    This is the part I want to focus on!!!
    
    If the attribute class is the one I want to inject into, it needs an empty constructor (implicit or explicit)
    or else its (empty) usage will cause a compile error.
    
    I haven't worked out the implications for applying unit tests on Attribute classes in which I want to use DI
    */
    public ClassxAttribute()
        : this (new TestInjectable())
    { }
    
    public ClassxAttribute(TestInjectable testInjectable)
    {
        fooz = this.GetType().Name;   //nameof(this.GetType);

        fooz.Dump("ClassxAttribute constructor");
    }
    
    
    public override bool IsDefaultAttribute()
    {
        var baseMatch = base.IsDefaultAttribute();
        "<empty>".Dump($"inside ClassxAttribute.IsDefaultAttribute() = {baseMatch}");
        return baseMatch;
    }

    public override bool Equals(object obj)
    {
        var baseMatch = base.Equals(obj);
        obj.Dump($"inside ClassxAttribute.Equals() = {baseMatch}");
        return baseMatch;
    }

    public override int GetHashCode()
    {
        var baseMatch = base.GetHashCode();
        "<empty>".Dump($"inside ClassxAttribute.IsDefaultAttribute() = {baseMatch}");
        return baseMatch;
    }

    public override bool Match(object obj)
    {
        var baseMatch = base.Match(obj);
        obj.Dump($"inside ClassxAttribute.Match() = {baseMatch}");
        return baseMatch;
    }
}

[Classx]
public class Test
{
    private readonly string fooz;

    public Test()
    {
        fooz = this.GetType().Name;   //nameof(this.GetType);

        fooz.Dump("Test constructor");
    }
    
    [Method]
    public string Foo(string foo)
    {
        return $"Foo: {foo}";
    }
}