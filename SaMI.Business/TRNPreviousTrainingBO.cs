using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DataAccess;
using SaMI.DTO;

namespace SaMI.Business
{
   public class TRNPreviousTrainingBO
    {
       public static DataView GetPreviousTrainingInfoByID(int TraineeID)
       {
           return new TRNPreviousTrainingDAO().SelectPreviousTrainingInfo(TraineeID);
       }

       public static DataView GetPreviousTrainingIDByTraineeID(int TraineeID)
       {
           return new TRNPreviousTrainingDAO().SelectPreviousTrainingIdByTraineeID(TraineeID);
       }
    }
}
