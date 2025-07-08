using System;
using System.Collections.Generic;

public class Inventory
{
    public List<Item> items = new List<Item>();

    public Item equippedWeapon = null;
    public Item equippedArmor = null;
    public Item equippedSub = null;

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void AddRange(List<Item> itemsToAdd)
    {
        foreach (var item in itemsToAdd)
        {
            Add(item);
        }
    }

    public void InvenShow()
    {
        Console.WriteLine("====== 인벤토리 ======");
        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            string equippedMark = "";

            if (item == equippedWeapon || item == equippedArmor || item == equippedSub)
            {
                equippedMark = "[E]";
            }

            Console.WriteLine($"{i + 1}. {equippedMark}{item.name} ({item.type})");
        }
    }
}
