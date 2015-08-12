using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_zones")]
    public class Zones
    {
        [ColumnAttribute(Name = "ZoneID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int ZoneID { get; set; }
        [ColumnAttribute(Name = "ZoneName", DbType = "VARCHAR NOT NULL")]
        public string ZoneName { get; set; }
    }
}
