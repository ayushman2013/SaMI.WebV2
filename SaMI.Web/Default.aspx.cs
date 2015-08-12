using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SaMI.DTO;
using SaMI.Business;
using System.IO;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace SaMI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/Profile/Index.aspx");
            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
                Response.Redirect("CaseIndex.aspx");
            if (!Page.IsPostBack)
            {
                LoadOptions();
                

                if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "CASEUSR")
                    ddlDistrict.Enabled = true;
                else
                {
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                    ddlDistrict.Enabled = false;
                }
                LoadProfiles();
                MapDate();
                txtFromDate.Enabled = false;
                txtToDate.Enabled = false;
                btnSearchByDate.Enabled = false;
            }
        }

        

        void MapDate()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = Convert.ToInt32(ddlYear.SelectedValue);
            int endMonth = currentMonth + 2;
            int endYear = currentYear;
            int totalDays = DateTime.DaysInMonth(endYear, endMonth);

            switch (ddlPeriod.SelectedValue)
            {
                case "FIRST":
                    currentMonth = 1;
                    endMonth = 3;
                    break;
                case "SECOND":
                    currentMonth = 4;
                    endMonth = 6;
                    break;
                case "THIRD":
                    currentMonth = 7;
                    endMonth = 9;
                    break;
                case "FOURTH":
                    currentMonth = 10;
                    endMonth = 12;
                    break;
                default:
                    break;
            }

            if (ddlPeriod.SelectedValue != "CUSTOM")
            {
                totalDays = DateTime.DaysInMonth(endYear, endMonth);
                txtFromDate.Text = currentMonth + "/1/" + currentYear;
                txtToDate.Text = endMonth + "/" + totalDays + "/" + endYear;

            }

        }

        protected void ddlPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPeriod.SelectedValue != "CUSTOM")
            {
                txtFromDate.Enabled = false;
                txtToDate.Enabled = false;
                btnSearchByDate.Enabled = false;
                MapDate();
                LoadProfiles();
            }
            else
            {
                txtFromDate.Enabled = true;
                txtToDate.Enabled = true;
                btnSearchByDate.Enabled = true;
            }
        }

        protected void LoadProfiles(Boolean blnProfile = true, Boolean blnReturnee = true)
        {
            int ethnicityID = 0;
            int casteID = 0;
            int districtID = 0;
            string followUpStatus = string.Empty;
            string fromDate = string.Empty;
            string toDate = string.Empty;

            if (!string.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                ethnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            if (!string.IsNullOrEmpty(ddlCaste.SelectedValue))
                casteID = Convert.ToInt32(ddlCaste.SelectedValue);
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!string.IsNullOrEmpty(ddlFollowUpStatus.SelectedValue))
                followUpStatus = ddlFollowUpStatus.SelectedValue;
            fromDate = txtFromDate.Text;
            toDate = txtToDate.Text;

            if (blnProfile)
            {
                gvSaMIProfile.DataSource = SaMIProfileBO.GetCustomReport(fromDate, toDate, ethnicityID, districtID, followUpStatus, 0, "", "", "SP.CreatedDate DESC");
                gvSaMIProfile.DataBind();
                gvProfileSummary.DataSource = SaMIProfileBO.GetStatistics(fromDate, toDate, ethnicityID, districtID, followUpStatus, 0);
                gvProfileSummary.DataBind();
            }

            if (blnReturnee)
            {
                gvReturnee.DataSource = SaMIProfileBO.GetCustomReport(fromDate, toDate, ethnicityID, districtID, followUpStatus, 0, "", "", "SP.CreatedDate DESC", true);
                gvReturnee.DataBind();
                gvReturneeSummary.DataSource = SaMIProfileBO.GetStatistics(fromDate, toDate, ethnicityID, districtID, followUpStatus, 0, true);
                gvReturneeSummary.DataBind();
            }
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

            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("[Follow-up]", "");
            ddlFollowUpStatus.Items.Add(li);
            li = new System.Web.UI.WebControls.ListItem("Yes", "Yes");
            ddlFollowUpStatus.Items.Add(li);
            li = new System.Web.UI.WebControls.ListItem("No", "No");
            ddlFollowUpStatus.Items.Add(li);

            li = new System.Web.UI.WebControls.ListItem("First Quarter", "FIRST");
            ddlPeriod.Items.Add(li);
            li = new System.Web.UI.WebControls.ListItem("Second Quarter", "SECOND");
            ddlPeriod.Items.Add(li);
            li = new System.Web.UI.WebControls.ListItem("Third Quarter", "THIRD");
            ddlPeriod.Items.Add(li);
            li = new System.Web.UI.WebControls.ListItem("Fourth Quarter", "FOURTH");
            ddlPeriod.Items.Add(li);
            li = new System.Web.UI.WebControls.ListItem("Custom", "CUSTOM");
            ddlPeriod.Items.Add(li);

            for (int i = DateTime.Now.Year; i >= (DateTime.Now.Year - 5); i--)
            {
                li = new System.Web.UI.WebControls.ListItem("YEAR: " + i, i.ToString());
                ddlYear.Items.Add(li);
            }
        }


        protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProfiles();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProfiles();
        }

        protected void ddlFollowUpStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProfiles();
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

                LoadProfiles();
            }
        }

        protected void btnSearchByDate_Click(object sender, EventArgs e)
        {
            LoadProfiles();
        }


        protected void btnExportProfilePDF_Click(object sender, EventArgs e)
        {

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            StringWriter sw2 = new StringWriter();
            HtmlTextWriter hw2 = new HtmlTextWriter(sw2);

            DateTime dtFromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtToDate = Convert.ToDateTime(txtToDate.Text);

            String strHeader = "<h1>Safer Migration Project</h1><br/>";
            strHeader += "<h1>Registered Profile</h1><br/>";
            strHeader += "<h4>" + dtFromDate.ToString("dd MMMM, yyyy") + " - " + dtToDate.ToString("dd MMMM, yyyy") + "</h4><br/>";

            gvSaMIProfile.AllowPaging = false;
            gvSaMIProfile.RenderControl(hw);
            gvProfileSummary.RenderControl(hw2);

            String strHeaderSummary = "<br/><br/><h1>Summary</h1><br/>";
            StringReader sr = new StringReader(strHeader + sw.ToString() + strHeaderSummary + sw2.ToString());

            Document pdfDoc = new Document(PageSize.A2, 50f, 50f, 50f, 50f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Profile Registered.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();


        }

        protected void btnExportProfileExcel_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable("GridView_Data");            

            foreach (TableCell cell in gvSaMIProfile.HeaderRow.Cells)
            {
                dt.Columns.Add("");
            }


            DateTime dtFromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtToDate = Convert.ToDateTime(txtToDate.Text);
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "Safer Migration Project";
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "Registered Profile";
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = dtFromDate.ToString("dd MMMM, yyyy") + " - " + dtToDate.ToString("dd MMMM, yyyy");
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = string.Empty;

            int count = 0;
            dt.Rows.Add();
            foreach (TableCell cell in gvSaMIProfile.HeaderRow.Cells)
            {
                dt.Rows[dt.Rows.Count - 1][count] = cell.Text;
                count++;
            }

            int rowCount = 1;
            foreach (GridViewRow row in gvSaMIProfile.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (i == 0)
                        dt.Rows[dt.Rows.Count - 1][i] = rowCount.ToString();
                    else
                        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
                rowCount++;
            }

            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "";
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "Summary";
            
            count = 0;
            foreach (TableCell cell in gvProfileSummary.HeaderRow.Cells)
            {
                dt.Rows[dt.Rows.Count - 1][count] = cell.Text;
                count++;
            }
            foreach (GridViewRow row in gvProfileSummary.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                
                
                wb.Worksheets.Add(dt);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Profile Registered.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnExportRerurneePDF_Click(object sender, EventArgs e)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            StringWriter sw2 = new StringWriter();
            HtmlTextWriter hw2 = new HtmlTextWriter(sw2);

            DateTime dtFromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtToDate = Convert.ToDateTime(txtToDate.Text);

            String strHeader = "<h1>Safer Migration Project</h1><br/>";
            strHeader += "<h1>Returnee's Profile</h1><br/>";
            strHeader += "<h4>" + dtFromDate.ToString("dd MMMM, yyyy") + " - " + dtToDate.ToString("dd MMMM, yyyy") + "</h4><br/>";

            gvReturnee.AllowPaging = false;
            gvReturnee.RenderControl(hw);
            gvReturneeSummary.RenderControl(hw2);

            String strHeaderSummary = "<br/><br/><h1>Summary</h1><br/>";
            StringReader sr = new StringReader(strHeader + sw.ToString() + strHeaderSummary + sw2.ToString());

            Document pdfDoc = new Document(PageSize.A2, 50f, 50f, 50f, 50f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Returnee Profile.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void btnExportReturneeExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("GridView_Data");

            foreach (TableCell cell in gvReturnee.HeaderRow.Cells)
            {
                dt.Columns.Add("");
            }


            DateTime dtFromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime dtToDate = Convert.ToDateTime(txtToDate.Text);
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "Safer Migration Project";
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "Returnee's Profile";
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = dtFromDate.ToString("dd MMMM, yyyy") + " - " + dtToDate.ToString("dd MMMM, yyyy");
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = string.Empty;

            int count = 0;
            dt.Rows.Add();
            foreach (TableCell cell in gvReturnee.HeaderRow.Cells)
            {
                dt.Rows[dt.Rows.Count - 1][count] = cell.Text;
                count++;
            }

            int rowCount = 1;
            foreach (GridViewRow row in gvReturnee.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (i == 0)
                        dt.Rows[dt.Rows.Count - 1][i] = rowCount.ToString();
                    else
                        dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
                rowCount++;
            }

            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "";
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = "Summary";

            count = 0;
            foreach (TableCell cell in gvReturneeSummary.HeaderRow.Cells)
            {
                dt.Rows[dt.Rows.Count - 1][count] = cell.Text;
                count++;
            }
            foreach (GridViewRow row in gvReturneeSummary.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Returnee Profile.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void gvSaMIProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSaMIProfile.PageIndex = e.NewPageIndex;
            LoadProfiles(true, false);
            Session["pageNumberProfile"] = e.NewPageIndex;
        }

        protected void gvReturnee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReturnee.PageIndex = e.NewPageIndex;
            LoadProfiles(false, true);
            Session["pageNumberReturnee"] = e.NewPageIndex;
        }



    }
}
