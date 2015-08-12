using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;

namespace SaMI.DataAccess
{
   public class TRNEmploymentDAO:BaseDAO
    {
       public TRNEmploymentDAO() : base() { }

       public TRNEmploymentDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNEmployment";
            KeyField = "ID";
        }

       public DataView SelectEmploymentInfo(int TraineeID)
       {
           String sql = "SELECT RA.ID AS RecruitmentAgencyID, E.OrganizationID, T.Unemployment, E.DepartureDate, E.EmploymentStatusID, E.EmploymentTypeID, DCL.ChecklistID, " +
                       " E.Salary, E.Currency, E.ReturnDate, E.EmploymentPeriod, E.CountryID " +
                       "FROM TRNRecruitmentAgency RA " +
                       "JOIN TRNEmployment E ON E.RecruitmentAgencyID = RA.ID " +
                       "JOIN TRNTrainee T ON T.ID = E.TraineeID " +
                       "JOIN TRNDepartureChecklist DCL ON DCL.EmploymentID = E.ID " +
                       "JOIN tbl_countries C ON C.CountryID = E.CountryID " +
                       "WHERE T.ID = " + TraineeID;
           return ExecuteQuery(sql);
       }

       public DataView SelectEmploymentInfoByTraineeID(int TraineeID)
       {
           String sql = "SELECT * FROM TRNEmployment " +
                       "WHERE TraineeID = " + TraineeID;
           return ExecuteQuery(sql);
       }

       public DataView SelectCheckList(int TraineeID)
       {
           String sql = "SELECT ChecklistID FROM TRNDepartureChecklist D " +
                       "JOIN TRNEmployment E ON E.ID = D.EmploymentID " +
                       "WHERE E.TraineeID = " + TraineeID;
           return ExecuteQuery(sql);
       }

       public DataView SelectEmploymentIdByTraineeId(int TraineeID)
       {
           String sql = "SELECT ID FROM TRNEmployment WHERE TraineeID = " + TraineeID;
           return ExecuteQuery(sql);
       }

       public DataView SelectDepartureIDByEmploymentID(int EmploymentID)
       {
           String sql = "SELECT ID FROM TRNDepartureChecklist WHERE EmploymentID = " + EmploymentID;
           return ExecuteQuery(sql);
       }

       /*Options for Employment Reports*/

       public DataView SelectOptionsEmployment()
       {
           String sql = "SELECT V.VDCName AS 'VDC', ET.EmploymentType AS 'Employment Type', EMP.Organization, C.CountryName, T.PhoneNumber AS 'Contact No.', " +
                        "EMP.DepartureDate AS 'Departure Date', EMP.Salary, ES.EmploymentStatus AS 'Status', EMP.RecruitmentAgency AS 'Recruitment Agency' " +
                        "FROM TRNTrainee T " +
                        "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                        "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                        "JOIN TRNEmployment EMP ON EMP.TraineeID = T.ID " +
                        "JOIN tbl_countries C ON C.CountryID = EMP.CountryID " +
                        "JOIN TRNEmploymentType ET ON ET.ID = EMP.EmploymentTypeID " +
                        "JOIN TRNEmploymentStatus ES ON ES.ID = EMP.EmploymentStatusID  ";
           return ExecuteQuery(sql);
       }

       // Employment Regular
       public DataView SelectCustomEmploymentRegular(string VDCName, string EmploymentType, string Organization, string Country, 
                                                    String PhoneNumber, string DepartureDate, string Salary, string EmploymentStatus, string RecruitmentAgency,
                                                    int EthnicityID, int DistrictID, int EventID, String strOption)
       {
           String sql = "SELECT TE.Batch,TA.TrainingAgency, TE.EventID, TR.TradeName, TE.StartDate, TE.EndDate, T.FirstName + ' ' + T.LastName AS Name, E.EthnicityNameNP, T.Gender, D.DistrictName";
           if (VDCName != String.Empty)
               sql += ", V.VDCName AS 'VDC' ";
           if (EmploymentType != String.Empty)
               sql += ", ET.EmploymentType AS 'Employment Type'";
           if (Organization != String.Empty)
               sql += ", EMP.Organization AS 'Employed Organization'";
           if (Country != String.Empty)
               sql += ",  C.CountryName ";
           if (PhoneNumber != String.Empty)
               sql += ", T.PhoneNumber AS 'Contact No.' ";
           if (DepartureDate != string.Empty)
               sql += ", EMP.DepartureDate AS 'Departure Date' ";
           if (Salary != String.Empty)
               sql += ", EMP.Salary ";
           if (EmploymentStatus != String.Empty)
               sql += ",  ES.EmploymentStatus AS Status";
           if (RecruitmentAgency != string.Empty)
               sql += ", EMP.RecruitmentAgency AS 'Recruitment Agency' ";

           sql += " FROM TRNTrainee T " +
                  "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                   "JOIN TRNTrainingAgency TA ON TE.TrainingAgencyID=TA.ID " +
                       "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                       "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                       "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                       "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                       "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                       "JOIN TRNEmployment EMP ON EMP.TraineeID = T.ID " +
                       "JOIN tbl_countries C ON C.CountryID = EMP.CountryID " +
                       "JOIN TRNEmploymentType ET ON ET.ID = EMP.EmploymentTypeID " +
                       "JOIN TRNEmploymentStatus ES ON ES.ID = EMP.EmploymentStatusID " +
                       "WHERE 1=1 AND T.Status = 1 ";
           
           if (EthnicityID > 0)
               sql += " AND E.EthnicityID = " + EthnicityID;
           if (DistrictID > 0)
               sql += " AND D.DistrictID = " + DistrictID;
           if (EventID > 0)
               sql += " AND TE.TradeNameID = " + EventID;

           if (strOption != String.Empty)
           {
               String[] arrName = strOption.Split(' ');

               if (arrName.Length == 1)
               {
                   sql += " AND (LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(T.LastName) LIKE'" + arrName[0].ToLower() + "%' " +
                               "OR (LOWER(E.EthnicityName) LIKE '" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(D.DistrictName) LIKE'" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(TR.TradeName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.EventID) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.Batch) LIKE'" + arrName[0].ToLower() + "%')) ";
               }
               else if (arrName.Length == 2)
               {
                   sql += " AND LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                   sql += " AND (LOWER(T.LastName) LIKE '" + arrName[1].ToLower() + "%'";
               }
           }

           return ExecuteQuery(sql);
       }

       public DataView SelectEmploymentRegularCount(String strOption, int EthnicityID, int DistrictID, int EventID)
       {
           String sql = "SELECT COUNT(T.ID) AS Count " +
                       "FROM TRNTrainee T " +
                       "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                       "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                       "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                       "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                       "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                       "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                       "JOIN TRNEmployment EMP ON EMP.TraineeID = T.ID " +
                       "JOIN tbl_countries C ON C.CountryID = EMP.CountryID " +
                       "JOIN TRNEmploymentType ET ON ET.ID = EMP.EmploymentTypeID " +
                       "JOIN TRNEmploymentStatus ES ON ES.ID = EMP.EmploymentStatusID " +
                       "WHERE 1=1 AND T.Status = 1 ";
           if (EthnicityID > 0)
               sql += " AND E.EthnicityID = " + EthnicityID;
           if (DistrictID > 0)
               sql += " AND D.DistrictID = " + DistrictID;
           if (EventID > 0)
               sql += " AND TE.TradeNameID = " + EventID;

           if (strOption != String.Empty)
           {
               String[] arrName = strOption.Split(' ');

               if (arrName.Length == 1)
               {
                   sql += " AND (LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(T.LastName) LIKE'" + arrName[0].ToLower() + "%' " +
                               "OR (LOWER(E.EthnicityName) LIKE '" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(D.DistrictName) LIKE'" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(TR.TradeName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.EventID) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.Batch) LIKE'" + arrName[0].ToLower() + "%')) ";
               }
               else if (arrName.Length == 2)
               {
                   sql += " AND LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                   sql += " AND (LOWER(T.LastName) LIKE '" + arrName[1].ToLower() + "%'";
               }
           }

           return ExecuteQuery(sql);
       }

       public DataView SelectEmploymentRegularReport(String strOption, int EthnicityID, int DistrictID, int EventID)
       {
           String sql = "SELECT T.ID, TE.Batch,TA.TrainingAgency, TE.EventID, TR.TradeName, TE.StartDate, TE.EndDate, " +
                       "T.FirstName + ' ' + T.LastName AS Name, E.EthnicityNameNP, T.Gender, " +
                       "D.DistrictName, V.VDCName, ET.EmploymentType, EMP.Organization, C.CountryName, " +
                       "T.PhoneNumber, EMP.DepartureDate, EMP.Salary, EMP.Currency, ES.EmploymentStatus, EMP.RecruitmentAgency, T.CurrentAge " +
                       "FROM TRNTrainee T " +
                       "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                        "JOIN TRNTrainingAgency TA ON TA.ID = TE.TrainingAgencyID " +
                       "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                       "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                       "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                       "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                       "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                       "JOIN TRNEmployment EMP ON EMP.TraineeID = T.ID " +
                       "JOIN tbl_countries C ON C.CountryID = EMP.CountryID " +
                       "JOIN TRNEmploymentType ET ON ET.ID = EMP.EmploymentTypeID " +
                       "JOIN TRNEmploymentStatus ES ON ES.ID = EMP.EmploymentStatusID " +
                       "WHERE 1=1 AND T.Status = 1 ";
           if (EthnicityID > 0)
               sql += " AND E.EthnicityID = " + EthnicityID;
           if (DistrictID > 0)
               sql += " AND D.DistrictID = " + DistrictID;
           if (EventID > 0)
               sql += " AND TE.TradeNameID = " + EventID;

           if (strOption != String.Empty)
           {
               String[] arrName = strOption.Split(' ');

               if (arrName.Length == 1)
               {
                   sql += " AND (LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(T.LastName) LIKE'" + arrName[0].ToLower() + "%' " +
                               "OR (LOWER(E.EthnicityName) LIKE '" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(D.DistrictName) LIKE'" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(TR.TradeName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.EventID) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.Batch) LIKE'" + arrName[0].ToLower() + "%')) ";
               }
               else if (arrName.Length == 2)
               {
                   sql += " AND LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                   sql += " AND (LOWER(T.LastName) LIKE '" + arrName[1].ToLower() + "%'";
               }
           }

           return ExecuteQuery(sql);
       }


       // Employment Cost Sharing
       public DataView SelectCustomEmploymentCostSharing(string VDCName, string EmploymentType, string Organization, string Country,
                                                    String PhoneNumber, string DepartureDate, string Salary, string EmploymentStatus, string RecruitmentAgency,
                                                    int EthnicityID, int DistrictID, int EventID, String strOption)
       {
           String sql = "SELECT TE.Batch,TA.TrainingAgency, TE.EventID, TA.TrainingAgency, TR.TradeName, TE.StartDate, TE.EndDate, T.FirstName + ' ' + T.LastName AS Name, E.EthnicityNameNP, T.Gender, D.DistrictName";
           if (VDCName != String.Empty)
               sql += ", V.VDCName AS 'VDC' ";
           if (EmploymentType != String.Empty)
               sql += ", ET.EmploymentType AS 'Employment Type'";
           if (Organization != String.Empty)
               sql += ", EMP.Organization AS 'Employed Organization'";
           if (Country != String.Empty)
               sql += ",  C.CountryName ";
           if (PhoneNumber != String.Empty)
               sql += ", T.PhoneNumber AS 'Contact No.' ";
           if (DepartureDate != string.Empty)
               sql += ", EMP.DepartureDate AS 'Departure Date' ";
           if (Salary != String.Empty)
               sql += ", EMP.Salary ";
           if (EmploymentStatus != String.Empty)
               sql += ",  ES.EmploymentStatus AS Status";
           if (RecruitmentAgency != string.Empty)
               sql += ", EMP.RecruitmentAgency AS 'Recruitment Agency' ";

           sql += " FROM TRNTrainee T " +
                  "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                    "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                    "JOIN TRNTrainingAgency TA ON TA.ID = TE.TrainingAgencyID " +
                    "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                    "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                    "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                    "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                    "JOIN TRNEmployment EMP ON EMP.TraineeID = T.ID " +
                    "JOIN tbl_countries C ON C.CountryID = EMP.CountryID " +
                    "JOIN TRNEmploymentType ET ON ET.ID = EMP.EmploymentTypeID " +
                    "JOIN TRNEmploymentStatus ES ON ES.ID = EMP.EmploymentStatusID " +
                    "WHERE 1=1 AND T.Status = 1 ";

           if (EthnicityID > 0)
               sql += " AND E.EthnicityID = " + EthnicityID;
           if (DistrictID > 0)
               sql += " AND D.DistrictID = " + DistrictID;
           if (EventID > 0)
               sql += " AND TE.TradeNameID = " + EventID;

           if (strOption != String.Empty)
           {
               String[] arrName = strOption.Split(' ');

               if (arrName.Length == 1)
               {
                   sql += " AND (LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(T.LastName) LIKE'" + arrName[0].ToLower() + "%' " +
                               "OR (LOWER(E.EthnicityName) LIKE '" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(D.DistrictName) LIKE'" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(TR.TradeName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.EventID) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.Batch) LIKE'" + arrName[0].ToLower() + "%')) ";
               }
               else if (arrName.Length == 2)
               {
                   sql += " AND LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                   sql += " AND (LOWER(T.LastName) LIKE '" + arrName[1].ToLower() + "%'";
               }
           }

           return ExecuteQuery(sql);
       }

       public DataView SelectEmploymentCostSharingCount(String strOption, int EthnicityID, int DistrictID, int EventID)
       {
           String sql = "SELECT COUNT(T.ID) AS Count " +
                       "FROM TRNTrainee T " +
                       "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                       "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                       "JOIN TRNTrainingAgency TA ON TA.ID = TE.TrainingAgencyID " +
                       "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                       "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                       "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                       "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                       "JOIN TRNEmployment EMP ON EMP.TraineeID = T.ID " +
                       "JOIN tbl_countries C ON C.CountryID = EMP.CountryID " +
                       "JOIN TRNEmploymentType ET ON ET.ID = EMP.EmploymentTypeID " +
                       "JOIN TRNEmploymentStatus ES ON ES.ID = EMP.EmploymentStatusID " +
                       "WHERE 1=1 AND T.Status = 1 ";
           if (EthnicityID > 0)
               sql += " AND E.EthnicityID = " + EthnicityID;
           if (DistrictID > 0)
               sql += " AND D.DistrictID = " + DistrictID;
           if (EventID > 0)
               sql += " AND TE.TradeNameID = " + EventID;

           if (strOption != String.Empty)
           {
               String[] arrName = strOption.Split(' ');

               if (arrName.Length == 1)
               {
                   sql += " AND (LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(T.LastName) LIKE'" + arrName[0].ToLower() + "%' " +
                               "OR (LOWER(E.EthnicityName) LIKE '" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(D.DistrictName) LIKE'" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(TR.TradeName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.EventID) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.Batch) LIKE'" + arrName[0].ToLower() + "%')) ";
               }
               else if (arrName.Length == 2)
               {
                   sql += " AND LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                   sql += " AND (LOWER(T.LastName) LIKE '" + arrName[1].ToLower() + "%'";
               }
           }

           return ExecuteQuery(sql);
       }

       public DataView SelectEmploymentCostSharingReport(String strOption, int EthnicityID, int DistrictID, int EventID)
       {
           String sql = "SELECT T.ID, TE.Batch, TA.TrainingAgency, TE.EventID, TA.TrainingAgency, TR.TradeName, TE.StartDate, TE.EndDate, " +
                       "T.FirstName + ' ' + T.LastName AS Name, E.EthnicityNameNP, T.Gender, " +
                       "D.DistrictName, V.VDCName, ET.EmploymentType, EMP.Organization, C.CountryName, " +
                       "T.PhoneNumber, EMP.DepartureDate, EMP.Salary, EMP.Currency, ES.EmploymentStatus, EMP.RecruitmentAgency,  T.CurrentAge " +
                       "FROM TRNTrainee T " +
                       "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                        "JOIN TRNTrainingAgency TA ON TA.ID = TE.TrainingAgencyID " +
                       "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +                     
                       "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                       "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                       "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                       "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                       "JOIN TRNEmployment EMP ON EMP.TraineeID = T.ID " +
                       "JOIN tbl_countries C ON C.CountryID = EMP.CountryID " +
                       "JOIN TRNEmploymentType ET ON ET.ID = EMP.EmploymentTypeID " +
                       "JOIN TRNEmploymentStatus ES ON ES.ID = EMP.EmploymentStatusID " +
                       "WHERE 1=1 AND T.Status = 1 ";
           if (EthnicityID > 0)
               sql += " AND E.EthnicityID = " + EthnicityID;
           if (DistrictID > 0)
               sql += " AND D.DistrictID = " + DistrictID;
           if (EventID > 0)
               sql += " AND TE.TradeNameID = " + EventID;

           if (strOption != String.Empty)
           {
               String[] arrName = strOption.Split(' ');

               if (arrName.Length == 1)
               {
                   sql += " AND (LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(T.LastName) LIKE'" + arrName[0].ToLower() + "%' " +
                               "OR (LOWER(E.EthnicityName) LIKE '" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(D.DistrictName) LIKE'" + arrName[0].ToLower() + "%') " +
                               "OR (LOWER(TR.TradeName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.EventID) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.Batch) LIKE'" + arrName[0].ToLower() + "%')) ";
               }
               else if (arrName.Length == 2)
               {
                   sql += " AND LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                   sql += " AND (LOWER(T.LastName) LIKE '" + arrName[1].ToLower() + "%'";
               }
           }

           return ExecuteQuery(sql);
       }



       public DataView SelectByID(int TraineeID)
       {
           String sql = "SELECT E.*, Tr.Unemployment, C.CountryName, T.EmploymentType, S.EmploymentStatus " +
                        "FROM TRNEmployment E " +
                         "JOIN tbl_countries C ON C.CountryID = E.CountryID " +
                         "JOIN TRNEmploymentType T ON T.ID = E.EmploymentTypeID " +
                         "JOIN TRNEmploymentStatus S ON S.ID = E.EmploymentStatusID " +
                         "JOIN TRNTrainee Tr ON Tr.ID = E.TraineeID " +
                       "WHERE E.TraineeID = " + TraineeID;
           return ExecuteQuery(sql);
       }
    }
}
