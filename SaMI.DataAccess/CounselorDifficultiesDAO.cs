using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
   public class CounselorDifficultiesDAO : BaseDAO
    {
       public CounselorDifficultiesDAO() : base() { }
        public CounselorDifficultiesDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_counselor_difficulties";
            KeyField = "CounselorDifficultyID";
        }

        public DataView SelectAll(Boolean Select)
        {
            String sql = string.Empty;
            if (Select)
            {
                sql = "SELECT 0 AS CounselorDifficultyID, '[Select]' AS CounselorDifficultyDesc " +
                    "UNION" +
                    " SELECT CounselorDifficultyID, CounselorDifficultyDesc FROM tbl_counselor_difficulties " +
                         "WHERE Status <> 0 ";
            }
            else
                sql = "SELECT * FROM tbl_counselor_difficulties " +
                             "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public int InsertCounselorDifficulty(CounselorDifficulties objCounselorDifficulties)
        {
            objCounselorDifficulties.CounselorDifficultyID = 1;
            BeginTransaction();

            try
            {
                objCounselorDifficulties.CounselorDifficultyID = Insert(objCounselorDifficulties);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCounselorDifficulties.CounselorDifficultyID = -1;
            }

            return objCounselorDifficulties.CounselorDifficultyID;
        }

        public int UpdateCounselorDifficulties(CounselorDifficulties objCounselorDifficulties)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "CounselorDifficultyDesc", "UpdatedBy", "UpdatedDate", "Status", "SyncStatus" };
                rowsaffected = Update(objCounselorDifficulties, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteCounselorDifficulties(CounselorDifficulties objCounselorDifficulties)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objCounselorDifficulties, UpdateProperties);

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
