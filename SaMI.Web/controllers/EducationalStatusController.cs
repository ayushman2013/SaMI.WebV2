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
    public class EducationalStatusController : ApiController
    {
        // GET api/educationalstatus
        public IEnumerable<EducationalStatus> Get()
        {
            List<EducationalStatus> listEducationalStatus = new List<EducationalStatus>();
            DataView dvEducationalStatus = EducationalStatusBO.GetEducationalStatusIDForSync();
            foreach (DataRowView drvEducationalStatus in dvEducationalStatus)
            {
                EducationalStatus educationalStaus = new EducationalStatus();
                listEducationalStatus.Add(EducationalStatusBO.GetEducationalStatus(Convert.ToInt32(drvEducationalStatus["EducationalStatusID"])));
            }
            return listEducationalStatus;
        }

       
        // POST api/educationalstatus
        public EducationalStatus Post(EducationalStatus education)
        {

            if (education.GUID > 0)
            {
                education.EducationalStatusID = education.GUID;
                int rowResult = EducationalStatusBO.UpdateEducationalStatus(education);

                //Return Back to The Client               
                return education;
            }
            else
            {
                education.GUID = education.EducationalStatusID;               
                int rowResult = EducationalStatusBO.InsertEduationalStatus(education);

                //Return Back to The Client               
                return education;
            }
        }

       
    }
}
