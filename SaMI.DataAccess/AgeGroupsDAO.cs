using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class AgeGroupsDAO : BaseDAO
    {
        public AgeGroupsDAO() : base() { }
        public AgeGroupsDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_age_groups";
            KeyField = "AgeGroupID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;

            if (Select)
                sql = "SELECT '' AS AgeGroupID, '[Age Group]' AS AgeGroupDesc " +
                      "UNION " +
                      "SELECT AgeGroupID, AgeGroupDesc FROM tbl_age_groups " + 
                      "WHERE Status <> 0";
            else
                sql = "SELECT * FROM tbl_age_groups " +
                      "WHERE Status <> 0";
            return ExecuteQuery(sql);
        }

        public int InsertAgeGroup(AgeGroups objAgeGroup)
        {
            objAgeGroup.AgeGroupID = 1;
            BeginTransaction();

            try
            {
                objAgeGroup.AgeGroupID = Insert(objAgeGroup);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objAgeGroup.AgeGroupID = -1;
            }

            return objAgeGroup.AgeGroupID;
        }

        public int UpdateAgeGroups(AgeGroups objAgeGroups)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "AgeGroupDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objAgeGroups, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteAgeGroups(AgeGroups objAgeGroups)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objAgeGroups, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;
        }

        public DataView SelectAgeGroupIDForSync()
        {
            String sql = string.Empty;

            sql = "SELECT AgeGroupID FROM tbl_age_groups " +
                  "WHERE SyncStatus='0'";

            return ExecuteQuery(sql);
        }
    }
}
