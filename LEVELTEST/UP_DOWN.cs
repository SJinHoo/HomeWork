using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEVELtest
{
    internal class UP_DOWN
    {
        static void Main(string[] args)
        {
            Random random = new Random();       //Random 클래스 인스턴스 생성
            int userInput = random.Next(1000);  //Next()메서드 생성 999까지(최대값 -1)의 임의의 정수값을 생성

            int attempts = 10;      // 시도횟수를 10회 제한으로 두기위해 10의 데이터 변수에 저장
            bool play = true;       // while반복문 실행을 위해 논리형변수 설정

            Console.WriteLine("업 & 다운 게임 시작. 0부터 999까지의 숫자 중 하나를 입력하세요! 기회는 총 10번 입니다.");
            // 게임시작 출력문
            while (play)
            {


                Console.Write("숫자를 입력해주세요 : ");
                string input = Console.ReadLine();      // 문자열로 입력받고

                if (int.TryParse(input, out int guess)) // 입력받은 문자열을 TrtParse를 통해 정수형으로 변환할 수 있는지 검사
                    // Try Parse에서 변환 가능할 경우 True 반환하며 반환된 값은 guess 변수에 저장
                    // 문자열이 정수로 변환될 수 없는 경우 false 를 반환하며 guess 변수에는 0이 저장됨
                    // Parse 메서드와 달리 변환 할 수 없는 문자열을 입력받았을때 예외를 발생시키지 않고, 반환값을 통해 결과와 성공 여부를 알려줌
                    if (guess < 0 || guess > 999)
                    {
                        Console.WriteLine("잘 못 입력하셨습니다. 0~999까지의 숫자만 입력해주세요.");
                        // 입력한 값이 0보다작거나 999보다 크면 재입력
                    }
                    else if (guess < userInput)
                    {
                        Console.WriteLine("UP! 더 큰 수를 입력 하세요.");
                        Console.WriteLine("남은기회 : {0}", attempts);
                        attempts--;
                    }
                        // 입력받은 값이 작다면 더 큰 수를 입력하라는 메세지 출력 시도 횟수 1회 차감
                    else if (guess > userInput)
                    {
                        Console.WriteLine("DOWN! 더 작은 수를 입력 하세요.");
                        Console.WriteLine("남은기회 : {0}", attempts);
                        attempts--;
                        // 입력받은 값이 더 크다면 작은 수를 입력하라는 메세지 출력시도 , 횟수 1회 차감
                    }

                    else
                    {
                        Console.WriteLine("정답!");
                        play = false;
                        // 정답일 경우 false 로 반복문 탈출
                    }

                while (attempts <= 0) // 시도횟수가 0이거나 더 작은경우
                {

                    Console.WriteLine("남은기회 : {0}", attempts);  
                    Console.WriteLine("GAME OVER 정답은 {0} 입니다!", userInput); // 정답과 함께 GAME OVER 출력
                    Console.WriteLine("재도전 하시겠습니까? Yes/No (Y/N)");  // 재도전 안내문
                    ConsoleKeyInfo key = Console.ReadKey();
                    // 사용자의 키입력을 받고
                    if (key.KeyChar == 'y' || key.KeyChar == 'Y')       // y,Y를 입력한 경우
                    {
                        userInput = random.Next(1000);
                        attempts = 10;
                        Console.Clear();
                        Console.WriteLine("새 게임을 시작합니다.");
                        Console.WriteLine("업 & 다운 게임 시작. 0부터 999까지의 숫자 중 하나를 입력하세요! 기회는 총 10번 입니다.");
                    }

                    // 새로운 게임 시작
                    else if (key.KeyChar == 'n' || key.KeyChar == 'N')
                    {
                        Console.WriteLine("게임을 종료합니다.");
                        play = false;
                    }
                    // n,N을 입력시 게임을 종료
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. Y 또는 N을 입력해주세요.");
                    }
                    // 잘못된 입력의 경우 안내 메세지 출력






                }
            }
        }
    }
}
