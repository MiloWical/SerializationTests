using System.Text.Json;
using VariableSerialization.System.Text.Json;
using YamlDotNet.Serialization;

namespace VariableSerializationTests;

public class DotNetJsonSerializer
{
  private static readonly JsonSerializerOptions serializerOptions;
  
  static DotNetJsonSerializer()
  {
    serializerOptions = new JsonSerializerOptions();
    serializerOptions.Converters.Add(new ResultAndOptionConverterFactory());
  }

  public static string Serialize<T>(T obj)
  {
    return JsonSerializer.Serialize<T>(obj, serializerOptions);
  }

  public static T? Deserialize<T>(string json)
  {
    return JsonSerializer.Deserialize<T>(json, serializerOptions);
  }
}
