using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_employment_skills")]
    public class EmploymentSkills : BaseDTO
    {
        [ColumnAttribute(Name = "EmploymentSkillID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int EmploymentSkillID { get; set; }
       
        [ColumnAttribute(Name = "IsUnemployed", DbType = "INT NOT NULL")]
        public int IsUnemployed { get; set; }

        [ColumnAttribute(Name = "SelfEmploymentIncome", DbType = "INT")]
        public int? SelfEmploymentIncome { get; set; }
        [ColumnAttribute(Name = "AgricultureIncome", DbType = "INT")]
        public int? AgricultureIncome { get; set; }
        [ColumnAttribute(Name = "WageIncome", DbType = "INT")]
        public int? WageIncome { get; set; }
        [ColumnAttribute(Name = "OtherIncome", DbType = "INT")]
        public int? OtherIncome { get; set; }
        [ColumnAttribute(Name = "FamilyWageIncome", DbType = "INT")]
        public int? FamilyWageIncome { get; set; }
        [ColumnAttribute(Name = "FamilyAgricultureIncome", DbType = "INT")]
        public int? FamilyAgricultureIncome { get; set; }
        [ColumnAttribute(Name = "FamilySalaryIncome", DbType = "INT")]
        public int? FamilySalaryIncome { get; set; }
        [ColumnAttribute(Name = "FamilyForeignIncome", DbType = "INT")]
        public int? FamilyForeignIncome { get; set; }
        [ColumnAttribute(Name = "FamilyBusinessIncome", DbType = "INT")]
        public int? FamilyBusinessIncome { get; set; }
        [ColumnAttribute(Name = "FamilyOtherIncome", DbType = "INT")]
        public int? FamilyOtherIncome { get; set; }
        [ColumnAttribute(Name = "FeedDurationTypeID", DbType = "INT NOT NULL")]
        public int FeedDurationTypeID { get; set; }

        [ColumnAttribute(Name = "TrainingSubject", DbType = "VARCHAR NOT NULL")]
        public String TrainingSubject { get; set; }
        [ColumnAttribute(Name = "TrainingDistrictID", DbType = "INT NOT NULL")]
        public int TrainingDistrictID { get; set; }
        [ColumnAttribute(Name = "TrainingVDCID", DbType = "INT NOT NULL")]
        public int TrainingVDCID { get; set; }
        [ColumnAttribute(Name = "TrainingWardNumber", DbType = "VARCHAR NOT NULL")]
        public String TrainingWardNumber { get; set; }
        [ColumnAttribute(Name = "TrainingStratDate", DbType = "DATETIME NOT NULL")]
        public DateTime TrainingStratDate { get; set; }
        [ColumnAttribute(Name = "TrainingReasonTypeID", DbType = "INT NOT NULL")]
        public int TrainingReasonTypeID { get; set; }
        [ColumnAttribute(Name = "KnowAboutTrainingID", DbType = "INT NOT NULL")]
        public int KnowAboutTrainingID { get; set; }
        
        [ColumnAttribute(Name = "HavePreviousTraining", DbType = "INT NOT NULL")]
        public int HavePreviousTraining { get; set; }
        [ColumnAttribute(Name = "PreTrainingName", DbType = "VARCHAR NOT NULL")]
        public String PreTrainingName { get; set; }
        [ColumnAttribute(Name = "PreTrainingYear", DbType = "VARCHAR NOT NULL")]
        public String PreTrainingYear { get; set; }
        [ColumnAttribute(Name = "PreTrainingInstituteName", DbType = "VARCHAR NOT NULL")]
        public String PreTrainingInstituteName { get; set; }
        [ColumnAttribute(Name = "PreTrainingPeriod", DbType = "VARCHAR NOT NULL")]
        public String PreTrainingPeriod { get; set; }

        [ColumnAttribute(Name = "TrainingRegistrationDate", DbType = "DATETIME NOT NULL")]
        public DateTime TrainingRegistrationDate { get; set; }

        [ColumnAttribute(Name = "FirstName", DbType = "VARCHAR NOT NULL")]
        public String FirstName { get; set; }
        [ColumnAttribute(Name = "MiddleName", DbType = "VARCHAR")]
        public String MiddleName { get; set; }
        [ColumnAttribute(Name = "LastName", DbType = "VARCHAR NOT NULL")]
        public String LastName { get; set; }
        [ColumnAttribute(Name = "DistrictID", DbType = "INT NOT NULL")]
        public int DistrictID { get; set; }
        [ColumnAttribute(Name = "VDCID", DbType = "INT NOT NULL")]
        public int VDCID { get; set; }

        
    }
}
