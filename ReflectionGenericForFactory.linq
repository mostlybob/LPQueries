<Query Kind="Program" />

void Main()
{
    var foo=new CallTrackingProviderFactory();
    
 //   foo.Find<string>().Dump();
  //  foo.Find<ICallTrackingService>().Dump();
//    foo.Find<ICallTrackingProvider>().Dump();
    foo.Find<CarWars>().Dump();
}

public interface ICallTrackingService
{
    IEnumerable<ICallTrackingProvider> Providers { get; }
}

public interface ICallTrackingProvider
{
    void Register();
    string Name { get; }
}

public interface ICarWars:ICallTrackingProvider
{}

public interface IInteractiveTel:ICallTrackingProvider
{}

public class CarWars : ICarWars
{
    public string Name => "CarWars";//could probably do with with introspection

    public void Register()
    {
        Console.WriteLine($"{Name} registered");
    }
}

public class InteractiveTel : IInteractiveTel
{
    public string Name => "InteractiveTel";

    public void Register()
    {
        Console.WriteLine($"{Name} registered");
    }
}

public class CallTrackingService : ICallTrackingService
{
    public CallTrackingService()
    {
    }

    public IEnumerable<ICallTrackingProvider> Providers { get; private set; }
}

public interface ICallTrackingProviderFactory
{
    T Find<T>();
}

public class CallTrackingProviderFactory : ICallTrackingProviderFactory
{
    /*
    I don't think this will work, since getting the list of providers
    might not work just using reflection. May need to have an abstracted
    class to handle that lookup and have it injected. Either that or we'd
    need the IOC container for the application locally. I'm iffy about this
    as it is, so I might be overthinking it, at least for the messing I'm
    doing right now.
    
    And... it doesn't work (yet) anyway, since I can't get providers assignment
    broad enough to accept all the implements without casting to interface
    and losing the value.
    
    Feels close tho
    */
    
 //   private IEnumerable<ICallTrackingProvider> providers;
    private IEnumerable<object> providers;
    
    public CallTrackingProviderFactory()
    {
        FindProviders();
    }

    private void FindProviders()
    {
        providers = System.Reflection.Assembly
            .GetAssembly(typeof(ICallTrackingProvider))
            .ExportedTypes
            .Where(et => et.IsClass && typeof(ICallTrackingProvider).IsAssignableFrom(et))
//            .Select(t=>t as ICallTrackingProvider);
            //.Select(t=>(ICallTrackingProvider)t)
            ;
            
        providers.Dump("providers in constructor");
    }

    public T Find<T>()
    {
        if (typeof(T).IsClass == false || typeof(ICallTrackingProvider).IsAssignableFrom(typeof(T)) == false)
        {
            throw new InvalidOperationException($"{ nameof(CallTrackingProviderFactory) } only returns returns implentations {nameof(ICallTrackingProvider)}. Tried to find an instance of {typeof(T).Name}.");
        }
        
        typeof(T).Dump("typeof(T)");
        providers.Dump("providers");
        
        providers.Select(x=>x.GetType()).Dump("providers GetType");

var zzz=providers.FirstOrDefault(x => typeof(T) == x.GetType());
zzz.Dump("zzz");
        return (T)zzz;
    }
}