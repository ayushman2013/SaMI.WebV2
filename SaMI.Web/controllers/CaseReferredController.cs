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
    public class CaseReferredController : ApiController
    {
        // GET api/casereferred
        public IEnumerable<CaseReferred> Get(int Organization)
        {
            List<CaseReferred> listCaseReferred = new List<CaseReferred>();
            DataView dvUsers = UserBO.GetUsersIDByOrganization(Organization);  ////PUT The Organization As Dynamic
            string TempCreatedBy = "";
            if (dvUsers.Count > 0)
            {
                foreach (DataRowView drvUsers in dvUsers)
                {
                    TempCreatedBy += "CreatedBy=" + drvUsers["UserID"] + " OR ";
                }
                string CreatedBy = TempCreatedBy.Remove(TempCreatedBy.Length - 3);
                DataView dvlistCaseReferred = CaseReferredBO.GetCaseReferredIDForSync(CreatedBy);
                foreach (DataRowView drvCaseReferred in dvlistCaseReferred)
                {
                    CaseReferred CaseReferred = new CaseReferred();
                    listCaseReferred.Add(CaseReferredBO.GetCaseReferred(Convert.ToInt32(drvCaseReferred["CaseReferredID"])));
                }
            }
            return listCaseReferred;
        }

        // POST api/casereferred
        public CaseReferred Post(CaseReferred CaseReferred)
        {

            if (CaseReferred.GUID > 0)
            {
                CaseReferred.CaseReferredID = CaseReferred.GUID;
                CaseReferred.SyncStatus = 1;
                int rowResult = CaseReferredBO.UpdateCaseReferred(CaseReferred);

                //Return Back to The Client               
                return CaseReferred;
            }
            else
            {               
                CaseReferred.SyncStatus = 1;
                int rowResult = CaseReferredBO.InsertCaseReferred(CaseReferred);
                CaseReferred.CaseReferredID = rowResult;

                //Return Back to The Client               
                return CaseReferred;
            }
        }

       
    }
}
