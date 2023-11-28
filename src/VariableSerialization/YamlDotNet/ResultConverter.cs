using WicalWare.Components.ResultCs;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
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
    ResultKind kind = (ResultKind)(-1);
    T? val = default;
    E? err = default;

    parser.Consume<MappingStart>();

    while(parser.Current!.GetType() != typeof(MappingEnd))
    {
      if(((Scalar)parser.Current).Value == "Kind")
      {
        parser.Consume<Scalar>();
        kind = Enum.Parse<ResultKind>(((Scalar)parser.Current).Value);
        parser.Consume<Scalar>();
      }

      else if(((Scalar)parser.Current).Value == "Ok")
      {
        parser.Consume<Scalar>();
        val = deserializer.Deserialize<T>(((Scalar)parser.Current).Value);
        parser.Consume<Scalar>();
      }

      else if(((Scalar)parser.Current).Value == "Err")
      {
        parser.Consume<Scalar>();
        err = deserializer.Deserialize<E>(((Scalar)parser.Current).Value);
        parser.Consume<Scalar>();
      }
    }

    parser.Consume<MappingEnd>();
    
    if(kind == ResultKind.Ok)
    {
      return Result<T, E>.Ok(val!);
    }

    if(kind == ResultKind.Err)
    {
      return Result<T, E>.Err(err!);
    }

    throw new YamlException($"Could not parse Result<{typeof(T)}, {typeof(E)}>.");
  }

  public void WriteYaml(IEmitter emitter, object? value, Type type)
  {
    if(value is null)
    {
      return;
    }
    var result = (Result<T, E>)value;

    emitter.Emit(new MappingStart());

    emitter.Emit(new Scalar("Kind"));
    emitter.Emit(new Scalar(result.Kind.ToString()));
    
    if(result.IsOk())
    {
      emitter.Emit(new Scalar("Ok"));
      emitter.Emit(new Scalar(serializer.Serialize(result.Unwrap())));
    }
    else if(result.IsErr())
    {
      emitter.Emit(new Scalar("Err"));
      emitter.Emit(new Scalar(serializer.Serialize(result.UnwrapErr())));
    }
    
    emitter.Emit(new MappingEnd());
  }

}
