using Newtonsoft.Json.Serialization;

namespace VariableSerialization.Newtonsoft.Json;

public class CompositeContractResolver : IContractResolver
{
  private static readonly DefaultContractResolver DefaultContractResolver = new();
  public IDictionary<Type, IContractResolver> ContractResolvers { get; init; }

  public CompositeContractResolver()
  {
    ContractResolvers = new Dictionary<Type, IContractResolver>();
  }

  public void Add<TContractResolver>(IContractResolver contractResolver)
  {
    ArgumentNullException.ThrowIfNull(contractResolver);

    ContractResolvers.Add(typeof(TContractResolver), contractResolver);
  }

  public JsonContract ResolveContract(Type type)
  {
    if (ContractResolvers.TryGetValue(type, out IContractResolver? value))
      return value.ResolveContract(type);

    return DefaultContractResolver.ResolveContract(type);
  }
}
