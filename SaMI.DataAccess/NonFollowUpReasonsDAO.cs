using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class NonFollowUpReasonsDAO : BaseDAO
    {
        public NonFollowUpReasonsDAO() : base() { }
        public NonFollowUpReasonsDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_non_followup_reasons";
            KeyField = "NonFollowUpReasonID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;

            if (Select)
                sql = "SELECT '' AS NonFollowUpReasonID, '[Select]' AS NonFollowUpReasonDesc " +
                        "UNION " +
                        "SELECT NonFollowUpReasonID, NonFollowUpReasonDesc FROM tbl_non_followup_reasons " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_non_followup_reasons " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertNonFollowUpReasons(NonFollowUpReasons objNonFollowUpReasons)
        {
            objNonFollowUpReasons.NonFollowUpReasonID = 1;
            BeginTransaction();

            try
            {
                objNonFollowUpReasons.NonFollowUpReasonID = Insert(objNonFollowUpReasons);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objNonFollowUpReasons.NonFollowUpReasonID = -1;
            }

            return objNonFollowUpReasons.NonFollowUpReasonID;
        }
        public int UpdateNonFollowUpReasons(NonFollowUpReasons objNonFollowUpReasons)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "NonFollowUpReasonDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objNonFollowUpReasons, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteNonFollowUpReasons(NonFollowUpReasons objNonFollowUpReasons)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "NonFollowUpReasonDesc", "UpdatedBy", "UpdatedDate", "Status" };
                rowsaffected = Update(objNonFollowUpReasons, UpdateProperties);

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
