using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowAPI.Models
{
    public class ItemClassIndexEntity
    {
        public ItemClassIndexEntity() { }

        public ItemClassIndexEntity(int ID, string NAME)
        {
            id = ID;
            name = NAME;
        }

        public int id { get; set; }
        public string? name { get; set; }
    }
}
