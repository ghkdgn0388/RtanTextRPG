using RtanTextRPG;
using System;

public class Dungeon
{
    public Role myRole;

    public string name;
	
	public int clearGold;
	public int clearExp;

    public int minDam;
    public int maxDam;

	public float finalDamMin;
	public float finalDamMax;

    public int minClampDamage;

    public float diff;
	public int rcArmor;

	public int damage;
    public int bonusGold;
    public int minBonusPoint;
    public int maxBonusPoint;

    public virtual void Enter(Role role)
    {
        Console.Clear();
        myRole = role;
        CalculateDamage();

        Console.WriteLine($"{name}에 입장했습니다!");

        for (int i = 0; i <= 20; i++)
        {
            Thread.Sleep(300);
            string bar = new string('■', i) + new string('-', 20 - i);
            Console.Write($"\r[{bar}] {i * 5}% 탐험중");
        }
        Console.WriteLine("\n탐험 완료!");

        if (myRole.curHealth <= damage)
        {
            OnFail();
        }
        else
        {
            myRole.curHealth -= damage;
            OnClear();
        }
    }

    public virtual void OnClear()
    {
        // 1. 보너스 비율 계산 (예: 공격력 10이면 10% ~ 20%)
        int minPercent = myRole.curPower;
        int maxPercent = myRole.curPower * 2;

        // 2. 랜덤 비율 정수 선택
        int bonusRate = new Random().Next(minPercent, maxPercent + 1); // 정수 %, 예: 10~20

        // 3. 보너스 골드 계산
        int bonusGold = clearGold * bonusRate / 100;

        // 4. 최종 골드 지급
        int totalGold = clearGold + bonusGold;
        myRole.gold += totalGold;

        myRole.clearCount++; // 클리어 횟수 증가

        Console.WriteLine($"{name}을(를) 클리어했습니다! 보상: {clearGold}G + {bonusGold}G");
        Console.WriteLine($"남은체력 : {myRole.curHealth}Hp");

        // 레벨업 조건 체크
        if (myRole.clearCount >= myRole.requiredClear)
        {
            myRole.level++;
            myRole.clearCount = 0; // 초기화
            myRole.requiredClear++; // 다음부터는 1회 더 필요

            myRole.power += 1;
            myRole.armor += 0.5f;


            Console.WriteLine(@"
 _                    _ _   _       
| |                  | | | | |      
| |     _____   _____| | | | |_ __  
| |    / _ \ \ / / _ \ | | | | '_ \ 
| |___|  __/\ V /  __/ | |_| | |_) |
\_____/\___| \_/ \___|_|\___/| .__/ 
                             | |    
                             |_|    
");
            Console.WriteLine($"레벨업! 현재 레벨: {myRole.level}");
            Console.WriteLine($"능력치가 상승했습니다!\n{myRole.power - 1} -> {myRole.power}  / {myRole.armor - 1 : 0.0} -> {myRole.armor : 0.0}");
        }

        myRole.PlayerInfo();
        Console.ReadLine();
    }

    public virtual void OnFail()
    {
        Console.Clear();
        Console.WriteLine(@"
   _____                       ____                 
  / ____|                     / __ \                
 | |  __  __ _ _ __ ___   ___| |  | |_   _____ _ __ 
 | | |_ |/ _` | '_ ` _ \ / _ \ |  | \ \ / / _ \ '__|
 | |__| | (_| | | | | | |  __/ |__| |\ V /  __/ |   
  \_____|\__,_|_| |_| |_|\___|\____/  \_/ \___|_|   
                                                                                                      
");
        Console.WriteLine($"{name}에서 쓰러졌습니다... 체력: {myRole.curHealth} → 0");
        myRole.curHealth = 0;
        myRole.PlayerInfo();
        Console.WriteLine("게임을 종료합니다.");
        Console.ReadLine() ;
        Environment.Exit(0);
    }

    public virtual void CalculateDamage()
    {
        diff = rcArmor - myRole.curArmor;
        finalDamMin = Math.Max(minDam + diff, minClampDamage);
        finalDamMax = Math.Max(maxDam + diff, finalDamMin);
        damage = new Random().Next((int)finalDamMin, (int)finalDamMax + 1);
    }
}

public class Goblin : Dungeon
{
	public Goblin()
	{
		name = "고블린 부락";
		clearGold = 1000;
		clearExp = 1;

		rcArmor = 5;

		minDam = 20;
		maxDam = 30;

        minClampDamage = 10;
    }
}

public class Skeleton : Dungeon
{
    public Skeleton()
    {
        name = "스켈레톤 요새";
        clearGold = 1500;
        clearExp = 1;

        rcArmor = 15;

        minDam = 30;
        maxDam = 40;

        minClampDamage = 20;
    }
}

public class Slime : Dungeon
{
    public Slime()
    {
        name = "슬라임 동굴";
        clearGold = 2500;
        clearExp = 1;

        rcArmor = 20;

        minDam = 40;
        maxDam = 50;

        minClampDamage = 30;
    }
}
