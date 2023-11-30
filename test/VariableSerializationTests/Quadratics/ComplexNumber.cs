using WicalWare.Components.ResultCs;

namespace VariableSerializationTests.Quadratics;

public class ComplexNumber
{
  public Option<double> RealPart { get; init; }
  public Option<double> ComplexPart{ get; init; }

  public bool IsReal() => ComplexPart.IsNone();

  public override string ToString()
  {
    var output = RealPart.IsSome() ? RealPart.Unwrap().ToString("0.##") : "0";
    
    if(ComplexPart.IsSome())
    {
      var complexPart = ComplexPart.Unwrap();
      
      if(complexPart > 0.0)
      {
        output += $"+{complexPart:0.##}i";
      }
      else if(complexPart < 0.0)
      {
        output += $"{complexPart:0.##}i";
      }
    }

    return output;
  }
}
