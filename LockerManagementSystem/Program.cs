using System;

namespace LockerManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************WELCOME! * ************");
            while (true)
            {
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.Get A Locker");
                Console.WriteLine("2.DropABag");
                Console.WriteLine("3.PickABag");
                Console.WriteLine("4.Close A Locker");
                Console.WriteLine("5.Print Available Lockers");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thankyou For Visiting");
                        return;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Please select a valid option !");
                        break;

                }
            }


        }
    }
}
