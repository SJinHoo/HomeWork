namespace DictionaryPractice
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<string,int> hashTable = new Dictionary<string,int>();

            hashTable.Add("꼬부기", 5);
            hashTable.Add("피카츄", 8);
            hashTable.Add("야도란", 10);
            hashTable.Add("피죤투", 15);
            hashTable.Add("또가스", 25);
            hashTable.Add("냐옹이", 35);
            hashTable.Add("롱스톤", 45);

            hashTable.Remove("또가스");

            Console.WriteLine(hashTable["야도란"]);

            


        }
    }
}