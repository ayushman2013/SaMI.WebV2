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
    public class MaritalStatusController : ApiController
    {
        // GET api/maritalstatus
        public IEnumerable<MaritalStatus> Get()
        {
            List<MaritalStatus> listMaritalStatus = new List<MaritalStatus>();
            DataView dvMaritalStatus = MaritalStatusBO.GetMaritalStatusIDForSync();
            foreach (DataRowView drvEducationalStatus in dvMaritalStatus)
            {
                MaritalStatus status = new MaritalStatus();
                listMaritalStatus.Add(MaritalStatusBO.GetMaritalStatus(Convert.ToInt32(drvEducationalStatus["MaritalStatusID"])));
            }
            return listMaritalStatus;
        }

        // POST api/maritalstatus
        public MaritalStatus Post(MaritalStatus status)
        {
            if (status.GUID > 0)
            {
                status.MaritalStatusID = status.GUID;
                int rowResult = MaritalStatusBO.UpdateMaritalStatus(status);

                //Return Back to The Client               
                return status;
            }
            else
            {
                
                int rowResult = MaritalStatusBO.InsertmaritalStatus(status);

                //Return Back to The Client               
                return status;
            }
        }

       
    }
}
