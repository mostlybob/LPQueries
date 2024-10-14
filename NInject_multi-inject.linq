<Query Kind="Program">
  <NuGetReference>Ninject</NuGetReference>
  <NuGetReference>Ninject.Extensions.Factory</NuGetReference>
  <NuGetReference>Ninject.Web.Common</NuGetReference>
  <NuGetReference>Ninject.Web.Common.WebHost</NuGetReference>
  <NuGetReference>Ninject.Web.WebApi</NuGetReference>
  <NuGetReference>Ninject.Web.WebApi.WebHost</NuGetReference>
  <Namespace>Ninject</Namespace>
</Query>

// https://github.com/ninject/Ninject/wiki/Multi-injection

void Main()
{
    Ninject.IKernel kernel = new StandardKernel(new TestModule());

    var samurai = kernel.Get<Samurai>();
    samurai.Attack("your enemy");
    
    var zz=kernel.GetAll<IWeapon>();
    foreach (var z in zz)
    {
        z.Hit("soo & so").Dump();
    }
}

// Define other methods and classes here


class TestModule : Ninject.Modules.NinjectModule
{
    public override void Load()
    {
        Bind<IWeapon>().To<Sword>();
        Bind<IWeapon>().To<Dagger>();
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