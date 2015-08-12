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
    public class UserDAO : BaseDAO
    {

        public UserDAO() : base() { }
        public UserDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_users";
            KeyField = "UserID";
        }

        public DataView SelectUsers(Boolean Select = false)
        {
            String sql = string.Empty;

            if (Select)
                sql = "SELECT '' AS UserID, '[User]' AS FullName UNION " +
                        "SELECT U.UserID, U.FullName  FROM tbl_users U " +
                        "JOIN tbl_user_types UT ON UT.UserTypeID = U.UserTypeID " +
                        "WHERE UT.UserTypeCode <> 'SA'" +
                        " ORDER BY FullName ASC";
            else
                sql = "SELECT U.UserID, U.FullName  FROM tbl_users U " +
                        "JOIN tbl_user_types UT ON UT.UserTypeID = U.UserTypeID " +
                        "WHERE UT.UserTypeCode <> 'SA'" +
                        " ORDER BY FullName ASC";
            return ExecuteQuery(sql);
        }

        public DataView SelectAllCustom()
        {
            String sql = "SELECT fn_GetUserFullName(UserId) as fullname, tbl_users.* FROM tbl_users";
            return ExecuteQuery(sql);
        }

        public DataView SelectAll(String strFilter = "")
        {
            String sql = "SELECT U.UserID, U.FullName, U.UserName, SH.StakeHolderName, " +
                         "UT.UserTypeDesc, D.DistrictName, SO.SaMIOrganizationName, SKP.SkillPartnerName " +
                         "FROM tbl_users U " +
                         "JOIN tbl_user_types UT ON UT.UserTypeID = U.UserTypeID " +
                         "JOIN tbl_districts D ON D.DistrictID = U.DistrictID " +
                         "LEFT JOIN tbl_stakeholders SH ON SH.StakeHolderID = U.PartnerID " +
                         "LEFT JOIN tbl_skill_partners SKP ON SKP.SkillPartnerID = U.SkillPartnerID " +
                         "LEFT JOIN tbl_SaMI_organizations SO ON SO.SaMIOrganizationID = U.SaMIOrganizationID " +
                         "WHERE UT.UserTypeCode <> 'SA'";
            if (strFilter != string.Empty)
                sql += strFilter;
            return ExecuteQuery(sql);
        }

        public DataView SelectUserInfoByUserNamePassword(String UserName, String Password)
        {
            String sql = "SELECT U.UserID, U.FullName, U.UserName, SH.StakeHolderName, " +
                         "UT.UserTypeDesc, D.DistrictName, SO.SaMIOrganizationName, SKP.SkillPartnerName " +
                         "FROM tbl_users U " +
                         "JOIN tbl_user_types UT ON UT.UserTypeID = U.UserTypeID " +
                         "JOIN tbl_districts D ON D.DistrictID = U.DistrictID " +
                         "LEFT JOIN tbl_stakeholders SH ON SH.StakeHolderID = U.PartnerID " +
                         "LEFT JOIN tbl_skill_partners SKP ON SKP.SkillPartnerID = U.SkillPartnerID " +
                         "LEFT JOIN tbl_SaMI_organizations SO ON SO.SaMIOrganizationID = U.SaMIOrganizationID " +
                         "WHERE UT.UserTypeCode <> 'SA'" +
                         " AND U.FullName = '"+UserName+"'" +
                         " AND U.UserName= '"+Password+"'";
            return ExecuteQuery(sql);
        }

       
        public int InsertUser(Users objUsers)
        {
            objUsers.UserID = 1;
            BeginTransaction();

            try
            {
                objUsers.UserID = Insert(objUsers);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objUsers.UserID = -1;
            }

            return objUsers.UserID;
        }



        public DataView SelectUsersWithRole()
        {
            String sql = "SELECT fn_GetUserFullNameWithRole(user_id) as fullname,users.* FROM users";
            return ExecuteQuery(sql);
        }

        public DataView SelectUsersTypes()
        {
            String sql = "SELECT user_type_id, user_type_name FROM user_types";
            return ExecuteQuery(sql);
        }



        public DataView CheckLogin(string username, string password)
        {
            String sql = "SELECT U.UserID FROM tbl_users AS U " +
                            "JOIN tbl_districts D ON D.DistrictID = U.DistrictID " +
                            "JOIN tbl_user_types UT ON UT.UserTypeID = U.UserTypeID " +
                            "WHERE UserName='" + username + "' and Password='" + password + "'";
            return ExecuteQuery(sql);
        }

        public DataView GetUserInfo(string username)
        {
            String sql = "Select users.user_id,users.username,users.password,user_types.user_type_code from users left join user_types "
                         + " on users.user_type_id=user_types.user_type_id "
             + " where  users.username='" + username + "'";
            //' and user_types.user_type_code='" + usertypecode + "'";
            return ExecuteQuery(sql);
        }


        public int ChangePassword(Users objUsers)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Password", "UpdatedBy", "UpdatedDate", "SyncStatus" };
                rowsaffected = Update(objUsers, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int UpdateUser(Users objUsers)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "FullName", "DistrictID", "Password", "UserTypeID", "PartnerID", "UpdatedBy", "UpdatedDate", "SaMIOrganizationID","SyncStatus" };
                rowsaffected = Update(objUsers, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView CustomSelect(int UserId)
        {

            ArrayList paramField = new ArrayList { "@UserId" };
            ArrayList paramValue = new ArrayList { UserId.ToString() };
            return DBHelper.ExecuteStoredProc("sp_Get_Users", paramField, paramValue);

        }


        public DataView SelectUsersIDByOrganization(int OrganizationID)
        {
            String sql = string.Empty;
            sql = "SELECT UserID FROM  tbl_users  WHERE SaMIOrganizationID=" + OrganizationID;
            return ExecuteQuery(sql);
        }

        public DataView SelectAllUsersIDByOrganizationID(int OrganizationID)
        {
            String sql = string.Empty;
            sql = "SELECT UserID FROM  tbl_users  WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }

        public DataView CheckUserAuthentication(string username, string password)
        {
            String sql = string.Empty;
            sql = "SELECT UserID FROM  tbl_users  WHERE UserName='" + username +"' AND Password='"+password+"'";
            return ExecuteQuery(sql);
        }

        public DataView SelectByDistrictID(int DistrictID, String Select = "")
        {
            String sql = "SELECT '' AS UserID, '" + Select + "' AS FullName UNION " +
                        "SELECT UserID, FullName " +
                         "FROM tbl_users U " +
                         "WHERE DistrictID = '" + DistrictID + "'";

            return ExecuteQuery(sql);
        }

        public DataView SelectByUserId(int UserId)
        {
            String sql = "SELECT * FROM tbl_users " +
                         "WHERE UserID = '" + UserId + "'";

            return ExecuteQuery(sql);
        }
    }
}
