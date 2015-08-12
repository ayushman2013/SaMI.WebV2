using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class FamilyMembersDAO : BaseDAO
    {
         public FamilyMembersDAO() : base() { }
         public FamilyMembersDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_family_members";
            KeyField = "FamilyMemberID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = string.Empty;
            if (Select)
                sql = "SELECT '' AS FamilyMemberID, '[Select]' AS FamilyMemberName " +
                      "UNION " +
                      "SELECT FamilyMemberID, FamilyMemberName FROM tbl_family_members";
            else
                sql = "SELECT * FROM tbl_family_members";
            return ExecuteQuery(sql);
        }
        public int InsertFamilyMembers(FamilyMembers objFamilyMembers)
        {
            objFamilyMembers.FamilyMemberID = 1;
            BeginTransaction();

            try
            {
                objFamilyMembers.FamilyMemberID = Insert(objFamilyMembers);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objFamilyMembers.FamilyMemberID = -1;
            }

            return objFamilyMembers.FamilyMemberID;
        }

        public int UpdateFamilyMembers(FamilyMembers objFamilyMembers)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "FamilyMemberName", "UpdatedBy", "UpdatedDate" };
                rowsaffected = Update(objFamilyMembers, UpdateProperties);

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
