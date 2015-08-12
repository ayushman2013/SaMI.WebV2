using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;
namespace SaMI.Business
{
   public class CaseReferredBO
    {
       public static int InsertCaseReferred(CaseReferred objCaseReferred)
        {
            return new CaseReferredDAO().InsertCaseReferred(objCaseReferred);
        }

       public static int UpdateCaseReferred(CaseReferred objCaseReferred)
        {
            return new CaseReferredDAO().UpdateCaseReferred(objCaseReferred);
        }

        public static DataView GetAll()
        {
            return new CaseReferredDAO().SelectAll();
        }

        public static DataView GetStatus(int SaMIProfileID)
        {
            return new CaseReferredDAO().GetStatus(SaMIProfileID);
        }

        public static int DeleteCaseReferred(int SaMIProfileID)
        {
            return new CaseReferredDAO().DeleteCaseReferred(SaMIProfileID);
        }

        public static DataView GetReferredProfile(int SaMIProfileID)
        {
            return new CaseReferredDAO().SelectReferredProfile(SaMIProfileID);
        }

        public static DataView GetRecruitmentList(string strName)
        {
            return new CaseReferredDAO().SelectRecruitmentList(strName);
        }

        public static DataView CountRecruitmentList(string strName)
        {
            return new CaseReferredDAO().CountRecruitmentList(strName);
        }

       //This is used for Sync
        public static DataView GetCaseReferredIDForSync(String CreatedBy)
        {
            return new CaseReferredDAO().GetCaseReferredIDForSync(CreatedBy);
        }
        public static CaseReferred GetCaseReferred(int CaseReferredID)
        {
            CaseReferred objCaseReferred = new CaseReferred();
            return (CaseReferred)(new CaseReferredDAO().FillDTO(objCaseReferred, "CaseReferredID=" + CaseReferredID));
        }
    }
}
