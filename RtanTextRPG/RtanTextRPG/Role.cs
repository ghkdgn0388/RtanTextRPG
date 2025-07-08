using System;

public class Role
{
    //static Item myItem = null;

    public string name;
    public string role;
    public int level;
    public int power;
    public int armor;
    public int health;
    public int gold;

    public void PlayerInfo()
    {
        Console.WriteLine("=== 캐릭터 정보 ===");
        Console.WriteLine($"이름: {name}");
        Console.WriteLine($"레벨: Lv.{level}");
        Console.WriteLine($"직업: {role}");
        Console.WriteLine($"공격력: {power}");
        Console.WriteLine($"방어력: {armor}");
        Console.WriteLine($"체력: {health}");
        Console.WriteLine($"소지금: {gold}");
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

