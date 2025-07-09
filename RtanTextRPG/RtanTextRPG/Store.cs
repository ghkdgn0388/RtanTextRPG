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
        sItem = StoreItem();

        Console.WriteLine("====== 상점 ======");
        for (int i = 0; i < sItem.Count; i++)
        {
            Item item = sItem[i];

            Console.WriteLine($"{i + 1}. {item.name} ({item.type})");
        }
    }
}
