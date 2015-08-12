using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DataAccess;
using SaMI.DTO;


namespace SaMI.Business
{
   public class TRNCurrentEmploymentBO
    {
       public static DataView GetCurrentEmploymentIdByTraineeID(int TraineeID)
       {
           return new TRNCurrentEmploymentDAO().SelectCurrentEmploymentIdByTraineeId(TraineeID);
       }

       public static int Delete(int CurrentEmploymentID)
       {
           return new TRNCurrentEmploymentDAO().Delete("ID=" + CurrentEmploymentID);
       }

       public static DataView GetCurrentEmploymentInfoByID(int TraineeID)
       {
           return new TRNCurrentEmploymentDAO().SelectCurrentEmploymentInfo(TraineeID);
       }

       public static DataView GetByID(int TraineeID)
       {
           return new TRNCurrentEmploymentDAO().SelectByID(TraineeID);
       }
    }
}
