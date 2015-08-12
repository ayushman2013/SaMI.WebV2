using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class FollowUpDAO : BaseDAO
    {
         public FollowUpDAO() : base() { }
         public FollowUpDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_follow_up";
            KeyField = "FollowUpID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '0' AS FollowUpID, '[Select]' AS FollowUpDesc " +
                      "UNION " +
                      "SELECT FollowUpID, FollowUpDesc FROM tbl_follow_up " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_follow_up " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertFollowUp(FollowUp objfollowup)
        {
            objfollowup.FollowUpID = 1;
            BeginTransaction();

            try
            {
                objfollowup.FollowUpID = Insert(objfollowup);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objfollowup.FollowUpID = -1;
            }

            return objfollowup.FollowUpID;
        }

        public int UpdateFollowUp(FollowUp objfollowup)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "FollowUpDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objfollowup, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteFollowUp(FollowUp objfollowup)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objfollowup, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectFollowUpIDForSync()
        {
            String sql = string.Empty;
            sql = "SELECT FollowUpID FROM tbl_follow_up " +
                         "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
