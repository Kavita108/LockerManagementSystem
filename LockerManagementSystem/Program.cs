using System;

namespace LockerManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //object intialization
            //instance of class (Locker) = = object

            var locker = LockerManager.OpenLocker("test@test.com", LockerSize.Medium);
           

            
            /* String Interapolation*/
            Console.WriteLine($" LS: {locker.LockerSize} , EA: {locker.EmailAddress}, CD: {locker.CheckingDate}, LN: {locker.LockerNumber}");

            var locker2 = LockerManager.OpenLocker("test1@test.com", LockerSize.Small);
            Console.WriteLine($" LS: {locker2.LockerSize} , EA: {locker2.EmailAddress}, CD: {locker2.CheckingDate}, LN: {locker2.LockerNumber}");

            
        }
    }
}
