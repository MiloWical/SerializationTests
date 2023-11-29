using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace VariableSerialization.YamlDotNet;

internal class ResultAndOptionTypeConverter : IYamlTypeConverter
{
  private ISerializer? internalSerializer;
  private IDeserializer? internalDeserializer;
  private bool initialized;
  private static readonly Dictionary<Type, IYamlTypeConverter> converterCache = [];

  internal ResultAndOptionTypeConverter()
  {
    initialized = false;
  }

  internal void Initialize(SerializerBuilder serializerBuilder, DeserializerBuilder deserializerBuilder)
  {
    if (initialized)
    {
      throw new InvalidOperationException("Cannot initialize a ResultAndOptionTypeConverter that is already initialized.");
    }
    if(serializerBuilder != null)
    {
      internalSerializer = serializerBuilder.Build();
    }

    if(deserializerBuilder != null)
    {
      internalDeserializer = deserializerBuilder.Build();
    }

    initialized = true;
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
        [internalSerializer, internalDeserializer],
        null // CultureInfo => null = default
      ) as IYamlTypeConverter;
  }
}