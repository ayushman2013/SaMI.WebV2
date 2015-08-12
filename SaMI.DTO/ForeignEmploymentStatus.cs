using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_foreign_employment_status")]
    public class ForeignEmploymentStatus : BaseDTO
    {
        [ColumnAttribute(Name = "ForeignEmploymentStatusID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int ForeignEmploymentStatusID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "DecisionStatusID", DbType = "INT NOT NULL")]
        public int DecisionStatusID { get; set; }
        [ColumnAttribute(Name = "PassportStatusID", DbType = "INT NOT NULL")]
        public int PassportStatusID { get; set; }
        [ColumnAttribute(Name = "HaveJobOffer", DbType = "TINYINT NOT NULL")]
        public int HaveJobOffer { get; set; }

        [ColumnAttribute(Name = "JobOfferSourceID", DbType = "INT")]
        public int? JobOfferSourceID { get; set; }
        [ColumnAttribute(Name = "JobOfferedTypeID", DbType = "INT")]
        public int? JobOfferedTypeID { get; set; }
        [ColumnAttribute(Name = "WorkTypeID", DbType = "INT")]
        public int? WorkTypeID { get; set; }
        [ColumnAttribute(Name = "MadePaymentAmount", DbType = "VARCHAR")]
        public String MadePaymentAmount { get; set; }
        [ColumnAttribute(Name = "AskedPaymentAmount", DbType = "VARCHAR")]
        public String AskedPaymentAmount { get; set; }

        [ColumnAttribute(Name = "ICKnowledgeID", DbType = "INT NOT NULL")]
        public int ICKnowledgeID { get; set; }

        
        [ColumnAttribute(Name = "NothingAskedYet", DbType = "TINYINT NOT NULL")]
        public int NothingAskedYet { get; set; }
        [ColumnAttribute(Name = "HavePaymentReceipt", DbType = "TINYINT NOT NULL")]
        public int HavePaymentReceipt { get; set; }
        [ColumnAttribute(Name = "ReceiptPaymentAmount", DbType = "VARCHAR")]
        public String ReceiptPaymentAmount { get; set; }
        [ColumnAttribute(Name = "CountryID", DbType = "INT")]
        public int CountryID { get; set; }

        [ColumnAttribute(Name = "ReferToFSkill", DbType = "TINYINT")]
        public int ReferToFSkill { get; set; }
        [ColumnAttribute(Name = "ReferToCase", DbType = "TINYINT")]
        public int ReferToCase { get; set; }


        //[ColumnAttribute(Name = "PotentialAndNonPotentialMigrant", DbType = "TINYINT")]
        //public int? PotentialAndNonPotentialMigrant { get; set; }
    }
}
