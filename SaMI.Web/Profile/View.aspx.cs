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
    public partial class View : System.Web.UI.Page
    {
        public int j;
        public List<int> list = new List<int>();
        public int ethnicityID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int SaMIProfileID = 0;

            if (!string.IsNullOrEmpty(Request.QueryString.Get("ID")))
                SaMIProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));

            if (!UserAuthentication.CheckPermission(SaMIProfileID, this.Page))
                Response.Redirect("Index.aspx");

            if (!Page.IsPostBack)
            {
                LoadOptions();
                LoadAllData(SaMIProfileID);

            }
        }

        void LoadOptions()
        {
            //GeoBased Ethnicity
            rbValidRegions.DataSource = EthnicityBO.SelectGeoBasedEthnicity();
            rbValidRegions.DataValueField = "GeoBasedEthnicityID";
            rbValidRegions.DataTextField = "GeoBasedEthnicityDesc";
            rbValidRegions.DataBind();

            //ICRecommendation
            cblICRecommendation.DataSource = ICRecommendationsBO.GetAll(false);
            cblICRecommendation.DataValueField = "ICRecommendationID";
            cblICRecommendation.DataTextField = "ICRecommendationDesc";
            cblICRecommendation.DataBind();

            //Additional Document
            cblAdditionalDocument.DataSource = AdditionalFollowUpInfoBO.GetAll();
            cblAdditionalDocument.DataValueField = "AdditionalFollowUpInfoID";
            cblAdditionalDocument.DataTextField = "AdditionalFollowUpInfoDesc";
            cblAdditionalDocument.DataBind();

            //Document Left
            cblDocumentsBehind.DataSource = DocumentsBehindBO.GetAll();
            cblDocumentsBehind.DataValueField = "DocumentBehindID";
            cblDocumentsBehind.DataTextField = "DocumentBehindDesc";
            cblDocumentsBehind.DataBind();

            //Problem Types
            cblProblemType.DataSource = ProblemTypesBO.GetAll();
            cblProblemType.DataValueField = "ProblemTypeID";
            cblProblemType.DataTextField = "ProblemTypeDesc";
            cblProblemType.DataBind();

            //Evidence Types
            cblEvidenceTypes.DataSource = EvidenceTypeBO.GetAll();
            cblEvidenceTypes.DataValueField = "EvidenceTypeID";
            cblEvidenceTypes.DataTextField = "EvidenceTypeDesc";
            cblEvidenceTypes.DataBind();

            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                pnlIC.Visible = false;
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
            LoadCasesAndFollowUp(SaMIProfileID);
            LoadCaseDocumentation(SaMIProfileID);
            LoadEmploymentSkill(SaMIProfileID);
            LoadEmployment(SaMIProfileID);
            LoadPreviousFEExperience(SaMIProfileID);
            LoadPhoneFollowUp(SaMIProfileID);
        }

        private void LoadPhoneFollowUp(int SaMIProfileID)
        {
            DataView dvTraineeInfo = SaMIProfileBO.GetTraineeInfo(SaMIProfileID);
            lblNameOfVisitor.Text = dvTraineeInfo.Table.Rows[0]["NAME"].ToString();
            lblAddressOfVisitor.Text = dvTraineeInfo.Table.Rows[0]["ADDRESS"].ToString();
            lblICCVisitedDate.Text = dvTraineeInfo.Table.Rows[0]["REGISTRATIONDATE"].ToString();

            DataView dvPhoneFollowUp = PhoneFollowUpBO.GetBySaMIProfileID(SaMIProfileID);

            if (dvPhoneFollowUp.Count > 0)
            {
                if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["LeftForFE"].ToString()))
                {
                    if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["LeftForFE"]) == 1)
                    {
                        rbtnLeftFEYes.Checked = true;
                        rbtnLeftFENo.Checked = false;
                        lblContractNumber.Text = dvPhoneFollowUp.Table.Rows[0]["ContractNumber"].ToString();
                        lblMigratedCountry.Text = dvPhoneFollowUp.Table.Rows[0]["MigratedCountry"].ToString();
                        lblMigratedDate.Text = dvPhoneFollowUp.Table.Rows[0]["MigratedDate"].ToString();
                        if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["MigratedAfterTraining"].ToString()))
                        {
                            if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["MigratedAfterTraining"]) == 1)
                            {
                                rbtnMigratedAfterTrainingYes.Checked = true;
                                rbtnMigratedAfterTrainingNo.Checked = false;
                                lblManpowerAgent.Text = dvPhoneFollowUp.Table.Rows[0]["ManpowerAgent"].ToString();
                                lblAmountPaidforFE.Text = dvPhoneFollowUp.Table.Rows[0]["AmountPaidforFE"].ToString();

                                List<string> lstSourceOfInvestment = PhoneFollowUpBO.SelectSourceOfInvestment(SaMIProfileID);

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
                            if (!String.IsNullOrEmpty(dvPhoneFollowUp.Table.Rows[0]["MigratedAfterTraining"].ToString()))
                            {
                                if (Convert.ToInt32(dvPhoneFollowUp.Table.Rows[0]["MigratedAfterTraining"]) == 0)
                                {
                                    rbtnMigratedAfterTrainingNo.Checked = true;
                                    rbtnMigratedAfterTrainingYes.Checked = false;
                                }
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
                        lblCurrentStatusOption.Text = dvPhoneFollowUp.Table.Rows[0]["VisitorsCurrentStatus"].ToString();
                        lblCurrentStatus.Text = dvPhoneFollowUp.Table.Rows[0]["VisitorsOtherStatus"].ToString();
                    }
                }

                lblAdditionalInfo.Text = dvPhoneFollowUp.Table.Rows[0]["AdditionalInfo"].ToString();
                lblRecommendations.Text = dvPhoneFollowUp.Table.Rows[0]["Recommendation"].ToString();
            }

            gvPhoneFollowUp.DataSource = PhoneFollowUpInfoBO.GetBySaMIProfileID(SaMIProfileID);
            gvPhoneFollowUp.DataBind();
        }

        private void LoadPreviousFEExperience(int SaMIProfileID)
        {
            DataView dv = PreviousFEExperienceBO.SelectAllBySaMIProfileID(SaMIProfileID);
            if (dv.Count > 0)
            {
                rbPrevFEExperienceYes.Checked = true;
                if (!String.IsNullOrEmpty(dv.Table.Rows[0]["CountryName"].ToString()))
                    lblCountry.Text = dv.Table.Rows[0]["CountryName"].ToString();
                if (!String.IsNullOrEmpty(dv.Table.Rows[0]["JobOfferedTypeDesc"].ToString()))
                    lblJobType.Text = dv.Table.Rows[0]["JobOfferedTypeDesc"].ToString();
                if (!String.IsNullOrEmpty(dv.Table.Rows[0]["StayDuration"].ToString()))
                    lblStayDuration.Text = dv.Table.Rows[0]["StayDuration"].ToString();
            }
            else
            {
                rbPrevFEExperienceNo.Checked = true;
            }
            //lblVisitFrequency.Text = dv.Table.Rows[0]["VisitFrequencyID"].ToString();
            //gvPreviousFEExperience.DataSource = PreviousFEExperienceBO.GetCustom(SaMIProfileID);
            //gvPreviousFEExperience.DataBind();
        }
        

        void LoadSaMIProfile(int SaMIProfileID)
        {
            //SaMI Profiles
            SaMIProfiles objSaMIProfiles = SaMIProfileBO.GetSaMIProfile(SaMIProfileID);

            ethnicityID = EthnicityBO.GetEthnicity(objSaMIProfiles.EthnicityID).EthnicityID;

            lblEthnicity.Text = EthnicityBO.GetEthnicity(objSaMIProfiles.EthnicityID).EthnicityName;
            LoadValidRegions();

            lblSaMIProfileNumber.Text = objSaMIProfiles.SaMIProfileNumber;
            lblRegistrationDate.Text = objSaMIProfiles.RegistrationDate.ToShortDateString();
            lblDistrict.Text = DistrictBO.GetDistrict(objSaMIProfiles.DistrictID).DistrictName;
            if (objSaMIProfiles.Gender == "M")
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            lblFirstName.Text = objSaMIProfiles.FirstName;
            lblMiddleName.Text = objSaMIProfiles.MiddleName;
            lblLastName.Text = objSaMIProfiles.LastName;

            List<int> lstValidRegions = EthnicityBO.SelectValidRegions(ethnicityID, SaMIProfileID);


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

            lblAddress.Text = objSaMIProfiles.Address;
            lblAddressDistrict.Text = DistrictBO.GetDistrict(objSaMIProfiles.AddressDistrictID).DistrictName;
            lblVDC.Text = VDCBO.GetVDC(objSaMIProfiles.VDCID).VDCName;
            lblWard.Text = objSaMIProfiles.Ward;

            lblVisitorPhone.Text = objSaMIProfiles.VisitorPhone;
            lblFamilyMemberPhone.Text = objSaMIProfiles.FamilyMemberPhone;
            lblAgeGroup.Text = AgeGroupBO.GetAgeGroups(objSaMIProfiles.AgeGroupID).AgeGroupDesc;

            lblEducationalStatus.Text = EducationalStatusBO.GetEducationalStatus(objSaMIProfiles.EducationalStatusID).EducationalStatusDesc;
            lblMaritalStatus.Text = MaritalStatusBO.GetMaritalStatus(objSaMIProfiles.MaritalStatusID).MaritalStatusDesc;
            //lblOccupationType.Text = OccupationTypeBO.GetOccupationType(objSaMIProfiles.OccupationTypeID).OccupationTypeDesc;

            lblProfileICKnowledge.Text = ICKnowledgesBO.GetICKnowledges(objSaMIProfiles.ICKnowledgeID).ICKnowledgeDesc;
            if (objSaMIProfiles.FrequencyOfVisit == 1)
                lblFrequencyOfVisit.Text = "Once";
            else
                lblFrequencyOfVisit.Text = "More Than Once";
            if (objSaMIProfiles.ReasonForVisiting == 1)
                lblReasonOfVisit.Text = "General Information";
            else
                lblReasonOfVisit.Text = "Specific Inquiry";

            lblFamilyHeadName.Text = objSaMIProfiles.FamilyHeadName;
            lblFamilyHeadRelation.Text = objSaMIProfiles.FamilyHeadRelation;

           
        }

        void LoadValidRegions()
        {
            List<int> lstValidRegions = EthnicityBO.SelectValidRegionForEthnicity(ethnicityID);

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
            //if (lblEthnicity.Text == "Janajati Newar")
            //{
            //    rbValidRegions.Items[0].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[1].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[2].Attributes.Add("hidden", "hidden");
            //}
            //else if (lblEthnicity.Text == "Brahmin" || lblEthnicity.Text == "Chhetri" || lblEthnicity.Text == "Dalit")
            //{
            //    rbValidRegions.Items[0].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[3].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[4].Attributes.Add("hidden", "hidden");
            //}
            //else if (lblEthnicity.Text == "Janajati")
            //{
            //    rbValidRegions.Items[3].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[4].Attributes.Add("hidden", "hidden");
            //}
            //else if (lblEthnicity.Text == "Thakuri")
            //{
            //    rbValidRegions.Items[0].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[2].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[3].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[4].Attributes.Add("hidden", "hidden");
            //}
            //else if (lblEthnicity.Text == "Other")
            //{
            //    rbValidRegions.Items[0].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[1].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[2].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[3].Attributes.Add("hidden", "hidden");
            //    rbValidRegions.Items[4].Attributes.Add("hidden", "hidden");
            //}
        }
        
        void LoadForeignEmploymentStatus(int SaMIProfileID)
        {
            //Foreign Employment Status
            ForeignEmploymentStatus objForeignEmploymentStatus = ForeignEmploymentStatusBO.GetFEStatus(SaMIProfileID);

            if (objForeignEmploymentStatus.ForeignEmploymentStatusID > 0)
            {
                lblJobOfferSource.Enabled = true;
                lblJobOfferedType.Enabled = true;
                //lblWorkType.Enabled = true;
                lblPaymentRange.Enabled = true;
                lblPaymentRangeReceipt.Enabled = true;
                lblPaymentRangeAskedFor.Enabled = true;

                lblDecisionStatus.Text = DecisionStatusBO.GetDecisionStatus(objForeignEmploymentStatus.DecisionStatusID).DecisionStatusDesc;
                lblPassportStatus.Text = PassportStatusBO.GetPassportStatus(objForeignEmploymentStatus.PassportStatusID).PassportStatusDesc.ToString();

                if (objForeignEmploymentStatus.HaveJobOffer == 1)
                    rbJobOfferYes.Checked = true;
                else
                    rbJobOfferNo.Checked = true;

                if (objForeignEmploymentStatus.JobOfferSourceID > 0)
                    lblJobOfferSource.Text =  JobOfferSourcesBO.GetJobOfferSources((int)objForeignEmploymentStatus.JobOfferSourceID).JobOfferSourceDesc;
                else
                    lblJobOfferSource.Enabled = false;

                if (objForeignEmploymentStatus.JobOfferedTypeID > 0)
                    lblJobOfferedType.Text = JobOfferedTypesBO.GetJobOfferedTypes((int)objForeignEmploymentStatus.JobOfferedTypeID).JobOfferTypeDesc;
                else
                    lblJobOfferedType.Enabled = false;

                //if (objForeignEmploymentStatus.WorkTypeID > 0)
                //    lblWorkType.Text = WorkTypesBO.GetWorkTypes((int)objForeignEmploymentStatus.WorkTypeID).WorkTypeDesc;
                //else
                //    lblWorkType.Enabled = false;

                if (objForeignEmploymentStatus.MadePaymentAmount != string.Empty)
                {
                    lblPaymentRangeAskedFor.Enabled = false;
                    rbMadePaymentYes.Checked = true;
                    lblPaymentRange.Text = objForeignEmploymentStatus.MadePaymentAmount.ToString();

                    if (objForeignEmploymentStatus.HavePaymentReceipt == 1)
                    {
                        rblPaymentReceiptYes.Checked = true;
                        lblPaymentRangeReceipt.Text = objForeignEmploymentStatus.ReceiptPaymentAmount.ToString();
                    }
                    else
                    {
                        rblPaymentReceiptNo.Checked = true;
                        lblPaymentRangeReceipt.Enabled = false;
                    }
                }
                else
                {
                    lblPaymentRange.Enabled = false;
                    lblPaymentRangeReceipt.Enabled = false;
                    rbMadePaymentNo.Checked = true;

                    if (objForeignEmploymentStatus.NothingAskedYet == 1)
                    {
                        chkNothingYet.Checked = true;
                        lblPaymentRangeAskedFor.Enabled = false;
                    }
                    else
                        lblPaymentRangeAskedFor.Text = objForeignEmploymentStatus.AskedPaymentAmount.ToString();
                }

                //lblICKnowledge.Text = ICKnowledgesBO.GetICKnowledges(objForeignEmploymentStatus.ICKnowledgeID).ICKnowledgeDesc;

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

        

        //void LoadOtherInfo(int SaMIProfileID)
        //{
        //    OtherInfoPerSaMIProfile objOtherInfoPerSaMIProfile = OtherInfoPerSaMIProfileBO.GetOtherInfo(SaMIProfileID);
        //    PreviousFEExperiences objPreviousFEExperiences = PreviousFEExperienceBO.GetFEExperience(SaMIProfileID);

        //    if (objOtherInfoPerSaMIProfile.OtherInfoPerSaMIProfileID > 0)
        //    {

        //        if (objOtherInfoPerSaMIProfile.HaveExperienceORTraining == 1)
        //            rbHaveQualificationYes.Checked = true;
        //        else
        //            rbHaveQualificationNo.Checked = true;

        //        if (objOtherInfoPerSaMIProfile.HaveJobExperience == 1)
        //            rbHaveJobExperienceYes.Checked = true;
        //        else
        //            rbHaveJobExperienceNo.Checked = true;

        //        //Documents
        //        List<FEDocumentsPerSaMIProfile> lstFEDocumentsPerSaMIProfile = FEDocumentsPerSaMIProfileBO.GetAll(SaMIProfileID);
        //        for (int j = 0; j < cblFEDocuments.Items.Count; j++)
        //        {
        //            if (lstFEDocumentsPerSaMIProfile.Exists(delegate(FEDocumentsPerSaMIProfile objFEDocumentsPerSaMIProfile) { return objFEDocumentsPerSaMIProfile.DocumentTypeID == Convert.ToInt32(cblFEDocuments.Items[j].Value); }))
        //            {
        //                cblFEDocuments.Items[j].Selected = true;
        //            }

        //        }
        //    }

        //    gvPreviousFEExperience.DataSource = PreviousFEExperienceBO.GetCustom(SaMIProfileID);
        //    gvPreviousFEExperience.DataBind();

        //}
        

        //void LoadOtherMemberMigrations(int SaMIProfileID)
        //{
        //    gvOtherMembers.DataSource = OtherMemberMigrationBO.GetCustom(SaMIProfileID);
        //    gvOtherMembers.DataBind();
        //}

        

        //protected void gvOtherMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    ClearOtherMigrant();
        //    if (e.CommandName.Equals("cmdView"))
        //    {
        //        OtherMemberMigrations objOtherMemberMigrations = OtherMemberMigrationBO.GetOtherMemberMigration(Convert.ToInt32(e.CommandArgument));
        //        lblFamilyMember.Text = FamilyMembersBO.GetFamilyMembers(objOtherMemberMigrations.FamilyMemberID).FamilyMemberName;
        //        lblFamilyMemberCountry.Text = CountriesBO.GetCountry(objOtherMemberMigrations.CountryID).CountryName;

        //        if (objOtherMemberMigrations.VisitSameCountry == 1)
        //        {
        //            rbSameCountryYes.Checked = true;
        //        }
        //        else
        //            rbSameCountryNo.Checked = true;

        //        if (objOtherMemberMigrations.DoesSendMoney == 1)
        //        {
        //            rbSendMoneyYes.Checked = true;
        //            lblMoneyRange.Text = MoneyRangesBO.GetMoneyRanges((int)objOtherMemberMigrations.MoneyRangeID).MoneyRangeDesc;
        //            lblMoneyRange.Enabled = true;
        //        }
        //        else
        //        {
        //            rbSendMoneyNo.Checked = true;
        //            lblMoneyRange.Enabled = false;
        //        }

        //        List<DocumentsPerOtherMemberMigration> lstDocumentsPerOtherMemberMigration = DocumentsPerOtherMemberMigrationBO.GetAllByOtherMemberMigrationID(objOtherMemberMigrations.OtherMemberMigrationID);

        //        if (lstDocumentsPerOtherMemberMigration.Count > 0)
        //        {
        //            rbDocumentLeftYes.Checked = true;
        //            for (int j = 0; j < cblDocumentsBehind.Items.Count; j++)
        //            {
        //                if (lstDocumentsPerOtherMemberMigration.Exists(delegate(DocumentsPerOtherMemberMigration objDPOMM) { return objDPOMM.DocumentBehindID == Convert.ToInt32(cblDocumentsBehind.Items[j].Value); }))
        //                {
        //                    cblDocumentsBehind.Items[j].Selected = true;
        //                }

        //            }
        //        }
        //        else
        //            rbDocumentLeftNo.Checked = true;

        //        List<ProblemsPerOtherMemberMigration> lstProblemsPerOtherMemberMigration = ProblemsPerOtherMemberMigrationBO.GetAllByOtherMemberMigrationID(objOtherMemberMigrations.OtherMemberMigrationID);

        //        if (lstProblemsPerOtherMemberMigration.Count > 0)
        //        {
        //            rbProblemFacedYes.Checked = true;
        //            for (int j = 0; j < cblProblemType.Items.Count; j++)
        //            {
        //                if (lstProblemsPerOtherMemberMigration.Exists(delegate(ProblemsPerOtherMemberMigration objPPOMM) { return objPPOMM.ProblemTypeID == Convert.ToInt32(cblProblemType.Items[j].Value); }))
        //                {
        //                    cblProblemType.Items[j].Selected = true;
        //                }

        //            }
        //        }
        //        else
        //            rbProblemFacedNo.Checked = true;

        //    }
            
        //}
       
        

        void LoadServicesProvided(int SaMIProfileID)
        {
            ServicesProvidedPerSaMI objServicesProvidedPerSaMI = ServicesProvidedPerSaMIBO.GetServicesProvidedPerSaMI(SaMIProfileID);

            if (objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID > 0)
            {
                LoadOtherFollowupPerService(objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID);
                
                lblVisitTimes.Text = objServicesProvidedPerSaMI.VisitTimes;
                lblServiceProvided.Text = ServicesProvidedBO.GetServicesProvided(objServicesProvidedPerSaMI.ServiceProvidedID).ServiceProvidedDesc;


                FollowUpPerServices objFollowUpPerServices = FollowUpPerServicesBO.GetFollowUpPerService(objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID);
                if (objFollowUpPerServices.ICFollowUpRequired == 1)
                {
                    lblFollowUp.Enabled = true;
                    rdYes.Checked = true;
                    lblFollowUp.Text = objFollowUpPerServices.FollowUpID;
                }
                else
                    rbNo.Checked = true;

                List<int> lstICRecommendation = ICRecommendationsBO.SelectICRecommendations(SaMIProfileID);


                if (lstICRecommendation.Count > 0)
                {
                    for (int j = 0; j < cblICRecommendation.Items.Count; j++)
                    {
                        if (lstICRecommendation.Exists(delegate(int ICRecommendation) { return ICRecommendation == Convert.ToInt32(cblICRecommendation.Items[j].Value); }))
                        {
                            cblICRecommendation.Items[j].Selected = true;
                        }

                    }
                }

                if (objFollowUpPerServices.CounselorDifficultyID > 0)
                {
                    lblCounselorsDifficuties.Enabled = true;
                    rbCounselorDifficultyYes.Checked = true;
                    lblCounselorsDifficuties.Text = CounselorDifficultiesBO.GetCounselorDifficulties(objFollowUpPerServices.CounselorDifficultyID).CounselorDifficultyDesc;
                }
                else
                    rbCounselorDifficultyNo.Checked = true;


                List<AdditionalFollowUpInfoPerServices> lstAdditionalFollowUpInfoPerServices = AdditionalFollowUpInfoPerServiceBO.GetAllByServiceProvidedPerSaMIID(objServicesProvidedPerSaMI.ServiceProvidedPerSaMIID);

                if (lstAdditionalFollowUpInfoPerServices.Count > 0)
                    rbAdditionalInfoYes.Checked = true;
                else
                    rbAdditionalInfoNo.Checked = false;

                for (int j = 0; j < cblAdditionalDocument.Items.Count; j++)
                {
                    if (lstAdditionalFollowUpInfoPerServices.Exists(delegate(AdditionalFollowUpInfoPerServices objAdditionalFollowUpInfoPerServices) { return objAdditionalFollowUpInfoPerServices.AdditionalFollowupInfoID == Convert.ToInt32(cblAdditionalDocument.Items[j].Value); }))
                    {
                        cblAdditionalDocument.Items[j].Selected = true;
                    }

                }
            }

        }

        void LoadOtherFollowupPerService(int ServiceProvidedPerSaMIID)
        {
            gvOtherFollowUp.DataSource = OtherFollowupPerServiceBO.GetCustom(ServiceProvidedPerSaMIID);
            gvOtherFollowUp.DataBind();
        }


        protected void gvOtherFollowUp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClearOtherFollowUp();

            if (e.CommandName.Equals("cmdView"))
            {
                OtherFollowupPerService objOtherFollowupPerService = OtherFollowupPerServiceBO.GetOtherFollowUpInfoPerService(Convert.ToInt32(e.CommandArgument));
                lblFollowUpDate.Text = objOtherFollowupPerService.FollowUpDate.ToShortDateString();
                if (objOtherFollowupPerService.NonFollowUpReasonID > 0)
                {
                    lblNonFollowup.Text = NonFollowUpReasonsBO.GetNonFollowUpReasons((int)objOtherFollowupPerService.NonFollowUpReasonID).NonFollowUpReasonDesc;

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

                lblDidNoComplyReason.Text = objOtherFollowupPerService.Remarks;
            }
            
        }

        
        void LoadCasesAndFollowUp(int SaMIProfileID)
        {
            gvCases.DataSource = CaseBO.GetCustom(SaMIProfileID);
            gvCases.DataBind();

            gvCaseFollowUp.DataSource = CaseFollowUpBO.GetCustom(SaMIProfileID);
            gvCaseFollowUp.DataBind();

            
        }

        void LoadCaseDocumentation(int SaMIProfileID)
        {
            CaseDocumentations objCaseDocumentations = CaseDocumentationsBO.GetCaseDocumentation(SaMIProfileID);
            if (objCaseDocumentations.CaseDocumentationID > 0)
            {

                if (objCaseDocumentations.ReferralToID > 0)
                {
                    lblRefferToYes.Enabled = true;
                    rbRefferToYes.Checked = true;
                    lblRefferToYes.Text = StakeholderBO.GetStakeHolders(objCaseDocumentations.ReferralToID).StakeHolderName;
                }
                else
                {
                    lblRefferToNo.Enabled = true;
                    rbRefferToNo.Checked = true;
                    lblRefferToNo.Text = NonReferralReasonsBO.GetNonReferralReasons((int)objCaseDocumentations.NonReferredReasonID).NonReferralReasonDesc;

                }
                lblDateofRefferal.Text = objCaseDocumentations.DateOfReferral.ToShortDateString();
                lblRefferalStatus.Text = ReferralStatusBO.GetReferralStatus(objCaseDocumentations.ReferralStatusID).ReferralStatusDesc;

                if (objCaseDocumentations.IsDifficultyFaced == 1)
                {
                    rblDifficultyFaceYes.Checked = true;
                    lblDifficultyFaceReason.Text = objCaseDocumentations.DifficultyFacedRemarks;
                }
                else
                    tblDifficultyFaceNo.Checked = true;

            }

        }


        protected void gvCases_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClearCase();

            if (e.CommandName.Equals("cmdView"))
            {
                Cases objCases = CaseBO.GetCases(Convert.ToInt32(e.CommandArgument));
                lblTypeOfCase.Text = CaseTypesBO.GetCaseType(objCases.CaseTypeID).CaseTypeDesc;
                lblCaseNumber.Text = objCases.CaseNumber;
                lblNameOfOpponent.Text = objCases.NameOfOpponent;
                lblCaseDesc.Text = objCases.Description;
                lblCaseRegisteredDate.Text = objCases.CaseRegisteredDate.ToShortDateString();
                if(objCases.PartnerID > 0)
                    lblStackeHolder.Text = StakeholderBO.GetStakeHolders(objCases.PartnerID).StakeHolderName.ToString();
                if(objCases.CaseRegistrarID > 0)
                    lblCaseRegistrar.Text = CaseRegistrarBO.GetCaseRegistrar(objCases.CaseRegistrarID).CaseRegistrarName;
                lblResponsibleStaff.Text = objCases.ResponsibleStaff;
                lblCaseStatusType.Text = CaseStatusTypeBO.GetCaseStatusType(objCases.CaseStatusTypeID).CaseStatusTypeDesc;

                if (objCases.CompensationAmount > 0)
                {
                    rbCompensationYes.Checked = true;
                    lblCompensationAmount.Text = objCases.CompensationAmount.ToString();
                }
                else
                    rbCompensationNo.Checked = true;

                lblOutputDetails.Text = objCases.OutputDetails;

                List<EvidencesPerCase> lstEvidencesPerCase = EvidencesPerCaseBO.GetAllByCaseID(objCases.CaseID);

                if (lstEvidencesPerCase.Count > 0)
                {
                    for (int j = 0; j < cblEvidenceTypes.Items.Count; j++)
                    {
                        if (lstEvidencesPerCase.Exists(delegate(EvidencesPerCase objEPC) { return objEPC.EvidenceTypeID == Convert.ToInt32(cblEvidenceTypes.Items[j].Value); }))
                        {
                            cblEvidenceTypes.Items[j].Selected = true;
                        }

                    }
                }
            }
        }

        protected void gvCaseFollowUp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClearCaseFollowUp();

            if (e.CommandName.Equals("cmdView"))
            {
                CaseFollowUp objCaseFollowUp = CaseFollowUpBO.GetCaseFollowUp(Convert.ToInt32(e.CommandArgument));
                lblCaseFollowUpDate.Text = objCaseFollowUp.FollowUpDate.ToShortDateString();
                lblFollowupCaseType.Text = CaseTypesBO.GetByCaseID(objCaseFollowUp.CaseID);                
                lblCaseFollowUpDesc.Text = objCaseFollowUp.Description;

            }
        }
       

        void LoadEmploymentSkill(int SaMIProfileID)
        {
            EmploymentSkills objEmploymentSkills = EmploymentSkillBO.GetEmploymentSkill(SaMIProfileID);

            if (objEmploymentSkills.EmploymentSkillID > 0)
            {
                if (objEmploymentSkills.IsUnemployed == 0)
                {
                    chkUnEmployment.Checked = false;
                    if (objEmploymentSkills.SelfEmploymentIncome > 0) lblSelfEmploymentIncome.Text = objEmploymentSkills.SelfEmploymentIncome.ToString();
                    if (objEmploymentSkills.AgricultureIncome > 0) lblAgricultureIncome.Text = objEmploymentSkills.AgricultureIncome.ToString();
                    if (objEmploymentSkills.WageIncome > 0) lblWageIncome.Text = objEmploymentSkills.WageIncome.ToString();
                    if (objEmploymentSkills.OtherIncome > 0) lblOtherIncome.Text = objEmploymentSkills.OtherIncome.ToString();
                }
                else
                {
                    chkUnEmployment.Checked = true;
                    lblSelfEmploymentIncome.Enabled = false;
                    lblAgricultureIncome.Enabled = false;
                    lblWageIncome.Enabled = false;
                    lblOtherIncome.Enabled = false;
                }

                if (objEmploymentSkills.FamilyWageIncome > 0) lblFamilyWageIncome.Text = objEmploymentSkills.FamilyWageIncome.ToString();
                if (objEmploymentSkills.FamilyAgricultureIncome > 0) lblFamilyAgricultureIncome.Text = objEmploymentSkills.FamilyAgricultureIncome.ToString();
                if (objEmploymentSkills.FamilySalaryIncome > 0) lblFamilySalaryIncome.Text = objEmploymentSkills.FamilySalaryIncome.ToString();
                if (objEmploymentSkills.FamilyForeignIncome > 0) lblFamilyForeignIncome.Text = objEmploymentSkills.FamilyForeignIncome.ToString();
                if (objEmploymentSkills.FamilyBusinessIncome > 0) lblFamilyBusinessIncome.Text = objEmploymentSkills.FamilyBusinessIncome.ToString();
                if (objEmploymentSkills.FamilyOtherIncome > 0) lblFamilyOtherIncome.Text = objEmploymentSkills.FamilyOtherIncome.ToString();

                lblFeedDurationTypeID.Text = FeedDurationTypeBO.GetFeedDurationType(objEmploymentSkills.FeedDurationTypeID).FeedDurationTypeDesc;
                lblTrainingSubject.Text = objEmploymentSkills.TrainingSubject;
                lblTrainingDistrict.Text = DistrictBO.GetDistrict(objEmploymentSkills.TrainingDistrictID).DistrictName;
                lblTrainingVDC.Text = VDCBO.GetVDC(objEmploymentSkills.TrainingVDCID).VDCName;
                lblTrainingWardNumber.Text = objEmploymentSkills.TrainingWardNumber;
                lblTrainingStartDate.Text = objEmploymentSkills.TrainingStratDate.ToShortDateString();
                lblTrainingReasonType.Text = objEmploymentSkills.TrainingReasonTypeID.ToString();
                lblKnowAboutTraining.Text = objEmploymentSkills.KnowAboutTrainingID.ToString();


                if (objEmploymentSkills.HavePreviousTraining == 1)
                {
                    rbHavePreviousTrainingYes.Checked = true;
                    lblPreTrainingName.Enabled = true;
                    lblPreTrainingYear.Enabled = true;
                    lblPreTrainingPeriod.Enabled = true;
                    lblPreTrainingInstituteName.Enabled = true;
                    lblPreTrainingName.Text = objEmploymentSkills.PreTrainingName;
                    lblPreTrainingYear.Text = objEmploymentSkills.PreTrainingYear;
                    lblPreTrainingPeriod.Text = objEmploymentSkills.PreTrainingPeriod;
                    lblPreTrainingInstituteName.Text = objEmploymentSkills.PreTrainingInstituteName;
                }
                else
                    rbHavePreviousTrainingNo.Checked = true;
            }

        }

        void LoadEmployment(int SaMIProfileID)
        {
            gvEmployment.DataSource = EmploymentBO.GetCustom(SaMIProfileID);
            gvEmployment.DataBind();
        }

        protected void gvEmployment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdView"))
            {
                Employments objEmployments = EmploymentBO.GetEmployment(Convert.ToInt32(e.CommandArgument));
                lblEmploymentCompanyName.Text = objEmployments.CompanyName;
                lblEmploymentCountry.Text = CountriesBO.GetCountry(objEmployments.CountryID).CountryName;
                lblEmploymentStartDate.Text = objEmployments.EmploymentStartDate.ToShortDateString();
                lblEmploymentWorkType.Text = WorkTypesBO.GetWorkTypes(objEmployments.WorkTypeID).WorkTypeDesc;
                lblEmploymentIncomeRange.Text = PaymentRangesBO.GetPaymentRanges(objEmployments.IncomeRangeID).PaymentRangeDesc;
            }
        }

        #region Clear Fields

        void ClearOtherMigrant()
        {
            
            lblFamilyMember.Text = string.Empty;
            lblFamilyMemberCountry.Text = string.Empty;
            rbSameCountryYes.Checked = false;
            rbSameCountryNo.Checked = false;
            rbSendMoneyNo.Checked = false;
            rbSendMoneyYes.Checked = false;
            lblMoneyRange.Text = string.Empty;
            lblMoneyRange.Enabled = false;
            rbDocumentLeftYes.Checked = false;
            rbDocumentLeftNo.Checked = false;
            cblDocumentsBehind.ClearSelection();
            rbProblemFacedYes.Checked = false;
            rbProblemFacedNo.Checked = false;
            cblProblemType.ClearSelection();
        }

       
        void ClearOtherFollowUp()
        {
            hfOtherFollowUpPerServiceID.Value = string.Empty;
            lblFollowUpDate.Text = string.Empty;
            lblNonFollowup.Text = string.Empty;
            rbComplied.Checked = false;
            rbCompliedPartly.Checked = false;
            rbDidNotComply.Checked = false;
            rbReasonForNonCompliance.Checked = false;
            rbReasonRecommendation.Checked = false;
            rbWasTooDifficult.Checked = false;
            rbReasonReceipt.Checked = false;
            rbOther.Checked = false;
            rbReasonFamilyMember.Checked = false;
        }

        void ClearCase()
        {
            hfCaseID.Value = string.Empty;
            lblTypeOfCase.Text = string.Empty;
            lblCaseNumber.Text = string.Empty;
            lblNameOfOpponent.Text = string.Empty;
            lblCaseDesc.Text = string.Empty;
            lblCaseRegisteredDate.Text = string.Empty;
            lblStackeHolder.Text = string.Empty;
            lblCaseRegistrar.Text = string.Empty;
            lblResponsibleStaff.Text = string.Empty;
            lblCaseStatusType.Text = string.Empty;
            pnlCaseOutput.Visible = false;
            rbCompensationYes.Checked = false;
            rbCompensationNo.Checked = false;
            lblCompensationAmount.Text = string.Empty;
            lblOutputDetails.Text = string.Empty;
            cblEvidenceTypes.ClearSelection();
        }

        void ClearCaseFollowUp()
        {
            hfCaseFollowUpID.Value = string.Empty;
            lblFollowupCaseType.Text = string.Empty;
            lblCaseFollowUpDate.Text = string.Empty;
            lblCaseFollowUpDesc.Text = string.Empty;

        }

        #endregion

        protected String SetPermission()
        {

            string strPermitted = string.Empty;

            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                pnlCaseReferral.Visible = false;

                strPermitted = "<li class=\"active\"><a href=\"#general\" data-toggle=\"tab\">General Information</a></li> ";
            }
            else
            {
                strPermitted = "<li class=\"active\"><a href=\"#general\" onclick=\"ShowHideButton('general');return false;\" data-toggle=\"tab\">General Information</a></li> " +
                    "<li><a href=\"#foreign\" data-toggle=\"tab\">Foreign Employment</a></li> " +
                    "<li><a href=\"#servicesandfollowup\" data-toggle=\"tab\">Followup</a></li> " +
                    "<li><a href=\"#phonefollowup\" data-toggle=\"tab\">Phone Follow Up</a></li>";
            }
            return strPermitted;
        }

       
    }
}