using System.Text.Json;
using System.Text.Json.Serialization;
using WicalWare.Components.ResultCs;

namespace VariableSerialization.System.Text.Json;

public class ResultConverter<T, E> : JsonConverter<Result<T, E>>
{
  public override Result<T, E>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    ResultKind kind = (ResultKind)(-1);
    T? val = default;
    E? err = default;

    if (reader.TokenType != JsonTokenType.StartObject)
    {
      throw new JsonException();
    }

    reader.Read();

    while (reader.TokenType != JsonTokenType.EndObject)
    {
      if (reader.TokenType != JsonTokenType.PropertyName)
      {
        throw new JsonException();
      }

      if (reader.ValueTextEquals("Kind"))
      {
        reader.Skip();
        kind = Enum.Parse<ResultKind>(reader.GetString()!);
      }

      else if (reader.ValueTextEquals("Ok"))
      {
        reader.Skip();
        val = JsonSerializer.Deserialize<T>(ref reader, options)!;
      }

      else if (reader.ValueTextEquals("Err"))
      {
        reader.Skip();
        err = JsonSerializer.Deserialize<E>(ref reader, options)!;
      }

      reader.Read();
    }

    if (kind == ResultKind.Ok)
    {
      if (val is null)
      {
        throw new JsonException("Cannot create an Result.Ok with a null value.");
      }

      return Result<T, E>.Ok(val);
    }

    if (kind == ResultKind.Err)
    {
      if (err is null)
      {
        throw new JsonException("Cannot create an Result.Err with a null value.");
      }

      return Result<T, E>.Err(err);
    }

    throw new JsonException($"Could not deserialize a Result with kind '{kind}'.");
  }

  public override void Write(Utf8JsonWriter writer, Result<T, E> result, JsonSerializerOptions options)
  {
    if (result is null) return;

    writer.WriteStartObject();

    writer.WriteString("Kind", result.Kind.ToString());

    if (result.IsOk())
    {
      writer.WritePropertyName("Ok");
      JsonSerializer.Serialize(writer, result.Unwrap(), options);
    }

    else if (result.IsErr())
    {
      writer.WritePropertyName("Err");
      JsonSerializer.Serialize(writer, result.UnwrapErr(), options);
    }

    writer.WriteEndObject();
  }

}
