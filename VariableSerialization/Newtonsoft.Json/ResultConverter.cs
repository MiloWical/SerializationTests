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

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    if (value is null) return;

    var result = (Result<T, E>)value;

    var obj = JObject.FromObject(result);

    if (result.IsOk())
    {
      obj.Add(new JProperty("Ok", JObject.FromObject(result.Unwrap()!)));
    }
    else
    {
      obj.Add(new JProperty("Rrr", JObject.FromObject(result.UnwrapErr()!)));
    }

    obj.WriteTo(writer);
  }

}
