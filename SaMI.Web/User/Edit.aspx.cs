using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SaMI.Business;
using SaMI.DTO;

namespace SaMI.Web.User
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadOptions();

                int userID = Convert.ToInt32(Request.QueryString.Get("ID"));

                Users objUsers = new Users();
                objUsers = UserBO.GetUser(userID);

                ddlUserType.SelectedValue = objUsers.UserTypeID.ToString();
                txtFullName.Text = objUsers.FullName;
                txtUserName.Text = objUsers.UserName;
                ddlDistrict.SelectedValue = objUsers.DistrictID.ToString();
                ddlPartner.SelectedValue = objUsers.PartnerID.ToString();
                ddlSkillPartner.SelectedValue = objUsers.SkillPartnerID.ToString();


                ddlSaMIOrganization.DataSource = SaMIOrganizationBO.GetOrganizationByDistrictID(Convert.ToInt32(objUsers.DistrictID), "");
                ddlSaMIOrganization.DataValueField = "SaMIOrganizationID";
                ddlSaMIOrganization.DataTextField = "SaMIOrganizationName";
                ddlSaMIOrganization.DataBind();

                ddlSaMIOrganization.SelectedValue = objUsers.SaMIOrganizationID.ToString();

                if (objUsers.PartnerID > 0)
                {
                    ddlPartner.Enabled = true;
                    ddlSaMIOrganization.Enabled = false;
                }

                if (objUsers.SkillPartnerID > 0)
                {
                    ddlSkillPartner.Enabled = true;
                    ddlSaMIOrganization.Enabled = false;
                }

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
            objUsers.FullName = txtFullName.Text;
            if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue))
                objUsers.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!String.IsNullOrEmpty(ddlPartner.SelectedValue))
                objUsers.PartnerID = Convert.ToInt32(ddlPartner.SelectedValue);
            if (!String.IsNullOrEmpty(ddlSaMIOrganization.SelectedValue))
                objUsers.SaMIOrganizationID = Convert.ToInt32(ddlSaMIOrganization.SelectedValue);
            int userID = Convert.ToInt32(Request.QueryString.Get("ID"));
            objUsers.UserID = userID;
            objUsers.Password = txtPassword.Text;
            objUsers.UpdatedBy = UserAuthentication.GetUserId(this.Page);
            objUsers.UpdatedDate = DateTime.Now;
            objUsers.SyncStatus = 0;
            UserBO.UpdateUser(objUsers);

            Response.Redirect("Index.aspx");
        }
    }
}