<Query Kind="Program" />

void Main()
{
	var bars=new List<Bar>();
	
	for (int i=1;i<=10;i++)
	{
		bars.Add(new Bar{Id=i,BarFoo=new List<Foo>{new Foo{ Bar=i*2},new Foo{ Bar=i*3},new Foo{ Bar=i*4}}});
	}
	
//	bars.Dump();

	Func<Bar,bool> ex=x=>x.Id>6;
	ex=x=>x.Id>10;

	var baz=bars.FirstOrDefault(ex);
//	baz.Dump();

	var test=baz?.BarFoo.Select(x=>x.Bar).Any(x=>x>15);
	test.Dump();
}

// Define other methods and classes here
public class Foo
{
	public int Bar {get;set;}
}

public class Bar
{
	public int Id {get;set;}
	public IEnumerable<Foo> BarFoo {get;set;}
}

