using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueuePractice
{
    internal class Queue<T> //제네릭 FIFO 구조 클래스 Queue<T> 
    {
        // 수용할 
        private const int DefaultCapacity = 10;     

        private T[] array;      // queue의 아이템을 보관하기위한 배열
        private int head;       // 큐에서 가장 오래된 아이템을 가리키는 head
        private int tail;       // 큐에서 가장 최근에 추가된 아이템을 가리키는 tail

        private Queue()
        {
            array = new T[DefaultCapacity + 1]; 
            head = 0;
            tail = 0;
        }

        public int Count    // 아이템 갯수
        {
            get
            {
                if (head <= tail)       // tail 보다 head의 값이 작다면 큐에 있는 배열 아이템의 갯수는 tail - head
                    return tail - head;
                else
                    return (tail - head) + array.Length;  // head가 tail 보다 클 경우 (tail - head) + array.Length
                                                          // 배열의 길이를 더하는 이유는 tail이 head보다 작아져서 음수 값이 되는 경우를 보정 하기 위함
            }
        }
        public void Clear() // 큐를 초기화
        {
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }

        /// <summary>
        /// 큐에 아이템을 추가하는 함수
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (IsFull())       // 만약 아이템의 갯수가 꽉 찬 상태라면
            {
                Grow();         // 아래 설정해둔 grow 함수로 배열의 크기를 늘려준다
            }

            array[tail] = item; // tail 인덱스가 가리키는 방향에 item을 추가하고
            MoveNext(ref tail); // tail 을 MoveNext를 이용하여 다음으로 옮긴다   
        }
        /// <summary>
        /// 큐를 제거하고 반환하는 함수
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();      // 큐가 비어있을 경우 예외처리

            T result = array[head];                         // head가 가리키는 방향을 T result 변수에 저장하고
            MoveNext(ref head);                             // MoveNext의 함수를 호출해 head의 위치를 옮긴 후
            return result;                                  // result값을 반환한다.
        }

        public T Peek()
        {
            if (IsEmpty())                                  // 큐가 비어있을 경우 예외처리
                throw new InvalidOperationException();
            return array[head];                             //
        }

        private void MoveNext(ref int index)
        {
            index = (index == array.Length - 1) ? 0 : index + 1; // 인덱스가 배열의 끝에 도달하면 다시 처음으로 돌아가고 그렇지않으면 +1
        }
        /// <summary>
        /// 큐가 비어있는지 확인하는 함수
        /// </summary>
        /// <returns></returns>
        private bool IsEmpty()      // head와 tail의 값이 같은 경우 비어있음
        {
            return head == tail;
        }
        /// <summary>
        /// 큐가 가득 차있는지 확인하는 함수
        /// </summary>
        /// <returns></returns>
        private bool IsFull()
        {
            if (head > tail)
                return head == tail + 1;    // 큐가 가득 차려면 head가 tail보다 1이 더 많아야 하기 때문에 head = tail +1    
            else
                return head == 0 && tail == array.Length - 1; // 큐가 가득차려면 head는 0이어야하고 tail 은 배열의 길이보다 1이 작아야한다.
        }

        public void Grow()
        {
            int newCapacity = array.Length * 2; // 배열의 크기를 2배로 늘리는 변수 생성
            T[] newArray = new T[newCapacity];  // 인스턴스 생성
            if (head < tail)
            {
                Array.Copy(array, newArray, Count); // 만약 head의 값이 tail 보다 작은경우 배열 복사함수를 이용해 원래 배열에서 Count 만큼의 요소들을 새로운 배열로 복사
            }
            else
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);  // 원래 배열의 head 부분부터 array.Length - head 부분 즉, 배열의 끝 마지막 요소 까지 복사
                Array.Copy(array, 0, newArray, array.Length - head, tail);  // 원래 배열의 시작점 부터 tail까지 복사
                head = 0;
                tail = Count;
            }
            array = newArray; // array 변수에 newArray를 할당하고 늘어난 배열을 사용함으로써 배열의 용량을 2배 늘림
        }
    }
}
