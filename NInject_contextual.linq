<Query Kind="Program">
  <NuGetReference>Ninject</NuGetReference>
  <NuGetReference>Ninject.Extensions.Factory</NuGetReference>
  <NuGetReference>Ninject.Web.Common</NuGetReference>
  <NuGetReference>Ninject.Web.Common.WebHost</NuGetReference>
  <NuGetReference>Ninject.Web.WebApi</NuGetReference>
  <NuGetReference>Ninject.Web.WebApi.WebHost</NuGetReference>
  <Namespace>Ninject</Namespace>
</Query>

// https://github.com/ninject/ninject/wiki/Contextual-Binding

void Main()
{
    Ninject.IKernel kernel = new StandardKernel(new TestModule());
    
    "\ngetting OnLandAttack".Dump();
    var zzz=kernel.Get<OnLandAttack>();
    
    "\ncalling OnLandAttack method".Dump();
    zzz.Hmmm();
    
    "\ngetting AmphibiousAttack".Dump();
    var yyy=kernel.Get<AmphibiousAttack>();


    //"\ngetting first instance of Yikes, with no general binding for IWeapon".Dump();
    //var yikes=kernel.Get<Yikes>();
    //// throws "Error activating UserQuery+IWeaponNo matching bindings are available, and the type is not self-bindable.Activation path:"

    // try redoing a binding
    "\nLoading new binding, does it override putting Dagger to AmphibiousAttack?".Dump();
    kernel.Load<Module2>();

    "\ngetting new AmphibiousAttack it does not override putting Dagger".Dump();
    var aaa=kernel.Get<AmphibiousAttack>();

    "\ngetting second instance of Yikes, after adding general binding for IWeapon".Dump();
    var yikes=kernel.Get<Yikes>();
}

// Define other methods and classes here

class Module2 : Ninject.Modules.NinjectModule
{ 
    public override void     Load()
    {
        Bind<IWeapon>().To<Sword>();
    }
    
}

class TestModule : Ninject.Modules.NinjectModule
{
    public override void Load()
    {
        Bind<IWeapon>().To<Sword>().WhenInjectedInto(typeof(OnLandAttack));
        Bind<IWeapon>().To<Dagger>().WhenInjectedInto(typeof(AmphibiousAttack));
        
        Bind<IFoo>().To<Foo>();
    }
}

class Yikes
{ 
    public Yikes(IWeapon weapon)
    {
        
        "instantiating Yikes".Dump();
    }
}

class OnLandAttack
{ 
    private IFoo foo;
    public OnLandAttack(IWeapon weapon, IFoo foo)
    {
        this.foo=foo;
        "instantiating OnLandAttack".Dump();
    }
    
    public void Hmmm()
    {
        foo.Bar("Hmm");
    }
}

class AmphibiousAttack
{
    public AmphibiousAttack(IWeapon weapon)
    {
        "instantiating AmphibiousAttack".Dump();
        
    }
}

interface IFoo
{
    void Bar(string bar);
}

public class Foo : IFoo
{
    public Foo()
    {
        "instantiating Foo".Dump();
        
    }
    public void Bar(string bar)
    {
        $"Bar {bar}!".Dump();
    }
}

public interface IWeapon
{
    string Hit(string target);
}

public class Sword : IWeapon
{
    public Sword()
    {
        "instantiating Sword".Dump();
    }
    public string Hit(string target)
    {
        return "Slice " + target + " in half";
    }
}

public class Dagger : IWeapon
{
    public Dagger()
    {
        
        "instantiating Dagger".Dump();
    }
    public string Hit(string target)
    {
        return "Stab " + target + " to death";
    }
}

public class Samurai
{
    readonly IWeapon[] allWeapons;

    public Samurai(IWeapon[] allWeapons)
    {
        this.allWeapons = allWeapons;
    }

    public void Attack(string target)
    {
        foreach (IWeapon weapon in this.allWeapons)
            Console.WriteLine(weapon.Hit(target));
    }
}