using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_services_provided_per_SaMI")]
    public class ServicesProvidedPerSaMI : BaseDTO
    {
        [ColumnAttribute(Name = "ServiceProvidedPerSaMIID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int ServiceProvidedPerSaMIID { get; set; }
        [ColumnAttribute(Name = "SaMIProfileID", DbType = "INT NOT NULL")]
        public int SaMIProfileID { get; set; }
        [ColumnAttribute(Name = "VisitTimes", DbType = "VARCHAR NOT NULL")]
        public String VisitTimes { get; set; }
        [ColumnAttribute(Name = "ServiceProvidedID", DbType = "INT NOT NULL")]
        public int ServiceProvidedID { get; set; }
        
    }
}
