using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class FollowUpBO
    {
       public static DataView GetAll(Boolean Select = false)
       {
           return new FollowUpDAO().SelectAll(Select);

       }
       public static int InsertFollowUp(FollowUp objfollowup)
       {
           return new FollowUpDAO().InsertFollowUp(objfollowup);
       }
       public static FollowUp GetFollowUp(int FollowUpID)
       {
           FollowUp objFollowUp = new FollowUp();
           return (FollowUp)(new FollowUpDAO().FillDTO(objFollowUp, "FollowUpID=" + FollowUpID));
       }
       public static int UpdateFollowUp(FollowUp objfollowup)
       {
           return new FollowUpDAO().UpdateFollowUp(objfollowup);
       }

       public static int Delete(int FollowUpID)
       {
           DataView dv = new FollowUpDAO().Select("FollowUpID", "tbl_follow_up_per_services", "FollowUpID=" + FollowUpID);
           if(dv.Count == 0)
               return new FollowUpDAO().Delete("FollowUpID=" + FollowUpID);
           return -1;
       }

       public static int DeleteFollowUp(FollowUp objfollowup)
       {
           return new FollowUpDAO().DeleteFollowUp(objfollowup);
       }

       public static DataView GetFollowUpIDForSync()
       {
           return new FollowUpDAO().SelectFollowUpIDForSync();
       }
    }
}
