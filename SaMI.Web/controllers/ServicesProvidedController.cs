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
    public class ServicesProvidedController : ApiController
    {
        // GET api/servicesprovided
        public IEnumerable<ServicesProvided> Get()
        {
            List<ServicesProvided> listServicesProvided = new List<ServicesProvided>();
            DataView dvServicesProvided = ServicesProvidedBO.GetServicesProvidedIDForSync();
            foreach (DataRowView drvServicesProvided in dvServicesProvided)
            {
                ServicesProvided ServicesProvided = new ServicesProvided();
                listServicesProvided.Add(ServicesProvidedBO.GetServicesProvided(Convert.ToInt32(drvServicesProvided["ServiceProvidedID"])));
            }
            return listServicesProvided;
        }

        // POST api/servicesprovided
        public ServicesProvided Post(ServicesProvided ServicesProvided)
        {
            if (ServicesProvided.GUID > 0)
            {
                ServicesProvided.ServiceProvidedID = ServicesProvided.GUID;
                int rowResult = ServicesProvidedBO.UpdateServicesProvided(ServicesProvided);

                //Return Back to The Client               
                return ServicesProvided;
            }
            else
            {                
                int rowResult = ServicesProvidedBO.InsertServicesProvided(ServicesProvided);

                //Return Back to The Client               
                return ServicesProvided;
            }
        }

    }
}
