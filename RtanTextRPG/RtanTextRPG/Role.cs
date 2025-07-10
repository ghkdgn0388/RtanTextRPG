using System;

public class Role
{
    public Inventory myInven;
    public string name;
    public string role;
    public int level;
    public int power;
    public float armor;
    public int health;
    public int gold;

    public int plusPower;
    public int plusArmor;
    public int plusHealth;

    public int curHealth;

    public int curPower;
    public float curArmor;
    public int maxHealth;

    public int clearCount = 0;
    public int requiredClear = 1;

    public void PlayerInfo()
    {
        LoadStat();

        Console.WriteLine("=== 캐릭터 정보 ===");
        Console.WriteLine($"이름: {name}");
        Console.WriteLine($"레벨: Lv.{level}");
        Console.WriteLine($"직업: {role}");
        Console.WriteLine($"공격력: {power}{(plusPower > 0 ? $" + {plusPower}" : "")}");
        Console.WriteLine($"방어력: {armor : 0.0}{(plusArmor > 0 ? $" + {plusArmor}" : "")}");
        Console.WriteLine($"체력: {health}{(plusHealth > 0 ? $" + {plusHealth}" : "")}");
        Console.WriteLine($"소지금: {gold}G");
    }

    public void LoadStat()
    {
        plusPower = 0;
        plusArmor = 0;
        plusHealth = 0;
        for (int i = 0; i < myInven.equipment.Length; i++)
        {
            if (myInven.equipment[i] != null)
            {
                plusPower += myInven.equipment[i].power;
                plusArmor += myInven.equipment[i].armor;
                plusHealth += myInven.equipment[i].health;
            }
        }

        curPower = power + plusPower;
        curArmor = armor + plusArmor;
        maxHealth = health + plusHealth;
    }
}

public class Knight : Role
{
    public Knight()
    {
        role = "기사";
        level = 1;
        power = 5;
        armor = 20;
        health = 150;
        gold = 300;
    }

    public List<Item> GetStarterItem()
    {
        return new List<Item>
        {
            new KnightMace(),
            new KnightArmor(),
            new KnightShield()
        };
    }
}

public class Mercenary : Role
{
    public Mercenary()
    {
        role = "용병";
        level = 1;
        power = 10;
        armor = 10;
        health = 100;
        gold = 500;
    }

    public List<Item> GetStarterItem()
    {
        return new List<Item>
        {
            new MercenaryTwohander(),
            new MercenaryArmor()
        };
    }
}

public class Thief : Role
{
    public Thief()
    {
        role = "도적";
        level = 1;
        power = 15;
        armor = 5;
        health = 80;
        gold = 800;
    }

    public List<Item> GetStarterItem()
    {
        return new List<Item>
        {
            new ThiefSword(),
            new ThiefDagger(),
            new ThiefArmor()
        };
    }
}

