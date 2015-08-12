using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_VDC")]
    public class VDC
    {
        [ColumnAttribute(Name = "VDCID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int VDCID { get; set; }
        [ColumnAttribute(Name = "VDCName", DbType = "VARCHAR NOT NULL")]
        public String VDCName { get; set; }
        [ColumnAttribute(Name = "DistrictCode", DbType = "VARCHAR NOT NULL")]
        public String DistrictCode { get; set; }
    }
}
