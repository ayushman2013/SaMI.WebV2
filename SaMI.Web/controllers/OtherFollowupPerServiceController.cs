using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;
using SaMI.Business;

namespace Sync.Controllers
{
    public class OtherFollowupPerServiceController : ApiController
    {

        // GET api/otherfollowupperservice
        public IEnumerable<OtherFollowupPerService> Get(int Organization)
        {
            List<OtherFollowupPerService> listOtherFollowupPerService = new List<OtherFollowupPerService>();

            DataView dvUsers = UserBO.GetUsersIDByOrganization(Organization);
            string TempCreatedBy = "";
            if (dvUsers.Count > 0)
            {
                foreach (DataRowView drvUsers in dvUsers)
                {
                    TempCreatedBy += "CreatedBy=" + drvUsers["UserID"] + " OR ";
                }
                string CreatedBy = TempCreatedBy.Remove(TempCreatedBy.Length - 3);

                DataView dvOtherFollowupPerService = OtherFollowupPerServiceBO.GetOtherFollowupPerServiceIDForSync(CreatedBy);
                foreach (DataRowView drvOtherFollowupPerService in dvOtherFollowupPerService)
                {
                    OtherFollowupPerService OtherFollowupPerService = new OtherFollowupPerService();
                    listOtherFollowupPerService.Add(OtherFollowupPerServiceBO.GetOtherFollowUpInfoPerService(Convert.ToInt32(drvOtherFollowupPerService["OtherFollowUpPerServiceID"])));
                }
            }
            return listOtherFollowupPerService;
        }


        // POST api/otherfollowupperservice
        public OtherFollowupPerService Post(OtherFollowupPerService OtherFollowupPerService)
        {

            if (OtherFollowupPerService.GUID > 0)
            {
                OtherFollowupPerService.SyncStatus = 1;
                OtherFollowupPerService.ServiceProvidedPerSaMIID = OtherFollowupPerService.GUID;
                int rowResult = OtherFollowupPerServiceBO.UpdateOtherFollowUp(OtherFollowupPerService);

                //Return Back to The Client               
                return OtherFollowupPerService;
            }
            else
            {

                OtherFollowupPerService.SyncStatus = 1;
                int rowResult = OtherFollowupPerServiceBO.InsertOtherFollowUp(OtherFollowupPerService);
                OtherFollowupPerService.ServiceProvidedPerSaMIID = rowResult;
                //Return Back to The Client               
                return OtherFollowupPerService;
            }
        }

       
    }
}
