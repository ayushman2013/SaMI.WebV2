using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SaMI.DTO;
using SaMI.Business;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;

namespace SaMI.Web.Reports
{
    public partial class Index : System.Web.UI.Page
    {
        public string ProfileNo = "", Name = "", Gender = "", Ethnicity = "", Phone = "", District = "", VDC = "", Ward = "", Organization = "", Country = "";
        public string AgeGroup = "", Education = "", ICKnowledge = "", FollowUp = "";
        public string CreatedByName = "", CreatedDate = "", Registration="";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOptions();
                BindOptions();


                if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "KTMUSER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
                {
                    ddlDistrict.Enabled = true;
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                }
                else
                {
                    ddlDistrict.Enabled = false;
                    ddlOrganization.SelectedValue = UserAuthentication.GetSaMIOrganizationId(this.Page).ToString();
                    //ddlOrganization.Enabled = false;
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                }

                if (UserAuthentication.GetUserType(this.Page) == "USER")
                {
                    ddlOrganization.SelectedValue = UserAuthentication.GetSaMIOrganizationId(this.Page).ToString();
                    ddlOrganization.Enabled = false;
                }
                else
                {
                    ddlOrganization.Enabled = true;
                }

                BindDataOnChange();
                
            }
        }

        //Bind Data On Check List Box
        private void BindOptions()
        {
            DataView dv = new SaMIProfileBO().SelectOptions();
            dv.Table.Columns[5].ColumnName = "Ethinicity";
            dv.Table.Columns[8].ColumnName = "VDC";
            dv.Table.Columns[10].ColumnName = "Organization";
            dv.Table.Columns[11].ColumnName = "Country";
            dv.Table.Columns[12].ColumnName = "Age Group";
            dv.Table.Columns[13].ColumnName = "Education";
            dv.Table.Columns[14].ColumnName = "IC Knowledge";
            dv.Table.Columns[15].ColumnName = "Follow up";
            dv.Table.Columns[16].ColumnName = "Created By";
            dv.Table.Columns[17].ColumnName = "Created Date";

            chkOptions.Items.Add(dv.Table.Columns[4].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[5].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[8].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[9].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[10].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[11].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[12].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[13].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[14].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[15].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[16].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[17].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[18].ColumnName);
           
            chkOptions.DataBind();
        }

        // Bind Data On Grid View
        protected void BindDataOnChange()
        {
            gvSaMIProfile.DataSource = null;
            gvSaMIProfile.DataBind();
            if (chkOptions.Items[0].Selected == true)
                Gender = chkOptions.Items[0].Text;
            if (chkOptions.Items[1].Selected == true)
                Ethnicity = chkOptions.Items[1].Text;
            if (chkOptions.Items[2].Selected == true)
                VDC = chkOptions.Items[2].Text;
            if (chkOptions.Items[3].Selected == true)
                Ward = chkOptions.Items[3].Text;
            if (chkOptions.Items[4].Selected == true)
                Organization = chkOptions.Items[4].Text;
            if (chkOptions.Items[5].Selected == true)
                Country = chkOptions.Items[5].Text;
            if (chkOptions.Items[6].Selected == true)
                AgeGroup = chkOptions.Items[6].Text;
            if (chkOptions.Items[7].Selected == true)
                Education = chkOptions.Items[7].Text;
            if (chkOptions.Items[8].Selected == true)
                ICKnowledge = chkOptions.Items[8].Text;
            if (chkOptions.Items[9].Selected == true)
                FollowUp = chkOptions.Items[9].Text;
            if (chkOptions.Items[10].Selected == true)
                CreatedByName = chkOptions.Items[10].Text;
            if (chkOptions.Items[11].Selected == true)
                CreatedDate = chkOptions.Items[11].Text;
            if (chkOptions.Items[12].Selected == true)
                Registration = chkOptions.Items[12].Text;

            //string RegistrationDate = string.Empty;
            string RegistrationDateFrom = string.Empty;
            string RegistrationDateTo = string.Empty;

            int SaMIOrganizationID = 0;
            int ethnicityID = 0;
            int districtID = 0;
            string followUpStatus = string.Empty;
            string genderid = string.Empty;
            int vdcID = 0;
            int countryID = 0;
            int ageGroupID = 0;
            int educationalStatusID = 0;
            int frequencyOfVisit = 0;
            int reasonForVisiting = 0;
            int passportStatusID = 0;
            int jobOfferSourceID = 0;
            int workTypeID = 0;
            int decisionStatusID = 0;
            int ICRecommendationID = 0;
            string strOption = String.Empty;

            //if (!string.IsNullOrEmpty(txtRegistrationDate.Text))
            //    RegistrationDate = txtRegistrationDate.Text;
            if (!string.IsNullOrEmpty(txtRegistrationDateFrom.Text))
                RegistrationDateFrom = txtRegistrationDateFrom.Text;
            if (!string.IsNullOrEmpty(txtRegistrationDateTo.Text))
                RegistrationDateTo = txtRegistrationDateTo.Text;

            if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                ethnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!string.IsNullOrEmpty(ddlGender.SelectedValue))
                genderid = ddlGender.SelectedValue;
            if (!string.IsNullOrEmpty(ddlVDC.SelectedValue))
                vdcID = Convert.ToInt32(ddlVDC.SelectedValue);

            if (!string.IsNullOrEmpty(ddlWillingCountry.SelectedValue))
                countryID = Convert.ToInt32(ddlWillingCountry.SelectedValue);
            if (!string.IsNullOrEmpty(ddlAgeGroup.SelectedValue))
                ageGroupID = Convert.ToInt32(ddlAgeGroup.SelectedValue);
            if (!string.IsNullOrEmpty(ddlEducationalStatus.SelectedValue))
                educationalStatusID = Convert.ToInt32(ddlEducationalStatus.SelectedValue);
            if (!string.IsNullOrEmpty(ddlFrequencyOfVisit.SelectedValue))
                frequencyOfVisit = Convert.ToInt32(ddlFrequencyOfVisit.SelectedValue);
            if (!string.IsNullOrEmpty(ddlReasonForVisiting.SelectedValue))
                reasonForVisiting = Convert.ToInt32(ddlReasonForVisiting.SelectedValue);
            if (!string.IsNullOrEmpty(ddlPassportStatus.SelectedValue))
                passportStatusID = Convert.ToInt32(ddlPassportStatus.SelectedValue);
            if (!string.IsNullOrEmpty(ddlJobOfferSource.SelectedValue))
                jobOfferSourceID = Convert.ToInt32(ddlJobOfferSource.SelectedValue);
            if (!string.IsNullOrEmpty(ddlWorkType.SelectedValue))
                workTypeID = Convert.ToInt32(ddlWorkType.SelectedValue);
            if (!string.IsNullOrEmpty(ddlDecisionStatus.SelectedValue))
                decisionStatusID = Convert.ToInt32(ddlDecisionStatus.SelectedValue);
            if (!string.IsNullOrEmpty(ddlRecommendationByICC.SelectedValue))
                ICRecommendationID = Convert.ToInt32(ddlRecommendationByICC.SelectedValue);


            //if (UserAuthentication.GetUserType(this.Page) == "USER")
            //{
            //    SaMIOrganizationID = UserAuthentication.GetSaMIOrganizationId(this.Page);
            //}
            //else if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
            //{
                if (!string.IsNullOrEmpty(ddlOrganization.SelectedValue))
                    SaMIOrganizationID = Convert.ToInt32(ddlOrganization.SelectedValue);
            //}

            if (!string.IsNullOrEmpty(txtSearchText.Text))
            {
                strOption = txtSearchText.Text.Trim();
            }

            DataView dvProfileReport = SaMIProfileBO.GetReport(strOption, RegistrationDateFrom, RegistrationDateTo, SaMIOrganizationID, ethnicityID, 0, districtID, followUpStatus, vdcID, genderid,
                                                                    countryID, ageGroupID, educationalStatusID, frequencyOfVisit,
                                                                    reasonForVisiting, passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID,
                                                                      0, 0, 0,
                                                                    Gender, Ethnicity, VDC, Ward, Organization, Country,
                                                                     AgeGroup, Education, ICKnowledge, FollowUp, CreatedByName, CreatedDate, Registration);


            //gvSaMIProfile.AutoGenerateColumns = false;
            //gvSaMIProfile.CssClass = "table table-striped table-hover";
            //gvSaMIProfile.AllowPaging = true;
            gvSaMIProfile.PageIndexChanging += new GridViewPageEventHandler(gvSaMIProfile_PageIndexChanging);


            if (dvProfileReport != null)
            {

                for (int i = 0; i < dvProfileReport.Table.Columns.Count; i++)
                {

                    BoundField boundfield = new BoundField();
                    boundfield.DataField = dvProfileReport.Table.Columns[i].ColumnName.ToString();
                    boundfield.HeaderText = dvProfileReport.Table.Columns[i].ColumnName.ToString();
                    gvSaMIProfile.Columns.Add(boundfield);
                }

                gvSaMIProfile.Width = 1200;
                gvSaMIProfile.HeaderStyle.CssClass = "header";
                gvSaMIProfile.RowStyle.CssClass = "rowstyle";
            }

            gvSaMIProfile.Columns[0].Visible = false;
            gvSaMIProfile.Columns[1].Visible = false;
            gvSaMIProfile.Columns[3].Visible = false;
            gvSaMIProfile.Columns[4].Visible = false;
            gvSaMIProfile.Columns[6].Visible = false;
            gvSaMIProfile.Columns[7].Visible = false;
            gvSaMIProfile.Columns[8].Visible = false;

            gvSaMIProfile.DataSource = dvProfileReport;
            gvSaMIProfile.DataBind();
            Panel1.Controls.Add(gvSaMIProfile);



            //Get Record Count

            DataView dvTotalCount = SaMIProfileBO.CountRecord(strOption, RegistrationDateFrom, RegistrationDateTo, SaMIOrganizationID, ethnicityID, 0, districtID, followUpStatus, vdcID, genderid,
                                                                       countryID, ageGroupID, educationalStatusID, frequencyOfVisit,
                                                                       reasonForVisiting, passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID);
            DataView dvMaleCount = SaMIProfileBO.CountMaleRecord(strOption, RegistrationDateFrom, RegistrationDateTo, SaMIOrganizationID, ethnicityID, 0, districtID, followUpStatus, vdcID, genderid,
                                                                       countryID, ageGroupID, educationalStatusID, frequencyOfVisit,
                                                                       reasonForVisiting, passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID);
            DataView dvFemaleCount = SaMIProfileBO.CountFemaleRecord(strOption, RegistrationDateFrom, RegistrationDateTo, SaMIOrganizationID, ethnicityID, 0, districtID, followUpStatus, vdcID, genderid,
                                                                       countryID, ageGroupID, educationalStatusID, frequencyOfVisit,
                                                                       reasonForVisiting, passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID);
            int totalCount = Convert.ToInt32(dvTotalCount.Table.Rows[0]["Count"]);
            int maleCount = Convert.ToInt32(dvMaleCount.Table.Rows[0]["Count"]);
            int femaleCount = Convert.ToInt32(dvFemaleCount.Table.Rows[0]["Count"]);
            lblNoOfRecords.Text = totalCount.ToString();
            lblNoOfMaleRecords.Text = maleCount.ToString();
            lblNoOfFemaleRecord.Text = femaleCount.ToString();
        }


        
        protected void LoadProfiles()
        {
            string RegistrationDateFrom = string.Empty;
            string RegistrationDateTo = string.Empty;

            int SaMIOrganizationID = 0;
            int ethnicityID = 0;
            int districtID = 0;
            string followUpStatus = string.Empty;
            string gender = string.Empty;
            int vdcID = 0;
            int countryID = 0;
            int ageGroupID = 0;
            int educationalStatusID = 0;
            int frequencyOfVisit = 0;
            int reasonForVisiting = 0;
            int passportStatusID = 0;
            int jobOfferSourceID = 0;
            int workTypeID = 0;
            int decisionStatusID = 0;
            int ICRecommendationID = 0;

            if (!string.IsNullOrEmpty(txtRegistrationDateFrom.Text))
                RegistrationDateFrom = txtRegistrationDateFrom.Text;
            if (!string.IsNullOrEmpty(txtRegistrationDateTo.Text))
                RegistrationDateTo = txtRegistrationDateTo.Text;

            if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                ethnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!string.IsNullOrEmpty(ddlGender.SelectedValue))
                gender = ddlGender.SelectedValue;
            if (!string.IsNullOrEmpty(ddlVDC.SelectedValue))
                vdcID = Convert.ToInt32(ddlVDC.SelectedValue);

            if (!string.IsNullOrEmpty(ddlWillingCountry.SelectedValue))
                countryID = Convert.ToInt32(ddlWillingCountry.SelectedValue);
            if (!string.IsNullOrEmpty(ddlAgeGroup.SelectedValue))
                ageGroupID = Convert.ToInt32(ddlAgeGroup.SelectedValue);
            if (!string.IsNullOrEmpty(ddlEducationalStatus.SelectedValue))
                educationalStatusID = Convert.ToInt32(ddlEducationalStatus.SelectedValue);
            if (!string.IsNullOrEmpty(ddlFrequencyOfVisit.SelectedValue))
                frequencyOfVisit = Convert.ToInt32(ddlFrequencyOfVisit.SelectedValue);
            if (!string.IsNullOrEmpty(ddlReasonForVisiting.SelectedValue))
                reasonForVisiting = Convert.ToInt32(ddlReasonForVisiting.SelectedValue);
            if (!string.IsNullOrEmpty(ddlPassportStatus.SelectedValue))
                passportStatusID = Convert.ToInt32(ddlPassportStatus.SelectedValue);
            if (!string.IsNullOrEmpty(ddlJobOfferSource.SelectedValue))
                jobOfferSourceID = Convert.ToInt32(ddlJobOfferSource.SelectedValue);
            if (!string.IsNullOrEmpty(ddlWorkType.SelectedValue))
                workTypeID = Convert.ToInt32(ddlWorkType.SelectedValue);
            if (!string.IsNullOrEmpty(ddlDecisionStatus.SelectedValue))
                decisionStatusID = Convert.ToInt32(ddlDecisionStatus.SelectedValue);
            if (!string.IsNullOrEmpty(ddlRecommendationByICC.SelectedValue))
                ICRecommendationID = Convert.ToInt32(ddlRecommendationByICC.SelectedValue);
           

           if (UserAuthentication.GetUserType(this.Page) == "USER")
            {
                SaMIOrganizationID = UserAuthentication.GetSaMIOrganizationId(this.Page);
            }
            else if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {
                if (!string.IsNullOrEmpty(ddlOrganization.SelectedValue))
                    SaMIOrganizationID = Convert.ToInt32(ddlOrganization.SelectedValue);
            }


                // Load Data in Grid View
                //gvSaMIProfile.DataSource = SaMIProfileBO.GetReport(String.Empty, RegistrationDate, SaMIOrganizationID, ethnicityID, districtID, followUpStatus, vdcID, gender,
                //                                                    countryID, ageGroupID, educationalStatusID, frequencyOfVisit,
                //                                                    reasonForVisiting, passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID);
                //gvSaMIProfile.DataBind();

                
                //Get Record Count
                DataView dv = SaMIProfileBO.CountRecord(String.Empty, RegistrationDateFrom, RegistrationDateTo, SaMIOrganizationID, ethnicityID, 0, districtID, followUpStatus, vdcID, gender,
                                                                       countryID, ageGroupID, educationalStatusID, frequencyOfVisit,
                                                                       reasonForVisiting, passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID);
                int count = Convert.ToInt32(dv.Table.Rows[0]["Count"]);
                //lblNoOfRecords.Text = count.ToString();
                
        }

        void LoadOptions()
        {
            
            if (UserAuthentication.GetUserType(this.Page) == "USER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                int DistrictID = UserAuthentication.GetDistrictId(this.Page);
                ddlOrganization.DataSource = SaMIOrganizationBO.GetByDistrictID(DistrictID);
                ddlOrganization.DataValueField = "SaMIOrganizationID";
                ddlOrganization.DataTextField = "SaMIOrganizationName";
                ddlOrganization.DataBind();
            }

            ddlEthnicity.DataSource = EthnicityBO.GetAll(true);
            ddlEthnicity.DataValueField = "EthnicityID";
            ddlEthnicity.DataTextField = "EthnicityName";
            ddlEthnicity.DataBind();

            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            if (UserAuthentication.GetUserType(this.Page) == "USER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                ddlVDC.DataSource = VDCBO.GetAllByDistrictID(Convert.ToInt32(UserAuthentication.GetDistrictId(this.Page)), true);
                ddlVDC.DataValueField = "VDCID";
                ddlVDC.DataTextField = "VDCName";
                ddlVDC.DataBind();
            }
            else
            {
                ddlVDC.DataSource = VDCBO.GetAll(true);
                ddlVDC.DataValueField = "VDCID";
                ddlVDC.DataTextField = "VDCName";
                ddlVDC.DataBind();
            }
           

            ListItem li = new ListItem("[Gender]", "");
            ddlGender.Items.Add(li);
            li = new ListItem("Male", "M");
            ddlGender.Items.Add(li);
            li = new ListItem("Female", "F");
            ddlGender.Items.Add(li);

            ddlAgeGroup.DataSource = AgeGroupBO.GetAll(true);
            ddlAgeGroup.DataValueField = "AgeGroupID";
            ddlAgeGroup.DataTextField = "AgeGroupDesc";
            ddlAgeGroup.DataBind();

            ddlEducationalStatus.DataSource = EducationalStatusBO.GetAll(true);
            ddlEducationalStatus.DataValueField = "EducationalStatusID";
            ddlEducationalStatus.DataTextField = "EducationalStatusDesc";
            ddlEducationalStatus.DataBind();

            //Passport Status
            ddlPassportStatus.DataSource = PassportStatusBO.GetAll(true);
            ddlPassportStatus.DataValueField = "PassportStatusID";
            ddlPassportStatus.DataTextField = "PassportStatusDesc";
            ddlPassportStatus.DataBind();

            //Jof offer source
            ddlJobOfferSource.DataSource = JobOfferSourcesBO.GetAll(true);
            ddlJobOfferSource.DataValueField = "JobOfferSourceID";
            ddlJobOfferSource.DataTextField = "JobOfferSourceDesc";
            ddlJobOfferSource.DataBind();

            //Work Types
            ddlWorkType.DataSource = WorkTypesBO.GetAll(true);
            ddlWorkType.DataValueField = "WorkTypeID";
            ddlWorkType.DataTextField = "WorkTypeDesc";
            ddlWorkType.DataBind();

            ddlWillingCountry.DataSource = CountriesBO.GetAll(true);
            ddlWillingCountry.DataValueField = "CountryID";
            ddlWillingCountry.DataTextField = "CountryName";
            ddlWillingCountry.DataBind();

            //Decision Status
            ddlDecisionStatus.DataSource = DecisionStatusBO.GetAll(true);
            ddlDecisionStatus.DataValueField = "DecisionStatusID";
            ddlDecisionStatus.DataTextField = "DecisionStatusDesc";
            ddlDecisionStatus.DataBind();

            //IC Recommendation
            ddlRecommendationByICC.DataSource = ICRecommendationsBO.GetAll(true);
            ddlRecommendationByICC.DataValueField = "ICRecommendationID";
            ddlRecommendationByICC.DataTextField = "ICRecommendationDesc";
            ddlRecommendationByICC.DataBind();
        }

        protected void txtRegistrationDate_TextChanged(object sender, EventArgs e)
        {
            BindDataOnChange();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {
                ddlOrganization.DataSource = SaMIOrganizationBO.GetOrganizationByDistrictID(Convert.ToInt32(ddlDistrict.SelectedValue), "[Organization]");
                ddlOrganization.DataValueField = "SaMIOrganizationID";
                ddlOrganization.DataTextField = "SaMIOrganizationName";
                ddlOrganization.DataBind();
            }
            else
            {
                int DistrictID = UserAuthentication.GetDistrictId(this.Page);
                ddlOrganization.DataSource = SaMIOrganizationBO.GetOrganizationByDistrictID(DistrictID, "[Organization]");
                ddlOrganization.DataValueField = "SaMIOrganizationID";
                ddlOrganization.DataTextField = "SaMIOrganizationName";
                ddlOrganization.DataBind();
            }

            BindDataOnChange();
        }

        protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataOnChange();
        }

        protected void ddlEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataOnChange();
        }

        protected void ddlRecommendationByICC_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataOnChange();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataOnChange();

           // if (!string.IsNullOrEmpty(txtSearchText.Text))
           // {
           //     string RegistrationDate = string.Empty;
           //      int SaMIOrganizationID = 0;
           // int ethnicityID = 0;
           // int districtID = 0;
           // string followUpStatus = string.Empty;
           // string gender = string.Empty;
           // int vdcID = 0;
           // int countryID = 0;
           // int ageGroupID = 0;
           // int educationalStatusID = 0;
           // int frequencyOfVisit = 0;
           // int reasonForVisiting = 0;
           // int passportStatusID = 0;
           // int jobOfferSourceID = 0;
           // int workTypeID = 0;
           // int decisionStatusID = 0;
           // int ICRecommendationID = 0;

           // if (!string.IsNullOrEmpty(txtRegistrationDate.Text))
           //     RegistrationDate = txtRegistrationDate.Text;
           // if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
           //     ethnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
           //     districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlGender.SelectedValue))
           //     gender = ddlGender.SelectedValue;
           // if (!string.IsNullOrEmpty(ddlVDC.SelectedValue))
           //     vdcID = Convert.ToInt32(ddlVDC.SelectedValue);

           // if (!string.IsNullOrEmpty(ddlWillingCountry.SelectedValue))
           //     countryID = Convert.ToInt32(ddlWillingCountry.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlAgeGroup.SelectedValue))
           //     ageGroupID = Convert.ToInt32(ddlAgeGroup.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlEducationalStatus.SelectedValue))
           //     educationalStatusID = Convert.ToInt32(ddlEducationalStatus.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlFrequencyOfVisit.SelectedValue))
           //     frequencyOfVisit = Convert.ToInt32(ddlFrequencyOfVisit.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlReasonForVisiting.SelectedValue))
           //     reasonForVisiting = Convert.ToInt32(ddlReasonForVisiting.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlPassportStatus.SelectedValue))
           //     passportStatusID = Convert.ToInt32(ddlPassportStatus.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlJobOfferSource.SelectedValue))
           //     jobOfferSourceID = Convert.ToInt32(ddlJobOfferSource.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlWorkType.SelectedValue))
           //     workTypeID = Convert.ToInt32(ddlWorkType.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlDecisionStatus.SelectedValue))
           //     decisionStatusID = Convert.ToInt32(ddlDecisionStatus.SelectedValue);
           // if (!string.IsNullOrEmpty(ddlRecommendationByICC.SelectedValue))
           //     ICRecommendationID = Convert.ToInt32(ddlRecommendationByICC.SelectedValue);

           

           //if (UserAuthentication.GetUserType(this.Page) == "USER")
           // {
           //     SaMIOrganizationID = UserAuthentication.GetSaMIOrganizationId(this.Page);
           // }
           //else if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
           //{
           //    if (!string.IsNullOrEmpty(ddlOrganization.SelectedValue))
           //        SaMIOrganizationID = Convert.ToInt32(ddlOrganization.SelectedValue);
           //}


           //     //int districtID = 0;
           //     int partnerID = 0;
           //     //int OrganizationID = 0;
           //     //if (UserAuthentication.GetUserType(this.Page) == "USER")
           //     //    districtID = UserAuthentication.GetDistrictId(this.Page);
           //     if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
           //         partnerID = UserAuthentication.GetPartnerId(this.Page);
           //     //OrganizationID = UserAuthentication.GetSaMIOrganizationId(this.Page);
           //     //gvSaMIProfile.DataSource = SaMIProfileBO.GetReport(txtSearchText.Text.Trim(), 0, 0, 0, "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", partnerID);
           //     // gvSaMIProfile.DataSource = SaMIProfileBO.GetReport(txtSearchText.Text.Trim(), RegistrationDate, SaMIOrganizationID, ethnicityID, districtID, followUpStatus, vdcID, gender,
           //     //                                                    countryID, ageGroupID, educationalStatusID, frequencyOfVisit,
           //     //                                                    reasonForVisiting, passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID, "", "", partnerID );
                
           //     //gvSaMIProfile.DataBind();


           //     //Get Record Count
           //     DataView dv = SaMIProfileBO.CountRecord(txtSearchText.Text.Trim(), RegistrationDate, SaMIOrganizationID, ethnicityID, districtID, followUpStatus, vdcID, gender,
           //                                                            countryID, ageGroupID, educationalStatusID, frequencyOfVisit,
           //                                                            reasonForVisiting, passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID);
           //     int count = Convert.ToInt32(dv.Table.Rows[0]["Count"]);
           //     //lblNoOfRecords.Text = count.ToString();
           // }

        }

        protected void chkOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataOnChange();
        }

        protected void gvSaMIProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSaMIProfile.PageIndex = e.NewPageIndex;
            BindDataOnChange();
            Session["pageNumber"] = e.NewPageIndex;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            gvSaMIProfile.AllowPaging = false;
            BindDataOnChange();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=ProfileRegistered.xls");
            Response.ContentType = "application/vnd.xlsx";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvSaMIProfile.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}