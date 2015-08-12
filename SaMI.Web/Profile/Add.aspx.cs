using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Data;
using SaMI.DTO;
using SaMI.Business;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Services;

namespace SaMI.Web.Profile
{
    public partial class Add : System.Web.UI.Page
    {
        public int id = 0;
        public int SaMiProfileID = 0;
        public int PreviousFEID = 0;
        public int j;
        public List<int> list = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (hfSaMIProfileID.Value != "")
                LoadPreviousFEExperience(Convert.ToInt32(hfSaMIProfileID.Value));

            if (!Page.IsPostBack)
            {
                LoadOptions();            
                LoadPreviousForeignEmploymentExperience();

                if(UserAuthentication.GetUserType(this.Page) == "USER")
                {
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                    ddlDistrict.Enabled = false;
                }
                else if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
                {
                    ddlDistrict.Enabled = true;
                }
            }
        }

        void LoadPreviousForeignEmploymentExperience()
        {
            //Country
            ddlCountry.DataSource = CountriesBO.GetAll(true);
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataBind();

            //Job Type
            ddlJobType.DataSource = JobOfferedTypesBO.GetAll(true);
            ddlJobType.DataValueField = "JobOfferedTypeID";
            ddlJobType.DataTextField = "JobOfferedTypeDesc";
            ddlJobType.DataBind();


            //Stay Duration
            ddlStayDuration.DataSource = StayDurationBO.GetAll("[Stay Duration]");
            ddlStayDuration.DataValueField = "StayDurationID";
            ddlStayDuration.DataTextField = "StayDurationDesc";
            ddlStayDuration.DataBind();

            //Visit Reason
            ddlReasonOfVisit.DataSource = VisitReasonBO.GetAll("[Visit Reason]");
            ddlReasonOfVisit.DataValueField = "VisitReasonID";
            ddlReasonOfVisit.DataTextField = "VisitReasonDesc";
            ddlReasonOfVisit.DataBind();

            //Visit Frequency
            ddlFrequencyOfVisit.DataSource = VisitFrequencyICCBO.GetAll("[Visit Frequency]");
            ddlFrequencyOfVisit.DataValueField = "VisitFrequencyID";
            ddlFrequencyOfVisit.DataTextField = "VisitFrequencyDesc";
            ddlFrequencyOfVisit.DataBind();
        }

        void LoadGeoBasedEthnicity()
        {
            rbValidRegions.DataSource = EthnicityBO.SelectGeoBasedEthnicity();
            rbValidRegions.DataValueField = "GeoBasedEthnicityID";
            rbValidRegions.DataTextField = "GeoBasedEthnicityDesc";
            rbValidRegions.DataBind();
        }

        void LoadOptions()
        {
            //Load District
            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            ddlAddressDistrict.DataSource = DistrictBO.GetAll(true);
            ddlAddressDistrict.DataValueField = "DistrictID";
            ddlAddressDistrict.DataTextField = "DistrictName";
            ddlAddressDistrict.DataBind();


            ddlDistrict.ClearSelection();

            if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
                ddlDistrict.Enabled = true;
            else
            {
                ddlDistrict.Enabled = false;
                ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
            }

            //Load Age Group
            ddlAgeGroup.DataSource = AgeGroupBO.GetAll(true);
            ddlAgeGroup.DataValueField = "AgeGroupID";
            ddlAgeGroup.DataTextField = "AgeGroupDesc";
            ddlAgeGroup.DataBind();

            //Ethnicity
            ddlEthnicity.DataSource = EthnicityBO.GetAll(true);
            ddlEthnicity.DataValueField = "EthnicityID";
            ddlEthnicity.DataTextField = "EthnicityName";
            ddlEthnicity.DataBind();

            //Load Educational Status
            ddlEducationalStatus.DataSource = EducationalStatusBO.GetAll(true);
            ddlEducationalStatus.DataValueField = "EducationalStatusID";
            ddlEducationalStatus.DataTextField = "EducationalStatusDesc";
            ddlEducationalStatus.DataBind();

            //Load Marital Status
            ddlMaritalStatus.DataSource = MaritalStatusBO.GetAll(true);
            ddlMaritalStatus.DataValueField = "MaritalStatusID";
            ddlMaritalStatus.DataTextField = "MaritalStatusDesc";
            ddlMaritalStatus.DataBind();

            //IC Knowledge
            ddlICKnowledge.DataSource = ICKnowledgesBO.GetAll(true);
            ddlICKnowledge.DataValueField = "ICKnowledgeID";
            ddlICKnowledge.DataTextField = "ICKnowledgeDesc";
            ddlICKnowledge.DataBind();

            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                pnlIC.Visible = false;
            }

        }

        SaMIProfiles MapSaMIProfilesDTO()
        {
            SaMIProfiles objSaMIProfiles = new SaMIProfiles();           
            if (!String.IsNullOrEmpty(txtRegistrationDate.Text.Trim()))
                objSaMIProfiles.RegistrationDate = Convert.ToDateTime(txtRegistrationDate.Text.Trim());
            if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue))
                objSaMIProfiles.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (rbMale.Checked)
                objSaMIProfiles.Gender = "M";
            else
                objSaMIProfiles.Gender = "F";


            objSaMIProfiles.FirstName = txtFirstName.Text.Trim();
            objSaMIProfiles.MiddleName = txtMiddleName.Text.Trim();
            objSaMIProfiles.LastName = txtLastName.Text.Trim();
            objSaMIProfiles.CasteID = Convert.ToInt32(Request.Params["ctl00$MainContent$ddlCaste"]);
            objSaMIProfiles.EthnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);

            string ValidRegions = string.Empty;

            for (int j = 0; j < rbValidRegions.Items.Count; j++)
            {
                if (rbValidRegions.Items[j].Selected == true)
                {
                    if (j == 0)
                        ValidRegions = rbValidRegions.Items[j].Value;
                    else
                        ValidRegions = ValidRegions + "," + rbValidRegions.Items[j].Value;
                }
            }

            objSaMIProfiles.ValidRegions = ValidRegions;

            objSaMIProfiles.Address = txtAddress.Text.Trim();
            objSaMIProfiles.AddressDistrictID = Convert.ToInt32(ddlAddressDistrict.SelectedValue);
            objSaMIProfiles.VDCID = Convert.ToInt32(ddlVDC.SelectedValue);
            objSaMIProfiles.Ward = txtWard.Text;


            objSaMIProfiles.VisitorPhone = txtVisitorPhone.Text;
            objSaMIProfiles.FamilyMemberPhone = txtFamilyMemberPhone.Text.Trim();
            objSaMIProfiles.AgeGroupID = Convert.ToInt32(ddlAgeGroup.SelectedValue);
            objSaMIProfiles.EducationalStatusID = Convert.ToInt32(ddlEducationalStatus.SelectedValue);
            objSaMIProfiles.MaritalStatusID = Convert.ToInt32(ddlMaritalStatus.SelectedValue);
            objSaMIProfiles.ICKnowledgeID = Convert.ToInt32(ddlICKnowledge.SelectedValue);
            objSaMIProfiles.FrequencyOfVisit = Convert.ToInt32(ddlFrequencyOfVisit.SelectedValue);
            objSaMIProfiles.ReasonForVisiting = Convert.ToInt32(ddlReasonOfVisit.SelectedValue);

            objSaMIProfiles.FamilyHeadName = txtFamilyHeadName.Text;
            objSaMIProfiles.FamilyHeadRelation = txtFamilyHeadRelation.Text;


            objSaMIProfiles.CreatedBy = UserAuthentication.GetUserId(this.Page);
            objSaMIProfiles.CreatedDate = DateTime.Now;

            objSaMIProfiles.Status = 1;
            objSaMIProfiles.SyncStatus = 0;

            return objSaMIProfiles;
        }

        TRNRecruitmentList MapRecruitmentList()
        {
            TRNRecruitmentList objRecruitmentList = new TRNRecruitmentList();

            int saMIOrganizationID = UserAuthentication.GetSaMIOrganizationId(this.Page);
            objRecruitmentList.OrganizationID = saMIOrganizationID;
            objRecruitmentList.ReferStatus = 0;
            objRecruitmentList.CreatedBy = UserAuthentication.GetUserId(this.Page);
            objRecruitmentList.CreatedDate = DateTime.Now;
            return objRecruitmentList;
        }

       

        PreviousFEExperiences MapPreviousFEExperiencesDTO()
        {
            PreviousFEExperiences objPreviousFEExperiences = null;
            objPreviousFEExperiences = new PreviousFEExperiences();
            objPreviousFEExperiences.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            objPreviousFEExperiences.JobOfferedType = Convert.ToInt32(ddlJobType.SelectedValue);
            objPreviousFEExperiences.StayDuration = ddlStayDuration.Text;
            objPreviousFEExperiences.SyncStatus = 0;
            return objPreviousFEExperiences;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaMiProfileID = SaMIProfileBO.InsertProfile(MapSaMIProfilesDTO());
            hfSaMIProfileID.Value = SaMiProfileID.ToString();
            
            LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
            Response.Redirect("Edit.aspx?ID=" + SaMiProfileID);
        }

        

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ddlEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGeoBasedEthnicity();
            if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
            {

                LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
            }
        }

        protected void ddlAddressDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlAddressDistrict.SelectedValue))
            {
                if (Convert.ToInt32(ddlAddressDistrict.SelectedValue) > 0)
                {
                    LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
                    int districtID = Convert.ToInt32(ddlAddressDistrict.SelectedValue);
                    ddlVDC.DataSource = VDCBO.GetAllByDistrictID(districtID, true);
                    ddlVDC.DataValueField = "VDCID";
                    ddlVDC.DataTextField = "VDCName";
                    ddlVDC.DataBind();
                }
            }
            else
            {

            }
        }

        void LoadValidRegions(int EthnicityID)
        {
            List<int> lstValidRegions = EthnicityBO.SelectValidRegionForEthnicity(EthnicityID);

            if (lstValidRegions.Count > 0)
            {

                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {

                    if (lstValidRegions.Exists(delegate(int region) { return region == Convert.ToInt32(rbValidRegions.Items[j].Value); }))
                    {
                    }
                    else
                        list.Add(j);

                }
                foreach (int a in list)
                {
                    rbValidRegions.Items[a].Attributes.Add("hidden", "hidden");
                }

            }
            else
            {
                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {
                    rbValidRegions.Items[j].Attributes.Add("hidden", "hidden");
                }
            }
        }

        protected void btnAddPFEExperience_Click(object sender, EventArgs e)
        {
            PreviousFEExperiences objPreviousFEExperiences = MapPreviousFEExperiencesDTO();
            objPreviousFEExperiences.SaMIProfileID = Convert.ToInt32(hfSaMIProfileID.Value);
            if (!String.IsNullOrEmpty(ddlCountry.SelectedValue))
                objPreviousFEExperiences.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            if (!String.IsNullOrEmpty(ddlJobType.SelectedValue))
                objPreviousFEExperiences.JobOfferedType = Convert.ToInt32(ddlJobType.SelectedValue);
            if (!String.IsNullOrEmpty(ddlStayDuration.SelectedValue))
                objPreviousFEExperiences.StayDuration = ddlStayDuration.SelectedValue;
            
            objPreviousFEExperiences.Status = 1;

            if (String.IsNullOrEmpty(lblPreviousID.Text))
            {
                objPreviousFEExperiences.CreatedBy = UserAuthentication.GetUserId(this.Page);
                PreviousFEID = PreviousFEExperienceBO.InsertFEExperience(objPreviousFEExperiences);
            }
            else
            {
                objPreviousFEExperiences.ForeignEmploymentExperienceID = Convert.ToInt32(lblPreviousID.Text);
                objPreviousFEExperiences.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                PreviousFEID = PreviousFEExperienceBO.UpdateFEExperience(objPreviousFEExperiences);
            }

            LoadPreviousFEExperience(Convert.ToInt32(hfSaMIProfileID.Value));
            LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
            ClearForeignEmployemntExperience();
        }

        void ClearForeignEmployemntExperience()
        {
            ddlCountry.SelectedIndex = 0;
            ddlJobType.SelectedIndex = 0;
            ddlStayDuration.SelectedIndex = 0;
        }

        public void LoadPreviousFEExperience(int SaMIProfileID)
        {
            gvPFE.DataSource = SaMIProfileBO.GetPFEExperience(Convert.ToInt32(hfSaMIProfileID.Value));
            gvPFE.DataBind();
        }

        

        protected void gvPFE_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdEdit"))
            {
                hfPreviousFEEID.Value = e.CommandArgument.ToString();
                lblPreviousID.Text = e.CommandArgument.ToString();
                PreviousFEExperiences objPreviousFEExperience = PreviousFEExperienceBO.GetByID(Convert.ToInt32(e.CommandArgument.ToString()));
                ddlCountry.SelectedValue = objPreviousFEExperience.CountryID.ToString();
                ddlStayDuration.SelectedValue = objPreviousFEExperience.StayDuration;
                ddlJobType.SelectedValue = objPreviousFEExperience.JobOfferedType.ToString();
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                hfPreviousFEEID.Value = e.CommandArgument.ToString();
                PreviousFEExperiences objPreviousFEExperience = new PreviousFEExperiences();
                objPreviousFEExperience.ForeignEmploymentExperienceID = Convert.ToInt32(e.CommandArgument.ToString());
                objPreviousFEExperience.Status = 0;
                objPreviousFEExperience.SyncStatus = 0;
                PreviousFEExperienceBO.DeletePreviousFEExperience(objPreviousFEExperience);
                LoadPreviousFEExperience(Convert.ToInt32(hfSaMIProfileID.Value));
                LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
            }
        }
    }
}