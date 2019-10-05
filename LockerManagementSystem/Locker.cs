﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LockerManagementSystem
{
    /// <summary>
    /// This is a TravelLockerManagementSystem
    /// where user can drop and pick luggage from it
    /// </summary>
    class Locker
    {
        #region Properties
        /// <summary>
        ///defines type of Locker(Checking/TakingOut)
        /// </summary>
        public String LockerType { get; set; }
        /// <summary>
        /// defines size of locker(small/medium/large)
        /// </summary>
        public String LockerSize { get; set; }
        /// <summary>
        /// defines autogenerated locker number for locker
        /// </summary>
        public int LockerNumber { get; set; }
        /// <summary>
        /// defines creation time for locker
        /// </summary>
        public int ArrivalTime { get; set; }
        /// <summary>
        /// defines creation date for locker
        /// </summary>
        public DateTime ArrivalDate { get; set; }
        /// <summary>
        /// defines the number of hours user need that locker for
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// defines the total amount charged for the locker
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// defines the total number of lockers needed for luggage storage
        /// </summary>
        public int NumberOfLockers { get; set; }
        #endregion
    }
}
