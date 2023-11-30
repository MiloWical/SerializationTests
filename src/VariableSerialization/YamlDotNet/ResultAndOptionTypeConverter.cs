using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace VariableSerialization.YamlDotNet;

internal class ResultAndOptionTypeConverter : IYamlTypeConverter
{
  private readonly Lazy<ISerializer?> internalSerializer;
  private readonly Lazy<IDeserializer?> internalDeserializer;
  private readonly Dictionary<Type, IYamlTypeConverter> converterCache = [];

  internal ResultAndOptionTypeConverter(SerializerBuilder serializerBuilder)
    : this(serializerBuilder, null!)
  { }

  internal ResultAndOptionTypeConverter(DeserializerBuilder deserializerBuilder)
    : this(null!, deserializerBuilder)
  { }

  internal ResultAndOptionTypeConverter(SerializerBuilder serializerBuilder, DeserializerBuilder deserializerBuilder)
  {
    internalSerializer = new Lazy<ISerializer?>(() => InitializeSerializer(serializerBuilder));

    internalDeserializer = new Lazy<IDeserializer?>(() => InitializeDeserializer(deserializerBuilder));
  }

  public bool Accepts(Type type) =>
   OptionConverter.AcceptsGeneric(type) || ResultConverter.AcceptsGeneric(type);

  public object? ReadYaml(IParser parser, Type type)
  {
    if (converterCache.TryGetValue(type, out var converter))
    {
      return converter.ReadYaml(parser, type);
    }

    if (OptionConverter.AcceptsGeneric(type))
    {
      converter = CreateConverter(type, typeof(OptionConverter<>));
    }

    else if (ResultConverter.AcceptsGeneric(type))
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
    if (converterCache.TryGetValue(type, out var converter))
    {
      converter.WriteYaml(emitter, value, type);
      return;
    }

    if (OptionConverter.AcceptsGeneric(type))
    {
      converter = CreateConverter(type, typeof(OptionConverter<>));
    }

    else if (ResultConverter.AcceptsGeneric(type))
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
        BindingFlags.Instance | BindingFlags.NonPublic,
        null, // Binder => null = default
        [internalSerializer.Value, internalDeserializer.Value],
        null // CultureInfo => null = default
      ) as IYamlTypeConverter;
  }

  private static ISerializer InitializeSerializer(SerializerBuilder builder)
  {
    ISerializer serializer = null!;

    if(builder != null)
    {
      serializer = builder.Build();
    }

    return serializer;
  }

  private static IDeserializer InitializeDeserializer(DeserializerBuilder builder)
  {
    IDeserializer deserializer = null!;

    if(builder != null)
    {
      deserializer = builder.Build();
    }

    return deserializer;
  }
}