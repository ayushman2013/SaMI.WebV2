using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using SaMI.DTO;
using SaMI.Business;

namespace SaMI.Web.CaseDocumentation
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {
                if (!Page.IsPostBack)
                {
                    LoadCaseProfileOption();
                    int CaseProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));
                    hfCaseProfileID.Value = Request.QueryString.Get("ID").ToString();
                    LoadCaseProfileDetail();

                    LoadCaseOptions();
                    LoadCasesAndFollowUp(CaseProfileID);
                    LoadCaseReferralHistory(CaseProfileID);
                }
            }
            else
                Response.Redirect("~/Login.aspx");
        }


        #region Case Documentation
        void LoadCaseOptions()
        {
            DataView objDataView = CaseTypesBO.GetAll(true);
            ddlTypeOfCase.DataSource = objDataView;
            ddlTypeOfCase.DataValueField = "CaseTypeID";
            ddlTypeOfCase.DataTextField = "CaseTypeDesc";
            ddlTypeOfCase.DataBind();
            ddlTypeOfCase.SelectedIndex = 1;

            ddlFollowupCaseType.DataSource = CaseTypesBO.GetAllInCases(Convert.ToInt32(hfCaseProfileID.Value), true);
            ddlFollowupCaseType.DataValueField = "CaseID";
            ddlFollowupCaseType.DataTextField = "CaseTypeDesc";
            ddlFollowupCaseType.DataBind();



            ddlStackeHolder.DataSource = StakeholderBO.GetAll(true);
            ddlStackeHolder.DataValueField = "StakeHolderID";
            ddlStackeHolder.DataTextField = "StakeHolderName";
            ddlStackeHolder.DataBind();
            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                ddlStackeHolder.SelectedValue = UserAuthentication.GetPartnerId(this.Page).ToString();
                ddlStackeHolder.Enabled = false;
            }

            ddlCaseRegistrar.DataSource = CaseRegistrarBO.GetAll(true);
            ddlCaseRegistrar.DataValueField = "CaseRegistrarID";
            ddlCaseRegistrar.DataTextField = "CaseRegistrarName";
            ddlCaseRegistrar.DataBind();

            ddlCaseStatusType.DataSource = CaseStatusTypeBO.GetAll(true);
            ddlCaseStatusType.DataValueField = "CaseStatusTypeID";
            ddlCaseStatusType.DataTextField = "CaseStatusTypeDesc";
            ddlCaseStatusType.DataBind();

            cblEvidenceTypes.DataSource = EvidenceTypeBO.GetAll();
            cblEvidenceTypes.DataValueField = "EvidenceTypeID";
            cblEvidenceTypes.DataTextField = "EvidenceTypeDesc";
            cblEvidenceTypes.DataBind();


            ddlPerviousPartner.DataSource = StakeholderBO.GetAll(true);
            ddlPerviousPartner.DataValueField = "StakeHolderID";
            ddlPerviousPartner.DataTextField = "StakeHolderName";
            ddlPerviousPartner.DataBind();

            ddlNewPartner.DataSource = StakeholderBO.GetAll(true);
            ddlNewPartner.DataValueField = "StakeHolderID";
            ddlNewPartner.DataTextField = "StakeHolderName";
            ddlNewPartner.DataBind();

            ddlReferralCaseType.DataSource = CaseTypesBO.GetAllInCases(Convert.ToInt32(hfCaseProfileID.Value), true);
            ddlReferralCaseType.DataValueField = "CaseID";
            ddlReferralCaseType.DataTextField = "CaseTypeDesc";
            ddlReferralCaseType.DataBind();
        }

       
        void LoadCasesAndFollowUp(int CaseProfileID)
        {
            gvCases.DataSource = CaseBO.GetCustom(CaseProfileID);
            gvCases.DataBind();

            gvCaseFollowUp.DataSource = CaseFollowUpBO.GetCustom(CaseProfileID);
            gvCaseFollowUp.DataBind();

            ddlFollowupCaseType.DataSource = CaseTypesBO.GetAllInCases(Convert.ToInt32(hfCaseProfileID.Value), true);
            ddlFollowupCaseType.DataValueField = "CaseID";
            ddlFollowupCaseType.DataTextField = "CaseTypeDesc";
            ddlFollowupCaseType.DataBind();

            ddlReferralCaseType.DataSource = CaseTypesBO.GetAllInCases(Convert.ToInt32(hfCaseProfileID.Value), true);
            ddlReferralCaseType.DataValueField = "CaseID";
            ddlReferralCaseType.DataTextField = "CaseTypeDesc";
            ddlReferralCaseType.DataBind();

        }

        protected void btnAddOtherCase_Click(object sender, EventArgs e)
        {
            Cases objCases = new Cases();
            objCases.CaseProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));
            objCases.CaseTypeID = Convert.ToInt32(ddlTypeOfCase.SelectedValue);
            objCases.Description = txtCaseDesc.Text;
            objCases.CaseNumber = txtCaseNumber.Text.Trim();
            objCases.NameOfOpponent = txtNameOfOpponent.Text.Trim();
            objCases.CaseRegistrarID = Convert.ToInt32(ddlCaseRegistrar.SelectedValue);
            objCases.ResponsibleStaff = txtResponsibleStaff.Text.Trim();
            objCases.CaseRegisteredDate = Convert.ToDateTime(txtCaseRegisteredDate.Text);
            objCases.CaseStatusTypeID = Convert.ToInt32(ddlCaseStatusType.SelectedValue);
            objCases.PartnerID = Convert.ToInt32(ddlStackeHolder.SelectedValue);

            List<EvidencesPerCase> lstEvidencesPerCase = new List<EvidencesPerCase>();
            if (cblEvidenceTypes.Items.Count > 0)
            {
                for (int j = 0; j < cblEvidenceTypes.Items.Count; j++)
                {
                    if (cblEvidenceTypes.Items[j].Selected == true)
                    {
                        EvidencesPerCase objEvidencesPerCase = new EvidencesPerCase();
                        objEvidencesPerCase.EvidenceTypeID = Convert.ToInt32(cblEvidenceTypes.Items[j].Value);
                        lstEvidencesPerCase.Add(objEvidencesPerCase);
                    }
                }
            }

            if (!string.IsNullOrEmpty(hfCaseID.Value))
            {
                if (rbCompensationYes.Checked)
                {
                    objCases.CompensationAmount = Convert.ToInt32(txtCompensationAmount.Text.Trim());
                }
                else
                    objCases.CompensationAmount = 0;

                objCases.OutputDetails = txtOutputDetails.Text;

                objCases.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objCases.UpdatedDate = DateTime.Now;
                objCases.CaseID = Convert.ToInt32(hfCaseID.Value);
                CaseBO.UpdateCase(objCases, lstEvidencesPerCase);
            }
            else
            {
                objCases.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objCases.CreatedDate = DateTime.Now;
                CaseBO.InsertCase(objCases, lstEvidencesPerCase);
            }

            ClearCase();
            LoadCasesAndFollowUp(Convert.ToInt32(hfCaseProfileID.Value));


        }

             

        protected void gvCases_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName.Equals("cmdEdit"))
            {
                ClearCase();
                hfCaseID.Value = e.CommandArgument.ToString();
                pnlCaseOutput.Visible = true;
                Cases objCases = CaseBO.GetCases(Convert.ToInt32(e.CommandArgument.ToString()));
                ddlTypeOfCase.SelectedValue = objCases.CaseTypeID.ToString();
                txtCaseNumber.Text = objCases.CaseNumber;
                txtNameOfOpponent.Text = objCases.NameOfOpponent;
                txtCaseDesc.Text = objCases.Description;
                txtCaseRegisteredDate.Text = objCases.CaseRegisteredDate.ToShortDateString();
                ddlCaseRegistrar.SelectedValue = objCases.CaseRegistrarID.ToString();
                txtResponsibleStaff.Text = objCases.ResponsibleStaff;
                ddlCaseStatusType.SelectedValue = objCases.CaseStatusTypeID.ToString();
                ddlStackeHolder.SelectedValue = objCases.PartnerID.ToString();

                if (objCases.CompensationAmount > 0)
                {
                    rbCompensationYes.Checked = true;
                    txtCompensationAmount.Text = objCases.CompensationAmount.ToString();
                }

                txtOutputDetails.Text = objCases.OutputDetails;

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
            else if (e.CommandName.Equals("cmdDelete"))
            {
                hfCaseID.Value = e.CommandArgument.ToString();
                CaseBO.DeleteCase(Convert.ToInt32(hfCaseID.Value));
                hfCaseID.Value = string.Empty;
                LoadCasesAndFollowUp(Convert.ToInt32(hfCaseProfileID.Value));
                ClearCase();
            }
        }

        #endregion

        #region Case Followup

        protected void btnAddCaseFollowUp_Click(object sender, EventArgs e)
        {
            CaseFollowUp objCaseFollowUp = new CaseFollowUp();
            objCaseFollowUp.SaMIProfileID = 0;
            objCaseFollowUp.CaseID = Convert.ToInt32(ddlFollowupCaseType.SelectedValue);
            objCaseFollowUp.Description = txtCaseFollowUpDesc.Text.Trim();
            objCaseFollowUp.FollowUpDate = Convert.ToDateTime(txtCaseFollowUpDate.Text);

            if (!string.IsNullOrEmpty(hfCaseFollowUpID.Value))
            {
                objCaseFollowUp.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objCaseFollowUp.UpdatedDate = DateTime.Now;
                objCaseFollowUp.CaseFollowUpID = Convert.ToInt32(hfCaseFollowUpID.Value);
                CaseFollowUpBO.UpdateCaseFollowUp(objCaseFollowUp);
            }
            else
            {
                objCaseFollowUp.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objCaseFollowUp.CreatedDate = DateTime.Now;
                CaseFollowUpBO.InsertCaseFollowUp(objCaseFollowUp);
            }
            ClearCaseFollowUp();
            LoadCasesAndFollowUp(Convert.ToInt32(hfCaseProfileID.Value));
        }


        protected void gvCaseFollowUp_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName.Equals("cmdEdit"))
            {
                ClearCaseFollowUp();
                hfCaseFollowUpID.Value = e.CommandArgument.ToString();
                CaseFollowUp objCaseFollowUp = CaseFollowUpBO.GetCaseFollowUp(Convert.ToInt32(e.CommandArgument.ToString()));
                txtCaseFollowUpDate.Text = objCaseFollowUp.FollowUpDate.ToShortDateString();
                ddlFollowupCaseType.SelectedValue = objCaseFollowUp.CaseID.ToString();
                txtCaseFollowUpDesc.Text = objCaseFollowUp.Description;

            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                hfCaseFollowUpID.Value = e.CommandArgument.ToString();
                CaseFollowUpBO.DeleteCaseFollowUp(Convert.ToInt32(hfCaseFollowUpID.Value));
                hfCaseFollowUpID.Value = string.Empty;
                LoadCasesAndFollowUp(Convert.ToInt32(hfCaseProfileID.Value));
            }
        }

        #endregion

        #region Case Referral History
        protected void btnSaveCaseReferral_Click(object sender, EventArgs e)
        {
            CaseReferralHistory objCaseReferralHistory = new CaseReferralHistory();
            objCaseReferralHistory.CaseID = Convert.ToInt32(ddlReferralCaseType.SelectedValue);
            objCaseReferralHistory.ReferralDate = Convert.ToDateTime(txtReferralDate.Text);
            objCaseReferralHistory.PreviousPartnerID = Convert.ToInt32(ddlPerviousPartner.SelectedValue);
            objCaseReferralHistory.NewPartnerID = Convert.ToInt32(ddlNewPartner.SelectedValue);
            objCaseReferralHistory.Remarks = txtReferralRemarks.Text;

            if (!string.IsNullOrEmpty(hfCaseReferralHistoryID.Value))
            {
                objCaseReferralHistory.CaseReferralHistoryID = Convert.ToInt32(hfCaseReferralHistoryID.Value);
                objCaseReferralHistory.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                CaseReferralHistoryBO.UpdateCaseFollowUp(objCaseReferralHistory);
            }
            else
            {
                objCaseReferralHistory.CreatedBy = UserAuthentication.GetUserId(this.Page);
                CaseReferralHistoryBO.InsertCaseReferralHistory(objCaseReferralHistory);
            }

            ClearCaseReferral();
            LoadCaseReferralHistory(Convert.ToInt32(hfCaseProfileID.Value));
        }

        void LoadCaseReferralHistory(int CaseProfileID)
        {
            gvCaseReferralHistory.DataSource = CaseReferralHistoryBO.GetCustom(CaseProfileID);
            gvCaseReferralHistory.DataBind();
        }

        protected void gvCaseReferralHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdEdit"))
            {
                ClearCaseReferral();
                hfCaseReferralHistoryID.Value = e.CommandArgument.ToString();
                CaseReferralHistory objCaseReferralHistory = CaseReferralHistoryBO.GetCaseReferralHistory(Convert.ToInt32(e.CommandArgument.ToString()));
                txtReferralDate.Text = objCaseReferralHistory.ReferralDate.ToShortDateString();
                ddlReferralCaseType.SelectedValue = objCaseReferralHistory.CaseID.ToString();
                ddlPerviousPartner.SelectedValue = objCaseReferralHistory.PreviousPartnerID.ToString();
                ddlNewPartner.SelectedValue = objCaseReferralHistory.NewPartnerID.ToString();
                txtReferralRemarks.Text = objCaseReferralHistory.Remarks;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                hfCaseReferralHistoryID.Value = e.CommandArgument.ToString();
                CaseReferralHistoryBO.DeleteCaseReferralHistory(Convert.ToInt32(hfCaseReferralHistoryID.Value), UserAuthentication.GetUserId(this.Page));
                hfCaseReferralHistoryID.Value = string.Empty;
                LoadCaseReferralHistory(Convert.ToInt32(hfCaseProfileID.Value));
            }
        }

        protected void ddlReferralCaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlReferralCaseType.SelectedValue))
            {
                int partnerID = CaseBO.GetCases(Convert.ToInt32(ddlReferralCaseType.SelectedValue)).PartnerID;
                ddlPerviousPartner.SelectedValue = partnerID.ToString();
            }
        }
        #endregion



        void ClearCase()
        {
            hfCaseID.Value = string.Empty;
            ddlTypeOfCase.SelectedIndex = 0;
            txtCaseNumber.Text = string.Empty;
            txtNameOfOpponent.Text = string.Empty;
            txtCaseDesc.Text = string.Empty;
            txtCaseRegisteredDate.Text = string.Empty;
            ddlStackeHolder.SelectedIndex = 0;
            ddlCaseRegistrar.SelectedIndex = 0;
            txtResponsibleStaff.Text = string.Empty;
            ddlCaseStatusType.SelectedIndex = 1;
            pnlCaseOutput.Visible = false;
            rbCompensationYes.Checked = false;
            rbCompensationNo.Checked = false;
            txtCompensationAmount.Text = string.Empty;
            txtOutputDetails.Text = string.Empty;
            cblEvidenceTypes.ClearSelection();
        }

        void ClearCaseFollowUp()
        {
            hfCaseFollowUpID.Value = string.Empty;
            ddlFollowupCaseType.SelectedIndex = 0;
            txtCaseFollowUpDate.Text = string.Empty;
            txtCaseFollowUpDesc.Text = string.Empty;

        }

        void ClearCaseReferral()
        {
            //ddlPerviousPartner.Enabled = false;
            txtReferralDate.Text = string.Empty;
            ddlReferralCaseType.SelectedIndex = 0;
            ddlPerviousPartner.SelectedIndex = 0;
            ddlNewPartner.SelectedIndex = 0;
            txtReferralRemarks.Text = string.Empty;
            hfCaseReferralHistoryID.Value = string.Empty;
        }


        void LoadCaseProfileOption()
        {
            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();
        }

        void LoadCaseProfileDetail()
        {
            CaseProfiles objCaseProfiles = CaseBO.GetCaseProfile(Convert.ToInt32(Request.QueryString.Get("ID")));
            ddlVDC.DataSource = VDCBO.GetAllByDistrictID(objCaseProfiles.DistrictID, true);
            ddlVDC.DataValueField = "VDCID";
            ddlVDC.DataTextField = "VDCName";
            ddlVDC.DataBind();

            txtFirstName.Text = objCaseProfiles.FirstName;
            txtMiddleName.Text = objCaseProfiles.MiddleName;
            txtLastName.Text = objCaseProfiles.LastName;
            ddlDistrict.SelectedValue = objCaseProfiles.DistrictID.ToString();
            ddlVDC.SelectedValue = objCaseProfiles.VDCID.ToString();
        }

        protected void btnSaveCaseProfile_Click(object sender, EventArgs e)
        {
            CaseBO.UpdateCaseProfile(MapCaseProfilesDTO());
        }

        protected CaseProfiles MapCaseProfilesDTO()
        {
            CaseProfiles objCaseProfiles = new CaseProfiles();
            objCaseProfiles.CaseProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));
            objCaseProfiles.FirstName = txtFirstName.Text;
            objCaseProfiles.MiddleName = txtMiddleName.Text;
            objCaseProfiles.LastName = txtLastName.Text;
            objCaseProfiles.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            objCaseProfiles.VDCID = Convert.ToInt32(ddlVDC.SelectedValue);
            objCaseProfiles.UpdatedBy = UserAuthentication.GetUserId(this.Page);
            return objCaseProfiles;
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
            {
                if (Convert.ToInt32(ddlDistrict.SelectedValue) > 0)
                {
                    int districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
                    ddlVDC.DataSource = VDCBO.GetAllByDistrictID(districtID, true);
                    ddlVDC.DataValueField = "VDCID";
                    ddlVDC.DataTextField = "VDCName";
                    ddlVDC.DataBind();
                }
            }

        }
    }
}