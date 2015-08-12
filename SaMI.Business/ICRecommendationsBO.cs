using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class ICRecommendationsBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new ICRecommendationsDAO().SelectAll(Select);

        }
        
        public static int InsertICRecommendations(ICRecommendations objICRecommendations)
        {
            return new ICRecommendationsDAO().InsertICRecommendations(objICRecommendations);
        }
        public static ICRecommendations GetICRecommendations(int ICRecommendationID)
        {
            ICRecommendations objICRecommendations = new ICRecommendations();
            return (ICRecommendations)(new ICRecommendationsDAO().FillDTO(objICRecommendations, "ICRecommendationID=" + ICRecommendationID));
        }
        public static int UpdateICRecommendations(ICRecommendations objICRecommendations)
        {
            return new ICRecommendationsDAO().UpdateICRecommendations(objICRecommendations);
        }
        public static int Delete(int ICRecommendationID)
        {
            return new ICRecommendationsDAO().Delete("ICRecommendationID=" + ICRecommendationID);
        }

        public static int DeleteICRecommendations(ICRecommendations objICRecommendations)
        {
            return new ICRecommendationsDAO().DeleteICRecommendations(objICRecommendations);
        }

        public static List<int> SelectICRecommendations(int SaMIProfileID)
        {
            List<int> lstICRecommendations = new List<int>();
            DataView dv = new ICRecommendationsDAO().SelectICRecommendations(SaMIProfileID);

            if (dv.Count > 0)
            {
                String ICRecommendations = dv.Table.Rows[0]["ICRecommendationID"].ToString();
                if (!string.IsNullOrEmpty(ICRecommendations))
                {
                    string[] Recommendations = ICRecommendations.Split(',');
                    foreach (string Recommendation in Recommendations)
                    {
                        if (Recommendation != string.Empty)
                            lstICRecommendations.Add(Convert.ToInt32(Recommendation));
                    }
                }

            }

            return lstICRecommendations;
        }

        public static DataView GetICRecommendationsIDForSync()
        {
            return new ICRecommendationsDAO().SelectICRecommendationsIDForSync();

        }
    }
}
