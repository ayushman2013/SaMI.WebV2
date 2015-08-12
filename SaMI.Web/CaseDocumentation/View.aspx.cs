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
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {
                if (!Page.IsPostBack)
                {
                    int CaseProfileID = Convert.ToInt32(Request.QueryString.Get("ID"));
                    LoadOption();
                    LoadCaseProfileDetail(CaseProfileID);
                }
            }
            else
                Response.Redirect("~/Login.aspx");
        }

        private void LoadOption()
        {
            cblEvidenceTypes.DataSource = EvidenceTypeBO.GetAll();
            cblEvidenceTypes.DataValueField = "EvidenceTypeID";
            cblEvidenceTypes.DataTextField = "EvidenceTypeDesc";
            cblEvidenceTypes.DataBind();
        }

        private void LoadCaseProfileDetail(int CaseProfileID)
        {
            CaseProfiles objCaseProfiles = CaseBO.GetCaseProfile(CaseProfileID);
            
            txtFirstName.Text = objCaseProfiles.FirstName;
            txtMiddleName.Text = objCaseProfiles.MiddleName;
            txtLastName.Text = objCaseProfiles.LastName;
            txtDistrict.Text = DistrictBO.GetDistrict(objCaseProfiles.DistrictID).DistrictName;
            txtVDC.Text = VDCBO.GetVDC(objCaseProfiles.VDCID).VDCName;

            Cases objCases = CaseBO.GetCases(CaseProfileID);
            txtCaseRegisteredDate.Text = objCases.CaseRegisteredDate.ToShortDateString();
            txtStackeHolder.Text = StakeholderBO.GetStakeHolders(objCases.PartnerID).StakeHolderName;
            txtCaseRegistrar.Text = CaseRegistrarBO.GetCaseRegistrar(objCases.CaseRegistrarID).CaseRegistrarName;
            txtResponsibleStaff.Text = objCases.ResponsibleStaff;
            txtCaseStatusType.Text = CaseStatusTypeBO.GetCaseStatusType(objCases.CaseStatusTypeID).CaseStatusTypeDesc;
            txtTypeOfCase.Text = CaseTypesBO.GetCaseType(objCases.CaseTypeID).CaseTypeDesc;
            txtCaseNumber.Text = objCases.CaseNumber;
            txtNameOfOpponent.Text = objCases.NameOfOpponent;
            txtCaseDesc.Text = objCases.Description;

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
}