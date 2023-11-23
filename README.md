# SerializationTests

Useful links:

- [Serialization using ContractResolver (Newtonsoft.Json))](https://www.newtonsoft.com/json/help/html/ContractResolver.htm): How to use a custom `ContractResolver`.

- [Newtonsoft.Json.Serialization.DefaultContractResolver](https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Serialization/DefaultContractResolver.cs#L234): This should be able to override the member serialization mechanism to allow the private members to serialize.

- [Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver](https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Serialization/CamelCasePropertyNamesContractResolver.cs): An example implementation of a custom `ContractResolver`.

- [Newtonsoft.Json.JsonConverter](https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/JsonConverter.cs#L37): The JsonConverter abstract class.

- [Example: Serialize private fields (System.Text.Json)](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/custom-contracts#example-serialize-private-fields): Demonstrates how to create a custom attribute for private field serialization.

- [System.Text.Json – How to serialize non-public properties](https://makolyte.com/system-text-json-how-to-serialize-non-public-properties/): An example of how to serialize using a custom converter rather than attributes.

- [How to write custom converters for JSON serialization (marshalling) in .NET (System.Text.Json)](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-8-0): Might be useful to look at this for controlling the deserialization using the static functions provided in the `Option<T>` and `Result<T>` objects.

- [Custom JSON Converter (Newtonsoft.json)](https://www.newtonsoft.com/json/help/html/CustomJsonConverter.htm): How to implement a custom converter for serialization.