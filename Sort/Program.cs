namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 };
            List<int> list = new List<int>(arr);

            // 배열을 정렬한다.
            int[] sortedArr = SortUtility.Sort(arr);
            foreach (int item in sortedArr)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.WriteLine("정렬된 배열의 평균값 : {0}",SortUtility.Average(sortedArr));

            // 리스트를 정렬한다.
            List<int> sortedList = SortUtility.Sort(list);
            foreach (int item in sortedList)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.WriteLine("정렬된 배열의 평균값 : {0}", SortUtility.Average(sortedList));
        }
    }
}