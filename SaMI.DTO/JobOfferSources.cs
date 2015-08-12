using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_job_offer_sources")]
    public class JobOfferSources : BaseDTO
    {
        [ColumnAttribute(Name = "JobOfferSourceID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int JobOfferSourceID { get; set; }
        [ColumnAttribute(Name = "JobOfferSourceDesc", DbType = "VARCHAR NOT NULL")]
        public string JobOfferSourceDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
