using System;
using System.Collections.Generic;
using System.Text;

namespace LockerManagementSystem
{
    static  class LockerManager
    {
        public static Locker OpenLocker(string emailAddress, LockerSize lockerSize)
        {
            var locker = new Locker
            {
                EmailAddress = emailAddress,
                LockerSize = lockerSize
            };

            return locker;
        }
    }
}
