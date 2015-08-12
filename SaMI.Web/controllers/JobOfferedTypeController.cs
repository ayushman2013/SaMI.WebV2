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
    public class JobOfferedTypeController : ApiController
    {
        // GET api/jobofferedtype
        public IEnumerable<JobOfferedTypes> Get()
        {

            List<JobOfferedTypes> listJobOfferedType = new List<JobOfferedTypes>();
            DataView dvJobOfferedType = JobOfferedTypesBO.GetJobOfferedTypeIDForSync();
            foreach (DataRowView drvJobOfferedType in dvJobOfferedType)
            {
                JobOfferedTypes jobOfferType = new JobOfferedTypes();
                listJobOfferedType.Add(JobOfferedTypesBO.GetJobOfferedTypes(Convert.ToInt32(drvJobOfferedType["JobOfferedTypeID"])));
            }
            return listJobOfferedType;
        }

        // POST api/jobofferedtype
        public JobOfferedTypes Post(JobOfferedTypes jobOfferedType)
        {
            if (jobOfferedType.GUID > 0)
            {
                jobOfferedType.JobOfferedTypeID = jobOfferedType.GUID;
                int rowResult = JobOfferedTypesBO.UpdateJobOfferedTypes(jobOfferedType);

                //Return Back to The Client               
                return jobOfferedType;
            }
            else
            {
              
                int rowResult = JobOfferedTypesBO.InsertJobOfferedTypes(jobOfferedType);

                //Return Back to The Client               
                return jobOfferedType;
            }
        }

       
    }
}
