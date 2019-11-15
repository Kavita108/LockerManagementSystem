using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LockerManagementSystem
{
    public class LockerManager
    {
        //declaring the constant value
        private const int SMALL_LOCKERS_COUNT = 500;
        private const int MEDIUM_LOCKERS_COUNT = 500;
        private const int LARGE_LOCKERS_COUNT = 500;
        private const int XLARGE_LOCKERS_COUNT = 500;

        //creating a temporary empty list of Availablelockers
        private  List<Locker> smallAvailableLockers = new List<Locker>();
        private  List<Locker> mediumAvailableLockers = new List<Locker>();
        private  List<Locker> largeAvailableLockers = new List<Locker>();
        private  List<Locker> xLargeAvailableLockers = new List<Locker>();

        //creating a temporary empty list of UnAvailablelockers
        private IDictionary<int, Locker> checkedoutLockers = new Dictionary<int, Locker>();
        private List<Locker> smallCheckedoutLockers = new List<Locker>();
        private List<Locker> mediumCheckedoutLockers = new List<Locker>();
        private List<Locker> largeCheckedoutLockers = new List<Locker>();
        private List<Locker> xLargeCheckedoutLockers = new List<Locker>();

        //creating constructor 
        #region Constructor
        public LockerManager()
        {
            for (int i = 0; i < SMALL_LOCKERS_COUNT; i++)
            {
                smallAvailableLockers.Add(new Locker { LockerSize = LockerSize.Small });
            }

            for (int i = 0; i < MEDIUM_LOCKERS_COUNT; i++)
            {
                mediumAvailableLockers.Add(new Locker { LockerSize = LockerSize.Medium });
            }

            for (int i = 0; i < LARGE_LOCKERS_COUNT; i++)
            {
                largeAvailableLockers.Add(new Locker { LockerSize = LockerSize.Large });
            }

            for (int i = 0; i < XLARGE_LOCKERS_COUNT; i++)
            {
                xLargeAvailableLockers.Add(new Locker { LockerSize = LockerSize.XtraLarge });
            }
        }
        #endregion

        public bool IsLockerAvailable(LockerSize lockerSize)
        {
            switch (lockerSize)
            {
                case LockerSize.Small:
                    return smallAvailableLockers.Count() > 0;

                case LockerSize.Medium:
                    return mediumAvailableLockers.Count() > 0;
                    
                case LockerSize.Large:
                    return largeAvailableLockers.Count() > 0;

                case LockerSize.XtraLarge:
                    return xLargeAvailableLockers.Count() > 0;

                default:
                    return false;
            }
        }

        public Locker GetLocker(LockerSize lockerSize)
        {
            switch (lockerSize)
            {
                case LockerSize.Small:
                    if (smallAvailableLockers.Count() > 0)
                    {
                        Locker sl = smallAvailableLockers.First();
                        smallAvailableLockers.Remove(sl);
                        smallCheckedoutLockers.Add(sl);

                        return sl;
                    } else
                    {
                        return null;
                    }

                case LockerSize.Medium:
                    if (mediumAvailableLockers.Count() > 0)
                    {
                        Locker ml = mediumAvailableLockers.First();
                        mediumAvailableLockers.Remove(ml);
                        mediumCheckedoutLockers.Add(ml);

                        return ml;
                    }
                    else
                    {
                        return null;
                    }

                case LockerSize.Large:
                    if (largeAvailableLockers.Count() > 0)
                    {
                        Locker ll = largeAvailableLockers.First();
                        largeAvailableLockers.Remove(ll);
                        largeCheckedoutLockers.Add(ll);

                        return ll;
                    }
                    else
                    {
                        return null;
                    }

                case LockerSize.XtraLarge:
                    if (xLargeAvailableLockers.Count() > 0)
                    {
                        Locker xll = xLargeAvailableLockers.First();
                        xLargeAvailableLockers.Remove(xll);
                        xLargeCheckedoutLockers.Add(xll);

                        return xll;
                    }
                    else
                    {
                        return null;
                    }

                default:
                    return null;
            }
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
            //using LINQ and LAMBDA to get filtered list
            IList<Locker> smallLockers = smallCheckedoutLockers.Where(l => l.EmailAddress == emailAddress).ToList();
            IList<Locker> mediumLockers = mediumCheckedoutLockers.Where(l => l.EmailAddress == emailAddress).ToList();
            IList<Locker> largeLockers = largeCheckedoutLockers.Where(l => l.EmailAddress == emailAddress).ToList();
            IList<Locker> xlargeLockers = xLargeCheckedoutLockers.Where(l => l.EmailAddress == emailAddress).ToList();

            return smallLockers.Concat(mediumLockers).Concat(largeLockers).Concat(xlargeLockers).ToList();
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
                return null;
            }

            if (PaymentSystem.MakePayment(price))
            {
                l.Paid = true;
                l.EmailAddress = emailAddress;
                l.CheckInDate = new DateTime();
                return l;
            } else
            {
                return null;
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
                locker.EmailAddress = string.Empty;
                locker.CheckInDate = null;
                locker.Paid = false;

                switch (locker.LockerSize)
                {
                    case LockerSize.Small:
                        smallCheckedoutLockers.Remove(locker);
                        smallAvailableLockers.Add(locker);
                        break;

                    case LockerSize.Medium:
                        mediumCheckedoutLockers.Remove(locker);
                        mediumAvailableLockers.Add(locker);
                        break;

                    case LockerSize.Large:
                        largeCheckedoutLockers.Remove(locker);
                        largeAvailableLockers.Add(locker);
                        break;

                    case LockerSize.XtraLarge:
                        xLargeCheckedoutLockers.Remove(locker);
                        xLargeAvailableLockers.Add(locker);
                        break;

                    default:
                        break;
                }
            }

            return true;
        }

    }
}
