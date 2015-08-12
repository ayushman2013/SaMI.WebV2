using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class AdditionalFollowUpInfoBO
    {
       public static DataView GetAll()
       {
           return new AddtionalFollowUpInfoDAO().SelectAll();

       }

       public static int InsertAddtionalFollowUpInfo(AdditionalFollowupInfo objAdditionalFollowupInfo)
       {
           return new AddtionalFollowUpInfoDAO().InsertAddtionalFollowUpInfo(objAdditionalFollowupInfo);
       }

       public static AdditionalFollowupInfo GetAdditionalFollowupInfo(int AdditionalFollowUpInfoID)
       {
           AdditionalFollowupInfo objAdditionalFollowupInfo = new AdditionalFollowupInfo();
           return (AdditionalFollowupInfo)(new AddtionalFollowUpInfoDAO().FillDTO(objAdditionalFollowupInfo, "AdditionalFollowUpInfoID=" + AdditionalFollowUpInfoID));
       }
       public static int UpdateAdditionalFollowUpInfo(AdditionalFollowupInfo objAdditionalFollowUpInfo)
       {
           return new AddtionalFollowUpInfoDAO().UpdateAdditionalFollowUpInfo(objAdditionalFollowUpInfo);
       }

       public static int Delete(int AdditionalFollowUpInfoID)
       {
           return new AddtionalFollowUpInfoDAO().Delete("AdditionalFollowUpInfoID=" + AdditionalFollowUpInfoID);
       }

       public static int DeleteAdditionalFollowUpInfo(AdditionalFollowupInfo objAdditionalFollowUpInfo)
       {
           return new AddtionalFollowUpInfoDAO().DeleteAdditionalFollowUpInfo(objAdditionalFollowUpInfo);
       }


       public static DataView GetAdditionalFollowupInfoIDForSync()
       {
           return new AddtionalFollowUpInfoDAO().SelectAdditionalFollowupInfoIDForSync();
       } 
    }
}
