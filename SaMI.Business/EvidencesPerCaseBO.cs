using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;


namespace SaMI.Business
{
    public class EvidencesPerCaseBO
    {
        public static List<EvidencesPerCase> GetAllByCaseID(int CaseID)
        {
            List<EvidencesPerCase> lstEvidencesPerCase = new List<EvidencesPerCase>();

            DataView objDataView = new BaseDAO().Select("*", "tbl_evidences_per_case", "CaseID=" + CaseID);

            foreach (DataRowView drv in objDataView)
            {
                EvidencesPerCase objEvidencesPerCase = new EvidencesPerCase();
                objEvidencesPerCase.EvidencesPerCaseID = (int)drv["EvidencesPerCaseID"];
                objEvidencesPerCase.EvidenceTypeID = (int)drv["EvidenceTypeID"];
                objEvidencesPerCase.CaseID = (int)drv["CaseID"];
                lstEvidencesPerCase.Add(objEvidencesPerCase);
            }

            return lstEvidencesPerCase;
        }
    }
}
