using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_non_followup_reasons")]
    public class NonFollowUpReasons : BaseDTO
    {
        [ColumnAttribute(Name = "NonFollowUpReasonID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int NonFollowUpReasonID { get; set; }
        [ColumnAttribute(Name = "NonFollowUpReasonDesc", DbType = "VARCHAR NOT NULL")]
        public string NonFollowUpReasonDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
