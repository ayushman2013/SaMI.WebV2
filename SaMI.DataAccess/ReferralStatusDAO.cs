using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class ReferralStatusDAO : BaseDAO
    {
        public ReferralStatusDAO() : base() { }
        public ReferralStatusDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_referral_status";
            KeyField = "ReferralStatusID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS ReferralStausID, '[Select]' AS ReferralStatusDesc " +
                      "UNION " +
                      "SELECT ReferralStausID, ReferralStatusDesc FROM tbl_referral_status";
            else
                sql = "SELECT * FROM tbl_referral_status";
            return ExecuteQuery(sql);
        }

        public int InsertReferralStatus(ReferralStatus objReferralStatus)
        {
            objReferralStatus.ReferralStausID = 1;
            BeginTransaction();

            try
            {
                objReferralStatus.ReferralStausID = Insert(objReferralStatus);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objReferralStatus.ReferralStausID = -1;
            }

            return objReferralStatus.ReferralStausID;
        }
        public int UpdateReferralStatus(ReferralStatus objReferralStatus)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ReferralStatusDesc", "UpdatedBy", "UpdatedDate" };
                rowsaffected = Update(objReferralStatus, UpdateProperties);

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
