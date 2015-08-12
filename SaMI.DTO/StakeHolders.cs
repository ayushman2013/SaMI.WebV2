using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_stakeholders")]
    public class StakeHolders : BaseDTO
    {
        [ColumnAttribute(Name = "StakeHolderID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int StakeHolderID { get; set; }
        [ColumnAttribute(Name = "StakeHolderName", DbType = "VARCHAR NOT NULL")]
        public string StakeHolderName { get; set; }
    }
}
