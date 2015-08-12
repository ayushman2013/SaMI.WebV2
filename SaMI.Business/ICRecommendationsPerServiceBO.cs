using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class ICRecommendationsPerServiceBO
    {
        public static DataView GetAll(int ServiceProvidedPerSaMIID)
        {
            return new ICRecommendationsPerServiceDAO().SelectAll(ServiceProvidedPerSaMIID);
        }

        public static int InsertRecommendation(ICRecommendationsPerService objICRecommendationsPerService)
        {
            return new ICRecommendationsPerServiceDAO().InsertRecommendation(objICRecommendationsPerService);
        }

        public static int UpdateRecommendation(ICRecommendationsPerService objICRecommendationsPerService)
        {
            return new ICRecommendationsPerServiceDAO().UpdateRecommendation(objICRecommendationsPerService);
        }

        public static ICRecommendationsPerService GetICRecommendationsPerService(int ServiceProvidedPerSaMIID)
        {
            ICRecommendationsPerService objICRecommendationsPerServiceID = new ICRecommendationsPerService();
            return (ICRecommendationsPerService)(new ICRecommendationsPerServiceDAO().FillDTO(objICRecommendationsPerServiceID, "ServiceProvidedPerSaMIID=" + ServiceProvidedPerSaMIID));

        }
    }
}
