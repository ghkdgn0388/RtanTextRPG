namespace RtanTextRPG
{
    internal class Program
    {
        static Role myRole = null;
        //static Item myItem = null;
        static Inventory myInven = new Inventory();
        static Store nStore = new Store();

        static void Main(string[] args)
        {
            while (true)
            {
                start();
            }
        }

        static void start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
 +-+-+-+-+ +-+-+-+-+ +-+-+-+
 |R|t|a|n| |T|e|x|t| |R|P|G|
 +-+-+-+-+ +-+-+-+-+ +-+-+-+
");
                Console.WriteLine("1. 새 게임");
                Console.WriteLine("2. 불러 오기");

                string startinput = Console.ReadLine();

                if (startinput == "1")
                {
                    while (true)  // 새 게임 시작 화면 반복
                    {
                        Console.Clear();
                        Console.WriteLine("새 게임을 시작합니다");
                        Console.WriteLine("1. 시작하기\n0. 돌아 가기");

                        string check = Console.ReadLine();
                        if (check == "1")
                        {
                            newGame();
                            break; // 새 게임 시작 루프 탈출 → 메인 메뉴 루프 탈출
                        }
                        else if (check == "0")
                        {
                            break; // 새 게임 시작 루프 탈출 → 메인 메뉴로 다시 표시
                        }
                        else
                        {
                            Console.WriteLine("정확한 값을 입력해 주세요");
                            Thread.Sleep(1000);
                            // 이 while 루프를 유지하므로 새 게임 시작 화면으로 다시 감
                        }
                    }
                }
                else if (startinput == "2")
                {
                    Console.Clear();
                    Console.WriteLine("저장된 게임을 불러옵니다");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("정확한 값을 입력해 주세요");
                    Thread.Sleep(1000);
                }
            }
        }

        static void newGame()
        {
            while(true)
            {
                Console.Clear();
                Console.Write("이름을 입력해 주세요 : ");
                string name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"당신의 이름은 {name}입니다.");

                Console.WriteLine($"1. 기사 \n2. 용병\n3. 도적");
                Console.Write("직업을 입력해 주세요 : ");
                string role = Console.ReadLine();

                if (role == "1")
                {
                    myRole = new Knight();
                    myInven.AddRange(((Knight)myRole).GetStarterItem());
                }
                else if (role == "2")
                {
                    myRole = new Mercenary();
                    myInven.AddRange(((Mercenary)myRole).GetStarterItem());
                }
                else if (role == "3")
                {
                    myRole = new Thief();
                    myInven.AddRange(((Thief)myRole).GetStarterItem());
                }
                else
                {
                    Console.WriteLine("정확한 값을 입력해 주세요");
                    Thread.Sleep(1000);
                    continue;
                }
                myRole.name = name;

                myRole.PlayerInfo();
                Console.WriteLine("1. 시작하기\n0. 다시선택");
                string check = Console.ReadLine();
                if (check == "1")
                {
                    mainScene();
                    break;
                }
                else if (check == "0")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("정확한 값을 입력해 주세요");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }

        static void mainScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"스파르타에 오신 {myRole.name}님 환영합니다. \n이곳에서 던전으로 입장하기전 정비를 할 수 있습니다.");
                Console.WriteLine("1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전 입장\n5. 저장");
                string act = Console.ReadLine();

                if (act == "1")
                {
                    Console.Clear();
                    myRole.PlayerInfo();
                    Console.WriteLine("돌아가려면 아무버튼이나 입력해주세요");
                    Console.ReadLine();
                    continue;
                }
                else if (act == "2") // 2. 인벤토리 선택
                {
                    // 인벤토리 하위 메뉴를 위한 새로운 루프 시작
                    while (true)
                    {
                        Console.Clear();
                        myInven.InvenShow(); // 현재 아이템 목록과 장착 상태 보여주기
                        Console.WriteLine("\n--------------------");
                        Console.WriteLine("1. 장비 관리");
                        Console.WriteLine("0. 나가기");
                        Console.WriteLine("--------------------");
                        Console.Write("원하시는 행동을 입력해주세요: ");

                        string invenAct = Console.ReadLine();

                        if (invenAct == "1")
                        {
                            // 여기서 Equip() 메서드를 호출합니다.
                            myInven.Equip();
                            // Equip() 메서드가 끝나면 루프의 처음으로 돌아가
                            // 변경된 내용이 적용된 인벤토리를 다시 보여줍니다.
                        }
                        else if (invenAct == "0")
                        {
                            // '나가기'를 선택하면 break를 통해
                            // 인벤토리 루프를 탈출하고 메인 메뉴로 돌아갑니다.
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(1000);
                        }
                    }
                }
                else if (act == "3")
                {
                    Console.Clear();
                    nStore.StoreShow();
                }
                else if (act == "4")
                {

                }
                else if (act == "5")
                {

                }
                else
                {
                    Console.WriteLine("정확한 값을 입력해 주세요");
                    continue;
                }
            }
        }

        
    }
}
