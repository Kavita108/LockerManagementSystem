using System;

namespace LockerManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************  WELCOME! **************");

            //creating instance of locker manager class
            var lockerManager = new LockerManager();

            while (true)
            {
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.Check locker availability");
                Console.WriteLine("2.Drop A Bag");
                Console.WriteLine("3.Pick A Bag");
                Console.WriteLine("4.Print Checkedout Lockers");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thankyou For Visiting !");
                        return;
                    case "1":
                        Console.WriteLine("LockerSize : ");
                        //convert enum to array
                        var sizeOfLockers = Enum.GetNames(typeof(LockerSize));
                        for (var i = 0; i < sizeOfLockers.Length; i++)
                        {
                            //loop through the array and print out
                            Console.WriteLine($"{i}.{sizeOfLockers[i]}");
                        }
                        var lockerSize = Enum.Parse<LockerSize>(Console.ReadLine()); ;
                        var isAvailable = lockerManager.IsLockerAvailable(lockerSize);
                        if (isAvailable)
                        {
                            Console.WriteLine($"Locker is available");
                        } else
                        {
                            Console.WriteLine($"Locker is not available");
                        }
                        break;
                    case "2":
                        Console.Write("Email Address : ");
                        var email = Console.ReadLine();
                        Console.WriteLine("LockerSize : ");
                        //convert enum to array
                        sizeOfLockers = Enum.GetNames(typeof(LockerSize));
                        for (var i = 0; i < sizeOfLockers.Length; i++)
                        {
                            //loop through the array and print out
                            Console.WriteLine($"{i}.{sizeOfLockers[i]}");
                        }
                        var sizeOfLocker = Enum.Parse<LockerSize>(Console.ReadLine());
                        Console.WriteLine("Enter hours: ");
                        var hours = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Pay amount: " + lockerManager.GetHourlyPrice(sizeOfLocker) * hours);
                        Console.WriteLine("Enter amount : ");
                        var amount = Int32.Parse(Console.ReadLine());
                        var locker = lockerManager.Dropbag(email, sizeOfLocker, hours, amount);
                        if (locker != null)
                        {
                            Console.WriteLine($"EA: {locker.EmailAddress}, CD: {locker.CheckInDate}, LS: {locker.LockerSize}, LID: {locker.LockerID}");
                        }
                        else
                        {
                            Console.WriteLine("Locker can not be assigned.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        var pickedup = lockerManager.PickBag(emailAddress);
                        if (pickedup)
                        {
                            Console.WriteLine("Your bags have been picked up");
                        } else
                        {
                            Console.WriteLine("No lockers found for the given email address");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Email Address: ");
                        emailAddress = Console.ReadLine();
                        var lockers = lockerManager.GetAllLockersByEmailAddress(emailAddress);
                        if (lockers == null || lockers.Count == 0)
                        {
                            Console.WriteLine("No lockers found for the given email address");
                        }
                        foreach (var mylocker in lockers)
                        {
                            Console.WriteLine($"EA: {mylocker.EmailAddress}, CD: {mylocker.CheckInDate}, LS: {mylocker.LockerSize}, LID: {mylocker.LockerID}");
                        }
                        break;
                    default:
                        Console.WriteLine("Please select a valid option !");
                        break;

                }
            }


        }
    }
}
