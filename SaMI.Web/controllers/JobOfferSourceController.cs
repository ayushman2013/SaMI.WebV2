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
    public class JobOfferSourceController : ApiController
    {
        // GET api/joboffersource
        public IEnumerable<JobOfferSources> Get()
        {

            List<JobOfferSources> listJobOfferSources = new List<JobOfferSources>();
            DataView dvJobOfferSources = JobOfferSourcesBO.GetJobOfferSourcesIDForSync();
            foreach (DataRowView drvJobOfferSources in dvJobOfferSources)
            {
                JobOfferSources jobOfferSources = new JobOfferSources();
                listJobOfferSources.Add(JobOfferSourcesBO.GetJobOfferSources(Convert.ToInt32(drvJobOfferSources["JobOfferSourceID"])));
            }
            return listJobOfferSources;
        }

        // POST api/joboffersource
        public JobOfferSources Post(JobOfferSources jobOfferSources)
        {

            if (jobOfferSources.GUID > 0)
            {
                jobOfferSources.JobOfferSourceID = jobOfferSources.GUID;
                int rowResult = JobOfferSourcesBO.UpdateJobOfferSources(jobOfferSources);

                //Return Back to The Client               
                return jobOfferSources;
            }
            else
            {
               
                int rowResult = JobOfferSourcesBO.InsertJobOfferSources(jobOfferSources);

                //Return Back to The Client               
                return jobOfferSources;
            }
        }

       
    }
}
