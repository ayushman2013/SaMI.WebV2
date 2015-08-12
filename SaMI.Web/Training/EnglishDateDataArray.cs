using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaMI.Web.Training
{
    public class EnglishDateDataArray
    {
        public static int[] GetEnglishDateDataArray(int year)
        {
            switch (year)
            {
                case 2070:
                    return new int[15] { 2013, 14, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30 };

                case 2071:
                    return new int[15] { 2014, 14, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30 };

                default:
                    throw new ArgumentOutOfRangeException(year.ToString(), "English year is out of range. Can not convert to Nepali date");
            }
        }
    }
}