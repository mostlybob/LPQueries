<Query Kind="Program">
  <NuGetReference>Neleus.LambdaCompare</NuGetReference>
  <NuGetReference>NSubstitute</NuGetReference>
  <Namespace>NSubstitute</Namespace>
  <Namespace>Neleus.LambdaCompare</Namespace>
</Query>

void Main()
{
    var imdb=Substitute.For<IDbFactoryBase>();
    
    imdb
        .FetchSingle(Arg.Is<Expression<Func<string, bool>>>(x => 
            Neleus.LambdaCompare.Lambda.Eq(x, y=>   y.Length>5)))
        .Returns("hi");
    
    var zzz=imdb.FetchSingle<string>(f => f.Length==2);
    
    zzz.Dump("zzzz");
    
    
    var yyy=imdb.FetchSingle<string>(f=>f.Length>5);
    
    yyy.Dump("yyy");


    imdb.FetchSingle(Arg.Any<Expression<Func<DealerVanityDatum, bool>>>())
                   .Returns(new DealerVanityDatum { DealerAddress = "zzzzzzzzzzzzzz" });

    imdb.FetchSingle(Arg.Is<Expression<Func<DealerVanityDatum, bool>>>(i=>i.))

    //var nel=Lambda.Eq(

    imdb
        .ReceivedCalls()
        .Select(i => i.GetParameterInfos())
        .Dump("GetParameterInfos");

    imdb
        .ReceivedCalls()
        .Select(i => i.GetArguments())
        .Dump("GetArguments");
    
    

}

// You can define other methods, fields, classes and namespaces here


/*
var mockRepository = Substitute.For<IRepository>();
mockRepository.Find(Arg.Is<Expression<Func<Invoice, bool>>>(expr =>
                    LambdaCompare.Eq(expr, i => !i.IsProcessed && i.IsConfirmed))
              .Returns(..etc..)
              */





public interface IDbFactoryBase
{
    List<T> Query<T>(Expression<Func<T, bool>> predicate);
     T FetchSingle<T>(Expression<Func<T, bool>> predicate);
}

public class DealerVanityDatum
{
    public string DealerAddress { get; set; }
    public string DealerCode { get; set; }
}