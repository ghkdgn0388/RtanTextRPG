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

    public void InvenShow()
    {
        for(int i, i <= items.Length, i++)
        {
            
        }
    }
}
