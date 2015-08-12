using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_visit_reason")]
   public class VisitReasonDTO : BaseDTO
    {
        [ColumnAttribute(Name = "VisitReasonID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int VisitReasonID { get; set; }
        [ColumnAttribute(Name = "VisitReasonDesc", DbType = "VARCHAR NOT NULL")]
        public string VisitReasonDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT NOT NULL")]
        public int Status { get; set; }
    }
}
