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
    OptionKind kind = (OptionKind)(-1);
    T? val = default;
    parser.Consume<MappingStart>();

    while(parser.Current!.GetType() != typeof(MappingEnd))
    {
      if(((Scalar)parser.Current).Value == "Kind")
      {
        parser.Consume<Scalar>();
        kind = Enum.Parse<OptionKind>(((Scalar)parser.Current).Value);
        parser.Consume<Scalar>();
      }

      else if(((Scalar)parser.Current).Value == "Some")
      {
        parser.Consume<Scalar>();
        val = deserializer.Deserialize<T>(((Scalar)parser.Current).Value);
        parser.Consume<Scalar>();
      }
    }

    parser.Consume<MappingEnd>();
    
    if(kind == OptionKind.None)
    {
      return Option<T>.None();
    }

    if(kind == OptionKind.Some)
    {
      return Option<T>.Some(val!);
    }

    throw new YamlException($"Could not parse Option<{typeof(T)}>.");
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
