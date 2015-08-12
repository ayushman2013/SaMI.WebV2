using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class PhoneFollowUpInfoDAO : BaseDAO
    {
         public PhoneFollowUpInfoDAO() : base() { }
         public PhoneFollowUpInfoDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_phonefollowup_info";
            KeyField = "PhoneFollowUpInfoID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = "SELECT * FROM tbl_phonefollowup_info " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public DataView SelectBySaMIProfileID(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_phonefollowup_info " +
                         "WHERE Status <> 0 AND SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public static PhoneFollowUpInfo GetPhoneFollowUpInfo(int SaMIProfileID)
        {
            PhoneFollowUpInfo objPhoneFollowUp = new PhoneFollowUpInfo();
            return (PhoneFollowUpInfo)(new PhoneFollowUpInfoDAO().FillDTO(objPhoneFollowUp, "SaMIProfileID=" + SaMIProfileID));
        }

        public int InsertPhoneFollowUpInfo(PhoneFollowUpInfo objPhoneFollowUpInfo)
        {
            objPhoneFollowUpInfo.PhoneFollowUpInfoID = 1;
            BeginTransaction();

            try
            {
                objPhoneFollowUpInfo.PhoneFollowUpInfoID = Insert(objPhoneFollowUpInfo);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objPhoneFollowUpInfo.PhoneFollowUpInfoID = -1;
            }

            return objPhoneFollowUpInfo.PhoneFollowUpInfoID;
        }

        public int UpdatePhoneFollowUpInfo(PhoneFollowUpInfo objPhoneFollowUpInfo)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "InformantsName", "MigrantRelation", "FollowUpDate", "Remarks", "UpdatedBy", "UpdatedDate", "Status" };
                rowsaffected = Update(objPhoneFollowUpInfo, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeletePhoneFollowUpInfo(PhoneFollowUpInfo objPhoneFollowUpInfo)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objPhoneFollowUpInfo, UpdateProperties);

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
            //sql = "SELECT PhoneFollowUpID FROM tbl_phone_follow_up " +
            //             "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
