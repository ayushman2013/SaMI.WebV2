using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace SaMI.DTO
{
    [TableAttribute(Name = "tbl_ic_recommendations_per_service")]
    public class ICRecommendationsPerService
    {
        [ColumnAttribute(Name = "ICRecommendationsPerServiceID", DbType = "INT NOT NULL", IsPrimaryKey = true)]
        public int ICRecommendationsPerServiceID { get; set; }
        [ColumnAttribute(Name = "ServiceProvidedPerSaMIID", DbType = "INT NOT NULL")]
        public int ServiceProvidedPerSaMIID { get; set; }
        [ColumnAttribute(Name = "ICRecommendationID", DbType = "INT NOT NULL")]
        public int ICRecommendationID { get; set; }
    }
}
