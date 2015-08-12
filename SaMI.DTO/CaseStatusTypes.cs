using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_case_status_types")]
    public class CaseStatusTypes : BaseDTO
    {
        [ColumnAttribute(Name = "CaseStatusTypeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CaseStatusTypeID { get; set; }
        [ColumnAttribute(Name = "CaseStatusTypeDesc", DbType = "VARCHAR NOT NULL")]
        public string CaseStatusTypeDesc { get; set; }
        [ColumnAttribute(Name = "CaseStatusTypeCode", DbType = "VARCHAR NOT NULL")]
        public string CaseStatusTypeCode { get; set; }
    }
}
