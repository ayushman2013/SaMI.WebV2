using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class PassportStatusDAO : BaseDAO
    {
        public PassportStatusDAO() : base() { }
        public PassportStatusDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_passport_status";
            KeyField = "PassportStatusID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS PassportStatusID, '[Passport Status]' AS PassportStatusDesc " +
                      "UNION " +
                      "SELECT PassportStatusID, PassportStatusDesc FROM tbl_passport_status " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_passport_status " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertPassportStatus(PassportStatus objPassportStatus)
        {
            objPassportStatus.PassportStatusID = 1;
            BeginTransaction();

            try
            {
                objPassportStatus.PassportStatusID = Insert(objPassportStatus);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objPassportStatus.PassportStatusID = -1;
            }

            return objPassportStatus.PassportStatusID;
        }

        public int UpdatePassportStatus(PassportStatus objPassportStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "PassportStatusDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objPassportStatus, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeletePassportStatus(PassportStatus objPassportStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objPassportStatus, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectPassporttatusIDForSync()
        {
            String sql = string.Empty;

            sql = "SELECT PassportStatusID FROM tbl_passport_status " +
                     "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
