using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;

namespace SaMI.DataAccess
{
    public class TRNTraineeDAO : BaseDAO
    {
        public TRNTraineeDAO() : base() { }

        public TRNTraineeDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "TRNTrainee";
            KeyField = "ID";
        }

        public int InsertTrainee(TRNTrainee ObjTrainee, TRNCurrentEmployment objCurrentEmployment, TRNEmployment objEmployment, TRNPreviousTraining objPreviousTraining, List<int> checkList)
        {
            ObjTrainee.TraineeID = 1;
            ObjTrainee.CreatedDate = DateTime.Now;
            BeginTransaction();
            try
            {
                // Insert Trainee
                ObjTrainee.TraineeID = Insert(ObjTrainee);


                objEmployment.TraineeID = ObjTrainee.TraineeID;
                if (objEmployment.CountryID != 0 && objEmployment.EmploymentTypeID != 0 && objEmployment.Organization != "" && objEmployment.EmploymentStatusID != 0 && objEmployment.RecruitmentAgency != "")
                {
                    //Insert Employment
                    objEmployment.EmploymentID = Insert(objEmployment);

                    //Insert Departure Check List
                    TRNDepartureCheckList objDepartureCheckList = new TRNDepartureCheckList();
                    foreach (int list in checkList)
                    {
                        objDepartureCheckList.CheckListID = list;
                        objDepartureCheckList.EmploymentID = objEmployment.EmploymentID;
                        objDepartureCheckList.Availability = 1;
                        objDepartureCheckList.DepartureChecklistID = Insert(objDepartureCheckList);
                    }
                }

                //Insert Current Employment
                objCurrentEmployment.TraineeID = ObjTrainee.TraineeID;
                if (objCurrentEmployment.CountryID != 0 && objCurrentEmployment.WorkingYear != "" && objCurrentEmployment.WorkingMonth != "" && objCurrentEmployment.Occupation != "" && objCurrentEmployment.MonthlySalary != "" && objCurrentEmployment.ReturnDate != "")
                {
                    objCurrentEmployment.EmploymentID = Insert(objCurrentEmployment);
                }

                //Insert Previous Training
                objPreviousTraining.TraineeID = ObjTrainee.TraineeID;
                if (objPreviousTraining.Name != "" && objPreviousTraining.Institute != "" && objPreviousTraining.Year != "" && objPreviousTraining.Duration != "")
                {
                    objPreviousTraining.PreviousTrainingID = Insert(objPreviousTraining);
                }


                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                ObjTrainee.TraineeID = -1;
            }

            return ObjTrainee.TraineeID;
        }

        public int InsertEmployment(TRNEmployment objEmployment)
        {
            objEmployment.EmploymentID = 1;
            objEmployment.CreatedDate = DateTime.Now;
            BeginTransaction();
            try
            {
                //Insert Employment
                objEmployment.EmploymentID = Insert(objEmployment);

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objEmployment.EmploymentID = -1;
            }

            return objEmployment.EmploymentID;
        }

        public int InsertCurrentEmployment(TRNCurrentEmployment objCurrentEmployment)
        {
            objCurrentEmployment.EmploymentID = 1;
            objCurrentEmployment.CreatedDate = DateTime.Now;
            BeginTransaction();
            try
            {
                //Insert Employment
                objCurrentEmployment.EmploymentID = Insert(objCurrentEmployment);

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objCurrentEmployment.EmploymentID = -1;
            }

            return objCurrentEmployment.EmploymentID;
        }

        public int InsertPreviousTraining(TRNPreviousTraining objPreviousTraining)
        {
            objPreviousTraining.PreviousTrainingID = 1;

            BeginTransaction();
            try
            {
                //Insert Previous Training
                objPreviousTraining.PreviousTrainingID = Insert(objPreviousTraining);

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objPreviousTraining.PreviousTrainingID = -1;
            }

            return objPreviousTraining.PreviousTrainingID;
        }

        public int InsertDepartureList(TRNDepartureCheckList objDepartureCheckList)
        {
            objDepartureCheckList.DepartureChecklistID = 1;

            BeginTransaction();
            try
            {
                //Insert Departure Check List

                objDepartureCheckList.DepartureChecklistID = Insert(objDepartureCheckList);

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objDepartureCheckList.DepartureChecklistID = -1;
            }

            return objDepartureCheckList.DepartureChecklistID;
        }

        public int UpdateTrainee(TRNTrainee ObjTrainee)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                //Update Trainee
                String[] UpdatePropertiesTrainee = new String[] { "EducationLevelID", "InformationSourceID", "VDCID", "DistrictID", "EventID", "EthnicityID", 
                                                        "FeedDurationTypeID", "CitizenshipIssueDistictID", "FirstName", "LastName", "Gender", "MaritalStatus", 
                                                        "DateOfBirthAD", "DateOfBirthBS", "CurrentAge", "SpecialCase", "Tole", "WardNumber", "PhoneNumber", 
                                                        "MobileNumber", "CitizenshipNumber", "PassportNumber", "FatherName", "FatherTelephone", "ContactPerson", 
                                                        "ContactPersonTelephone", "SelfEmployment", "Agriculture", "Wage", "ForeignEmploymentIncome", "Other", 
                                                        "Unemployment", "RegisteredDate", "NoOfFamilyMember", "Photo", "Status", "ModifiedBy", "ModifiedDate", "ReferredBy",
                                                        "ValidRegions" };
                rowsaffected = Update(ObjTrainee, UpdatePropertiesTrainee);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int UpdateEmployment(TRNEmployment objEmployment)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                //Update Employment
                String[] UpdatePropertiesEmployment = new String[] { "TraineeID", "Organization", "EmploymentTypeID", "EmploymentStatusID", "RecruitmentAgency", 
                                                         "Salary", "Currency", "DepartureDate", "ReturnDate", "Status", "EmploymentPeriod", "CountryID", "ModifiedBy", "ModifiedDate" };
                rowsaffected = Update(objEmployment, UpdatePropertiesEmployment);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int UpdateCurrentEmployment(TRNCurrentEmployment objCurrentEmployment)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                //Update Employment
                String[] UpdatePropertiesEmployment = new String[] { "TraineeID", "CountryID", "WorkingYear", "WorkingMonth", "Occupation", "MonthlySalary", "ReturnDate",
                                                                    "ModifiedBy", "ModifiedDate" };
                rowsaffected = Update(objCurrentEmployment, UpdatePropertiesEmployment);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int UpdatePreviousTraining(TRNPreviousTraining objPreviousTraining)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                //Update Previous Training
                String[] UpdatePropertiesPreviousTraining = new String[] { "TraineeID", "Name", "Year", "Institute", "Duration" };
                rowsaffected = Update(objPreviousTraining, UpdatePropertiesPreviousTraining);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteTrainee(TRNTrainee ObjTrainee)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(ObjTrainee, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteEmployment(TRNEmployment objEmployment)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objEmployment, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteCurrentEmployment(TRNCurrentEmployment objCurrentEmployment)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objCurrentEmployment, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteDepartureCheckList(TRNDepartureCheckList objDepartureCheckList)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Availability" };
                rowsaffected = Update(objDepartureCheckList, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectAllTrainee(Boolean Select = false)
        {
            String sql = "SELECT * FROM TRNTrainee";
            return ExecuteQuery(sql);
        }

        public object SelectTraineeData()
        {
            String sql = "SELECT ID, (T.FirstName + ' ' + T.LastName) AS Name, T.PhoneNumber, D.DistrictName, " +
                        "U.FullName, T.CreatedDate " +
                        "FROM TRNTrainee T " +
                        "JOIN tbl_districts as D ON D.DistrictID = T.DistrictID  " +
                        "JOIN tbl_users U ON U.UserID = T.CreatedBy ";
            return ExecuteQuery(sql);
        }

        public DataView SelectTrainingInfoByID(int TraineeID)
        {
            String sql = "SELECT TA.ID AS TrainingAgencyID, TA.TrainingAgency, TE.ID AS TrainingEventID, TE.TradeNameID " +
                        "FROM TRNTrainingAgency TA " +
                        "JOIN TRNTrainingEvent TE ON TE.TrainingAgencyID = TA.ID " +
                        "JOIN TRNTrainee T ON T.EventID = TE.ID " +
                        "WHERE T.ID = " + TraineeID;
            return ExecuteQuery(sql);
        }

        public DataView SelectByID(int TraineeID)
        {
            String sql = "SELECT * FROM TRNTrainee " +
                        "WHERE ID = " + TraineeID;
            return ExecuteQuery(sql);
        }
        

        public DataView SelectCheckListData(int EthnicityID, int DistrictID, int EventID)
        {
            String sql = "SELECT CL.Checklist " +
                        "FROM TRNTrainee T " +
                        "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                        "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                        "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                        "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                        "JOIN TRNEmployment EMP ON EMP.TraineeID = T.ID " +
                        "JOIN TRNDepartureChecklist DCL ON DCL.EmploymentID = EMP.ID " +
                        "JOIN TRNChecklist CL ON CL.ID = DCL.ChecklistID " +
                        "WHERE 1=1 ";
            if (EthnicityID > 0)
                sql += " AND E.EthnicityID = " + EthnicityID;
            if (DistrictID > 0)
                sql += " AND D.DistrictID = " + DistrictID;
            if (EventID > 0)
                sql += " AND TE.TradeNameID = " + EventID;
            return ExecuteQuery(sql);
        }

        public DataView SelectTrainingData(String strFilter, String strOrderBy = "")
        {
            String sql = "SELECT T.ID, (T.FirstName + ' ' + T.LastName) AS Name, E.EthnicityName, T.PhoneNumber, D.DistrictName, TA.TrainingAgency, " +
                       "U.FullName, T.CreatedDate, TE.EventID, TE.Batch " +
                       "FROM TRNTrainee T " +
                       "JOIN tbl_districts as D ON D.DistrictID = T.DistrictID  " +
                       "JOIN tbl_ethnicity AS E ON E.EthnicityID = T.EthnicityID " +
                       "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                       "JOIN TRNTrainingAgency TA ON TA.ID = TE.TrainingAgencyID " +
                       "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                       "JOIN tbl_users U ON U.UserID = T.CreatedBy ";

            sql += strFilter;

            if (strOrderBy != string.Empty)
                sql += " ORDER BY " + strOrderBy;

            return ExecuteQuery(sql);
        }

        public DataView SelectTrainingDataCount(int EthnicityID, int validRegionID, int DistrictID, int EventID, int createdBy)
        {
            String sql = "SELECT COUNT(T.ID) AS Count " +
                       "FROM TRNTrainee T " +
                       "JOIN tbl_districts as D ON D.DistrictID = T.DistrictID  " +
                       "JOIN tbl_ethnicity AS E ON E.EthnicityID = T.EthnicityID " +
                       "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                       "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                       "JOIN tbl_users U ON U.UserID = T.CreatedBy " +
                       "WHERE 1=1 AND T.Status=1 ";

            if (EthnicityID > 0)
                sql += " AND T.EthnicityID = " + EthnicityID;
            if (validRegionID > 0)
                sql += " AND (',' + RTRIM(T.ValidRegions) + ',') LIKE '%,'+'" + validRegionID + "'+',%' ";
            if (DistrictID > 0)
                sql += " AND D.DistrictID = " + DistrictID;
            if (EventID > 0)
                sql += " AND TE.TradeNameID = " + EventID;
            if (createdBy > 0)
                sql += " AND T.CreatedBy = " + createdBy;

            if (createdBy > 0)
                sql += " AND T.CreatedBy = " + createdBy;

            return ExecuteQuery(sql);
        }

        public DataView SelectTrainingReportCount(string strOption, int EthnicityID, int DistrictID, int EventID, int createdBy)
        {
            String sql = "SELECT COUNT(T.ID) AS Count " +
                       "FROM TRNTrainee T " +
                       "JOIN tbl_districts as D ON D.DistrictID = T.DistrictID  " +
                       "JOIN tbl_ethnicity AS E ON E.EthnicityID = T.EthnicityID " +
                       "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                       "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                       "JOIN tbl_users U ON U.UserID = T.CreatedBy " +
                       "WHERE 1=1 AND T.Status=1 ";

            if (EthnicityID > 0)
                sql += " AND E.EthnicityID = " + EthnicityID;
            if (DistrictID > 0)
                sql += " AND D.DistrictID = " + DistrictID;
            if (EventID > 0)
                sql += " AND TE.TradeNameID = " + EventID;
            if (createdBy > 0)
                sql += " AND T.CreatedBy = " + createdBy;

            if (strOption != String.Empty)
            {
                String[] arrName = strOption.Split(' ');

                if (arrName.Length == 1)
                {
                    sql += " AND (LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(T.LastName) LIKE'" + arrName[0].ToLower() + "%' " +
                                "OR (LOWER(E.EthnicityName) LIKE '" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(D.DistrictName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TR.TradeName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(U.FullName) LIKE'" + arrName[0].ToLower() + "%')) " +
                                "OR (LOWER(TE.EventID) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.Batch) LIKE'" + arrName[0].ToLower() + "%') ";
                }
                else if (arrName.Length == 2)
                {
                    sql += " AND LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND (LOWER(T.LastName) LIKE '" + arrName[1].ToLower() + "%'";
                }

                if (createdBy > 0)
                    sql += " AND T.CreatedBy = " + createdBy;


            }
            return ExecuteQuery(sql);
        }

        // New
        //Training Regular
        public DataView SelectCustomTrainingRegular(string CitizenshipNumber, string PassportNumber, string DOBBS, string VDC, string WardNumber, string MobileNumber, String EducationLevel, string ReferredBy, int EthnicityID, int DistrictID, int EventID, String strOption)
        {
            String sql = "SELECT TE.EventID, TR.TradeName, TE.StartDate, TE.EndDate, T.FirstName, T.LastName  ";
            if (CitizenshipNumber != String.Empty)
                sql += ", T.CitizenshipNumber AS 'Citizenship No.' ";
            if (PassportNumber != String.Empty)
                sql += ", T.PassportNumber AS 'Passport No.' ";

            sql += ", E.EthnicityNameNP AS 'Category' ";

            if (DOBBS != String.Empty)
                sql += ", T.DOBBS AS 'Birth Date' ";

            sql += ", T.Gender, D.DistrictName AS 'District' ";

            if (VDC != String.Empty)
                sql += ", V.VDCName AS 'VDC' ";
            if (WardNumber != String.Empty)
                sql += ", T.WardNumber AS 'Ward No.' ";
            if (MobileNumber != String.Empty)
                sql += ", T.MobileNumber AS 'Contact No.' ";
            if (EducationLevel != String.Empty)
                sql += ", EL.EducationLevel AS 'Education Level' ";
            if (ReferredBy != string.Empty)
                sql += ", T.ReferredBy AS 'Referred By' ";

            sql += " FROM TRNTrainee T " +
                   "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                   "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                   "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                   "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                   "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                   "JOIN tbl_ethnicity E ON T.EthnicityID = E.EthnicityID ";

            sql += "WHERE 1=1 AND T.Status = 1";
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

        public DataView SelectOptionsTrainingRegular()
        {
            String sql = "SELECT T.CitizenshipNumber AS 'Citizenship No.', T.PassportNumber AS 'Passport No.', T.DOBBS AS 'Birth Date', V.VDCName AS 'VDC', " +
                         "T.WardNumber AS 'Ward No.', T.MobileNumber AS 'Contact No.', E.EducationLevel AS 'Education Level', T.ReferredBy AS 'Referred By' " +
                         "FROM TRNTrainee T " +
                         "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                         "JOIN TRNEducationLevel E ON E.ID = T.EducationLevelID";
            return ExecuteQuery(sql);
        }

        public DataView SelectTrainingRegularCount(String strOption, int EthnicityID, int DistrictID, int EventID)
        {
            String sql = "SELECT COUNT(T.ID) AS Count " +
                        "FROM TRNTrainee T " +
                        "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                        "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                        "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                        "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                        "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                        "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
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

        public DataView SelectTrainingRegularReport(String strOption, int EthnicityID, int DistrictID, int EventID)
        {
            String sql = "SELECT TE.Batch,TA.TrainingAgency,TE.EventID, TR.TradeName, TE.StartDate, TE.EndDate, " +
                        "T.FirstName, T.LastName, T.CitizenshipNumber, T.PassportNumber, E.EthnicityNameNP, " +
                        "T.DOBBS, T.Gender, D.DistrictName, V.VDCName, T.WardNumber, T.PhoneNumber, " +
                        "EL.EducationLevel, T.ReferredBy, T.CurrentAge " +
                        "FROM TRNTrainee T " +
                        "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                        "JOIN TRNTrainingAgency TA ON TE.TrainingAgencyID=TA.ID "+
                        "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                        "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                        "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                        "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                        "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
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

        //Training Cost Sharing
        public DataView SelectCustomTrainingCostSharing(string CitizenshipNumber, string PassportNumber, string DOBBS, string VDC, string WardNumber, String EducationLevel, string ReferredBy, int EthnicityID, int DistrictID, int EventID, String strOption)
        {
            String sql = "SELECT TE.Batch,TA.TrainingAgency,TE.EventID, TR.TradeName, TE.StartDate, TE.EndDate, T.FirstName, T.LastName  ";
            if (CitizenshipNumber != String.Empty)
                sql += ", T.CitizenshipNumber AS 'Citizenship No.' ";
            if (PassportNumber != String.Empty)
                sql += ", T.PassportNumber AS 'Passport No.' ";

            sql += ", E.EthnicityNameNP AS 'Category' ";

            if (DOBBS != String.Empty)
                sql += ", T.DOBBS AS 'Birth Date' ";

            sql += ", T.Gender, D.DistrictName AS 'District' ";

            if (VDC != String.Empty)
                sql += ", V.VDCName AS 'VDC' ";
            if (WardNumber != String.Empty)
                sql += ", T.WardNumber AS 'Ward No.' ";
            
            if (EducationLevel != String.Empty)
                sql += ", EL.EducationLevel AS 'Education Level' ";
            if (ReferredBy != string.Empty)
                sql += ", T.ReferredBy AS 'Referred By' ";

            sql += " FROM TRNTrainee T " +
                   "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                   "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                   "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                   "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                    "JOIN TRNTrainingAgency TA ON TE.TrainingAgencyID=TA.ID " +
                   "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                   "JOIN tbl_ethnicity E ON T.EthnicityID = E.EthnicityID ";

            sql += "WHERE 1=1 AND T.Status = 1";
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

        public DataView SelectOptionsTrainingCostSharing()
        {
            String sql = "SELECT T.CitizenshipNumber AS 'Citizenship No.', T.PassportNumber AS 'Passport No.', T.DOBBS AS 'Birth Date', V.VDCName AS 'VDC', " +
                         "T.WardNumber AS 'Ward No.', E.EducationLevel AS 'Education Level', T.ReferredBy AS 'Referred By' " +
                         "FROM TRNTrainee T " +
                         "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
                         "JOIN TRNEducationLevel E ON E.ID = T.EducationLevelID";
            return ExecuteQuery(sql);
        }

        public DataView SelectTrainingCostSharingCount(String strOption, int EthnicityID, int DistrictID, int EventID)
        {
            String sql = "SELECT COUNT(T.ID) AS Count " +
                        "FROM TRNTrainee T " +
                        "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                        "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                        "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                        "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                        "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                        "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
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

        public DataView SelectTrainingCostSharingReport(String strOption, int EthnicityID, int DistrictID, int EventID)
        {
            String sql = "SELECT TE.Batch,TA.TrainingAgency,TE.EventID, TR.TradeName, TE.StartDate, TE.EndDate, " +
                        "T.FirstName, T.LastName, T.CitizenshipNumber, T.PassportNumber, E.EthnicityNameNP, " +
                        "T.DOBBS, T.Gender, D.DistrictName, V.VDCName, T.WardNumber, " +
                        "EL.EducationLevel, T.ReferredBy, T.CurrentAge " +
                        "FROM TRNTrainee T " +
                        "JOIN TRNTrainingEvent TE ON TE.ID = T.EventID " +
                         "JOIN TRNTrainingAgency TA ON TE.TrainingAgencyID=TA.ID " +
                        "JOIN TRNTrade TR ON TR.TRNTradeID = TE.TradeNameID " +
                        "JOIN TRNEducationLevel EL ON EL.ID = T.EducationLevelID " +
                        "JOIN tbl_ethnicity E ON E.EthnicityID = T.EthnicityID " +
                        "JOIN tbl_districts D ON D.DistrictID = T.DistrictID " +
                        "JOIN tbl_VDC V ON V.VDCID = T.VDCID " +
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


    }
}
