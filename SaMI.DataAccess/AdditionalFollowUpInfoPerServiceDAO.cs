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
    public class AdditionalFollowUpInfoPerServiceDAO :BaseDAO
    {
        public AdditionalFollowUpInfoPerServiceDAO() : base() { }
        public AdditionalFollowUpInfoPerServiceDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_additional_followup_info_per_service";
            KeyField = "AdditionalFollowUpInfoPerServiceID";
        }

        public DataView SelectAll(int ServiceProvidedPerSaMIID)
        {
            String sql = "SELECT * FROM tbl_additional_followup_info_per_service WHERE ServiceProvidedPerSaMIID = " + ServiceProvidedPerSaMIID;
            return ExecuteQuery(sql);
        }

        public int InsertAdditionalFollowUp(AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices)
        {
            objAdditionalFollowUpInfoPerServices.AdditionalFollowUpInfoPerServiceID = 1;
            BeginTransaction();

            try
            {
                objAdditionalFollowUpInfoPerServices.AdditionalFollowUpInfoPerServiceID = Insert(objAdditionalFollowUpInfoPerServices);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objAdditionalFollowUpInfoPerServices.AdditionalFollowUpInfoPerServiceID = -1;
            }

            return objAdditionalFollowUpInfoPerServices.AdditionalFollowUpInfoPerServiceID;
        }

        public int UpdateAdditionalFollowUp(AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "AdditionalFollowupInfoID"};
                rowsaffected = Update(objAdditionalFollowUpInfoPerServices, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView GetAdditionalFollowUpInfoPerServicesIDForSync(String ServiceProvidedPerSaMIID)
        {
            String sql = "SELECT AdditionalFollowUpInfoPerServiceID FROM tbl_additional_followup_info_per_service WHERE SyncStatus='0' AND (" + ServiceProvidedPerSaMIID + ")";
            return ExecuteQuery(sql);
        }
    }
}
