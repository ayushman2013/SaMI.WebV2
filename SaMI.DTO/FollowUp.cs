using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_follow_up")]
    public class FollowUp : BaseDTO
    {
        [ColumnAttribute(Name = "FollowUpID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int FollowUpID { get; set; }
        [ColumnAttribute(Name = "FollowUpDesc", DbType = "VARCHAR NOT NULL")]
        public string FollowUpDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
