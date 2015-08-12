using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class DistrictsDAO: BaseDAO
    {
         public DistrictsDAO() : base() { }
         public DistrictsDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_districts";
            KeyField = "DistrictID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;

            if (Select)
                sql = "SELECT 0 AS DistrictID, '[District]' AS DistrictName UNION " +
                        "SELECT DistrictID, DistrictName  FROM tbl_districts ORDER BY DistrictName";
            else
                sql = "SELECT * FROM tbl_districts ORDER BY DistrictName";
            return ExecuteQuery(sql);
        }

        public DataView GetDistrictIDForSync()
        {
            String sql = string.Empty;
                sql = "SELECT DistrictID FROM tbl_districts WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }

        
        public int InsertDistrict(Districts Districts)
        {
            Districts.DistrictID = -1;
            BeginTransaction();

            try
            {
                Districts.DistrictID = Insert(Districts);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                Districts.DistrictID = -1;
            }

            return Districts.DistrictID;
        }

        public int UpdateDistrict(Districts Districts)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "DistrictName", "ZoneID", "DistrictCode", "UpdatedBy", "UpdatedDate", "SyncStatus" };
                rowsaffected = Update(Districts, UpdateProperties);

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
