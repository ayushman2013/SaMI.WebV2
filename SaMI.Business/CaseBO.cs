using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class CaseBO
    {
        public static DataView GetAll(int SaMIProfileID)
        {
            return new CaseDAO().SelectAll(SaMIProfileID);
        }

        public static DataView GetCustom(int SaMIProfileID)
        {
            return new CaseDAO().SelectCustom(SaMIProfileID);
        }

        public static int InsertCaseProfile(CaseProfiles objCaseProfiles,Cases objCases, List<EvidencesPerCase> lstEvidencesPerCase)
        {
            objCaseProfiles.CreatedDate = DateTime.Now;
            objCases.CreatedDate = DateTime.Now;
            return new CaseDAO().InsertCaseProfile(objCaseProfiles,objCases, lstEvidencesPerCase);
        }

        public static int InsertCase(Cases objCases, List<EvidencesPerCase> lstEvidencesPerCase)
        {
            return new CaseDAO().InsertCase(objCases, lstEvidencesPerCase);
        }

        public static int UpdateCase(Cases objCases, List<EvidencesPerCase> lstEvidencesPerCase)
        {
            return new CaseDAO().UpdateCase(objCases, lstEvidencesPerCase);
        }

        public static int UpdateCaseProfile(CaseProfiles objCaseProfiles)
        {
            objCaseProfiles.UpdatedDate = DateTime.Now;
            return new CaseDAO().UpdateCaseProfile(objCaseProfiles);
        }

        public static Cases GetCases(int CaseProfileID)
        {
            Cases objCases = new Cases();
            return (Cases)(new CaseDAO().FillDTO(objCases, "CaseProfileID=" + CaseProfileID));

        }

      
        public static int DeleteCase(int CaseID)
        {
            return new CaseDAO().Delete("CaseID=" + CaseID);
        }

        public static DataView GetCustomDetails(int ethnicityID, int casteID, int districtID, string followUpStatus = "", int vdcID = 0, string gender = "",string status = "", string compensation = "", string discriminated = "", String orderBy = "", int partnerID = 0)
        {
            String strFilter = "WHERE 1=1 ";

            if (districtID > 0)
                strFilter += " AND D.DistrictID = " + districtID;
            if (vdcID > 0)
                strFilter += " AND V.VDCID= " + vdcID;
            

            if (status != string.Empty)
                strFilter += " AND CT.CaseStatusTypeCode = '" + status + "'";

            if (compensation == "Yes")
                strFilter += " AND CA.CompensationAmount > 0 ";
            else if (compensation == "No")
                strFilter += " AND CA.CompensationAmount = 0 ";

            if (partnerID > 0)
                strFilter += " AND CA.PartnerID = " + partnerID;

            return new CaseDAO().SelectCustomDetails(strFilter, orderBy);

        }

        public static Boolean CheckCaseBySaMIProfileID(int SaMIProfileID, int PartnerID)
        {
            Boolean blnExists = false;
            DataView dv = new CaseDAO().ExecuteQuery("SELECT dbo.ufnGetPartnerCases("+ SaMIProfileID + "," + PartnerID + ") AS NoOfCase");
            if (dv.Count > 0)
            {
                if((int)dv.Table.Rows[0]["NoOfCase"] > 0)
                    blnExists = true;
            }
            return blnExists;
        }

        public static DataView GetCaseFollowUpRemider(int Frequency = -15, int DistrictID = 0, int PartnerID = 0)
        {
            return new CaseDAO().SelectCaseFollowUpRemider(Frequency, DistrictID, PartnerID);
        }

        public static CaseProfiles GetCaseProfile(int CaseProfileID)
        {
            CaseProfiles objCaseProfiles = new CaseProfiles();
            return (CaseProfiles)(new CaseDAO().FillDTO(objCaseProfiles, "CaseProfileID=" + CaseProfileID));

        }
    }
}
