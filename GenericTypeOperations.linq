<Query Kind="Program">
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

/*
- bailed before finishing, the serializer stuff was depending on NetSerializer 
- more trouble than I wanted to get into  
*/

void Main()
{
    //System.Text.Encoding.Default.GetString(SerializedDataB()).Dump();
    
    

    
    (GetDeserializedData<List<Foo>>(SerializedDataB(),null)).Dump("List<Foo>");
    (GetDeserializedData<object>(SerializedDataB(),null)).Dump("object");

    
}


public class Foo
{
    public IEnumerable<int> Bar { get; set; }
    public Baz Baz { get; set; }
}

public class Baz
{
    public string Name { get; set; }
    public int Id { get; set; }
}

public T GetDeserializedData<T>(byte[] Data, string JsonData)
{
    /*
    - snagged from a helper class
    - not my preferred way, but this is for illustration
    */
    object deserializedData = null;

    if (Data != null)
    {
        deserializedData = DeserializeJobData(Data);
    }
    else if (JsonData != null)
    {
        deserializedData = DeserializeJobDataJson(JsonData, typeof(T));
    }

    return (deserializedData != null && deserializedData is T) ? (T)deserializedData : default(T);
}




object DeserializeJobData(byte[] serialized)
{
    using (MemoryStream memStream = new MemoryStream())
    {
        memStream.Write(serialized, 0, serialized.Length);
        memStream.Seek(0, SeekOrigin.Begin);

        object jobData = _serializer.Deserialize(memStream);

        return jobData;
    }
}

// - this stuff, I made up myself
private object DeserializeJobDataJson(string jsonData, Type type)
{
    var foo = JsonConvert.DeserializeObject(jsonData);
    return foo;
}



byte[] SerializedDataB()
{
    var zzz = Encoding.ASCII.GetBytes(SerializedData());
    return zzz;
}

string SerializedData()
{
    var fooz = new List<Foo>
    {
        new Foo
        {
            Bar=new[]{1,2,3},
            Baz=new Baz
            {
                Name="Foo1",
                Id=1
            }
        },
        new Foo
        {
            Bar=new List<int>{4,5,6},
            Baz=new Baz
            {
                Name="Foo2",
                Id=2
            }
        },
        new Foo
        {
            Bar=new List<int>{7,8,9},
            Baz=new Baz
            {
                Name="Foo3",
                Id=3
            }
        },
    };

    var json = JsonConvert.SerializeObject(fooz);

    return json;
}