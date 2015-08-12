using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DBTools;
using SaMI.DTO;
using System.Data;
using System.Collections;

namespace SaMI.DataAccess
{
    public class CaseReferralHistoryDAO : BaseDAO
    {
        public CaseReferralHistoryDAO() : base() { }
        public CaseReferralHistoryDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_case_referral_history";
            KeyField = "CaseReferralHistoryID";
        }

        public DataView SelectAll(int CaseID)
        {
            String sql = "SELECT * FROM tbl_case_referral_history WHERE CaseID = " + CaseID;
            return ExecuteQuery(sql);
        }

        public DataView SelectCustom(int CaseProfileID)
        {
            String sql = "SELECT CRH.CaseReferralHistoryID, " +
                         "CONVERT(varchar(10), CRH.ReferralDate, 111) AS ReferralDate, " +
                         "CT.CaseTypeDesc, CRH.Remarks, " +
                         "dbo.ufnGetStakeHolderName(CRH.PreviousPartnerID) AS PreviousPartnerName, " +
                         "dbo.ufnGetStakeHolderName(CRH.NewPartnerID) AS NewPartnerName " +
                         "FROM tbl_case_referral_history AS CRH " +
                         "JOIN tbl_cases AS C " +
                         "  ON C.CaseID = CRH.CaseID " +
                         "JOIN tbl_case_types AS CT " +
                         "  ON CT.CaseTypeID = C.CaseTypeID " +
                         "WHERE C.CaseProfileID = " + CaseProfileID;
            return ExecuteQuery(sql);
        }

        public int InsertCaseReferralHistory(CaseReferralHistory objCaseReferralHistory, Cases objCases)
        {
            objCaseReferralHistory.CaseReferralHistoryID = 1;
            BeginTransaction();

            try
            {
                objCaseReferralHistory.CaseReferralHistoryID = Insert(objCaseReferralHistory);
                String[] UpdateProperties = new String[] { "PartnerID", "UpdatedBy", "UpdatedDate"};
                Update(objCases, UpdateProperties);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCaseReferralHistory.CaseReferralHistoryID = -1;
            }

            return objCaseReferralHistory.CaseReferralHistoryID;
        }

        public int UpdateCaseFollowUpHistory(CaseReferralHistory objCaseReferralHistory, Cases objCases)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "PreviousPartnerID", "NewPartnerID", "ReferralDate"
                                                            , "Remarks","UpdatedBy", "UpdatedDate"
                                                            };
                rowsaffected = Update(objCaseReferralHistory, UpdateProperties);

                UpdateProperties = new String[] { "PartnerID", "UpdatedBy", "UpdatedDate"};
                rowsaffected = Update(objCases, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteCaseReferralHistory(int CaseReferralHistoryID, Cases objCases)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                Delete("CaseReferralHistoryID=" + CaseReferralHistoryID);
                String[] UpdateProperties = new String[] { "PartnerID", "UpdatedBy", "UpdatedDate" };
                rowsaffected = Update(objCases, UpdateProperties);

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
