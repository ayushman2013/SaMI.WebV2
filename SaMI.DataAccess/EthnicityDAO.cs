using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class EthnicityDAO : BaseDAO
    {
        public EthnicityDAO() : base() { }
        public EthnicityDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_ethnicity";
            KeyField = "EthnicityID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;

            if (Select)
                sql = "SELECT '' AS EthnicityID, '[Ethnicity]' AS EthnicityName UNION " +
                        "SELECT EthnicityID, EthnicityName  FROM tbl_ethnicity " +
                         "WHERE Status <> 0 " +
                        "ORDER BY EthnicityName ";
            else
                sql = "SELECT * FROM tbl_ethnicity " +
                         "WHERE Status <> 0 " +
                        "ORDER BY EthnicityName ";
            return ExecuteQuery(sql);
        }

        public int InsertEthnicity(Ethnicity objEthnicity)
        {
            objEthnicity.EthnicityID = 1;
            BeginTransaction();

            try
            {
                objEthnicity.EthnicityID = Insert(objEthnicity);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objEthnicity.EthnicityID = -1;
            }

            return objEthnicity.EthnicityID;
        }

        public int UpdateEthnicity(Ethnicity objEthnicity)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "EthnicityName", "Category", "UpdatedBy", "UpdatedDate",
                                                           "Status", "ValidRegions", "SyncStatus" };
                rowsaffected = Update(objEthnicity, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteEthnicity(Ethnicity objEthnicity)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objEthnicity, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectGeoBasedEthnicity()
        {
            String sql = "SELECT * FROM tbl_geo_based_ethnicity ";
            return ExecuteQuery(sql);
        }

        public DataView SelectValidRegions(int EthnicityID, int SaMiProfileID)
        {
            String sql = "SELECT ValidRegions FROM tbl_SaMI_profiles WHERE EthnicityID = " + EthnicityID;
            
                if(SaMiProfileID>0)
                {
                    sql += " AND SaMIProfileID = " + SaMiProfileID ;
                }
            
            return ExecuteQuery(sql);
        }

        public DataView SelectValidRegionsForTrainee(int EthnicityID, int SaMiProfileID)
        {
            String sql = "SELECT ValidRegions FROM TRNTrainee WHERE EthnicityID = " + EthnicityID;

            if (SaMiProfileID > 0)
            {
                sql += " AND ID = " + SaMiProfileID;
            }

            return ExecuteQuery(sql);
        }

        public DataView SelectValidRegionForEthnicity(int EthnicityID)
        {
            String sql = "SELECT ValidRegions FROM tbl_ethnicity WHERE EthnicityID = " + EthnicityID;

            return ExecuteQuery(sql);
        }

        public DataView SelectRegionsForDropdown(List<int> lstValidRegions, String option)
        {
            string regions = "";
            String a = "";

            if (lstValidRegions.Count > 0)
            {
                foreach (int region in lstValidRegions)
                {
                    //sql += ", '"+region+"'";
                    a += "," + region;
                }
                regions = a.Substring(1);
            }
            else
            {
                regions = "0";
            }

            String sql = "SELECT 0 AS GeoBasedEthnicityID, '" + option + "' AS GeoBasedEthnicityDesc UNION " +
                        "SELECT GeoBasedEthnicityID, GeoBasedEthnicityDesc FROM tbl_geo_based_ethnicity WHERE GeoBasedEthnicityID IN ( ";

            sql += regions;
            sql += ")";

            return ExecuteQuery(sql);
        }

        public DataView SelectEthnicityIDForSync()
        {
            String sql = string.Empty;

            sql = "SELECT EthnicityID FROM tbl_ethnicity " +
                     "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
