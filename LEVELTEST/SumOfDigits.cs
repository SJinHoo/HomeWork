using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEVELtest
{
    internal class SumOfDigits
    {
        static void Main()
        {
            int eachSum = 0;    //합산 결과 변수 초기화

            string userInput = Console.ReadLine(); // 입력받은 값을 문자열 변수 userInput에 저장
            userInput.ToCharArray();        //문자열을 char 배열로 변환
            foreach (int eachNumber in userInput)       // 문자열을 순회하며 각 자리 숫자에 대해 반복 eachNumber변수는 ASCII코드 값을 가짐
            {
                eachSum += eachNumber - 48;         //eachNumber의 ASCII 코드 값에서 48을 뺀 값을 eachSum 변수에 더해줌
            }
            // ASCII코드의 48은 숫자 0
            Console.WriteLine(eachSum);
            Console.ReadLine();
        }
    }
}
