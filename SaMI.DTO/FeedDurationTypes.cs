using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_feed_duration_types")]
    public class FeedDurationTypes : BaseDTO
    {
        [ColumnAttribute(Name = "FeedDurationTypeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int FeedDurationTypeID { get; set; }
        [ColumnAttribute(Name = "FeedDurationTypeDesc", DbType = "VARCHAR NOT NULL")]
        public string FeedDurationTypeDesc { get; set; }
    }
}
