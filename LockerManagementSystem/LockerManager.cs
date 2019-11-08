using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LockerManagementSystem
{
    public class LockerManager
    {
        private const int SMALL_LOCKERS_COUNT = 500;
        private const int MEDIUM_LOCKERS_COUNT = 500;
        private const int LARGE_LOCKERS_COUNT = 500;
        private const int XLARGE_LOCKERS_COUNT = 500;

        //creating a temporary empty list of lockers
        private  List<Locker> smallAvailableLockers = new List<Locker>();
        private  List<Locker> mediumAvailableLockers = new List<Locker>();
        private  List<Locker> largeAvailableLockers = new List<Locker>();
        private  List<Locker> xLargeAvailableLockers = new List<Locker>();

        private List<Locker> smallCheckedoutLockers = new List<Locker>();
        private List<Locker> mediumCheckedoutLockers = new List<Locker>();
        private List<Locker> largeCheckedoutLockers = new List<Locker>();
        private List<Locker> xLargeCheckedoutLockers = new List<Locker>();

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

        public Locker GetLocker(string emailAddress, LockerSize lockerSize)
        {
            var locker = new Locker
            {
                EmailAddress = emailAddress,
                LockerSize = lockerSize
            };

            switch (lockerSize)
            {
                case LockerSize.Small:
                    if (smallAvailableLockers.Count() > 0)
                    {
                        Locker sl = smallAvailableLockers.First();
                        smallAvailableLockers.Remove(sl);
                        sl.EmailAddress = emailAddress;
                        sl.CheckInDate = new DateTime();
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
                        ml.EmailAddress = emailAddress;
                        ml.CheckInDate = new DateTime();
                        mediumCheckedoutLockers.Add(ml);

                        return ml;
                    }
                    else
                    {
                        return null;
                    }

                case LockerSize.Large:
                    if (smallAvailableLockers.Count() > 0)
                    {
                        Locker ll = largeAvailableLockers.First();
                        largeAvailableLockers.Remove(ll);
                        ll.EmailAddress = emailAddress;
                        ll.CheckInDate = new DateTime();
                        largeCheckedoutLockers.Add(ll);

                        return ll;
                    }
                    else
                    {
                        return null;
                    }

                case LockerSize.XtraLarge:
                    if (smallAvailableLockers.Count() > 0)
                    {
                        Locker xll = xLargeAvailableLockers.First();
                        xLargeAvailableLockers.Remove(xll);
                        xll.EmailAddress = emailAddress;
                        xll.CheckInDate = new DateTime();
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

        public IList<Locker> GetAllLockersByEmailAddress(String emailAddress)
        {
            IList<Locker> smallLockers = smallCheckedoutLockers.Where(l => l.EmailAddress == emailAddress).ToList();
            IList<Locker> mediumLockers = mediumCheckedoutLockers.Where(l => l.EmailAddress == emailAddress).ToList();
            IList<Locker> largeLockers = largeCheckedoutLockers.Where(l => l.EmailAddress == emailAddress).ToList();
            IList<Locker> xlargeLockers = xLargeCheckedoutLockers.Where(l => l.EmailAddress == emailAddress).ToList();

            return smallLockers.Concat(mediumLockers).Concat(largeLockers).Concat(xlargeLockers).ToList();
        }
    }
}
