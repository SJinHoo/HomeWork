using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEVELtest
{
    internal class SearchInString
    {
        public void Main()
        {

            string str = Console.ReadLine();    // 문자를 입력받아 문자열 변수 str 저장
            int index = str.IndexOf(Console.ReadLine());    // 두번째 문자열을 입력받고 index변수에 저장
            // indexof() : 문자열이 처음 나타내는 위치의 인덱스 값 반환
            // 찾고자하는 문자열이 없읅경우 -1 반환
            Console.WriteLine(index);   // index의 변수값 출력
        }
    }
}
