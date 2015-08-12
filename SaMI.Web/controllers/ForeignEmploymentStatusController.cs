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
    public class ForeignEmploymentStatusController : ApiController
    {
        // GET api/foreignemploymentstatus
        public IEnumerable<ForeignEmploymentStatus> Get(int Organization)
        {
            List<ForeignEmploymentStatus> listForeignEmploymentStatus = new List<ForeignEmploymentStatus>();
            DataView dvUsers = UserBO.GetUsersIDByOrganization(Organization);
            string TempCreatedBy = "";
            if (dvUsers.Count > 0)
            {
                foreach (DataRowView drvUsers in dvUsers)
                {
                    TempCreatedBy += "CreatedBy=" + drvUsers["UserID"] + " OR ";
                }
                string CreatedBy = TempCreatedBy.Remove(TempCreatedBy.Length - 3);
                DataView dvForeignEmploymentStatus = ForeignEmploymentStatusBO.GetForeignEmploymentStatusIDForSync(CreatedBy);
                foreach (DataRowView drvSaMIProfiles in dvForeignEmploymentStatus)
                {
                    ForeignEmploymentStatus ForeignEmploymentStatus = new ForeignEmploymentStatus();
                    listForeignEmploymentStatus.Add(ForeignEmploymentStatusBO.GetForeignEStatus(Convert.ToInt32(drvSaMIProfiles["ForeignEmploymentStatusID"])));
                }
            }
            return listForeignEmploymentStatus;
        }
        // POST api/foreignemploymentstatus
        public ForeignEmploymentStatus Post(ForeignEmploymentStatus ForeignEmploymentStatus)
        {

            if (ForeignEmploymentStatus.GUID > 0)
            {
                int ForeignEmploymentStatusID = ForeignEmploymentStatus.GUID;
                // ForeignEmploymentStatus.GUID = ForeignEmploymentStatus.SaMIProfileID;
                ForeignEmploymentStatus.ForeignEmploymentStatusID = ForeignEmploymentStatusID;
                int rowResult = ForeignEmploymentStatusBO.UpdateFEStatus(ForeignEmploymentStatus);

                //Return Back to The Client               
                return ForeignEmploymentStatus;
            }
            else
            {
                //  ForeignEmploymentStatus.GUID = ForeignEmploymentStatus.SaMIProfileID;
                ForeignEmploymentStatus.SyncStatus = 1;
                int rowResult = ForeignEmploymentStatusBO.InsertFEStatus(ForeignEmploymentStatus);
                ForeignEmploymentStatus.ForeignEmploymentStatusID = rowResult;

                //Return Back to The Client               
                return ForeignEmploymentStatus;
               
            }

        }
    }
}
