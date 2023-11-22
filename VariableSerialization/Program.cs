﻿using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json;
using VariableSerialization;
using System.Text.Json;

var defaultColor = Console.ForegroundColor;

var systemTextSerializerOptions = new JsonSerializerOptions
{
  IncludeFields = true
};

ProcessStandardClasses();
ProcessSerializableClasses();

Console.ForegroundColor = defaultColor;


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