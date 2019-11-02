using System;

namespace LockerManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************  WELCOME! **************");
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
                        Console.WriteLine("Thankyou For Visiting !");
                        return;
                    case "1":
                        Console.Write("Email Address : ");
                        var email = Console.ReadLine();
                        Console.WriteLine("LockerSize : ");
                        //convert enum to array
                        var sizeOfLockers = Enum.GetNames(typeof(LockerSize));
                        for (var i = 0; i < sizeOfLockers.Length; i++)
                        {
                            //loop through the array and print out
                            Console.WriteLine($"{i}.{sizeOfLockers[i]}");
                        }
                        var sizeOfLocker = Enum.Parse<LockerSize>(Console.ReadLine());

                        var locker = LockerManager.GetLocker(email, sizeOfLocker);
                        Console.WriteLine($"EA: {locker.EmailAddress}, CD: {locker.CheckInDate}, LS: {locker.LockerSize}, LN: {locker.LockerID}");

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
