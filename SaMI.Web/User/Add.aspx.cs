using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.User
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadOptions();
            }
        }

        void LoadOptions()
        {
            ddlUserType.DataSource = UserTypeBO.GetAll(true);
            ddlUserType.DataValueField = "UserTypeID";
            ddlUserType.DataTextField = "UserTypeDesc";
            ddlUserType.DataBind();

            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            ddlPartner.DataSource = StakeholderBO.GetAll(true);
            ddlPartner.DataValueField = "StakeHolderID";
            ddlPartner.DataTextField = "StakeHolderName";
            ddlPartner.DataBind();

            ddlSkillPartner.DataSource = SkillPartnerBO.GetAll();
            ddlSkillPartner.DataValueField = "SkillPartnerID";
            ddlSkillPartner.DataTextField = "SkillPartnerName";
            ddlSkillPartner.DataBind();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDistrict.SelectedItem != null)
            {
                if (ddlDistrict.SelectedIndex > 0)
                {
                    int districtId = Convert.ToInt32(ddlDistrict.SelectedValue);
                    LoadOrganization(districtId);
                }
            }
        }

        private void LoadOrganization(int districtId)
        {
            ddlSaMIOrganization.DataSource = SaMIOrganizationBO.GetOrganizationByDistrictID(districtId, "[Organization]");
            ddlSaMIOrganization.DataValueField = "SaMIOrganizationID";
            ddlSaMIOrganization.DataTextField = "SaMIOrganizationName";
            ddlSaMIOrganization.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Users objUsers = new Users();
            objUsers.UserTypeID = Convert.ToInt32(ddlUserType.SelectedValue);
            objUsers.FullName = txtFullName.Text.Trim();
            objUsers.UserName = txtUserName.Text.Trim();
            objUsers.Password = txtPassword.Text.Trim();
            if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue))
                objUsers.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!String.IsNullOrEmpty(ddlSaMIOrganization.SelectedValue))
                objUsers.SaMIOrganizationID = Convert.ToInt32(ddlSaMIOrganization.SelectedValue);
            if (!String.IsNullOrEmpty(ddlPartner.SelectedValue))
                objUsers.PartnerID = Convert.ToInt32(ddlPartner.SelectedValue);
            if (!String.IsNullOrEmpty(ddlSkillPartner.SelectedValue))
                objUsers.SkillPartnerID = Convert.ToInt32(ddlSkillPartner.SelectedValue);

            objUsers.CreatedBy = UserAuthentication.GetUserId(this.Page);
            objUsers.CreatedDate = DateTime.Now;
            if(UserBO.IsUserExists(txtUserName.Text.Trim()))
            {
                lblStatus.Text = "User Name: " + txtUserName.Text + " already exists.";
                lblStatus.Visible = true;
            }
            else
            {
                objUsers.SyncStatus = 0;
                UserBO.InsertUser(objUsers);
                Response.Redirect("Index.aspx");
            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDistrict.Enabled = true;

            if (ddlUserType.SelectedIndex > 0)
            {
                if (Convert.ToInt32(ddlUserType.SelectedValue) == 6)
                {
                    ddlDistrict.SelectedValue = "27";
                    ddlDistrict.Enabled = false;
                }
                else
                {
                    ddlDistrict.Enabled = true;
                }
            }
            
        }

        

    }
}