using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaMI.Web.Training
{
    public class EnglishDate
    {
        private string _englishDate;

        /// <summary>
        /// String representation of English Date. Format yyyy/m/d
        /// </summary>
        public string enDate
        {
            get { return _englishDate; }
            set { _englishDate = value; }
        }

        private int _enDaysInMonth;

        /// <summary>
        /// DaysInMonth of English date
        /// </summary>
        public int enDaysInMonth
        {
            get { return _enDaysInMonth; }
            set { _enDaysInMonth = value; }
        }

        private int _enYear;

        /// <summary>
        /// Numeric Year of English date
        /// </summary>
        public int enYear
        {
            get { return _enYear; }
            set { _enYear = value; }
        }

        private int _enMonth;

        /// <summary>
        /// Numeric Month of English date
        /// </summary>
        public int enMonth
        {
            get { return _enMonth; }
            set { _enMonth = value; }
        }

        private int _enDay;

        /// <summary>
        /// Numeric Day of English date
        /// </summary>
        public int enDay
        {
            get { return _enDay; }
            set { _enDay = value; }
        }
    }
}