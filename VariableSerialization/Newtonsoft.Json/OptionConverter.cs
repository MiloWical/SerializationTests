using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WicalWare.Components.ResultCs;

namespace VariableSerialization.Newtonsoft.Json;

public class OptionConverter<T> : JsonConverter
{
  public override bool CanConvert(Type objectType)
  {
    return objectType == typeof(Option<T>);
  }

  public override Option<T> ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    JObject json = JObject.Load(reader);

    var kind = Enum.Parse<OptionKind>(json["Kind"]!.ToString());
        
    if(kind == OptionKind.Some)
    {
      T val = json["Some"]!.ToObject<T>()!;
      return Option<T>.Some(val);
    }
    else if (kind == OptionKind.None)
    {
      return Option<T>.None();
    }

    throw new ArgumentException($"Count not convert {kind} to {objectType}");
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    if (value is null) return;

    var option = (Option<T>)value;

    var json = new JObject
    {
      new JProperty("Kind", option.Kind.ToString())
    };

    if (option.IsSome())
    {
      json.Add(new JProperty("Some", option.Unwrap()));
    }

    json.WriteTo(writer);
  }

}
