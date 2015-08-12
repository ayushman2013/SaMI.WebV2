using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SaMI.DTO;
using SaMI.Business;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Drawing;

namespace SaMI.Web.Training
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOptions();
                LoadTraineeList();
            }
        }

       public void LoadOptions()
       {
           ddlEthnicity.DataSource = EthnicityBO.GetAll(true);
           ddlEthnicity.DataValueField = "EthnicityID";
           ddlEthnicity.DataTextField = "EthnicityName";
           ddlEthnicity.DataBind();

           ddlDistrict.DataSource = DistrictBO.GetAll(true);
           ddlDistrict.DataValueField = "DistrictID";
           ddlDistrict.DataTextField = "DistrictName";
           ddlDistrict.DataBind();

           ddlTrainingEvent.DataSource = new TRNTradeBO().SelectAllTradeName(true);
           ddlTrainingEvent.DataValueField = "TRNTradeID";
           ddlTrainingEvent.DataTextField = "TradeName";
           ddlTrainingEvent.DataBind();

           if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
           {
               ddlUsers.DataSource = UserBO.GetUsers(true);
               ddlUsers.DataValueField = "UserID";
               ddlUsers.DataTextField = "FullName";
               ddlUsers.DataBind();
           }
           else
           {
               ddlUsers.Visible = false;
           }
       }

       protected void ddlEventID_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadTraineeList();
       }

       protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadTraineeList();
       }

       protected void ddlEthnicity_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
           {
               LoadValidRegions(Convert.ToInt32(ddlEthnicity.SelectedValue));
           }
           LoadTraineeList();
       }

       void LoadValidRegions(int EthnicityID)
       {
           List<int> lstValidRegions = EthnicityBO.SelectValidRegionForEthnicity(EthnicityID);

           ddlValidRegions.DataSource = EthnicityBO.SelectRegionsForDropdown(lstValidRegions, "[Regions]");
           ddlValidRegions.DataValueField = "GeoBasedEthnicityID";
           ddlValidRegions.DataTextField = "GeoBasedEthnicityDesc";
           ddlValidRegions.DataBind();
       }

       protected void ddlValidRegions_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadTraineeList();
       }

       protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadTraineeList();
       }

       protected void ddlTrainingEvent_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadTraineeList();
       }

       protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
       {
           LoadTraineeList();
       }

       protected void btnSearch_Click(object sender, EventArgs e)
       {
           String strOption = "";
           int EthnicityID = 0;
           int DistrictID = 0;
           int EventID = 0;
           String orderBy = "";
           int createdBy = 0;

           if (!String.IsNullOrEmpty(ddlEthnicity.SelectedValue))
               EthnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
           if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue))
               DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
           if (!String.IsNullOrEmpty(ddlTrainingEvent.SelectedValue))
               EventID = Convert.ToInt32(ddlTrainingEvent.SelectedValue);
           if (!String.IsNullOrEmpty(ddlUsers.SelectedValue))
               createdBy = Convert.ToInt32(ddlUsers.SelectedValue);
           if (!string.IsNullOrEmpty(txtSearchText.Text))
           {
               strOption = txtSearchText.Text.Trim();
           }

           gvTraineeProfile.DataSource = TRNTraineeBO.GetTrainingReport(strOption, EthnicityID, DistrictID, EventID, orderBy, createdBy);
           gvTraineeProfile.DataBind();

           //Get Record Count
           DataView dv = TRNTraineeBO.GetTrainingReportCount(strOption, EthnicityID, DistrictID, EventID, createdBy);
           int count = Convert.ToInt32(dv.Table.Rows[0]["Count"]);
           lblNoOfRecords.Text = count.ToString();
       }

       private void LoadTraineeList()
       {
           int EthnicityID=0;
           int validRegionID = 0;
           int DistrictID=0;
           int TradeName=0;
           String orderBy="";
           int createdBy=0;

           if (!String.IsNullOrEmpty(ddlEthnicity.SelectedValue))
               EthnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
           if (!string.IsNullOrEmpty(ddlValidRegions.SelectedValue))
               validRegionID = Convert.ToInt32(ddlValidRegions.SelectedValue);
           if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue))
               DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
           if (!String.IsNullOrEmpty(ddlTrainingEvent.SelectedValue))
               TradeName = Convert.ToInt32(ddlTrainingEvent.SelectedValue);
           if (!String.IsNullOrEmpty(ddlUsers.SelectedValue))
               createdBy = Convert.ToInt32(ddlUsers.SelectedValue);

           gvTraineeProfile.DataSource = TRNTraineeBO.GetTrainingData(EthnicityID, validRegionID, DistrictID, TradeName, orderBy, createdBy);
           gvTraineeProfile.DataBind();

           //Get Record Count
           DataView dv = TRNTraineeBO.GetTrainingDataCount(EthnicityID, validRegionID, DistrictID, TradeName, createdBy);
           int count = Convert.ToInt32(dv.Table.Rows[0]["Count"]);
           lblNoOfRecords.Text = count.ToString();
       }

       protected void gvTraineeProfile_RowCommand(object sender, GridViewCommandEventArgs e)
       {
           TRNTrainee objTraineeProfile = new TRNTrainee();
           if (e.CommandName.Equals("cmdDelete"))
           {
               int TraineeID = Convert.ToInt32(e.CommandArgument);
               objTraineeProfile.TraineeID = TraineeID;
               objTraineeProfile.Status = 0;
               int rowaffected = TRNTraineeBO.DeleteTrainee(objTraineeProfile);
               LoadTraineeList();
           }
       }

       protected void gvTraineeProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           gvTraineeProfile.PageIndex = e.NewPageIndex;
           LoadTraineeList();
           Session["pageNumber"] = e.NewPageIndex;
       }

        //Export To Excel
       protected void btnExportEmploymentRegular_Click(object sender, EventArgs e)
       {
           gvTraineeProfile.AllowPaging = false;
           LoadTraineeList();

           Response.Clear();
           Response.AddHeader("content-disposition", "attachment;filename=Trainee List.xls");
           Response.ContentType = "application/vnd.xlsx";
           System.IO.StringWriter stringWrite = new System.IO.StringWriter();
           System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
           gvTraineeProfile.RenderControl(htmlWrite);
           Response.Write(stringWrite.ToString());
           Response.End();
       }

       public override void VerifyRenderingInServerForm(Control control)
       {
           /* Verifies that the control is rendered */
       }
    }
}