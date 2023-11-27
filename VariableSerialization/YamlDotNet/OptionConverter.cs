using WicalWare.Components.ResultCs;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace VariableSerialization.YamlDotNet;

internal class OptionConverter
{
   public static bool AcceptsGeneric(Type type) => 
    type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Option<>);
}

internal class OptionConverter<T> : OptionConverter, IYamlTypeConverter
{
  private readonly ISerializer serializer;

  private readonly IDeserializer deserializer;

  internal OptionConverter(ISerializer serializer, IDeserializer deserializer)
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
    if(value is null)
    {
      return;
    }
    var option = (Option<T>)value;

    emitter.Emit(new MappingStart());

    emitter.Emit(new Scalar("Kind"));
    emitter.Emit(new Scalar(option.Kind.ToString()));
    
    if(option.IsSome())
    {
      emitter.Emit(new Scalar("Some"));
      emitter.Emit(new Scalar(serializer.Serialize(option.Unwrap())));
    }
    emitter.Emit(new MappingEnd());
  }

}
