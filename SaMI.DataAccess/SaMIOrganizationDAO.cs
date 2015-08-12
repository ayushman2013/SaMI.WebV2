using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class SaMIOrganizationDAO : BaseDAO
    {
        public SaMIOrganizationDAO() : base() { }
        public SaMIOrganizationDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_SaMI_organizations";
            KeyField = "SaMIOrganizationID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT 0 as SaMIOrganizationID, '[Organization]' AS SaMIOrganizationName " +
                       " UNION " +
                       " SELECT SaMIOrganizationID, SaMIOrganizationName FROM tbl_SaMI_organizations WHERE Status = 1";
            else
                sql = "SELECT D.DistrictName, O.* FROM tbl_SaMI_organizations O " +
                      "JOIN tbl_districts D ON D.DistrictID = O.DistrictID " +
                      "WHERE O.Status = 1";
            return ExecuteQuery(sql);
        }


        public int InsertSaMIOrganization(SaMIOrganizations objSaMIOrganizations)
        {
            objSaMIOrganizations.SaMIOrganizationID = 1;
            BeginTransaction();

            try
            {
                objSaMIOrganizations.SaMIOrganizationID = Insert(objSaMIOrganizations);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objSaMIOrganizations.SaMIOrganizationID = -1;
            }

            return objSaMIOrganizations.SaMIOrganizationID;
        }

        public int UpdateSaMIOrganization(SaMIOrganizations objSaMIOrganizations)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "SaMIOrganizationName", "DistrictID", "UpdatedBy", "UpdatedDate",
                                                            "Status", "SyncStatus"};
                rowsaffected = Update(objSaMIOrganizations, UpdateProperties);
                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteSaMIOrganization(SaMIOrganizations objSaMIOrganizations)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objSaMIOrganizations, UpdateProperties);
                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectByDistrictID(int DistrictID)
        {
            String sql = "SELECT DISTINCT(O.SaMIOrganizationName), O.* FROM tbl_SaMI_organizations O " +
                        "JOIN tbl_users U ON U.SaMIOrganizationID=O.SaMIOrganizationID " +
                        "WHERE U.DistrictID = " + DistrictID;
            return ExecuteQuery(sql);
        }


        public DataView SelectOrganizationByDistrictID(int DistrictID, String select)
        {
            String sql = "SELECT 0 AS SaMIOrganizationID, '" + select + "' AS SaMIOrganizationName UNION " +
                         "SELECT SaMIOrganizationID, SaMIOrganizationName" + 
                        " FROM tbl_SaMI_organizations O " +
                        "WHERE O.DistrictID = " + DistrictID;
            return ExecuteQuery(sql);
        }

        public DataView SelectSaMIOrganizationID()
        {
            String sql = "SELECT SaMIOrganizationID FROM tbl_SaMI_organizations WHERE SyncStatus ='0'";
            return ExecuteQuery(sql);
        }

        public object SelectByUserID(int userID)
        {
            String sql = "SELECT O.SaMIOrganizationID, O.SaMIOrganizationName FROM tbl_SaMI_organizations O " +
                        "JOIN tbl_users U ON U.SaMIOrganizationID = O.SaMIOrganizationID " +
                        "WHERE U.UserID ='"+userID+"'";
            return ExecuteQuery(sql);
        }
    }
}
