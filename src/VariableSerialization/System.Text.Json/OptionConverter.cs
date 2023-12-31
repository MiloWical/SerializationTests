using System.Text.Json;
using System.Text.Json.Serialization;
using WicalWare.Components.ResultCs;

namespace VariableSerialization.System.Text.Json;

public class OptionConverter<T> : JsonConverter<Option<T>>
{
  public override Option<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    OptionKind kind = (OptionKind)(-1);
    T? val = default;

    if (reader.TokenType != JsonTokenType.StartObject)
    {
        throw new JsonException();
    }

    reader.Read();

    while(reader.TokenType != JsonTokenType.EndObject)
    {
      if(reader.TokenType != JsonTokenType.PropertyName)
      {
        throw new JsonException();
      }

      if(reader.ValueTextEquals("Kind"))
      {
        reader.Skip();
        kind = Enum.Parse<OptionKind>(reader.GetString()!);
      }

      else if(reader.ValueTextEquals("Some"))
      {
        reader.Skip();
        val = JsonSerializer.Deserialize<T>(ref reader, options)!;
      }

      reader.Read();
    }
    
    if(kind == OptionKind.None)
    {
      return Option<T>.None();
    } 
    else if(kind == OptionKind.Some)
    {
      if(val is null)
      {
        throw new JsonException("Cannot create an Option.Some with a null value.");
      }

      return Option<T>.Some(val);
    }

    throw new JsonException($"Could not deserialize an Option with kind '{kind}'.");
  }

  public override void Write(Utf8JsonWriter writer, Option<T> option, JsonSerializerOptions options)
  {
    if (option is null) return;

    writer.WriteStartObject();

    writer.WriteString("Kind", option.Kind.ToString());

    if(option.IsSome())
    {
      writer.WritePropertyName("Some");
      JsonSerializer.Serialize(writer, option.Unwrap(), options);
    }

    writer.WriteEndObject();
  }
}
