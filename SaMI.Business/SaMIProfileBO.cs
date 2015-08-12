using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SaMI.DTO;
using SaMI.DataAccess;

namespace SaMI.Business
{
    public class SaMIProfileBO
    {
        public static DataView GetAll()
        {
            return new SaMIProfileDAO().SelectAll();
        }

        public static DataView GetCustom(String search, int ethnicityID, int validRegionID, int districtID, int organizationID, string followUpStatus = "", int vdcID = 0, string gender = "", string discriminated = "", String orderBy = "", int partnerID = 0, int userID = 0, int createdBy = 0, int saMIOrganizationID = 0)
        {
            String strFilter = "WHERE 1=1 AND SP.Status=1 ";

            
            if (ethnicityID > 0)
                strFilter += " AND SP.EthnicityID = " + ethnicityID;
            if (validRegionID > 0)
                strFilter += " AND (',' + RTRIM(SP.ValidRegions) + ',') LIKE '%,'+'" + validRegionID + "'+',%' ";
            if (districtID > 0)
                strFilter += " AND SP.DistrictID = " + districtID;
            if (organizationID > 0)
                strFilter += " AND U.SaMIOrganizationID = " + organizationID;
            if (followUpStatus == "Yes")
                strFilter += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) > 0";
            else if (followUpStatus == "No")
                strFilter += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) = 0";
            if (vdcID > 0)
                strFilter += " AND V.VDCID= " + vdcID;
            if (gender != string.Empty)
                strFilter += " AND SP.Gender = '" + gender + "'";

            if (partnerID > 0)
                strFilter += " AND dbo.ufnGetPartnerCases(SP.SaMIProfileID," + partnerID + ") > 0";

            if (createdBy > 0)
                strFilter += " AND SP.CreatedBy = " + createdBy;
            else if (userID > 0)
                strFilter += " OR SP.CreatedBy = " + userID;

            if (organizationID > 0)
            {
                String strSubFilter = "SELECT tbl_SaMI_profiles.SaMIProfileID " +
                                        "FROM tbl_SaMI_profiles " +
                                        "JOIN tbl_users ON tbl_users.UserID = tbl_SaMI_profiles.CreatedBy " +
                                        "JOIN tbl_user_types ON tbl_user_types.UserTypeID = tbl_users.UserTypeID " +
                                        "LEFT JOIN tbl_SaMI_organizations ON tbl_SaMI_organizations.SaMIOrganizationID = tbl_users.SaMIOrganizationID " +
                                        "WHERE  " +
                                            "tbl_user_types.UserTypeCode = 'Partner' " +
                                            "OR  " +
                                            "tbl_users.SaMIOrganizationID = " + organizationID;
                strFilter += " AND SP.SaMIProfileID IN(" + strSubFilter + ")";
            }

            if (search != string.Empty)
            {
                String[] arrName = search.Split(' ');

                if (arrName.Length == 1)
                {
                    strFilter += " AND (LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(SP.LastName) LIKE'" + arrName[0].ToLower() + "%')";
                }
                else if (arrName.Length == 2)
                {
                    strFilter += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    strFilter += " AND (LOWER(SP.LastName) LIKE '" + arrName[1].ToLower() + "%' OR LOWER(SP.MiddleName) LIKE'" + arrName[1].ToLower() + "%')";
                }
                else if (arrName.Length == 3)
                {
                    strFilter += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    strFilter += " AND LOWER(SP.MiddleName) LIKE '" + arrName[1].ToLower() + "%'";
                    strFilter += " AND LOWER(SP.LastName) LIKE '" + arrName[2].ToLower() + "%'";
                }
            }

            return new SaMIProfileDAO().SelectCustom(strFilter, orderBy);

        }

        public static DataView GetCustomReport(string fromDate, string toDate, int ethnicityID, int districtID, string followUpStatus = "", int vdcID = 0, string gender = "", string discriminated = "", String orderBy = "", Boolean Returnee = false)
        {
            String strFilter = "WHERE 1=1 AND SP.Status=1 ";

            if (ethnicityID > 0)
                strFilter += " AND E.EthnicityID = " + ethnicityID;
            if (districtID > 0)
                strFilter += " AND D.DistrictID = " + districtID;
            if (followUpStatus == "Yes")
                strFilter += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) > 0";
            else if (followUpStatus == "No")
                strFilter += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) = 0";
            if (vdcID > 0)
                strFilter += " AND V.VDCID= " + vdcID;
            if (gender != string.Empty)
                strFilter += " AND SP.Gender = '" + gender + "'";
            if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
                strFilter += " AND ( " +
                                "CONVERT(DATE,SP.RegistrationDate) BETWEEN " +
                                "CONVERT(DATE,'" + fromDate + "') AND CONVERT(DATE,'" + toDate + "') " +
                                ") ";

            return new SaMIProfileDAO().SelectCustomReport(strFilter, orderBy, Returnee);

        }

        public static DataView GetStatistics(string fromDate, string toDate, int ethnicityID, int districtID, string followUpStatus = "", int vdcID = 0, Boolean Returnee = false)
        {
            String strFilter = "WHERE 1=1 AND SP.Status=1 ";


            if (ethnicityID > 0)
                strFilter += " AND E.EthnicityID = " + ethnicityID;
            if (districtID > 0)
                strFilter += " AND D.DistrictID = " + districtID;
            if (followUpStatus == "Yes")
                strFilter += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) > 0";
            else if (followUpStatus == "No")
                strFilter += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) = 0";
            if (vdcID > 0)
                strFilter += " AND V.VDCID= " + vdcID;
            if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
                strFilter += " AND ( " +
                                "CONVERT(DATE,SP.RegistrationDate) BETWEEN " +
                                "CONVERT(DATE,'" + fromDate + "') AND CONVERT(DATE,'" + toDate + "') " +
                                ") ";


            return new SaMIProfileDAO().SelectStatistics(strFilter, Returnee);

        }

        public static int InsertProfile(SaMIProfiles objSaMIProfiles)
        {
            objSaMIProfiles.SaMIProfileNumber = new SaMIProfileDAO().GenerateRegistrationNumber(objSaMIProfiles.DistrictID);
            return new SaMIProfileDAO().InsertProfile(objSaMIProfiles);
        }

        public static int UpdateProfile(SaMIProfiles objSaMIProfiles)
        {
            return new SaMIProfileDAO().UpdateProfile(objSaMIProfiles);
        }

        public static int DeleteProfile(SaMIProfiles objSaMIProfiles)
        {
            return new SaMIProfileDAO().DeleteProfile(objSaMIProfiles);
        }

        public static SaMIProfiles GetSaMIProfile(int SaMIProfileID)
        {
            SaMIProfiles objSaMIProfiles = new SaMIProfiles();
            return (SaMIProfiles)(new SaMIProfileDAO().FillDTO(objSaMIProfiles, "SaMIProfileID=" + SaMIProfileID));
        }

        public static String GetNewRegistratonNumber(int districtID)
        {
            return new SaMIProfileDAO().GenerateRegistrationNumber(districtID);
        }

        public static Boolean CheckSaMIProfileByDistrict(int DistrictID, int SaMIProfileID)
        {
            Boolean blnExists = false;
            DataView dv = new SaMIProfileDAO().Select("SaMIProfileID", "", "DistrictID = " + DistrictID + " AND SaMIProfileID = " + SaMIProfileID);
            if (dv.Count > 0)
            {
                blnExists = true;
            }
            return blnExists;
        }

        public static Boolean CheckSaMIProfileByUser(int UserID, int SaMIProfileID)
        {
            Boolean blnExists = false;
            DataView dv = new SaMIProfileDAO().Select("SaMIProfileID", "", "CreatedBy = " + UserID + " AND SaMIProfileID = " + SaMIProfileID);
            if (dv.Count > 0)
            {
                blnExists = true;
            }
            return blnExists;
        }

        public static String InsertMultipleProfile(List<SaMIProfiles> lstSaMIProfiles)
        {
            return new SaMIProfileDAO().InsertMultipleProfile(lstSaMIProfiles);
        }

        public static DataView GetReport(string strName = "", string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0, int ethnicityID = 0, int validRegionID=0, int districtID = 0, string followUpStatus = "",
                                    int vdcID = 0, string genderid = "", int countryID = 0, int ageGroupID = 0, int educationalStatusID = 0, int frequencyOfVisit = 0,
                                    int reasonForVisiting = 0, int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0,
                                    int decisionStatusID = 0, int ICRecommendationID = 0, int partnerID = 0, int createdBy = 0, int userID = 0,
                                    String Gender = "", String Ethnicity = "", String VDC = "", String Ward = "", String Organization = "", String Country = "", String AgeGroup = "",
                                    String Education = "", String ICKnowledge = "", String Followup = "", String CreatedByName = "", String CreatedDate = "", String Registration = "")
        {
            return new SaMIProfileDAO().SelectReport(strName, RegistrationDateFrom, RegistrationDateTo, organizationID, ethnicityID, validRegionID, districtID, followUpStatus, vdcID, genderid,
                                        countryID, ageGroupID, educationalStatusID, frequencyOfVisit, reasonForVisiting, passportStatusID, jobOfferSourceID, 
                                        workTypeID, decisionStatusID, ICRecommendationID, partnerID, createdBy, userID, Gender, Ethnicity, VDC, Ward,
                                        Organization, Country, AgeGroup, Education, ICKnowledge, Followup, CreatedByName, CreatedDate, Registration);

        }



        public static DataView CountRecord(string strName = "", string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0, 
                                       int ethnicityID = 0, int validRegionID = 0, int districtID = 0, string followUpStatus = "",
                                       int vdcID = 0, string gender = "", int countryID = 0, int ageGroupID = 0,
                                       int educationalStatusID = 0, int frequencyOfVisit = 0, int reasonForVisiting = 0,
                                       int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0, int decisionStatusID = 0, int ICRecommendationID = 0,
                                       string discriminated = "", int createdBy = 0)
        {
            return new SaMIProfileDAO().CountRecord(strName, RegistrationDateFrom, RegistrationDateTo, organizationID, ethnicityID, validRegionID, districtID, followUpStatus,
                                    vdcID, gender, countryID, ageGroupID,
                                    educationalStatusID, frequencyOfVisit, reasonForVisiting,
                                    passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID,
                                    discriminated, createdBy);
        }

        public static DataView CountMaleRecord(string strName = "", string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0,
                                      int ethnicityID = 0, int validRegionID = 0, int districtID = 0, string followUpStatus = "",
                                      int vdcID = 0, string gender = "", int countryID = 0, int ageGroupID = 0,
                                      int educationalStatusID = 0, int frequencyOfVisit = 0, int reasonForVisiting = 0,
                                      int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0, int decisionStatusID = 0, int ICRecommendationID = 0,
                                      string discriminated = "", int createdBy = 0)
        {
            return new SaMIProfileDAO().CountMaleRecord(strName, RegistrationDateFrom, RegistrationDateTo, organizationID, ethnicityID, validRegionID, districtID, followUpStatus,
                                    vdcID, gender, countryID, ageGroupID,
                                    educationalStatusID, frequencyOfVisit, reasonForVisiting,
                                    passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID,
                                    discriminated, createdBy);
        }

        public static DataView CountFemaleRecord(string strName = "", string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0,
                                      int ethnicityID = 0, int validRegionID = 0, int districtID = 0, string followUpStatus = "",
                                      int vdcID = 0, string gender = "", int countryID = 0, int ageGroupID = 0,
                                      int educationalStatusID = 0, int frequencyOfVisit = 0, int reasonForVisiting = 0,
                                      int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0, int decisionStatusID = 0, int ICRecommendationID = 0,
                                      string discriminated = "", int createdBy = 0)
        {
            return new SaMIProfileDAO().CountFemaleRecord(strName, RegistrationDateFrom, RegistrationDateTo, organizationID, ethnicityID, validRegionID, districtID, followUpStatus,
                                    vdcID, gender, countryID, ageGroupID,
                                    educationalStatusID, frequencyOfVisit, reasonForVisiting,
                                    passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID,
                                    discriminated, createdBy);
        }

        
        public static object GetPFEExperience(int SaMiProfileID)
        {
            return new SaMIProfileDAO().SelectPFEExperience(SaMiProfileID);
        }

        public DataView SelectOptions()
        {
            return new SaMIProfileDAO().SelectOptions();
        }

        public static DataView GetSummaryReport(string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0, int ethnicityID = 0, int districtID = 0, string followUpStatus = "",
                                    int vdcID = 0, string genderid = "", int countryID = 0, int ageGroupID = 0,
                                    int educationalStatusID = 0, int frequencyOfVisit = 0, int reasonForVisiting = 0,
                                    int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0, int decisionStatusID = 0, int ICRecommendationID = 0)
        {
            return new SaMIProfileDAO().SelectSummaryReport(RegistrationDateFrom, RegistrationDateTo, organizationID, ethnicityID, districtID, followUpStatus, vdcID, genderid,
                                        countryID, ageGroupID, educationalStatusID, frequencyOfVisit, reasonForVisiting, passportStatusID, jobOfferSourceID,
                                        workTypeID, decisionStatusID, ICRecommendationID);
        }

        public static DataView GetSaMIProfileIDForSync(String CreatedBy)
        {
            return new SaMIProfileDAO().SelectSaMIProfileIDForSync(CreatedBy);
        }

	    public static int UpdateQuery(String Sql)
        {

            return new SaMIProfileDAO().UpdateQuery(Sql);
        }

        public static DataView GetTraineeInfo(int SaMIProfileID)
        {
            return new SaMIProfileDAO().SelectTraineeInfo(SaMIProfileID);
        }

        public static List<List<String>> GetCountRecord(String ethnicityName, String Gender, String date, int DistrictID)
        {
            List<String> lstRegion = new List<String>();
            String Region = "", countRecord = "";
            List<String> lstRecord = new List<String>();
            List<String> lstCountRecord = new List<String>();
            List<List<String>> lstCombined = new List<List<string>>();
            DataView dv = new SaMIProfileDAO().SelectValidRegions(ethnicityName);
            if (dv.Count > 0)
            {
                String validRegions = dv.Table.Rows[0]["validRegions"].ToString();
                int len = dv.Table.Rows[0]["validRegions"].ToString().Length;
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        lstRegion.Add(validRegions.Substring(i, 1));
                    }
                    foreach (String region in lstRegion)
                    {
                        if (region != ",")
                        {
                            DataView dvRecords = new SaMIProfileDAO().SelectRecords(ethnicityName, region, Gender, date, DistrictID);
                            if (dvRecords.Count > 0)
                            {
                                Region = dvRecords.Table.Rows[0]["Region"].ToString();
                                countRecord = dvRecords.Table.Rows[0]["countRecord"].ToString();

                                lstRecord.Add(Region);
                                lstCountRecord.Add(countRecord);

                            }
                        }
                    }
                }
                else
                {
                    DataView dvRecordsforOther = new SaMIProfileDAO().SelectRecords(ethnicityName, "", Gender, date, DistrictID);
                    if (dvRecordsforOther.Count > 0)
                    {
                        countRecord = dvRecordsforOther.Table.Rows[0]["countRecord"].ToString();

                        lstRecord.Add(Region);
                        lstCountRecord.Add(countRecord);

                    }
                }
            }
            lstCombined.Add(lstRecord);
            lstCombined.Add(lstCountRecord);
            return lstCombined;
        }

        public static DataView GetDate()
        {
            return new SaMIProfileDAO().SelectDate();
        }

        public static DataView GetTotalVisitorsRecord(string date)
        {
            return new SaMIProfileDAO().SelectTotalVisitorsRecord(date);
        }

        public static DataView GetTotalVisitorsDistrictRecord(string date, int districtId)
        {
            return new SaMIProfileDAO().SelectTotalVisitorsDistrictRecord(date, districtId);
        }
    }
}
