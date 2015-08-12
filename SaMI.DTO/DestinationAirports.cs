using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_destination_airports")]
    public class DestinationAirports : BaseDTO
    {
        [ColumnAttribute(Name = "DestinationAirportID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int DestinationAirportID { get; set; }
        [ColumnAttribute(Name = "DestinationAirportName", DbType = "VARCHAR NOT NULL")]
        public string DestinationAirportName { get; set; }
    }
}
