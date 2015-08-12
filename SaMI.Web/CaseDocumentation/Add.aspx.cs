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
    public partial class Add : System.Web.UI.Page
    {
        public int SamiProfileID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["ICCID"]))
            {
                SamiProfileID = Convert.ToInt32(Request.QueryString["ICCID"]);
            }
           
            if (UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {

                if (!Page.IsPostBack)
                {
                    LoadOptions();
                    LoadReferredProfile(SamiProfileID);
                }
            }
            else
                Response.Redirect("~/Login.aspx");

            if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {
                ddlStackeHolder.Enabled = true;
            }
        }

        private void LoadReferredProfile(int SamiProfileID)
        {
            if (SamiProfileID > 0)
            {
                DataView dvReferredProfile = CaseReferredBO.GetReferredProfile(SamiProfileID);

                txtFirstName.Text = dvReferredProfile.Table.Rows[0]["FirstName"].ToString();
                txtMiddleName.Text = dvReferredProfile.Table.Rows[0]["MiddleName"].ToString();
                txtLastName.Text = dvReferredProfile.Table.Rows[0]["LastName"].ToString();
                ddlDistrict.SelectedValue = dvReferredProfile.Table.Rows[0]["DistrictID"].ToString();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CaseBO.InsertCaseProfile(MapCaseProfilesDTO(), MapCasesDTO(), MapEvidencesPerCaseDTOList());
            Response.Redirect("Index.aspx");
        }

        protected CaseProfiles MapCaseProfilesDTO()
        {
            CaseProfiles objCaseProfiles = new CaseProfiles();
            objCaseProfiles.FirstName = txtFirstName.Text;
            objCaseProfiles.MiddleName = txtMiddleName.Text;
            objCaseProfiles.LastName = txtLastName.Text;
            objCaseProfiles.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            objCaseProfiles.VDCID = Convert.ToInt32(ddlVDC.SelectedValue);
            objCaseProfiles.CreatedBy = UserAuthentication.GetUserId(this.Page);
            return objCaseProfiles;
        }

        protected Cases MapCasesDTO()
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
            if (UserAuthentication.GetUserType(this.Page) == "CASEUSR")
            {
                objCases.PartnerID = UserAuthentication.GetPartnerId(this.Page); //Convert.ToInt32(ddlStackeHolder.SelectedValue);
            }
            else if(UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {
                objCases.PartnerID = Convert.ToInt32(ddlStackeHolder.SelectedValue);
            }
            objCases.CreatedBy = UserAuthentication.GetUserId(this.Page);
            return objCases;
        }

        protected List<EvidencesPerCase> MapEvidencesPerCaseDTOList()
        {
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

            return lstEvidencesPerCase;
        }

        protected void LoadOptions()
        {
            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            DataView objDataView = CaseTypesBO.GetAll(true);
            ddlTypeOfCase.DataSource = objDataView;
            ddlTypeOfCase.DataValueField = "CaseTypeID";
            ddlTypeOfCase.DataTextField = "CaseTypeDesc";
            ddlTypeOfCase.DataBind();
            ddlTypeOfCase.SelectedIndex = 1;


            ddlStackeHolder.DataSource = StakeholderBO.GetAll(true);
            ddlStackeHolder.DataValueField = "StakeHolderID";
            ddlStackeHolder.DataTextField = "StakeHolderName";
            ddlStackeHolder.DataBind();
            //ddlStackeHolder.SelectedValue = UserAuthentication.GetPartnerId(this.Page).ToString();
            if (UserAuthentication.GetUserType(this.Page) == "CASEUSR")
            {
                ddlStackeHolder.SelectedValue = UserAuthentication.GetPartnerId(this.Page).ToString();
                //ddlStackeHolder.Enabled = false;
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