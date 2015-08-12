using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_ethnicity")]
    public class Ethnicity : BaseDTO
    {
        [ColumnAttribute(Name = "EthnicityID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int EthnicityID { get; set; }
        [ColumnAttribute(Name = "EthnicityName", DbType = "VARCHAR NOT NULL")]
        public string EthnicityName { get; set; }
        [ColumnAttribute(Name = "EthnicityNameNP", DbType = "VARCHAR")]
        public string Category { get; set; }
        [ColumnAttribute(Name = "ValidRegions", DbType = "VARCHAR NOT NULL")]
        public string ValidRegions { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
