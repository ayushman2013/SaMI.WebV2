using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class CounselorDifficultiesPerServiceBO
    {
        public static DataView GetAll(int ServiceProvidedPerSaMIID)
        {
            return new CounselorDifficultiesPerServiceDAO().SelectAll(ServiceProvidedPerSaMIID);
        }

        public static int InsertDifficulty(CounselorDifficultiesPerService objCounselorDifficultiesPerService)
        {
            return new CounselorDifficultiesPerServiceDAO().InsertDifficulty(objCounselorDifficultiesPerService);
        }

        public static int UpdateDifficulty(CounselorDifficultiesPerService objCounselorDifficultiesPerService)
        {
            return new CounselorDifficultiesPerServiceDAO().UpdateDifficulty(objCounselorDifficultiesPerService);
        }

        public static CounselorDifficultiesPerService GetCounselorDifficultiesPerService(int ServiceProvidedPerSaMIID)
        {
            CounselorDifficultiesPerService objCounselorDifficultyID = new CounselorDifficultiesPerService();
            return (CounselorDifficultiesPerService)(new CounselorDifficultiesPerServiceDAO().FillDTO(objCounselorDifficultyID, "ServiceProvidedPerSaMIID=" + ServiceProvidedPerSaMIID));

        }
    }
}
