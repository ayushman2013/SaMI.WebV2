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
    public class OtherFollowupPerServiceDAO : BaseDAO
    {
        public OtherFollowupPerServiceDAO() : base() { }
        public OtherFollowupPerServiceDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_other_followup_per_service";
            KeyField = "OtherFollowUpPerServiceID";
        }

        public DataView SelectAll(int ServiceProvidedPerSaMIID)
        {
            String sql = "SELECT * FROM tbl_other_followup_per_service WHERE ServiceProvidedPerSaMIID = " + ServiceProvidedPerSaMIID;
            return ExecuteQuery(sql);
        }

        public DataView SelectCustom(int ServiceProvidedPerSaMIID)
        {
            String sql = "SELECT OFPS.OtherFollowUpPerServiceID, CONVERT(varchar(10),OFPS.FollowUpDate,111) AS FollowUpDate, " +
                            "dbo.ufnGetOtherFollowupStatus(OFPS.OtherFollowUpPerServiceID) AS FollowUpStatus, " +
                            "NFR.NonFollowUpReasonDesc, Remarks " +
                            "FROM tbl_other_followup_per_service  AS OFPS  " +
                            "LEFT JOIN tbl_non_followup_reasons NFR  " +
                            "   ON NFR.NonFollowUpReasonID = OFPS.NonFollowUpReasonID " +
                            "WHERE OFPS.ServiceProvidedPerSaMIID = " + ServiceProvidedPerSaMIID;
            return ExecuteQuery(sql);
        }

        public int InsertOtherFollowUp(OtherFollowupPerService objOtherFollowupPerService)
        {
            objOtherFollowupPerService.OtherFollowUpPerServiceID = 1;
            BeginTransaction();

            try
            {
                objOtherFollowupPerService.OtherFollowUpPerServiceID = Insert(objOtherFollowupPerService);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objOtherFollowupPerService.OtherFollowUpPerServiceID = -1;
            }

            return objOtherFollowupPerService.OtherFollowUpPerServiceID;
        }

        public int UpdateOtherFollowUp(OtherFollowupPerService objOtherFollowupPerService)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "FollowUpDate", "NonFollowUpReasonID", "IsFollowUpComplied", 
                                                            "IsFollowUpDidNotComply", "IsReasonRecommendation",
                                                            "IsReasonReceipt", "IsReasonFamilyMember", "IsReasonOther",
                                                            "Remarks", "UpdatedBy", "UpdatedDate", "SyncStatus"
                                                            };
                rowsaffected = Update(objOtherFollowupPerService, UpdateProperties);


                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectOtherFollowupPerServiceIDForSync(String CreatedBy)
        {
            String sql = "SELECT OtherFollowUpPerServiceID FROM tbl_other_followup_per_service WHERE SyncStatus='0' AND (" + CreatedBy +")";
            return ExecuteQuery(sql);
        }
    }
}
