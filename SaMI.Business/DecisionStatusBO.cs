using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;


namespace SaMI.Business
{
   public class DecisionStatusBO
    {
       public static DataView GetAll(Boolean Select = false)
       {
           return new DecisionStatusDAO().SelectAll(Select);

       }

       public static int InsertDecisionStatus(DecisionStatus objDecisionStatus)
       {
           return new DecisionStatusDAO().InsertDecisionStatus(objDecisionStatus);
       }

       public static DecisionStatus GetDecisionStatus(int DecisionStatusID)
       {
           DecisionStatus objDecisionStatus = new DecisionStatus();
           return (DecisionStatus)(new DecisionStatusDAO().FillDTO(objDecisionStatus, "DecisionStatusID=" + DecisionStatusID));
       }

       public static int UpdateDecisionStatus(DecisionStatus objDecisionStatus)
       {
           return new DecisionStatusDAO().UpdateDecisionStatus(objDecisionStatus);
       }

       public static int Delete(int DecisionStatusID)
       {
           return new DecisionStatusDAO().Delete("DecisionStatusID=" + DecisionStatusID);
       }

       public static int DeleteDecisionStatus(DecisionStatus objDecisionStatus)
       {
           return new DecisionStatusDAO().DeleteDecisionStatus(objDecisionStatus);
       }

       public static DataView GetDecisionStatusIDForSync()
       {
           return new DecisionStatusDAO().SelectDecisionStatusIDForSync();

       }
    }
}
