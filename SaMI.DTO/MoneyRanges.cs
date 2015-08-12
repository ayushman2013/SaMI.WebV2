using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;
namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_money_ranges")]
    public class MoneyRanges : BaseDTO
    {
        [ColumnAttribute(Name = "MoneyRangeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int MoneyRangeID { get; set; }
        [ColumnAttribute(Name = "MoneyRangeDesc", DbType = "VARCHAR NOT NULL")]
        public string MoneyRangeDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
