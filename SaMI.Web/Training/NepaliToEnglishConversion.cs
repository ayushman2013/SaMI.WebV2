using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaMI.Web.Training
{
    public class NepaliToEnglishConversion
    {

        int[][] bs = new int[][] { 
                          new int[] { 2000, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 },
                          new int[] { 2001,31,31,32,31,31,31,30,29,30,29,30,30 },
                          new int[] { 2002,31,31,32,32,31,30,30,29,30,29,30,30},
                          new int[] { 2003,31,32,31,32,31,30,30,30,29,29,30,31},
                          new int[] {2004,30,32,31,32,31,30,30,30,29,30,29,31 },
                          new int[] { 2005,31,31,32,31,31,31,30,29,30,29,30,30 },
                          new int[] { 2006,31,31,32,32,31,30,30,29,30,29,30,30 },
                          new int[] { 2007,31,32,31,32,31,30,30,30,29,29,30,31 },
                          new int[] { 2008,31,31,31,32,31,31,29,30,30,29,29,31 },
                          new int[] { 2009,31,31,32,31,31,31,30,29,30,29,30,30 },
                          new int[] { 2010,31,31,32,32,31,30,30,29,30,29,30,30 },
                          new int[] { 2011,31,32,31,32,31,30,30,30,29,29,30,31 },
                          new int[] { 2012,31,31,31,32,31,31,29,30,30,29,30,30 },
                          new int[] { 2013,31,31,32,31,31,31,30,29,30,29,30,30 },
                          new int[] { 2014,31,31,32,32,31,30,30,29,30,29,30,30 },
                          new int[] {2015,31,32,31,32,31,30,30,30,29,29,30,31 },
                          new int[] { 2016,31,31,31,32,31,31,29,30,30,29,30,30 },
                          new int[] { 2017,31,31,32,31,31,31,30,29,30,29,30,30 },
                          new int[] { 2018,31,32,31,32,31,30,30,29,30,29,30,30 },
                          new int[] {2019,31,32,31,32,31,30,30,30,29,30,29,31},
			            new int[] {2020,31,31,31,32,31,31,30,29,30,29,30,30},
			            new int[] {2021,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2022,31,32,31,32,31,30,30,30,29,29,30,30},
			            new int[] {2023,31,32,31,32,31,30,30,30,29,30,29,31},
			            new int[] {2024,31,31,31,32,31,31,30,29,30,29,30,30},
			            new int[] {2025,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2026,31,32,31,32,31,30,30,30,29,29,30,31},
			            new int[] {2027,30,32,31,32,31,30,30,30,29,30,29,31},
			            new int[] {2028,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2029,31,31,32,31,32,30,30,29,30,29,30,30},
			            new int[] {2030,31,32,31,32,31,30,30,30,29,29,30,31},
			            new int[] {2031,30,32,31,32,31,30,30,30,29,30,29,31},
			            new int[] {2032,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2033,31,31,32,32,31,30,30,29,30,29,30,30},
			            new int[] {2034,31,32,31,32,31,30,30,30,29,29,30,31}, 
			            new int[] {2035,30,32,31,32,31,31,29,30,30,29,29,31},
			            new int[] {2036,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2037,31,31,32,32,31,30,30,29,30,29,30,30},
			            new int[] {2038,31,32,31,32,31,30,30,30,29,29,30,31},
			            new int[] {2039,31,31,31,32,31,31,29,30,30,29,30,30},
			            new int[] {2040,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2041,31,31,32,32,31,30,30,29,30,29,30,30},
			            new int[] {2042,31,32,31,32,31,30,30,30,29,29,30,31},
			            new int[] {2043,31,31,31,32,31,31,29,30,30,29,30,30},
			            new int[] {2044,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2045,31,32,31,32,31,30,30,29,30,29,30,30},
			            new int[] {2046,31,32,31,32,31,30,30,30,29,29,30,31},
			            new int[] {2047,31,31,31,32,31,31,30,29,30,29,30,30},
			            new int[] {2048,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2049,31,32,31,32,31,30,30,30,29,29,30,30},
			            new int[] {2050,31,32,31,32,31,30,30,30,29,30,29,31},
			            new int[] {2051,31,31,31,32,31,31,30,29,30,29,30,30},
			            new int[] {2052,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2053,31,32,31,32,31,30,30,30,29,29,30,30},
			            new int[] {2054,31,32,31,32,31,30,30,30,29,30,29,31},
			            new int[] {2055,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2056,31,31,32,31,32,30,30,29,30,29,30,30},
			            new int[] {2057,31,32,31,32,31,30,30,30,29,29,30,31},
			            new int[] {2058,30,32,31,32,31,30,30,30,29,30,29,31},
			            new int[] {2059,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2060,31,31,32,32,31,30,30,29,30,29,30,30},
			            new int[] {2061,31,32,31,32,31,30,30,30,29,29,30,31},
		                new int[] {2062,30,32,31,32,31,31,29,30,29,30,29,31},
			            new int[] {2063,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2064,31,31,32,32,31,30,30,29,30,29,30,30},
			            new int[] {2065,31,32,31,32,31,30,30,30,29,29,30,31},
			            new int[] {2066,31,31,31,32,31,31,29,30,30,29,29,31},
			            new int[] {2067,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2068,31,31,32,32,31,30,30,29,30,29,30,30},
			            new int[] {2069,31,32,31,32,31,30,30,30,29,29,30,31},
			            new int[] {2070,31,31,31,32,31,31,29,30,30,29,30,30},
			            new int[] {2071,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2072,31,32,31,32,31,30,30,29,30,29,30,30},
			            new int[] {2073,31,32,31,32,31,30,30,30,29,29,30,31},
			            new int[] {2074,31,31,31,32,31,31,30,29,30,29,30,30},
			            new int[] {2075,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2076,31,32,31,32,31,30,30,30,29,29,30,30},
			            new int[] {2077,31,32,31,32,31,30,30,30,29,30,29,31},
			            new int[] {2078,31,31,31,32,31,31,30,29,30,29,30,30},
			            new int[] {2079,31,31,32,31,31,31,30,29,30,29,30,30},
			            new int[] {2080,31,32,31,32,31,30,30,30,29,29,30,30},
			            new int[] {2081, 31, 31, 32, 32, 31, 30, 30, 30, 29, 30, 30, 30},
			            new int[] {2082, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30},
			            new int[] {2083, 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30},
			            new int[] {2084, 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30},
			            new int[] {2085, 31, 32, 31, 32, 30, 31, 30, 30, 29, 30, 30, 30},
			            new int[] {2086, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30},
			            new int[] {2087, 31, 31, 32, 31, 31, 31, 30, 30, 29, 30, 30, 30},
			            new int[] {2088, 30, 31, 32, 32, 30, 31, 30, 30, 29, 30, 30, 30},
			            new int[] {2089, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30},
			            new int[] {2090, 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30}
                         };

        Dictionary<string, string> nep_date = new Dictionary<string, string> {
                { "year", "" }, 
                { "month", "" }, 
                { "date", "" }, 
                { "day", "" }, 
                { "nmonth", "" }, 
                { "num_day", "" }
            };
        Dictionary<string, string> eng_date = new Dictionary<string, string> {
                { "year", "" }, 
                { "month", "" }, 
                { "date", "" }, 
                { "day", "" }, 
                { "nmonth", "" }, 
                { "num_day", "" }
            };

        string debug_info = "";

        public bool is_leap_year(int year)
        {
            int a = year;
            if (a % 100 == 0)
            {
                if (a % 400 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (a % 4 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string get_nepali_month(int m){
			string n_month = "";
			
			switch(m){
				case 1:
					n_month = "Baishak";
					break;
					
				case 2:
					n_month = "Jestha";
					break;
					
				case 3:
					n_month = "Ashad";
					break;
					
				case 4:
					n_month = "Shrawn";
					break;
					
				case 5:
					n_month = "Bhadra";
					break;
				
				case 6:
					n_month = "Ashwin";
					break;
				
				case 7:
					n_month = "kartik";
					break;
				
				case 8:
					n_month = "Mangshir";
					break;
				
				case 9:
					n_month = "Poush";
					break;
				
				case 10:
					n_month = "Magh";
					break;
				
				case 11:
					n_month = "Falgun";
					break;
				
				case 12:
					n_month = "Chaitra";
					break;
			}	
			return  n_month;
		}
       
        private string get_english_month(int m){
			string eMonth = "";
			switch(m){
				case 1:
					eMonth = "January";
					break;
				case 2:
					eMonth = "February";
					break;
				case 3:
					eMonth = "March";
					break;
				case 4:
					eMonth = "April";
					break;
				case 5:
					eMonth = "May";
					break;
				case 6:
					eMonth = "June";
					break;
				case 7:
					eMonth = "July";
					break;
				case 8:
					eMonth = "August";
					break;
				case 9:
					eMonth = "September";
					break;
				case 10:
					eMonth = "October";
					break;
				case 11:
					eMonth = "November";
					break;
				case 12:
					eMonth = "December";
                    break;
			}
			return eMonth;	
		}

        private string get_day_of_week(int day){
            string eday = "";
			switch(day){
				case 1:
					eday = "Sunday";
					break;
					
				case 2:
					eday = "Monday";
					break;
					
				case 3:
					eday = "Tuesday";
					break;
				
				case 4:
					eday = "Wednesday";
					break;
				
				case 5:
					eday = "Thursday";
					break;
				
				case 6:
					eday = "Friday";
					break;
				
				case 7:
					eday = "Saturday";
					break;
			}
			return eday;
		}

        private bool is_range_eng(int yy, int mm, int dd){
			if(yy<1944 || yy>2033){
				debug_info = "Supported only between 1944-2022";
				return false;
			}
				
			if(mm<1 || mm >12){
				debug_info = "Error! value 1-12 only";
				return false;
			}
				
			if(dd<1 || dd >31){
				debug_info = "Error! value 1-31 only";			
				return false;
			}	
			
			return true;
		}

        private bool is_range_nep(int yy, int mm, int dd){		
			if(yy<2000 || yy>2089){
				debug_info="Supported only between 2000-2089";
				return false;
			}
			
			if(mm<1 || mm >12) {
				debug_info="Error! value 1-12 only";
				return false;
			}
			
			if(dd<1 || dd >32){
				debug_info="Error! value 1-31 only";	
				return false;
			}		
			
			return true;
		}	

        public Dictionary<string,string> eng_to_nep(string eDate){
            string[] enDate = eDate.Split('-');
            int yy = Convert.ToInt32(enDate[0]);
            int mm = Convert.ToInt32(enDate[1]);
            int dd = Convert.ToInt32(enDate[2]);
            if (is_range_eng(yy, mm, dd) == false){
                return null;
            }
            else{

                // english month data.

                int[] month = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                int[] lmonth = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


                int def_eyy = 1944;									//spear head english date...
                int def_nyy = 2000; int def_nmm = 9; int def_ndd = 17 - 1;		//spear head nepali date...
                int total_eDays = 0; int total_nDays = 0; int a = 0; int day = 7 - 1;		//all the initializations...
                int m = 0; int y = 0; int i = 0; int j = 0;
                int numDay = 0;

                // count total no. of days in-terms of year
                for (i = 0; i < (yy - def_eyy); i++)
                {	//total days for month calculation...(english)
                    if (is_leap_year(def_eyy + i) == true)
                        for (j = 0; j < 12; j++)
                            total_eDays += lmonth[j];
                    else
                        for (j = 0; j < 12; j++)
                            total_eDays += month[j];
                }

                // count total no. of days in-terms of month					
                for (i = 0; i < (mm - 1); i++)
                {
                    if (is_leap_year(yy) == true)
                        total_eDays += lmonth[i];
                    else
                        total_eDays += month[i];
                }

                // count total no. of days in-terms of date
                total_eDays += dd;


                i = 0; j = def_nmm;
                total_nDays = def_ndd;
                m = def_nmm;
                y = def_nyy;

                // count nepali date from array
                while (total_eDays != 0)
                {
                    a = bs[i][j];
                    total_nDays++;						//count the days
                    day++;								//count the days interms of 7 days
                    if (total_nDays > a)
                    {
                        m++;
                        total_nDays = 1;
                        j++;
                    }
                    if (day > 7)
                        day = 1;
                    if (m > 12)
                    {
                        y++;
                        m = 1;
                    }
                    if (j > 12)
                    {
                        j = 1; i++;
                    }
                    total_eDays--;
                }

                numDay = day;

                nep_date["year"] = y.ToString();
                nep_date["month"] = m.ToString();
                nep_date["date"] = total_nDays.ToString();
                nep_date["day"] = get_day_of_week(day);
                nep_date["nmonth"] = get_nepali_month(m);
                nep_date["num_day"] = numDay.ToString();
                return nep_date;
            }
		}


        public Dictionary<string,string> nep_to_eng(string nDate){
            string[] nepDate = nDate.Split('/');
            int mm = Convert.ToInt32(nepDate[1]);
            int dd = Convert.ToInt32(nepDate[2]);
            int yy = Convert.ToInt32(nepDate[0]);
			int def_eyy = 1943, def_emm=4, def_edd=14-1,		// init english date.
			def_nyy = 2000, def_nmm = 1, def_ndd = 1,		// equivalent nepali date.
			total_eDays=0, total_nDays=0, a=0, day=4-1,		// initializations...
			m = 0, y = 0, i=0, j = 0,
			k = 0,	numDay = 0;
			
            int[] month = new int[] {0,31,28,31,30,31,30,31,31,30,31,30,31 };
                int[] lmonth = new int[] { 0,31,29,31,30,31,30,31,31,30,31,30,31 };

			
			if(is_range_nep(yy, mm, dd)==false){
				return null;
				
			} else {
				
				// count total days in-terms of year
				for(i=0; i<(yy-def_nyy); i++){	
					for(j=1; j<=12; j++){
						total_nDays += bs[k][j];
					}
					k++;
				}
				
				// count total days in-terms of month			
				for(j=1; j<mm; j++){
					total_nDays += bs[k][j];
				}
				
				// count total days in-terms of dat
				total_nDays += dd;			
				
				//calculation of equivalent english date...
				 total_eDays =  def_edd;
				 m =  def_emm;
				 y = def_eyy;
				while( total_nDays != 0){
					if(  is_leap_year( y))
					{
						 a =  lmonth[ m];
					}
					else
					{
						 a =  month[ m];
					}
					 total_eDays++;
					 day++;
					if( total_eDays >  a){
						 m++;
						 total_eDays = 1;
						if( m > 12){
							 y++;
							 m = 1;
						}	
					}
					if( day > 7)
						 day = 1;
					 total_nDays--;	
				}
				 numDay =  day;
				
				 eng_date["year"] =  y.ToString();					
				 eng_date["month"] =  m.ToString();					
				  eng_date["date"] =  total_eDays.ToString();		
				  eng_date["day"] =  get_day_of_week(day);					
				  eng_date["emonth"] =  get_english_month( m);  			
				  eng_date["num_day"] =  numDay.ToString();			
				
				return   eng_date;			
			}
		}
    }
}