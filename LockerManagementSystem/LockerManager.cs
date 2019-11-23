using System;
using System.Collections.Generic;
using System.Linq;

namespace LockerManagementSystem
{
    public class LockerManager
    {
        
        private LockerContext db = new LockerContext();

        //creating constructor 
        #region Constructor
        public LockerManager()
        {
            /*for (int i = 0; i < SMALL_LOCKERS_COUNT; i++)
            {
                db.Lockers.Add(new Locker { LockerSize = LockerSize.Small });
            }

            for (int i = 0; i < MEDIUM_LOCKERS_COUNT; i++)
            {
                db.Lockers.Add(new Locker { LockerSize = LockerSize.Medium });
            }

            for (int i = 0; i < LARGE_LOCKERS_COUNT; i++)
            {
                db.Lockers.Add(new Locker { LockerSize = LockerSize.Large });
            }

            for (int i = 0; i < XLARGE_LOCKERS_COUNT; i++)
            {
                db.Lockers.Add(new Locker { LockerSize = LockerSize.XtraLarge });
            }

            db.SaveChanges();*/
        }
        #endregion

        public bool IsLockerAvailable(LockerSize lockerSize)
        {
            var query = from l in db.Lockers
                        where l.LockerSize == lockerSize
                        && l.EmailAddress == null && l.CheckInDate == null
                        select l;
            return query.Count() > 0;
        }

        public Locker GetLocker(LockerSize lockerSize)
        {
            var query = from l in db.Lockers
                        where l.LockerSize == lockerSize
                        && l.EmailAddress == null && l.CheckInDate == null
                        select l;
            return query.FirstOrDefault<Locker>();
        }

        /// <summary>
        /// Defines price of a locker
        /// </summary>
        public int GetHourlyPrice(LockerSize lockerSize)
        {
            switch (lockerSize)
            {
                case LockerSize.Small:
                    return 5;

                case LockerSize.Medium:
                    return 10;

                case LockerSize.Large:
                    return 15;

                case LockerSize.XtraLarge:
                    return 20;

                default:
                    return -1;
            }
        }

        //creating filtered list of lockers that match to emailaddress
        public IList<Locker> GetAllLockersByEmailAddress(String emailAddress)
        {
            var query = from l in db.Lockers
                        where l.EmailAddress == emailAddress
                        select l;

            return query.ToList<Locker>();
        }

        //dropping bag
        public Locker Dropbag(string emailAddress, LockerSize lockerSize, int hours, int amount)
        {
            Locker l = GetLocker(lockerSize);
            if (l == null)
            {
                return null;
            }

            int price = GetHourlyPrice(lockerSize) * hours;
            if (amount < price)
            {
                throw new Exception("Amount is less than the locker price");
            }

            if (PaymentSystem.MakePayment(price))
            {
                l.Paid = true;
                l.EmailAddress = emailAddress;
                l.CheckInDate = DateTime.Now;
                db.SaveChanges();
                return l;
            } else
            {
                throw new Exception("Payment failed");
            }
        }

        public bool PickBag(string emailAddress)
        {
            var lockers = GetAllLockersByEmailAddress(emailAddress);
            if (lockers == null || lockers.Count() == 0)
            {
                return false;
            }

            foreach( var locker in lockers )
            {
                locker.EmailAddress = null;
                locker.CheckInDate = null;
                locker.Paid = false;
            }

            db.SaveChanges();
            return true;
        }

    }
}
