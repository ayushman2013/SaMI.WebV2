using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class OccupationTypeDAO : BaseDAO
    {
        public OccupationTypeDAO() : base() { }
        public OccupationTypeDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_occupation_types";
            KeyField = "OccupationTypeID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS OccupationTypeID, '[Select]' AS OccupationTypeDesc " +
                      "UNION " +
                      "SELECT OccupationTypeID, OccupationTypeDesc FROM tbl_occupation_types " +
                         "WHERE Status <> 0 ";
            else
                sql = "SELECT * FROM tbl_occupation_types " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertOccupationType(OccupationTypes objOccupationType)
        {
            objOccupationType.OccupationTypeID = 1;
            BeginTransaction();

            try
            {
                objOccupationType.OccupationTypeID = Insert(objOccupationType);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objOccupationType.OccupationTypeID = -1;
            }

            return objOccupationType.OccupationTypeID;
        }
        public int UpdateOccupationTypes(OccupationTypes objOccupationTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "OccupationTypeDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objOccupationTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteOccupationTypes(OccupationTypes objOccupationTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objOccupationTypes, UpdateProperties);

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
