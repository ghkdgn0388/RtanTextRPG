using System;

public class Item
{
    public string name;
    public string type;
    public int power;
    public int armor;
    public int health;
    public int price;
}

public class KnightMace : Item
{
    public KnightMace()
    {
        name = "기사의 메이스";
        type = "한손 무기";
        power = "5";
        price = "100";
    }
}

public class KnightArmor : Item
{
    public KnightArmor()
    {
        name = "기사의 갑옷";
        type = "방어구";
        armor = "10";
        health = "30";
        price = "100";
    }
}

public class KnightShield : Item
{
    public KnightShield()
    {
        name = "기사의 방패";
        type = "보조 장비";
        armor = "10";
        price = "100";
    }
}

public class MercenaryTwohander : Item
{
    public MercenaryTwohander()
    {
        name = "용병의 양손검";
        type = "양손 무기";
        power = "10";
        armor = "5";
        price = "200";
    }
}

public class MercenaryArmor : Item
{
    public MercenaryArmor()
    {
        name = "용병의 갑옷";
        type = "방어구";
        armor = "10";
        health = "10";
        price = "100";
    }
}

public class ThiefSword : Item
{
    public ThiefSword()
    {
        name = "도적의 한손검";
        type = "한손 무기";
        power = "15";
        price = "100";
    }
}

public class ThiefArmor : Item
{
    public ThiefArmor()
    {
        name = "도적의 방어구";
        type = "방어구";
        health = "10";
        price = "100";
    }
}

public class ThiefDagger : Item
{
    public ThiefDagger()
    {
        name = "도적의 단검";
        type = "보조 장비";
        power = "10";
        price = "100";
    }
}