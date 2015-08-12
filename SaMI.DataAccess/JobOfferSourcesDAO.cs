using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;


namespace SaMI.DataAccess
{
   public class JobOfferSourcesDAO : BaseDAO
    {
        public JobOfferSourcesDAO() : base() { }
        public JobOfferSourcesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_job_offer_sources";
            KeyField = "JobOfferSourceID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS JobOfferSourceID, '[Job Offer Source]' AS JobOfferSourceDesc " +
                      "UNION " +
                      "SELECT JobOfferSourceID, JobOfferSourceDesc FROM tbl_job_offer_sources " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_job_offer_sources " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertJobOfferSources(JobOfferSources objJobOfferSources)
        {
            objJobOfferSources.JobOfferSourceID = 1;
            BeginTransaction();

            try
            {
                objJobOfferSources.JobOfferSourceID = Insert(objJobOfferSources);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objJobOfferSources.JobOfferSourceID = -1;
            }

            return objJobOfferSources.JobOfferSourceID;
        }

        public int UpdateJobOfferSources(JobOfferSources objJobOfferSources)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "JobOfferSourceDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objJobOfferSources, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteJobOfferSources(JobOfferSources objJobOfferSources)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objJobOfferSources, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }
        public DataView SelectJobOfferSourcesIDForSync()
        {
            String sql = string.Empty;
            sql = "SELECT JobOfferSourceID FROM tbl_job_offer_sources " +
                     "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
