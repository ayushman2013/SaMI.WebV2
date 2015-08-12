using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class JobOfferedTypesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new JobOfferedTypesDAO().SelectAll(Select);

        }
        public static int InsertJobOfferedTypes(JobOfferedTypes objJobOfferedTypes)
        {
            return new JobOfferedTypesDAO().InsertJobOfferedTypes(objJobOfferedTypes);
        }
        public static JobOfferedTypes GetJobOfferedTypes(int JobOfferTypeID)
        {
            JobOfferedTypes objJobOfferedTypes = new JobOfferedTypes();
            return (JobOfferedTypes)(new JobOfferedTypesDAO().FillDTO(objJobOfferedTypes, "JobOfferedTypeID=" + JobOfferTypeID));
        }
        public static int UpdateJobOfferedTypes(JobOfferedTypes objJobOfferedTypes)
        {
            return new JobOfferedTypesDAO().UpdateJobOfferedTypes(objJobOfferedTypes);
        }

        public static int Delete(int JobOfferedTypeID)
        {
            DataView dv = new JobOfferedTypesDAO().Select("JobOfferedTypeID", "tbl_foreign_employment_status", "JobOfferedTypeID=" + JobOfferedTypeID);
            if (dv.Count == 0)
               return new JobOfferedTypesDAO().Delete("JobOfferedTypeID=" + JobOfferedTypeID);
            return -1;
        }

        public static int DeleteJobOfferedTypes(JobOfferedTypes objJobOfferedTypes)
        {
            return new JobOfferedTypesDAO().DeleteJobOfferedTypes(objJobOfferedTypes);
        }

        public static DataView GetJobOfferedTypeIDForSync()
        {
            return new JobOfferedTypesDAO().SelectJobOfferedTypeIDForSync();

        }
    }
}
