using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class NonReferralReasonsDAO :  BaseDAO
    {
        public NonReferralReasonsDAO() : base() { }
        public NonReferralReasonsDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_non_referral_reasons";
            KeyField = "NonReferralReasonID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as NonReferralReasonID, '[Select]' AS NonReferralReasonDesc " +
                       " UNION " +
                       " SELECT NonReferralReasonID, NonReferralReasonDesc FROM tbl_non_referral_reasons " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_non_referral_reasons " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertNonReferralReasons(NonReferralReasons objNonReferralReasons)
        {
            objNonReferralReasons.NonReferralReasonID = 1;
            BeginTransaction();

            try
            {
                objNonReferralReasons.NonReferralReasonID = Insert(objNonReferralReasons);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objNonReferralReasons.NonReferralReasonID = -1;
            }

            return objNonReferralReasons.NonReferralReasonID;
        }

        public int UpdateNonReferralReasons(NonReferralReasons objNonReferralReasons)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "NonReferralReasonDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objNonReferralReasons, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteNonReferralReasons(NonReferralReasons objNonReferralReasons)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objNonReferralReasons, UpdateProperties);

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
