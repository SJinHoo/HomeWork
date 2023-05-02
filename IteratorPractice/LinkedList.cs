using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPractice
{
   
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;            
        internal LinkedListNode<T> prev;        
        internal LinkedListNode<T> next;        
        private T item;                         

        

        
        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        
        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        
        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }
        
        public LinkedList<T> List { get { return list; } }
       
        public LinkedListNode<T> Prev { get { return prev; } }
       
        public LinkedListNode<T> Next { get { return next; } }
        
        public T Item { get { return item; } set { item = value; } }
    }

    
    public class LinkedList<T> : IEnumerable<T> // IEnumerable 메서드 인터페이스 선언
    {
        private LinkedListNode<T> head;     
        private LinkedListNode<T> tail;     
        private int count;                  

        
        public LinkedList()     
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        
        public LinkedListNode<T> First { get { return head; } }
        
        public LinkedListNode<T> Last { get { return tail; } }
        
        public int Count { get { return count; } }

        
        public LinkedListNode<T> AddFirst(T value)
        {

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);


            if (head == null)    
            {
                head = newNode;     
                tail = newNode;     
            }
            else                
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode; ;   
            }
            
            count++;
            return newNode;
        }

        
        public LinkedListNode<T> AddLast(T value)
        {
            // AddFrist 와 유사하지만 taill에 새로운 노드를 연결
            // 이전의 tail은 새로운 노드를 가리킴
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            // 반환값은 AddFrist와 동일하게 추가된 새로운 노드를 반환
            count++;
            return newNode;
        }
     
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (node.list == null)       
                throw new ArgumentNullException(nameof(node));  
            if (node.list != this)     
                throw new InvalidOperationException();    
            
            if (head == node)
            {
                node.prev = newNode;
                newNode.next = node;
                head = newNode;

            }
            else
            {
                newNode.prev = node.prev;
                node.prev = newNode;
                newNode.next = node;
                newNode.prev.next = newNode;
            }
            count++;
            return newNode;

        }
        
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            
            if (node.list == null)
                throw new ArgumentNullException(nameof(node));
            if (node.list != this)
                throw new InvalidOperationException();

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            
            if (tail == node)
            {
                node.next = newNode;
                newNode.prev = node;
                tail = newNode;
            }
            else
            {
                newNode.next = node.next;
                node.next = newNode;
                newNode.prev = node;
                newNode.next.prev = newNode;
            }
            count++;
            return newNode;
        }


        public void Remove(LinkedListNode<T> node)
        {
            
            if (node == null)
                throw new ArgumentNullException();  
            if (node.list != this)
                throw new InvalidOperationException();      

            
            if (head == node)
                head = node.next;   
            if (tail == node)
                tail = node.prev;  

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;    

            
            count--;

    
        }

        public void Remove(T value)
        {

            if (head == null)       
                throw new ArgumentNullException();    

           
            LinkedListNode<T> deledtenode = Find(value);

            
            if (deledtenode != null)
            {
                
                if (head == deledtenode)
                {
                    head = deledtenode.next;
                    deledtenode.next.prev = null;
                    deledtenode.next = null;
                }
               
                else if (tail == deledtenode)
                {
                    tail = deledtenode.prev;
                    deledtenode.prev.next = null;
                    deledtenode.prev = null;
                }
                
                else
                {
                    deledtenode.prev.next = null;
                    deledtenode.prev = null;
                    deledtenode.next.prev = null;
                    deledtenode.next = null;
                }
            }
            count--;
        }
        public void RemoveNode(LinkedListNode<T> node)
        {
            if (node == null) 
                throw new ArgumentNullException(); 
            if (node.list != this)  
                throw new InvalidOperationException(); 

           
            if (head == node)
                head = node.next;

            
            if (tail == node)
                tail = node.prev;

           
            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            count--;

        }


        public LinkedListNode<T> Find(T value)
        {
           
            LinkedListNode<T> node = head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (value != null)
            {
                while (node != null)
                {
                    
                    if (comparer.Equals(node.Item, value)) 
                        return node;
                    else
                        node = node.next;
                }
            }
           
            else
            {
                while (node != null)
                {
                    if (node.Item == null)
                        return node;
                    else
                        node = node.next;
                }
            }
            
            return null;
        }
        
        
        public IEnumerator<T> GetEnumerator()       // IEnumerable은 IEnumerator를 반환하는 GetEnumerator()를 가지고 있음
        {                                           // IEnumerator는 컬렉션 데이터를 반복적으로 열거하는데에 사용되는 인터페이스
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T> // Enumerator 구조체 정의, 연결된 리스트의 요소를 열거하기 위한 인터페이스 IEnumerator 인터페이스 구현
        {
            private LinkedList<T> linkedlist;
            private LinkedListNode<T> node;
            private T current;

            public Enumerator(LinkedList<T> linkedlist)
            {
                this.linkedlist = linkedlist;
                this.node = linkedlist.head;
                this.current = default(T);

            }
            public T Current {get { return current;}}

            object IEnumerator.Current      // Currnet의 요소를 반환하기위해 오브젝트 형식으로 형변환
            {
                get { return current; }
            }

            public void Dispose()
            {
                
            }

            // 노드가 null인 경우 false 반환
            public bool MoveNext()
            {
                if(node != null)
                {
                    current = node.Item; // 
                    node = node.next;
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
            }

            public void Reset()     //head 노드로 이동하고 current 필드를 초기화
            {
                this.node = linkedlist.head;
                current = default(T);
            }
        }
    }
}
