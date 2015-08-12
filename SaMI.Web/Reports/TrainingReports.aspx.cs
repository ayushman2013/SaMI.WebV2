using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SaMI.DTO;
using SaMI.Business;

namespace SaMI.Web.Reports
{
    public partial class TrainingReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOptions();
                if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
                    ddlDistrict.Enabled = true;
                else
                {
                    ddlDistrict.Enabled = false;
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                }
                LoadTrainingDetails();
            }
        }

        protected void LoadTrainingDetails()
        {
            int ethnicityID = 0;
            int casteID = 0;
            int districtID = 0;
            string gender = string.Empty;
            int vdcID = 0;
            string status = string.Empty;
            string compensation = string.Empty;
            string fromDate = string.Empty;
            string toDate = string.Empty;

            if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                ethnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            if (!string.IsNullOrEmpty(ddlCaste.SelectedValue))
                casteID = Convert.ToInt32(ddlCaste.SelectedValue);
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!string.IsNullOrEmpty(ddlGender.SelectedValue))
                gender = ddlGender.SelectedValue;
            if (!string.IsNullOrEmpty(ddlVDC.SelectedValue))
                vdcID = Convert.ToInt32(ddlVDC.SelectedValue);

            if (!string.IsNullOrEmpty(txtFromDate.Text) && !string.IsNullOrEmpty(txtToDate.Text))
            {
                fromDate = txtFromDate.Text;
                toDate = txtToDate.Text;
            }
            else if(!string.IsNullOrEmpty(txtFromDate.Text))
            {
                fromDate = txtFromDate.Text;
            }
            




            gvEmploymentSkills.DataSource = EmploymentSkillBO.GetCustom(ethnicityID, casteID, districtID, vdcID, gender, fromDate, toDate);
            gvEmploymentSkills.DataBind();
        }

        void LoadOptions()
        {
            ddlEthnicity.DataSource = EthnicityBO.GetAll(true);
            ddlEthnicity.DataValueField = "EthnicityID";
            ddlEthnicity.DataTextField = "EthnicityName";
            ddlEthnicity.DataBind();

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

        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTrainingDetails();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTrainingDetails();
        }

        protected void ddlVDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTrainingDetails();
        }

        protected void ddlEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
            {
                int ethnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);

                if (ethnicityID > 0)
                {
                    ddlCaste.DataSource = CasteBO.GetByEthnicityID(ethnicityID, true);
                    ddlCaste.DataValueField = "CasteID";
                    ddlCaste.DataTextField = "CasteName";
                    ddlCaste.DataBind();
                }

                LoadTrainingDetails();
            }
        }

        protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTrainingDetails();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTrainingDetails();
        }

        protected void gvEmploymentSkills_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmploymentSkills.PageIndex = e.NewPageIndex;
            LoadTrainingDetails();
            Session["pageNumber"] = e.NewPageIndex;
        }

    }
}