using System;
using System.Collections.Generic;
using System.IO;

namespace JsonLinesReader
{
    internal interface ILinesDeserializer
    {
        List<Item> GetItems(string content);
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var content = File.ReadAllText("items.jsonl");
            ILinesDeserializer linesDeserializer = new DeserializerWithNewtonsoft();
            var items = linesDeserializer.GetItems(content);

            foreach (var item in items)
            {
                Console.WriteLine($"#{item.Id}: {item.Name} ({item.Category})");
            }
        }
    }
}