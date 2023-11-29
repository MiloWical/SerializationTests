using YamlDotNet.Serialization;

namespace VariableSerialization.YamlDotNet;

public static class ResultAndOptionTypeConverterExtensions
{
  public static SerializerBuilder WithResultAndOptionTypeConverter(this SerializerBuilder serializerBuilder)
  { 
    //return serializerBuilder.WithTypeConverter(new ResultAndOptionTypeConverter(serializerBuilder));
    
    var converter = new ResultAndOptionTypeConverter();
    serializerBuilder.WithTypeConverter(converter);
    converter.Initialize(serializerBuilder, null!);
    return serializerBuilder;
  }

  public static DeserializerBuilder WithResultAndOptionTypeConverter(this DeserializerBuilder deserializerBuilder)
  { 
    //return deserializerBuilder.WithTypeConverter(new ResultAndOptionTypeConverter(deserializerBuilder));
    
    var converter = new ResultAndOptionTypeConverter();
    deserializerBuilder.WithTypeConverter(converter);
    converter.Initialize(null!, deserializerBuilder);
    return deserializerBuilder;
  }
}
