using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class JobOfferSourcesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new JobOfferSourcesDAO().SelectAll(Select);

        }

        public static int InsertJobOfferSources(JobOfferSources objJobOfferSources)
        {
            return new JobOfferSourcesDAO().InsertJobOfferSources(objJobOfferSources);
        }

        public static JobOfferSources GetJobOfferSources(int JobOfferSourceID)
        {
            JobOfferSources objJobOfferSources = new JobOfferSources();
            return (JobOfferSources)(new JobOfferSourcesDAO().FillDTO(objJobOfferSources, "JobOfferSourceID=" + JobOfferSourceID));
        }
        public static int UpdateJobOfferSources(JobOfferSources objJobOfferSources)
        {
            return new JobOfferSourcesDAO().UpdateJobOfferSources(objJobOfferSources);
        }

        public static int Delete(int JobOfferSourceID)
        {
            DataView dv = new JobOfferSourcesDAO().Select("JobOfferSourceID", "tbl_foreign_employment_status", "JobOfferSourceID=" + JobOfferSourceID);

            if (dv.Count == 0)
                return new JobOfferSourcesDAO().Delete("JobOfferSourceID=" + JobOfferSourceID);
            
            return -1;
        }

        public static int DeleteJobOfferSources(JobOfferSources objJobOfferSources)
        {
            return new JobOfferSourcesDAO().DeleteJobOfferSources(objJobOfferSources);
        }

        public static DataView GetJobOfferSourcesIDForSync()
        {
            return new JobOfferSourcesDAO().SelectJobOfferSourcesIDForSync();

        }
    }
}
