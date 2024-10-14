<Query Kind="Program">
  <NuGetReference>NUnitLite</NuGetReference>
  <Namespace>NUnit</Namespace>
  <Namespace>NUnit.Common</Namespace>
  <Namespace>NUnit.Compatibility</Namespace>
  <Namespace>NUnit.Framework</Namespace>
  <Namespace>NUnit.Framework.Api</Namespace>
  <Namespace>NUnit.Framework.Constraints</Namespace>
  <Namespace>NUnit.Framework.Interfaces</Namespace>
  <Namespace>NUnit.Framework.Internal</Namespace>
  <Namespace>NUnit.Framework.Internal.Builders</Namespace>
  <Namespace>NUnit.Framework.Internal.Commands</Namespace>
  <Namespace>NUnit.Framework.Internal.Execution</Namespace>
  <Namespace>NUnit.Options</Namespace>
  <Namespace>NUnitLite</Namespace>
</Query>


void Main()
{
    //    new NUnitLite.Runner.TextUI().Execute(new[] { "-noheader" })


    //    new NUnitLite
    //        .TextRunner(this.GetType().Assembly)
    //        .Execute(new[] {
    //            "-noheader", 
    //            "--work=C:\\Users\\robert.campbell.AUTOALERT\\Documents\\" //LINQPad/ Queries"
    //        });

    var workpath=@"C:\Users\robert.campbell.AUTOALERT\Documents\LINQPadTests";
    workpath.Dump();

    var foo = new AutoRun().Execute(new[] {
            "-noheader",
            $"--work={workpath}",
            $"--out={workpath}\\output",
            $"--err={workpath}\\error"
        });
        
    foo.Dump("foo");
}

[TestFixture]
public class TestClass
{
    [Test]
    public void SomeTest()
    {
        Assert.Pass("SomeTest passed");
        Assert.Fail("fail");
    }
}
