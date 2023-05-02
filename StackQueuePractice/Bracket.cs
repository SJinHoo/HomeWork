using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueuePractice
{
    public class Bracket
    {
        public bool BracketChecker(string s)
        {
            Stack<string> stack = new Stack<string>();

            foreach(char word in s)
            {
                if ( word ==  '('|| word == '{')
                {
                    stack.Push(word.ToString());
                    continue;
                }

                if (stack.Count == 0)
                {
                    return false;
                }

                if (word == ')' && stack.Peek() == "(")
                {
                    stack.Pop();
                }
                else if (word == '}' && stack.Peek() == "{")
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }

            return stack.Count == 0;

            
        }

        
        
    }
}
