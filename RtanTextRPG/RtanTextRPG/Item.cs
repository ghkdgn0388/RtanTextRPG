using System;

public class Item
{
    public string name;
    public ItemType type;
    public int power;
    public int armor;
    public int health;
    public int price;
}

public enum ItemType
{
    한손무기,
    양손무기,
    방어구,
    보조장비
}

public class KnightMace : Item
{
    public KnightMace()
    {
        name = "기사의 메이스";
        type = ItemType.한손무기;
        power = 5;
        price = 100;
    }
}

public class KnightArmor : Item
{
    public KnightArmor()
    {
        name = "기사의 갑옷";
        type = ItemType.방어구;
        armor = 10;
        health = 30;
        price = 100;
    }
}

public class KnightShield : Item
{
    public KnightShield()
    {
        name = "기사의 방패";
        type = ItemType.보조장비;
        armor = 10;
        price = 100;
    }
}

public class MercenaryTwohander : Item
{
    public MercenaryTwohander()
    {
        name = "용병의 양손검";
        type = ItemType.양손무기;
        power = 10;
        armor = 5;
        price = 200;
    }
}

public class MercenaryArmor : Item
{
    public MercenaryArmor()
    {
        name = "용병의 갑옷";
        type = ItemType.방어구;
        armor = 10;
        health = 10;
        price = 100;
    }
}

public class ThiefSword : Item
{
    public ThiefSword()
    {
        name = "도적의 한손검";
        type = ItemType.한손무기;
        power = 15;
        price = 100;
    }
}

public class ThiefArmor : Item
{
    public ThiefArmor()
    {
        name = "도적의 방어구";
        type = ItemType.방어구;
        health = 10;
        price = 100;
    }
}

public class ThiefDagger : Item
{
    public ThiefDagger()
    {
        name = "도적의 단검";
        type = ItemType.보조장비;
        power = 10;
        price = 100;
    }
}

public class SpartaSpear : Item
{
    public SpartaSpear()
    {
        name = "스파르타 창";
        type = ItemType.한손무기;
        power = 15;
        price = 300;
    }
}

public class SpartaShield : Item
{
    public SpartaShield()
    {
        name = "스파르타 방패";
        type = ItemType.보조장비;
        armor = 15;
        price = 300;
    }
}

public class SteelArmor : Item
{
    public SteelArmor()
    {
        name = "강철 갑옷";
        type = ItemType.방어구;
        armor = 15;
        health = 15;
        price = 500;
    }
}

public class TwoHandSword : Item
{
    public TwoHandSword()
    {
        name = "대검";
        type = ItemType.양손무기;
        power = 15;
        armor = 10;
        price = 100;
    }
}