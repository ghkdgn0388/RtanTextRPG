using System;
using static Inventory;

public class Store
{
    public List<Item> items = new List<Item>();
    public Role myRole;
    public Inventory myInven;

    public Store(Role role)
    {
        myRole = role;
    }

    public List<Item> StoreItem()
    {
        return new List<Item>
        {
            new SpartaSpear(),
            new SpartaShield(),
            new SteelArmor(),
            new TwoHandSword()
        };
    }

    public void StoreShow()
    {
        items = StoreItem();  //클래스 필드에 저장

        Console.WriteLine("====== 상점 ======");
        Console.WriteLine($"보유 골드 {myRole.gold}G");
        Console.WriteLine("====== 상품 ======");
        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];

            string statInfo = "";
            if (item.power > 0) statInfo += $" | 공격력 +{item.power}";
            if (item.armor > 0) statInfo += $" | 방어력 +{item.armor}";
            if (item.health > 0) statInfo += $" | 체력 +{item.health}";

            Console.WriteLine($"{i + 1}. {item.name} ({item.type}){statInfo} | {item.price}G");
        }
    }

    public void Buy(Inventory inven)
    {
        Console.Write("구매할 아이템의 번호를 입력하세요: ");
        string buy = Console.ReadLine();

        if (!int.TryParse(buy, out int itemIndex) || itemIndex <= 0 || itemIndex > items.Count)
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000); // 1초 대기
            return; // 메서드 종료
        }

        Item selectedItem = items[itemIndex - 1];

        if (selectedItem.price <= myRole.gold)
        {
            Console.WriteLine($"{selectedItem.name}를 구매하시겠습니까?");
            Console.WriteLine("1. 구매 \n2. 취소");
            String cheak = Console.ReadLine();
            if (cheak == "1") 
            {
                myRole.gold -= selectedItem.price;
                inven.Add(selectedItem);
                Console.WriteLine($"{selectedItem.name}를 구매하셨습니다.");
            }
            else if (cheak == "2")
            {
                Console.WriteLine($"구매를 취소하였습니다.");
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
        else
        {
            Console.WriteLine("소지금이 부족합니다!");
        }
        Thread.Sleep(1000);
    }

    public void Sell(Inventory inven)
    {
        Console.Clear();
        Console.WriteLine("====== 인벤토리 ======");
        Console.WriteLine($"보유 골드 {myRole.gold}G");

        if (inven.items.Count == 0)
        {
            Console.WriteLine("판매할 아이템이 없습니다.");
            Thread.Sleep(1000);
            return;
        }

        for (int i = 0; i < inven.items.Count; i++)
        {
            Item item = inven.items[i];
            Console.WriteLine($"{i + 1}. {item.name} ({item.type}) | {item.price * 0.75}G");
        }

        Console.WriteLine("판매할 아이템의 번호를 입력하세요: ");
        string sell = Console.ReadLine();

        if (!int.TryParse(sell, out int itemIndex) || itemIndex <= 0 || itemIndex > inven.items.Count)
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000); // 1초 대기
            return; // 메서드 종료
        }
        else 
        {
            Item selectedItem = inven.items[itemIndex - 1];
            Console.WriteLine($"정말로 {selectedItem.name}을 판매 하시겠습니까? | {selectedItem.price * 0.75}G");
            Console.WriteLine($"1. 판매하기 \n2. 취소하기");
            string input = Console.ReadLine();

            if(input == "1")
            {
                int sellPrice = (int)(selectedItem.price * 0.75);
                myRole.gold += sellPrice;

                for (int i = 0; i < inven.equipment.Length; i++)
                {
                    if (inven.equipment[i] == selectedItem)
                    {
                        inven.equipment[i] = null;
                    }
                }

                inven.items.Remove(selectedItem);
                Console.WriteLine($"{selectedItem.name}을 판매하고 {sellPrice}G 를 획득하셨습니다.");
                Thread.Sleep(1000);
            }
            else if(input == "2")
            {
                Console.WriteLine($"구매를 취소하였습니다.");
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
