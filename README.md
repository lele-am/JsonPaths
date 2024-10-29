# JsonPaths

A C# class library made for JSON manipulation using paths to nodes.

## Features

- Load JSON data from a file.
- Save JSON data to a file.
- Check if a path exists in the JSON data.
- Retrieve the value at a specific path.
- Set the value at a specific path.
- Delete a key at a specific path.

## Installation

To use this library, add a reference to the JsonPaths-DLL in your project.
# Usage
## Loading JSON Data
```csharp
JSON json = new JSON("path/to/your/file.json");
```
## Saving JSON Data
```csharp
json.Save("file.json");
```
## Checking if a path exists
```csharp
bool exists = json.PathExists("order/id");
```
## Retrieving a value
```csharp
string value = json.Value("order/id");
```
## Setting (or creating) a value
```csharp
json.SetKey("order/newKey", "\"newValue\"");
```
## Deleting a key
```csharp
bool deleted = json.DeleteKey("order/newKey");
```

# Example (JsonPathsRunner)
```csharp
using System;
using JsonPaths;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the path to the JSON file:");
        string filepath = Console.ReadLine();

        JSON jsonLib = new JSON(filepath);

        Console.WriteLine("Loaded JSON:");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Check if a path exists");
            Console.WriteLine("2. Get value at a path");
            Console.WriteLine("3. Set value at a path");
            Console.WriteLine("4. Delete value at a path");
            Console.WriteLine("5. Save JSON file");
            Console.WriteLine("Type 'exit' to quit");

            string choice = Console.ReadLine();

            if (choice.ToLower() == "exit")
            {
                break;
            }

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter the path to check:");
                    string pathToCheck = Console.ReadLine();
                    bool exists = jsonLib.PathExists(pathToCheck);
                    Console.WriteLine($"Path exists: {exists}");
                    break;

                case "2":
                    Console.WriteLine("Enter the path to get the value:");
                    string pathToGet = Console.ReadLine();
                    var value = jsonLib.Value(pathToGet);
                    Console.WriteLine($"Value at path: {value}");
                    break;

                case "3":
                    Console.WriteLine("Enter the path to set the value:");
                    string pathToSet = Console.ReadLine();
                    Console.WriteLine("Enter the value to set:");
                    string valueToSet = Console.ReadLine();
                    jsonLib.SetKey(pathToSet, valueToSet);
                    Console.WriteLine("Value set successfully.");
                    break;

                case "4":
                    Console.WriteLine("Enter the path to delete the value:");
                    string pathToDelete = Console.ReadLine();
                    bool deleted = jsonLib.DeleteKey(pathToDelete);
                    Console.WriteLine($"Value deleted: {deleted}");
                    break;

                case "5":
                    Console.WriteLine("Enter the path to save the JSON file:");
                    string savePath = Console.ReadLine();
                    jsonLib.Save(savePath);
                    Console.WriteLine("JSON file saved successfully.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
```

# License
This project is licensed under the CC0 License.
