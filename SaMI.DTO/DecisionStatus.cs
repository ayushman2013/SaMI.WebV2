using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_decision_status")]
    public class DecisionStatus : BaseDTO
    {
        [ColumnAttribute(Name = "DecisionStatusID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int DecisionStatusID { get; set; }
        [ColumnAttribute(Name = "DecisionStatusDesc", DbType = "VARCHAR NOT NULL")]
        public string DecisionStatusDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
