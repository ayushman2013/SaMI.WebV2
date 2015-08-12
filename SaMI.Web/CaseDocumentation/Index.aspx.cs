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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {
                if (!IsPostBack)
                {
                    LoadOptions();
                    LoadCaseDetails();

                    if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
                    {
                        ddlDistrict.Enabled = true;
                    }
                    else if (UserAuthentication.GetUserType(this.Page) == "CASEUSR")
                    {
                        ddlDistrict.Enabled = false;
                        ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                        LoadVDC(Convert.ToInt32(ddlDistrict.SelectedValue));

                    }
                }
            }
            else
                Response.Redirect("~/Login.aspx");
        }



        protected void LoadCaseDetails()
        {
            int partnerID = 0;
            int ethnicityID = 0;
            int casteID = 0;
            int districtID = 0;
            string followUpStatus = string.Empty;
            string gender = string.Empty;
            int vdcID = 0;
            string status = string.Empty;
            string compensation = string.Empty;


            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!string.IsNullOrEmpty(ddlGender.SelectedValue))
                gender = ddlGender.SelectedValue;
            if (!string.IsNullOrEmpty(ddlVDC.SelectedValue))
                vdcID = Convert.ToInt32(ddlVDC.SelectedValue);
            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
                status = ddlStatus.SelectedValue;
            //if (!string.IsNullOrEmpty(ddlCompensation.SelectedValue))
            //    compensation = ddlCompensation.SelectedValue;
            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
                partnerID = UserAuthentication.GetPartnerId(this.Page);


            gvSaMICases.DataSource = CaseBO.GetCustomDetails(ethnicityID, casteID, districtID, followUpStatus, vdcID, gender, status, compensation, "", "", partnerID);
            gvSaMICases.DataBind();
        }

        void LoadOptions()
        {
            
                ddlDistrict.DataSource = DistrictBO.GetAll(true);
                ddlDistrict.DataValueField = "DistrictID";
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataBind();
            

            ListItem li = new ListItem("[Gender]", "");
            ddlGender.Items.Add(li);
            li = new ListItem("Male", "M");
            ddlGender.Items.Add(li);
            li = new ListItem("Female", "F");
            ddlGender.Items.Add(li);


            li = new ListItem("[Status]", "");
            ddlStatus.Items.Add(li);
            li = new ListItem("Completed", "Completed");
            ddlStatus.Items.Add(li);
            li = new ListItem("Running", "Running");
            ddlStatus.Items.Add(li);

            //li = new ListItem("[Compensation]", "");
            //ddlCompensation.Items.Add(li);
            //li = new ListItem("Yes", "Yes");
            //ddlCompensation.Items.Add(li);
            //li = new ListItem("No", "No");
            //ddlCompensation.Items.Add(li);
        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCaseDetails();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCaseDetails();
            if (ddlDistrict.SelectedItem != null)
            {
                if (ddlDistrict.SelectedIndex > 0)
                {
                    int x = Convert.ToInt32(ddlDistrict.SelectedValue);
                    LoadVDC(x);
                }
            }
        }

        private void LoadVDC(int DistrictId)
        {
            ddlVDC.DataSource = VDCBO.GetAllByDistrictID(DistrictId, true);
            ddlVDC.DataValueField = "VDCID";
            ddlVDC.DataTextField = "VDCName";
            ddlVDC.DataBind();
        }

        protected void ddlVDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCaseDetails();
        }



        protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCaseDetails();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlStatus.SelectedIndex == 2)
            //    ddlCompensation.SelectedIndex = 0;
            LoadCaseDetails();
        }

        protected void ddlCompensation_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(ddlCompensation.SelectedValue))
            //{
            //    ddlStatus.SelectedIndex = 1;
            //}

            LoadCaseDetails();
        }

        protected void gvSaMICases_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSaMICases.PageIndex = e.NewPageIndex;
            gvSaMICases.DataBind();
            LoadCaseDetails();
            Session["pageNumber"] = e.NewPageIndex;
        }

        
    }
}