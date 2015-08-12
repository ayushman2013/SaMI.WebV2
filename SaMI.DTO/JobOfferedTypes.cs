using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_job_offered_types")]
    public class JobOfferedTypes : BaseDTO
    {
        [ColumnAttribute(Name = "JobOfferedTypeID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int JobOfferedTypeID { get; set; }
        [ColumnAttribute(Name = "JobOfferedTypeDesc", DbType = "VARCHAR NOT NULL")]
        public string JobOfferTypeDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
