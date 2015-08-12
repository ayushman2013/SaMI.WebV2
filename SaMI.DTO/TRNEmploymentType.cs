using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
namespace SaMI.DTO
{
    [TableAttribute(Name = "TRNEmploymentType")]
    public class TRNEmploymentType:TRNBaseDTO
    {
        [ColumnAttribute(Name="ID",DbType="INT NOT NULL", IsPrimaryKey=true)]
        public int EmployeeTypeID { get; set; }

        [ColumnAttribute(Name="EmploymentType", DbType="VARCHAR")]
        public String EmploymentType { get; set; }

        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
