using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class ReferralToDAO : BaseDAO
    {
        public ReferralToDAO() : base() { }
        public ReferralToDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_referral_to";
            KeyField = "ReferralToID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as ReferralToID, '[Select]' AS ReferralToDesc " +
                       " UNION " +
                       " SELECT ReferralToID, ReferralToDesc FROM tbl_referral_to";
            else
            sql = "SELECT * FROM tbl_referral_to";
            return ExecuteQuery(sql);
        }

        public int InsertReferralTo(ReferralTo objReferralTo)
        {
            objReferralTo.ReferralToID = 1;
            BeginTransaction();

            try
            {
                objReferralTo.ReferralToID = Insert(objReferralTo);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objReferralTo.ReferralToID = -1;
            }

            return objReferralTo.ReferralToID;
        }
        public int UpdateReferralTo(ReferralTo objReferralTo)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ReferralToDesc", "UpdatedBy", "UpdatedDate" };
                rowsaffected = Update(objReferralTo, UpdateProperties);

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
