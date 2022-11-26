using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowAPI.Models
{
    public class ItemSubClassesEntity
    {
        [JsonProperty("item_subclasses")]
        public ItemSubClass[] ItemSubClasses { get; set; }
    }

    public class ItemSubClass 
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
