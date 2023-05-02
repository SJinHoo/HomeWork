using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinarySearchTreePractice
{
    internal class BinarySearchTree<T> where T : IComparable<T>     // 이진탐색트리 클래스 생성 비교가능한 데이터로 지정
    {
        private Node root;  //

        public BinarySearchTree()
        {
            this.root = null;
        }

        /// <summary>
        /// 이진탐색트리에서의 노드가 추가되는 함수
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);    // 새 노드 인스턴스를 생성

            Node current = root;
            if (root == null)   // root가 null값인 경우 즉, 처음 데이터를 입력받은경우
            {
                root = newNode; // 새로운노드는 root로
                return;
            }
            // 현재 값이 null 이 아닌 경우 즉, 기존의 root 값이 있는 경우
            while (current != null)     //while 반복문 실행
            {
                // 비교해서 값이 더 작은 경우 왼쪽으로
                if (item.CompareTo(current.item) < 0)
                {
                    // 비교 노드의 왼쪽 노드에 자식노드가 있는 경우
                    if (current.left != null)
                    {
                        // 왼쪽 자식노드와 비교하기위해 current의 왼쪽 자식으로 지정
                        current = current.left;
                    }
                    // 비교할 노드에 왼쪽 자식이 없는 경우
                    else
                    {
                        // 그 자리에 노드가 추가가 될 자리임
                        current.left = newNode;     // 새로운 노드값을 왼쪽 현재 노드에 넣어줌
                        newNode.parent = current;   // 새로운 부모노드를 현재 값으로 설정
                        return;

                    }
                }
                // 비교해서 값이 더 큰 경우 오른쪽으로
                if (item.CompareTo(current.item) > 0)
                {
                    // 비교 노드의 오른쪽 노드에 자식노드가 있는 경우
                    if (current.right != null)
                    {
                        // 오른쪽 자식노드와 비교하기위해 current의 오른쪽 자식으로 지정
                        current = current.right;
                    }
                    // 비교한 노드에 왼쪽 자식이 없는 경우
                    else
                    {
                        // 그 자리에 노드가 추가가 될 자리임
                        current.right = newNode;    // 새로운 노드값을 오른쪽 현재 노드에 넣어줌
                        newNode.parent = current;   // 새로운 부모도드를 현재 값으로 설정
                        return;
                    }
                }
                // 동일한 데이터가 들어온 경우
                else
                {
                    return;     // 아무고토 안함
                }
            }
        }
        /// <summary>
        /// 노드를 삭제하는 함수
        /// </summary>
        /// <param name="item"></param>
        public bool Remove(T item)
        {
            // Node 클래스 findnode 인스턴스 생성 후 FindNode에 item 매개변수 가 포함된 함수 저장(복사)
            Node findNode = FindNode(item);
            // root가 null 값이면 fasle
            if (root == null)
                return false;
            // findNode 역시 null 값인 경우 false
            if (findNode == null)
            {
                return false;
            }
            // 그 외의 경우 EraseNode 함수에 findNode 인스턴스값을 넣어 true 출력 즉, 삭제해준다
            else
            {
                EraseNode(findNode);
                return true;
            }

        }
        /// <summary>
        /// 값을 찾는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        public bool TryGetValue(T item, out T outValue)
        {
            Node findNode = FindNode(item);     // 노드를 찾는 함수 FindNode를 불러와 매개변수 item을 넣어주고 새로운 Node 인스턴스 생성
            if (root == null)                   // 루트가 null 값이라면
            {
                outValue = default(T);          // default 값을 outValue로
                return false;                   // false 리턴
            }


            if (findNode == null)               // 노드를 찾았음에도 null값인 경우에도
            {
                outValue = default(T);
                return false;                   // false
            }
            // 그 외의 경우
            else
            {
                outValue = findNode.item;       // 찾은 노드를 outValue에 대입
                return true;                    // true
            }
        }
        /// <summary>
        /// 노드를 찾는 함수
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Node FindNode(T item)
        {
            if (root == null)
                return null;
            Node current = root;
            while (current != null) // root에 값이 있는경우 while 반복문 실행
            {
                // 현재값이 찾고자 하는 노드값보다 작은 경우
                if (item.CompareTo(current.item) < 0)
                {
                    // 왼쪽 자식 노드 부터 다시 찾기
                    current = current.left;
                }
                // 현재값이 찾고자 하는 노드값보다 큰 경우
                else if (item.CompareTo(current.item) > 0)
                {
                    // 오른쪽 자식 노드 부터 다시 찾기
                    current = current.right;
                }
                // 현재값이 찾고자하는 값와 같은 경우~
                else
                {
                    // 찾음
                    return current; // 현재값을 리턴
                }
            }
            return null;
        }

        private void EraseNode(Node node)
        {
            // 1. 자식 노드가 없는 노드의 경우
            if (node.HasNoChild)
            {
                if (node.IsLeftChild) { node.parent.left = null; }
                else if (node.IsRightChild) { node.parent.right = null; }
                else // if (node.IsRootNode)
                { root = null; }
            }
            // 2. 자식 노드가 1개만 있는 노드의 경우
            else if (node.HasLeftChild || node.HasRightChild) // 왼쪽 자식노드 혹은 오른쪽 자식노드가 있는 경우
            {
                Node parent = node.parent;      // Node 클래스 parent 인스턴스 생성 후 부모노드 대입
                Node child = node.HasLeftChild ? node.left : node.right;        // Node 클래스 child 인스턴스 생성 후
                                                                                // 왼쪽 자식노드를 가지고있다면 왼쪽노드 아니면 오른쪽 노드 출력
                if (node.IsLeftChild)       // 왼쪽에 자식 노드만 있는 경우
                {
                    parent.left = child;
                    child.parent = parent;
                }
                if (node.IsRightChild)      // 오른쪽에 자식 노드만 있는 경우
                {
                    parent.right = child;       // 부모노드의 오른쪽 값에 child를 넣고 삼항연산자를 돌린 값을 넣어주고 (right)
                    child.parent = parent;      // child(right).parent 에 parent 인스턴스 대입
                }
                else // if (node.HasBothChild)  만약 자식이 둘다 있는경우
                {
                    root = child;       // 루트에 child 인스턴스를 넣어주되
                    child.parent = null;    // 자식이 둘다 있는 경우기 때문에 null 값을 넣어준다

                }
            }
            // 3. 자식 노드가 두 개 있는 경우
            // 왼쪽 자식 중 가장 큰 값과 데이터 교환한 후, 그 노드를 지워주는 방식으로 대체
            // 삭제하려는 노드를 대체할 노드를 찾아야함
            else
            {
                Node replaceNode = node.left;       // Node 인스턴스 replaceNode 생성 node.left 대입
                // 노드의 왼쪽 하위트리에서 가장 큰 값을 찾을 때 까지 while문을 반복
                while (replaceNode.right != null)   // 
                {
                    replaceNode = replaceNode.right;
                }
                node.item = replaceNode.item;   // 대체 노드 값을 삭제하려는 노드로 정해주고
                EraseNode(replaceNode); // 대체 노드를 삭제시켜준다
            }
        }



        public class Node       // 노드 클래스 생성
        {
            internal T item;
            internal Node parent;
            internal Node left;
            internal Node right;

            public Node(T item, BinarySearchTree<T>.Node parent, BinarySearchTree<T>.Node left, BinarySearchTree<T>.Node right)     // Node 클래스의 생성자 만들어줌 
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public bool IsRootNode { get { return parent == null; } }                       // 루트 노드의 프로퍼티
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }       // 왼쪽 자식노드의 프로퍼티
            public bool IsRightChild { get { return parent != null && parent.right == this; } }     // 오른쪽 자식 노드의 프로퍼티

            public bool HasNoChild { get { return left == null && right == null; } }        // 자식노드가 없는 경우의 논리값 프로퍼티
            public bool HasLeftChild { get { return left != null && right == null; } }      // 왼쪽에 자식노드가 있는 경우의 논리값 프로퍼티
            public bool HasRightChild { get { return left == null && right != null; } }     // 오른쪽에 자식노드가 있는 경우의 논리값 프로퍼티
            public bool HasBothChild { get { return left != null && right != null; } }      // 자식노드가 둘다 있는 경우의 논리값 프로퍼티

        }
    }
}
