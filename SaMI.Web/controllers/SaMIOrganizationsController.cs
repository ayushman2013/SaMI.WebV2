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
    public class SaMIOrganizationsController : ApiController
    {
        // GET api/samiorganizations
        public IEnumerable<SaMIOrganizations> Get()
        {
            List<SaMIOrganizations> listOrganizations = new List<SaMIOrganizations>();
            DataView dvSaMIOrganizations = SaMIOrganizationBO.GetSaMIOrganizationID();
            foreach (DataRowView drvOrganization in dvSaMIOrganizations)
            {
                listOrganizations.Add(SaMIOrganizationBO.GetSaMIOrganization(Convert.ToInt32(drvOrganization["SaMIOrganizationID"])));
            
            }
            return listOrganizations;
        }

        
        // POST api/samiorganizations
        public SaMIOrganizations Post(SaMIOrganizations objOrganization)
        {
            if (objOrganization.GUID > 0)
            {
                objOrganization.SaMIOrganizationID = objOrganization.GUID;
                int rowResult = SaMIOrganizationBO.UpdateSaMIOrganization(objOrganization);

                //Return Back to The Client               
                return objOrganization;
            }
            else
            {               
                
                int rowResult = SaMIOrganizationBO.InsertSaMIOrganization(objOrganization);

                //Return Back to The Client               
                return objOrganization;
            }
        }

       
    }
}
