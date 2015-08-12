using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_case_referral_history")]
    public class CaseReferralHistory : BaseDTO
    {
        [ColumnAttribute(Name = "CaseReferralHistoryID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CaseReferralHistoryID { get; set; }
        [ColumnAttribute(Name = "CaseID", DbType = "INT NOT NULL")]
        public int CaseID { get; set; }
        [ColumnAttribute(Name = "PreviousPartnerID", DbType = "INT NOT NULL")]
        public int PreviousPartnerID { get; set; }
        [ColumnAttribute(Name = "NewPartnerID", DbType = "INT NOT NULL")]
        public int NewPartnerID { get; set; }
        [ColumnAttribute(Name = "ReferralDate", DbType = "DATETIME NOT NULL")]
        public DateTime ReferralDate { get; set; }
        [ColumnAttribute(Name = "Remarks", DbType = "TEXT")]
        public String Remarks { get; set; }
    }
}
