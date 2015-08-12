using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
   public class PhoneFollowUpBO
    {
       public static DataView GetAll(Boolean Select = false)
       {
           return new PhoneFollowUpDAO().SelectAll(Select);
       }

       public static int InsertPhoneFollowUp(PhoneFollowUp objPhonefollowup)
       {
           return new PhoneFollowUpDAO().InsertPhoneFollowUp(objPhonefollowup);
       }

       public static PhoneFollowUp GetPhoneFollowUp(int PhoneFollowUpID)
       {
           PhoneFollowUp objPhonefollowup = new PhoneFollowUp();
           return (PhoneFollowUp)(new PhoneFollowUpDAO().FillDTO(objPhonefollowup, "PhoneFollowUpID=" + PhoneFollowUpID));
       }

       public static int UpdatePhoneFollowUp(PhoneFollowUp objPhonefollowup)
       {
           return new PhoneFollowUpDAO().UpdatePhoneFollowUp(objPhonefollowup);
       }

       public static int DeletePhoneFollowUp(PhoneFollowUp objPhonefollowup)
       {
           return new PhoneFollowUpDAO().DeletePhoneFollowUp(objPhonefollowup);
       }

       public static DataView GetFollowUpIDForSync()
       {
           return new PhoneFollowUpDAO().SelectFollowUpIDForSync();
       }

       public static DataView GetBySaMIProfileID(int SaMIProfileID)
       {
           return new PhoneFollowUpDAO().SelectBySaMIProfileID(SaMIProfileID);
       }

       public static DataView GetPhoneInfoSaMIProfileID(int SaMIProfileID)
       {
           return new PhoneFollowUpDAO().SelectPhoneInfoSaMIProfileID(SaMIProfileID);
       }

       public static DataView GetByPhoneFollowUpID(int PhoneFollowUpId)
       {
           return new PhoneFollowUpDAO().SelectByPhoneFollowUpID(PhoneFollowUpId);
       }

       public static List<string> SelectSourceOfInvestment(int PhoneFollowUpID)
       {
           List<string> lstSourceOfInvestment = new List<string>();
           DataView dv = new PhoneFollowUpDAO().SelectSourceOfInvestment(PhoneFollowUpID);

           if (dv.Count > 0)
           {
               String sourceOfInvestment = dv.Table.Rows[0]["SourceOfInvestment"].ToString();
               if (!string.IsNullOrEmpty(sourceOfInvestment))
               {
                   string[] sources = sourceOfInvestment.Split(',');
                   foreach (string source in sources)
                   {
                       if (source != string.Empty)
                           lstSourceOfInvestment.Add(source);
                   }
               }

           }

           return lstSourceOfInvestment;
       }

       public static DataView GetReport(String Gender = "", String Year = "", int DistrictID = 0)
       {
           return new PhoneFollowUpDAO().SelectReport(Gender, Year, DistrictID);
       }

       public static DataView GetTotalTrainee(String Year = "", int DistrictID = 0)
       {
           return new PhoneFollowUpDAO().SelectTotalTrainee(Year, DistrictID);
       }

       public static DataView GetPhoneFollowUpRecord(int districtId = 0, int organizationId = 0, string registrationFrom = "", string registrationTo = "")
       {
           return new PhoneFollowUpDAO().SelectPhoneFollowUpRecord(districtId, organizationId, registrationFrom, registrationTo);
       }

       public static DataView CountPhoneFollowUpRecord(int districtId = 0, int organizationId = 0, string registrationFrom = "", string registrationTo = "")
       {
           return new PhoneFollowUpDAO().CountPhoneFollowUpRecord(districtId, organizationId, registrationFrom, registrationTo);
       }
    }
}
