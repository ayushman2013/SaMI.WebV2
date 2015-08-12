using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class EducationalStatusDAO : BaseDAO
    {
        public EducationalStatusDAO() : base() { }
        public EducationalStatusDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_educational_status";
            KeyField = "EducationalStatusID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;

            if (Select)
                sql = "SELECT '' AS EducationalStatusID, '[Education]' AS EducationalStatusDesc " +
                      "UNION " +
                      "SELECT EducationalStatusID, EducationalStatusDesc FROM tbl_educational_status " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_educational_status " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertEduationalStatus(EducationalStatus objEducationalStatus)
        {
            objEducationalStatus.EducationalStatusID = 1;
            BeginTransaction();

            try
            {
                objEducationalStatus.EducationalStatusID = Insert(objEducationalStatus);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objEducationalStatus.EducationalStatusID = -1;
            }

            return objEducationalStatus.EducationalStatusID;
        }

        public int UpdateEducationalStatus(EducationalStatus objEducationalStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "EducationalStatusDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objEducationalStatus, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteEducationalStatus(EducationalStatus objEducationalStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objEducationalStatus, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView GetEducationalStatusIDForSync()
        {
            String sql = string.Empty;
            sql = "SELECT EducationalStatusID FROM tbl_educational_status " +
                     "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }

    }
}
