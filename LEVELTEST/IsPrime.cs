using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LEVELtest
{
    internal class IsPrime
    {
        static void Main()
        {
            int num = 0;    // num 변수 선언
            bool thisIsSosu = true;
            Console.WriteLine("정수를 입력해주세요.");
            num = int.Parse(Console.ReadLine());    // int.Parse를 통해 num 변수에 입력값 할당

            if (num == 2)   // 2는 소수이기 때문에 
            {
                thisIsSosu = true;  // 변수를 true 값으로 설정
            }
            else if (num % 2 == 0)
            {
                thisIsSosu = false; // 그 외에 2로 나누어 떨어지는 경우 즉, 짝수인 경우에는 소수가 아니므로 false 로 변수 설정
            }
            else
            {
                for(int i = 3; i < num; i=i++) // 3부터 입력받은 정수를 num 까지 반복
                {
                    if(num % i == 0) 
                    {
                        thisIsSosu = false;
                        break;      // 약수를 발견하면 false 로 변수 설정 후 반복문 중단
                    }
                    else
                    {
                        thisIsSosu = true;  // 발견하지 못하면 변수를 true 로 설정
                    }
                }
            }
            if(thisIsSosu) 
            {
                Console.WriteLine("소수입니다."); 
            } 
            else 
            {
                Console.WriteLine("소수가 아닙니다."); 
            }
            // 변수 값에 따라서 입력받은 정수가 소수인지 판별하는 조건문설정 결과 출력 메세지 작성 
        }
    }
}
