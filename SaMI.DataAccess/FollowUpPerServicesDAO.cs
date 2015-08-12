using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class FollowUpPerServicesDAO : BaseDAO
    {
         public FollowUpPerServicesDAO() : base() { }
         public FollowUpPerServicesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

         public override void Initilize()
         {
             Table = "tbl_follow_up_per_services";
             KeyField = "FollowUpPerServiceID";
         }


         public DataView GetFollowUpPerServicesIDForSync(String CreatedBy)
         {
             string sql = "SELECT FollowUpPerServiceID FROM tbl_follow_up_per_services WHERE SyncStatus='0' AND " + CreatedBy;
             return ExecuteQuery(sql);

         }

         public int InsertFollowUpPerServices(FollowUpPerServices objFollowServices)
         {
             objFollowServices.FollowUpPerServiceID = -1;
             BeginTransaction();

             try
             {
                 objFollowServices.FollowUpPerServiceID = Insert(objFollowServices);
                 CommitTransaction();
             }
             catch (Exception ex)
             {
                 RollBackTransaction();
                 objFollowServices.FollowUpPerServiceID = -1;
             }

             return objFollowServices.FollowUpPerServiceID;
         }

         public int UpdateInsertFollowUpPerServices(FollowUpPerServices objFollowServices)
         {
             int rowsaffected = -1;
             BeginTransaction();
             try
             {
                 String[] UpdateProperties;

                 UpdateProperties = new String[] { "ICFollowUpRequired", "FollowUpID", "ICRecommendationID", "FurtherFollowUpID", "FurtherFollowUpRequired",
                                                            "CounselorDifficultyID", "UpdatedBy", "UpdatedDate","GUID","SyncStatus"
                                                            };
                 rowsaffected = Update(objFollowServices, UpdateProperties);

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
