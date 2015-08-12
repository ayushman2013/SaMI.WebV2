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
    public class CounselorDifficultiesPerServiceDAO : BaseDAO
    {
        public CounselorDifficultiesPerServiceDAO() : base() { }
        public CounselorDifficultiesPerServiceDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_counselor_difficulties_per_service";
            KeyField = "CounseloDifficultyPerServiceID";
        }

        public DataView SelectAll(int ServiceProvidedPerSaMIID)
        {
            String sql = "SELECT * FROM tbl_foreign_employment_status WHERE ServiceProvidedPerSaMIID = " + ServiceProvidedPerSaMIID;
            return ExecuteQuery(sql);
        }

        public int InsertDifficulty(CounselorDifficultiesPerService objCounselorDifficultiesPerService)
        {
            objCounselorDifficultiesPerService.CounseloDifficultyPerServiceID = 1;
            BeginTransaction();

            try
            {
                objCounselorDifficultiesPerService.CounseloDifficultyPerServiceID = Insert(objCounselorDifficultiesPerService);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCounselorDifficultiesPerService.CounseloDifficultyPerServiceID = -1;
            }

            return objCounselorDifficultiesPerService.CounseloDifficultyPerServiceID;
        }

        public int UpdateDifficulty(CounselorDifficultiesPerService objCounselorDifficultiesPerService)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "CounselorDifficultyID"};
                rowsaffected = Update(objCounselorDifficultiesPerService, UpdateProperties);

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
