using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_occupation_types")]
    public class OccupationTypes : BaseDTO
    {
        [ColumnAttribute(Name = "OccupationTypeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int OccupationTypeID { get; set; }
        [ColumnAttribute(Name = "OccupationTypeDesc", DbType = "VARCHAR NOT NULL")]
        public string OccupationTypeDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

    }
}
