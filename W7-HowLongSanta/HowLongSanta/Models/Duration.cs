using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HowLongSanta.Models
{
    public class Duration
    {
        private DateTime _startDate;
        private DateTime _endDate;

        /// <summary>
        /// Get and set start date
        /// </summary>
        public DateTime StartDate {
            get 
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

        /// <summary>
        /// Get and set end date
        /// </summary>
        public DateTime EndDate 
        { 
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                if (StartDate != DateTime.MinValue)
                {
                    if (DaysToWait > 366)
                    {
                        throw new ArgumentException("Dates must not be more than 1 year apart: " + _startDate);
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the number of days from StartDate until EndDate.
        /// </summary>
        public int DaysToWait
        {
            get 
            {
                if (StartDate == DateTime.MinValue || EndDate == DateTime.MinValue)
                {
                    throw new ArgumentException("Missing StartDate or EndDate");
                }
                return (int)(EndDate - StartDate).TotalDays;
            }
        }

        /// <summary>
        /// Calculate the number of days that have elapsed since exactly one year
        /// before the EndDate.
        /// </summary>
        public int DaysPassed 
        {
            get
            {
                return TotalDaysSinceAnniversaryOneYearAgo - DaysToWait;
            }
        }

        /// <summary>
        /// Calculate the total number of days between EndDate and exactly one year before.
        /// </summary>
        public int TotalDaysSinceAnniversaryOneYearAgo
        {
            get
            {
                if (StartDate == DateTime.MinValue || EndDate == DateTime.MinValue)
                {
                    throw new ArgumentException("Missing StartDate or EndDate");
                }
                return (int)(EndDate - 
                    new DateTime(EndDate.Year - 1, EndDate.Month, EndDate.Day)).TotalDays;
            }
        }
    }
}