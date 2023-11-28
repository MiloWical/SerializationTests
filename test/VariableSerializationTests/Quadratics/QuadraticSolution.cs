using System.Text;
using WicalWare.Components.ResultCs;

namespace VariableSerializationTests.Quadratics;

public class QuadraticSolution
{
  public bool IsReal { get; private init; }
  public Result<ComplexNumber[], QuadraticException> RealRoots { get; private init; }
  public Result<ComplexNumber[], QuadraticException> ComplexRoots { get; private init; }

  public QuadraticSolution(ComplexNumber[] roots)
  {
    IsReal = roots.All(r => r.IsReal);

    if(IsReal)
    {
      RealRoots = Result<ComplexNumber[], QuadraticException>.Ok(roots);
      ComplexRoots = Result<ComplexNumber[], QuadraticException>.Err(new QuadraticException("All roots are real."));
    }
    else
    {
      RealRoots = Result<ComplexNumber[], QuadraticException>.Err(new QuadraticException("All roots are complex."));
      ComplexRoots = Result<ComplexNumber[], QuadraticException>.Ok(roots);
    }
  }

  public override string ToString()
  {
    ComplexNumber[] roots;
    if (IsReal)
    {
      roots = RealRoots.Unwrap();
    }
    else
    {
      roots = ComplexRoots.Unwrap();
    }

    return $"{{{roots[0]}, {roots[1]}}}";
  }
}
