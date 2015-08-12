using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using SaMI.Business;
using SaMI.DTO;

namespace Sync.Controllers
{
    public class ICRecommendationsController : ApiController
    {
        // GET api/icrecommendations
        public IEnumerable<ICRecommendations> Get()
        {

            List<ICRecommendations> listICRecommendations = new List<ICRecommendations>();
            DataView dvICRecommendations = ICRecommendationsBO.GetICRecommendationsIDForSync();
            foreach (DataRowView drvICRecommendations in dvICRecommendations)
            {
                ICRecommendations ICRecommendations = new ICRecommendations();
                listICRecommendations.Add(ICRecommendationsBO.GetICRecommendations(Convert.ToInt32(drvICRecommendations["ICRecommendationID"])));
            }
            return listICRecommendations;
        }

        // POST api/icrecommendations
        public ICRecommendations Post(ICRecommendations ICRecommendations)
        {
            if (ICRecommendations.GUID > 0)
            {
                ICRecommendations.ICRecommendationID = ICRecommendations.GUID;
                int rowResult = ICRecommendationsBO.UpdateICRecommendations(ICRecommendations);
                //Return Back to The Client               
                return ICRecommendations;
            }
            else
            {
                int rowResult = ICRecommendationsBO.InsertICRecommendations(ICRecommendations);

                //Return Back to The Client               
                return ICRecommendations;
            }
        }
    }
}
