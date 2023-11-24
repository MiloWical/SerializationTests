using System.Text.Json;
using System.Text.Json.Serialization;
using WicalWare.Components.ResultCs;

namespace VariableSerialization.System.Text.Json;

public class ResultConverter<T, E> : JsonConverter<Result<T, E>>
{
  public override Result<T, E>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    throw new NotImplementedException();
  }

  public override void Write(Utf8JsonWriter writer, Result<T, E> value, JsonSerializerOptions options)
  {
    throw new NotImplementedException();
  }

}
