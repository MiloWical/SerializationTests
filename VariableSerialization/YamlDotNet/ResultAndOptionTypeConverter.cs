using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace VariableSerialization.YamlDotNet;

public class ResultAndOptionTypeConverter(SerializerBuilder serializerBuilder, DeserializerBuilder deserializerBuilder) : IYamlTypeConverter
{
  private readonly ISerializer internalSerializer = serializerBuilder.Build();
  private readonly IDeserializer internalDeserializer = deserializerBuilder.Build();
  private readonly Dictionary<Type, IYamlTypeConverter> converterCache = [];

  public ResultAndOptionTypeConverter(SerializerBuilder serializerBuilder)
    : this(serializerBuilder, new DeserializerBuilder())
  {
    
  }

  public ResultAndOptionTypeConverter(DeserializerBuilder deserializerBuilder)
    : this(new SerializerBuilder(), deserializerBuilder)
  {
    
  }


  public bool Accepts(Type type) => 
   OptionConverter.AcceptsGeneric(type) || ResultConverter.AcceptsGeneric(type);

  public object? ReadYaml(IParser parser, Type type)
  {
    if(converterCache.TryGetValue(type, out var converter))
    {
      return converter.ReadYaml(parser, type);
    }

    if(OptionConverter.AcceptsGeneric(type))
    {
      converter = CreateConverter(type, typeof(OptionConverter<>));
    }

    else if(ResultConverter.AcceptsGeneric(type))
    {
      converter = CreateConverter(type, typeof(ResultConverter<,>));
    }

    else
    {
      throw new YamlException($"Could not deserialize type '{type}'");
    }

    converterCache.Add(type, converter!);
    return converter!.ReadYaml(parser, type);
  }

  public void WriteYaml(IEmitter emitter, object? value, Type type)
  {
    if(converterCache.TryGetValue(type, out var converter))
    {
      converter.WriteYaml(emitter, value, type);
      return;
    }

    if(OptionConverter.AcceptsGeneric(type))
    {
      converter = CreateConverter(type, typeof(OptionConverter<>));
    }

    else if(ResultConverter.AcceptsGeneric(type))
    {
      converter = CreateConverter(type, typeof(ResultConverter<,>));
    }

    else
    {
      throw new YamlException($"Could not deserialize type '{type}'");
    }

    converterCache.Add(type, converter!);
    converter!.WriteYaml(emitter, value, type);
  }

  private IYamlTypeConverter? CreateConverter(Type optionType, Type converterType)
  {
    var genericTypes = optionType.GenericTypeArguments;
    var converterInstanceType = converterType.MakeGenericType(genericTypes);
    return Activator.CreateInstance(
      converterInstanceType,
      [internalSerializer, internalDeserializer]) as IYamlTypeConverter;
  }
}