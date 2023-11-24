using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WicalWare.Components.ResultCs;

namespace VariableSerialization.Newtonsoft.Json;

public class ResultAndOptionContractResolver : DefaultContractResolver
{
  private Dictionary<Type, JsonContract> contractCache;

  public ResultAndOptionContractResolver()
  {
    contractCache = [];
  }

  public override JsonContract ResolveContract(Type type)
  {
    if (contractCache.TryGetValue(type, out JsonContract? jsonContract))
    {
      return jsonContract;
    }

    jsonContract = base.CreateContract(type);

    JsonConverter? jsonConverter = null;

    var genericType = type.GetGenericTypeDefinition();

    if (genericType == typeof(Option<>))
    {
      jsonConverter = CreateConverter(type, typeof(OptionConverter<>));
    }
    else if (genericType == typeof(Result<,>))
    {
      jsonConverter = CreateConverter(type, typeof(ResultConverter<,>));
    }

    jsonContract.Converter = jsonConverter ?? throw new ArgumentException($"Could not create a converter for the type {type}");

    contractCache[type] = jsonContract;

    return jsonContract;
  }

  private static JsonConverter? CreateConverter(Type optionType, Type converterType)
  {
    var genericTypes = optionType.GenericTypeArguments;
    var converterInstanceType = converterType.MakeGenericType(genericTypes);
    return Activator.CreateInstance(converterInstanceType) as JsonConverter;
  }
}
