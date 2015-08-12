using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using SaMI.DTO;
using SaMI.Business;


namespace Sync.Controllers
{
    public class ServiceProvidedPerSaMIController : ApiController
    {
        // GET api/serviceprovidedpersami
        public IEnumerable<ServicesProvidedPerSaMI> Get(int Organization)
        {
            List<ServicesProvidedPerSaMI> listServicesProvidedPerSaMI = new List<ServicesProvidedPerSaMI>();

            DataView dvUsers = UserBO.GetUsersIDByOrganization(Organization);
            string TempCreatedBy = "";
            if (dvUsers.Count > 0)
            {
                foreach (DataRowView drvUsers in dvUsers)
                {
                    TempCreatedBy += "CreatedBy=" + drvUsers["UserID"] + " OR ";
                }
                string CreatedBy = TempCreatedBy.Remove(TempCreatedBy.Length - 3);
            
            DataView dvServicesProvidedPerSaMI = ServicesProvidedPerSaMIBO.GetServicesProvidedPerSaMIIDForSync(CreatedBy);
            foreach (DataRowView drvServicesProvidedPerSaMI in dvServicesProvidedPerSaMI)
            {
                ServicesProvidedPerSaMI ServicesProvidedPerSaMI = new ServicesProvidedPerSaMI();
                listServicesProvidedPerSaMI.Add(ServicesProvidedPerSaMIBO.GetServicesProvidedPerSaMIID(Convert.ToInt32(drvServicesProvidedPerSaMI["ServiceProvidedPerSaMIID"])));
            }
        }
            return listServicesProvidedPerSaMI;
        }

        // POST api/serviceprovidedpersami
        public ServicesProvidedPerSaMI Post(ServicesProvidedPerSaMI ServicesProvidedPerSaMI)
        {
            if (ServicesProvidedPerSaMI.GUID > 0)
            {
                ServicesProvidedPerSaMI.SyncStatus = 1;
                ServicesProvidedPerSaMI.ServiceProvidedPerSaMIID = ServicesProvidedPerSaMI.GUID;
                int rowResult = ServicesProvidedPerSaMIBO.UpdateServiceProvidedPerSaMI(ServicesProvidedPerSaMI);

                //Return Back to The Client               
                return ServicesProvidedPerSaMI;
            }
            else
            {
               
                ServicesProvidedPerSaMI.SyncStatus = 1;
                int rowResult = ServicesProvidedPerSaMIBO.InsertServiceProvidedPerSaMI(ServicesProvidedPerSaMI);
                ServicesProvidedPerSaMI.ServiceProvidedPerSaMIID = rowResult;
                //Return Back to The Client               
                return ServicesProvidedPerSaMI;
            }
        }

       
    }
}
