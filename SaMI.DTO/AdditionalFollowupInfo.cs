using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_additional_followup_info")]
   public class AdditionalFollowupInfo : BaseDTO
    {

        [ColumnAttribute(Name = "AdditionalFollowUpInfoID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int AdditionalFollowUpInfoID { get; set; }
        [ColumnAttribute(Name = "AdditionalFollowUpInfoDesc", DbType = "VARCHAR NOT NULL")]
        public String AdditionalFollowUpInfoDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
