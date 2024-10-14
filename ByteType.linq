<Query Kind="Program" />

/*
https://zetcode.com/csharp/byte/
*/

void Main()
{
    byte val1 = 5;
    sbyte val2 = -4;
    
    var zzz=(int)val1;
    zzz.Dump("cast");
    
    var yyy=(byte)zzz;
    
    yyy.GetType().Name.Dump("cast");



    First();
    //UTFWork();
    //WriteToFile();

    //The zetcode article has other examples

}



void WriteToFile()
{
    var path = "words.txt";

    System.IO.FileStream fs = File.Create(path);
    byte[] data = Encoding.UTF8.GetBytes("falcon\nribbon\ncloud\nwater");
    fs.Write(data, 0, data.Length);

    Console.WriteLine("data written to file");

}

void UTFWork()
{
    string word = "čerešňa";

    byte[] data = Encoding.UTF8.GetBytes(word);
    Console.WriteLine(string.Join(" ", data));

    string word2 = Encoding.UTF8.GetString(data);
    Console.WriteLine(word2);
}

void First()
{
    byte val1 = 5;
    sbyte val2 = -4;

    val1.Dump();
    val2.Dump();

    val1.GetType().Dump();
    val2.GetType().Dump();

    Console.WriteLine(byte.MinValue);
    Console.WriteLine(byte.MaxValue);

    Console.WriteLine(sbyte.MinValue);
    Console.WriteLine(sbyte.MaxValue);

    Console.WriteLine("------------------------");

    Console.WriteLine(typeof(byte));
    Console.WriteLine(typeof(sbyte));
    Console.WriteLine(default(byte));
    Console.WriteLine(default(sbyte));
}

