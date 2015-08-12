using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_phone_follow_up")]
    public class PhoneFollowUp : BaseDTO
    {
        [ColumnAttribute(Name = "PhoneFollowUpID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int PhoneFollowUpID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "LeftForFE", DbType = "INT NOT NULL")]
        public int LeftForFE { get; set; }
        [ColumnAttribute(Name = "VisitorsCurrentStatus", DbType = "VARCHAR")]
        public string VisitorsCurrentStatus { get; set; }
        [ColumnAttribute(Name = "VisitorsOtherStatus", DbType = "VARCHAR")]
        public string VisitorsOtherStatus { get; set; }
        [ColumnAttribute(Name = "ContractNumber", DbType = "VARCHAR")]
        public string ContractNumber { get; set; }
        [ColumnAttribute(Name = "MigratedCountry", DbType = "VARCHAR")]
        public string MigratedCountry { get; set; }
        [ColumnAttribute(Name = "MigratedDate", DbType = "VARCHAR")]
        public String MigratedDate { get; set; }
        [ColumnAttribute(Name = "MigratedAfterTraining", DbType = "INT")]
        public int MigratedAfterTraining { get; set; }
        [ColumnAttribute(Name = "ManpowerAgent", DbType = "VARCHAR")]
        public string ManpowerAgent { get; set; }
        [ColumnAttribute(Name = "AmountPaidforFE", DbType = "VARCHAR")]
        public string AmountPaidforFE { get; set; }
        [ColumnAttribute(Name = "SourceOfInvestment", DbType = "VARCHAR")]
        public string SourceOfInvestment { get; set; }
        [ColumnAttribute(Name = "ReceiptReceived", DbType = "INT")]
        public int? ReceiptReceived { get; set; }
        [ColumnAttribute(Name = "LeftDocumentBeforeDeparture", DbType = "INT")]
        public int? LeftDocumentBeforeDeparture { get; set; }
        [ColumnAttribute(Name = "SameWorkAsAgreement", DbType = "INT")]
        public int? SameWorkAsAgreement { get; set; }
        [ColumnAttribute(Name = "SameSalaryAsAgreement", DbType = "INT")]
        public int? SameSalaryAsAgreement { get; set; }
        [ColumnAttribute(Name = "AdditionalInfo", DbType = "VARCHAR")]
        public String AdditionalInfo { get; set; }
        [ColumnAttribute(Name = "Recommendation", DbType = "VARCHAR")]
        public String Recommendation { get; set; }
        [ColumnAttribute(Name = "InformantsName", DbType = "VARCHAR")]
        public String InformantsName { get; set; }
        [ColumnAttribute(Name = "MigrantRelation", DbType = "VARCHAR")]
        public string MigrantRelation { get; set; }
        [ColumnAttribute(Name = "FollowUpDate", DbType = "VARCHAR")]
        public string FollowUpDate { get; set; }
        [ColumnAttribute(Name = "Remarks", DbType = "VARCHAR")]
        public string Remarks { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT NOT NULL")]
        public int Status { get; set; }
    }
}
