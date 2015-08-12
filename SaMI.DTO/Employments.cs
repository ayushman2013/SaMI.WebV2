using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_employments")]
    public class Employments : BaseDTO
    {
        [ColumnAttribute(Name = "EmploymentID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int EmploymentID { get; set; }
        [ColumnAttribute(Name = "EmploymentSkillID", DbType = "INT NOT NULL")]
        public int EmploymentSkillID { get; set; }
        [ColumnAttribute(Name = "CompanyName", DbType = "VARCHAR NOT NULL")]
        public String CompanyName { get; set; }
        [ColumnAttribute(Name = "CountryID", DbType = "INT NOT NULL")]
        public int CountryID { get; set; }
        [ColumnAttribute(Name = "EmploymentStartDate", DbType = "DATETIME NOT NULL")]
        public DateTime EmploymentStartDate { get; set; }
        [ColumnAttribute(Name = "WorkTypeID", DbType = "INT NOT NULL")]
        public int WorkTypeID { get; set; }
        [ColumnAttribute(Name = "IncomeRangeID", DbType = "INT NOT NULL")]
        public int IncomeRangeID { get; set; }
       
    }
}
