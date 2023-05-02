using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueuePractice
{
    internal class AdapterStack<T>  // 스택 자료구조를 구현하는 제네릭 클래스 AdapterStack<T> 구현
    {
        // 스택에 저장된 항목을 보관하는 리스트 container
        private List<T> container;

        public AdapterStack()
        {
            container = new List<T>();
        }

        /// <summary>
        /// 주어진 항목을 스택(container)에 추가하는 함수
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            container.Add(item);
        }
        /// <summary>
        /// 스택에서 가장 최근에 추가된 항목을 제거하고 반환하는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public T Pop()
        {
            return container[container.Count - 1];
        }
    }
}
