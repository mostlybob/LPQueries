<Query Kind="Program" />

void Main()
{
	var foo = new Foo{Bar=1,Baz="Hi there", Fooie=11};
	
	foo.Dump();
	
	Func<IFoo> baz= () => new Foo();
	
	var bar=new Bar(baz);
	
	bar.FooBar();
	
}

public class Bar
{
	private Func<IFoo> foo;
	public Bar (Func<IFoo> foo)
	{
		this.foo=foo;
	}
	
	public void FooBar()
	{
		foo().Dump();
	}
}

public class Foo : IFoo
{
	public int Fooie{get;set;}
	public int? Bar{get;set;}
	public string Baz{get;set;}
}

public interface IFoo
{
	int Fooie{get;set;}
	int? Bar {get;set;}
	string Baz{get;set;}
}