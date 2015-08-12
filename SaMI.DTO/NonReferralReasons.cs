using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_non_referral_reasons")]
    public class NonReferralReasons : BaseDTO
    {
        [ColumnAttribute(Name = "NonReferralReasonID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int NonReferralReasonID { get; set; }
        [ColumnAttribute(Name = "NonReferralReasonDesc", DbType = "VARCHAR NOT NULL")]
        public string NonReferralReasonDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
