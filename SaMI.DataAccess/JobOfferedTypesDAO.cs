using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class JobOfferedTypesDAO : BaseDAO
    {
       public JobOfferedTypesDAO() : base() { }
       public JobOfferedTypesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_job_offered_types";
            KeyField = "JobOfferedTypeID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS JobOfferedTypeID, '[Select]' AS JobOfferedTypeDesc " +
                      "UNION " +
                      "SELECT JobOfferedTypeID, JobOfferedTypeDesc FROM tbl_job_offered_types " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_job_offered_types " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

       

        public int InsertJobOfferedTypes(JobOfferedTypes objJobOfferedTypes)
        {
            objJobOfferedTypes.JobOfferedTypeID = 1;
            BeginTransaction();

            try
            {
                objJobOfferedTypes.JobOfferedTypeID = Insert(objJobOfferedTypes);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objJobOfferedTypes.JobOfferedTypeID = -1;
            }

            return objJobOfferedTypes.JobOfferedTypeID;
        }

        public int UpdateJobOfferedTypes(JobOfferedTypes objJobOfferedTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "JobOfferTypeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objJobOfferedTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteJobOfferedTypes(JobOfferedTypes objJobOfferedTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objJobOfferedTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectJobOfferedTypeIDForSync()
        {
            String sql = string.Empty;
            sql = "SELECT JobOfferedTypeID FROM tbl_job_offered_types " +
                     "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
