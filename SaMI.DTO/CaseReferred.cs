using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_case_referred")]
   public class CaseReferred:BaseDTO
    {
        [ColumnAttribute(Name = "CaseReferredID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CaseReferredID { get; set; }

        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }

        [ColumnAttribute(Name = "ReferStatus", DbType = "TINYINT NOT NULL")]
        public int ReferStatus { get; set; }

    }
}
