using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListpractice
{
    //연결 리스트의 노드 클래스 생성
    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;            // 노드에 속한 연결리스트 객체를 가리키는 변수
        internal LinkedListNode<T> prev;        // 해당 노드의 이전 노드를 가리키는 변수
        internal LinkedListNode<T> next;        // 해당 노드의 다음 노드를 가리키는 변수
        private T item;                         // 이 노드에 저장된 데이터를 가리키는 변수

        // 연결리스트 노드의 생성자

        // 데이터 값을 받아서 노드를 생성, list,prev,next 노드들은 null로 초기화
        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        // 연결리스트 객체와 데이터 값을 받아서 노드를 생성 prev,next 노드는 null 로 초기화
        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        // 연결리스트 객체,prev,next,데이터 값을 받아서 노드 새성
        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }
        // 해당 노드가 속한 연결리스트 객체를 모두 가져오는 프로퍼티
        public LinkedList<T> List { get { return list; } }
        // 해당 노드의 이전 노드를 가져오는 프로퍼티
        public LinkedListNode<T> Prev { get { return prev; } }
        // 해당 노드의 다음 노드를 가져오는 프로퍼티
        public LinkedListNode<T> Next { get { return next; } }
        // 해당 노드에 저장된 데이터 값을 가져오거나 설정하는 프로퍼티
        public T Item { get { return item; } set { item = value; } }
    }

    // 연결리스트 클래스 생성
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;     // 연결리스트의 첫 번째 노드를 가르키는 변수
        private LinkedListNode<T> tail;     // 연결리스트의 마지막 노드를 가리키는 변수
        private int count;                  // 연결리스트의 노드 갯수를 저장하는 변수

        // LikedList 클래스의 생성자
        public LinkedList()     // 빈 연결리스트의 객체를 생성 head,tail 은 null로 초기화, count는 0으로 초기화
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        // 연결리스트의 첫 번째 노드를 가져오는 프로퍼티
        public LinkedListNode<T> First { get { return head; } }
        // 연결리스트의 마지막 노드를 가져오는 프로퍼티
        public LinkedListNode<T> Last { get { return tail; } }
        // 연결리스트의 노드 갯수를 가져오는 프로퍼티
        public int Count { get { return count; } }

        /// <summary>
        /// 연결리스트의 첫 번째 위치에 노드를 추가하는 함수
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LinkedListNode<T> AddFrist(T value)
        {

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);


            if (head == null)    // head가 null이 아라면 즉, 아무 것도 없는 리스트 라면
            {
                head = newNode;     // head에 새로만든 노드를 대입
                tail = newNode;     // tail에 새로만든 노드를 대입
            }
            else                // 노드가 있는 리스트 일 경우
            {
                newNode.next = head;// 새로만든 노드의 다음 노드로 현재 헤드 노드를 저장
                head.prev = newNode;// 현재 헤드 노드의 앞에 노드로 새로 만든 노드를 저장
                head = newNode; ;   // 헤드를 새로만든 노드로 저장
            }
            // count를 1 증가시키고 새로운 노드를 반환
            count++;
            
            
        }

        /// <summary>
        /// 연결리스트의 마지막 위치에 노드를 추가하는 함수
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
            
        }
        /// <summary>
        /// 연결리스트 앞 위치에 노드를 추가하는 함수
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            if (node.list == null)       // 주어진 노드가 null 인경우, 즉 아무것도 없는 리스트인경우
                throw new ArgumentNullException(nameof(node));  // 예외 처리
            if (node.list != this)      // node.list 가 추가하려는 리스트와 다를경우
                throw new InvalidOperationException();     // 또한 예외처리

            // 주어진 노드가 head일때, 주어진 노드가 head가 아닐때
            if(head == node)
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
        }
        /// <summary>
        /// 연결리스트 뒤 위치에 노드를 추가하는 함수
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            // 아무것도 없는 리스트일때, 주어진 노드와 추가하려는 리스트가 다를때
            if (node.list == null)
                throw new ArgumentNullException(nameof(node));
            if (node.list != this)
                throw new InvalidOperationException();

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);

            // 주어진 노드가 tail일때, 주어진 노드가 tail이 아닐때
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
        }


        /// <summary>
        /// 연결리스트에서 해당 노드를 삭제하는 함수
        /// </summary>
        /// <param name="node"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Remove(LinkedListNode<T> node)
        {
            // 매개변수 node 의 값이 null 이거나 연결리스트에 포함되지않는경우
            if (node == null)
                throw new ArgumentNullException();  // 예외 처리
            if (node.list != this)
                throw new InvalidOperationException();      // 추가하는 리스트와 다를 경우 역시 예외처리

            // head와 tail 노드가 삭제할 노드를 가르키는 경우
            if (head == node)
                head = node.next;   // 삭제할 노드가 head 노드인 경우 삭제할 노드의 다음노드로 변경
            if (tail == node)
                tail = node.prev;   // 삭제할 노드가 tail 노드인 경우 삭제할 노드의 이전노드로 변경

            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;     // 삭제할 노드의 이전노드와 다음 노드를 연결해줌

            // 즉, 삭제할 노드의 이전노드의 다음노드를 삭제할 노드의 다음 노드로 바꿔주고, 삭제할 노드의 다음노드의 이전노드를 삭제할 노드의 이전 노드로 바꿔줌

            count--;

            // 그 후 연결리스트의 노드갯수를 하나 줄임
        }

        public void Remove(T value)
        {
            
            if (head == null)       // 리스트가 비어있을 경우
                throw new ArgumentNullException();      // 예외처리

            // 삭제할 노드를 찾고
            LinkedListNode<T> deledtenode = Find(value);

            // 삭제할 노드가 존재하는 경우
            if (deledtenode != null)
            {
                // 삭제할 노드가 head 인경우
                if (head == deledtenode)
                {
                    head = deledtenode.next;
                    deledtenode.next.prev = null;
                    deledtenode.next = null;
                }
                // 삭제할 노드가 tail인 경우
                else if (tail == deledtenode)
                {
                    tail = deledtenode.prev;
                    deledtenode.prev.next = null;
                    deledtenode.prev = null;
                }
                // 삭제할 노드가 head나 tail이 아닌 경우
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
            if (node == null) //node가 null인 경우
                throw new ArgumentNullException();  // 예외처리
            if (node.list != this)  // 리스트에 속하지 않을 경우 역시
                throw new InvalidOperationException(); // 예외처리
            
            // 삭제할 노드가 head 인 경우
            if (head == node)   
                head = node.next;

            // 삭제할 노드가 tail 인 경우
            if (tail == node)
                tail = node.prev;

            // 노드 삭제
            if (node.prev != null)
                node.prev.next = node.next;
            if (node.next != null)
                node.next.prev = node.prev;

            count--;

        }


        public LinkedListNode<T> Find(T value) 
        {
            // 리스트의 head 부터 value 까지 일치하는 노드를 탐색
            LinkedListNode<T> node = head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            if (value != null)
            {
                while (node != null)
                {
                    // value와 일치하는 노드를 찾은 경우 해당 노드를 반환
                    if (comparer.Equals(node.Item, value))
                        return node;
                    else
                        node = node.next;
                }
            }
            // value가 null인 경우 null인 노드를 찾아서 반환
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
            // 리스트에서 value와 일치하는 노드를 찾지 못한 경우 null 을 반환
            return null;
        }


            
            
    }
}


    
