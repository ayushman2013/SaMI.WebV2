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
    public class EmploymentSkillDAO : BaseDAO
    {
        public EmploymentSkillDAO() : base() { }
        public EmploymentSkillDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_employment_skills";
            KeyField = "EmploymentSkillID";
        }

        public DataView SelectAll()
        {
            String sql = "SELECT * FROM tbl_employment_skills";
            return ExecuteQuery(sql);
        }

        public DataView SelectCustom(string strFilter = "", string strOrderBy = "")
        {
            String sql = "SELECT SP.SaMIProfileID, SP.SaMIProfileNumber, " +
                            "(SP.FirstName + ' ' + SP.MiddleName + ' ' + SP.LastName) as FullName,  " +
                            "SP.VisitorPhone, D.DistrictName, C.CasteName, V.VDCName,  " +
                            "CASE Gender   " +
	                            "WHEN 'M' Then 'Male'   " +
	                            "ELSE 'Female'   " +
                            "END AS Gender, " +
                            "ES.TrainingSubject, CONVERT(varchar(10), ES.TrainingStratDate, 111) AS TrainingStratDate, ES.TrainingWardNumber,  " +
                            "CASE ES.HavePreviousTraining " +
	                            "WHEN 1 THEN 'Yes' " +
	                            "ELSE 'No' " +
                            "END AS PreviousTraining, " +
                            "(D.DistrictName + ', ' + ', ' + V.VDCName + ', ' +  " +
	                            "CONVERT(varchar(20),ES.TrainingWardNumber)) as TrainingLocation, " +
                            "TRT.TrainingReasonTypeDesc " +
                            "FROM dbo.tbl_employment_skills AS ES " +
                            "JOIN tbl_SaMI_profiles AS SP ON SP.SaMIProfileID = ES.SaMIProfileID " +
                            "JOIN tbl_districts as D ON D.DistrictID = ES.TrainingDistrictID  " +
                            "JOIN tbl_training_reason_types AS TRT ON TRT.TrainingReasonTypeID = ES.TrainingReasonTypeID " +
                            "JOIN tbl_vdc AS V ON V.VDCID = ES.TrainingVDCID  " +
                            "JOIN tbl_caste AS C ON C.CasteID = SP.CasteID  " +
                            "JOIN tbl_ethnicity E ON E.EthnicityID = C.EthnicityID ";

            sql += strFilter;

            if (strOrderBy != string.Empty)
                sql += " ORDER BY " + strOrderBy;

            return ExecuteQuery(sql);
        }

        public int InsertSkill(EmploymentSkills objEmploymentSkills)
        {
            objEmploymentSkills.EmploymentSkillID = 1;
            BeginTransaction();

            try
            {
                objEmploymentSkills.EmploymentSkillID = Insert(objEmploymentSkills);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objEmploymentSkills.EmploymentSkillID = -1;
            }

            return objEmploymentSkills.EmploymentSkillID;
        }

        public int UpdateSkill(EmploymentSkills objEmploymentSkills)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "CompanyName", "IsUnemployed", "SelfEmploymentIncome", "AgricultureIncome",
                                                            "WageIncome", "OtherIncome",
                                                            "FamilyAgricultureIncome", "FamilySalaryIncome",
                                                            "FamilyForeignIncome", "FamilyBusinessIncome",
                                                            "FamilyOtherIncome", "FeedDurationTypeID",
                                                            "TrainingSubject", "TrainingDistrictID",
                                                            "TrainingVDCID", "TrainingWardNumber", "TrainingStratDate","TrainingReasonTypeID",
                                                            "KnowAboutTrainingID", "HavePreviousTraining",
                                                            "PreTrainingName", "PreTrainingYear",
                                                            "PreTrainingInstituteName", "PreTrainingPeriod",
                                                            "UpdatedBy", "UpdatedDate","TrainingRegistrationDate"
                                                            };
                rowsaffected = Update(objEmploymentSkills, UpdateProperties);

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
