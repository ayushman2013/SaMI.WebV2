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
    public class ICRecommendationsPerServiceDAO : BaseDAO
    {
        public ICRecommendationsPerServiceDAO() : base() { }
        public ICRecommendationsPerServiceDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_ic_recommendations_per_service";
            KeyField = "ICRecommendationsPerServiceID";
        }

        public DataView SelectAll(int ServiceProvidedPerSaMIID)
        {
            String sql = "SELECT * FROM tbl_ic_recommendations_per_service WHERE ServiceProvidedPerSaMIID = " + ServiceProvidedPerSaMIID;
            return ExecuteQuery(sql);
        }

        public int InsertRecommendation(ICRecommendationsPerService objICRecommendationsPerService)
        {
            objICRecommendationsPerService.ICRecommendationsPerServiceID = 1;
            BeginTransaction();

            try
            {
                objICRecommendationsPerService.ICRecommendationsPerServiceID = Insert(objICRecommendationsPerService);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objICRecommendationsPerService.ICRecommendationsPerServiceID = -1;
            }

            return objICRecommendationsPerService.ICRecommendationsPerServiceID;
        }

        public int UpdateRecommendation(ICRecommendationsPerService objICRecommendationsPerService)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "ServiceProvidedID"};
                rowsaffected = Update(objICRecommendationsPerService, UpdateProperties);

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
