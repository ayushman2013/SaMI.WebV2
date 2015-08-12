using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;


namespace SaMI.Business
{
    public class CaseTypesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new CaseTypesDAO().SelectAll(Select);

        }


        public static DataView GetAllInCases(int CaseProfileID, Boolean Select = false)
        {
            return new CaseTypesDAO().SelectAllInCases(CaseProfileID, Select);

        }


        public static int InsertCaseTypes(CaseTypes objCaseType)
        {
            return new CaseTypesDAO().InsertCaseTypes(objCaseType);
        }

        public static CaseTypes GetCaseType(int caseTypeID)
        {
            CaseTypes objCaseType = new CaseTypes();
            return (CaseTypes)(new CaseTypesDAO().FillDTO(objCaseType, "CaseTypeID=" + caseTypeID));
        }

        public static int UpdateCaseTypes(CaseTypes objCaseTypes)
        {
            return new CaseTypesDAO().UpdateCaseTypes(objCaseTypes);
        }

        public static int Delete(int CaseTypeID)
        {
            return new CaseTypesDAO().Delete("CaseTypeID=" + CaseTypeID);
        }

        public static String GetByCaseID(int CaseID)
        {
            String sql = "SELECT CT.CaseTypeDesc FROM tbl_case_types AS CT " +
                         "JOIN tbl_cases AS C ON C.CaseTypeID = CT.CaseTypeID ";
            DataView dv = new CaseTypesDAO().ExecuteQuery(sql);

            if (dv.Count > 0)
                return dv.Table.Rows[0]["CaseTypeDesc"].ToString();
            else
                return string.Empty;

        }

        public static int DeleteCaseTypes(CaseTypes objCaseTypes)
        {
            return new CaseTypesDAO().DeleteCaseTypes(objCaseTypes);
        }
    }
}
