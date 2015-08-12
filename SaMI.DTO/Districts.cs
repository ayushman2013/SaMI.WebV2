using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_districts")]
    public class Districts
    {
        [ColumnAttribute(Name = "DistrictID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int DistrictID { get; set; }
        [ColumnAttribute(Name = "DistrictName", DbType = "VARCHAR NOT NULL")]
        public string DistrictName { get; set; }
        [ColumnAttribute(Name = "ZoneID", DbType = "INT")]
        public int ZoneID { get; set; }
        [ColumnAttribute(Name = "DistrictCode", DbType = "VARCHAR NOT NULL")]
        public string DistrictCode { get; set; }

        [ColumnAttribute(Name = "GUID", DbType = "INT")]
        public int GUID { get; set; }
        [ColumnAttribute(Name = "SyncStatus", DbType = "INT")]
        public int SyncStatus { get; set; }
    }
}
