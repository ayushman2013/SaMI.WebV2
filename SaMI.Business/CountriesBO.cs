using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class CountriesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new CountriesDAO().SelectAll(Select);

        }
        public static int InsertCountries(Countries objCountries)
        {
            return new CountriesDAO().InsertCountries(objCountries);
        }

        public static Countries GetCountry(int CountryID)
        {
            Countries objCountry = new Countries();
            return (Countries)(new CountriesDAO().FillDTO(objCountry, "CountryID=" + CountryID));
        }

        public static int UpdateCountries(Countries objCountries)
        {
            return new CountriesDAO().UpdateCountries(objCountries);
        }

        public static int Delete(int CountryID)
        {
            return new CountriesDAO().Delete("CountryID=" + CountryID);
        }
       
    }
}
