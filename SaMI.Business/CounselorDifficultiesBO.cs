using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class CounselorDifficultiesBO
    {
        public static DataView GetAll(Boolean Select = false)
        {
            return new CounselorDifficultiesDAO().SelectAll(Select);

        }

        public static int InsertCounselorDifficulty(CounselorDifficulties objCounselorDifficulties)
        {
            return new CounselorDifficultiesDAO().InsertCounselorDifficulty(objCounselorDifficulties);
        }

        public static CounselorDifficulties GetCounselorDifficulties(int CounselorDifficultyID)
        {
            CounselorDifficulties objCounselorDifficulties = new CounselorDifficulties();
            return (CounselorDifficulties)(new CounselorDifficultiesDAO().FillDTO(objCounselorDifficulties, "CounselorDifficultyID=" + CounselorDifficultyID));
        }

        public static int UpdateCounselorDifficulties(CounselorDifficulties objCounselorDifficulties)
        {
            return new CounselorDifficultiesDAO().UpdateCounselorDifficulties(objCounselorDifficulties);
        }

        public static int Delete(int CounselorDifficultyID)
        {
            DataView dv = new CounselorDifficultiesDAO().Select("CounselorDifficultyID", "tbl_follow_up_per_services", "CounselorDifficultyID=" + CounselorDifficultyID);
            if(dv.Count == 0)
                return new CounselorDifficultiesDAO().Delete("CounselorDifficultyID=" + CounselorDifficultyID);
            return -1;
        }

        public static int DeleteCounselorDifficulties(CounselorDifficulties objCounselorDifficulties)
        {
            return new CounselorDifficultiesDAO().DeleteCounselorDifficulties(objCounselorDifficulties);
        }

    }
}
