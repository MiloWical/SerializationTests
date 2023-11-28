using YamlDotNet.Serialization;
using VariableSerialization.YamlDotNet;

namespace VariableSerializationTests;

public class YamlDotNetSerializer
{
  private static readonly ISerializer serializer;
  private static readonly IDeserializer deserializer;

  static YamlDotNetSerializer()
  {
    serializer = new SerializerBuilder()
    .WithResultAndOptionTypeConverter()
    .Build();

    deserializer = new DeserializerBuilder()
      .WithResultAndOptionTypeConverter()
      .Build();
  }

  public static string Serialize<T>(T obj)
  {
    return serializer.Serialize(obj);
  }

  public static T Deserialize<T>(string json)
  {
    return deserializer.Deserialize<T>(json);
  }
}
