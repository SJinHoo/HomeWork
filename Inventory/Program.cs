namespace Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 문자열 타입의 인벤토리 생성
            var inventory = new Inven<string>();        // var : 할당되는 데이터를 파악해 컴파일러가 자동으로 해당 변수의 형식을 지정함

            // 인벤토리에 아이템 추가
            inventory.Add("자객의 발톱");
            inventory.Add("피바라기");
            inventory.Add("존야의 모래시계");
            inventory.Add("최후의 속삭임");           // inven 클래스에 지정해둔 Add 함수를 불러와 원하는 아이템 추가 

            // 인벤토리 내 아이템 개수 출력
            Console.WriteLine($"인벤토리 내 아이템 개수: {inventory.Count()}");       // inven 클래스에 지정해둔 Count함수 불러와 아이템 갯수를 출력

            // index를 사용하여 인벤토리 내 아이템에 접근
            Console.WriteLine($"index 0의 아이템: {inventory[0]}");
            Console.WriteLine($"index 1의 아이템: {inventory[1]}");


            // 인벤토리 내에 있는 아이템 검색
            Console.WriteLine($"인벤토리 내 '존야의 모래시계' 아이템 존재 여부: {inventory.Find("존야의 모래시계")}");
            Console.WriteLine($"인벤토리 내 '드락사르의 황혼검' 아이템 존재 여부: {inventory.Find("드락사르의 황혼검")}");      // 드락사르 황혼검은 아이템 목록에 추가하지 않았기 때문에 출력되지않음

            // 인벤토리 내 지정한 아이템 삭제
            inventory.Remove("피바라기");

            // 인벤토리 내 아이템 갯수 출력
            Console.WriteLine($"인벤토리 내 아이템 개수: {inventory.Count()}");           // 피바라기가 지워졌으니 3개

            // index 배열의 0,1,2 의 아이템
            Console.WriteLine($"index 0의 아이템: {inventory[0]}");
            Console.WriteLine($"index 1의 아이템: {inventory[1]}");     //위에서 피바라기 index[1]을 삭제했기 때문에 list 배열이 한 칸씩 앞으로 땡겨져서 나열됨
            Console.WriteLine($"index 2의 아이템: {inventory[2]}");


            // Find,FindIndex 로 인벤토리 내에 특정 아이템 찾기
            Console.WriteLine($"인벤토리 내 '피바라기' 아이템 존재 여부: {inventory.Find("피바라기")}");           // 아마 피바라기를 위에서 삭제했기 때문에 false가 출력될 것임
            Console.WriteLine($"인벤토리 내 '최후의 속삭임' 아이템 인덱스: {inventory.FindIndex("최후의 속삭임")}");

        }
    }
}