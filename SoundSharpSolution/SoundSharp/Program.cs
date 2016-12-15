using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Principal;
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
        private static int _PasswordLoop;
        private static int Loopin;
        private static string Password = null;
        public static ArrayList MPlayerArrayList = new ArrayList();

        static void Main(string[] args)
        {
            MPlayerArrayListInfo();
            _LoopKill = 1;
            while (_LoopKill == 1)
            {
                try // Rechter muis admin
                {
                    WindowsIdentity identity = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                    {
                        ShowMenu();
                    } else
                    {
                        WrongName:
                        Console.Write("Name: ");
                        _Name = Convert.ToString(Console.ReadLine());
                        if (args.Length == 2 && args[0] == "admin" && args[1] == Password)
                        {
                            ShowMenu();
                        }
                        else if (_Name == "")
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
                catch (Exception ex)
                {
                    if (ex != null) { }
                }
            }
        }

        static void LogIn()
        {
            int Attempts = -1;
            _PasswordLoop = 1;


            while (_PasswordLoop == 1)
            {

                Console.Write("Password: ");
                Console.ForegroundColor = ConsoleColor.Black;
                string password = Convert.ToString(Console.ReadLine());
                Attempts++;
                if (password != Password)
                {
                    _PasswordLoop = 0;
                }
                else
                {
                    switch (Attempts)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Wrong Password! 3 Attempts remaining!");
                            Console.WriteLine();
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Wrong Password! 2 Attempts remaining!");
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.WriteLine("CAREFUL: Last attempt!");
                            Console.WriteLine();
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Clear();
                            _LoopKill = 0;
                            _PasswordLoop = 0;
                            break;
                    }
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
                Console.WriteLine("|4. Statistics           |");
                Console.WriteLine("|5. Add a new MP3 player |");
                Console.WriteLine("|6.                      |");
                Console.WriteLine("|7.                      |");
                Console.WriteLine("|8. Show Menu            |");
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
                    case 4:
                        Console.Clear();
                        Stats();
                        break;
                    case 5:
                        Console.Clear();
                        GenerateMP();
                        break;
                    case 8:
                        Console.Clear();
                        ShowMenu();
                        break;
                    case 9:
                        Loopin = 0;
                        _LoopKill = 0;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Thats not a viable option!");
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
                Console.WriteLine("ID: " + item.Player_id);
                Console.WriteLine("Make: " + item.Player_make);
                Console.WriteLine("Model: " + item.Player_model);
                Console.WriteLine("MBSize: " + item.Player_MB);
                Console.WriteLine("Price: " + item.Player_price);
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
            int MutatieID;
            try
            {

                MutatieID = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < MPlayerArrayList.Count; i++)
                {
                    MPlayer temp = (MPlayer)MPlayerArrayList[i];
                    if (temp.Player_id == MutatieID)
                    {
                        Console.WriteLine("How much MP3 Players were bought(+) or sold(-)?");
                        int MutatieMod = Convert.ToInt32(Console.ReadLine());
                        temp.Player_stock = temp.Player_stock + MutatieMod;
                        MPlayerArrayList[i] = temp;
                        Console.WriteLine("ID: " + temp.Player_id + ", voorraad: " + temp.Player_stock);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("U heeft een ongeldige waarde ingevoerd.");
                return;
            }
            

        }

        public static void Stats()
        {
            MPlayer temp = (MPlayer)MPlayerArrayList[0];
            MPlayer temp2 = (MPlayer)MPlayerArrayList[1];
            MPlayer temp3 = (MPlayer)MPlayerArrayList[2];
            MPlayer temp4 = (MPlayer)MPlayerArrayList[3];
            MPlayer temp5 = (MPlayer)MPlayerArrayList[4];

            int TotalMp3 = temp.Player_stock + temp2.Player_stock + temp3.Player_stock + temp4.Player_stock + temp5.Player_stock;
            int PriceMp3 = (temp.Player_stock * Convert.ToInt32(temp.Player_price)) + (temp2.Player_stock * Convert.ToInt32(temp2.Player_price)) + (temp3.Player_stock * Convert.ToInt32(temp3.Player_price)) + (temp4.Player_stock * Convert.ToInt32(temp4.Player_price)) + (temp5.Player_stock * Convert.ToInt32(temp5.Player_price));
            int AveragePrice = Convert.ToInt32(temp.Player_price + temp2.Player_price + temp3.Player_price + temp4.Player_price + temp5.Player_price) / 5;
            

            Console.WriteLine("Statistics: ");
            Console.WriteLine();
            Console.WriteLine("Total amount of MP3 Players in stock: " + TotalMp3);
            Console.WriteLine("Total price of all MP3 Players in stock: " + PriceMp3 + " euro's.");
            Console.WriteLine("Average price of players at SoundSharp: " + AveragePrice + " euro's");

            Console.ReadKey();
            Console.Clear();
        }

        public static void GenerateMP()
        {
            int IDGen = MPlayerArrayList.Count + 1;
            Console.WriteLine("What is the production Company?");
            string MPMake = Convert.ToString(Console.ReadLine());
            Console.WriteLine("What is the model name?");
            string MPModel = Convert.ToString(Console.ReadLine());
            Console.WriteLine("How many are in stock?");
            int MPStock = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the MBSize?");
            int MPmb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the price?");
            int MPprice = Convert.ToInt32(Console.ReadLine());

            MPlayerArrayList.Add(new MPlayer(IDGen, MPStock, MPMake, MPModel, MPmb, MPprice));

            Console.Clear();
        }
    }
}