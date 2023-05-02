using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListPractice
{
    public class Inventory
    {
        List<Item> ItemList;

        public Inventory()
        {
            this.ItemList = new List<Item>();
        }

        public void AddItem(Item item)
        {
            foreach (Item i in ItemList)
            {
                if (i.Name == item.Name)
                {
                    i.Quantity += item.Quantity;
                    return;
                }
            }
            ItemList.Add(item);
        }
        public void RemoveItem(Item item)
        {
            foreach (Item i in ItemList)
            {
                if (i.Name == item.Name)
                {
                    i.Quantity -= item.Quantity;
                    if (i.Quantity <= 0)
                    {
                        ItemList.Remove(i);
                    }
                    return;
                }
            }
        }

        public void PrintInventory()
        {
            Console.WriteLine("인벤토리 목록: ");
            foreach (Item item in ItemList)
            {
                Console.WriteLine("{0} - {1} * {2}개",item.Name,item.Type,item.Quantity);
            }
        }

        
    }
}
