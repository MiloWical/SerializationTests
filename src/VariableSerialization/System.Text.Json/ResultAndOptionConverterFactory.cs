using System.Text.Json;
using System.Text.Json.Serialization;
using WicalWare.Components.ResultCs;

namespace VariableSerialization.System.Text.Json;

public class ResultAndOptionConverterFactory : JsonConverterFactory
{
  public override bool CanConvert(Type typeToConvert)
  {
    if(!typeToConvert.IsGenericType)
    {
      return false;
    }
    var genericType = typeToConvert.GetGenericTypeDefinition();

    return genericType == typeof(Result<,>) || genericType == typeof(Option<>);
  }

  public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
  {
    var baseType = typeToConvert.GetGenericTypeDefinition();

    Type converterType;

    if(baseType == typeof(Result<,>))
    {
      converterType = typeof(ResultConverter<,>);
    }
    else if(baseType == typeof(Option<>))
    {
      converterType = typeof(OptionConverter<>);
    }
    else
    {
      throw new ArgumentException($"Could not generate converter for generic type {baseType} of type {typeToConvert}.", nameof(typeToConvert));
    }

    var genericTypes = typeToConvert.GenericTypeArguments;
  
    var converterInstanceType = converterType.MakeGenericType(genericTypes);
    return Activator.CreateInstance(converterInstanceType) as JsonConverter;
  }

}
