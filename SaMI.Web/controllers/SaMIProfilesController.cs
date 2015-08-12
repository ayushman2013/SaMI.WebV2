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
    public class SaMIProfilesController : ApiController
    {
        // GET api/samiprofiles
        
        public IEnumerable<SaMIProfiles> Get(int Organization)
        {
            List<SaMIProfiles> listSaMIProfiles = new List<SaMIProfiles>();
            DataView dvUsers = UserBO.GetUsersIDByOrganization(Organization);//PUT The Organization As Dynamic
            string TempCreatedBy = "";
            if (dvUsers.Count > 0)
            {
                foreach (DataRowView drvUsers in dvUsers)
                {
                    TempCreatedBy += "CreatedBy=" + drvUsers["UserID"] + " OR ";
                }
                string CreatedBy = TempCreatedBy.Remove(TempCreatedBy.Length - 3);
                DataView dvlistSaMIProfiles = SaMIProfileBO.GetSaMIProfileIDForSync(CreatedBy);
                foreach (DataRowView drvSaMIProfiles in dvlistSaMIProfiles)
                {
                    SaMIProfiles SaMIProfiles = new SaMIProfiles();
                    listSaMIProfiles.Add(SaMIProfileBO.GetSaMIProfile(Convert.ToInt32(drvSaMIProfiles["SaMIProfileID"])));
                }
            }
            return listSaMIProfiles;
        }

      
        // POST api/samiprofiles
        public SaMIProfiles Post(SaMIProfiles SaMIProfiles)
        {

            if (SaMIProfiles.GUID > 0)
            {
                SaMIProfiles.SaMIProfileID = SaMIProfiles.GUID;
                SaMIProfiles.SyncStatus = 1;
                int rowResult = SaMIProfileBO.UpdateProfile(SaMIProfiles);

                //Return Back to The Client               
                return SaMIProfiles;
            }
            else
            {
                SaMIProfiles.SyncStatus = 1;
                int rowResult = SaMIProfileBO.InsertProfile(SaMIProfiles);
                SaMIProfiles.SaMIProfileID = rowResult;

                //Return Back to The Client               
                return SaMIProfiles;
            }
        }

    }
}
