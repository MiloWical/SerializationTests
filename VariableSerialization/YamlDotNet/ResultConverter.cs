using WicalWare.Components.ResultCs;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace VariableSerialization.YamlDotNet;

public class ResultConverter
{
  public static bool AcceptsGeneric(Type type) =>
    type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Result<,>);
}

public class ResultConverter<T, E>(ISerializer serializer, IDeserializer deserializer) : ResultConverter, IYamlTypeConverter
{
  private readonly ISerializer serializer = serializer;

  private readonly IDeserializer deserializer = deserializer;

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
