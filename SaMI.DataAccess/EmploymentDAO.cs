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
    public class EmploymentDAO : BaseDAO
    {
        public EmploymentDAO() : base() { }
        public EmploymentDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_employments";
            KeyField = "EmploymentID";
        }

        public DataView SelectAll(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_employments WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectCustom(int EmploymentSkillID)
        {
            String sql = "SELECT E.EmploymentID, E.CompanyName, C.CountryName, " +
                         "CONVERT(varchar(10), E.EmploymentStartDate, 111) AS EmploymentStartDate, " +
                         "WT.WorkTypeDesc, PR.PaymentRangeDesc " +
                         "FROM tbl_employments AS E " +
                         "JOIN tbl_countries AS C " +
                         "  ON C.CountryID = E.CountryID " +
                         "JOIN tbl_payment_ranges  AS PR " +
                         "  ON PR.PaymentRangeID = E.IncomeRangeID " +
                         "JOIN tbl_work_types  AS WT " +
                         "  ON WT.WorkTypeID = E.WorkTypeID " +
                         "WHERE EmploymentSkillID = " + EmploymentSkillID;
            return ExecuteQuery(sql);
        }

        public DataView SelectCustomDetails(String strFilter, String strOrderBy = "")
        {
            String sql = "SELECT SP.SaMIProfileID, SP.SaMIProfileNumber, " +
                            "(SP.FirstName + ' ' + SP.MiddleName + ' ' + SP.LastName) as FullName,  " +
                            "SP.VisitorPhone, D.DistrictName, C.CasteName, V.VDCName,  " +
                            "CASE Gender   " +
	                            "WHEN 'M' Then 'Male'   " +
	                            "ELSE 'Female'   " +
                            "END AS Gender, " +
                            "ES.CompanyName, CNT.CountryName, CONVERT(varchar(10), ES.EmploymentStartDate,111) AS EmploymentStartDate, " +
                            "WT.WorkTypeDesc, PR.PaymentRangeDesc, " +
                            "CASE	 " +
	                            "(SELECT COUNT(ESK.EmploymentSkillID)  " +
	                            " FROM tbl_employment_skills AS ESK  " +
	                            " WHERE ESK.SaMIProfileID = SP.SaMIProfileID) " +
	                            " WHEN 0 THEN 'No' " +
	                            " ELSE 'Yes' " +
                            "END AS TrainingStatus " +
                            "FROM tbl_employments AS ES " +
                            "JOIN tbl_SaMI_profiles AS SP ON SP.SaMIProfileID = ES.SaMIProfileID " +
                            "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID  " +
                            "JOIN tbl_countries AS CNT ON CNT.CountryID = ES.CountryID " +
                            "JOIN tbl_work_types AS WT ON WT.WorkTypeID = ES.WorkTypeID " +
                            "JOIN tbl_payment_ranges AS PR ON PR.PaymentRangeID = ES.IncomeRangeID " +
                            "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID  " +
                            "JOIN tbl_caste AS C ON C.CasteID = SP.CasteID  " +
                            "JOIN tbl_ethnicity E ON E.EthnicityID = C.EthnicityID ";

            sql += strFilter;

            if (strOrderBy != string.Empty)
                sql += " ORDER BY " + strOrderBy;

            return ExecuteQuery(sql);
        }

        public int InsertEmployment(Employments objEmployments)
        {
            objEmployments.EmploymentID = 1;
            BeginTransaction();

            try
            {
                objEmployments.EmploymentID = Insert(objEmployments);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objEmployments.EmploymentID = -1;
            }

            return objEmployments.EmploymentID;
        }

        public int UpdateEmployment(Employments objEmployments)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "CompanyName", "CountryID", "EmploymentStartDate",
                                                            "WorkTypeID", "IncomeRangeID", 
                                                            "UpdatedBy", "UpdatedDate"
                                                            };
                rowsaffected = Update(objEmployments, UpdateProperties);

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
