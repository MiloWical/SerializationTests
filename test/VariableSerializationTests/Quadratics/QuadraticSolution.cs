using WicalWare.Components.ResultCs;

namespace VariableSerializationTests.Quadratics;

public class QuadraticSolution
{
  private bool isReal;
  public bool IsReal() => isReal;

  public ComplexNumber[]? Roots { get; init; }
  private Result<ComplexNumber[], QuadraticException>? realRoots; 
  public Result<ComplexNumber[], QuadraticException> RealRoots() => realRoots!;

  private Result<ComplexNumber[], QuadraticException>? complexRoots;
  public Result<ComplexNumber[], QuadraticException> ComplexRoots() => complexRoots!;

  public QuadraticSolution()
  { }

  [System.Text.Json.Serialization.JsonConstructor] // Necessary because of multiple serializers
  [Newtonsoft.Json.JsonConstructor] // Necessary because of multiple serializers
  
  public QuadraticSolution(ComplexNumber[] roots)
  {
    Roots = roots;
    isReal = roots.All(r => r.IsReal());

    if(IsReal())
    {
      realRoots = Result<ComplexNumber[], QuadraticException>.Ok(roots);
      complexRoots = Result<ComplexNumber[], QuadraticException>.Err(new QuadraticException("All roots are real."));
    }
    else
    {
      realRoots = Result<ComplexNumber[], QuadraticException>.Err(new QuadraticException("All roots are complex."));
      complexRoots = Result<ComplexNumber[], QuadraticException>.Ok(roots);
    }
  }

  public override string ToString()
  {
    return $"{{{Roots![0]}, {Roots![1]}}}";
  }
}
