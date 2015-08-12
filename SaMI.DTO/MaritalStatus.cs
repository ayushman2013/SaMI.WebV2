using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_marital_status")]
    public class MaritalStatus : BaseDTO
    {
        [ColumnAttribute(Name = "MaritalStatusID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int MaritalStatusID { get; set; }
        [ColumnAttribute(Name = "MaritalStatusDesc", DbType = "VARCHAR NOT NULL")]
        public string MaritalStatusDesc { get; set; }
    }
}
