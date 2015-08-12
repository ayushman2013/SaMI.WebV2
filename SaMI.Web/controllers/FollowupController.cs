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
    public class FollowupController : ApiController
    {
        // GET api/followup
        public IEnumerable<FollowUp> Get()
        {
            List<FollowUp> listFollowUp = new List<FollowUp>();
            DataView dvFollowUp = FollowUpBO.GetFollowUpIDForSync();
            foreach (DataRowView drvFollowUp in dvFollowUp)
            {
                FollowUp FollowUp = new FollowUp();
                listFollowUp.Add(FollowUpBO.GetFollowUp(Convert.ToInt32(drvFollowUp["FollowUpID"])));
            }
            return listFollowUp;
        }

      
        // POST api/followup
        public FollowUp Post(FollowUp FollowUp)
        {
            if (FollowUp.GUID > 0)
            {
                FollowUp.FollowUpID = FollowUp.GUID;
                int rowResult = FollowUpBO.UpdateFollowUp(FollowUp);
                //Return Back to The Client               
                return FollowUp;
            }
            else
            {             
               
                int rowResult = FollowUpBO.InsertFollowUp(FollowUp);
                //Return Back to The Client               
                return FollowUp;
            }
        }

       
    }
}
