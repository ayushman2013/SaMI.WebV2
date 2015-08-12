using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "TRNCurrentEmployment")]
   public class TRNCurrentEmployment:TRNBaseDTO
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int EmploymentID { get; set; }

        [ColumnAttribute(Name = "TraineeID", DbType = "INT")]
        public int TraineeID { get; set; }

        [ColumnAttribute(Name = "CountryID", DbType = "INT")]
        public int? CountryID { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

        [ColumnAttribute(Name = "WorkingYear", DbType = "VARCHAR")]
        public String WorkingYear { get; set; }

        [ColumnAttribute(Name = "WorkingMonth", DbType = "VARCHAR")]
        public String WorkingMonth { get; set; }

        [ColumnAttribute(Name = "Occupation", DbType = "VARCHAR")]
        public String Occupation { get; set; }

        [ColumnAttribute(Name = "MonthlySalary", DbType = "VARCHAR")]
        public String MonthlySalary { get; set; }

        [ColumnAttribute(Name = "ReturnDate", DbType = "VARCHAR")]
        public String ReturnDate { get; set; }
    }
}
