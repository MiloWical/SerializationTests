using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json;
using VariableSerialization;
using System.Text.Json;
using WicalWare.Components.ResultCs;
using VariableSerialization.Newtonsoft.Json;
using VariableSerialization.System.Text.Json;

var defaultColor = Console.ForegroundColor;

var systemTextSerializerOptions = new JsonSerializerOptions
{
  IncludeFields = true
};

try
{
  // ProcessStandardClasses();
  // ProcessSerializableClasses();
  // ProcessOptions();
  // ProcessOptionsWithNewtonsoftCustomComponents();
  // ProcessResultsWithNewtonsoftCustomComponents();
  //ProcessOptionsWithCustomDotNetComponents();
  ProcessResultsWithCustomDotNetComponents();
}
catch (Exception e)
{
  Console.WriteLine(e);
}
finally
{
  Console.ForegroundColor = defaultColor;
}


void ProcessStandardClasses()
{
  Console.ForegroundColor = ConsoleColor.Cyan;
  Console.WriteLine("===== VARIABLES (System.Text.Json) =====");
  Console.WriteLine();

  var variableTest = new DifferentScopeVariables();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(variableTest);
  Console.WriteLine();

  var serializedTest = JsonSerializer.Serialize(variableTest, systemTextSerializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<DifferentScopeVariables>(serializedTest, systemTextSerializerOptions));
  Console.WriteLine();

  Console.WriteLine("===== PROPERTIES (System.Text.Json) =====");
  Console.WriteLine();

  var propertyTest = new DifferentScopeProperties();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(propertyTest);
  Console.WriteLine();

  serializedTest = JsonSerializer.Serialize(propertyTest, systemTextSerializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<DifferentScopeProperties>(serializedTest, systemTextSerializerOptions));
  Console.WriteLine();

  Console.ForegroundColor = ConsoleColor.Green;

  Console.WriteLine("===== VARIABLES (Newtonsoft.Json) =====");
  Console.WriteLine();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(variableTest);
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(variableTest);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<DifferentScopeVariables>(serializedTest));
  Console.WriteLine();

  Console.WriteLine("===== PROPERTIES (Newtonsoft.Json) =====");
  Console.WriteLine();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(propertyTest);
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(propertyTest);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<DifferentScopeProperties>(serializedTest));
  Console.WriteLine();
}

void ProcessSerializableClasses()
{
  Console.ForegroundColor = ConsoleColor.Red;
  Console.WriteLine("===== SERIALIZABLE VARIABLES (System.Text.Json) =====");
  Console.WriteLine();

  var serializableVariableTest = new SerializableDifferentScopeVariables();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(serializableVariableTest);
  Console.WriteLine();

  var serializedTest = JsonSerializer.Serialize(serializableVariableTest, systemTextSerializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<SerializableDifferentScopeVariables>(serializedTest, systemTextSerializerOptions));
  Console.WriteLine();

  Console.WriteLine("===== SERIALIZABLE PROPERTIES (System.Text.Json) =====");
  Console.WriteLine();

  var serializablePropertyTest = new SerializableDifferentScopeProperties();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(serializablePropertyTest);
  Console.WriteLine();

  serializedTest = JsonSerializer.Serialize(serializablePropertyTest, systemTextSerializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<SerializableDifferentScopeProperties>(serializedTest, systemTextSerializerOptions));
  Console.WriteLine();

  Console.ForegroundColor = ConsoleColor.Yellow;

  Console.WriteLine("===== SERIALIZABLE VARIABLES (Newtonsoft.Json) =====");
  Console.WriteLine();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(serializableVariableTest);
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(serializableVariableTest);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<SerializableDifferentScopeVariables>(serializedTest));
  Console.WriteLine();

  Console.WriteLine("===== SERIALIZABLE PROPERTIES (Newtonsoft.Json) =====");
  Console.WriteLine();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(serializablePropertyTest);
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(serializablePropertyTest);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<SerializableDifferentScopeProperties>(serializedTest));
  Console.WriteLine();
}

void ProcessOptions()
{
  Console.ForegroundColor = ConsoleColor.Magenta;
  Console.WriteLine("===== OPTION.NONE (System.Text.Json) =====");
  Console.WriteLine();

  var optionTest = Option<int>.None();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(optionTest);
  Console.WriteLine();

  var serializedTest = JsonSerializer.Serialize(optionTest, systemTextSerializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<Option<int>>(serializedTest, systemTextSerializerOptions));
  Console.WriteLine();

  Console.WriteLine("===== OPTION.SOME (System.Text.Json) =====");
  Console.WriteLine();

  optionTest = Option<int>.Some(55);

  Console.WriteLine("Before serialization:");
  Console.WriteLine(optionTest.UnwrapOr(-1));
  Console.WriteLine();

  serializedTest = JsonSerializer.Serialize(optionTest, systemTextSerializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<Option<int>>(serializedTest, systemTextSerializerOptions)!.UnwrapOr(-1));
  Console.WriteLine();

  Console.ForegroundColor = ConsoleColor.White;
  Console.WriteLine("===== OPTION.NONE (Newtonsoft.Json) =====");
  Console.WriteLine();

  optionTest = Option<int>.None();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(optionTest);
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(optionTest);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<Option<int>>(serializedTest));
  Console.WriteLine();

  Console.WriteLine("===== OPTION.SOME (Newtonsoft.Json) =====");
  Console.WriteLine();

  optionTest = Option<int>.Some(55);

  Console.WriteLine("Before serialization:");
  Console.WriteLine(optionTest.UnwrapOr(-1));
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(optionTest);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<Option<int>>(serializedTest)!.UnwrapOr(-1));
  Console.WriteLine();
}

void ProcessOptionsWithNewtonsoftCustomComponents()
{
  Console.ForegroundColor = ConsoleColor.DarkYellow;
  Console.WriteLine("===== OPTION.NONE (Newtonsoft.Json Converter) =====");
  Console.WriteLine();

  var optionTest = Option<int>.None();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(optionTest);
  Console.WriteLine();

  var serializedTest = JsonConvert.SerializeObject(optionTest, new VariableSerialization.Newtonsoft.Json.OptionConverter<int>());

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<Option<int>>(serializedTest, new VariableSerialization.Newtonsoft.Json.OptionConverter<int>())!.Kind);
  Console.WriteLine();

  Console.WriteLine("===== OPTION.SOME (Newtonsoft.Json Converter) =====");
  Console.WriteLine();

  optionTest = Option<int>.Some(55);

  Console.WriteLine("Before serialization:");
  Console.WriteLine(optionTest.UnwrapOr(-1));
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(optionTest, new VariableSerialization.Newtonsoft.Json.OptionConverter<int>());

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<Option<int>>(serializedTest, new VariableSerialization.Newtonsoft.Json.OptionConverter<int>())!.UnwrapOr(-1));
  Console.WriteLine();

  Console.ForegroundColor = ConsoleColor.DarkCyan;
  Console.WriteLine("===== OPTION.SOME (Newtonsoft.Json ContractResolver) =====");
  Console.WriteLine();

  var serializerSettings = new JsonSerializerSettings
  {
    ContractResolver = new ResultAndOptionContractResolver()
  };

  optionTest = Option<int>.Some(99);

  Console.WriteLine("Before serialization:");
  Console.WriteLine(optionTest.UnwrapOr(-1));
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(optionTest, serializerSettings);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<Option<int>>(serializedTest, serializerSettings)!.UnwrapOr(-1));
  Console.WriteLine();
}

void ProcessResultsWithNewtonsoftCustomComponents()
{
  Console.ForegroundColor = ConsoleColor.DarkGreen;
  Console.WriteLine("===== RESULT.ERR (Newtonsoft.Json Converter) =====");
  Console.WriteLine();

  var resultTest = Result<int, string>.Err("Bad mojo.");

  Console.WriteLine("Before serialization:");
  Console.WriteLine(resultTest);
  Console.WriteLine();

  var serializedTest = JsonConvert.SerializeObject(resultTest, new VariableSerialization.Newtonsoft.Json.ResultConverter<int, string>());

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<Result<int, string>>(serializedTest, new VariableSerialization.Newtonsoft.Json.ResultConverter<int, string>())!.UnwrapErr());
  Console.WriteLine();

  Console.WriteLine("===== RESULT.OK (Newtonsoft.Json Converter) =====");
  Console.WriteLine();

  resultTest = Result<int, string>.Ok(55);

  Console.WriteLine("Before serialization:");
  Console.WriteLine(resultTest.UnwrapOr(-1));
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(resultTest, new VariableSerialization.Newtonsoft.Json.ResultConverter<int, string>());

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<Result<int, string>>(serializedTest, new VariableSerialization.Newtonsoft.Json.ResultConverter<int, string>())!.UnwrapOr(-1));
  Console.WriteLine();

  Console.ForegroundColor = ConsoleColor.DarkRed;
  Console.WriteLine("===== RESULT.OK (Newtonsoft.Json ContractResolver) =====");
  Console.WriteLine();

  var serializerSettings = new JsonSerializerSettings
  {
    ContractResolver = new ResultAndOptionContractResolver()
  };

  resultTest = Result<int, string>.Ok(99);

  Console.WriteLine("Before serialization:");
  Console.WriteLine(resultTest.UnwrapOr(-1));
  Console.WriteLine();

  serializedTest = JsonConvert.SerializeObject(resultTest, serializerSettings);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonConvert.DeserializeObject<Result<int, string>>(serializedTest, serializerSettings)!.UnwrapOr(-1));
  Console.WriteLine();
}

void ProcessOptionsWithCustomDotNetComponents()
{
  var serializerOptions = new JsonSerializerOptions();
  serializerOptions.Converters.Add(new ResultAndOptionConverterFactory());

  Console.ForegroundColor = ConsoleColor.DarkMagenta;
  Console.WriteLine("===== OPTION.NONE (System.Text.Json Converter) =====");
  Console.WriteLine();

  var optionTest = Option<int>.None();

  Console.WriteLine("Before serialization:");
  Console.WriteLine(optionTest.Kind);
  Console.WriteLine();

  var serializedTest = JsonSerializer.Serialize(optionTest, serializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<Option<int>>(serializedTest, serializerOptions)!.Kind);
  Console.WriteLine();

  Console.WriteLine("===== OPTION.SOME (System.Text.Json Converter) =====");
  Console.WriteLine();

  optionTest = Option<int>.Some(55);

  Console.WriteLine("Before serialization:");
  Console.WriteLine(optionTest.UnwrapOr(-1));
  Console.WriteLine();

  serializedTest = JsonSerializer.Serialize(optionTest, serializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<Option<int>>(serializedTest, serializerOptions)!.UnwrapOr(-1));
  Console.WriteLine();
}

void ProcessResultsWithCustomDotNetComponents()
{
  var serializerOptions = new JsonSerializerOptions();
  serializerOptions.Converters.Add(new ResultAndOptionConverterFactory());

  Console.ForegroundColor = ConsoleColor.DarkGreen;
  Console.WriteLine("===== RESULT.ERR (System.Text.Json Converter) =====");
  Console.WriteLine();

  var resultTest = Result<int, string>.Err("Bad mojo.");

  Console.WriteLine("Before serialization:");
  Console.WriteLine(resultTest.UnwrapErr());
  Console.WriteLine();

  var serializedTest = JsonSerializer.Serialize(resultTest, serializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<Result<int, string>>(serializedTest, serializerOptions)!.UnwrapErr());
  Console.WriteLine();

  Console.WriteLine("===== RESULT.OK (System.Text.Json Converter) =====");
  Console.WriteLine();

  resultTest = Result<int, string>.Ok(55);

  Console.WriteLine("Before serialization:");
  Console.WriteLine(resultTest.UnwrapOr(-1));
  Console.WriteLine();

  serializedTest = JsonSerializer.Serialize(resultTest, serializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<Result<int, string>>(serializedTest, serializerOptions)!.UnwrapOr(-1));
  Console.WriteLine();

  Console.ForegroundColor = ConsoleColor.DarkRed;
  Console.WriteLine("===== RESULT.OK (System.Text.Json Converter) =====");
  Console.WriteLine();

  resultTest = Result<int, string>.Ok(99);

  Console.WriteLine("Before serialization:");
  Console.WriteLine(resultTest.UnwrapOr(-1));
  Console.WriteLine();

  serializedTest = JsonSerializer.Serialize(resultTest, serializerOptions);

  Console.WriteLine("Serialized object:");
  Console.WriteLine(serializedTest);
  Console.WriteLine();

  Console.WriteLine("After deserialization:");
  Console.WriteLine(JsonSerializer.Deserialize<Result<int, string>>(serializedTest, serializerOptions)!.UnwrapOr(-1));
  Console.WriteLine();
}