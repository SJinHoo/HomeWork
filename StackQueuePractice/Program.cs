namespace StackQueuePractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bracket bracket = new Bracket();

            Console.WriteLine(bracket.BracketChecker("()()"));
            Console.WriteLine(bracket.BracketChecker("(())"));
            Console.WriteLine(bracket.BracketChecker("())"));
            Console.WriteLine(bracket.BracketChecker("{){)"));
            Console.WriteLine(bracket.BracketChecker(")()()("));
            Console.WriteLine(bracket.BracketChecker("{}{}{}"));
            Console.WriteLine(bracket.BracketChecker("}{}{}{"));
        }
    }
}