using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
namespace SaMI.DTO
{
     [TableAttribute(Name = "TRNEmploymentStatus")]
  public  class TRNEmploymentStatus:TRNBaseDTO
    {
        [ColumnAttribute(Name = "ID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int EmploymentStatusID { get; set; }

        [ColumnAttribute(Name = "EmploymentStatus", DbType = "VARCHAR")]
        public String EmploymentStatus { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
