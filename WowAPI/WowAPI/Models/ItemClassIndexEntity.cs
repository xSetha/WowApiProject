using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace WowAPI.Models
{
    public class ItemClassIndexEntity
    {
        [JsonProperty("item_classes")]
        public ItemClass[] ItemClasses { get; set; }
    }

    public class ItemClass
    {
        public ItemClass(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
