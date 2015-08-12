using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_evidence_types")]
    public class EvidenceTypes : BaseDTO
    {
        [ColumnAttribute(Name = "EvidenceTypeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int EvidenceTypeID { get; set; }
        [ColumnAttribute(Name = "EvidenceTypeDesc", DbType = "VARCHAR NOT NULL")]
        public string EvidenceTypeDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
