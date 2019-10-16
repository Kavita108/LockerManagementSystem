using System;

namespace LockerManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // instance of class (Locker) = = object
            var locker = new Locker
            {
                LockerType = "Checking",
                LockerSize = "small",
               // LockerNumber = 1234,
                //NumberOfLockers = 1,
                //ArrivalTime = 2,
                //ArrivalDate = 1,
                Duration = 3
            };

            Console.WriteLine(locker.LockerType);
        }
    }
}
