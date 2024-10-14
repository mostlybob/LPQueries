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
    /*
    original data
    {"trigger_set_id":5,"account_id":1,"account_platform_ids":[1090],"lead_type_id":1,"name":"Engagement","description":"Engagement Trigger Test 4","trigger_set_trigger_action_type_ids":[13,14],"trigger_set_completed_action_type_ids":[19,56,58,61,64,65,66,67],"enabled":true,"rank":1,"deleted":false}
   
    new data
    {"trigger_set_id":5,"account_id":1,"account_platform_ids":[1090],"lead_type_id":1,"name":"Engagement","description":"Engagement Trigger Test 5","trigger_set_trigger_action_type_ids":[13,14],"trigger_set_completed_action_type_ids":[19,56,58,61,64,65,66,67],"enabled":true,"rank":1,"deleted":false}
    
    original_data,new_data
"{""trigger_set_id"":5,""account_id"":1,""account_platform_ids"":[1090],""lead_type_id"":1,""name"":""Engagement"",""description"":""Engagement Trigger Test 4"",""trigger_set_trigger_action_type_ids"":[13,14],""trigger_set_completed_action_type_ids"":[19,56,58,61,64,65,66,67],""enabled"":true,""rank"":1,""deleted"":false}"
,
"{""trigger_set_id"":5,""account_id"":1,""account_platform_ids"":[1090],""lead_type_id"":1,""name"":""Engagement"",""description"":""Engagement Trigger Test 5"",""trigger_set_trigger_action_type_ids"":[13,14],""trigger_set_completed_action_type_ids"":[19,56,58,61,64,65,66,67],""enabled"":true,""rank"":1,""deleted"":false}"
    
    */


    var originalJson = @"{""trigger_set_id"":5,""account_id"":1,""account_platform_ids"":[1090],""lead_type_id"":1,""name"":""Engagement"",""description"":""Engagement Trigger Test 4"",""trigger_set_trigger_action_type_ids"":[13,14],""trigger_set_completed_action_type_ids"":[19,56,58,61,64,65,66,67],""enabled"":true,""rank"":1,""deleted"":false}";
    var updateJson = @"{""trigger_set_id"":5,""account_id"":1,""account_platform_ids"":[1090],""lead_type_id"":1,""name"":""Engagement"",""description"":""Engagement Trigger Test 5"",""trigger_set_trigger_action_type_ids"":[13,14],""trigger_set_completed_action_type_ids"":[19,56,58,61,64,65,66,67],""enabled"":true,""rank"":1,""deleted"":false}";

    var original=JsonConvert.DeserializeObject<Dictionary<string, object>>(originalJson);
    var update=JsonConvert.DeserializeObject<Dictionary<string, object>>(updateJson);

    original = NormalizeJArrayTypeMembers(original);
    update = NormalizeJArrayTypeMembers(update);

    foreach (var key in original.Keys)
    {

        if ((TheyAreJArrayType(original[key], update[key]) && ArraysAreEqual(original[key] as JArray, update[key] as JArray) == false) || update[key].Equals(original[key]) == false)
            Console.WriteLine($"{key}      changed from {original[key]} to { update[key] }");

//        else if (update[key].Equals(original[key]) == false)
//            Console.WriteLine($"{key}      changed from {original[key]} to { update[key] }");

        //        if (update[key] != original[key])
        //            Console.WriteLine($"{key}      changed from {original[key]} to { update[key] }");
    }




    //    foreach (var key in original.Keys)
//    {
//        //Console.WriteLine($"{original[key]} : {update[key]}\n{update[key].Equals( original[key])}\n-------------------------");
//
//        if (TheyAreJArrayType(original[key], update[key]) && ArraysAreEqual(original[key] as JArray, update[key] as JArray) == false)
//            Console.WriteLine($"{key}      changed from {original[key]} to { update[key] }");
//
//        if (update[key].Equals( original[key]) == false)
//            Console.WriteLine($"{key}      changed from {original[key]} to { update[key] }");
//            
////        if (update[key] != original[key])
////            Console.WriteLine($"{key}      changed from {original[key]} to { update[key] }");
//    }

/*
    var json=@"{""trigger_set_id"":5,""account_id"":1,""account_platform_ids"":[1090],""lead_type_id"":1,""name"":""Engagement"",""description"":""Engagement Trigger Test 4"",""trigger_set_trigger_action_type_ids"":[13,14],""trigger_set_completed_action_type_ids"":[19,56,58,61,64,65,66,67],""enabled"":true,""rank"":1,""deleted"":false}";
    
    Dictionary<string, object> values =
JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    
    values.Dump();
    
//    var foo=values["account_platform_ids"] as JArray;
    
    var foo= (values["account_platform_ids"] as JArray).Select(jv => (int)jv).ToArray();

    //int[] items = myJArray.Select(jv => (int)jv).ToArray();


    foo.Dump();
*/

}

// Define other methods and classes here

public bool TheyAreJArrayType(object original, object update)
{
    return original as JArray != null
        && update as JArray != null;
}

public bool TheyAreArrayTypeAndTheArraysDoNotMatch(object original, object update)
{
    return original as JArray != null
        && update as JArray != null
        && ArraysAreEqual(original as JArray, update as JArray) == false;
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
