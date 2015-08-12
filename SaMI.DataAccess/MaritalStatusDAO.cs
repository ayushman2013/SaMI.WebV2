using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class MaritalStatusDAO: BaseDAO
    {
        public MaritalStatusDAO() : base() { }
        public MaritalStatusDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_marital_status";
            KeyField = "MaritalStatusID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;

            if (Select)
                sql = "SELECT '' AS MaritalStatusID, '[Select]' AS MaritalStatusDesc " +
                      "UNION " +
                      "SELECT MaritalStatusID, MaritalStatusDesc FROM tbl_marital_status ";
            else
                sql = "SELECT * FROM tbl_marital_status";
            return ExecuteQuery(sql);
        }

        public DataView SelectMaritalStatusIDForSync()
        {
            String sql = string.Empty;
            sql = "SELECT MaritalStatusID FROM tbl_marital_status WHERE SyncStatus='0'";

            return ExecuteQuery(sql);
        }


        public int InsertMaritalStatus(MaritalStatus objStatus)
        {
            objStatus.MaritalStatusID = 1;
            BeginTransaction();

            try
            {
                objStatus.MaritalStatusID = Insert(objStatus);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objStatus.MaritalStatusID = -1;
            }

            return objStatus.MaritalStatusID;
        }

        public int UpdateMaritalStatus(MaritalStatus objStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "MaritalStatusDesc", "UpdatedBy", "UpdatedDate", "GUID", "SyncStatus" };
                rowsaffected = Update(objStatus, UpdateProperties);

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
