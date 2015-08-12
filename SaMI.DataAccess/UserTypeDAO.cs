using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DTO;
using SaMI.DBTools;



namespace SaMI.DataAccess
{
   public class UserTypeDAO : BaseDAO

    {
         public UserTypeDAO() : base() { }
        public UserTypeDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_user_types";
            KeyField = "UserTypeID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;

            if(Select)
                sql = "SELECT 0 as UserTypeID, '[Select]' AS UserTypeDesc " +
                       " UNION " +
                       " SELECT UserTypeID, UserTypeDesc FROM tbl_user_types " +
                       "WHERE UserTypeCode <> 'SA'";
                        //"WHERE UserTypeCode <> 'SA' AND UserTypeCode<>'CASEUSR' AND UserTypeCode<>'PARTNER'";
            else
                sql = "SELECT * FROM tbl_user_types WHERE UserTypeCode <> 'SA'";
            return ExecuteQuery(sql);
        }

        public int InsertUserTypes(UserTypes objUserTypes)
        {
            objUserTypes.UserTypeID = 1;
            BeginTransaction();

            try
            {
                objUserTypes.UserTypeID = Insert(objUserTypes);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objUserTypes.UserTypeID = -1;
            }

            return objUserTypes.UserTypeID;
        }

        public int UpdateUserTypes(UserTypes objUserTypes)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "UserTypeDesc", "UserTypeCode", "SyncStatus","UpdatedBy", "UpdatedDate" };
                rowsaffected = Update(objUserTypes, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView GetAllForSync()
        {
            String sql = string.Empty;

            sql = "SELECT UserTypeID  FROM tbl_user_types " +
                   "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }
    }
}
