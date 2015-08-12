using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SaMI.Business;
using SaMI.DTO;
using System.Data;



namespace Sync.Controllers
{
    public class EthnicityController : ApiController
    {
        // GET api/ethnicity
        public IEnumerable<Ethnicity> Get()
        {

            List<Ethnicity> listEthnicity = new List<Ethnicity>();
            DataView dvEthnicity =EthnicityBO.GetEthnicityIDForSync();
            foreach (DataRowView drvEthnicity in dvEthnicity)
            {
                listEthnicity.Add(EthnicityBO.GetEthnicity(Convert.ToInt32(drvEthnicity["EthnicityID"])));

            }
            return listEthnicity;
        }

        
        // POST api/ethnicity
        public Ethnicity Post(Ethnicity ethnicity)
        {
            if (ethnicity.GUID > 0)
            {
                ethnicity.EthnicityID = ethnicity.GUID;
                int rowResult = EthnicityBO.UpdateEthnicity(ethnicity);

                //Return Back to The Client               
                return ethnicity;
            }
            else
            {
                
                int rowResult = EthnicityBO.InsertEthnicity(ethnicity);

                //Return Back to The Client               
                return ethnicity;
            }
        }

    }
}
