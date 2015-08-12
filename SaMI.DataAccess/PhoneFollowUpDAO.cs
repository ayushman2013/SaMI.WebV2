using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DBTools;

namespace SaMI.DataAccess
{
    public class PhoneFollowUpDAO : BaseDAO
    {
         public PhoneFollowUpDAO() : base() { }
         public PhoneFollowUpDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }

        public override void Initilize()
        {
            Table = "tbl_phone_follow_up";
            KeyField = "PhoneFollowUpID";
        }

        public DataView SelectAll(Boolean Select = false)
        {
            String sql = "SELECT * FROM tbl_phone_follow_up " +
                         "WHERE Status <> 0 ";
            return ExecuteQuery(sql);
        }

        public DataView SelectBySaMIProfileID(int SaMIProfileID)
        {
            String sql = "SELECT * FROM tbl_phone_follow_up " +
                         "WHERE Status <> 0 AND SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        //public static PhoneFollowUp GetPhoneFollowUp(int SaMIProfileID)
        //{
        //    PhoneFollowUp objPhoneFollowUp = new PhoneFollowUp();
        //    return (PhoneFollowUp)(new PhoneFollowUpDAO().FillDTO(objPhoneFollowUp, "SaMIProfileID=" + SaMIProfileID));
        //}

        public int InsertPhoneFollowUp(PhoneFollowUp objPhonefollowup)
        {
            objPhonefollowup.PhoneFollowUpID = 1;
            BeginTransaction();

            try
            {
                objPhonefollowup.PhoneFollowUpID = Insert(objPhonefollowup);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objPhonefollowup.PhoneFollowUpID = -1;
            }

            return objPhonefollowup.PhoneFollowUpID;
        }

        public int UpdatePhoneFollowUp(PhoneFollowUp objPhonefollowup)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "LeftForFE", "VisitorsCurrentStatus", "VisitorsOtherStatus", "ContractNumber", "MigratedCountry", "MigratedDate", "MigratedAfterTraining",
                    "ManpowerAgent", "AmountPaidforFE", "SourceOfInvestment", "ReceiptReceived", "LeftDocumentBeforeDeparture", "SameWorkAsAgreement", 
                    "SameSalaryAsAgreement", "AdditionalInfo", "Recommendation", "InformantsName", "MigrantRelation", "FollowUpDate", 
                    "Remarks", "UpdatedBy", "UpdatedDate", "Status" };
                rowsaffected = Update(objPhonefollowup, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeletePhoneFollowUp(PhoneFollowUp objPhonefollowup)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objPhonefollowup, UpdateProperties);

                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public DataView SelectPhoneInfoSaMIProfileID(int SaMIProfileID)
        {
            String sql = "SELECT InformantsName, MigrantRelation, FollowUpDate, Remarks, PhoneFollowUpID FROM tbl_phone_follow_up " +
                         "WHERE Status <> 0 AND SaMIProfileID = " + SaMIProfileID;
            return ExecuteQuery(sql);
        }

        public DataView SelectByPhoneFollowUpID(int PhoneFollowUpId)
        {
            String sql = "SELECT * FROM tbl_phone_follow_up " +
                         "WHERE Status <> 0 AND PhoneFollowUpID = " + PhoneFollowUpId;
            return ExecuteQuery(sql);
        }

        public DataView SelectFollowUpIDForSync()
        {
            String sql = string.Empty;
            //sql = "SELECT PhoneFollowUpID FROM tbl_phone_follow_up " +
            //             "WHERE SyncStatus='0'";
            return ExecuteQuery(sql);
        }

        public DataView SelectSourceOfInvestment(int PhoneFollowUpId)
        {
            String sql = "SELECT SourceOfInvestment FROM tbl_phone_follow_up " +
                         "WHERE Status <> 0 AND PhoneFollowUpID = " + PhoneFollowUpId;
            return ExecuteQuery(sql);
        }

        public DataView SelectReport(String Gender = "", String Year = "", int DistrictID = 0)
        {
            String sql = "SELECT DISTINCT " +
                        " (SELECT COUNT(*) FROM tbl_phone_follow_up) AS FollowUpNo, (SELECT COUNT(LEFTFORFE) FROM tbl_phone_follow_up WHERE LeftForFE = 1) AS LeftForFENo, " +
                        " (SELECT COUNT(LeftDocumentBeforeDeparture) FROM tbl_phone_follow_up WHERE LeftDocumentBeforeDeparture = 1) AS LeftDocumentNo, " +
                        " (SELECT COUNT(ReceiptReceived) FROM tbl_phone_follow_up WHERE ReceiptReceived = 1) AS ReceiptReceivedNo, " +
                        " (SELECT COUNT(SameSalaryAsAgreement) FROM tbl_phone_follow_up WHERE SameSalaryAsAgreement = 0) AS PaidLessNo, " +
                        " (SELECT COUNT(VisitorsCurrentStatus) FROM tbl_phone_follow_up WHERE VisitorsCurrentStatus = 'StartedWorkingInNepal') AS NotDecidedMigratingNo, " +
                        " (SELECT COUNT(LeftForFE) FROM tbl_phone_follow_up WHERE LeftForFE = 0) AS NotLeftYetNo,  " +
                        " (SELECT COUNT(VisitorsCurrentStatus) FROM tbl_phone_follow_up  WHERE VisitorsCurrentStatus= 'Decidednottogo') AS DecidedNotToGoNo " +

                        " FROM tbl_phone_follow_up F " +
                        " JOIN tbl_SaMI_profiles S ON S.SaMIProfileID = F.SaMIProfileID " +
                        " WHERE F.Status = 1 AND S.Status = 1 ";

            if(Gender!=String.Empty)
                sql += " AND S.Gender = '"+Gender+"'";
            if (Year != String.Empty)
                sql += " AND S.RegistrationDate LIKE '" + Year + "%'";
            if (DistrictID > 0)
                sql += " AND S.DistrictID = '"+DistrictID+"'";

            return ExecuteQuery(sql);
        }

        public DataView SelectTotalTrainee(String Year = "", int DistrictID = 0)
        {
            String sql = "SELECT COUNT(*) AS TotalTrainee FROM tbl_SaMI_profiles WHERE Status = 1 ";
            if (Year != String.Empty)
                sql += " AND RegistrationDate LIKE '" + Year + "%'";
            if (DistrictID > 0)
                sql += " AND DistrictID = '" + DistrictID + "'";
            return ExecuteQuery(sql);
        }

        public DataView SelectPhoneFollowUpRecord(int districtId = 0, int organizationId = 0, string registrationFrom = "", string registrationTo = "")
        {
            string sql = "SELECT " +
                            "CASE B.MiddleName WHEN '' THEN B.FirstName + ' ' + B.LastName + ', ' + Address + '-' + Ward + ', ' + D.DistrictName " +
                            "ELSE  B.FirstName + ' ' + B.MiddleName + ' ' + B.LastName + ', ' + Address + '-' + Ward + ', ' + D.DistrictName END AS NameAndAddress, " +
                            "B.RegistrationDate, CASE A.LeftForFE WHEN 1 THEN 'YES' ELSE 'NO' END AS LeftForFE, VisitorsCurrentStatus,ContractNumber,B.FamilyMemberPhone, " +
                            "A.MigratedCountry, A.MigratedDate,  " +
                            "CASE A.MigratedAfterTraining WHEN 1 THEN 'YES' ELSE 'NO' END AS MigratedAfterTraining, A.ManpowerAgent, A.AmountPaidforFE, A.SourceOfInvestment, " +
                            "CASE A.ReceiptReceived WHEN 1 THEN 'YES' ELSE 'NO' END AS ReceiptReceivedFromManpower, " +
                            "CASE A.LeftDocumentBeforeDeparture WHEN 1 THEN 'YES' ELSE 'NO' END AS LeftDocumentBeforeDeparture, " +
                            "CASE A.SameWorkAsAgreement WHEN 1 THEN 'YES' ELSE 'NO' END AS SameWorkAsAgreement, " +
                            "CASE A.SameSalaryAsAgreement WHEN 1 THEN 'YES' ELSE 'NO' END AS SameSalaryAsAgreement, " +
                            "A.AdditionalInfo, A.Recommendation, A.InformantsName, A.MigrantRelation, A.FollowUpDate, A.Remarks " +
                            "FROM tbl_phone_follow_up A " +
                            "JOIN tbl_SaMI_profiles B ON B.SaMIProfileID = A.SaMIProfileID " +
                            "JOIN tbl_districts D ON D.DistrictID = B.AddressDistrictID " +
                            "LEFT JOIN tbl_SaMI_organizations C ON C.DistrictID = B.DistrictID " +
                            "WHERE 1=1 AND A.Status = 1 ";
            if (districtId > 0)
                sql += " AND B.DistrictID = " + districtId;
            if (organizationId > 0)
                sql += " AND C.SaMIOrganizationID = " + organizationId;
            if (registrationFrom != "" && registrationTo != "")
                sql += " AND B.RegistrationDate BETWEEN '" + registrationFrom + "' AND '" + registrationTo + "'";
            sql += " ORDER BY B.RegistrationDate DESC";

            return ExecuteQuery(sql);
        }

        public DataView CountPhoneFollowUpRecord(int districtId = 0, int organizationId = 0, string registrationFrom = "", string registrationTo = "")
        {
            string sql = "SELECT COUNT(*) AS Count " +
                            "FROM tbl_phone_follow_up A " +
                            "JOIN tbl_SaMI_profiles B ON B.SaMIProfileID = A.SaMIProfileID " +
                            "LEFT JOIN tbl_SaMI_organizations C ON C.DistrictID = B.DistrictID " +
                            "WHERE 1=1 AND A.Status = 1 ";
            if (districtId > 0)
                sql += " AND B.DistrictID = " + districtId;
            if (organizationId > 0)
                sql += " AND C.SaMIOrganizationID = " + organizationId;
            if (registrationFrom != "" && registrationTo != "")
                sql += " AND B.RegistrationDate BETWEEN '" + registrationFrom + "' AND '" + registrationTo + "'";

            return ExecuteQuery(sql);
        }
    }
}
