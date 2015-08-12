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
    public partial class SummaryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOptions();

                if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "KTMUSER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
                {
                    ddlDistrict.Enabled = true;
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                }
                else
                {
                    ddlDistrict.Enabled = false;
                    ddlOrganization.SelectedValue = UserAuthentication.GetSaMIOrganizationId(this.Page).ToString();
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

                LoadData();
            }
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

        // Bind Data On Grid View
        protected void LoadData()
        {
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

            if (!string.IsNullOrEmpty(txtRegistrationDateFrom.Text))
                RegistrationDateFrom = txtRegistrationDateFrom.Text;
            if (!string.IsNullOrEmpty(txtRegistrationDateTo.Text))
                RegistrationDateTo = txtRegistrationDateTo.Text;
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!string.IsNullOrEmpty(ddlOrganization.SelectedValue))
                SaMIOrganizationID = Convert.ToInt32(ddlOrganization.SelectedValue);
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
            if (!string.IsNullOrEmpty(ddlDecisionStatus.SelectedValue))
                decisionStatusID = Convert.ToInt32(ddlDecisionStatus.SelectedValue);
            if (!string.IsNullOrEmpty(ddlPassportStatus.SelectedValue))
                passportStatusID = Convert.ToInt32(ddlPassportStatus.SelectedValue);
            if (!string.IsNullOrEmpty(ddlJobOfferSource.SelectedValue))
                jobOfferSourceID = Convert.ToInt32(ddlJobOfferSource.SelectedValue);
            if (!string.IsNullOrEmpty(ddlWorkType.SelectedValue))
                workTypeID = Convert.ToInt32(ddlWorkType.SelectedValue);
            if (!string.IsNullOrEmpty(ddlGender.SelectedValue))
                genderid = ddlGender.SelectedValue;
            if (!string.IsNullOrEmpty(ddlVDC.SelectedValue))
                vdcID = Convert.ToInt32(ddlVDC.SelectedValue);
            if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                ethnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            if (!string.IsNullOrEmpty(ddlRecommendationByICC.SelectedValue))
                ICRecommendationID = Convert.ToInt32(ddlRecommendationByICC.SelectedValue);

            DataView dvSummaryReport = SaMIProfileBO.GetSummaryReport(RegistrationDateFrom, RegistrationDateTo, SaMIOrganizationID, ethnicityID, districtID, followUpStatus, vdcID, genderid,
                                                                    countryID, ageGroupID, educationalStatusID, frequencyOfVisit,
                                                                    reasonForVisiting, passportStatusID, jobOfferSourceID, workTypeID, decisionStatusID, ICRecommendationID);

            gvSummaryReport.DataSource = dvSummaryReport;
            gvSummaryReport.DataBind();
        }


        protected void txtRegistrationDate_TextChanged(object sender, EventArgs e)
        {
            LoadData();
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

            LoadData();
        }

        protected void ddlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void ddlEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void ddlRecommendationByICC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            gvSummaryReport.AllowPaging = false;
            LoadData();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=SummaryReport.xls");
            Response.ContentType = "application/vnd.xlsx";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvSummaryReport.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

    }
}