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
    public class AdditionalFollowupInfoPerServiceController : ApiController
    {
        // GET api/additionalfollowupinfoperservice
        public IEnumerable<AdditionalFollowUpInfoPerServices> Get(int Organization)
        {
            List<AdditionalFollowUpInfoPerServices> listAdditionalFollowUpInfoPerServices = new List<AdditionalFollowUpInfoPerServices>();

            DataView dvUsers = UserBO.GetUsersIDByOrganization(Organization);
            string TempCreatedBy = "";
            if (dvUsers.Count > 0)
            {
                foreach (DataRowView drvUsers in dvUsers)
                {
                    TempCreatedBy += "CreatedBy=" + drvUsers["UserID"] + " OR ";
                }
                string CreatedBy = TempCreatedBy.Remove(TempCreatedBy.Length - 3);
             
                DataView dvServiceProvidedPerSaMI = ServicesProvidedPerSaMIBO.GetServicesProvidedPerSaMIIDForSync(CreatedBy);
                string ServiceProvidedPersaMIID = "";
                if (dvServiceProvidedPerSaMI.Count > 0)
                {
                    foreach (DataRowView drvSPPSaMI in dvServiceProvidedPerSaMI)
                    {
                        ServiceProvidedPersaMIID += "ServiceProvidedPerSaMIID=" + drvSPPSaMI["ServiceProvidedPerSaMIID"] + " OR ";
                    }
                    string listOfServiceProvidedPerSaMIID = ServiceProvidedPersaMIID.Remove(ServiceProvidedPersaMIID.Length - 3);

                    DataView dvAdditionalFollowUpInfoPerServices = AdditionalFollowUpInfoPerServiceBO.GetAdditionalFollowUpInfoPerServicesIDForSync(listOfServiceProvidedPerSaMIID);
                    foreach (DataRowView drvAdditionalFollowUpInfoPerServices in dvAdditionalFollowUpInfoPerServices)
                    {
                        AdditionalFollowUpInfoPerServices AdditionalFollowUpInfoPerServices = new AdditionalFollowUpInfoPerServices();
                        listAdditionalFollowUpInfoPerServices.Add(AdditionalFollowUpInfoPerServiceBO.GetAdditionalFollowUpInfoPerServices(Convert.ToInt32(drvAdditionalFollowUpInfoPerServices["AdditionalFollowUpInfoPerServiceID"])));
                    }
                }
            }
            return listAdditionalFollowUpInfoPerServices;
        }

       
        // POST api/additionalfollowupinfoperservice
        public AdditionalFollowUpInfoPerServices Post(AdditionalFollowUpInfoPerServices AdditionalFollowUpInfoPerServices)
        {
            if (AdditionalFollowUpInfoPerServices.GUID> 0)
            {
                AdditionalFollowUpInfoPerServices.SyncStatus = 1;
                AdditionalFollowUpInfoPerServices.AdditionalFollowUpInfoPerServiceID = AdditionalFollowUpInfoPerServices.GUID;
                int rowResult = AdditionalFollowUpInfoPerServiceBO.UpdateAdditionalFollowUp(AdditionalFollowUpInfoPerServices);

                //Return Back to The Client               
                return AdditionalFollowUpInfoPerServices;
            }
            else
            {

                AdditionalFollowUpInfoPerServices.SyncStatus = 1;
                int rowResult = AdditionalFollowUpInfoPerServiceBO.InsertAdditionalFollowUp(AdditionalFollowUpInfoPerServices);
                AdditionalFollowUpInfoPerServices.AdditionalFollowUpInfoPerServiceID = rowResult;
                //Return Back to The Client               
                return AdditionalFollowUpInfoPerServices;
            }
        }

    }
}
