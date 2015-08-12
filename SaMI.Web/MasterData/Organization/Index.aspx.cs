using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.Organization
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDistrict();
                LoadSaMIOrganizations();
            }

        }

        private void LoadDistrict()
        {
            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();
        }

        void LoadSaMIOrganizations()
        {
            DataView dv = SaMIOrganizationBO.GetAll();
            gvOrgnaizations.DataSource = dv;
            gvOrgnaizations.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaMIOrganizations objSaMIOrganizations = new SaMIOrganizations();
            objSaMIOrganizations.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            objSaMIOrganizations.SaMIOrganizationName = txtOrganizationName.Text;
            objSaMIOrganizations.Status = 1;

            if (!string.IsNullOrEmpty(hfSaMIOrganizationID.Value.ToString()))
            {
                objSaMIOrganizations.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objSaMIOrganizations.UpdatedDate = DateTime.Now;
                objSaMIOrganizations.SaMIOrganizationID = Convert.ToInt32(hfSaMIOrganizationID.Value);
                SaMIOrganizationBO.UpdateSaMIOrganization(objSaMIOrganizations);
            }
            else
            {
                objSaMIOrganizations.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objSaMIOrganizations.CreatedDate = DateTime.Now;
                SaMIOrganizationBO.InsertSaMIOrganization(objSaMIOrganizations);
            }

            ddlDistrict.SelectedIndex = 0;
            txtOrganizationName.Text = string.Empty;
            hfSaMIOrganizationID.Value = string.Empty;
            LoadSaMIOrganizations();
        }

        protected void gvOrgnaizations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfSaMIOrganizationID.Value = e.CommandArgument.ToString();
            SaMIOrganizations objSaMIOrganizations = new SaMIOrganizations();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objSaMIOrganizations = SaMIOrganizationBO.GetSaMIOrganization(Convert.ToInt32(e.CommandArgument));
                ddlDistrict.SelectedValue = objSaMIOrganizations.DistrictID.ToString();
                txtOrganizationName.Text = objSaMIOrganizations.SaMIOrganizationName;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int SaMIOrganizationID = Convert.ToInt32(e.CommandArgument);
                objSaMIOrganizations.SaMIOrganizationID = SaMIOrganizationID;
                objSaMIOrganizations.Status = 0;
                SaMIOrganizationBO.DeleteSaMIOrganization(objSaMIOrganizations);
                LoadSaMIOrganizations();
            }
        }
    }
}