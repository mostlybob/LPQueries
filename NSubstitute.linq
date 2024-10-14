<Query Kind="Program">
  <NuGetReference>NSubstitute</NuGetReference>
  <NuGetReference>NUnit</NuGetReference>
  <Namespace>NSubstitute</Namespace>
  <Namespace>NUnit.Framework</Namespace>
</Query>

void Main()
{

    var calculator = Substitute.For<ICalculator>();
    
    calculator.Add(Arg.Any<int>(), 5).Returns(10);
    
    Assert.AreEqual(10, calculator.Add(123, 5));
    Assert.AreEqual(10, calculator.Add(-9, 5));
    Assert.AreNotEqual(10, calculator.Add(-9, -9));

    //Return when first arg is 1 and second arg less than 0:
    calculator.Add(1, Arg.Is<int>(x => x < 0)).Returns(345);
    Assert.AreEqual(345, calculator.Add(1, -2));
    Assert.AreNotEqual(345, calculator.Add(1, 2));

    //Return when both args equal to 0:
    calculator.Add(Arg.Is(0), Arg.Is(0)).Returns(99);
    Assert.AreEqual(99, calculator.Add(0, 0));



    Should_execute_command();
    Should_execute_argument_command();
    
    //Expression<Func<int>> return5 = () => 5;
    //Func<int> compiled = return5.Compile();
    //Console.WriteLine(compiled());
    //
    //
    //Expression<Func<string,int>> fooz=x=>x.Length;
    //Func<string,int> baz=fooz.Compile();
    //
    //Console.WriteLine(baz("Hello"));
    //   
    //
    //T FetchSingle<T>(Expression<Func<T, bool>> predicate);
    
    //Expression<Func<T, bool>> predicate
    
}

// You can define other methods, fields, classes and namespaces here
public interface ICalculator
{
    int Add(int a, int b);
    string Mode { get; set; }
}


public interface ICommand
{
    void Execute();
    event EventHandler Executed;
    
    // - my additions
    
    void Execute(int foo);
    
}

public class SomethingThatNeedsACommand
{
    ICommand command;
    public SomethingThatNeedsACommand(ICommand command)
    {
        this.command = command;
    }
    public void DoSomething() 
    {
        command.Execute();
        
    }
    
    public void DoSomething(int whatever)
    {
        command.Execute(whatever);
        
    }
    public void DontDoAnything() { }
    
    // - my additions
    
    
}

public void Should_execute_command()
{
    // example from NSubstitute docs
    
    //Arrange
    
    var command = Substitute.For<ICommand>();
    var something = new SomethingThatNeedsACommand(command);
    //Act
    something.DoSomething();
    //Assert
    command.Received().Execute();
}
public void Should_execute_argument_command()
{
    //Arrange
    var command = Substitute.For<ICommand>();
    
    var something = new SomethingThatNeedsACommand(command);
    //Act
    something.DoSomething(333);
    //Assert
    command.Received().Execute(333);
}
