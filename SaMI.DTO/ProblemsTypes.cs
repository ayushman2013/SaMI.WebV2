using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_problem_types")]
    public class ProblemsTypes : BaseDTO
    {
        [ColumnAttribute(Name = "ProblemTypeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int ProblemTypeID { get; set; }
        [ColumnAttribute(Name = "ProblemTypeDesc", DbType = "VARCHAR NOT NULL")]
        public string ProblemTypeDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
