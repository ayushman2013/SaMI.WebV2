using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SaMI.DTO;
using SaMI.Business;


namespace SaMI.Web.Profile
{
    public partial class Edit : System.Web.UI.Page
    {
        public int j;
        public int PreviousFEID = 0;
        public List<int> list = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            int SaMIProfileID = 0;

            
            if (!string.IsNullOrEmpty(Request.QueryString.Get("ID")))
                SaMIProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));

            if (!UserAuthentication.CheckPermission(SaMIProfileID, this.Page))
                Response.Redirect("Index.aspx");


            if (!Page.IsPostBack)
            {
                btnSaveForeignEmployment.Attributes.Add("style", "display:none");
                btnSaveServices.Attributes.Add("style", "display:none");
                btnSavePhoneFollowUp.Attributes.Add("style", "display:none");
                hfSaMIProfileID.Value = SaMIProfileID.ToString();
                LoadOptions();

                if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
                    ddlDistrict.Enabled = true;
                else
                    ddlDistrict.Enabled = false;
                LoadForeignEmploymentOptions();
                LoadPreviousForeignEmploymentExperience();
                LoadServicesOptions();
                LoadAllData(SaMIProfileID);
                LoadTraineeInfo(SaMIProfileID);
            }
        }

        void LoadGeoBasedEthnicity()
        {
            rbValidRegions.DataSource = EthnicityBO.SelectGeoBasedEthnicity();
            rbValidRegions.DataValueField = "GeoBasedEthnicityID";
            rbValidRegions.DataTextField = "GeoBasedEthnicityDesc";
            rbValidRegions.DataBind();
        }

        void LoadAllData(int SaMIProfileID)
        {
            LoadGeoBasedEthnicity();
            LoadSaMIProfile(SaMIProfileID);
            LoadForeignEmploymentStatus(SaMIProfileID);
            LoadServicesProvided(SaMIProfileID);
           // LoadPreviousFEExperiences(SaMIProfileID);
            LoadPreviousFEExperience(SaMIProfileID);
            //LoadPhoneFollowUp(SaMIProfileID);
            //LoadPhoneFollowUpInfo(SaMIProfileID);
            LoadPhoneFollowUpList(SaMIProfileID);
        }

        #region SaMI Profile

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
        }

        void LoadSaMIProfile(int SaMIProfileID)
        {
            //SaMI Profiles
            SaMIProfiles objSaMIProfiles = SaMIProfileBO.GetSaMIProfile(SaMIProfileID);

            ddlEthnicity.SelectedValue = objSaMIProfiles.EthnicityID.ToString();
            LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));

            List<int> lstValidRegions = EthnicityBO.SelectValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue), SaMIProfileID);


            if (lstValidRegions.Count > 0)
            {
                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {
                    if (lstValidRegions.Exists(delegate(int region) { return region == Convert.ToInt32(rbValidRegions.Items[j].Value); }))
                    {
                        rbValidRegions.Items[j].Selected = true;
                    }

                }
            }
           

            txtSaMIProfileNumber.Text = objSaMIProfiles.SaMIProfileNumber;
            txtSaMIProfileNumber.Enabled = false;
            hfSaMIProfileNumber.Value = objSaMIProfiles.SaMIProfileNumber;

            txtRegistrationDate.Text = objSaMIProfiles.RegistrationDate.ToShortDateString();
            ddlDistrict.SelectedValue = objSaMIProfiles.DistrictID.ToString();
            hfSaMIDistrictID.Value = objSaMIProfiles.DistrictID.ToString();

            if (objSaMIProfiles.Gender == "M")
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtFirstName.Text = objSaMIProfiles.FirstName;
            txtMiddleName.Text = objSaMIProfiles.MiddleName;
            txtLastName.Text = objSaMIProfiles.LastName;

            txtAddress.Text = objSaMIProfiles.Address;
            ddlAddressDistrict.SelectedValue = objSaMIProfiles.AddressDistrictID.ToString();
            ddlVDC.SelectedValue = objSaMIProfiles.VDCID.ToString();
            txtWard.Text = objSaMIProfiles.Ward;

            txtVisitorPhone.Text = objSaMIProfiles.VisitorPhone;
            txtFamilyMemberPhone.Text = objSaMIProfiles.FamilyMemberPhone;
            ddlAgeGroup.SelectedValue = objSaMIProfiles.AgeGroupID.ToString();

            ddlEducationalStatus.SelectedValue = objSaMIProfiles.EducationalStatusID.ToString();
            ddlMaritalStatus.SelectedValue = objSaMIProfiles.MaritalStatusID.ToString();
            ddlICKnowledge.SelectedValue = objSaMIProfiles.ICKnowledgeID.ToString();
            ddlFrequencyOfVisit.SelectedValue = objSaMIProfiles.FrequencyOfVisit.ToString();
            ddlReasonOfVisit.SelectedValue = objSaMIProfiles.ReasonForVisiting.ToString();

            txtFamilyHeadName.Text = objSaMIProfiles.FamilyHeadName;
            txtFamilyHeadRelation.Text = objSaMIProfiles.FamilyHeadRelation;

        }

        PreviousFEExperiences MapPreviousFEExperiencesDTO()
        {
            PreviousFEExperiences objPreviousFEExperiences = null;
            objPreviousFEExperiences = new PreviousFEExperiences();
            objPreviousFEExperiences.SaMIProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));
            objPreviousFEExperiences.UpdatedBy = UserAuthentication.GetUserId(this.Page);
            objPreviousFEExperiences.SyncStatus = 0;
            return objPreviousFEExperiences;
        }

        //void LoadPreviousFEExperiences(int SaMIProfileID)
        //{
        //    PreviousFEExperiences objPreviousFEExperiences = PreviousFEExperienceBO.GetPreviousFEExperiences(SaMIProfileID);
        //    DataView dv = PreviousFEExperienceBO.GetAll(Convert.ToInt32(objPreviousFEExperiences.SaMIProfileID));
        //    if (dv.Count > 0)
        //    {
        //        rbPrevFEExperienceYes.Checked = true;
        //        ddlCountry.Enabled = true;
        //        ddlJobType.Enabled = true;
        //        ddlStayDuration.Enabled = true;
        //        if (!string.IsNullOrEmpty(objPreviousFEExperiences.CountryID.ToString()))
        //            ddlCountry.SelectedValue = objPreviousFEExperiences.CountryID.ToString();
        //        if (!string.IsNullOrEmpty(objPreviousFEExperiences.JobOfferedType.ToString()))
        //            ddlJobType.SelectedValue = objPreviousFEExperiences.JobOfferedType.ToString();
        //        if (!string.IsNullOrEmpty(objPreviousFEExperiences.StayDuration))
        //            ddlStayDuration.SelectedValue = objPreviousFEExperiences.StayDuration.ToString();
        //    }
        //    else
        //    {
        //        rbPrevFEExperienceNo.Checked = true;
        //        ddlCountry.Enabled = false;
        //        ddlJobType.Enabled = false;
        //        ddlStayDuration.Enabled = false;
        //    }
        //}

        void LoadOptions()
        {
            //Load District
            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

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

            //Load Address District
            ddlAddressDistrict.DataSource = DistrictBO.GetAll(true);
            ddlAddressDistrict.DataValueField = "DistrictID";
            ddlAddressDistrict.DataTextField = "DistrictName";
            ddlAddressDistrict.DataBind();

            //VDC
            ddlVDC.DataSource = VDCBO.GetAll(true);
            ddlVDC.DataValueField = "VDCID";
            ddlVDC.DataTextField = "VDCName";
            ddlVDC.DataBind();

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

            //IC Knowledges
            ddlICKnowledge.DataSource = ICKnowledgesBO.GetAll(true);
            ddlICKnowledge.DataValueField = "ICKnowledgeID";
            ddlICKnowledge.DataTextField = "ICKnowledgeDesc";
            ddlICKnowledge.DataBind();

            //Occupation Types
            //ddlOccupationType.DataSource = OccupationTypeBO.GetAll(true);
            //ddlOccupationType.DataValueField = "OccupationTypeID";
            //ddlOccupationType.DataTextField = "OccupationTypeDesc";
            //ddlOccupationType.DataBind();

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

            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                pnlIC.Visible = false;
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue) && !string.IsNullOrEmpty(hfSaMIDistrictID.Value))
            {
                if (Convert.ToInt32(ddlDistrict.SelectedValue) > 0 && Convert.ToInt32(hfSaMIDistrictID.Value) != Convert.ToInt32(ddlDistrict.SelectedValue))
                    txtSaMIProfileNumber.Text = SaMIProfileBO.GetNewRegistratonNumber(Convert.ToInt32(ddlDistrict.SelectedValue));
                else
                    txtSaMIProfileNumber.Text = hfSaMIProfileNumber.Value;
            }
        }

        protected void ddlEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGeoBasedEthnicity();
            if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
            {
                LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
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

            //if (ddlEthnicity.SelectedItem.ToString() == "Janajati Newar")
            //{
            //    rbValidRegions.Items[0].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[1].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[2].Attributes.Add("hidden", "hidden");
            //}
            //else if (ddlEthnicity.SelectedItem.ToString() == "Brahmin" || ddlEthnicity.SelectedItem.ToString() == "Chhetri" || ddlEthnicity.SelectedItem.ToString() == "Dalit")
            //{
            //    rbValidRegions.Items[0].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[3].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[4].Attributes.Add("hidden", "hidden");
            //}
            //else if (ddlEthnicity.SelectedItem.ToString() == "Janajati")
            //{
            //    rbValidRegions.Items[3].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[4].Attributes.Add("hidden", "hidden");
            //}
            //else if (ddlEthnicity.SelectedItem.ToString() == "Thakuri")
            //{
            //    rbValidRegions.Items[0].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[2].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[3].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[4].Attributes.Add("hidden", "hidden");
            //}
            //else if (ddlEthnicity.SelectedItem.ToString() == "Other")
            //{
            //    rbValidRegions.Items[0].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[1].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[2].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[3].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[4].Attributes.Add("hidden", "hidden");
            //}
        }

        protected void rbPrevFEExperienceNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrevFEExperienceNo.Checked)
            {
                ddlCountry.SelectedValue = "0";
                ddlJobType.SelectedValue = "0";
                ddlStayDuration.SelectedValue = "0";
            }
        }

        // Save General Information
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaMIProfileBO.UpdateProfile(MapSaMIProfilesDTO());

            ClearForeignEmployemntExperience();
            LoadPreviousFEExperience(Convert.ToInt32(hfSaMIProfileID.Value));
            //LoadPreviousFEExperiences(Convert.ToInt32(hfSaMIProfileID.Value));
            LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
        }

        //protected void btnSaveAndClose_Click(object sender, EventArgs e)
        //{
        //    SaMIProfileBO.UpdateProfile(MapSaMIProfilesDTO());

        //    ClearForeignEmployemntExperience();
        //    LoadPreviousFEExperience(Convert.ToInt32(hfSaMIProfileID.Value));
        //    //LoadPreviousFEExperiences(Convert.ToInt32(hfSaMIProfileID.Value));
        //    LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
        //    Response.Redirect("Index.aspx");
        //}

        SaMIProfiles MapSaMIProfilesDTO()
        {
            SaMIProfiles objSaMIProfiles = new SaMIProfiles();
            objSaMIProfiles.SaMIProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));
            objSaMIProfiles.SaMIProfileNumber = txtSaMIProfileNumber.Text.Trim();
            objSaMIProfiles.RegistrationDate = Convert.ToDateTime(txtRegistrationDate.Text.Trim());
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

           
            objSaMIProfiles.UpdatedBy = UserAuthentication.GetUserId(this.Page);
            objSaMIProfiles.UpdatedDate = DateTime.Now;

            objSaMIProfiles.Status = 1;
            objSaMIProfiles.SyncStatus = 0;

            return objSaMIProfiles;
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
        }

        protected void gvPFE_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdEdit"))
            {
                hfForeignEmploymentExperienceID.Value = e.CommandArgument.ToString();
                lblPreviousID.Text = e.CommandArgument.ToString();
                PreviousFEExperiences objPreviousFEExperience = PreviousFEExperienceBO.GetByID(Convert.ToInt32(e.CommandArgument.ToString()));
                ddlCountry.SelectedValue = objPreviousFEExperience.CountryID.ToString();
                ddlStayDuration.SelectedValue = objPreviousFEExperience.StayDuration;
                ddlJobType.SelectedValue = objPreviousFEExperience.JobOfferedType.ToString();
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                hfForeignEmploymentExperienceID.Value = e.CommandArgument.ToString();
                PreviousFEExperiences objPreviousFEExperience = new PreviousFEExperiences();
                objPreviousFEExperience.ForeignEmploymentExperienceID = Convert.ToInt32(e.CommandArgument.ToString());
                objPreviousFEExperience.Status = 0;
                objPreviousFEExperience.SyncStatus = 0;
                PreviousFEExperienceBO.DeletePreviousFEExperience(objPreviousFEExperience);
                LoadPreviousFEExperience(Convert.ToInt32(hfSaMIProfileID.Value));
                LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
            }
        }

        public void LoadPreviousFEExperience(int SaMIProfileID)
        {
            gvPFE.DataSource = SaMIProfileBO.GetPFEExperience(Convert.ToInt32(hfSaMIProfileID.Value));
            gvPFE.DataBind();
        }

        #endregion

        #region Followup

        //Load Data on dropdown list and checkbox list
        void LoadServicesOptions()
        {
            DataView objDataView = ServicesProvidedBO.GetAll(true);
            ddlServiceProvided.DataSource = objDataView;
            ddlServiceProvided.DataValueField = "ServiceProvidedID";
            ddlServiceProvided.DataTextField = "ServiceProvidedDesc";
            ddlServiceProvided.DataBind();

            objDataView = ICRecommendationsBO.GetAll(false);
            cblICRecommendation.DataSource = objDataView;
            cblICRecommendation.DataValueField = "ICRecommendationID";
            cblICRecommendation.DataTextField = "ICRecommendationDesc";
            cblICRecommendation.DataBind();

            objDataView = NonFollowUpReasonsBO.GetAll(true);
            ddlNonFollowup.DataSource = objDataView;
            ddlNonFollowup.DataValueField = "NonFollowUpReasonID";
            ddlNonFollowup.DataTextField = "NonFollowUpReasonDesc";
            ddlNonFollowup.DataBind();


            objDataView = AdditionalFollowUpInfoBO.GetAll();
            cblAdditionalDocument.DataSource = objDataView;
            cblAdditionalDocument.DataValueField = "AdditionalFollowUpInfoID";
            cblAdditionalDocument.DataTextField = "AdditionalFollowUpInfoDesc";
            cblAdditionalDocument.DataBind();

            objDataView = FollowUpBO.GetAll(true);
            ddlFurtherFollowUp.DataSource = objDataView;
            ddlFurtherFollowUp.DataValueField = "FollowUpID";
            ddlFurtherFollowUp.DataTextField = "FollowUpDesc";
            ddlFurtherFollowUp.DataBind();

            ddlFurtherFollowUp.Enabled = false;
        }

        //Load service provided
        void LoadServicesProvided(int SaMIProfileID)
        {
            ServicesProvidedPerSaMI objServicesProvidedPerSaMI = ServicesProvidedPerSaMIBO.GetServicesProvidedPerSaMI(SaMIProfileID);

            if (objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID > 0)
            {
                LoadOtherFollowupPerService(objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID);
                hfServiceProvidedPerSaMIID.Value = objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID.ToString();

                txtVisitTimes.Text = objServicesProvidedPerSaMI.VisitTimes;
                ddlServiceProvided.SelectedValue = objServicesProvidedPerSaMI.ServiceProvidedID.ToString();


                FollowUpPerServices objFollowUpPerServices = FollowUpPerServicesBO.GetFollowUpPerService(objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID);
                if (objFollowUpPerServices.ICFollowUpRequired == 1)
                {
                    rdYes.Checked = true;
                }
                else
                    rbNo.Checked = true;

                List<int> lstICRecommendation = ICRecommendationsBO.SelectICRecommendations(SaMIProfileID);


                if (lstICRecommendation.Count > 0)
                {
                    for (int j = 0; j < cblICRecommendation.Items.Count; j++)
                    {
                        if (lstICRecommendation.Exists(delegate(int recommendation) { return recommendation == Convert.ToInt32(cblICRecommendation.Items[j].Value); }))
                        {
                            cblICRecommendation.Items[j].Selected = true;
                        }
                    }
                }

                if (objFollowUpPerServices.FurtherFollowUpID > 0)
                {
                    rbFurtherFollowUpYes.Checked = true;
                    ddlFurtherFollowUp.Enabled = true;
                    ddlFurtherFollowUp.SelectedValue = objFollowUpPerServices.FurtherFollowUpID.ToString();
                }
                else
                {
                    rbFurtherFollowUpNo.Checked = true;
                }

                List<AdditionalFollowUpInfoPerServices> lstAdditionalFollowUpInfoPerServices = AdditionalFollowUpInfoPerServiceBO.GetAllByServiceProvidedPerSaMIID(objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID);

                if (lstAdditionalFollowUpInfoPerServices.Count > 0)
                    rbAdditionalInfoYes.Checked = true;
                else
                    rbAdditionalInfoNo.Checked = true;

                for (int j = 0; j < cblAdditionalDocument.Items.Count; j++)
                {
                    if (lstAdditionalFollowUpInfoPerServices.Exists(delegate(AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices) { return objAdditionalFollowUpInfoPerServices.AdditionalFollowupInfoID == Convert.ToInt32(cblAdditionalDocument.Items[j].Value); }))
                    {
                        cblAdditionalDocument.Items[j].Selected = true;
                    }
                }
            }
        }

        //Load Other Followup
        void LoadOtherFollowupPerService(int ServiceProvidedPerSaMIID)
        {
            gvOtherFollowUp.DataSource = OtherFollowupPerServiceBO.GetCustom(ServiceProvidedPerSaMIID);
            gvOtherFollowUp.DataBind();
        }

        //Save Followup
        protected void btnSaveServices_Click(object sender, EventArgs e)
        {
            int SaMIProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));
            ServicesProvidedPerSaMI objServicesProvidedPerSaMI = ServicesProvidedPerSaMIBO.GetServicesProvidedPerSaMI(SaMIProfileID);
            FollowUpPerServices objFollowUpPerServices = FollowUpPerServicesBO.GetFollowUpPerService(objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID);
            ServicesProvidedPerSaMI objServicesProvidedPerSaMINew = MapServicesProvidedPerSaMIDTO();
            FollowUpPerServices objFollowUpPerServicesNew = MapFollowUpPerServicesDTO();
            if (objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID > 0)
            {
                objServicesProvidedPerSaMINew.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objServicesProvidedPerSaMINew.UpdatedDate = DateTime.Now;
                objServicesProvidedPerSaMINew.ServiceProvidedPerSaMIID = objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID;

                objFollowUpPerServicesNew.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objFollowUpPerServicesNew.UpdatedDate = DateTime.Now;
                objFollowUpPerServicesNew.SyncStatus = 0;
                objFollowUpPerServicesNew.ServiceProvidedPerSaMIID = objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID;
                objFollowUpPerServicesNew.FollowUpPerServiceID = objFollowUpPerServices.FollowUpPerServiceID;
                ServicesProvidedPerSaMIBO.UpdateServiceProvided(objServicesProvidedPerSaMINew, objFollowUpPerServicesNew, MapAdditionalFollowupInfoList());
            }
            else
            {
                objServicesProvidedPerSaMINew.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objServicesProvidedPerSaMINew.CreatedDate = DateTime.Now;
                objFollowUpPerServicesNew.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objFollowUpPerServicesNew.CreatedDate = DateTime.Now;
                objFollowUpPerServicesNew.SyncStatus = 0;
                int serviceProvidedPerSaMIID = ServicesProvidedPerSaMIBO.InsertServiceProvided(objServicesProvidedPerSaMINew, objFollowUpPerServicesNew, MapAdditionalFollowupInfoList());
                hfServiceProvidedPerSaMIID.Value = serviceProvidedPerSaMIID.ToString();
            }
            LoadServicesOptions();
            LoadServicesProvided(Convert.ToInt32(hfSaMIProfileID.Value));
            LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
        }

        ServicesProvidedPerSaMI MapServicesProvidedPerSaMIDTO()
        {
            ServicesProvidedPerSaMI objServicesProvidedPerSaMI = new ServicesProvidedPerSaMI();
            objServicesProvidedPerSaMI.VisitTimes = txtVisitTimes.Text;
            objServicesProvidedPerSaMI.ServiceProvidedID = Convert.ToInt32(ddlServiceProvided.SelectedValue);
            objServicesProvidedPerSaMI.SaMIProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));
            objServicesProvidedPerSaMI.SyncStatus = 0;
            return objServicesProvidedPerSaMI;
        }

        FollowUpPerServices MapFollowUpPerServicesDTO()
        {
            FollowUpPerServices objFollowUpPerServices = new FollowUpPerServices();

            string ICRecommendation = string.Empty;

            for (int j = 0; j < cblICRecommendation.Items.Count; j++)
            {
                if (cblICRecommendation.Items[j].Selected == true)
                {
                    if (j == 0)
                        ICRecommendation = cblICRecommendation.Items[j].Value;
                    else
                        ICRecommendation = ICRecommendation + "," + cblICRecommendation.Items[j].Value;
                }
            }

            objFollowUpPerServices.ICRecommendationID = ICRecommendation;

            if (rdYes.Checked)
            {
                objFollowUpPerServices.ICFollowUpRequired = 1;
                objFollowUpPerServices.FollowUpID = txtFollowUp.Text;
            }
            else
                objFollowUpPerServices.ICFollowUpRequired = 0;

            if (rbFurtherFollowUpYes.Checked)
            {
                objFollowUpPerServices.FurtherFollowUpRequired = 1;
                objFollowUpPerServices.FurtherFollowUpID = Convert.ToInt32(ddlFurtherFollowUp.SelectedValue);
                ddlFurtherFollowUp.Enabled = true;
            }
            else
                objFollowUpPerServices.FurtherFollowUpRequired = 0;

            objFollowUpPerServices.SyncStatus = 0;

            return objFollowUpPerServices;
        }

        List<AdditionalFollowUpInfoPerServices> MapAdditionalFollowupInfoList()
        {
            //Additional Info
            List<AdditionalFollowUpInfoPerServices> lstAdditionalFollowUpInfoPerServices = new List<AdditionalFollowUpInfoPerServices>();

            if (rbAdditionalInfoYes.Checked)
            {
                for (int j = 0; j < cblAdditionalDocument.Items.Count; j++)
                {
                    if (cblAdditionalDocument.Items[j].Selected == true)
                    {
                        AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices = new AdditionalFollowUpInfoPerServices();
                        objAdditionalFollowUpInfoPerServices.AdditionalFollowupInfoID = Convert.ToInt32(cblAdditionalDocument.Items[j].Value);
                        lstAdditionalFollowUpInfoPerServices.Add(objAdditionalFollowUpInfoPerServices);
                    }
                }
            }

            return lstAdditionalFollowUpInfoPerServices;
        }

        protected void gvOtherFollowUp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdEdit"))
            {
                //ClearOtherFollowUp();
                hfOtherFollowUpPerServiceID.Value = e.CommandArgument.ToString();
                OtherFollowupPerService objOtherFollowupPerService = OtherFollowupPerServiceBO.GetOtherFollowUpInfoPerService(Convert.ToInt32(e.CommandArgument.ToString()));
                txtFollowUpDate.Text = objOtherFollowupPerService.FollowUpDate.ToShortDateString();
                if (objOtherFollowupPerService.NonFollowUpReasonID > 0)
                {
                    ddlNonFollowup.SelectedValue = objOtherFollowupPerService.NonFollowUpReasonID.ToString();

                }
                else
                {
                        if (objOtherFollowupPerService.IsFollowUpComplied == 1)
                        rbComplied.Checked = true;
                    else
                    {
                        rbCompliedPartly.Checked = true;

                        if (objOtherFollowupPerService.IsFollowUpDidNotComply == 1)
                            rbDidNotComply.Checked = true;
                        else
                        {
                            rbReasonForNonCompliance.Checked = true;
                            if (objOtherFollowupPerService.IsReasonRecommendation == 1)
                                rbReasonRecommendation.Checked = true;
                            else if (objOtherFollowupPerService.IsReasonFamilyMember == 1)
                                rbReasonFamilyMember.Checked = true;
                            else
                            {
                                rbWasTooDifficult.Checked = true;
                                if (objOtherFollowupPerService.IsReasonOther == 1)
                                    rbReasonReceipt.Checked = true;
                                else
                                    rbOther.Checked = true;
                            }
                        }
                    }
                }

                txtDidNoComplyReason.Text = objOtherFollowupPerService.Remarks;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                hfOtherFollowUpPerServiceID.Value = e.CommandArgument.ToString();
                OtherFollowupPerServiceBO.DeleteOtherFollowUp(Convert.ToInt32(hfOtherFollowUpPerServiceID.Value));
                LoadOtherFollowupPerService(Convert.ToInt32(hfServiceProvidedPerSaMIID.Value));
                
                hfOtherFollowUpPerServiceID.Value = string.Empty;
            }
        }

        // Save Other Followup
        protected void btnAddOtherFollowUp_Click(object sender, EventArgs e)
        {

            int SaMIProfileID = Convert.ToInt32(hfSaMIProfileID.Value);
            int ServiceProvidedPerSAMIID = Convert.ToInt32(hfServiceProvidedPerSaMIID.Value);

            if (!String.IsNullOrEmpty(hfServiceProvidedPerSaMIID.Value))
            {
                OtherFollowupPerService objOtherFollowupPerService = new OtherFollowupPerService();
                objOtherFollowupPerService.ServiceProvidedPerSaMIID = Convert.ToInt32(ServiceProvidedPerSAMIID);
                objOtherFollowupPerService.NonFollowUpReasonID = Convert.ToInt32(ddlNonFollowup.SelectedValue);

                //reset
                objOtherFollowupPerService.IsFollowUpComplied = 0;
                objOtherFollowupPerService.IsFollowUpDidNotComply = 0;
                objOtherFollowupPerService.IsReasonFamilyMember = 0;
                objOtherFollowupPerService.IsReasonOther = 0;
                objOtherFollowupPerService.IsReasonReceipt = 0;
                objOtherFollowupPerService.IsReasonRecommendation = 0;

                if (objOtherFollowupPerService.NonFollowUpReasonID == 0)
                {
                    if (rbComplied.Checked)
                        objOtherFollowupPerService.IsFollowUpComplied = 1;
                    else
                    {
                        if (rbDidNotComply.Checked)
                        {
                            objOtherFollowupPerService.IsFollowUpDidNotComply = 1;
                        }
                        else
                        {
                            if (rbReasonRecommendation.Checked)
                            {
                                objOtherFollowupPerService.IsReasonRecommendation = 1;
                            }
                            else if (rbReasonFamilyMember.Checked)
                            {
                                objOtherFollowupPerService.IsReasonFamilyMember = 1;
                            }
                            else
                            {
                                if (rbReasonReceipt.Checked)
                                    objOtherFollowupPerService.IsReasonReceipt = 1;
                                else
                                    objOtherFollowupPerService.IsReasonOther = 1;
                            }
                        }
                    }
                }

                objOtherFollowupPerService.FollowUpDate = Convert.ToDateTime(txtFollowUpDate.Text);
                objOtherFollowupPerService.Remarks = txtDidNoComplyReason.Text;
                objOtherFollowupPerService.SyncStatus = 0;

                if (!string.IsNullOrEmpty(hfOtherFollowUpPerServiceID.Value))
                {
                    objOtherFollowupPerService.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                    objOtherFollowupPerService.UpdatedDate = DateTime.Now;
                    objOtherFollowupPerService.OtherFollowUpPerServiceID = Convert.ToInt32(hfOtherFollowUpPerServiceID.Value);
                    OtherFollowupPerServiceBO.UpdateOtherFollowUp(objOtherFollowupPerService);
                }
                else
                {
                    objOtherFollowupPerService.CreatedBy = UserAuthentication.GetUserId(this.Page);
                    objOtherFollowupPerService.CreatedDate = DateTime.Now;
                    OtherFollowupPerServiceBO.InsertOtherFollowUp(objOtherFollowupPerService);
                }

                //ClearOtherFollowUp();
                gvOtherFollowUp.DataSource = OtherFollowupPerServiceBO.GetCustom(ServiceProvidedPerSAMIID);
                gvOtherFollowUp.DataBind();

            }

        }
        #endregion

        #region Foreign Employment

        void LoadForeignEmploymentOptions()
        {
            //Decision Status
            ddlDecisionStatus.DataSource = DecisionStatusBO.GetAll(true);
            ddlDecisionStatus.DataValueField = "DecisionStatusID";
            ddlDecisionStatus.DataTextField = "DecisionStatusDesc";
            ddlDecisionStatus.DataBind();

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


            //Job offered types
            ddlJobOfferedType.DataSource = JobOfferedTypesBO.GetAll(true);
            ddlJobOfferedType.DataValueField = "JobOfferedTypeID";
            ddlJobOfferedType.DataTextField = "JobOfferedTypeDesc";
            ddlJobOfferedType.DataBind();


            //Payment Range:
            /*ddlPaymentRange.DataSource = PaymentRangesBO.GetAll(true);
            ddlPaymentRangeAskedFor.DataSource = PaymentRangesBO.GetAll(true);
            ddlPaymentRangeReceipt.DataSource = PaymentRangesBO.GetAll(true);
            ddlPaymentRange.DataValueField = "PaymentRangeID";
            ddlPaymentRange.DataTextField = "PaymentRangeDesc";
            ddlPaymentRange.DataBind();
            ddlPaymentRangeAskedFor.DataValueField = "PaymentRangeID";
            ddlPaymentRangeAskedFor.DataTextField = "PaymentRangeDesc";
            ddlPaymentRangeAskedFor.DataBind();
            ddlPaymentRangeReceipt.DataValueField = "PaymentRangeID";
            ddlPaymentRangeReceipt.DataTextField = "PaymentRangeDesc";
            ddlPaymentRangeReceipt.DataBind();*/

          


            ddlJobOfferSource.Enabled = false;
            ddlJobOfferedType.Enabled = false;
            //ddlWorkType.Enabled = false;
            /*ddlPaymentRange.Enabled = false;
            ddlPaymentRangeReceipt.Enabled = false;
            ddlPaymentRangeAskedFor.Enabled = false;*/

            txtMadePaymentAmount.Enabled = false;
            txtReceiptPaymentAmount.Enabled = false;
            txtAskedPaymentAmount.Enabled = false;

            ddlWillingCountry.DataSource = CountriesBO.GetAll(true);
            ddlWillingCountry.DataValueField = "CountryID";
            ddlWillingCountry.DataTextField = "CountryName";
            ddlWillingCountry.DataBind();


        }

        void LoadForeignEmploymentStatus(int SaMIProfileID)
        {
            //Foreign Employment Status
            ForeignEmploymentStatus objForeignEmploymentStatus = ForeignEmploymentStatusBO.GetFEStatus(SaMIProfileID);

            if (objForeignEmploymentStatus.ForeignEmploymentStatusID > 0)
            {
                ddlJobOfferSource.Enabled = true;
                ddlJobOfferedType.Enabled = true;
                txtMadePaymentAmount.Enabled = true;
                txtReceiptPaymentAmount.Enabled = true;
                txtAskedPaymentAmount.Enabled = true;

                ddlDecisionStatus.SelectedValue = objForeignEmploymentStatus.DecisionStatusID.ToString();
                ddlPassportStatus.SelectedValue = objForeignEmploymentStatus.PassportStatusID.ToString();

                if (objForeignEmploymentStatus.HaveJobOffer == 1)
                    rbJobOfferYes.Checked = true;
                else
                    rbJobOfferNo.Checked = true;

                if (objForeignEmploymentStatus.JobOfferSourceID > 0)
                    ddlJobOfferSource.SelectedValue = objForeignEmploymentStatus.JobOfferSourceID.ToString();
                else
                    ddlJobOfferSource.Enabled = false;

                if (objForeignEmploymentStatus.JobOfferedTypeID > 0)
                    ddlJobOfferedType.SelectedValue = objForeignEmploymentStatus.JobOfferedTypeID.ToString();
                else
                    ddlJobOfferedType.Enabled = false;

                //if (objForeignEmploymentStatus.WorkTypeID > 0)
                //    ddlWorkType.SelectedValue = objForeignEmploymentStatus.WorkTypeID.ToString();
                //else
                //    ddlWorkType.Enabled = false;

                if (objForeignEmploymentStatus.MadePaymentAmount != string.Empty)
                {
                    txtAskedPaymentAmount.Enabled = false;
                    rbMadePaymentYes.Checked = true;
                    txtMadePaymentAmount.Text = objForeignEmploymentStatus.MadePaymentAmount.ToString();

                    if (objForeignEmploymentStatus.HavePaymentReceipt == 1)
                    {
                        rblPaymentReceiptYes.Checked = true;
                        txtReceiptPaymentAmount.Text = objForeignEmploymentStatus.ReceiptPaymentAmount.ToString();
                    }
                    else
                    {
                        rblPaymentReceiptNo.Checked = true;
                        txtReceiptPaymentAmount.Enabled = false;
                    }
                }
                else
                {
                    txtMadePaymentAmount.Enabled = false;
                    txtReceiptPaymentAmount.Enabled = false;
                    rbMadePaymentNo.Checked = true;

                    if (objForeignEmploymentStatus.NothingAskedYet == 1)
                    {
                        chkNothingYet.Checked = true;
                        txtAskedPaymentAmount.Enabled = false;
                    }
                    else
                        txtAskedPaymentAmount.Text = objForeignEmploymentStatus.AskedPaymentAmount.ToString();
                }

                //ddlICKnowledge.SelectedValue = objForeignEmploymentStatus.ICKnowledgeID.ToString();
                ddlWillingCountry.SelectedValue = objForeignEmploymentStatus.CountryID.ToString();

                if (objForeignEmploymentStatus.ReferToFSkill == 1)
                    chkReferred.Checked = true;
                else
                    chkReferred.Checked = false;


                if (objForeignEmploymentStatus.ReferToCase == 1)
                    chkReferredToCase.Checked = true;
                else
                    chkReferredToCase.Checked = false;

                //if (objForeignEmploymentStatus.PotentialAndNonPotentialMigrant == 1)
                //    chkPotentialMigrants.Checked = true;
                //else
                //    chkPotentialMigrants.Checked = false;
            }

        }

        ForeignEmploymentStatus MapForeignEmploymentStatusDTO()
        {
            ForeignEmploymentStatus objForeignEmploymentStatus = new ForeignEmploymentStatus();
            objForeignEmploymentStatus.DecisionStatusID = Convert.ToInt32(ddlDecisionStatus.SelectedValue);
            objForeignEmploymentStatus.PassportStatusID = Convert.ToInt32(ddlPassportStatus.SelectedValue);

            if (rbJobOfferYes.Checked)
            {
                objForeignEmploymentStatus.HaveJobOffer = 1;
                objForeignEmploymentStatus.JobOfferSourceID = Convert.ToInt32(ddlJobOfferSource.SelectedValue);
                objForeignEmploymentStatus.JobOfferedTypeID = Convert.ToInt32(ddlJobOfferedType.SelectedValue);
                objForeignEmploymentStatus.WorkTypeID = 0;
            }
            else
            {
                objForeignEmploymentStatus.JobOfferSourceID = 0;
                objForeignEmploymentStatus.JobOfferedTypeID = 0;
                //objForeignEmploymentStatus.WorkTypeID = Convert.ToInt32(ddlWorkType.SelectedValue);

            }

            if (rbMadePaymentYes.Checked)
            {
                objForeignEmploymentStatus.MadePaymentAmount = txtMadePaymentAmount.Text;

                if (rblPaymentReceiptYes.Checked)
                {
                    objForeignEmploymentStatus.HavePaymentReceipt = 1;
                    objForeignEmploymentStatus.ReceiptPaymentAmount = txtReceiptPaymentAmount.Text;
                }
                else
                {
                    objForeignEmploymentStatus.HavePaymentReceipt = 0;
                    objForeignEmploymentStatus.ReceiptPaymentAmount = string.Empty;
                }
            }
            else
            {
                objForeignEmploymentStatus.MadePaymentAmount = string.Empty;

                if (!chkNothingYet.Checked)
                {
                    objForeignEmploymentStatus.NothingAskedYet = 0;
                    objForeignEmploymentStatus.AskedPaymentAmount = txtAskedPaymentAmount.Text;
                }
                else
                {
                    objForeignEmploymentStatus.AskedPaymentAmount = string.Empty;
                    objForeignEmploymentStatus.NothingAskedYet = 1;
                }
            }

            if (chkReferred.Checked)
                objForeignEmploymentStatus.ReferToFSkill = 1;
            else
                objForeignEmploymentStatus.ReferToFSkill = 0;

            if (chkReferredToCase.Checked)
                objForeignEmploymentStatus.ReferToCase = 1;
            else
                objForeignEmploymentStatus.ReferToCase = 0;

            //if (chkPotentialMigrants.Checked)
            //    objForeignEmploymentStatus.PotentialAndNonPotentialMigrant = 1;
            //else
            //    objForeignEmploymentStatus.PotentialAndNonPotentialMigrant = 0;

            //objForeignEmploymentStatus.ICKnowledgeID = 0;// Convert.ToInt32(ddlICKnowledge.SelectedValue);
            objForeignEmploymentStatus.CountryID = Convert.ToInt32(ddlWillingCountry.SelectedValue);
            objForeignEmploymentStatus.SyncStatus = 0;
            return objForeignEmploymentStatus;
        }

        TRNRecruitmentList MapRecruitmentList()
        {
            TRNRecruitmentList objRecruitmentList = new TRNRecruitmentList();

            int saMIOrganizationID = UserAuthentication.GetSaMIOrganizationId(this.Page);
            objRecruitmentList.OrganizationID = saMIOrganizationID;
            objRecruitmentList.ReferStatus = 1;
            objRecruitmentList.CreatedBy = UserAuthentication.GetUserId(this.Page);
            objRecruitmentList.CreatedDate = DateTime.Now;
            objRecruitmentList.SyncStatus = 0;
            return objRecruitmentList;
        }

        protected void btnSaveForeignEmployment_Click(object sender, EventArgs e)
        {
            int ForeignEmploymentId = 0;
            int SaMIProfileID = Convert.ToInt32(Request.QueryString.Get("ID")); ;

            ForeignEmploymentStatus objForeignEmploymentStatus = ForeignEmploymentStatusBO.GetFEStatus(SaMIProfileID);

            if (objForeignEmploymentStatus.ForeignEmploymentStatusID > 0)
            {
                ForeignEmploymentStatus objForeignEmploymentStatusNew = MapForeignEmploymentStatusDTO();
                objForeignEmploymentStatusNew.SaMIProfileID = SaMIProfileID;
                objForeignEmploymentStatusNew.ForeignEmploymentStatusID = objForeignEmploymentStatus.ForeignEmploymentStatusID;
                objForeignEmploymentStatusNew.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objForeignEmploymentStatusNew.UpdatedDate = DateTime.Now;
                ForeignEmploymentId = ForeignEmploymentStatusBO.UpdateFEStatus(objForeignEmploymentStatusNew);
            }
            else
            {
                objForeignEmploymentStatus = MapForeignEmploymentStatusDTO();
                objForeignEmploymentStatus.SaMIProfileID = SaMIProfileID;
                objForeignEmploymentStatus.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objForeignEmploymentStatus.CreatedDate = DateTime.Now;
                ForeignEmploymentId = ForeignEmploymentStatusBO.InsertFEStatus(objForeignEmploymentStatus);
            }
            if (ForeignEmploymentId > 0)
            {
                hfForeignEmploymentID.Value = ForeignEmploymentId.ToString();
            }

            //Refer To F-Skill
            DataView dvCheckReferStatus = TRNRecruitmentListBO.GetStatus(Convert.ToInt32(hfSaMIProfileID.Value));
            if (dvCheckReferStatus.Count == 0)
            {
                if (chkReferred.Checked)
                {
                    TRNRecruitmentList objRecruitmentList = MapRecruitmentList();
                    objRecruitmentList.SaMIProfileID = Convert.ToInt32(hfSaMIProfileID.Value);
                    int ReferStatus = TRNRecruitmentListBO.InsertRecruitmentList(objRecruitmentList);
                }
            }
            else
            {
                if (chkReferred.Checked == false)
                {
                    int Status = TRNRecruitmentListBO.DeleteRecruitmentList(Convert.ToInt32(hfSaMIProfileID.Value));
                }
            }

            //Refer To Case
            DataView dvCheckReferStatusToCase = CaseReferredBO.GetStatus(Convert.ToInt32(hfSaMIProfileID.Value));
            if (dvCheckReferStatusToCase.Count == 0)
            {
                if (chkReferredToCase.Checked)
                {
                    CaseReferred objCaseReferred = new CaseReferred();
                    objCaseReferred.SaMIProfileID = Convert.ToInt32(hfSaMIProfileID.Value);
                    objCaseReferred.ReferStatus = 1;
                    objCaseReferred.CreatedBy = UserAuthentication.GetUserId(this.Page);
                    objCaseReferred.CreatedDate = DateTime.Now;
                    objCaseReferred.SyncStatus = 0;
                    int ReferStatus = CaseReferredBO.InsertCaseReferred(objCaseReferred);
                }
            }
            else
            {
                if (chkReferred.Checked == false)
                {
                    int Status = CaseReferredBO.DeleteCaseReferred(Convert.ToInt32(hfSaMIProfileID.Value));
                }
            }

            Response.Redirect("~/Profile/Edit.aspx?ID=" + Convert.ToInt32(hfSaMIProfileID.Value));

            LoadForeignEmploymentOptions();
            LoadForeignEmploymentStatus(SaMIProfileID);
            LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
        }


        #endregion

        #region Phone Follow Up

        int PhonefollowupId = 0;

        private void LoadPhoneFollowUp(int PhoneFollowUpId)
        {
           // string a = hfPhoneFollowUpId.Value;
            //DataView dvPhoneFollowUp = PhoneFollowUpBO.GetBySaMIProfileID(SaMIProfileID);
            DataView dvPhoneFollowUp = PhoneFollowUpBO.GetByPhoneFollowUpID(PhoneFollowUpId);

            if (dvPhoneFollowUp.Count > 0)
            {
                if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["LeftForFE"].ToString()))
                {
                    if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["LeftForFE"]) == 1)
                    {
                        rbtnLeftFEYes.Checked = true;
                        rbtnLeftFENo.Checked = false;
                        txtContractNumber.Text = dvPhoneFollowUp.Table.Rows[0]["ContractNumber"].ToString();
                        txtMigratedCountry.Text = dvPhoneFollowUp.Table.Rows[0]["MigratedCountry"].ToString();
                        txtMigratedDate.Text = dvPhoneFollowUp.Table.Rows[0]["MigratedDate"].ToString();
                        if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["MigratedAfterTraining"].ToString()))
                        {
                            if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["MigratedAfterTraining"]) == 1)
                            {
                                rbtnMigratedAfterTrainingYes.Checked = true;
                                rbtnMigratedAfterTrainingNo.Checked = false;
                                
                            }

                            if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["MigratedAfterTraining"]) == 0)
                            {
                                rbtnMigratedAfterTrainingNo.Checked = true;
                                rbtnMigratedAfterTrainingYes.Checked = false;
                            }
                            txtManpowerAgent.Text = dvPhoneFollowUp.Table.Rows[0]["ManpowerAgent"].ToString();
                            txtAmountPaidforFE.Text = dvPhoneFollowUp.Table.Rows[0]["AmountPaidforFE"].ToString();

                            List<string> lstSourceOfInvestment = PhoneFollowUpBO.SelectSourceOfInvestment(PhoneFollowUpId);

                            if (lstSourceOfInvestment.Count > 0)
                            {
                                for (int j = 0; j < chkSourceOfInvestment.Items.Count; j++)
                                {
                                    if (lstSourceOfInvestment.Exists(delegate(string source) { return source == chkSourceOfInvestment.Items[j].Value; }))
                                    {
                                        chkSourceOfInvestment.Items[j].Selected = true;
                                    }

                                }
                            }

                            if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["ReceiptReceived"].ToString()))
                            {
                                if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["ReceiptReceived"]) == 1)
                                    rbtnReceiptFromManpowerYes.Checked = true;
                                if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["ReceiptReceived"]) == 0)
                                    rbtnReceiptFromManpowerNo.Checked = true;
                            }
                            if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["LeftDocumentBeforeDeparture"].ToString()))
                            {
                                if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["LeftDocumentBeforeDeparture"]) == 1)
                                    rbtnLeftDocumentYes.Checked = true;
                                if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["LeftDocumentBeforeDeparture"]) == 0)
                                    rbtnLeftDocumentNo.Checked = true;
                            }
                            if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["SameWorkAsAgreement"].ToString()))
                            {
                                if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["SameWorkAsAgreement"]) == 1)
                                    rbtnWorkAggreementYes.Checked = true;
                                if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["SameWorkAsAgreement"]) == 0)
                                    rbtnWorkAggreementNo.Checked = true;
                            }
                            if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["SameSalaryAsAgreement"].ToString()))
                            {
                                if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["SameSalaryAsAgreement"]) == 1)
                                    rbtnSalaryAgreementYes.Checked = true;
                                if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["SameSalaryAsAgreement"]) == 0)
                                    rbtnSalaryAgreementNo.Checked = true;
                            }

                        }

                    }
                }
                if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["LeftForFE"].ToString()))
                {
                    if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["LeftForFE"]) == 0)
                    {
                        rbtnLeftFEYes.Checked = false;
                        rbtnLeftFENo.Checked = true;
                        ddlCurrentStatus.Text = dvPhoneFollowUp.Table.Rows[0]["VisitorsCurrentStatus"].ToString();
                        txtCurrentStatus.Text = dvPhoneFollowUp.Table.Rows[0]["VisitorsOtherStatus"].ToString();
                    }
                }

                txtAdditionalInfo.Text = dvPhoneFollowUp.Table.Rows[0]["AdditionalInfo"].ToString();
                txtRecommendations.Text = dvPhoneFollowUp.Table.Rows[0]["Recommendation"].ToString();
                txtNameOfInformants.Text = dvPhoneFollowUp.Table.Rows[0]["InformantsName"].ToString();
                txtRelationMigrant.Text = dvPhoneFollowUp.Table.Rows[0]["MigrantRelation"].ToString();
                txtDateOfFollowUp.Text = dvPhoneFollowUp.Table.Rows[0]["FollowUpDate"].ToString();
                txtRemarks.Text = dvPhoneFollowUp.Table.Rows[0]["Remarks"].ToString();
            }
        }

        //Name, Address, RegistrationDate
        private void LoadTraineeInfo(int SaMIProfileID)
        {
            DataView dvTraineeInfo = SaMIProfileBO.GetTraineeInfo(SaMIProfileID);
            lblNameOfVisitor.Text = dvTraineeInfo.Table.Rows[0]["NAME"].ToString();
            lblAddressOfVisitor.Text = dvTraineeInfo.Table.Rows[0]["ADDRESS"].ToString();
            lblICCVisitedDate.Text = dvTraineeInfo.Table.Rows[0]["REGISTRATIONDATE"].ToString();
        }

        protected void btnSavePhoneFollowUp_Click(object sender, EventArgs e)
        {
            String sourceofInvestment = string.Empty;
            //DataView dvPhoneFollowUp = PhoneFollowUpBO.GetBySaMIProfileID(Convert.ToInt32(Request.QueryString.Get("ID")));
            //if (dvPhoneFollowUp.Count > 0)
            //{
            //    ID = Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["PhoneFollowUpID"]);
            //}
            PhoneFollowUp objPhoneFollowUp = new PhoneFollowUp();

            int SaMIProfileId = Convert.ToInt32(hfSaMIProfileID.Value);
            objPhoneFollowUp.SaMIProfileID = SaMIProfileId;

            if (rbtnLeftFEYes.Checked)
            {
                objPhoneFollowUp.LeftForFE = 1;
                objPhoneFollowUp.ContractNumber = txtContractNumber.Text;
                objPhoneFollowUp.MigratedCountry = txtMigratedCountry.Text;
                objPhoneFollowUp.MigratedDate = txtMigratedDate.Text;
                if (rbtnMigratedAfterTrainingYes.Checked)
                {
                    objPhoneFollowUp.MigratedAfterTraining = 1;
                }
                else if (rbtnMigratedAfterTrainingNo.Checked)
                {
                    objPhoneFollowUp.MigratedAfterTraining = 0;
                }
                objPhoneFollowUp.ManpowerAgent = txtManpowerAgent.Text;
                objPhoneFollowUp.AmountPaidforFE = txtAmountPaidforFE.Text;

                for (int j = 0; j < chkSourceOfInvestment.Items.Count; j++)
                {
                    if (chkSourceOfInvestment.Items[j].Selected == true)
                    {
                        if (j == 0)
                            sourceofInvestment = chkSourceOfInvestment.Items[j].Value;
                        else
                            sourceofInvestment = sourceofInvestment + "," + chkSourceOfInvestment.Items[j].Value;
                    }
                }

                objPhoneFollowUp.SourceOfInvestment = sourceofInvestment;
                if (rbtnReceiptFromManpowerYes.Checked)
                    objPhoneFollowUp.ReceiptReceived = 1;
                else if (rbtnReceiptFromManpowerNo.Checked)
                    objPhoneFollowUp.ReceiptReceived = 0;
                if (rbtnLeftDocumentYes.Checked)
                    objPhoneFollowUp.LeftDocumentBeforeDeparture = 1;
                else if (rbtnLeftDocumentNo.Checked)
                    objPhoneFollowUp.LeftDocumentBeforeDeparture = 0;
                if (rbtnWorkAggreementYes.Checked)
                    objPhoneFollowUp.SameWorkAsAgreement = 1;
                else if (rbtnWorkAggreementNo.Checked)
                    objPhoneFollowUp.SameWorkAsAgreement = 0;
                if (rbtnSalaryAgreementYes.Checked)
                    objPhoneFollowUp.SameSalaryAsAgreement = 1;
                else if (rbtnSalaryAgreementNo.Checked)
                    objPhoneFollowUp.SameSalaryAsAgreement = 0;
            }
            else if (rbtnLeftFENo.Checked)
            {
                objPhoneFollowUp.LeftForFE = 0;
                objPhoneFollowUp.VisitorsCurrentStatus = ddlCurrentStatus.Text;
                objPhoneFollowUp.VisitorsOtherStatus = txtCurrentStatus.Text;
            }

            objPhoneFollowUp.AdditionalInfo = txtAdditionalInfo.Text;
            objPhoneFollowUp.Recommendation = txtRecommendations.Text;
            objPhoneFollowUp.InformantsName = txtNameOfInformants.Text;
            objPhoneFollowUp.MigrantRelation = txtRelationMigrant.Text;
            objPhoneFollowUp.FollowUpDate = txtDateOfFollowUp.Text;
            objPhoneFollowUp.Remarks = txtRemarks.Text;
            
            objPhoneFollowUp.Status = 1;
            objPhoneFollowUp.GUID = 0;
            objPhoneFollowUp.SyncStatus = 0;

            if (hfPhoneFollowUpID.Value != string.Empty)
            {
                objPhoneFollowUp.PhoneFollowUpID = Convert.ToInt32(hfPhoneFollowUpID.Value);
                objPhoneFollowUp.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objPhoneFollowUp.UpdatedDate = DateTime.Now;
                PhonefollowupId = PhoneFollowUpBO.UpdatePhoneFollowUp(objPhoneFollowUp);
            }
            else
            {
                objPhoneFollowUp.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objPhoneFollowUp.CreatedDate = DateTime.Now;
                PhonefollowupId = PhoneFollowUpBO.InsertPhoneFollowUp(objPhoneFollowUp);
            }
            if (PhonefollowupId > 0)
            {
                hfPhoneFollowUpID.Value = PhonefollowupId.ToString();
                LoadPhoneFollowUpList(SaMIProfileId);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);

                ClearPhoneFollowUpList();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
            }
        }

        public void LoadPhoneFollowUpList(int SaMIProfileID)
        {
            gvPhoneFollowUp.DataSource = PhoneFollowUpBO.GetPhoneInfoSaMIProfileID(Convert.ToInt32(hfSaMIProfileID.Value));
            gvPhoneFollowUp.DataBind();
        }

        protected void gvPhoneFollowUp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdEdit"))
            {
                hfPhoneFollowUpID.Value = e.CommandArgument.ToString();
                //PhoneFollowUp objPhoneFollowUp = PhoneFollowUpBO.GetPhoneFollowUp(Convert.ToInt32(e.CommandArgument.ToString()));
                
                LoadPhoneFollowUp(Convert.ToInt32(hfPhoneFollowUpID.Value));
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myalert", "alert('File already exists.');", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "abc()", true);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                hfPhoneFollowUpID.Value = e.CommandArgument.ToString();
                PhoneFollowUp objPhoneFollowUp = new PhoneFollowUp();
                objPhoneFollowUp.PhoneFollowUpID = Convert.ToInt32(e.CommandArgument.ToString());
                objPhoneFollowUp.Status = 0;
                objPhoneFollowUp.SyncStatus = 0;
                PhoneFollowUpBO.DeletePhoneFollowUp(objPhoneFollowUp);
                LoadPhoneFollowUpList(Convert.ToInt32(hfSaMIProfileID.Value));
                ClearPhoneFollowUpList();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
            }
        }

        #endregion

        #region Phone Follow Up Info

        //private void LoadPhoneFollowUpInfo(int SaMIProfileID)
        //{
        //    DataView dvPhoneFollowUpInfo = PhoneFollowUpInfoBO.GetBySaMIProfileID(SaMIProfileID);

        //    if (dvPhoneFollowUpInfo.Count > 0)
        //    {
        //        txtNameOfInformants.Text = dvPhoneFollowUpInfo.Table.Rows[0]["InformantsName"].ToString();
        //        txtRelationMigrant.Text = dvPhoneFollowUpInfo.Table.Rows[0]["MigrantRelation"].ToString();
        //        txtDateOfFollowUp.Text = dvPhoneFollowUpInfo.Table.Rows[0]["FollowUpDate"].ToString();
        //        txtRemarks.Text = dvPhoneFollowUpInfo.Table.Rows[0]["Remarks"].ToString();
        //    }
        //}

        //protected void btnAddPhoneFollowUp_Click(object sender, EventArgs e)
        //{
        //    int ID = 0;
        //    DataView dvPhoneFollowUpInfo = PhoneFollowUpInfoBO.GetBySaMIProfileID(Convert.ToInt32(Request.QueryString.Get("ID")));
        //    if (dvPhoneFollowUpInfo.Count > 0)
        //    {
        //        ID = Convert.ToInt32(dvPhoneFollowUpInfo.Table.Rows[0]["PhoneFollowUpInfoID"]);
        //    }

        //    int PhoneFollowUpInfoID = 0;
        //    PhoneFollowUpInfo objPhoneFollowUpInfo = new PhoneFollowUpInfo();
        //    objPhoneFollowUpInfo.SaMIProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));
        //    objPhoneFollowUpInfo.InformantsName = txtNameOfInformants.Text;
        //    objPhoneFollowUpInfo.MigrantRelation = txtRelationMigrant.Text;
        //    objPhoneFollowUpInfo.FollowUpDate = txtDateOfFollowUp.Text;
        //    objPhoneFollowUpInfo.Remarks = txtRemarks.Text;

        //    objPhoneFollowUpInfo.Status = 1;
        //    objPhoneFollowUpInfo.GUID = 0;
        //    objPhoneFollowUpInfo.SyncStatus = 0;

        //    int id = 0;
        //    if (!String.IsNullOrEmpty(hfPhoneFollowUpInfoID.Value))
        //        id = Convert.ToInt32(hfPhoneFollowUpInfoID.Value);
        //    if (id > 0)
        //    {
        //        objPhoneFollowUpInfo.PhoneFollowUpInfoID = id;
        //        objPhoneFollowUpInfo.UpdatedBy = UserAuthentication.GetUserId(this.Page);
        //        objPhoneFollowUpInfo.UpdatedDate = DateTime.Now;
        //        PhoneFollowUpInfoID = PhoneFollowUpInfoBO.UpdatePhoneFollowUpInfo(objPhoneFollowUpInfo);
        //        if (PhoneFollowUpInfoID > 0)
        //        {
        //            LoadPhoneFollowUpList(Convert.ToInt32(Request.QueryString.Get("ID")));
        //            ClearPhoneFollowUpList();
        //            Response.Redirect("~/Profile/Edit.aspx?ID=" + Convert.ToInt32(hfSaMIProfileID.Value));
        //        }
        //    }
        //    else
        //    {
        //        objPhoneFollowUpInfo.CreatedBy = UserAuthentication.GetUserId(this.Page);
        //        objPhoneFollowUpInfo.CreatedDate = DateTime.Now;
        //        PhoneFollowUpInfoID = PhoneFollowUpInfoBO.InsertPhoneFollowUpInfo(objPhoneFollowUpInfo);
        //        if (PhoneFollowUpInfoID > 0)
        //        {
        //            LoadPhoneFollowUpList(Convert.ToInt32(Request.QueryString.Get("ID")));
        //            ClearPhoneFollowUpList();
        //            Response.Redirect("~/Profile/Edit.aspx?ID=" + Convert.ToInt32(hfSaMIProfileID.Value));
        //        }
        //    }
            
        //}

        #endregion

        #region Clear Fields

        void ClearForeignEmployemntExperience()
        {
            ddlCountry.SelectedIndex = 0;
            ddlJobType.SelectedIndex = 0;
            ddlStayDuration.SelectedIndex = 0;
            hfForeignEmploymentExperienceID.Value = string.Empty;
        }

        void ClearPhoneFollowUpList()
        {
            rbtnLeftFEYes.Checked = false;
            rbtnLeftFENo.Checked = false;
            txtContractNumber.Text = string.Empty;
            txtMigratedCountry.Text = string.Empty;
            txtMigratedDate.Text = string.Empty;
            rbtnMigratedAfterTrainingYes.Checked = false;
            rbtnMigratedAfterTrainingNo.Checked = false;
            txtManpowerAgent.Text = string.Empty;
            txtAmountPaidforFE.Text = string.Empty;
            rbtnReceiptFromManpowerYes.Checked = false;
            rbtnReceiptFromManpowerNo.Checked = false;
            rbtnLeftDocumentYes.Checked = false;
            rbtnLeftDocumentNo.Checked = false;
            rbtnWorkAggreementYes.Checked = false;
            rbtnWorkAggreementNo.Checked = false;
            rbtnSalaryAgreementYes.Checked = false;
            rbtnSalaryAgreementNo.Checked = false;
            ddlCurrentStatus.SelectedValue = string.Empty;
            txtCurrentStatus.Text = string.Empty;
            txtAdditionalInfo.Text = string.Empty;
            txtRecommendations.Text = string.Empty;
            txtNameOfInformants.Text = string.Empty;
            txtRelationMigrant.Text = string.Empty;
            txtDateOfFollowUp.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            hfPhoneFollowUpID.Value = string.Empty;
            for(int i = 0; i < 3; i++)
            {
                chkSourceOfInvestment.Items[i].Selected = false;
            }
        }

        #endregion

        protected String SetPermission()
        {

            string strPermitted = string.Empty;

            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                btnSaveForeignEmployment.Visible = false;
                btnSaveServices.Visible = false;
                btnSavePhoneFollowUp.Visible = false;

                strPermitted = "<li class=\"active\" onclick=\"ShowHideButton('general');\"><a href=\"#general\" onclick=\"ShowHideButton('general');return false;\" data-toggle=\"tab\">General Information</a></li> " +
                   "<li onclick=\"$('#ctl00_MainContent_btnSave').hide();\"><a href=\"#casedocumentation\" onclick=\"$('#ctl00_MainContent_btnSave').hide();return false;\" data-toggle=\"tab\">Case Documentation</a></li> ";

            }
            else
            {
                strPermitted = "<li class=\"active\" onclick=\"ShowHideButton('general');\"><a href=\"#general\" onclick=\"ShowHideButton('general');return false;\" data-toggle=\"tab\">General Information</a></li> " +
                    "<li onclick=\"ShowHideButton('foreign');\"><a href=\"#foreign\" onclick=\"ShowHideButton('foreign');return false;\" data-toggle=\"tab\">Foreign Employment</a></li> " +
                    "<li onclick=\"ShowHideButton('servicesandfollowup');\"><a href=\"#servicesandfollowup\" onclick=\"ShowHideButton('servicesandfollowup');return false;\" data-toggle=\"tab\">Follow-Up</a></li> " +
                    "<li onclick=\"ShowHideButton('phonefollowup');\"><a href=\"#phonefollowup\" onclick=\"ShowHideButton('phonefollowup');return false;\" data-toggle=\"tab\">Phone Follow-Up</a></li> ";
            }
            return strPermitted;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile/Edit.aspx?ID=" + Convert.ToInt32(hfSaMIProfileID.Value));
        }

        

    }
}