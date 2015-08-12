using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNTrainee")]
    public class TRNTrainee : TRNBaseDTO
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int TraineeID { get; set; }

        [ColumnAttribute(Name = "EducationLevelID", DbType = "INT")]
        public int EducationLevelID { get; set; }

        [ColumnAttribute(Name = "InformationSourceID", DbType = "INT")]
        public int InformationSourceID { get; set; }

        [ColumnAttribute(Name = "VDCID", DbType = "INT")]
        public int VDCID { get; set; }

        [ColumnAttribute(Name = "DistrictID", DbType = "INT")]
        public int DistrictID { get; set; }

        [ColumnAttribute(Name = "EventID", DbType = "INT")]
        public int EventID { get; set; }

        [ColumnAttribute(Name = "EthnicityID", DbType = "INT")]
        public int EthnicityID { get; set; }

        [ColumnAttribute(Name = "FeedDurationTypeID", DbType = "INT")]
        public int? FeedDurationTypeID { get; set; }

        [ColumnAttribute(Name = "CitizenshipIssueDistictID", DbType = "INT")]
        public int CitizenshipIssueDistictID { get; set; }

        [ColumnAttribute(Name = "FirstName", DbType = "VARCHAR")]
        public String FirstName { get; set; }

        [ColumnAttribute(Name = "LastName", DbType = "VARCHAR")]
        public String LastName { get; set; }

        [ColumnAttribute(Name = "Gender", DbType = "VARCHAR")]
        public String Gender { get; set; }

        [ColumnAttribute(Name = "MaritalStatus", DbType = "VARCHAR")]
        public String MaritalStatus { get; set; }

        [ColumnAttribute(Name = "DOBAD", DbType = "VARCHAR")]
        public String DateOfBirthAD { get; set; }

        [ColumnAttribute(Name = "DOBBS", DbType = "VARCHAR")]
        public String DateOfBirthBS { get; set; }

        [ColumnAttribute(Name = "CurrentAge", DbType = "VARCHAR")]
        public String CurrentAge { get; set; }

        [ColumnAttribute(Name = "SpecialCase", DbType = "VARCHAR")]
        public String SpecialCase { get; set; }

        [ColumnAttribute(Name = "Tole", DbType = "VARCHAR")]
        public String Tole { get; set; }       

        [ColumnAttribute(Name = "WardNumber", DbType = "VARCHAR")]
        public String WardNumber { get; set; }

        [ColumnAttribute(Name = "PhoneNumber", DbType = "VARCHAR")]
        public String PhoneNumber { get; set; }

        [ColumnAttribute(Name = "MobileNumber", DbType = "VARCHAR")]
        public String MobileNumber { get; set; }

        [ColumnAttribute(Name = "CitizenshipNumber", DbType = "VARCHAR")]
        public String CitizenshipNumber { get; set; }

        [ColumnAttribute(Name = "PassportNumber", DbType = "VARCHAR")]
        public String PassportNumber { get; set; }

        [ColumnAttribute(Name = "FatherName", DbType = "VARCHAR")]
        public String FatherName { get; set; }

        [ColumnAttribute(Name = "FatherTelephone", DbType = "VARCHAR")]
        public String FatherTelephone { get; set; }

        [ColumnAttribute(Name = "ContactPerson", DbType = "VARCHAR")]
        public String ContactPerson { get; set; }

        [ColumnAttribute(Name = "ContactPersonTelephone", DbType = "VARCHAR")]
        public String ContactPersonTelephone { get; set; }

        [ColumnAttribute(Name = "SelfEmployment", DbType = "DECIMAL")]
        public decimal? SelfEmployment { get; set; }

        [ColumnAttribute(Name = "Agriculture", DbType = "DECIMAL")]
        public decimal? Agriculture { get; set; }

        [ColumnAttribute(Name = "Wage", DbType = "DECIMAL")]
        public decimal? Wage { get; set; }

        [ColumnAttribute(Name = "ForeignEmploymentIncome", DbType = "DECIMAL")]
        public decimal? ForeignEmploymentIncome { get; set; }

        [ColumnAttribute(Name = "Other", DbType = "DECIMAL")]
        public decimal? Other { get; set; }

        [ColumnAttribute(Name = "Unemployment", DbType = "INT")]
        public int? Unemployment { get; set; }

        [ColumnAttribute(Name = "RegisteredDate", DbType = "DATE")]
        public DateTime RegisteredDate { get; set; }

        [ColumnAttribute(Name = "NoOfFamilyMember", DbType = "INT")]
        public int? NoOfFamilyMember { get; set; }

        [ColumnAttribute(Name = "Photo", DbType = "VARCHAR")]
        public String Photo { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

        [ColumnAttribute(Name = "ReferredBy", DbType = "VARCHAR")]
        public String ReferredBy { get; set; }

        [ColumnAttribute(Name = "ValidRegions", DbType = "VARCHAR")]
        public String ValidRegions { get; set; }

    }
}
