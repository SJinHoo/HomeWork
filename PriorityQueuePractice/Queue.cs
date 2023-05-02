using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueuePractice
{
    public class PriorityQueue<TElement>      // 우선순위 큐 클래스 생성
    {
        private struct Node     // Node 구조체 생성
        {
            public TElement element;
            public int priority;
        }

        private List<Node> nodes;
        
        public PriorityQueue()
        {
            this.nodes = new List<Node>();
        }

        public int Count { get { return this.nodes.Count; } }       // 노드 번호 프로퍼티

        /// <summary>
        /// 힙에 새로운 노드를 삽입하는 경우의 함수
        /// </summary>
        /// <param name="element"></param>
        /// <param name="priority"></param>
        public void Enqueue(TElement element, int priority)
        {
            Node newNode = new Node() { element = element, priority = priority };       // 노드 구조체 인스턴스 생성 후 구조체 정의 값 불러옴


            this.nodes.Add(newNode);                // 새로운 노드 추가
            int newNodeIndex = this.nodes.Count - 1;        // 새로운 노드는 배열의 끝부분에 추가

            while (newNodeIndex > 0)        
            {
                // 부모의 노드 확인
                int parentIndex = GetParentIndex(newNodeIndex);    
                Node parentNode = nodes[parentIndex];           // Node 구조체의 인스턴스로 ParentNode 선언,parentIndex 인스턴스값을 node 배열위치로 저장

                // 자식의 노드가 부모의 노드보다 우선순위가 높다면
                if(newNode.priority < parentNode.priority)      
                {
                    nodes[newNodeIndex] = parentNode;       // 새로운 노드 인덱스에 부모의 노드 대입
                    nodes[parentIndex] = newNode;           // 부모 인덱스에 새로운 노드 대입
                    newNodeIndex = parentIndex;             // 결과적으로 새로운 노드인덱스와 부모인덱스 교체
                }
                else
                {
                    break;                                  // 더 이상 이동할 필요가 없는 경우 스탑
                }
            }
        }
        /// <summary>
        /// 힙의 최소값(가장 작은 데이터)을 삭제하는 함수
        /// </summary>
        /// <returns></returns>
        public TElement Dequeue()
        {
            Node rootNode = nodes[0];       // 노드 구조체 rootNode 인스턴스 생성 배열의 최소값 대입

            Node lastNode = nodes[nodes.Count - 1];     // lastNode 구조체 인스턴스 생성 배열의 마지막 값 대입
            nodes[0] = lastNode;                        // 배열의 마지막 값을 최소값의 위치로 이동
            nodes.RemoveAt(nodes.Count - 1);            // 마지막 값자리의 주소를 삭제

            int index = 0;                              // index 인스턴스 생성

            // 인덱스의 값이 노드의 번호 보다 작은 경우 while 반복문 실행
            while (index < nodes.Count)
            {
                // 불러온 함수값에 왼쪽과 오른쪽 자식 인덱스값 저장 새로운 int 변수 생성
                int leftChildIndex = GetLeftChildIndex(index);      
                int rightChildIndex = GetRightChildIndex(index);

                // 자식이 둘 다 있는 경우
                if (rightChildIndex < nodes.Count)
                {
                    // 왼쪽 자식과 오른쪽 자식을 비교하여 더 우선순위가 높은 자식을 선정
                    int lessChildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority ? leftChildIndex : rightChildIndex;

                    // 이중 조건문을 작성하여
                    // 더 우선순위가 높은 자식과 부모 노드를 비교하여
                    // 부모가 우선순위가 더 낮은 경우 바꾸기
                    if (nodes[lessChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[lessChildIndex];
                        nodes[lessChildIndex] = lastNode;
                        index = lessChildIndex;

                    }
                    else
                    {
                        break;      // 비교할 필요가 없는경우 스탑
                    }
                }

                // 자식이 하나만 있는 경우 == 왼쪽 자식만 있는 경우
                else if (leftChildIndex < nodes.Count)
                {
                    if (nodes[leftChildIndex].priority < nodes[index].priority) // 왼쪽자식과 비교하여
                    {
                        // 부모의 우선순위가 더 낮은 경우 바꾸기
                        nodes[index] = nodes[leftChildIndex];       
                        nodes[leftChildIndex] = lastNode;
                        index = leftChildIndex;
                        
                    }
                    else
                    {
                        break;
                    }
                }
                // 비교할 자식이 없는 경우
                else
                {
                    break;      // 스탑
                }
            }

            return rootNode.element;

        }
        public TElement Peek()
        {
            return nodes[0].element;
        }

        /// <summary>
        /// 부모 노드의 인덱스를 찾기위한 함수
        /// </summary>
        /// <param name="childIndex"></param>
        /// <returns></returns>
        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;        // 자식 인덱스값의 -1 하고 /2를 해준다
        }
        /// <summary>
        /// 왼쪽에 저장된 자식 노드의 인덱스를 찾기 위한 함수
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;     // 부모의 인덱스값에 *2 +1을 해준다
        }
        /// <summary>
        /// 오른쪽에 저장된 자식 노드의 인덱스를 찾기 위한 함수
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;     // 부모의 인덱스 값에 *2 + 2를 해준다.
        }
    }
}
