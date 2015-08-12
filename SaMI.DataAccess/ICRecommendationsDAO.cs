using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class ICRecommendationsDAO : BaseDAO
    {
        public ICRecommendationsDAO() : base() { }
        public ICRecommendationsDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_ic_recommendations";
            KeyField = "ICRecommendationID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if(Select)
            {
                sql = " SELECT 0 AS ICRecommendationID, '[Recommendation]' AS ICRecommendationDesc " +
                        "UNION" +
                        " SELECT ICRecommendationID, ICRecommendationDesc FROM tbl_ic_recommendations " +
                         "WHERE Status <> 0 ";
            }
            else
                sql = "SELECT * FROM tbl_ic_recommendations " +
                             "WHERE Status <> 0 " +
                             "ORDER BY ICRecommendationDesc";
            return ExecuteQuery(sql);
        }
        public int InsertICRecommendations(ICRecommendations objICRecommendations)
        {
            objICRecommendations.ICRecommendationID = 1;
            BeginTransaction();

            try
            {
                objICRecommendations.ICRecommendationID = Insert(objICRecommendations);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objICRecommendations.ICRecommendationID = -1;
            }

            return objICRecommendations.ICRecommendationID;
        }

        public int UpdateICRecommendations(ICRecommendations objICRecommendations)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ICRecommendationDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objICRecommendations, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteICRecommendations(ICRecommendations objICRecommendations)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objICRecommendations, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectICRecommendations(int SaMIProfileID)
        {
            String sql = "SELECT ICRecommendationID FROM tbl_follow_up_per_services FS " +
                        "JOIN tbl_services_provided_per_SaMI SS ON SS.ServiceProvidedPerSaMIID = FS.ServiceProvidedPerSaMIID " +
                         "WHERE SS.SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectICRecommendationsIDForSync()
        {
            String sql = string.Empty;

            sql = "SELECT ICRecommendationID FROM tbl_ic_recommendations " +
                         "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
