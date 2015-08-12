using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_payment_ranges")]
    public class PaymentRanges : BaseDTO
    {
        [ColumnAttribute(Name = "PaymentRangeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int PaymentRangeID { get; set; }
        [ColumnAttribute(Name = "PaymentRangeDesc", DbType = "VARCHAR NOT NULL")]
        public string PaymentRangeDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
