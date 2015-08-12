using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_follow_up_per_services")]
    public class FollowUpPerServices : BaseDTO
    {
        [ColumnAttribute(Name = "FollowUpPerServiceID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int FollowUpPerServiceID { get; set; }
        [ColumnAttribute(Name = "ServiceProvidedPerSaMIID", DbType = "INT NOT NULL")]
        public int ServiceProvidedPerSaMIID { get; set; }
        [ColumnAttribute(Name = "ICFollowUpRequired", DbType = "INT NOT NULL")]
        public int ICFollowUpRequired { get; set; }
        [ColumnAttribute(Name = "FollowUpID", DbType = "VARCHAR")]
        public String FollowUpID { get; set; }        
        [ColumnAttribute(Name = "DifficultReceipt", DbType = "INT")]
        public int? DifficultReceipt { get; set; }
        [ColumnAttribute(Name = "DifficultOther", DbType = "INT")]
        public int? DifficultOther { get; set; }
        [ColumnAttribute(Name = "NonComplianceFamilyReason", DbType = "INT")]
        public int? NonComplianceFamilyReason { get; set; }
        [ColumnAttribute(Name = "ICRecommendationID", DbType = "VARCHAR")]
        public String ICRecommendationID { get; set; }
        [ColumnAttribute(Name = "CounselorDifficultyID", DbType = "INT NOT NULL")]
        public int CounselorDifficultyID { get; set; }
        [ColumnAttribute(Name = "FurtherFollowUpID", DbType = "INT")]
        public int? FurtherFollowUpID { get; set; }
        [ColumnAttribute(Name = "FurtherFollowUpRequired", DbType = "INT")]
        public int? FurtherFollowUpRequired { get; set; }
    }
}
