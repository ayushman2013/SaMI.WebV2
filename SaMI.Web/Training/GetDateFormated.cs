using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SaMI.Web.Training
{
    public static class GetDateFormated
    {
        public static string Get(string date)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string[] dateFull = date.Split('/');
            if (date != string.Empty)
            {
                if (dateFull[0].Length != 2)
                {
                    dateFull[0] = "0" + dateFull[0];
                }
                if (dateFull[1].Length != 2)
                {
                    dateFull[1] = "0" + dateFull[1];
                }
                DateTime dateExtracted = DateTime.ParseExact(dateFull[0] + "/" + dateFull[1] + "/" + dateFull[2], "MM/dd/yyyy", provider);
                string getStartDate = dateExtracted.ToString("dd-MMM-yyyy");
                return getStartDate;
            }
            return "";
        }
    }
}