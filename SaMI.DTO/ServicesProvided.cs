using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_services_provided")]
    public class ServicesProvided : BaseDTO
    {
        [ColumnAttribute(Name = "ServiceProvidedID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int ServiceProvidedID { get; set; }
        [ColumnAttribute(Name = "ServiceProvidedDesc", DbType = "VARCHAR NOT NULL")]
        public string ServiceProvidedDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }

    }
}
