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
    public class ServicesProvidedPerSaMIDAO : BaseDAO
    {
        public ServicesProvidedPerSaMIDAO() : base() { }
        public ServicesProvidedPerSaMIDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_services_provided_per_SaMI";
            KeyField = "ServiceProvidedPerSaMIID";
        }

        public DataView SelectAll(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_services_provided_per_SaMI WHERE SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }



        public int InsertServiceProvided(ServicesProvidedPerSaMI objServicesProvidedPerSaMI, FollowUpPerServices objFollowServices, List<AdditionalFollowUpInfoPerServices> lstAdditionalFollowUpInfoPerServices)
        {
            objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID = 1;
            BeginTransaction();

            try
            {
                objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID = Insert(objServicesProvidedPerSaMI);
                
               
                objFollowServices.ServiceProvidedPerSaMIID = objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID;
                Insert(objFollowServices);

                foreach (AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices in lstAdditionalFollowUpInfoPerServices)
                {
                    objAdditionalFollowUpInfoPerServices.ServiceProvidedPerSaMIID = objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID;
                    Insert(objAdditionalFollowUpInfoPerServices);
                }

               

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID = -1;
            }

            return objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID;
        }



        public int UpdateServiceProvided(ServicesProvidedPerSaMI objServicesProvidedPerSaMI, FollowUpPerServices objFollowServices, List<AdditionalFollowUpInfoPerServices> lstAdditionalFollowUpInfoPerServices)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "VisitTimes", "ServiceProvidedID", "UpdatedBy", "UpdatedDate",
                                                            "SyncStatus"};
                rowsaffected = Update(objServicesProvidedPerSaMI, UpdateProperties);

                UpdateProperties = new String[] { "ICFollowUpRequired", "FollowUpID", "ICRecommendationID", 
                                                  "CounselorDifficultyID", "UpdatedBy", "UpdatedDate",
                                                  "SyncStatus"};
                rowsaffected = Update(objFollowServices, UpdateProperties);

                Delete("tbl_additional_followup_info_per_service", "ServiceProvidedPerSaMIID = " + objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID);
                foreach (AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices in lstAdditionalFollowUpInfoPerServices)
                {
                    objAdditionalFollowUpInfoPerServices.ServiceProvidedPerSaMIID = objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID;
                    objAdditionalFollowUpInfoPerServices.SyncStatus = 0;
                    Insert(objAdditionalFollowUpInfoPerServices);
                }

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectServicesProvidedPerSaMIIDForSync(String CreatedBy)
        {
            String sql = "SELECT ServiceProvidedPerSaMIID FROM tbl_services_provided_per_SaMI WHERE SyncStatus ='0' AND " + CreatedBy;
            return ExecuteQuery(sql);
        }

        public int InsertServiceProvidedPerSaMI(ServicesProvidedPerSaMI objServicesProvidedPerSaMI)
        {
            objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID = 1;
            BeginTransaction();

            try
            {
                objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID = Insert(objServicesProvidedPerSaMI);

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID = -1;
            }

            return objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID;
        }

        public int UpdateServiceProvidedPerSaMI(ServicesProvidedPerSaMI objServicesProvidedPerSaMI)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "VisitTimes", "ServiceProvidedID", "UpdatedBy", "UpdatedDate", "SyncStatus" };
                rowsaffected = Update(objServicesProvidedPerSaMI, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }
    }
}
