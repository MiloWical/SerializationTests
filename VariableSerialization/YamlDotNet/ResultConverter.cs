using WicalWare.Components.ResultCs;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace VariableSerialization.YamlDotNet;

internal class ResultConverter
{
  public static bool AcceptsGeneric(Type type) =>
    type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Result<,>);
}

internal class ResultConverter<T, E> : ResultConverter, IYamlTypeConverter
{
  private readonly ISerializer serializer;

  private readonly IDeserializer deserializer;

  internal ResultConverter(ISerializer serializer, IDeserializer deserializer)
  {
    this.serializer = serializer;
    this.deserializer = deserializer;
  }

  public bool Accepts(Type type) => AcceptsGeneric(type);

  public object? ReadYaml(IParser parser, Type type)
  {
    throw new NotImplementedException();
  }

  public void WriteYaml(IEmitter emitter, object? value, Type type)
  {
    throw new NotImplementedException();
  }

}
