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
    public class CaseDAO : BaseDAO
    {
        public CaseDAO() : base() { }
        public CaseDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_cases";
            KeyField = "CaseID";
        }

        public DataView SelectAll(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_cases WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectCustom(int CaseProfileID)
        {
            String sql = "SELECT C.CaseID, CT.CaseTypeDesc, C.Description, CST.CaseStatusTypeDesc, " +
                         "CASE dbo.ufnGetNoOfEvidencePerCaseID(C.CaseID)  " +
                                    "WHEN 0 THEN 'N/A' " +
                                    "ELSE CONVERT(varchar(100),dbo.ufnGetNoOfEvidencePerCaseID(C.CaseID)) " +
                         "END AS Evidences " +
                         "FROM tbl_cases AS C " +
                         "JOIN tbl_case_types AS CT " +
                         "  ON CT.CaseTypeID = C.CaseTypeID " +
                         "JOIN tbl_case_status_types AS CST " +
                         "  ON CST.CaseStatusTypeID = C.CaseStatusTypeID " +
                         "WHERE CaseProfileID = " + CaseProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectCustomDetails(String strFilter, String strOrderBy = "")
        {
            String sql = "SELECT " +
                            "CP.CaseProfileID, CP.CaseProfileNumber,V.VDCName,  " +
                            "(CP.FirstName + ' ' + CP.MiddleName + ' ' + CP.LastName) as FullName,  " +
                            " D.DistrictName, CA.NameOfOpponent, CA.[Description] AS ProblemFaced, CTY.CaseTypeDesc,  " +
                            "CASE CT.CaseStatusTypeCode  " +
                                    "WHEN 'Completed' THEN CA.OutputDetails " +
                                    "ELSE 'Running' " +
                            "END AS StatusDetail, " +
                            "CASE dbo.ufnGetNoOfEvidencePerCaseID(CA.CaseID)  " +
                                    "WHEN 0 THEN 'N/A' " +
                                    "ELSE CONVERT(varchar(100),dbo.ufnGetNoOfEvidencePerCaseID(CA.CaseID)) " +
                            "END AS Evidences, " +
                            "CASE CT.CaseStatusTypeCode  " +
                                    "WHEN 'Completed' THEN  " +
                                        "CASE CA.CompensationAmount " +
                                            "WHEN 0 THEN 'No' " +
                                            "ELSE CONVERT(varchar(100),CA.CompensationAmount) " +
                                        "END " +
                                    "ELSE '' " +
                            "END AS CompenstationDetail, " +
                            "SH.StakeHolderName, " +
                            "CONVERT(varchar(10),CA.CaseRegisteredDate, 111) AS CaseRegisteredDate, CR.CaseRegistrarName,CA.CaseNumber,  " +
                            "'' AS CaseFollowUpDetail " +
                        "FROM tbl_cases CA " +
                        "JOIN tbl_case_profiles AS CP ON CP.CaseProfileID = CA.CaseProfileID " +
                        "JOIN tbl_districts as D ON D.DistrictID = CP.DistrictID  " +
                        "JOIN tbl_vdc AS V ON V.VDCID = CP.VDCID " +
                        "JOIN tbl_case_status_types CT ON CT.CaseStatusTypeID = CA.CaseStatusTypeID  " +
                        "JOIN tbl_case_types CTY ON CTY.CaseTypeID = CA.CaseTypeID " +
                        "JOIN tbl_stakeholders SH ON SH.StakeHolderID = CA.PartnerID " +
                        "LEFT JOIN tbl_case_registrars CR ON CR.CaseRegistrarID = CA.CaseRegistrarID ";

            sql += strFilter;

            if (strOrderBy != string.Empty)
                sql += " ORDER BY " + strOrderBy;

            return ExecuteQuery(sql);
        }

        public int InsertCase(Cases objCases, List<EvidencesPerCase> lstEvidencesPerCase)
        {
            objCases.CaseID = 1;
            BeginTransaction();

            try
            {
                objCases.CaseID = Insert(objCases);
                foreach (EvidencesPerCase objEvidencesPerCase in lstEvidencesPerCase)
                {
                    objEvidencesPerCase.CaseID = objCases.CaseID;
                    Insert(objEvidencesPerCase);
                }
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCases.CaseID = -1;
            }

            return objCases.CaseID;
        }

        public int InsertCaseProfile(CaseProfiles objCaseProfiles, Cases objCases, List<EvidencesPerCase> lstEvidencesPerCase)
        {
            objCases.CaseID = 1;
            BeginTransaction();

            try
            {
                objCaseProfiles.CaseProfileNumber = GenerateCaseProfileNumber(objCaseProfiles.DistrictID);
                objCaseProfiles.CaseProfileID = Insert(objCaseProfiles);
                objCases.CaseProfileID = objCaseProfiles.CaseProfileID;


                objCases.CaseID = Insert(objCases);
                foreach (EvidencesPerCase objEvidencesPerCase in lstEvidencesPerCase)
                {
                    objEvidencesPerCase.CaseID = objCases.CaseID;
                    Insert(objEvidencesPerCase);
                }
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCases.CaseID = -1;
            }

            return objCases.CaseID;
        }

        public int UpdateCase(Cases objCases, List<EvidencesPerCase> lstEvidencesPerCase)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "CaseTypeID", "CaseNumber", "NameOfOpponent",
                                                            "Description", "PartnerID", "CaseRegistrarID", "ResponsibleStaff",
                                                            "CaseStatusTypeID", "CompensationAmount", "OutputDetails",
                                                            "UpdatedBy", "UpdatedDate", "CaseRegisteredDate"
                                                            };
                rowsaffected = Update(objCases, UpdateProperties);

                Delete("tbl_evidences_per_case", "CaseID = " + objCases.CaseID);
                foreach (EvidencesPerCase objEvidencesPerCase in lstEvidencesPerCase)
                {
                    objEvidencesPerCase.CaseID = objCases.CaseID;
                    Insert(objEvidencesPerCase);
                }

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int UpdateCaseProfile(CaseProfiles objCaseProfiles)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "FirstName", "MiddleName", "LastName", "DistrictID", "VDCID"};
                rowsaffected = Update(objCaseProfiles, UpdateProperties);
                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;
        }

        public DataView SelectCaseFollowUpRemider(int Frequency, int DistrictID, int PartnerID)
        {
            ArrayList paramField = new ArrayList { "@Frequency", "@PartnerID", "@DistrictID" };
            ArrayList paramValue = new ArrayList { Frequency, PartnerID, DistrictID };
            return DBHelper.ExecuteStoredProc("sp_GetCaseFollowUpReminder", paramField, paramValue);
        }

        public String GenerateCaseProfileNumber(int districtID)
        {
            String strRegNumber = string.Empty;

            String sql = "SELECT [dbo].[ufnGenerateCaseProfileNumber](" + districtID + ") AS RegistrationNumber";
            DataView dv = ExecuteQuery(sql);

            if (dv.Count > 0)
            {
                strRegNumber = dv.Table.Rows[0]["RegistrationNumber"].ToString();
            }

            return strRegNumber;
        }

       
    }
}
