<Query Kind="Program" />

void Main()
{
    var topLevelDirectory=@"C:\autoalert\git\motofuze\AutoAlert.IntelligentMarketing\";
    
    System.IO.DirectoryInfo di=new DirectoryInfo(topLevelDirectory);
    
    di.EnumerateDirectories("*",SearchOption.AllDirectories).Dump();
    // looks like it recurses down through all the folders, which is what I want
    // Originally, I was thinking I'd need to do the recursion myself.
}

// Define other methods and classes here
