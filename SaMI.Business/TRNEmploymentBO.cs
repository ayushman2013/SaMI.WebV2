using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DataAccess;
using SaMI.DTO;


namespace SaMI.Business
{
   public class TRNEmploymentBO
    {
       public static DataView GetEmploymentInfoByID(int TraineeID)
       {
           return new TRNEmploymentDAO().SelectEmploymentInfo(TraineeID);
       }

       public static DataView GetEmploymentInfoByTraineeID(int TraineeID)
       {
           return new TRNEmploymentDAO().SelectEmploymentInfoByTraineeID(TraineeID);
       }

       public static DataView GetCheckList(int TraineeID)
       {
           return new TRNEmploymentDAO().SelectCheckList(TraineeID);
       }

       public static DataView GetEmploymentIdByTraineeID(int TraineeID)
       {
           return new TRNEmploymentDAO().SelectEmploymentIdByTraineeId(TraineeID);
       }

       public static DataView GetDepartureIDByEmploymentID(int EmploymentID)
       {
           return new TRNEmploymentDAO().SelectDepartureIDByEmploymentID(EmploymentID);
       }

       //public static DataView GetEmploymentRegularData(int EthnicityID, int DistrictID, int EventID)
       //{
       //    return new TRNEmploymentDAO().SelectEmploymentRegularData(EthnicityID, DistrictID, EventID);
       //}

      

      

       //public static DataView GetEmploymentCostSharingData(int EthnicityID, int DistrictID, int EventID)
       //{
       //    return new TRNEmploymentDAO().SelectEmploymentCostSharingData(EthnicityID, DistrictID, EventID);
       //}

       public static int Delete(int EmploymentID)
       {
           return new TRNEmploymentDAO().Delete("ID=" + EmploymentID);
       }

       

       

       //Options for Employment Reports
       public static DataView SelectOptionsEmployment()
       {
           return new TRNEmploymentDAO().SelectOptionsEmployment();
       }

       //Employment Regular
       public static DataView SelectCustomEmploymentRegular(string VDCName, string EmploymentType, string Organization, string Country,
                                                    String PhoneNumber, string DepartureDate, string Salary, string EmploymentStatus, string RecruitmentAgency,
                                                    int EthnicityID, int DistrictID, int EventID, String strOption)
       {
           return new TRNEmploymentDAO().SelectCustomEmploymentRegular(VDCName, EmploymentType, Organization, Country, PhoneNumber, DepartureDate, Salary,
                                                                       EmploymentStatus, RecruitmentAgency, EthnicityID, DistrictID, EventID, strOption);
       }
       
       public static DataView GetEmploymentRegularCount(String strOption, int EthnicityID, int DistrictID, int EventID)
       {
           return new TRNEmploymentDAO().SelectEmploymentRegularCount(strOption, EthnicityID, DistrictID, EventID);
       }

       public static DataView GetEmploymentRegularReport(String strOption, int EthnicityID, int DistrictID, int EventID)
       {
           return new TRNEmploymentDAO().SelectEmploymentRegularReport(strOption, EthnicityID, DistrictID, EventID);
       }

       //Employment Cost Sharing
       public static DataView SelectCustomEmploymentCostSharing(string VDCName, string EmploymentType, string Organization, string Country,
                                                    String PhoneNumber, string DepartureDate, string Salary, string EmploymentStatus, string RecruitmentAgency,
                                                    int EthnicityID, int DistrictID, int EventID, String strOption)
       {
           return new TRNEmploymentDAO().SelectCustomEmploymentCostSharing(VDCName, EmploymentType, Organization, Country, PhoneNumber, DepartureDate, Salary,
                                                                       EmploymentStatus, RecruitmentAgency, EthnicityID, DistrictID, EventID, strOption);
       }

       public static DataView GetEmploymentCostSharingCount(String strOption, int EthnicityID, int DistrictID, int EventID)
       {
           return new TRNEmploymentDAO().SelectEmploymentCostSharingCount(strOption, EthnicityID, DistrictID, EventID);
       }

       public static DataView GetEmploymentCostSharingReport(String strOption, int EthnicityID, int DistrictID, int EventID)
       {
           return new TRNEmploymentDAO().SelectEmploymentCostSharingReport(strOption, EthnicityID, DistrictID, EventID);
       }

       public static TRNEmployment GetEmploymentByTraineeID(int TraineeID)
       {
           throw new NotImplementedException();
       }

       public static DataView GetByID(int TraineeID)
       {
           return new TRNEmploymentDAO().SelectByID(TraineeID);
       }
    }
}
