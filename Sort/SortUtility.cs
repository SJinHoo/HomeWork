using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class SortUtility
    {
        // 배열을 받아서 정렬한 후 반환
        public static T[] Sort<T>(T[] arr) where T : IComparable<T>
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    //j의 첫 번째 원소가 j+1번째 원소보다 크면 두 원소를 교환
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            // 정렬한 배열을 반환
            return arr;
        }

        // 리스트를 받아서 정렬한 후 반환하는 함수
        public static List<T> Sort<T>(List<T> list) where T : IComparable<T>
        {
            //리스트를 배열로 변환
            T[] arr = list.ToArray();
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    //j번째 원소가 j+1번째 원소보다 크면 두 원소를 교환
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            // 정렬된 배열을 리스트로 변환
            return new List<T>(arr);
        }

        public static double Average(int[] arr)
        {
            double sum = 0;

            if (arr.Length == 0)
            {
                throw new ArgumentException();  // 배열이 없는경우 예외처리
            }

            
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum / arr.Length;
        }

        public static double Average(List<int> list)
        {
            int[] arr = list.ToArray();
            return Average(arr);
        }
    }
}
