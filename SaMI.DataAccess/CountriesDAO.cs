using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class CountriesDAO : BaseDAO
    {
        public CountriesDAO() : base() { }
        public CountriesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_countries";
            KeyField = "CountryID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS CountryID, '[Country]' AS CountryName " +
                      "UNION " +
                      "SELECT CountryID, CountryName FROM tbl_countries ";
            else
                sql = "SELECT * FROM tbl_countries";
            return ExecuteQuery(sql);
        }

        public int InsertCountries(Countries objCountries)
        {
            objCountries.CountryID = 1;
            BeginTransaction();

            try
            {
                objCountries.CountryID = Insert(objCountries);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCountries.CountryID = -1;
            }

            return objCountries.CountryID;
        }

        public int UpdateCountries(Countries objCountries)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "CountryName", "CountryCode", "CountryGroup", "UpdatedBy", "UpdatedDate" };
                rowsaffected = Update(objCountries, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }
        
    }
}
