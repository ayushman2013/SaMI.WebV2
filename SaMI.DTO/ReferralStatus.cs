using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;
namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_referral_status")]
    public class ReferralStatus : BaseDTO
    {
        [ColumnAttribute(Name = "ReferralStausID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int ReferralStausID { get; set; }
        [ColumnAttribute(Name = "ReferralStatusDesc", DbType = "VARCHAR NOT NULL")]
        public string ReferralStatusDesc { get; set; }
    }
}
