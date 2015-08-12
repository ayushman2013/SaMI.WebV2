using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class CaseReferralHistoryBO
    {
        public static DataView GetAll(int CaseID)
        {
            return new CaseReferralHistoryDAO().SelectAll(CaseID);
        }

        public static DataView GetCustom(int CaseProfileID)
        {
            return new CaseReferralHistoryDAO().SelectCustom(CaseProfileID);
        }

        public static int InsertCaseReferralHistory(CaseReferralHistory objCaseReferralHistory)
        {
            Cases objCases = new Cases();
            objCases.CaseID = objCaseReferralHistory.CaseID;
            objCases.PartnerID = objCaseReferralHistory.NewPartnerID;
            objCases.UpdatedBy = objCaseReferralHistory.CreatedBy;
            objCases.UpdatedDate = DateTime.Now;
            objCaseReferralHistory.CreatedDate = DateTime.Now;
            return new CaseReferralHistoryDAO().InsertCaseReferralHistory(objCaseReferralHistory, objCases);
        }

        public static int UpdateCaseFollowUp(CaseReferralHistory objCaseReferralHistory)
        {
            Cases objCases = new Cases();
            objCases.CaseID = objCaseReferralHistory.CaseID;
            objCases.PartnerID = objCaseReferralHistory.NewPartnerID;
            objCases.UpdatedBy = objCaseReferralHistory.UpdatedBy;
            objCases.UpdatedDate = DateTime.Now;
            objCaseReferralHistory.UpdatedDate = DateTime.Now;
            return new CaseReferralHistoryDAO().UpdateCaseFollowUpHistory(objCaseReferralHistory, objCases);
        }

        public static CaseReferralHistory GetCaseReferralHistory(int CaseReferralHistoryID)
        {
            CaseReferralHistory objCaseReferralHistory = new CaseReferralHistory();
            return (CaseReferralHistory)(new CaseReferralHistoryDAO().FillDTO(objCaseReferralHistory, "CaseReferralHistoryID=" + CaseReferralHistoryID));

        }

        public static int DeleteCaseReferralHistory(int CaseReferralHistoryID, int UserID)
        {
            CaseReferralHistory objCaseReferralHistory = GetCaseReferralHistory(CaseReferralHistoryID);
            Cases objCases = new Cases();
            objCases.CaseID = objCaseReferralHistory.CaseID;
            objCases.PartnerID = objCaseReferralHistory.PreviousPartnerID;
            objCases.UpdatedBy = UserID;
            objCases.UpdatedDate = DateTime.Now;

            return new CaseReferralHistoryDAO().DeleteCaseReferralHistory(CaseReferralHistoryID, objCases);
        }
    }
}
