using YamlDotNet.Serialization;

namespace VariableSerialization.YamlDotNet;

public static class ResultAndOptionTypeConverterExtensions
{
  public static SerializerBuilder WithResultAndOptionTypeConverter(this SerializerBuilder serializerBuilder)
  { 
    return serializerBuilder.WithTypeConverter(new ResultAndOptionTypeConverter(serializerBuilder));
  }

  public static DeserializerBuilder WithResultAndOptionTypeConverter(this DeserializerBuilder deserializerBuilder)
  { 
    return deserializerBuilder.WithTypeConverter(new ResultAndOptionTypeConverter(deserializerBuilder));
  }
}
