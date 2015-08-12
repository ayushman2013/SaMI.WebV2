using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SaMI.DTO;
using SaMI.DataAccess;
using SaMI.Business;
using System.Data;

namespace Sync.Controllers
{
    public class FollowUpPerServicesController : ApiController
    {

        // GET api/followupperservices
        public IEnumerable<FollowUpPerServices> Get(int Organization)
        {
            List<FollowUpPerServices> listFollowUpPerServices = new List<FollowUpPerServices>();

            DataView dvUsers = UserBO.GetUsersIDByOrganization(Organization);
            string TempCreatedBy = "";
            if (dvUsers.Count > 0)
            {
                foreach (DataRowView drvUsers in dvUsers)
                {
                    TempCreatedBy += "CreatedBy=" + drvUsers["UserID"] + " OR ";
                }
                string CreatedBy = TempCreatedBy.Remove(TempCreatedBy.Length - 3);

                DataView dvFollowUpPerServices = FollowUpPerServicesBO.GetFollowUpPerServicesIDForSync(CreatedBy);
                foreach (DataRowView drvFollowUpPerServices in dvFollowUpPerServices)
                {
                    FollowUpPerServices FollowUpPerServices = new FollowUpPerServices();
                    listFollowUpPerServices.Add(FollowUpPerServicesBO.GetFollowUpPerServices(Convert.ToInt32(drvFollowUpPerServices["FollowUpPerServiceID"])));
                }
            }
            return listFollowUpPerServices;
        }
        // POST api/followupperservices
        public FollowUpPerServices Post(FollowUpPerServices FollowUpPerServices)
        {
            if (FollowUpPerServices.GUID > 0)
            {
                FollowUpPerServices.SyncStatus = 1;
                FollowUpPerServices.FollowUpPerServiceID = FollowUpPerServices.GUID;
                int rowResult = FollowUpPerServicesBO.UpdateInsertFollowUpPerServices(FollowUpPerServices);

                //Return Back to The Client               
                return FollowUpPerServices;
            }
            else
            {

                FollowUpPerServices.SyncStatus = 1;
                int rowResult = FollowUpPerServicesBO.InsertFollowUpPerServices(FollowUpPerServices);
                FollowUpPerServices.FollowUpPerServiceID = rowResult;
                //Return Back to The Client               
                return FollowUpPerServices;
            }
        }
    }
}
