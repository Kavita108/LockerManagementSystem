using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LockerManagementSystem
{
    static  class LockerManager
    {
        //creating a temporary list of lockers
        private static List<Locker> lockers = new List<Locker>();
        public static Locker GetLocker(string emailAddress, LockerSize lockerSize)
        {
            var locker = new Locker
            {
                EmailAddress = emailAddress,
                LockerSize = lockerSize
            };

            //Adding created locker to the collection/temporary array list
            lockers.Add(locker);
            return locker;

        }

        public static IEnumerable<Locker> GetAllLockerByEmailAddress(String emailAddress)
        {
            return lockers.Where(l => l.EmailAddress == emailAddress);
        }
    }
}
