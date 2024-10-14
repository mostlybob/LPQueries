<Query Kind="Program">
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
    var originalJson = @"{""trigger_set_id"":5,""account_id"":1,""account_platform_ids"":[1090],""lead_type_id"":1,""name"":""Engagement"",""description"":""Engagement Trigger Test 4"",""trigger_set_trigger_action_type_ids"":[13,14],""trigger_set_completed_action_type_ids"":[19,56,58,61,64,65,66,67],""enabled"":true,""rank"":1,""deleted"":false}";
    var updateJson = @"{""trigger_set_id"":5,""account_id"":1,""account_platform_ids"":[1090],""lead_type_id"":1,""name"":""Engagement"",""description"":""Engagement Trigger Test 5"",""trigger_set_trigger_action_type_ids"":[13,14],""trigger_set_completed_action_type_ids"":[19,56,58,61,64,65,66,67],""enabled"":true,""rank"":1,""deleted"":false}";

    var originalData = JsonConvert.DeserializeObject<Dictionary<string, object>>(originalJson);
    var updatedData = JsonConvert.DeserializeObject<Dictionary<string, object>>(updateJson);

    originalData = NormalizeJArrayTypeMembers(originalData);
    updatedData = NormalizeJArrayTypeMembers(updatedData);
    
//    original["account_platform_ids"].Dump("original");
//    update["account_platform_ids"].Dump("update");
//    (original["account_platform_ids"] as IEnumerable<int>).Dump("cast to IEnumerable<int>");
//    ArraysAreEqual(original["account_platform_ids"] as IEnumerable<int>, update["account_platform_ids"] as IEnumerable<int>).Dump("ArraysAreEqual");

    foreach (var key in originalData.Keys)
    {
        if (originalData[key] as IEnumerable<int> != null)
        {
            if (ArraysAreEqual(originalData[key] as IEnumerable<int>, updatedData[key] as IEnumerable<int>) == false)
                Console.WriteLine($"{key} - {originalData[key]} : {updatedData[key]}");
                
//            ArraysAreEqual(original[key] as IEnumerable<int>, update[key] as IEnumerable<int>).Dump("ArraysAreEqual");
            continue;
        }
        if (updatedData[key].Equals(originalData[key]) == false)
        {
            Console.WriteLine($"{key} - {originalData[key]} : {updatedData[key]}");
        }
    }
}

public bool ArraysAreEqual<T>(IEnumerable<T> array1, IEnumerable<T> array2)
{
    if (array1.Count() != array2.Count())
        return false;

    return array1
        .OrderBy(a1 => a1)
        .SequenceEqual(array2.OrderBy(a2 => a2));
}

public Dictionary<string, object> NormalizeJArrayTypeMembers(Dictionary<string, object> source)
{
    var normalized = new Dictionary<string, object>();

    foreach (var key in source.Keys.OrderBy(k => k))
    {
        normalized[key] = source[key] as JArray == null
            ? source[key]
            : (source[key] as JArray)
                .Select(jv => (int)jv)
                .ToArray();
    }

    return normalized;
}