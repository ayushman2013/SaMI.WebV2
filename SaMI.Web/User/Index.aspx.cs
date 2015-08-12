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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadOptions();
                LoadUsers();
            }
        }

        void LoadOptions()
        {
            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            ddlCasePartner.DataSource = StakeholderBO.GetAll(true);
            ddlCasePartner.DataValueField = "StakeHolderID";
            ddlCasePartner.DataTextField = "StakeHolderName";
            ddlCasePartner.DataBind();

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
            LoadUsers();
        }

        private void LoadOrganization(int districtId)
        {
            ddlSaMIOrganization.DataSource = SaMIOrganizationBO.GetOrganizationByDistrictID(districtId, "[Organization]");
            ddlSaMIOrganization.DataValueField = "SaMIOrganizationID";
            ddlSaMIOrganization.DataTextField = "SaMIOrganizationName";
            ddlSaMIOrganization.DataBind();
        }

        void LoadUsers()
        {
            int DistrictID = 0;
            int SaMIOrganizationID = 0;
            int PartnerID = 0;
            int SkillPartnerID = 0;

            if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue))
            {

                DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
               
            }
            if (ddlSaMIOrganization.SelectedIndex > 0) 
            { 
                if (!String.IsNullOrEmpty(ddlSaMIOrganization.SelectedValue))
                {

                    SaMIOrganizationID = Convert.ToInt32(ddlSaMIOrganization.SelectedValue);

                }
            }
            if (!String.IsNullOrEmpty(ddlCasePartner.SelectedValue))
            {

                PartnerID = Convert.ToInt32(ddlCasePartner.SelectedValue);

            }
            if (!String.IsNullOrEmpty(ddlSkillPartner.SelectedValue))
            {

                SkillPartnerID = Convert.ToInt32(ddlSkillPartner.SelectedValue);

            }
            DataView dv = UserBO.GetAll(DistrictID, SaMIOrganizationID, PartnerID, SkillPartnerID);
            gvUsers.DataSource = dv;
            gvUsers.DataBind();
        }


        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdDelete"))
            {
                int userID = Convert.ToInt32(e.CommandArgument);
                UserBO.DeleteUser(userID);
                LoadUsers();
            }
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            LoadUsers();
            Session["pageNumber"] = e.NewPageIndex;
        }

        
    }
}