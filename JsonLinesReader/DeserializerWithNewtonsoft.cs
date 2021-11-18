using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JsonLinesReader
{
    public class DeserializerWithNewtonsoft : ILinesDeserializer
    {
        public List<Item> GetItems(string content)
        {
            var jsonReader = new JsonTextReader(new StringReader(content))
            {
                SupportMultipleContent = true // This is important!
            };

            var jsonSerializer = new JsonSerializer();
            List<Item> items = new List<Item>();
            while (jsonReader.Read())
            {
                Item item = jsonSerializer.Deserialize<Item>(jsonReader);
                items.Add(item);
            }
            return items;
        }
    }
}