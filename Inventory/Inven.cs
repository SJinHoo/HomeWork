using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Inven<T>
    {
        private List<T> inventory = new List<T>(); // Generic List<T> 타입으로 인벤토리를 구현

        // index를 사용하여 리스트 내 아이템에 접근하도록 구현
        public T this[int index]
        {
            get { return inventory[index]; }
            set { inventory[index] = value; }
        }
       
        /// <summary>
        /// 아이템을 인벤토리에 추가하는 함수
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            inventory.Add(item);
        }

        /// <summary>
        /// 인벤토리에 있는 아이템을 삭제하는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            return inventory.Remove(item);
        }

        /// <summary>
        /// 인벤토리에서 특정 아이템을 찾는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Find(T item)
        {
            return inventory.Contains(item);
        }

        /// <summary>
        /// 인벤토리에서 특정 아이템을 찾는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int FindIndex(T item)
        {
            return inventory.IndexOf(item);
        }

        /// <summary>
        /// 인벤토리 내에있는 아이템 갯수를 반환하는 함수
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return inventory.Count;
        }
    }
}
