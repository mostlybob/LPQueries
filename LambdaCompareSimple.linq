<Query Kind="Program">
  <NuGetReference>Neleus.LambdaCompare</NuGetReference>
  <Namespace>Neleus.LambdaCompare</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
    //var t=new Tests();
    //
    //t.BasicConst();
    //t.PropAndMethodCall();
    //t.MemberInitWithConditional();
    //t.AnonymousType();

    // and try with var and const too

    int a=10;
    long b=10;
    
    //Expression<Func<int, ClassA>> funcA1 = i => new ClassA{Id=i};
    //Expression<Func<int, ClassA>> funcA2 = i => new ClassA{Id=i};
    
//    (Lambda.Eq(funcA1, funcA2)).Dump("should be true");
//
//    var port = 443;
//    Expression<Func<Uri, UriBuilder>> f1 = x => new UriBuilder(x) { Port = port, Host = string.IsNullOrEmpty(x.Host) ? "abc" : "def" };
//
//    var isSecure = true;
//    Expression<Func<Uri, UriBuilder>> f2=u => new UriBuilder(u) { Host = string.IsNullOrEmpty(u.Host) ? "abc" : "def", Port = isSecure ? 443 : 80 };
//
//    (Lambda.Eq(f1, f2)).Dump("should be true");
//
//    Expression<Func<int, ClassA>> funcA3 = i => new ClassA { Id = i,Foo=a };
//    Expression<Func<int, ClassA>> funcA4 = i => new ClassA { Id = i, Foo=a };
//
//    (Lambda.Eq(funcA3, funcA4)).Dump("should be true");

    Expression<Func<int, ClassB>> funcB1 = i => new ClassB { Id = i, Foo = a };
    Expression<Func<int, ClassB>> funcB2 = i => new ClassB { Id = i, Foo = a };

    (Lambda.Eq(funcB1, funcB2)).Dump("should be true");

    Expression<Func<int, ClassB>> funcB3 = i => new ClassB { Id = i, Foo = (long) a };
    Expression<Func<int, ClassB>> funcB4 = i => new ClassB { Id = i, Foo = (long) b };

    (Lambda.Eq(funcB3, funcB4)).Dump("should be true");

}

class ClassA
{
    public int Id { get; set; }
    public int Foo { get; set; }
}

class ClassB
{
    public long Id { get; set; }
    public long Foo { get; set; }
}



public class Tests
{
    public void BasicConst()
    {
        var f1 = GetBasicExpr1();
        var f2 = GetBasicExpr2();
        (Lambda.Eq(f1, f2)).Dump("should be true");
    }

    public void PropAndMethodCall()
    {
        var f1 = GetPropAndMethodExpr1();
        var f2 = GetPropAndMethodExpr2();
        (Lambda.Eq(f1, f2)).Dump("should be true");
    }

    public void MemberInitWithConditional()
    {
        var f1 = GetMemberInitExpr1();
        var f2 = GetMemberInitExpr2();
        (Lambda.Eq(f1, f2)).Dump("should be true");
    }

    public void AnonymousType()
    {
        var f1 = GetAnonymousExpr1();
        var f2 = GetAnonymousExpr2();
        ("Anonymous Types are not supported").Dump("should be Inconclusive");
    }

    private static Expression<Func<int, string, string>> GetBasicExpr2()
    {
        var const2 = "some const value";
        var const3 = "{0}{1}{2}{3}";
        return (i, s) =>
            string.Format(const3, (i + 25).ToString(CultureInfo.InvariantCulture), i + s, const2.ToUpper(), 25);
    }

    private static Expression<Func<int, string, string>> GetBasicExpr1()
    {
        var const1 = 25;
        return (first, second) =>
            string.Format("{0}{1}{2}{3}", (first + const1).ToString(CultureInfo.InvariantCulture), first + second,
                "some const value".ToUpper(), const1);
    }

    private static Expression<Func<Uri, bool>> GetPropAndMethodExpr2()
    {
        return u => Uri.IsWellFormedUriString(u.ToString(), UriKind.Absolute);
    }

    private static Expression<Func<Uri, bool>> GetPropAndMethodExpr1()
    {
        return arg1 => Uri.IsWellFormedUriString(arg1.ToString(), UriKind.Absolute);
    }

    private static Expression<Func<Uri, UriBuilder>> GetMemberInitExpr2()
    {
        var isSecure = true;
        return u => new UriBuilder(u) { Host = string.IsNullOrEmpty(u.Host) ? "abc" : "def", Port = isSecure ? 443 : 80 };
    }

    private static Expression<Func<Uri, UriBuilder>> GetMemberInitExpr1()
    {
        var port = 443;
        return x => new UriBuilder(x) { Port = port, Host = string.IsNullOrEmpty(x.Host) ? "abc" : "def" };
    }

    private static Expression<Func<Uri, object>> GetAnonymousExpr2()
    {
        return u => new { u.Host, Port = 443, Addr = u.AbsolutePath };
    }

    private static Expression<Func<Uri, object>> GetAnonymousExpr1()
    {
        return x => new { Port = 443, x.Host, Addr = x.AbsolutePath };
    }
}