using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEVELtest
{
    internal class StringCount
    {
        static void Main()
        {
            string str = Console.ReadLine();
            string[] words = str.Split(' '); // 문자열 배열을 ' ' 를 기준으로 분리하여 words에 저장
            Console.WriteLine(words.Length); // words 배열의 길이를 출력
        }
    }
}
