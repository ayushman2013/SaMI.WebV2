using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;
using System.Collections;

namespace SaMI.DataAccess
{
    public class PreviousFEExperienceDAO : BaseDAO
    {
        public PreviousFEExperienceDAO() : base() { }
        public PreviousFEExperienceDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_previous_fe_experiences";
            KeyField = "ForeignEmploymentExperienceID";
        }

        public DataView SelectAll(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_previous_fe_experiences WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectCustom(int SaMIProfileID)
        {
            String sql = "SELECT PFE.ForeignEmploymentExperienceID, PFE.SaMIProfileID, C.CountryName,  " +
                            "VF.VisitFrequencyDesc " +
                                "FROM tbl_previous_fe_experiences  AS PFE " +
                            "JOIN tbl_countries C ON C.CountryID = PFE.CountryID " +
                            "JOIN tbl_visit_frequencies VF ON VF.VisitFrequencyID = PFE.VisitFrequencyID " +
                            "WHERE PFE.SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public int InsertFEExperience(PreviousFEExperiences objPreviousFEExperiences)
        {
            objPreviousFEExperiences.ForeignEmploymentExperienceID = 1;
            BeginTransaction();

            try
            {
                objPreviousFEExperiences.ForeignEmploymentExperienceID = Insert(objPreviousFEExperiences);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objPreviousFEExperiences.ForeignEmploymentExperienceID = -1;
            }

            return objPreviousFEExperiences.ForeignEmploymentExperienceID;
        }

        public int UpdateFEExperience(PreviousFEExperiences objPreviousFEExperiences)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ForeignEmploymentExperienceID", "CountryID", "VisitFrequencyID", 
                                                           "DestinationAirportID", "JobOfferedType", "StayDuration", 
                                                           "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objPreviousFEExperiences, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeletePreviousFEExperience(PreviousFEExperiences objPreviousFEExperience)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objPreviousFEExperience, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;
        }

        public DataView SelectAllBySaMIProfileID(int SaMIProfileID)
        {
            String sql = "SELECT PE.*, JT.JobOfferedTypeDesc, C.CountryName FROM tbl_previous_fe_experiences PE " +
                "JOIN tbl_job_offered_types JT ON JT.JobOfferedTypeID = PE.JobOfferedTypeID " +
                "JOIN tbl_countries C ON C.CountryID = PE.CountryID " +
                "WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectPreviousFEExperienceIDForSync(String CreatedBy)
        {
            String sql = "SELECT ForeignEmploymentExperienceID FROM tbl_previous_fe_experiences WHERE SyncStatus='0' AND (" + CreatedBy + ")";
            return ExecuteQuery(sql);
        }

    }
}
