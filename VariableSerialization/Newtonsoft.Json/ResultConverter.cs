using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WicalWare.Components.ResultCs;

namespace VariableSerialization.Newtonsoft.Json;

public class ResultConverter<T,E> : JsonConverter
{
  public override bool CanConvert(Type objectType)
  {
    return objectType == typeof(Result<T,E>);
  }

  public override Result<T,E> ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    JObject json = JObject.Load(reader);

    var kind = Enum.Parse<ResultKind>(json["Kind"]!.ToString());

    if (kind == ResultKind.Ok)
    {
      T val = json["Ok"]!.ToObject<T>()!;
      return Result<T, E>.Ok(val);
    }
    else if (kind == ResultKind.Err)
    {
      E err = json["Err"]!.ToObject<E>()!;
      return Result<T, E>.Err(err);
    }

    throw new ArgumentException($"Count not convert {kind} to {objectType}");
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    if (value is null) return;

    var result = (Result<T, E>)value;

    var json = new JObject
    {
      new JProperty("Kind", result.Kind.ToString())
    };

    if (result.IsOk())
    {
      json.Add(new JProperty("Ok", result.Unwrap()!));
    }
    else
    {
      json.Add(new JProperty("Err", result.UnwrapErr()!));
    }

    json.WriteTo(writer);
  }

}
