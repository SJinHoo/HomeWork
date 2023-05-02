namespace IteratorPractice
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IteratorPractice.List<int> list = new IteratorPractice.List<int>();
            for (int i = 0; i < 5; i++) list.Add(i);

            foreach (int i in list) Console.WriteLine(i);

           

            IteratorPractice.LinkedList<int> linkedList = new IteratorPractice.LinkedList<int>();

            for (int i = 0; i < 5; i++) linkedList.AddLast(i);

            foreach (int i in linkedList) Console.WriteLine(i);

           

        }

       
    }
}