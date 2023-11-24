using System.Text.Json;
using System.Text.Json.Serialization;
using WicalWare.Components.ResultCs;

namespace VariableSerialization.System.Text.Json;

public class OptionConverter<T> : JsonConverter<Option<T>>
{
  public override Option<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    throw new NotImplementedException();
  }

  public override void Write(Utf8JsonWriter writer, Option<T> value, JsonSerializerOptions options)
  {
    throw new NotImplementedException();
  }

}
