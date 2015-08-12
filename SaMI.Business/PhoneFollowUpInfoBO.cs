using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class PhoneFollowUpInfoBO
    {
       public static DataView GetAll(Boolean Select = false)
       {
           return new PhoneFollowUpInfoDAO().SelectAll(Select);
       }

       public static int InsertPhoneFollowUpInfo(PhoneFollowUpInfo objPhonefollowupInfo)
       {
           return new PhoneFollowUpInfoDAO().InsertPhoneFollowUpInfo(objPhonefollowupInfo);
       }

       public static PhoneFollowUpInfo GetByID(int PhoneFollowUpInfoID)
       {
           PhoneFollowUpInfo objPhonefollowupInfo = new PhoneFollowUpInfo();
           return (PhoneFollowUpInfo)(new PhoneFollowUpInfoDAO().FillDTO(objPhonefollowupInfo, "PhoneFollowUpInfoID=" + PhoneFollowUpInfoID));
       }

       public static int UpdatePhoneFollowUpInfo(PhoneFollowUpInfo PhoneFollowUpInfoID)
       {
           return new PhoneFollowUpInfoDAO().UpdatePhoneFollowUpInfo(PhoneFollowUpInfoID);
       }

       public static int DeletePhoneFollowUpInfo(PhoneFollowUpInfo PhoneFollowUpInfoID)
       {
           return new PhoneFollowUpInfoDAO().DeletePhoneFollowUpInfo(PhoneFollowUpInfoID);
       }

       public static DataView GetFollowUpIDForSync()
       {
           return new PhoneFollowUpInfoDAO().SelectFollowUpIDForSync();
       }

       public static DataView GetBySaMIProfileID(int SaMIProfileID)
       {
           return new PhoneFollowUpInfoDAO().SelectBySaMIProfileID(SaMIProfileID);
       }
    }
}
