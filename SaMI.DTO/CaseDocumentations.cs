using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_case_documentations")]
    public class CaseDocumentations : BaseDTO
    {
        [ColumnAttribute(Name = "CaseDocumentationID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CaseDocumentationID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT")]
        public int? SaMIProfileID { get; set; }
        
        [ColumnAttribute(Name = "DistrictID", DbType = "INT NOT NULL")]
        public int DistrictID { get; set; }

        
        [ColumnAttribute(Name = "ReferralToID", DbType = "INT NOT NULL")]
        public int ReferralToID { get; set; }
        [ColumnAttribute(Name = "NonReferredReasonID", DbType = "INT")]
        public int? NonReferredReasonID { get; set; }
        [ColumnAttribute(Name = "ReferralStatusID", DbType = "INT NOT NULL")]
        public int ReferralStatusID { get; set; }

        [ColumnAttribute(Name = "DateOfReferral", DbType = "DATETIME NOT NULL")]
        public DateTime DateOfReferral { get; set; }
        [ColumnAttribute(Name = "IsDifficultyFaced", DbType = "TINYINT NOT NULL")]
        public int IsDifficultyFaced { get; set; }

        [ColumnAttribute(Name = "DifficultyFacedRemarks", DbType = "VARCHAR")]
        public String DifficultyFacedRemarks { get; set; }

        
    }
}
