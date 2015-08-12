using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaMI.Web.Training
{
    public class ConvertToEnglishDate
    {
        public static EnglishDate GetEnglishDate(DateTime npDate)
        {
            #region Core Algorithm for English date conversion
            //Getting Nepali date data for English date calculation
            int[] enDateData = EnglishDateDataArray.GetEnglishDateDataArray(npDate.Year);

            //Getting English day of the year
            int npDayOfYear = npDate.DayOfYear;

            //Initializing Nepali Year from the data
            int enYear = enDateData[0];

            //Initializing Nepali month to Poush (9)
            //This is because English date Jan 1 always fall in Poush month of Nepali Calendar, which is 9th month of Nepali calendar
            int enMonth = 4;

            //Initializing Nepali DaysInMonth with total days in the month of Poush
            int enDaysInMonth = enDateData[2];

            //Initializing temp nepali days
            //This is sum of total days in each Nepali month starting Jan 1 in Nepali month Poush
            //Note: for the month Poush, only counting days after Jan 1
            //***** This is the key field to calculate Nepali date *****
            int enTempDays = enDateData[2] - enDateData[1] + 1;

            //Looping through Nepali date data array to get exact Nepali month, Nepali year & Nepali daysInMonth information
            for (int i = 3; npDayOfYear > enTempDays; i++)
            {
                enTempDays += enDateData[i];
                enDaysInMonth = enDateData[i];
                enMonth++;

                if (enMonth > 12)
                {
                    enMonth -= 12;
                    enYear++;
                }
            }

            //Calculating Nepali day
            int enDay = enDaysInMonth - (enTempDays - npDayOfYear);



            //while(enDay != 0){
            //        if(is_leap_year(enYear)= true)
            //        {
            //            $a = $lmonth[$m];
            //        }
            //        else
            //        {
            //            $a = $month[$m];
            //        }
            //        $total_eDays++;
            //        $day++;
            //        if($total_eDays > $a){
            //            $m++;
            //            $total_eDays = 1;
            //            if($m > 12){
            //                $y++;
            //                $m = 1;
            //            }	
            //        }
            //        if($day > 7)
            //            $day = 1;
            //        $total_nDays--;	
            //    }



            #endregion

            #region Constructing and returning NepaliDate object
            //Returning back NepaliDate object with all the date details
            EnglishDate enDate = new EnglishDate();
            enDate.enDate = String.Format("{0}/{1}/{2}", enYear, enMonth, enDay);
            enDate.enYear = enYear;
            enDate.enMonth = enMonth;
            enDate.enDay = enDay;
            enDate.enDaysInMonth = enDaysInMonth;

            return enDate;
            #endregion
        }

        public bool is_leap_year(int year)
		{
			int a = year;
			if (a%100==0)
			{
			     if(a%400==0)
			     {
				    return true;
			     } else {
			 	    return false;
			     }
			} 
            else
            { 
				if (a%4==0)
				{
					return true;
				} else {
					return false;
				}
			}
		}
    }
}