using Newtonsoft.Json;

namespace WowAPI.Models
{
    public class ItemClassEntity
    {
        [JsonProperty("item_classes")]
        public ItemClass[] ItemClasses { get; set; }
    }

    public class ItemClass
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        public bool CheckedItemStatus { get; set; }
    }
}
