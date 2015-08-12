using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_other_followup_per_service")]
    public class OtherFollowupPerService : BaseDTO
    {
        

        [ColumnAttribute(Name = "OtherFollowUpPerServiceID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int OtherFollowUpPerServiceID { get; set; }
        [ColumnAttribute(Name = "ServiceProvidedPerSaMIID", DbType = "INT NOT NULL")]
        public int ServiceProvidedPerSaMIID { get; set; }
        [ColumnAttribute(Name = "FollowUpDate", DbType = "DATETIME NOT NULL")]
        public DateTime FollowUpDate { get; set; }
        [ColumnAttribute(Name = "NonFollowUpReasonID", DbType = "INT")]
        public int? NonFollowUpReasonID { get; set; }
        [ColumnAttribute(Name = "IsFollowUpComplied", DbType = "INT")]
        public int? IsFollowUpComplied { get; set; }
        [ColumnAttribute(Name = "IsFollowUpDidNotComply", DbType = "INT")]
        public int? IsFollowUpDidNotComply { get; set; }
        [ColumnAttribute(Name = "IsReasonRecommendation", DbType = "INT")]
        public int? IsReasonRecommendation { get; set; }
        [ColumnAttribute(Name = "IsReasonReceipt", DbType = "INT")]
        public int? IsReasonReceipt { get; set; }
        [ColumnAttribute(Name = "IsReasonOther", DbType = "INT")]
        public int? IsReasonOther { get; set; }
        [ColumnAttribute(Name = "IsReasonFamilyMember", DbType = "INT")]
        public int? IsReasonFamilyMember { get; set; }
        [ColumnAttribute(Name = "Remarks", DbType = "VARCHAR")]
        public String Remarks { get; set; }

    }
}
