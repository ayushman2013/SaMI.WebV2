using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaMI.DBTools;
using SaMI.DTO;
using System.Data;
using System.Collections;


namespace SaMI.DataAccess
{
    public class SaMIProfileDAO : BaseDAO
    {
        public SaMIProfileDAO() : base() { }
        public SaMIProfileDAO(MSSqlHelper objDBHelper) : base(objDBHelper) { }


        public override void Initilize()
        {
            Table = "tbl_SaMI_profiles";
            KeyField = "SaMIProfileID";
        }

        public DataView SelectAll()
        {
            String sql = "SELECT * FROM tbl_SaMI_profiles";
            return ExecuteQuery(sql);
        }

        public DataView SelectCustom(String strFilter, String strOrderBy = "")
        {
            String sql = "SELECT SP.SaMIProfileID, SP.SaMIProfileNumber, SO.SaMIOrganizationID, " +
                         "(SP.FirstName + ' ' + SP.MiddleName + ' ' + SP.LastName) as Name, " +
                         "E.EthnicityName, " +
                         "SP.VisitorPhone, " +
                         "D.DistrictName, V.VDCName, " +
                         "CASE Gender " +
                            " WHEN 'M' Then 'Male' " +
                            " ELSE 'Female' " +
                            " END AS Gender, " +
                         "CASE dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) " +
                          "  WHEN 0 Then 'NONE' " +
                           " ELSE 'YES' " +
                           " END AS FollowUpStatus, " +
                         "U.FullName as CreatedByName, " +
                         "CONVERT(varchar(10),SP.CreatedDate, 111) AS CreatedDate " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_ethnicity as E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "LEFT JOIN tbl_SaMI_organizations SO ON SO.SaMIOrganizationID = U.SaMIOrganizationID ";

            sql += strFilter;

            if (strOrderBy != string.Empty)
                sql += " ORDER BY " + strOrderBy;

            return ExecuteQuery(sql);
        }

        public DataView SelectCustomReport(String strFilter, String strOrderBy = "", Boolean Returnee = false)
        {
            String sql = string.Empty;

            if (Returnee)
                sql = "SELECT SP.SaMIProfileID, SP.SaMIProfileNumber, " +
                             "(SP.FirstName + ' ' + SP.MiddleName + ' ' + SP.LastName) as Name, " +
                             "SP.VisitorPhone, " +
                             "D.DistrictName, V.VDCName, " +
                             "CASE Gender " +
                                " WHEN 'M' Then 'Male' " +
                                " ELSE 'Female' " +
                                " END AS Gender, " +
                             "AG.AgeGroupDesc, " +
                                "CASE SP.IsDiscriminated WHEN 0 THEN 'NO' " +
                                "ELSE 'YES' END AS Discriminated, " +
                             "CNT.CountryName " +
                             "FROM tbl_SaMI_profiles AS SP " +
                             "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                             "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
                             "JOIN tbl_age_groups AG ON AG.AgeGroupID = SP.AgeGroupId " +
                             "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID " +
                             "JOIN tbl_previous_fe_experiences PFE ON PFE.SaMIProfileID = SP.SaMIProfileID " +
                             "JOIN tbl_countries AS CNT ON CNT.CountryID = PFE.CountryID ";

            else
                sql = "SELECT SP.SaMIProfileID, SP.SaMIProfileNumber, " +
                         "(SP.FirstName + ' ' + SP.MiddleName + ' ' + SP.LastName) as Name, " +
                         "SP.VisitorPhone, " +
                         "D.DistrictName, V.VDCName, " +
                         "CASE Gender " +
                            " WHEN 'M' Then 'Male' " +
                            " ELSE 'Female' " +
                            " END AS Gender, " +
                         "AG.AgeGroupDesc, " +
                            "CASE SP.IsDiscriminated WHEN 0 THEN 'NO' " +
                            "ELSE 'YES' END AS Discriminated " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_age_groups AG ON AG.AgeGroupID = SP.AgeGroupId " +
                         "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID ";

            sql += strFilter;

            if (strOrderBy != string.Empty)
                sql += " ORDER BY " + strOrderBy;

            return ExecuteQuery(sql);
        }

        public DataView SelectStatistics(String strFilter, Boolean Returnee = false)
        {
            String sql = string.Empty;

            sql = "SELECT " +
                            "SUM(CASE WHEN Gender = 'M' THEN 1 ELSE 0 END) AS MaleCount, " +
                            "SUM(CASE WHEN Gender = 'F' THEN 1 ELSE 0 END) AS FemaleCount,  " +
                            "SUM(CASE WHEN SP.IsDiscriminated = 1 THEN 1 ELSE 0 END) AS DiscriminationCount  " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID ";
            if (Returnee)
                sql += "JOIN tbl_previous_fe_experiences AS PFE ON PFE.SaMIProfileID = SP.SaMIProfileID " +
                        "JOIN tbl_countries AS CNT ON CNT.CountryID = PFE.CountryID ";

            sql += strFilter;

            return ExecuteQuery(sql);
        }



        public int InsertProfile(SaMIProfiles objSaMIProfiles)
        {
            objSaMIProfiles.SaMIProfileID = 1;
            BeginTransaction();

            try
            {
                objSaMIProfiles.SaMIProfileID = Insert(objSaMIProfiles);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                objSaMIProfiles.SaMIProfileID = -1;
            }

            return objSaMIProfiles.SaMIProfileID;
        }

        public int UpdateProfile(SaMIProfiles objSaMIProfiles)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "SaMIProfileNumber", "RegistrationDate", "DistrictID", "Gender", 
                                                            "FirstName", "MiddleName", "LastName", "CasteID",
                                                            "IsDiscriminated", "Address", "AddressDistrictID", "VDCID", "Ward",
                                                            "AddressTemp", "AddressDistrictIDTemp", "VDCTemp", "WardTemp",
                                                            "VisitorPhone", "FamilyMemberPhone",
                                                            "AgeGroupID", "EducationalStatusID", "MaritalStatusID",
                                                            "NoOfChildren", "NoOfAdultMale", "NoOfAdultFemale",
                                                            "OccupationTypeID", "UpdatedBy", "UpdatedDate", "ICKnowledgeID",
                                                            "FrequencyOfVisit", "ReasonForVisiting", "ValidRegions", "EthnicityID", "Status",
                                                            "FamilyHeadName", "FamilyHeadRelation", "SyncStatus"
                                                            };
                rowsaffected = Update(objSaMIProfiles, UpdateProperties);


                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }

        public int DeleteProfile(SaMIProfiles objSaMIProfiles)
        {
            int rowsaffected = -1;
            BeginTransaction();
            try
            {
                String[] UpdateProperties = new String[] { "Status" };
                rowsaffected = Update(objSaMIProfiles, UpdateProperties);


                CommitTransaction();
            }
            catch (Exception e)
            {
                RollBackTransaction();
                rowsaffected = -1;
            }
            return rowsaffected;

        }



        public String GenerateRegistrationNumber(int districtID)
        {
            String strRegNumber = string.Empty;

            String sql = "SELECT [dbo].[ufnGenerateSaMIProfileNumber](" + districtID + ") AS RegistrationNumber";
            DataView dv = ExecuteQuery(sql);

            if (dv.Count > 0)
            {
                strRegNumber = dv.Table.Rows[0]["RegistrationNumber"].ToString();
            }

            return strRegNumber;
        }

        public String InsertMultipleProfile(List<SaMIProfiles> lstSaMIProfiles)
        {
            String strErrorMsg = String.Empty;

            BeginTransaction();

            try
            {
                foreach (SaMIProfiles objSaMIProfiles in lstSaMIProfiles)
                {
                    objSaMIProfiles.CreatedDate = DateTime.Now;
                    objSaMIProfiles.SaMIProfileNumber = GenerateRegistrationNumber(objSaMIProfiles.DistrictID);
                    Insert(objSaMIProfiles);
                }

                CommitTransaction();
            }
            catch (Exception ex)
            {
                strErrorMsg = ex.Message;
                RollBackTransaction();
            }

            return strErrorMsg;
        }

        public DataView SelectReport(string strName = "", string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0, int ethnicityID = 0, int validRegionID = 0, int districtID = 0, string followUpStatus = "",
                                    int vdcID = 0, string genderid = "", int countryID = 0, int ageGroupID = 0,
                                    int educationalStatusID = 0, int frequencyOfVisit = 0, int reasonForVisiting = 0,
                                    int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0, int decisionStatusID = 0, int ICRecommendationID = 0,
                                    int partnerID = 0, int createdBy = 0, int userID = 0, String Gender = "", String Ethnicity = "", String VDC = "", String Ward = "", String Organization = "",
                                        String Country = "", String AgeGroup = "", String Education = "", String ICKnowledge = "", String Followup = "", String CreatedByName = "", String CreatedDate = "", String Registration = "")
        {
            String sql = "SELECT SP.SaMIProfileID, O.SaMIOrganizationID, SP.SaMIProfileNumber, SP.VisitorPhone, D.DistrictName, " +
                         "(SP.FirstName + ' ' + SP.MiddleName + ' ' + SP.LastName) as Name, " +
                         "CASE dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) " +
                          "  WHEN 0 Then 'NONE' " +
                           " ELSE 'YES' " +
                           " END AS FollowUpStatus, " +
                           "U.FullName as CreatedByName, " +
                           "CONVERT(varchar(10),SP.CreatedDate, 111) AS CreatedDate ";
            if (Gender != String.Empty)
                sql += ", CASE Gender " +
                            " WHEN 'M' Then 'Male' " +
                            " ELSE 'Female' " +
                            " END AS Gender ";
            if (Ethnicity != String.Empty)
                sql += ", E.EthnicityName AS Ethnicity ";
            sql += ", SP.VisitorPhone AS Phone, D.DistrictName AS District ";

            if (VDC != String.Empty)
                sql += ", V.VDCName AS VDC ";

            if (Ward != String.Empty)
                sql += ", SP.Ward ";

            if (Organization != String.Empty)
                sql += ", O.SaMIOrganizationName AS Organization ";

            if (Country != String.Empty)
                sql += ", C.CountryName AS Country ";

            if (AgeGroup != String.Empty)
                sql += ", A.AgeGroupDesc AS 'Age Group' ";

            if (Education != String.Empty)
                sql += ", Edu.EducationalStatusDesc AS Education ";

            if (ICKnowledge != String.Empty)
                sql += ", IC.ICKnowledgeDesc AS 'IC Knowledge' ";

            if (Followup != String.Empty)
                sql += ", CASE dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) " +
                          "  WHEN 0 Then 'NONE' " +
                           " ELSE 'YES' " +
                           " END AS FollowUpStatus ";

            if (CreatedByName != String.Empty)
                sql += ", U.FullName as 'Created By' ";

            if (CreatedDate != String.Empty)
                sql += ", CONVERT(varchar(10),SP.CreatedDate, 111) AS 'Created Date' ";

            if (Registration != String.Empty)
                sql += ", CONVERT(varchar(10),SP.RegistrationDate, 111) AS 'Registration Date' ";

            sql += ", CASE FES.ReferToFSkill WHEN 1 THEN 'YES' ELSE 'NO' END AS 'Refer to FSkill'" +
                   ", CASE FES.ReferToCase WHEN 1 THEN 'YES' ELSE 'NO' END AS 'Refer to Case' ";

            sql += "FROM tbl_SaMI_profiles AS SP " +
             "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
             "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
             "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID " +
             "LEFT JOIN tbl_foreign_employment_status AS FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
             "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
             "LEFT JOIN tbl_services_provided_per_SaMI S ON S.SaMIProfileID = SP.SaMIProfileID " +
             "LEFT JOIN tbl_follow_up_per_services F ON F.ServiceProvidedPerSaMIID = S.ServiceProvidedPerSaMIID " +
             "LEFT JOIN tbl_ic_recommendations R ON R.ICRecommendationID = F.ICRecommendationID " +
             "JOIN tbl_SaMI_organizations O ON O.SaMIOrganizationID = U.SaMIOrganizationID " +
             "LEFT JOIN tbl_countries C ON C.CountryID = FES.CountryID " +
             "JOIN tbl_age_groups A ON A.AgeGroupID = SP.AgeGroupID " +
             "JOIN tbl_educational_status Edu ON Edu.EducationalStatusID = SP.EducationalStatusID " +
             "JOIN tbl_ic_knowledges IC ON IC.ICKnowledgeID = SP.ICKnowledgeID ";

            sql += "WHERE 1=1 AND SP.Status=1 ";
            if (RegistrationDateFrom != "" && RegistrationDateTo != "")
                sql += "AND SP.RegistrationDate BETWEEN '" + RegistrationDateFrom + "' AND '" + RegistrationDateTo + "'";
            if (ethnicityID > 0)
                sql += " AND E.EthnicityID = " + ethnicityID;
            if (validRegionID > 0)
                sql += " AND (',' + RTRIM(SP.ValidRegions) + ',') LIKE '%,'+'" + validRegionID + "'+',%' ";
            if (districtID > 0)
                sql += " AND D.DistrictID = " + districtID;
            if (organizationID > 0)
                sql += " AND U.SaMIOrganizationID = " + organizationID;
            if (followUpStatus == "Yes")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) > 0";
            else if (followUpStatus == "No")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) = 0";
            if (vdcID > 0)
                sql += " AND V.VDCID= " + vdcID;
            if (genderid != string.Empty)
                sql += " AND SP.Gender = '" + genderid + "'";

            if (partnerID > 0)
                sql += " AND dbo.ufnGetPartnerCases(SP.SaMIProfileID," + partnerID + ") > 0";


            if (ageGroupID > 0)
                sql += " AND SP.AgeGroupID = " + ageGroupID;
            if (educationalStatusID > 0)
                sql += " AND SP.EducationalStatusID = " + educationalStatusID;
            if (frequencyOfVisit > 0)
                sql += " AND SP.FrequencyOfVisit = " + frequencyOfVisit;
            if (reasonForVisiting > 0)
                sql += " AND SP.ReasonForVisiting = " + reasonForVisiting;
            if (passportStatusID > 0)
                sql += " AND FES.PassportStatusID = " + passportStatusID;
            if (jobOfferSourceID > 0)
                sql += " AND FES.JobOfferSourceID = " + jobOfferSourceID;
            if (workTypeID > 0)
                sql += " AND FES.WorkTypeID = " + workTypeID;
            if (countryID > 0)
                sql += " AND FES.CountryID = " + countryID;
            if (decisionStatusID > 0)
                sql += " AND FES.DecisionStatusID = " + decisionStatusID;
            if (ICRecommendationID > 0)
                sql += " AND (',' + RTRIM(F.ICRecommendationID) + ',') LIKE '%,'+'" + ICRecommendationID + "'+',%' ";


            if (strName != string.Empty)
            {
                String[] arrName = strName.Split(' ');

                if (arrName.Length == 1)
                {
                    sql += " AND (LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(SP.LastName) LIKE'" + arrName[0].ToLower() + "%')";
                }
                else if (arrName.Length == 2)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND (LOWER(SP.LastName) LIKE '" + arrName[1].ToLower() + "%' OR LOWER(SP.MiddleName) LIKE'" + arrName[1].ToLower() + "%')";
                }
                else if (arrName.Length == 3)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND LOWER(SP.MiddleName) LIKE '" + arrName[1].ToLower() + "%'";
                    sql += " AND LOWER(SP.LastName) LIKE '" + arrName[2].ToLower() + "%'";
                }
            }



            if (createdBy > 0)
                sql += " AND SP.CreatedBy = " + createdBy;
            else if (userID > 0)
                sql += " OR SP.CreatedBy = " + userID;


            sql += " ORDER BY SP.DistrictID ";

            return ExecuteQuery(sql);
        }

        public DataView CountRecord(string strName = "", string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0,
                                    int ethnicityID = 0, int validRegionID = 0, int districtID = 0, string followUpStatus = "",
                                    int vdcID = 0, string gender = "", int countryID = 0, int ageGroupID = 0,
                                    int educationalStatusID = 0, int frequencyOfVisit = 0, int reasonForVisiting = 0,
                                    int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0, int decisionStatusID = 0, int ICRecommendationId = 0,
                                    string discriminated = "", int createdBy = 0)
        {
            String sql = "SELECT COUNT(SP.SaMIProfileID) AS Count " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID " +
                         "LEFT JOIN tbl_foreign_employment_status AS FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "LEFT JOIN tbl_services_provided_per_SaMI S ON S.SaMIProfileID = SP.SaMIProfileID " +
                         "LEFT JOIN tbl_follow_up_per_services F ON F.ServiceProvidedPerSaMIID = S.ServiceProvidedPerSaMIID " +
                         "LEFT JOIN tbl_ic_recommendations R ON R.ICRecommendationID = F.ICRecommendationID ";

            sql += "WHERE 1=1 AND SP.Status=1";

            if (RegistrationDateFrom != "" && RegistrationDateTo != "")
                sql += "AND SP.RegistrationDate BETWEEN '" + RegistrationDateFrom + "' AND '" + RegistrationDateTo + "'";
            if (organizationID > 0)
                sql += " AND U.SaMIOrganizationID = " + organizationID;
            if (ethnicityID > 0)
                sql += " AND SP.EthnicityID = " + ethnicityID;
            if (validRegionID > 0)
                sql += " AND (',' + RTRIM(SP.ValidRegions) + ',') LIKE '%,'+'" + validRegionID + "'+',%' ";
            if (districtID > 0)
                sql += " AND SP.DistrictID = " + districtID;
            if (followUpStatus == "Yes")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) > 0";
            else if (followUpStatus == "No")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) = 0";
            if (vdcID > 0)
                sql += " AND V.VDCID= " + vdcID;
            if (gender != string.Empty)
                sql += " AND SP.Gender = '" + gender + "'";

            if (ageGroupID > 0)
                sql += " AND SP.AgeGroupID = " + ageGroupID;
            if (educationalStatusID > 0)
                sql += " AND SP.EducationalStatusID = " + educationalStatusID;
            if (frequencyOfVisit > 0)
                sql += " AND SP.FrequencyOfVisit = " + frequencyOfVisit;
            if (reasonForVisiting > 0)
                sql += " AND SP.ReasonForVisiting = " + reasonForVisiting;
            if (passportStatusID > 0)
                sql += " AND FES.PassportStatusID = " + passportStatusID;
            if (jobOfferSourceID > 0)
                sql += " AND FES.JobOfferSourceID = " + jobOfferSourceID;
            if (workTypeID > 0)
                sql += " AND FES.WorkTypeID = " + workTypeID;
            if (countryID > 0)
                sql += " AND FES.CountryID = " + countryID;
            if (decisionStatusID > 0)
                sql += " AND FES.DecisionStatusID = " + decisionStatusID;
            if (ICRecommendationId > 0)
                sql += " AND (',' + RTRIM(F.ICRecommendationID) + ',') LIKE '%,'+'" + ICRecommendationId + "'+',%' ";

            if (strName != string.Empty)
            {
                String[] arrName = strName.Split(' ');

                if (arrName.Length == 1)
                {
                    sql += " AND (LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(SP.LastName) LIKE'" + arrName[0].ToLower() + "%')";
                }
                else if (arrName.Length == 2)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND (LOWER(SP.LastName) LIKE '" + arrName[1].ToLower() + "%' OR LOWER(SP.MiddleName) LIKE'" + arrName[1].ToLower() + "%')";
                }
                else if (arrName.Length == 3)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND LOWER(SP.MiddleName) LIKE '" + arrName[1].ToLower() + "%'";
                    sql += " AND LOWER(SP.LastName) LIKE '" + arrName[2].ToLower() + "%'";
                }
            }
            if (createdBy > 0)
                sql += " AND SP.CreatedBy = " + createdBy;

            return ExecuteQuery(sql);
        }

        public DataView CountMaleRecord(string strName = "", string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0,
                                   int ethnicityID = 0, int validRegionID = 0, int districtID = 0, string followUpStatus = "",
                                   int vdcID = 0, string gender = "", int countryID = 0, int ageGroupID = 0,
                                   int educationalStatusID = 0, int frequencyOfVisit = 0, int reasonForVisiting = 0,
                                   int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0, int decisionStatusID = 0, int ICRecommendationId = 0,
                                   string discriminated = "", int createdBy = 0)
        {
            String sql = "SELECT COUNT(SP.SaMIProfileID) AS Count " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID " +
                         "LEFT JOIN tbl_foreign_employment_status AS FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "LEFT JOIN tbl_services_provided_per_SaMI S ON S.SaMIProfileID = SP.SaMIProfileID " +
                         "LEFT JOIN tbl_follow_up_per_services F ON F.ServiceProvidedPerSaMIID = S.ServiceProvidedPerSaMIID " +
                         "LEFT JOIN tbl_ic_recommendations R ON R.ICRecommendationID = F.ICRecommendationID ";

            sql += "WHERE 1=1 AND SP.Status=1 AND SP.Gender = 'M'";

            if (RegistrationDateFrom != "" && RegistrationDateTo != "")
                sql += "AND SP.RegistrationDate BETWEEN '" + RegistrationDateFrom + "' AND '" + RegistrationDateTo + "'";
            if (organizationID > 0)
                sql += " AND U.SaMIOrganizationID = " + organizationID;
            if (ethnicityID > 0)
                sql += " AND SP.EthnicityID = " + ethnicityID;
            if (validRegionID > 0)
                sql += " AND (',' + RTRIM(SP.ValidRegions) + ',') LIKE '%,'+'" + validRegionID + "'+',%' ";
            if (districtID > 0)
                sql += " AND SP.DistrictID = " + districtID;
            if (followUpStatus == "Yes")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) > 0";
            else if (followUpStatus == "No")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) = 0";
            if (vdcID > 0)
                sql += " AND V.VDCID= " + vdcID;
            if (gender != string.Empty)
                sql += " AND SP.Gender = '" + gender + "'";

            if (ageGroupID > 0)
                sql += " AND SP.AgeGroupID = " + ageGroupID;
            if (educationalStatusID > 0)
                sql += " AND SP.EducationalStatusID = " + educationalStatusID;
            if (frequencyOfVisit > 0)
                sql += " AND SP.FrequencyOfVisit = " + frequencyOfVisit;
            if (reasonForVisiting > 0)
                sql += " AND SP.ReasonForVisiting = " + reasonForVisiting;
            if (passportStatusID > 0)
                sql += " AND FES.PassportStatusID = " + passportStatusID;
            if (jobOfferSourceID > 0)
                sql += " AND FES.JobOfferSourceID = " + jobOfferSourceID;
            if (workTypeID > 0)
                sql += " AND FES.WorkTypeID = " + workTypeID;
            if (countryID > 0)
                sql += " AND FES.CountryID = " + countryID;
            if (decisionStatusID > 0)
                sql += " AND FES.DecisionStatusID = " + decisionStatusID;
            if (ICRecommendationId > 0)
                sql += " AND (',' + RTRIM(F.ICRecommendationID) + ',') LIKE '%,'+'" + ICRecommendationId + "'+',%' ";

            if (strName != string.Empty)
            {
                String[] arrName = strName.Split(' ');

                if (arrName.Length == 1)
                {
                    sql += " AND (LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(SP.LastName) LIKE'" + arrName[0].ToLower() + "%')";
                }
                else if (arrName.Length == 2)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND (LOWER(SP.LastName) LIKE '" + arrName[1].ToLower() + "%' OR LOWER(SP.MiddleName) LIKE'" + arrName[1].ToLower() + "%')";
                }
                else if (arrName.Length == 3)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND LOWER(SP.MiddleName) LIKE '" + arrName[1].ToLower() + "%'";
                    sql += " AND LOWER(SP.LastName) LIKE '" + arrName[2].ToLower() + "%'";
                }
            }
            if (createdBy > 0)
                sql += " AND SP.CreatedBy = " + createdBy;

            return ExecuteQuery(sql);
        }

        public DataView CountFemaleRecord(string strName = "", string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0,
                                   int ethnicityID = 0, int validRegionID = 0, int districtID = 0, string followUpStatus = "",
                                   int vdcID = 0, string gender = "", int countryID = 0, int ageGroupID = 0,
                                   int educationalStatusID = 0, int frequencyOfVisit = 0, int reasonForVisiting = 0,
                                   int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0, int decisionStatusID = 0, int ICRecommendationId = 0,
                                   string discriminated = "", int createdBy = 0)
        {
            String sql = "SELECT COUNT(SP.SaMIProfileID) AS Count " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID " +
                         "LEFT JOIN tbl_foreign_employment_status AS FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "LEFT JOIN tbl_services_provided_per_SaMI S ON S.SaMIProfileID = SP.SaMIProfileID " +
                         "LEFT JOIN tbl_follow_up_per_services F ON F.ServiceProvidedPerSaMIID = S.ServiceProvidedPerSaMIID " +
                         "LEFT JOIN tbl_ic_recommendations R ON R.ICRecommendationID = F.ICRecommendationID ";

            sql += "WHERE 1=1 AND SP.Status=1 AND SP.Gender = 'F'";

            if (RegistrationDateFrom != "" && RegistrationDateTo != "")
                sql += "AND SP.RegistrationDate BETWEEN '" + RegistrationDateFrom + "' AND '" + RegistrationDateTo + "'";
            if (organizationID > 0)
                sql += " AND U.SaMIOrganizationID = " + organizationID;
            if (ethnicityID > 0)
                sql += " AND SP.EthnicityID = " + ethnicityID;
            if (validRegionID > 0)
                sql += " AND (',' + RTRIM(SP.ValidRegions) + ',') LIKE '%,'+'" + validRegionID + "'+',%' ";
            if (districtID > 0)
                sql += " AND SP.DistrictID = " + districtID;
            if (followUpStatus == "Yes")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) > 0";
            else if (followUpStatus == "No")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) = 0";
            if (vdcID > 0)
                sql += " AND V.VDCID= " + vdcID;
            if (gender != string.Empty)
                sql += " AND SP.Gender = '" + gender + "'";

            if (ageGroupID > 0)
                sql += " AND SP.AgeGroupID = " + ageGroupID;
            if (educationalStatusID > 0)
                sql += " AND SP.EducationalStatusID = " + educationalStatusID;
            if (frequencyOfVisit > 0)
                sql += " AND SP.FrequencyOfVisit = " + frequencyOfVisit;
            if (reasonForVisiting > 0)
                sql += " AND SP.ReasonForVisiting = " + reasonForVisiting;
            if (passportStatusID > 0)
                sql += " AND FES.PassportStatusID = " + passportStatusID;
            if (jobOfferSourceID > 0)
                sql += " AND FES.JobOfferSourceID = " + jobOfferSourceID;
            if (workTypeID > 0)
                sql += " AND FES.WorkTypeID = " + workTypeID;
            if (countryID > 0)
                sql += " AND FES.CountryID = " + countryID;
            if (decisionStatusID > 0)
                sql += " AND FES.DecisionStatusID = " + decisionStatusID;
            if (ICRecommendationId > 0)
                sql += " AND (',' + RTRIM(F.ICRecommendationID) + ',') LIKE '%,'+'" + ICRecommendationId + "'+',%' ";

            if (strName != string.Empty)
            {
                String[] arrName = strName.Split(' ');

                if (arrName.Length == 1)
                {
                    sql += " AND (LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%' OR LOWER(SP.LastName) LIKE'" + arrName[0].ToLower() + "%')";
                }
                else if (arrName.Length == 2)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND (LOWER(SP.LastName) LIKE '" + arrName[1].ToLower() + "%' OR LOWER(SP.MiddleName) LIKE'" + arrName[1].ToLower() + "%')";
                }
                else if (arrName.Length == 3)
                {
                    sql += " AND LOWER(SP.FirstName) LIKE '" + arrName[0].ToLower() + "%'";
                    sql += " AND LOWER(SP.MiddleName) LIKE '" + arrName[1].ToLower() + "%'";
                    sql += " AND LOWER(SP.LastName) LIKE '" + arrName[2].ToLower() + "%'";
                }
            }
            if (createdBy > 0)
                sql += " AND SP.CreatedBy = " + createdBy;

            return ExecuteQuery(sql);
        }

        public object SelectPFEExperience(int SaMIProfileID)
        {
            string sql = "SELECT PF.ForeignEmploymentExperienceID, PF.SaMIProfileID, C.CountryName, J.JobOfferedTypeDesc, PF.StayDuration " +
                         "FROM tbl_previous_fe_experiences PF " +
                         "JOIN tbl_countries C ON C.CountryID = PF.CountryID " +
                         "JOIN tbl_job_offered_types J ON J.JobOfferedTypeID = PF.JobOfferedTypeID " +
                         "WHERE SaMIProfileID = " + SaMIProfileID +
                         " AND PF.Status = '1'";
            return ExecuteQuery(sql);
        }

        public DataView SelectOptions()
        {
            String sql = "SELECT SP.SaMIProfileID, U.SaMIOrganizationID, SP.SaMIProfileNumber, " +
                         "(SP.FirstName + ' ' + SP.MiddleName + ' ' + SP.LastName) as Name, " +
                         "CASE Gender  WHEN 'M' Then 'Male'  ELSE 'Female'  END AS Gender, E.EthnicityName, " +
                         "SP.VisitorPhone, D.DistrictName, V.VDCName, SP.Ward, O.SaMIOrganizationName, C.CountryName, " +
                         "A.AgeGroupDesc, Edu.EducationalStatusDesc, IC.ICKnowledgeDesc, " +
                         "CASE dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) " +
                         "WHEN 0 Then 'NONE'  ELSE 'YES'  END AS FollowUpStatus, " +
                         "U.FullName as CreatedByName, " +
                         "CONVERT(varchar(10),SP.CreatedDate, 111) AS CreatedDate, SP.RegistrationDate " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID " +
                         "LEFT JOIN tbl_foreign_employment_status AS FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "LEFT JOIN tbl_services_provided_per_SaMI S ON S.SaMIProfileID = SP.SaMIProfileID " +
                         "LEFT JOIN tbl_follow_up_per_services F ON F.ServiceProvidedPerSaMIID = S.ServiceProvidedPerSaMIID " +
                         "LEFT JOIN tbl_ic_recommendations R ON R.ICRecommendationID = F.ICRecommendationID " +
                         "JOIN tbl_SaMI_organizations O ON O.SaMIOrganizationID = U.SaMIOrganizationID " +
                         "LEFT JOIN tbl_countries C ON C.CountryID = FES.CountryID " +
                         "JOIN tbl_age_groups A ON A.AgeGroupID = SP.AgeGroupID " +
                         "JOIN tbl_educational_status Edu ON Edu.EducationalStatusID = SP.EducationalStatusID " +
                         "JOIN tbl_ic_knowledges IC ON IC.ICKnowledgeID = SP.ICKnowledgeID ";
            return ExecuteQuery(sql);
        }





        public DataView SelectSummaryReport(string RegistrationDateFrom = "", string RegistrationDateTo = "", int organizationID = 0, int ethnicityID = 0, int districtID = 0, string followUpStatus = "",
                                    int vdcID = 0, string genderid = "", int countryID = 0, int ageGroupID = 0,
                                    int educationalStatusID = 0, int frequencyOfVisit = 0, int reasonForVisiting = 0,
                                    int passportStatusID = 0, int jobOfferSourceID = 0, int workTypeID = 0, int decisionStatusID = 0, int ICRecommendationID = 0)
        {
            String sql = "SELECT DISTINCT(SELECT COUNT(*) FROM tbl_SaMI_profiles WHERE Gender='M')AS NoOfMale, " +
                         "(SELECT COUNT(*) FROM tbl_SaMI_profiles WHERE Gender='F')AS NoOfFemale " +
                         "FROM tbl_SaMI_profiles AS SP " +
                         "JOIN tbl_districts as D ON D.DistrictID = SP.DistrictID " +
                         "JOIN tbl_ethnicity E ON E.EthnicityID = SP.EthnicityID " +
                         "JOIN tbl_vdc AS V ON V.VDCID = SP.VDCID " +
                         "LEFT JOIN tbl_foreign_employment_status AS FES ON FES.SaMIProfileID = SP.SaMIProfileID " +
                         "JOIN tbl_users U ON U.UserID = SP.CreatedBy " +
                         "LEFT JOIN tbl_services_provided_per_SaMI S ON S.SaMIProfileID = SP.SaMIProfileID " +
                         "LEFT JOIN tbl_follow_up_per_services F ON F.ServiceProvidedPerSaMIID = S.ServiceProvidedPerSaMIID " +
                         "LEFT JOIN tbl_ic_recommendations R ON R.ICRecommendationID = F.ICRecommendationID " +
                         "JOIN tbl_SaMI_organizations O ON O.SaMIOrganizationID = U.SaMIOrganizationID " +
                         "LEFT JOIN tbl_countries C ON C.CountryID = FES.CountryID " +
                         "JOIN tbl_age_groups A ON A.AgeGroupID = SP.AgeGroupID " +
                         "JOIN tbl_educational_status Edu ON Edu.EducationalStatusID = SP.EducationalStatusID ";

            sql += "WHERE 1=1 AND SP.Status=1 ";
            if (RegistrationDateFrom != "" && RegistrationDateTo != "")
                sql += "AND SP.RegistrationDate BETWEEN '" + RegistrationDateFrom + "' AND '" + RegistrationDateTo + "'";
            if (ethnicityID > 0)
                sql += " AND E.EthnicityID = " + ethnicityID;
            if (districtID > 0)
                sql += " AND D.DistrictID = " + districtID;
            if (organizationID > 0)
                sql += " AND U.SaMIOrganizationID = " + organizationID;
            if (followUpStatus == "Yes")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) > 0";
            else if (followUpStatus == "No")
                sql += " AND dbo.ufnGetOtherFollowupCount(dbo.ufnGetServiceProvidedPerSaMIID(SP.SaMIProfileID)) = 0";
            if (vdcID > 0)
                sql += " AND V.VDCID= " + vdcID;
            if (genderid != string.Empty)
                sql += " AND SP.Gender = '" + genderid + "'";

            if (ageGroupID > 0)
                sql += " AND SP.AgeGroupID = " + ageGroupID;
            if (educationalStatusID > 0)
                sql += " AND SP.EducationalStatusID = " + educationalStatusID;
            if (frequencyOfVisit > 0)
                sql += " AND SP.FrequencyOfVisit = " + frequencyOfVisit;
            if (reasonForVisiting > 0)
                sql += " AND SP.ReasonForVisiting = " + reasonForVisiting;
            if (passportStatusID > 0)
                sql += " AND FES.PassportStatusID = " + passportStatusID;
            if (jobOfferSourceID > 0)
                sql += " AND FES.JobOfferSourceID = " + jobOfferSourceID;
            if (workTypeID > 0)
                sql += " AND FES.WorkTypeID = " + workTypeID;
            if (countryID > 0)
                sql += " AND FES.CountryID = " + countryID;
            if (decisionStatusID > 0)
                sql += " AND FES.DecisionStatusID = " + decisionStatusID;
            if (ICRecommendationID > 0)
                sql += " AND (',' + RTRIM(F.ICRecommendationID) + ',') LIKE '%,'+'" + ICRecommendationID + "'+',%' ";

            return ExecuteQuery(sql);
        }

        public DataView SelectSaMIProfileIDForSync(String CreatedBy)
        {
            String sql = "SELECT TOP(1000) SaMIProfileID FROM tbl_SaMI_profiles WHERE SyncStatus='0' AND (" + CreatedBy + " )";
            return ExecuteQuery(sql);
        }

        public int UpdateQuery(String Sql)
        {
            return ExecuteNonQuery(Sql);
        }

        public DataView SelectTraineeInfo(int SaMIProfileID)
        {
            String sql = "SELECT CASE MIDDLENAME WHEN '' THEN FirstName + ' ' + LastName " +
                     "ELSE FirstName + ' ' + MiddleName +  ' ' + LastName  " +
                     "END AS NAME, " +
                     "Address + '-' + Ward + ', ' + D.DistrictName AS ADDRESS, CONVERT(varchar(10),RegistrationDate, 111) AS REGISTRATIONDATE  " +
                     "FROM tbl_SaMI_profiles S " +
                     "JOIN tbl_districts D ON D.DistrictID = S.AddressDistrictID " +
                     "WHERE SaMIProfileID= " + SaMIProfileID;
            return ExecuteQuery(sql);
        }


        //public DataView SelectCountReportICC(int ethnicityId, int validRegionsId)
        //{
        //    String sql = "SELECT COUNT(*) AS NoOfVisitors FROM tbl_SaMI_profiles ";
        //    return ExecuteQuery(sql);
        //}

        public DataView SelectValidRegions(String ethnicityName)
        {
            String sql = "SELECT EthnicityName, validregions FROM tbl_ethnicity WHERE EthnicityName='" + ethnicityName + "'";
            return ExecuteQuery(sql);
        }

        public DataView SelectRecords(String ethnicityName, String region, String Gender, String date, int DistrictID)
        {
            String sql = " SELECT (SELECT GeoBasedEthnicityDesc FROM tbl_geo_based_ethnicity WHERE GeoBasedEthnicityID = '" + region + "') AS Region , " +
                            " (SELECT COUNT(SAMIPROFILEID) FROM tbl_SaMI_profiles a " +
                            " JOIN tbl_ethnicity b ON b.EthnicityID = a.ETHNICITYID " +
                            " WHERE a.Status = '1' AND b.ETHNICITYNAME = '" + ethnicityName + "' AND A.Gender='"+Gender+"'";

            if (date != String.Empty)
            {
                sql += " AND a.RegistrationDate LIKE '"+date+"%'";
            }
            if (DistrictID > 0)
            {
                sql += " AND a.DistrictID = '"+DistrictID+"'";
            }

            sql += " AND ((',' + RTRIM(a.validregions) + ',') LIKE '%,'+ '" + region + "'+',%')) AS countRecord ";
            return ExecuteQuery(sql);
        }

        public DataView SelectDate()
        {
            String sql = "SELECT DISTINCT LEFT(RegistrationDate, 4) AS Date FROM tbl_SaMI_profiles ORDER BY LEFT(RegistrationDate, 4) ASC";
            return ExecuteQuery(sql);
        }

        public DataView SelectTotalVisitorsRecord(string date)
        {
            string sql = "SELECT (SELECT COUNT(SAMIPROFILEID) FROM tbl_SaMI_profiles WHERE RegistrationDate LIKE '" + date + "%' AND Gender='M') AS TotalMen, " +
                         "(SELECT COUNT(SAMIPROFILEID) FROM tbl_SaMI_profiles WHERE RegistrationDate LIKE '" + date + "%' AND Gender='F') AS TotalFemale, " +
                         "(SELECT COUNT(SAMIPROFILEID) FROM tbl_SaMI_profiles WHERE RegistrationDate LIKE '" + date + "%')  AS Total";
            return ExecuteQuery(sql);
        }

        public DataView SelectTotalVisitorsDistrictRecord(string date, int districtId)
        {
            string sql = "SELECT (SELECT COUNT(SAMIPROFILEID) FROM tbl_SaMI_profiles WHERE RegistrationDate LIKE '" + date + "%' AND Gender='M' AND DistrictID ='"+districtId+"') AS TotalMen, " +
                         "(SELECT COUNT(SAMIPROFILEID) FROM tbl_SaMI_profiles WHERE RegistrationDate LIKE '" + date + "%' AND Gender='F' AND DistrictID ='" + districtId + "') AS TotalFemale, " +
                         "(SELECT COUNT(SAMIPROFILEID) FROM tbl_SaMI_profiles WHERE RegistrationDate LIKE '" + date + "%' AND DistrictID ='" + districtId + "')  AS Total";
            return ExecuteQuery(sql);
        }
    }
}
