using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;
namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_referral_to")]
    public class ReferralTo : BaseDTO
    {
        [ColumnAttribute(Name = "ReferralToID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int ReferralToID { get; set; }
        [ColumnAttribute(Name = "ReferralToDesc", DbType = "VARCHAR NOT NULL")]
        public string ReferralToDesc { get; set; }
    }
}
