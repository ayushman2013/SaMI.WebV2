using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SaMI.DTO;
using SaMI.Business;

namespace SaMI.Web
{
    public partial class CaseIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOptions();
                //ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();

                LoadCaseDetails();
            }
        }

        

        protected void LoadCaseDetails()
        {
            int partnerID = UserAuthentication.GetPartnerId(this.Page);
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
            if (!string.IsNullOrEmpty(ddlCompensation.SelectedValue))
                compensation = ddlCompensation.SelectedValue;


            gvSaMICases.DataSource = CaseBO.GetCustomDetails(ethnicityID, casteID, districtID, followUpStatus, vdcID, gender, status, compensation, "", "", partnerID);
            gvSaMICases.DataBind();
        }

        void LoadOptions()
        {


            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            ddlVDC.DataSource = VDCBO.GetAll(true);
            ddlVDC.DataValueField = "VDCID";
            ddlVDC.DataTextField = "VDCName";
            ddlVDC.DataBind();

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

            li = new ListItem("[Compensation]", "");
            ddlCompensation.Items.Add(li);
            li = new ListItem("Yes", "Yes");
            ddlCompensation.Items.Add(li);
            li = new ListItem("No", "No");
            ddlCompensation.Items.Add(li);
        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCaseDetails();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCaseDetails();
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
            if (ddlStatus.SelectedIndex == 2)
                ddlCompensation.SelectedIndex = 0;
            LoadCaseDetails();
        }

        protected void ddlCompensation_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(ddlCompensation.SelectedValue))
            {
                ddlStatus.SelectedIndex = 1;
            }

            LoadCaseDetails();
        }

        protected void gvSaMICases_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSaMICases.PageIndex = e.NewPageIndex;
            LoadCaseDetails();
            Session["pageNumber"] = e.NewPageIndex;
        }
    }
}