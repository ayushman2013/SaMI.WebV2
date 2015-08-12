using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_visit_frequencies")]
    public class VisitFrequencies : BaseDTO
    {
        [ColumnAttribute(Name = "VisitFrequencyID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int VisitFrequencyID { get; set; }
        [ColumnAttribute(Name = "VisitFrequencyDesc", DbType = "VARCHAR NOT NULL")]
        public string VisitFrequencyDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
