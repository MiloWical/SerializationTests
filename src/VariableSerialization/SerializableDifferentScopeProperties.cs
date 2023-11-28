using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace VariableSerialization;

[Serializable]
public class SerializableDifferentScopeProperties
{
  int defaultGetDefaultSetInt { get; set; } = 0;
  public int publicGetPublicSetInt { get; set; } = 1;
  public int publicGetPrivateSetInt { get; private set; } = 2;
  public int publicGetInternalSetInt { get; internal set; } = 3;
  public int publicGetProtectedSetInt { get; protected set; } = 4;
  public int publicGetProtectedInternalSetInt { get; protected internal set; } = 5;
  public int publicGetPrivateProtectedSetInt { get; private protected set; } = 6;
  private int privateGetPrivateSetInt { get;  set; } = 7;
  internal int internalGetPrivateSetInt { get; private set; } = 8;
  internal int internalGetInternalSetInt { get; set; } = 9;
  internal int internalGetPrivateProtectedSetInt { get; private protected set; } = 10;
  protected int protectedGetPrivateSetInt { get; private set; } = 11;
  protected int protectedGetProtectedSetInt { get; set; } = 12;
  protected int protectedGetPrivateProtectedSetInt { get; private protected set; } = 13;
  protected internal int protectedInternalGetPublicSetInt { get; set; } = 14;
  protected internal int protectedInternalGetPrivateSetInt { get; private set; } = 15;
  protected internal int protectedInternalGetInternalSetInt { get; internal set; } = 16;
  protected internal int protectedInternalGetProtectedSetInt { get; protected set; } = 17;
  protected internal int protectedInternalGetProtectedInternalSetInt { get; set; } = 18;
  protected internal int protectedInternalGetPrivateProtectedSetInt { get; private protected set; } = 19;
  private protected int privateProtectedGetPublicSetInt { get; set; } = 20;
  private protected int privateProtectedGetPrivateSetInt { get; private set; } = 21;
  private protected int privateProtectedGetPrivateProtectedSetInt { get; set; } = 22;
  
  [JsonInclude] // System.Text.Json
  [JsonProperty] // Newtonsoft.Json
  private int serializablePrivateGetPrivateSetInt { get;  set; } = 23;

  public override string ToString()
  {
    return
@$"defaultGetDefaultSetInt: {defaultGetDefaultSetInt}
publicGetPublicSetInt: {publicGetPublicSetInt}
publicGetPrivateSetInt: {publicGetPrivateSetInt}
publicGetInternalSetInt: {publicGetInternalSetInt}
publicGetProtectedSetInt: {publicGetProtectedSetInt}
publicGetProtectedInternalSetInt: {publicGetProtectedInternalSetInt}
publicGetPrivateProtectedSetInt: {publicGetPrivateProtectedSetInt}
privateGetPrivateSetInt: {privateGetPrivateSetInt}
internalGetPrivateSetInt: {internalGetPrivateSetInt}
internalGetInternalSetInt: {internalGetInternalSetInt}
internalGetPrivateProtectedSetInt: {internalGetPrivateProtectedSetInt}
protectedGetPrivateSetInt: {protectedGetPrivateSetInt}
protectedGetProtectedSetInt: {protectedGetProtectedSetInt}
protectedGetPrivateProtectedSetInt: {protectedGetPrivateProtectedSetInt}
protectedInternalGetPublicSetInt: {protectedInternalGetPublicSetInt}
protectedInternalGetPrivateSetInt: {protectedInternalGetPrivateSetInt}
protectedInternalGetInternalSetInt: {protectedInternalGetInternalSetInt}
protectedInternalGetProtectedSetInt: {protectedInternalGetProtectedSetInt}
protectedInternalGetProtectedInternalSetInt: {protectedInternalGetProtectedInternalSetInt}
protectedInternalGetPrivateProtectedSetInt: {protectedInternalGetPrivateProtectedSetInt}
privateProtectedGetPublicSetInt: {privateProtectedGetPublicSetInt}
privateProtectedGetPrivateSetInt: {privateProtectedGetPrivateSetInt}
privateProtectedGetPrivateProtectedSetInt: {privateProtectedGetPrivateProtectedSetInt}
serializablePrivateGetPrivateSetInt: {serializablePrivateGetPrivateSetInt}";
  }
}
