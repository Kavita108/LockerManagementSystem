﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LockerManagementSystem
{
    public enum LockerSize
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
    public class Locker
    {
        //Declaring variable
        //private static int lastLockerID = 0;
               
        #region Properties

        /// <summary>
        /// defines email address of the user
        /// </summary>
        public string  EmailAddress { get; set; }

        
        /// <summary>
        /// defines size of locker(small/medium/large)
        /// </summary>
        public LockerSize LockerSize { get; set; }

        /// <summary>
        /// defines autogenerated locker number for locker
        /// </summary>
        public int LockerID { get; set; }

        /// <summary>
        /// defines creation date and time for locker
        /// this should be created by owner so the set property is private
        /// </summary>
        public DateTime? CheckInDate { get; set; }

        /// <summary>
        /// defines if user has paid for the locker or not
        /// </summary>
        public bool Paid { get; set; }


        #endregion
        #region Constructors        
        public Locker()
        {
            /// <summary>
            /// Automatic generation of date at the construction time
            /// </summary>
            CheckInDate = null;

            /// <summary>
            /// Generating locker number
            /// </summary>
            //LockerID = ++lastLockerID;

            /// <summary>
            /// Generating number of hours to store luggage
            /// </summary>


        }
        #endregion
        #region Methods
        /// <summary>
        /// Deposit luggage into the locker
        /// </summary>
        /// <param name="Bag"></param>
        public void Drop(string Bag)
        {
        }

        public void Pick(string Bag)
        {
        }
        #endregion

       
    }
}
