using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_evidences_per_case")]
    public class EvidencesPerCase
    {
        [ColumnAttribute(Name = "EvidencesPerCaseID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int EvidencesPerCaseID { get; set; }
        [ColumnAttribute(Name = "EvidenceTypeID", DbType = "INT NOT NULL")]
        public int EvidenceTypeID { get; set; }
        [ColumnAttribute(Name = "CaseID", DbType = "INT NOT NULL")]
        public int CaseID { get; set; }
    }
}
