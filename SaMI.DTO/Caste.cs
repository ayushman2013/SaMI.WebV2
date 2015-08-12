using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_caste")]
    public class Caste : BaseDTO
    {
        [ColumnAttribute(Name = "CasteID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int CasteID { get; set; }
        [ColumnAttribute(Name = "CasteName", DbType = "VARCHAR NOT NULL")]
        public string CasteName { get; set; }
        [ColumnAttribute(Name = "EthnicityID", DbType = "INT NOT NULL")]
        public int EthnicityID { get; set; }
        [ColumnAttribute(Name = "IsDiscriminated", DbType = "TINYINT NOT NULL")]
        public int IsDiscriminated { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
