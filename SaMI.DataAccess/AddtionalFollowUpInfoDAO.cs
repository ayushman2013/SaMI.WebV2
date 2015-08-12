using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class AddtionalFollowUpInfoDAO : BaseDAO
    {
         public AddtionalFollowUpInfoDAO() : base() { }
         public AddtionalFollowUpInfoDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_additional_followup_info";
            KeyField = "AddtionalFollowUpInfoID";
        }

        public DataView SelectAll()
        {
            String sql = string.Empty;
            sql = "SELECT * FROM tbl_additional_followup_info " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }        

        public int InsertAddtionalFollowUpInfo(AdditionalFollowupInfo objAdditionalFollowupInfo)
        {
            objAdditionalFollowupInfo.AdditionalFollowUpInfoID = 1;
            BeginTransaction();

            try
            {
                objAdditionalFollowupInfo.AdditionalFollowUpInfoID = Insert(objAdditionalFollowupInfo);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objAdditionalFollowupInfo.AdditionalFollowUpInfoID = -1;
            }

            return objAdditionalFollowupInfo.AdditionalFollowUpInfoID;
        }

        public int UpdateAdditionalFollowUpInfo(AdditionalFollowupInfo objAdditionalFollowUpInfo)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "AdditionalFollowUpInfoDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objAdditionalFollowUpInfo, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteAdditionalFollowUpInfo(AdditionalFollowupInfo objAdditionalFollowUpInfo)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objAdditionalFollowUpInfo, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectAdditionalFollowupInfoIDForSync()
        {
            String sql = string.Empty;
            sql = "SELECT AdditionalFollowUpInfoID FROM tbl_additional_followup_info " +
                         "WHERE SyncStatus='0' ";
            return ExecuteQuery(sql);
        }
    }
}
