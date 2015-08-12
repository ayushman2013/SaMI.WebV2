using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SaMI.DataAccess;
using SaMI.DTO;

namespace SaMI.Business
{
    public class TRNTraineeBO
    {
        public int InsertTrainee(TRNTrainee ObjTrainee, TRNCurrentEmployment objCurrentEmployment, TRNEmployment objEmployment, TRNPreviousTraining objPreviousTraining,  List<int> checkList)
        {
            ObjTrainee.CreatedDate = DateTime.Now;
            return new TRNTraineeDAO().InsertTrainee(ObjTrainee, objCurrentEmployment, objEmployment, objPreviousTraining,  checkList);
        }

        //public int UpdateTrainee(TRNTrainee ObjTrainee, TRNEmployment objEmployment, TRNPreviousTraining objPreviousTraining)
        //{
        //    ObjTrainee.ModifiedDate = DateTime.Now;
        //    objEmployment.ModifiedDate = DateTime.Now;
        //    return new TRNTraineeDAO().UpdateTrainee(ObjTrainee, objEmployment, objPreviousTraining);
        //}

        //public int DeleteTrainee(TRNTrainee ObjTrainee, TRNEmployment objEmployment, TRNPreviousTraining objPreviousTraining, List<TRNDepartureCheckList> lstDepartureCheckList)
        //{
        //    ObjTrainee.ModifiedDate = DateTime.Now;
        //    return new TRNTraineeDAO().DeleteTrainee(ObjTrainee, objEmployment, objPreviousTraining, lstDepartureCheckList);
        //}

        public DataView GetAllTrainee()
        {
            return new TRNTraineeDAO().SelectAllTrainee();
        }

        public static TRNTrainee GetTraineeByID(int TraineeID)
        {
            TRNTrainee objTRNTrainee = new TRNTrainee();
            return (TRNTrainee)(new TRNTraineeDAO().FillDTO(objTRNTrainee, "ID=" + TraineeID));
        }

        public static object GetTraineeData()
        {
            return new TRNTraineeDAO().SelectTraineeData();
        }

        public static DataView GetTrainingInfoByID(int TraineeID)
        {
            return new TRNTraineeDAO().SelectTrainingInfoByID(TraineeID);
        }

        public int InsertDepartureList(TRNDepartureCheckList objDepartureCheckList)
        {
            return new TRNTraineeDAO().InsertDepartureList(objDepartureCheckList);
        }

        public int InsertPreviousTraining(TRNPreviousTraining objPreviousTraining)
        {
            return new TRNTraineeDAO().InsertPreviousTraining(objPreviousTraining);
        }

        public int InsertEmployment(TRNEmployment objEmployment)
        {
            objEmployment.CreatedDate = DateTime.Now;
            return new TRNTraineeDAO().InsertEmployment(objEmployment);
        }

        public int InsertCurrentEmployment(TRNCurrentEmployment objCurrentEmployment)
        {
            objCurrentEmployment.CreatedDate = DateTime.Now;
            return new TRNTraineeDAO().InsertCurrentEmployment(objCurrentEmployment);
        }

        public int DeleteEmployment(TRNEmployment objEmployment)
        {
            return new TRNTraineeDAO().DeleteEmployment(objEmployment);
        }

        public int DeleteDepartureCheckList(TRNDepartureCheckList objDepartureCheckList)
        {
            return new TRNTraineeDAO().DeleteDepartureCheckList(objDepartureCheckList);
        }

        public int UpdateEmployment(TRNEmployment objEmployment)
        {
            objEmployment.ModifiedDate = DateTime.Now;
            return new TRNTraineeDAO().UpdateEmployment(objEmployment);
        }

        public int UpdateCurrentEmployment(TRNCurrentEmployment objCurrentEmployment)
        {
            objCurrentEmployment.ModifiedDate = DateTime.Now;
            return new TRNTraineeDAO().UpdateCurrentEmployment(objCurrentEmployment);
        }

        public int UpdatePreviousTraining(TRNPreviousTraining objPreviousTraining)
        {
            return new TRNTraineeDAO().UpdatePreviousTraining(objPreviousTraining);
        }

        public int UpdateTrainee(TRNTrainee objTrainee)
        {
            objTrainee.ModifiedDate = DateTime.Now;
            return new TRNTraineeDAO().UpdateTrainee(objTrainee);
        }

        //public static DataView GetTrainingRegularData(int EthnicityID, int DistrictID, int EventID)
        //{
        //    return new TRNTraineeDAO().SelectTrainingRegularData(EthnicityID, DistrictID, EventID);
        //}

        

        //public static DataView GetTrainingCostSharingData(int EthnicityID, int DistrictID, int EventID)
        //{
        //    return new TRNTraineeDAO().SelectTrainingCostSharingData(EthnicityID, DistrictID, EventID);
        //}

        public static DataView GetTrainingByID(int TraineeID)
        {
            return new TRNTraineeDAO().SelectByID(TraineeID);
        }

        public static DataView GetCheckListData(int EthnicityID, int DistrictID, int EventID)
        {
            return new TRNTraineeDAO().SelectCheckListData(EthnicityID, DistrictID, EventID);
        }

        public static DataView GetTrainingData(int EthnicityID = 0, int validRegionID = 0, int DistrictID = 0, int TradeName = 0, String orderBy = "", int createdBy = 0)
        {
            String strFilter = "WHERE 1=1 AND T.Status=1";
            
            if (EthnicityID > 0)
                strFilter += " AND T.EthnicityID = " + EthnicityID;
            if (validRegionID > 0)
                strFilter += " AND (',' + RTRIM(T.ValidRegions) + ',') LIKE '%,'+'" + validRegionID + "'+',%' ";
            if (DistrictID > 0)
                strFilter += " AND D.DistrictID = " + DistrictID;
            if (TradeName > 0)
                strFilter += " AND TE.TradeNameID = " + TradeName;
            if (createdBy > 0)
                strFilter += " AND T.CreatedBy = " + createdBy;

            orderBy += " T.CreatedDate DESC, T.ID DESC,  TE.EventID DESC  ";
               
            return new TRNTraineeDAO().SelectTrainingData(strFilter, orderBy);
        }

        public static DataView GetTrainingReport(String strOption = "", int EthnicityID = 0, int DistrictID = 0, int EventID = 0, String orderBy = "", int createdBy = 0)
        {
            String strFilter = "WHERE 1=1 AND T.Status=1";
            if (EthnicityID > 0)
                strFilter += " AND E.EthnicityID = " + EthnicityID;
            if (DistrictID > 0)
                strFilter += " AND D.DistrictID = " + DistrictID;
            if (EventID > 0)
                strFilter += " AND TE.ID = " + EventID;
            if (createdBy > 0)
                strFilter += " AND T.CreatedBy = " + createdBy;

            if (strOption != String.Empty)
            {
                String[] arrName = strOption.Split(' ');

                if (arrName.Length == 1)
                {
                    strFilter += " AND (LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(T.LastName) LIKE'" + arrName[0].ToLower() + "%' " +
                                "OR (LOWER(E.EthnicityName) LIKE '" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(D.DistrictName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TR.TradeName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(U.FullName) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.EventID) LIKE'" + arrName[0].ToLower() + "%') " +
                                "OR (LOWER(TE.Batch) LIKE'" + arrName[0].ToLower() + "%')) ";
                }
                else if (arrName.Length == 2)
                {
                    strFilter += " AND LOWER(T.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    strFilter += " AND (LOWER(T.LastName) LIKE '" + arrName[1].ToLower() + "%'";
                }

                if (createdBy > 0)
                    strFilter += " AND T.CreatedBy = " + createdBy;

                orderBy += " T.DistrictID ";

            }
            return new TRNTraineeDAO().SelectTrainingData(strFilter, orderBy);
        }

        public static DataView GetTrainingDataCount(int EthnicityID = 0, int validRegionID = 0, int DistrictID = 0, int EventID = 0, int createdBy = 0)
        {
            return new TRNTraineeDAO().SelectTrainingDataCount(EthnicityID, validRegionID, DistrictID, EventID, createdBy);
        }

        public static DataView GetTrainingReportCount(String strOption = "", int EthnicityID = 0, int DistrictID = 0, int EventID = 0, int createdBy = 0)
        {
            return new TRNTraineeDAO().SelectTrainingReportCount(strOption, EthnicityID, DistrictID, EventID, createdBy);
        }

        

        

        public static int DeleteTrainee(TRNTrainee objTraineeProfile)
        {
            return new TRNTraineeDAO().DeleteTrainee(objTraineeProfile);
        }

        //Training Regular
        public DataView GetCustomTrainingRegular(string CitizenshipNumber, string PassportNumber, string DOBBS, string VDCID, string WardNumber, string MobileNumber, string EducationLevelID, string ReferredBy, int EthnicityID, int DistrictID, int EventID, String strOption)
        {
            return new TRNTraineeDAO().SelectCustomTrainingRegular(CitizenshipNumber, PassportNumber, DOBBS, VDCID, WardNumber, MobileNumber, EducationLevelID, ReferredBy, EthnicityID, DistrictID, EventID, strOption);
        }

        public DataView SelectOptionsForTrainingRegular()
        {
            return new TRNTraineeDAO().SelectOptionsTrainingRegular();
        }

        public static DataView GetTrainingRegularCount(String strOption, int EthnicityID, int DistrictID, int EventID)
        {
            return new TRNTraineeDAO().SelectTrainingRegularCount(strOption, EthnicityID, DistrictID, EventID);
        }

        public static DataView GetTrainingRegularReport(String strOption, int EthnicityID, int DistrictID, int EventID)
        {
            return new TRNTraineeDAO().SelectTrainingRegularReport(strOption, EthnicityID, DistrictID, EventID);
        }

        //Training Cost Sharing
        public DataView GetCustomTrainingCostSharing(string CitizenshipNumber, string PassportNumber, string DOBBS, string VDCID, string WardNumber, string EducationLevelID, string ReferredBy, int EthnicityID, int DistrictID, int EventID, String strOption)
        {
            return new TRNTraineeDAO().SelectCustomTrainingCostSharing(CitizenshipNumber, PassportNumber, DOBBS, VDCID, WardNumber, EducationLevelID, ReferredBy, EthnicityID, DistrictID, EventID, strOption);
        }

        public DataView SelectOptionsForTrainingCostSharing()
        {
            return new TRNTraineeDAO().SelectOptionsTrainingCostSharing();
        }

        public static DataView GetTrainingCostSharingCount(String strOption, int EthnicityID, int DistrictID, int EventID)
        {
            return new TRNTraineeDAO().SelectTrainingCostSharingCount(strOption, EthnicityID, DistrictID, EventID);
        }

        public static DataView GetTrainingCostSharingReport(String strOption, int EthnicityID, int DistrictID, int EventID)
        {
            return new TRNTraineeDAO().SelectTrainingCostSharingReport(strOption, EthnicityID, DistrictID, EventID);
        }
    }
}
