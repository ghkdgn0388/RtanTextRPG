namespace RtanTextRPG
{
    internal class Program
    {
        static Role myRole = null;
        static void Main(string[] args)
        {
            while (true)
            {
                start();
            }
        }

        static void start()
        {
            Console.WriteLine("RtanTextRPG");
            Console.WriteLine("1. 새 게임");
            Console.WriteLine("2. 불러 오기");

            String startinput = Console.ReadLine();

            if (startinput == "1")
            {
                Console.Clear();
                Console.WriteLine("새 게임을 시작합니다");
                Thread.Sleep(1000);
                newGame();
            }
            else if (startinput == "2")
            {
                Console.Clear();
                Console.WriteLine("저장된 게임을 불러옵니다");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("정확한 값을 입력해 주세요");
            }
        }

        static void newGame()
        {
            Console.Clear();
            Console.Write("이름을 입력해 주세요 : ");
            string name = Console.ReadLine();

            Console.WriteLine($"당신의 이름은 {name}입니다.");

            Console.WriteLine($"1. 기사 \n2. 용병\n3. 도적");
            Console.Write("직업을 입력해 주세요 : ");
            string  role = Console.ReadLine();

            if (role == "1")
            {
                myRole = new Knight();
            }
            else if (role == "2")
            {
                myRole = new Mercenary();
            }
            else if (role == "3")
            {
                myRole = new Thief();
            }
            else
            {
                Console.WriteLine("정확한 값을 입력해 주세요");
                return;
            }
            myRole.name = name;

            playerInfo();
        }
        static void playerInfo()
        {
            Console.WriteLine("=== 캐릭터 정보 ===");
            Console.WriteLine($"이름: {myRole.name}");
            Console.WriteLine($"레벨: Lv.{myRole.level}");
            Console.WriteLine($"직업: {myRole.role}");
            Console.WriteLine($"공격력: {myRole.power}");
            Console.WriteLine($"방어력: {myRole.armor}");
            Console.WriteLine($"체력: {myRole.health}");
            Console.WriteLine($"소지금: {myRole.gold}");
        }

        public class Role
        {
            public string name;
            public string role;
            public int level;
            public int power;
            public int armor;
            public int health;
            public int gold;
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
        }
    }
}
