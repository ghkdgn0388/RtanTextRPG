using System;

public class Store
{
    public List<Item> items = new List<Item>();

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
        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            Console.WriteLine($"{i + 1}. {item.name} ({item.type})");
        }
    }
}
