using System;
using System.Web.UI;

using SaMI.Business;
using System.Data;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Web.UI.WebControls;
using System.Globalization;


namespace SaMI.Web.Training.TrnReport
{
    public partial class TrainingRegular : System.Web.UI.Page
    {
        public int EthnicityID = 0;
        public int DistrictID = 0;
        public int EventID = 0;
        public String strOption = "";
        public String CitizenshipNumber = "", PassportNumber = "", DOBBS = "", WardNumber = "", MobileNumber = "", ReferredBy = "";
        public String VDCID = "", EducationLevelID = "";

        DataView dv = new DataView();
        //GridView gdvTrainingRegularReport = new GridView();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOptions();
                BindOptions();
                BindData();
            }
        }

        //Load Options for Filtering
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

            ddlTrainingEvent.DataSource = TRNTradeBO.GetAllTrade(true);
            ddlTrainingEvent.DataValueField = "TRNTradeID";
            ddlTrainingEvent.DataTextField = "TradeName";
            ddlTrainingEvent.DataBind();
        }

        //Bind Data On Check List Box
        private void BindOptions()
        {
            DataView dv = new TRNTraineeBO().SelectOptionsForTrainingRegular();
            chkOptions.Items.Add(dv.Table.Columns[0].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[1].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[2].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[3].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[4].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[5].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[6].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[7].ColumnName);
            chkOptions.DataBind();
        }

        // Bind Data On Grid View
        protected void BindData()
        {
            if (chkOptions.Items[0].Selected == true)
                CitizenshipNumber = chkOptions.Items[0].Text;
            if (chkOptions.Items[1].Selected == true)
                PassportNumber = chkOptions.Items[1].Text;
            if (chkOptions.Items[2].Selected == true)
                DOBBS = chkOptions.Items[2].Text;
            if (chkOptions.Items[3].Selected == true)
                VDCID = chkOptions.Items[3].Text;
            if (chkOptions.Items[4].Selected == true)
                WardNumber = chkOptions.Items[4].Text;
            if (chkOptions.Items[5].Selected == true)
                MobileNumber = chkOptions.Items[5].Text;
            if (chkOptions.Items[6].Selected == true)
                EducationLevelID = chkOptions.Items[6].Text;
            if (chkOptions.Items[7].Selected == true)
                ReferredBy = chkOptions.Items[7].Text;

            if (!String.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                EthnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue))
                DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!String.IsNullOrEmpty(ddlTrainingEvent.SelectedValue))
                EventID = Convert.ToInt32(ddlTrainingEvent.SelectedValue);
            if (!string.IsNullOrEmpty(txtSearchText.Text))
            {
                strOption = txtSearchText.Text.Trim();
            }

            DataView dvTrainingReport = new TRNTraineeBO().GetCustomTrainingRegular(CitizenshipNumber, PassportNumber, DOBBS, VDCID, WardNumber, MobileNumber, EducationLevelID, ReferredBy, EthnicityID, DistrictID, EventID, strOption);

            if (dvTrainingReport != null)
            {
                for (int i = 0; i < dvTrainingReport.Table.Columns.Count; i++)
                {
                    BoundField boundfield = new BoundField();
                    boundfield.DataField = dvTrainingReport.Table.Columns[i].ColumnName.ToString();
                    boundfield.HeaderText = dvTrainingReport.Table.Columns[i].ColumnName.ToString();
                    gdvTrainingRegularReport.Columns.Add(boundfield);
                }

                gdvTrainingRegularReport.Width = 1200;
                gdvTrainingRegularReport.HeaderStyle.CssClass = "header";
                gdvTrainingRegularReport.RowStyle.CssClass = "rowstyle";
            }

            gdvTrainingRegularReport.Columns[1].HeaderText = "Event ID";
            gdvTrainingRegularReport.Columns[2].HeaderText = "Trade Name";
            gdvTrainingRegularReport.Columns[3].HeaderText = "Start Date";
            gdvTrainingRegularReport.Columns[4].HeaderText = "End Date";
            gdvTrainingRegularReport.Columns[5].HeaderText = "Name of Trainee";
            gdvTrainingRegularReport.Columns[6].HeaderText = "Last Name";


            ((BoundField)gdvTrainingRegularReport.Columns[3]).DataFormatString = "{0:dd-MMM-yyyy}";
            ((BoundField)gdvTrainingRegularReport.Columns[4]).DataFormatString = "{0:dd-MMM-yyyy}";

            gdvTrainingRegularReport.DataSource = dvTrainingReport;
            gdvTrainingRegularReport.DataBind();
            Panel1.Controls.Add(gdvTrainingRegularReport);

            //Get Record Count
            dv = TRNTraineeBO.GetTrainingRegularCount(strOption, EthnicityID, DistrictID, EventID);
            int count = Convert.ToInt32(dv.Table.Rows[0]["Count"]);
            lblNoOfRecords.Text = count.ToString();
        }

        protected void gdvTrainingRegularReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvTrainingRegularReport.PageIndex = e.NewPageIndex;
            gdvTrainingRegularReport.DataBind();
            BindData();
            Session["pageNumber"] = e.NewPageIndex;
        }

        //On Options Selected
        protected void chkOptions_CheckedChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ddlEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ddlTrainingEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        //Export To Excel
        protected void btnExportTrainingRegular_Click(object sender, EventArgs e)
        {
            ExcelPackage pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("$Sheet1");

            #region Heading

            ws.Cells["A1"].Value = "Namelist of training graduates (Regular)";
            ws.Cells[1, 1, 1, 9].Merge = true;
            ws.Cells[1, 1, 1, 9].Style.Font.Bold = true;
            ws.Cells[1, 1, 1, 9].Style.WrapText = true;

            ws.Cells["A3:A4"].Value = "S.N.";
            ws.Cells["A3:A4"].Merge = true;
            ws.Cells["A3:A4"].Style.Font.Bold = true;

            ws.Cells["B3:B4"].Value = "Batch";
            ws.Cells["B3:B4"].Merge = true;
            ws.Cells["B3:B4"].Style.Font.Bold = true;
            ws.Cells["B3:B4"].Style.WrapText = true;

            ws.Cells["C3:C4"].Value = "Training Agency";
            ws.Cells["C3:C4"].Merge = true;
            ws.Cells["C3:C4"].Style.Font.Bold = true;
            ws.Cells["C3:C4"].Style.WrapText = true;

            ws.Cells["D3:D4"].Value = "Event ID";
            ws.Cells["D3:D4"].Merge = true;
            ws.Cells["D3:D4"].Style.Font.Bold = true;
            ws.Cells["D3:D4"].Style.WrapText = true;

            ws.Cells["E3:E4"].Value = "Trade Name";
            ws.Cells["E3:E4"].Merge = true;
            ws.Cells["E3:E4"].Style.Font.Bold = true;
            ws.Cells["E3:E4"].Style.WrapText = true;

            ws.Cells["F3:F4"].Value = "Start Date";
            ws.Cells["F3:F4"].Merge = true;
            ws.Cells["F3:F4"].Style.Font.Bold = true;
            ws.Cells["F3:F4"].Style.WrapText = true;

            ws.Cells["G3:G4"].Value = "End Date";
            ws.Cells["G3:G4"].Merge = true;
            ws.Cells["G3:G4"].Style.Font.Bold = true;
            ws.Cells["G3:G4"].Style.WrapText = true;

            ws.Cells["H3:O3"].Value = "TRAINEE DETAILS";
            ws.Cells["H3:O3"].Merge = true;
            ws.Cells["H3:O3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["H3:O3"].Style.Font.Bold = true;
            ws.Cells["H3:O3"].Style.WrapText = true;

            ws.Cells["H4"].Value = "Name of Trainee";
            ws.Cells["H4"].Style.Font.Bold = true;
            ws.Cells["H4"].Style.WrapText = true;

            ws.Cells["I4"].Value = "Last Name";
            ws.Cells["I4"].Style.Font.Bold = true;
            ws.Cells["I4"].Style.WrapText = true;

            ws.Cells["J4"].Value = "Citizenship No.";
            ws.Cells["J4"].Style.Font.Bold = true;
            ws.Cells["J4"].Style.WrapText = true;

            ws.Cells["K4"].Value = "Passport No.";
            ws.Cells["K4"].Style.Font.Bold = true;
            ws.Cells["K4"].Style.WrapText = true;

            ws.Cells["L4"].Value = "Cat";
            ws.Cells["L4"].Style.Font.Bold = true;
            ws.Cells["L4"].Style.WrapText = true;

            ws.Cells["M4"].Value = "Birth Date";
            ws.Cells["M4"].Style.Font.Bold = true;
            ws.Cells["M4"].Style.WrapText = true;

            ws.Cells["N4"].Value = "Age";
            ws.Cells["N4"].Style.Font.Bold = true;
            ws.Cells["N4"].Style.WrapText = true;

            ws.Cells["O4"].Value = "Gender";
            ws.Cells["O4"].Style.Font.Bold = true;
            ws.Cells["O4"].Style.WrapText = true;

            ws.Cells["P3:S3"].Value = "ADDRESS";
            ws.Cells["P3:S3"].Merge = true;
            ws.Cells["P3:S3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["P3:S3"].Style.Font.Bold = true;
            ws.Cells["P3:S3"].Style.WrapText = true;


            ws.Cells["P4"].Value = "District";
            ws.Cells["P4"].Style.Font.Bold = true;
            ws.Cells["P4"].Style.WrapText = true;

            ws.Cells["Q4"].Value = "VDC";
            ws.Cells["Q4"].Style.Font.Bold = true;
            ws.Cells["Q4"].Style.WrapText = true;

            ws.Cells["R4"].Value = "W/N.";
            ws.Cells["R4"].Style.Font.Bold = true;
            ws.Cells["R4"].Style.WrapText = true;

            ws.Cells["S4"].Value = "Contact No.";
            ws.Cells["S4"].Style.Font.Bold = true;
            ws.Cells["S4"].Style.WrapText = true;

            ws.Cells["T3:T4"].Value = "Education Level";
            ws.Cells["T3:T4"].Merge = true;
            ws.Cells["T3:T4"].Style.Font.Bold = true;
            ws.Cells["T3:T4"].Style.WrapText = true;

            ws.Cells["U3:U4"].Value = "Refered By";

            ws.Cells["U3:U4"].Merge = true;
            ws.Cells["U3:U4"].Style.Font.Bold = true;
            ws.Cells["U3:U4"].Style.WrapText = true;


            #endregion

            int row = 4;
            int count = 0;
            int i = 0;

            ws.Cells["A3:U3"].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
            ws.Cells["A3:U3"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells["H3:O3"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells["P3:S3"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells["P3:S3"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells[row, 1, row, 21].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
            ws.Cells[row, 1, row, 21].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells[row, 1, row, 21].Style.Border.Diagonal.Style = ExcelBorderStyle.Thin;


            if (!String.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                EthnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue))
                DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!String.IsNullOrEmpty(ddlTrainingEvent.SelectedValue))
                EventID = Convert.ToInt32(ddlTrainingEvent.SelectedValue);
            if (txtSearchText.Text != String.Empty)
                strOption = txtSearchText.Text;
            dv = TRNTraineeBO.GetTrainingRegularReport(strOption, EthnicityID, DistrictID, EventID);

            foreach (DataRowView drv in dv)
            {
                row++;
                count++;

                ws.Cells[row, 1, row, 21].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                ws.Cells[row, 1, row, 21].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[row, 1, row, 21].Style.Border.Diagonal.Style = ExcelBorderStyle.Thin;

                ws.Cells[row, 1, row, 21].AutoFitColumns();
                string dtStartDate = dv.Table.Rows[i]["StartDate"].ToString();
                string[] Startdate = dtStartDate.Split(' ');
                string dtEndDate = dv.Table.Rows[i]["EndDate"].ToString();
                string[] Enddate = dtEndDate.Split(' ');

               
                if (dv.Count > 0)
                {
                    ws.Cells[row, 1].Value = count;
                    //Batch
                    //Training Agency   TrainingAgency

                    ws.Cells[row, 2].Value = dv.Table.Rows[i]["Batch"].ToString();
                    ws.Cells[row, 3].Value = dv.Table.Rows[i]["TrainingAgency"].ToString();
                    
                    ws.Cells[row, 4].Value = dv.Table.Rows[i]["EventID"].ToString();
                    ws.Cells[row, 5].Value = dv.Table.Rows[i]["TradeName"].ToString();
                  
                    ws.Cells[row, 6].Value = GetDateFormated.Get(Startdate[0]);
                    ws.Cells[row, 7].Value = GetDateFormated.Get(Enddate[0]);

                    ws.Cells[row, 8].Value = dv.Table.Rows[i]["FirstName"].ToString();
                    ws.Cells[row, 9].Value = dv.Table.Rows[i]["LastName"].ToString();
                    ws.Cells[row, 10].Value = dv.Table.Rows[i]["CitizenshipNumber"].ToString();
                    ws.Cells[row, 11].Value = dv.Table.Rows[i]["PassportNumber"].ToString();
                    ws.Cells[row, 12].Value = dv.Table.Rows[i]["EthnicityNameNP"].ToString();
                    ws.Cells[row, 13].Value = dv.Table.Rows[i]["DOBBS"].ToString();
                    ws.Cells[row, 14].Value = dv.Table.Rows[i]["CurrentAge"].ToString();
                    ws.Cells[row, 15].Value = dv.Table.Rows[i]["Gender"].ToString();
                    ws.Cells[row, 16].Value = dv.Table.Rows[i]["DistrictName"].ToString();
                    ws.Cells[row, 17].Value = dv.Table.Rows[i]["VDCName"].ToString();
                    ws.Cells[row, 18].Value = dv.Table.Rows[i]["WardNumber"].ToString();
                    ws.Cells[row, 19].Value = dv.Table.Rows[i]["PhoneNumber"].ToString();
                    ws.Cells[row, 20].Value = dv.Table.Rows[i]["EducationLevel"].ToString();
                    ws.Cells[row, 21].Value = dv.Table.Rows[i]["ReferredBy"].ToString();

                   
                }

                i++;
            }
            
            Response.Clear();
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Training Regular Report.xlsx");
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

    }
}