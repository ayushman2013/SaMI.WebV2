using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_countries")]
    public class Countries : BaseDTO
    {
        [ColumnAttribute(Name = "CountryID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int CountryID { get; set; }
        [ColumnAttribute(Name = "CountryName", DbType = "VARCHAR NOT NULL")]
        public string CountryName { get; set; }
        [ColumnAttribute(Name = "CountryCode", DbType = "VARCHAR")]
        public string CountryCode { get; set; }
        [ColumnAttribute(Name = "CountryGroup", DbType = "VARCHAR")]
        public string CountryGroup { get; set; }
    }
}
