﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LockerManagementSystem
{
    enum LockerSize
    {
        Small,
        Medium,
        Large,
        XtraLarge


    }
    /// <summary>
    /// This is a TravelLockerManagementSystem
    /// where user can drop and pick luggage from it
    /// </summary>
    class Locker
    {
        //Declaring variable
        private static int lastLockerNumber = 0;
               
        #region Properties

        /// <summary>
        /// defines email address of the user
        /// </summary>
        public string  EmailAddress { get; set; }

        /// <summary>
        ///defines type of Locker(Checking/CheckOut)
        /// </summary>
        public String LockerType { get; set; }

        /// <summary>
        /// defines size of locker(small/medium/large)
        /// </summary>
        public LockerSize LockerSize { get; set; }

        /// <summary>
        /// defines autogenerated locker number for locker
        /// </summary>
        public int LockerNumber { get;  }

        /// <summary>
        /// defines creation date and time for locker
        /// this should be created by owner so the set property is private
        /// </summary>
        public DateTime CheckingDate { get; private set; }

        /// <summary>
        /// defines the number of hours user need that locker for
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// defines the total amount charged for the locker
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// defines the total number of lockers needed for luggage storage
        /// </summary>
        public int NumberOfLockers { get; set; }
        #endregion
        #region Constructors

        
        public Locker()
        {
            /// <summary>
            /// Automatic generation of date at the construction time
            /// </summary>
            CheckingDate = DateTime.Now;

            /// <summary>
            /// Generating locker number
            /// </summary>
            LockerNumber = ++lastLockerNumber;
        }
        #endregion
        #region Methods
        /// <summary>
        /// pay money into the account
        /// </summary>
        /// <param name="amount">amount to deposit</param>
        public void Payment(decimal amount)
        {
            Balance += amount;
        }
        #endregion
    }
}
