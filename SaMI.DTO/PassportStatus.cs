using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_passport_status")]
    public class PassportStatus : BaseDTO
    {
        [ColumnAttribute(Name = "PassportStatusID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int PassportStatusID { get; set; }
        [ColumnAttribute(Name = "PassportStatusDesc", DbType = "VARCHAR NOT NULL")]
        public string PassportStatusDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
