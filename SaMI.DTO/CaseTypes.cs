using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_case_types")]
    public class CaseTypes : BaseDTO
    {
        [ColumnAttribute(Name = "CaseTypeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CaseTypeID { get; set; }
        [ColumnAttribute(Name = "CaseTypeDesc", DbType = "VARCHAR NOT NULL")]
        public string CaseTypeDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

    }
}
