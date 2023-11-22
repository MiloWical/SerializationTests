# SerializationTests

Useful links:

- [Newtonsoft.Json.Serialization.DefaultContractResolver](https://github.com/JamesNK/Newtonsoft.Json/blob/01e1759cac40d8154e47ed0e11c12a9d42d2d0ff/Src/Newtonsoft.Json/Serialization/DefaultContractResolver.cs#L234): This should be able to override the member serialization mechanism to allow the private members to serialize.

- [Serialization using ContractResolver (Newtonsoft.Json))](https://www.newtonsoft.com/json/help/html/ContractResolver.htm): How to use a custom `ConstractResolver`.

- [Example: Serialize private fields (System.Text.Json)](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/custom-contracts#example-serialize-private-fields): Demonstrates how to create a custom attribute for private field serialization.

- [System.Text.Json – How to serialize non-public properties](https://makolyte.com/system-text-json-how-to-serialize-non-public-properties/): An example of how to serialize using a custom converter rather than attributes.