namespace ListPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            Item AssassinClaw = new Item("자객의 발톱", "단검", 1);
            inventory.AddItem(AssassinClaw);
            Item SandWatch = new Item("존야의 모래시계", "장신구", 1);
            inventory.AddItem(SandWatch);
            Item BloodGreatSword = new Item("피바라기", "대검", 1);
            inventory.AddItem(BloodGreatSword);
            Console.WriteLine();
            Console.WriteLine("인벤토리에 장착 아이템이 추가되었습니다. ");
            Console.WriteLine();
            inventory.PrintInventory();
            Console.WriteLine();
            Item HealPotion = new Item("체력포션", "회복약", 4);
            inventory.AddItem(HealPotion);
            Item ManaPotion = new Item("마나포션", "회복약", 3);
            inventory.AddItem(ManaPotion);
            Console.WriteLine("인벤토리에 체력,마나 포션 아이템이 추가되었습니다.");
            Console.WriteLine();
            inventory.PrintInventory();
            Console.WriteLine();
            inventory.RemoveItem(SandWatch);
            Console.WriteLine("인벤토리에서 존야의 모래시계를 제거 합니다.");
            Console.WriteLine();
            inventory.PrintInventory();



        }
    }
}