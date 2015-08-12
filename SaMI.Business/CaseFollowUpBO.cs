using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class CaseFollowUpBO
    {
        public static DataView GetAll(int SaMIProfileID)
        {
            return new CaseFollowUpDAO().SelectAll(SaMIProfileID);
        }

        public static DataView GetCustom(int CaseProfileID)
        {
            return new CaseFollowUpDAO().SelectCustom(CaseProfileID);
        }

        public static int InsertCaseFollowUp(CaseFollowUp objCaseFollowUp)
        {
            return new CaseFollowUpDAO().InsertCaseFollowUp(objCaseFollowUp);
        }

        public static int UpdateCaseFollowUp(CaseFollowUp objCaseFollowUp)
        {
            return new CaseFollowUpDAO().UpdateCaseFollowUp(objCaseFollowUp);
        }

        public static CaseFollowUp GetCaseFollowUp(int CaseFollowUpID)
        {
            CaseFollowUp objCaseFollowUp = new CaseFollowUp();
            return (CaseFollowUp)(new CaseFollowUpDAO().FillDTO(objCaseFollowUp, "CaseFollowUpID=" + CaseFollowUpID));

        }

        public static int DeleteCaseFollowUp(int CaseFollowUpID)
        {
            return new CaseFollowUpDAO().Delete("CaseFollowUpID=" + CaseFollowUpID);
        }

        public static DataView GetCaseFollowUpUpdateRemider(int Frequency = -3, int DistrictID = 0, int PartnerID = 0)
        {
            return new CaseFollowUpDAO().SelectCaseFollowUpUpdateRemider(Frequency, DistrictID, PartnerID);
        }
    }
}
