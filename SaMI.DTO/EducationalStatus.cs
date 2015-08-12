using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_educational_status")]
    public class EducationalStatus : BaseDTO
    {
        [ColumnAttribute(Name = "EducationalStatusID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int EducationalStatusID { get; set; }
        [ColumnAttribute(Name = "EducationalStatusDesc", DbType = "VARCHAR NOT NULL")]
        public string EducationalStatusDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

    }
}
