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

Console.WriteLine("=====SERIALIZATION=====");
var dotnetSerializedQuadratic = DotNetJsonSerializer.Serialize(realRootsQuadratic);
Console.WriteLine("[Quadratic] System.Text.Json Serialization:");
Console.WriteLine(dotnetSerializedQuadratic);
Console.WriteLine();
var newtonsoftSerializedQuadratic = NewtonsoftJsonSerializer.Serialize(realRootsQuadratic);
Console.WriteLine("[Quadratic] Newtonsoft.Json Serialization:");
Console.WriteLine(newtonsoftSerializedQuadratic);
Console.WriteLine();
var yamlSerializedQuadratic = YamlDotNetSerializer.Serialize(realRootsQuadratic);
Console.WriteLine("[Quadratic] YAML Serialization:");
Console.WriteLine(yamlSerializedQuadratic);
Console.WriteLine();

Console.WriteLine("=====DESERIALIZATION=====");
var dotnetDeserializedQuadratic = DotNetJsonSerializer.Deserialize<Quadratic>(dotnetSerializedQuadratic);
Console.WriteLine("[Quadratic] System.Text.Json Deserialization:");
Console.WriteLine(dotnetDeserializedQuadratic);
Console.WriteLine();
var newtonsoftDeserializedQuadratic = NewtonsoftJsonSerializer.Deserialize<Quadratic>(newtonsoftSerializedQuadratic);
Console.WriteLine("[Quadratic] Newtonsoft.Json Deserialization:");
Console.WriteLine(newtonsoftDeserializedQuadratic);
Console.WriteLine();
var yamlDeserializedQuadratic = YamlDotNetSerializer.Deserialize<Quadratic>(yamlSerializedQuadratic);
Console.WriteLine("[Quadratic] YAML Deserialization:");
Console.WriteLine(yamlDeserializedQuadratic);
Console.WriteLine();

var realSolution = realRootsQuadratic.Solution();

Console.WriteLine(realSolution);
Console.WriteLine();
var dotnetSerializedRealSolution = DotNetJsonSerializer.Serialize(realSolution);
Console.WriteLine("[Solution] System.Text.Json Serialization:");
Console.WriteLine(dotnetSerializedRealSolution);
Console.WriteLine();
var newtonsoftSerializedRealSolution = NewtonsoftJsonSerializer.Serialize(realSolution);
Console.WriteLine("[Solution] Newtonsoft.Json Serialization:");
Console.WriteLine(newtonsoftSerializedRealSolution);
Console.WriteLine();
var yamlSerializedRealSolution = YamlDotNetSerializer.Serialize(realSolution);
Console.WriteLine("[Solution] YAML Serialization:");
Console.WriteLine(yamlSerializedRealSolution);
Console.WriteLine();

Console.WriteLine("=====DESERIALIZATION=====");
var dotnetDeserializedRealSolution = DotNetJsonSerializer.Deserialize<QuadraticSolution>(dotnetSerializedRealSolution);
Console.WriteLine("[Solution] System.Text.Json Deserialization:");
Console.WriteLine(dotnetDeserializedRealSolution);
Console.WriteLine();
var newtonsoftDeserializedRealSolution = NewtonsoftJsonSerializer.Deserialize<QuadraticSolution>(newtonsoftSerializedRealSolution);
Console.WriteLine("[Solution] Newtonsoft.Json Deserialization:");
Console.WriteLine(newtonsoftDeserializedRealSolution);
Console.WriteLine();
var yamlDeserializedRealSolution = YamlDotNetSerializer.Deserialize<QuadraticSolution>(yamlSerializedRealSolution);
Console.WriteLine("[Solution] YAML Deserialization:");
Console.WriteLine(yamlDeserializedRealSolution);
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Blue;

Quadratic complexRootsQuadratic = new()
{
  A = 1,
  B = 2,
  C = 3
};

Console.WriteLine(complexRootsQuadratic);

Console.WriteLine("=====SERIALIZATION=====");
dotnetSerializedQuadratic = DotNetJsonSerializer.Serialize(complexRootsQuadratic);
Console.WriteLine("[Quadratic] System.Text.Json Serialization:");
Console.WriteLine(dotnetSerializedQuadratic);
Console.WriteLine();
newtonsoftSerializedQuadratic = NewtonsoftJsonSerializer.Serialize(complexRootsQuadratic);
Console.WriteLine("[Quadratic] Newtonsoft.Json Serialization:");
Console.WriteLine(newtonsoftSerializedQuadratic);
Console.WriteLine();
yamlSerializedQuadratic = YamlDotNetSerializer.Serialize(complexRootsQuadratic);
Console.WriteLine("[Quadratic] YAML Serialization:");
Console.WriteLine(yamlSerializedQuadratic);
Console.WriteLine();

Console.WriteLine("=====DESERIALIZATION=====");
dotnetDeserializedQuadratic = DotNetJsonSerializer.Deserialize<Quadratic>(dotnetSerializedQuadratic);
Console.WriteLine("[Quadratic] System.Text.Json Deserialization:");
Console.WriteLine(dotnetDeserializedQuadratic);
Console.WriteLine();
newtonsoftDeserializedQuadratic = NewtonsoftJsonSerializer.Deserialize<Quadratic>(newtonsoftSerializedQuadratic);
Console.WriteLine("[Quadratic] Newtonsoft.Json Deserialization:");
Console.WriteLine(newtonsoftDeserializedQuadratic);
Console.WriteLine();
yamlDeserializedQuadratic = YamlDotNetSerializer.Deserialize<Quadratic>(yamlSerializedQuadratic);
Console.WriteLine("[Quadratic] YAML Deserialization:");
Console.WriteLine(yamlDeserializedQuadratic);
Console.WriteLine();

var complexSolution = complexRootsQuadratic.Solution();

Console.WriteLine(complexSolution);
Console.WriteLine();
var dotnetSerializedComplexSolution = DotNetJsonSerializer.Serialize(complexSolution);
Console.WriteLine("[Solution] System.Text.Json Serialization:");
Console.WriteLine(dotnetSerializedComplexSolution);
Console.WriteLine();
var newtonsoftSerializedComplexSolution = NewtonsoftJsonSerializer.Serialize(complexSolution);
Console.WriteLine("[Solution] Newtonsoft.Json Serialization:");
Console.WriteLine(newtonsoftSerializedComplexSolution);
Console.WriteLine();
var yamlSerializedComplexSolution = YamlDotNetSerializer.Serialize(complexSolution);
Console.WriteLine("[Solution] YAML Serialization:");
Console.WriteLine(yamlSerializedComplexSolution);
Console.WriteLine();

Console.WriteLine("=====DESERIALIZATION=====");
var dotnetDeserializedComplexSolution = DotNetJsonSerializer.Deserialize<QuadraticSolution>(dotnetSerializedComplexSolution);
Console.WriteLine("[Solution] System.Text.Json Deserialization:");
Console.WriteLine(dotnetDeserializedComplexSolution);
Console.WriteLine();
var newtonsoftDeserializedComplexSolution = NewtonsoftJsonSerializer.Deserialize<QuadraticSolution>(newtonsoftSerializedComplexSolution);
Console.WriteLine("[Solution] Newtonsoft.Json Deserialization:");
Console.WriteLine(newtonsoftDeserializedComplexSolution);
Console.WriteLine();
var yamlDeserializedComplexSolution = YamlDotNetSerializer.Deserialize<QuadraticSolution>(yamlSerializedComplexSolution);
Console.WriteLine("[Solution] YAML Deserialization:");
Console.WriteLine(yamlDeserializedComplexSolution);
Console.WriteLine();

Console.ForegroundColor = defaultConsoleColor;