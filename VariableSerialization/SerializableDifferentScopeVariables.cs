using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace VariableSerialization;

[Serializable]
public class SerializableDifferentScopeVariables
{
  public static int publicStaticInt = -1;
  int defaultInt = 0;
  public int publicInt = 1;
  private int privateInt = 2;
  internal int internalInt = 3;
  protected int protectedInt = 4;
  protected internal int protectedInternalInt = 5;
  private protected int privateProtectedInt = 6;

  [JsonInclude] // System.Text.Json
  [JsonProperty] // Newtonsoft.Json
  private int serializablePrivateInt = 7;

  public override string ToString()
  {
    return
@$"publicStaticInt: {publicStaticInt}
defaultInt: {defaultInt}
publicInt: {publicInt}
privateInt: {privateInt}
internalInt: {internalInt}
protectedInt: {protectedInt}
protectedInternalInt: {protectedInternalInt}
privateProtectedInt: {privateProtectedInt}
serializablePrivateInt: {serializablePrivateInt}";
  }
}
