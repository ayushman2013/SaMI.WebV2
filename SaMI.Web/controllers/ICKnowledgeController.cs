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
    public class ICKnowledgeController : ApiController
    {
        // GET api/icknowledge
        public IEnumerable<ICKnowledges> Get()
        {
            List<ICKnowledges> listICKnowledge = new List<ICKnowledges>();
            DataView dvICKnowledge = ICKnowledgesBO.GetICKnowledgeIDForSync();
            foreach (DataRowView drvICKnowledge in dvICKnowledge)
            {
                listICKnowledge.Add(ICKnowledgesBO.GetICKnowledges(Convert.ToInt32(drvICKnowledge["ICKnowledgeID"])));

            }
            return listICKnowledge;
        }

        
        // POST api/icknowledge
        public ICKnowledges Post(ICKnowledges knowledge)
        {
            if (knowledge.GUID > 0)
            {
                knowledge.ICKnowledgeID = knowledge.GUID;
                int rowResult = ICKnowledgesBO.UpdateICKnowledges(knowledge);
                //Return Back to The Client               
                return knowledge;
            }
            else
            {               
                
                int rowResult = ICKnowledgesBO.InsertICKnowledges(knowledge);
                //Return Back to The Client               
                return knowledge;
            }
        }

      
    }
}
