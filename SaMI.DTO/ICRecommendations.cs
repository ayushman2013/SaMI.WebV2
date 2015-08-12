using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
     [TableAttribute(Name = "tbl_ic_recommendations")]
    public class ICRecommendations : BaseDTO
    {
        [ColumnAttribute(Name = "ICRecommendationID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
         public int ICRecommendationID { get; set; }
        [ColumnAttribute(Name = "ICRecommendationDesc", DbType = "VARCHAR NOT NULL")]
        public string ICRecommendationDesc { get; set; }
        [ColumnAttribute(Name = "Status", DbType = "INT")]
        public int Status { get; set; }
    }
}
