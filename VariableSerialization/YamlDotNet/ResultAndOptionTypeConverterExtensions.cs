using YamlDotNet.Serialization;

namespace VariableSerialization.YamlDotNet;

public static class ResultAndOptionTypeConverterExtensions
{
  public static SerializerBuilder WithResultAndOptionTypeConverter(this SerializerBuilder serializerBuilder)
  { 
    return serializerBuilder.WithTypeConverter(new ResultAndOptionTypeConverter(serializerBuilder));
  }
}
