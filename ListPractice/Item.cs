using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListPractice
{
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public Item(string name, string type, int quantity)
        {
            this.Name = name;
            this.Type = type;
            this.Quantity = quantity;
        }
    }
}
