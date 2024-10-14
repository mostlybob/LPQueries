<Query Kind="Program" />

void Main()
{
    //1.GetHashCode().Dump();
    //1.GetHashCode().Dump();
    //2.GetHashCode().Dump();
    //1.GetType().IsPrimitive.Dump();

    (new {HashCode=1.GetHashCode(),1.GetType().IsPrimitive,1.GetType().Name}).Dump("1");
    (new {HashCode=2.GetHashCode(),2.GetType().IsPrimitive,2.GetType().Name}).Dump("2");
    
    var a=1;
    (new {HashCode=a.GetHashCode(),a.GetType().IsPrimitive,a.GetType().Name}).Dump("a=1");
    //a.GetHashCode().Dump();
    //a.GetType().IsPrimitive.Dump();


    long dealerId = 10000;
    dealerId.GetHashCode().Dump("dealerId");
    int convertedDealerId = (int)dealerId;
    convertedDealerId.GetHashCode().Dump("convertedDealerId");
    (dealerId == convertedDealerId).Dump("dealerId == convertedDealerId");
    dealerId.Equals(convertedDealerId).Dump("dealerId.Equals(convertedDealerId)");
    convertedDealerId.Equals(dealerId).Dump("convertedDealerId.Equals(dealerId)");


        //"Hi".GetHashCode().Dump();
    //"Hi".GetHashCode().Dump();
    //"Hi".GetType().IsPrimitive.Dump();
    
    var b="Hi";
    //b.GetHashCode().Dump();
    (new {HashCode=b.GetHashCode(),b.GetType().IsPrimitive,b.GetType().Name}).Dump("b=\"Hi\"");
    var c=b;
    (new {HashCode=c.GetHashCode(),c.GetType().IsPrimitive,c.GetType().Name}).Dump("c=b");
    //c.GetHashCode().Dump();
    //c.GetType().IsPrimitive.Dump();

    var f=new Foo();
    //f.GetHashCode().Dump();
    (new { HashCode = f.GetHashCode(), f.GetType().IsPrimitive, f.GetType().Name }).Dump("f=new Foo()");

    var g=new Foo();
    //g.GetHashCode().Dump();
    (new { HashCode = g.GetHashCode(), g.GetType().IsPrimitive, g.GetType().Name }).Dump("g=new Foo()");
    
    var h=g;
    (new { HashCode = h.GetHashCode(), h.GetType().IsPrimitive, h.GetType().Name }).Dump("h=g");
    
    h=f;
    (new { HashCode = h.GetHashCode(), h.GetType().IsPrimitive, h.GetType().Name }).Dump("h=f (reassigned value)");
    
    f.MyProperty=20;
    (new { HashCode = f.GetHashCode(), f.GetType().IsPrimitive, f.GetType().Name }).Dump("f after property change");
    (new { HashCode = h.GetHashCode(), h.GetType().IsPrimitive, h.GetType().Name }).Dump("h after property change in f");
    
    f.Dump("f");
    h.Dump("h");
    
}

// Define other methods and classes here

class Foo
{
    public int MyProperty { get; set; }
}


