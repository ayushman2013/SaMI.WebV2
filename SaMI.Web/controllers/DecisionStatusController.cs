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
    public class DecisionStatusController : ApiController
    {
        // GET api/decisionstatus
        public IEnumerable<DecisionStatus> Get()
        {
            List<DecisionStatus> listDecisionStatus = new List<DecisionStatus>();
            DataView dvDecisionStatus = DecisionStatusBO.GetDecisionStatusIDForSync();
            foreach (DataRowView drvDecisionStatus in dvDecisionStatus)
            {
                DecisionStatus decisionStatus = new DecisionStatus();
                listDecisionStatus.Add(DecisionStatusBO.GetDecisionStatus(Convert.ToInt32(drvDecisionStatus["DecisionStatusID"])));
            }
            return listDecisionStatus;
        }

        
        // POST api/decisionstatus
        public DecisionStatus Post(DecisionStatus decisionStatus)
        {
            if (decisionStatus.GUID > 0)
            {
                decisionStatus.DecisionStatusID = decisionStatus.GUID;
                int rowResult = DecisionStatusBO.UpdateDecisionStatus(decisionStatus);
                //Return Back to The Client               
                return decisionStatus;
            }
            else
            { 
                int rowResult = DecisionStatusBO.InsertDecisionStatus(decisionStatus);
                //Return Back to The Client               
                return decisionStatus;
            }
        }

        
    }
}
