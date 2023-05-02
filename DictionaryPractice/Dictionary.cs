using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPractice
{
    // 어떤 값이 들어와도 인덱스를 추출할 수 있도록 일반화로 데이터 지정
    // Key 값은 둘이 똑같은지의 여부를 판단 할 수 있도록 제약 여부 확인 IEquatable
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey> 
    {
        private const int DefaultCapacity = 2000;       
        private struct Entry
        {
            public enum State { None, Using, Deleted }  // State 구조체 선언

            public State state;
            public int hashCode;
            public TKey Key;
            public TValue Value;
        }

        private Entry[] table;      // Entry 배열 table

        // Dictionary 클래스의 생성자
        public Dictionary() { table = new Entry[DefaultCapacity]; } // Entry 구조체 배열의  table을 생성하고 DefaultCapacity 값을 초기화
                                                                    // Dictionary 클래스는 table의 고정 크기의 배열을 사용함

        public TValue this[TKey key]
        {
            get
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);
                // 2. 해당 key를 가진 값이 있는지 검사하고, 있다면 값을 반환
                while (table[index].state != Entry.State.None)
                {
                    if (table[index].state == Entry.State.Using && key.Equals(table[index].Key)) // 만약 key를 가진 값이 사용중이거나 key갚과 동일할 경우
                    {
                        return table[index].Value; // 값을 반환
                    }
                    index = ++index % table.Length;
                }
                // 3. 해당 key를 가진 값이 없다면 KeyNotFoundException 예외를 던짐
                throw new KeyNotFoundException();
            }
            set
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);
                // 2. 해당 key를 가진 값이 있는지 검사하고, 있다면 값을 업데이트
                while (table[index].state != Entry.State.None)
                {
                    if (table[index].state == Entry.State.Using && key.Equals(table[index].Key))
                    {
                        table[index].Value = value;
                        return;
                    }
                    // 다음으로 이동
                    index = ++index % table.Length;
                }
                // 3. 해당 key를 가진 값이 없다면 Add 함수를 호출하여 값을 추가해준다
                Add(key, value);
            }
        }
        /// <summary>
        /// 테이블에 index를 추가하는 함수
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(TKey key ,TValue value)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);     // key의 해시코드를 table 길이로 나눈값의 절대값을 index로 해싱
            // 2. 사용중이 아닌 인덱스까지 다음으로 이동
            while (table[index].state == Entry.State.Using)
            {
                // 똑같은 키가 입력된 경우
                if (key.Equals(table[index].Key))
                {
                    throw new ArgumentException();      // 예외 (오류) 처리
                }
                // 다음으로 이동
                index = ++index % table.Length;
            }
            // 3. 사용중이 아닌 index를 발견한 경우 그 위치에 값을 저장
            table[index].hashCode = key.GetHashCode();
            table[index].Key = key;
            table[index].Value = value;
            table[index].state = Entry.State.Using;
        }
        /// <summary>
        /// 테이블에 있는 index를 삭제하는 함수
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Remove(TKey key)
        {
            //1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);


            while (true)
            {
                // index 가 사용중이 아니라면 중단
                if (table[index].state == Entry.State.None) 
                {
                    break;
                }
                // 동일한 키값을 찾았을때 지운상태로 표시
                if (key.Equals(table[index].Key))
                {
                    table[index].state = Entry.State.Deleted;
                    return;
                }

                // 다음으로 이동
                index = ++index % table.Length;
            }
            throw new IndexOutOfRangeException();   // 인덱스가 범위를 벗어난 경우 예외처리
        }
        public void Clear()
        {
            table = new Entry[DefaultCapacity];
        }


    }

    
}
