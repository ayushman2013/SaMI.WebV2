using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;

namespace SaMI.DataAccess
{
   public class TRNPreviousTrainingDAO:BaseDAO
    {
        public TRNPreviousTrainingDAO() : base() { }

        public TRNPreviousTrainingDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNPreviousTraining";
            KeyField = "ID";
        }

        public DataView SelectPreviousTrainingInfo(int TraineeID)
        {
            String sql = "SELECT PT.Name, PT.Year, PT.Institute, PT.Duration " +
                        "FROM TRNPreviousTraining PT " +
                        "JOIN TRNTrainee T ON T.ID = PT.TraineeID " +
                        "WHERE T.ID = " + TraineeID;
            return ExecuteQuery(sql);
        }

        public DataView SelectPreviousTrainingIdByTraineeID(int TraineeID)
        {
            String sql = "SELECT ID FROM TRNPreviousTraining WHERE TraineeID = " + TraineeID;
            return ExecuteQuery(sql);
        }
    }
}
