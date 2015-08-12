using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_work_types")]
    public class WorkTypes : BaseDTO
    {
        [ColumnAttribute(Name = "WorkTypeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int WorkTypeID { get; set; }
        [ColumnAttribute(Name = "WorkTypeDesc", DbType = "VARCHAR NOT NULL")]
        public string WorkTypeDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
