using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNEmployment")]
    public class TRNEmployment : TRNBaseDTO
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int EmploymentID { get; set; }

        [ColumnAttribute(Name = "TraineeID", DbType = "INT")]
        public int TraineeID { get; set; }

        [ColumnAttribute(Name = "Organization", DbType = "VARCHAR")]
        public String Organization { get; set; }

        [ColumnAttribute(Name = "EmploymentTypeID", DbType = "INT")]
        public int? EmploymentTypeID { get; set; }

        [ColumnAttribute(Name = "EmploymentStatusID", DbType = "INT")]
        public int? EmploymentStatusID { get; set; }

        [ColumnAttribute(Name = "RecruitmentAgency", DbType = "VARCHAR")]
        public String RecruitmentAgency { get; set; }

        [ColumnAttribute(Name = "WorkDoneMonth", DbType = "VARCHAR")]
        public String WorkDoneMonth { get; set; }

        [ColumnAttribute(Name = "WorkDoneYear", DbType = "VARCHAR")]
        public String WorkDoneYear { get; set; }

        [ColumnAttribute(Name = "Salary", DbType = "VARCHAR")]
        public String Salary { get; set; }

        [ColumnAttribute(Name = "Currency", DbType = "VARCHAR")]
        public String Currency { get; set; }

        [ColumnAttribute(Name = "DepartureDate", DbType = "DATE")]
        public DateTime? DepartureDate { get; set; }

        [ColumnAttribute(Name = "ReturnDate", DbType = "DATE")]
        public DateTime? ReturnDate { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

        [ColumnAttribute(Name = "EmploymentPeriod", DbType = "VARCHAR")]
        public String EmploymentPeriod { get; set; }

        [ColumnAttribute(Name = "CountryID", DbType = "INT")]
        public int? CountryID { get; set; }
    }
}
