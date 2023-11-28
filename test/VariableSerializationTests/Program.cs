using VariableSerializationTests;
using VariableSerializationTests.Quadratics;

var defaultConsoleColor = Console.ForegroundColor;

Console.ForegroundColor = ConsoleColor.Green;

Quadratic realRootsQuadratic = new()
{
  A = 1,
  B = 1,
  C = -12
};

Console.WriteLine(realRootsQuadratic);
Console.WriteLine();
Console.WriteLine("[Quadratic] System.Text.Json Serialization:");
Console.WriteLine(DotNetJsonSerializer.Serialize(realRootsQuadratic));
Console.WriteLine();
Console.WriteLine("[Quadratic] Newtonsoft.Json Serialization:");
Console.WriteLine(NewtonsoftJsonSerializer.Serialize(realRootsQuadratic));
Console.WriteLine();
Console.WriteLine("[Quadratic] YAML Serialization:");
Console.WriteLine(YamlDotNetSerializer.Serialize(realRootsQuadratic));
Console.WriteLine();

var realSolution = realRootsQuadratic.Solution;

Console.WriteLine(realSolution);
Console.WriteLine();
Console.WriteLine("[Solution] System.Text.Json Serialization:");
Console.WriteLine(DotNetJsonSerializer.Serialize(realSolution));
Console.WriteLine();
Console.WriteLine("[Solution] Newtonsoft.Json Serialization:");
Console.WriteLine(NewtonsoftJsonSerializer.Serialize(realSolution));
Console.WriteLine();
Console.WriteLine("[Quadratic] YAML Serialization:");
Console.WriteLine(YamlDotNetSerializer.Serialize(realSolution));
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Blue;

Quadratic complexRootsQuadratic = new()
{
  A = 1,
  B = 2,
  C = 3
};

Console.WriteLine(complexRootsQuadratic);

var complexSolution = complexRootsQuadratic.Solution;

Console.WriteLine(complexSolution);



Console.ForegroundColor = defaultConsoleColor;