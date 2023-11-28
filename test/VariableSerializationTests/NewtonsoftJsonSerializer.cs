using Newtonsoft.Json;
using VariableSerialization.Newtonsoft.Json;

namespace VariableSerializationTests.Quadratics;

public class NewtonsoftJsonSerializer
{
  private static readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
  {
    ContractResolver = new ResultAndOptionContractResolver()
  };

  public static string Serialize<T>(T obj)
  {
    return JsonConvert.SerializeObject(obj, serializerSettings);
  }

  public static T? Deserialize<T>(string json)
  {
    return JsonConvert.DeserializeObject<T>(json, serializerSettings);
  }
}
