using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundSharp;

namespace SoundSharp
{
    class Program
    {
        private static string _Name;
        private static int _MenuOption;
        private static int _LoopKill;
        private static int Loopin;
        public static ArrayList MPlayerArrayList = new ArrayList();

        static void Main(string[] args)
        {
            MPlayerArrayListInfo();
            _LoopKill = 1;
            while (_LoopKill == 1)
            {
            WrongName:
                Console.Write("Name: ");
                _Name = Convert.ToString(Console.ReadLine());

                if (_Name == "")
                { 
                    Console.WriteLine("Please fill in a name!");
                    Console.WriteLine("");
                    goto WrongName;
                }
                else
                {
                    LogIn();
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.Clear();
                ShowMenu();

                _LoopKill = 0;
            }
        }

        static void LogIn()
        {
            string Password;
            int Attempts = -1;


        WrongPassword:

            Console.Write("Password: ");
            Console.ForegroundColor = ConsoleColor.Black;
            Password = Convert.ToString(Console.ReadLine());
            Attempts++;
            if (Password != "")
            {
                switch (Attempts)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Wrong Password! 3 Attempts remaining!");
                        Console.WriteLine();
                        goto WrongPassword;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Wrong Password! 2 Attempts remaining!");
                        Console.WriteLine();
                        goto WrongPassword;
                    case 2:
                        Console.WriteLine("CAREFUL: Last attempt!");
                        Console.WriteLine();
                        goto WrongPassword;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Clear();
                        _LoopKill = 0;
                        break;
                    
                }
            }




        }

        static void ShowMenu()
        {
            Loopin = 1;

            while (Loopin == 1)
            { 

                Console.WriteLine("Welcome to SoundSharp " + _Name + "!");
                Console.WriteLine(" ________________________ ");
                Console.WriteLine("|1. Assortment           |");
                Console.WriteLine("|2. Stock                |");
                Console.WriteLine("|3. Mutate Stock         |");
                Console.WriteLine("|4.                      |");
                Console.WriteLine("|5.                      |");
                Console.WriteLine("|6.                      |");
                Console.WriteLine("|7.                      |");
                Console.WriteLine("|8.                      |");
                Console.WriteLine("|9. Exit                 |");
                Console.WriteLine("|________________________|");
                Console.WriteLine();

                _MenuOption = Convert.ToInt32(Console.ReadLine());

                switch (_MenuOption)
                {
                    case 1:
                        Console.Clear();
                        showAssortiment();
                        break;
                    case 2:
                        Console.Clear();
                        showStock();
                        break;
                    case 3:
                        Console.Clear();
                        Mutate();
                        break;
                    case 9:
                        Loopin = 0;
                        _LoopKill = 0;
                        break;
                    default:
                        Console.WriteLine("Thats not a viable option!");
                        Console.Clear();
                        break;
                }        
            }
        }

        public static void MPlayerArrayListInfo()
        {
            MPlayerArrayList.Add(new MPlayer(1, 500, "GetTech inc.", "HF 410", 4096f, 129.99f));
            MPlayerArrayList.Add(new MPlayer(2, 500, "Far & Loud", "XM 600", 8192f, 224.95f));
            MPlayerArrayList.Add(new MPlayer(3, 500, "Innotivative", "Z3", 512f, 79.95f));
            MPlayerArrayList.Add(new MPlayer(4, 500, "Resistance", "3001", 4096f, 124.95f));
            MPlayerArrayList.Add(new MPlayer(5, 500, "CBA", "NXT Volume", 2048f, 159.05f));
        }

        public static void showAssortiment()
        {
            Console.WriteLine("Assortiment:\n");
            foreach (MPlayer item in MPlayerArrayList)
            {
                Console.WriteLine(item.Player_id);
                Console.WriteLine(item.Player_make);
                Console.WriteLine(item.Player_model);
                Console.WriteLine(item.Player_MB);
                Console.WriteLine(item.Player_price);
                Console.WriteLine();
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void showStock()
        {
            Console.WriteLine("Overzicht voorraad:\n");
            foreach (MPlayer MPlayerData in MPlayerArrayList)
            {
                Console.WriteLine("ID {0}, voorraad {1}", MPlayerData.Player_id, MPlayerData.Player_stock);
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void Mutate()
        {
            Console.WriteLine("Muteer voorraad:\n");
            Console.WriteLine("Vul het id waarvan u de voorraad wilt veranderen in.");
            int MutatieID = 0;
            try
            {
                MutatieID = -1 + Convert.ToInt32(Console.ReadLine());
                MPlayer mp3 = MutatieID;
                mp3.Player_stock = 400;
                MPlayerArrayList[MutatieID] = mp3;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("U heeft een ongeldige waarde ingevoerd.");
                return;
            }
            Console.WriteLine("ID: {0}, voorraad: {0}");
        }

    }
}