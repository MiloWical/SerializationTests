using WicalWare.Components.ResultCs;

namespace VariableSerializationTests.Quadratics;

public class Quadratic
{
  public double A { get; init; }
  public double B { get; init; }
  public double C { get; init; }

  private QuadraticSolution? solution;

  public QuadraticSolution Solution()
  {
    if (solution == null)
    {
      var discriminant = Math.Pow(B, 2) - (4 * A * C);

      if (discriminant >= 0)
      {
        solution = new QuadraticSolution([
          new ComplexNumber{
              RealPart = Option<double>.Some(((-1 * B) + Math.Sqrt(discriminant)) / (2 * A)),
              ComplexPart = Option<double>.None()
            },
            new ComplexNumber{
              RealPart = Option<double>.Some(((-1 * B) - Math.Sqrt(discriminant)) / (2 * A)),
              ComplexPart = Option<double>.None()
            },
          ]);
      }
      else
      {
        solution = new QuadraticSolution([
          new ComplexNumber{
              RealPart = Option<double>.Some(-1 * B / (2 * A)),
              ComplexPart = Option<double>.Some(Math.Sqrt(-1 * discriminant) / (2 * A))
            },
            new ComplexNumber{
              RealPart = Option<double>.Some(-1 * B / (2 * A)),
              ComplexPart = Option<double>.Some(-1 * Math.Sqrt(-1 * discriminant) / (2 * A))
            },
          ]);
      }

    }

    return solution;
  }

  public override string ToString()
  {
    return $"{A:0.##}x^2{(B < 0 ? "" : "+")}{B:0.##}x{(C < 0 ? "" : "+")}{C:0.##}";
  }

}