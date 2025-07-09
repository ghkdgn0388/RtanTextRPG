using System;
using System.Collections.Generic;

public class Inventory
{
    public List<Item> items = new List<Item>();

    public Item[] equipment = new Item[3]; 
    
    public enum equipped
    {
        weapon = 0,
        armor,
        sub
    }




    //public Item equipment[(int)equipped.weapon] = null;
    //public Item equipment[(int)equipped.armor] = null;
    //public Item equipment[(int)equipped.sub] = null;

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

            if (item == equipment[(int)equipped.weapon] || item == equipment[(int)equipped.armor] || item == equipment[(int)equipped.sub])
            {
                equippedMark = "[E] ";
            }

            Console.WriteLine($"{i + 1}. {equippedMark}{item.name} ({item.type})");
        }
    }

    public void Equip()
    {
        Console.Write("장착 또는 해제할 아이템의 번호를 입력하세요: ");
        string input = Console.ReadLine();

        // 1. 입력값이 숫자인지, 유효한 아이템 번호인지 확인
        if (!int.TryParse(input, out int itemIndex) || itemIndex <= 0 || itemIndex > items.Count)
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000); // 1초 대기
            return; // 메서드 종료
        }

        // 사용자는 1부터 입력하므로, 리스트의 인덱스(0부터 시작)에 맞게 1을 빼줍니다.
        Item selectedItem = items[itemIndex - 1];

        // 2. 선택한 아이템이 이미 장착된 아이템인지 확인 -> 맞다면 장착 해제
        if (selectedItem == equipment[(int)equipped.weapon])
        {
            equipment[(int)equipped.weapon] = null;
            Console.WriteLine($"{selectedItem.name} 장착을 해제했습니다.");
        }
        else if (selectedItem == equipment[(int)equipped.armor])
        {
            equipment[(int)equipped.armor] = null;
            Console.WriteLine($"{selectedItem.name} 장착을 해제했습니다.");
        }
        else if (selectedItem == equipment[(int)equipped.sub])
        {
            equipment[(int)equipped.sub] = null;
            Console.WriteLine($"{selectedItem.name} 장착을 해제했습니다.");
        }
        // 3. 장착되지 않은 아이템이라면 -> 아이템 타입에 맞게 장착
        else
        {
            switch (selectedItem.type)
            {
                case ItemType.한손무기:
                    // 이미 다른 무기를 끼고 있다면 알려줄 수 있습니다.
                    if (equipment[(int)equipped.weapon] != null)
                    {
                        if(equipment[(int)equipped.weapon].type == ItemType.양손무기)
                        {
                            equipment[(int)equipped.sub] = null;
                        }
                        Console.WriteLine($"{equipment[(int)equipped.weapon].name}을(를) 해제하고 {selectedItem.name}을(를) 장착합니다.");
                    }
                    equipment[(int)equipped.weapon] = selectedItem;
                    Console.WriteLine($"{selectedItem.name}을(를) 장착했습니다.");
                    break;

                case ItemType.양손무기:
                    if (equipment[(int)equipped.weapon] != null || equipment[(int)equipped.sub] != null)
                    {
                        Console.WriteLine("양손 무기를 장착하기 위해 다른 무기들을 해제합니다.");
                    }
                    equipment[(int)equipped.weapon] = selectedItem;
                    equipment[(int)equipped.sub] = null; // 양손 무기는 보조무기 슬롯도 차지
                    Console.WriteLine($"{selectedItem.name}을(를) 장착했습니다.");
                    break;

                case ItemType.방어구: // 아이템 타입은 일관성 있게 관리하는 것이 좋습니다.
                    if (equipment[(int)equipped.armor] != null)
                    {
                        Console.WriteLine($"{equipment[(int)equipped.armor].name}을(를) 해제하고 {selectedItem.name}을(를) 장착합니다.");
                    }
                    equipment[(int)equipped.armor] = selectedItem;
                    Console.WriteLine($"{selectedItem.name}을(를) 장착했습니다.");
                    break;

                case ItemType.보조장비:
                    if (equipment[(int)equipped.sub] != null)
                    {
                        Console.WriteLine($"{equipment[(int)equipped.sub].name}을(를) 해제하고 {selectedItem.name}을(를) 장착합니다.");
                    }

                    if (equipment[(int)equipped.weapon].type == ItemType.양손무기)
                    {
                        equipment[(int)equipped.weapon] = null;
                    }
                    equipment[(int)equipped.sub] = selectedItem;
                    Console.WriteLine($"{selectedItem.name}을(를) 장착했습니다.");
                    break;

                default:
                    Console.WriteLine("이 아이템은 장착할 수 없는 유형입니다.");
                    break;
            }
        }
        Thread.Sleep(1000); // 결과 메시지를 보여주기 위해 1초 대기
    }
}
