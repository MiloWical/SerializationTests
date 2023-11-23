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

  public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
  {
    throw new NotImplementedException();
  }

  public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
  {
    if (value is null) return;

    var option = (Option<T>)value;

    var obj = JObject.FromObject(option);

    // TODO: Force string serialization of the "Kind" enum.

    if (option.IsSome())
    {
      obj.Add(new JProperty("Some", option.Unwrap()));
    }

    obj.WriteTo(writer);
  }

}
