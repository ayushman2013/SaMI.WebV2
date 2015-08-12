using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_stay_duration")]
   public class StayDurationDTO : BaseDTO
    {
        [ColumnAttribute(Name = "StayDurationID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int StayDurationID { get; set; }
        [ColumnAttribute(Name = "StayDurationDesc", DbType = "VARCHAR NOT NULL")]
        public string StayDurationDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT NOT NULL")]
        public int Status { get; set; }
    }
}
