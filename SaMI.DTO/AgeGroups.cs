using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_age_groups")]
    public class AgeGroups : BaseDTO
    {
        [ColumnAttribute(Name = "AgeGroupID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int AgeGroupID { get; set; }
        [ColumnAttribute(Name = "AgeGroupDesc", DbType = "VARCHAR NOT NULL")]
        public string AgeGroupDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
