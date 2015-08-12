using System;
using System.Web.UI;

using SaMI.Business;
using System.Data;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SaMI.Web.Training.TrnReport
{
    public partial class EmploymentRegular : System.Web.UI.Page
    {
        public int EthnicityID = 0;
        public int DistrictID = 0;
        public int EventID = 0;
        public String strOption = "";
        public String VDCName = "", EmploymentType = "", Organization = "", Country = "", PhoneNumber = "", DepartureDate = "", Salary = "",
                      EmploymentStatus = "", RecruitmentAgency = "";
        
        DataView dv = new DataView();
        //GridView gdvEmploymentRegularReport = new GridView();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOptions();
                BindOptions();
                BindData();
            }
        }

        //Load Options
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
            DataView dv = TRNEmploymentBO.SelectOptionsEmployment();
            chkOptions.Items.Add(dv.Table.Columns[0].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[1].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[2].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[3].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[4].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[5].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[6].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[7].ColumnName);
            chkOptions.Items.Add(dv.Table.Columns[8].ColumnName);
            chkOptions.DataBind();
        }

        // Bind Data On Grid View
        protected void BindData()
        {
            if (chkOptions.Items[0].Selected == true)
                VDCName = chkOptions.Items[0].Text;
            if (chkOptions.Items[1].Selected == true)
                EmploymentType = chkOptions.Items[1].Text;
            if (chkOptions.Items[2].Selected == true)
                Organization = chkOptions.Items[2].Text;
            if (chkOptions.Items[3].Selected == true)
                Country = chkOptions.Items[3].Text;
            if (chkOptions.Items[4].Selected == true)
                PhoneNumber = chkOptions.Items[4].Text;
            if (chkOptions.Items[5].Selected == true)
                DepartureDate = chkOptions.Items[5].Text;
            if (chkOptions.Items[6].Selected == true)
                Salary = chkOptions.Items[6].Text;
            if (chkOptions.Items[7].Selected == true)
                EmploymentStatus = chkOptions.Items[7].Text;
            if (chkOptions.Items[8].Selected == true)
                RecruitmentAgency = chkOptions.Items[8].Text;

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

            DataView dvEmploymentReport = TRNEmploymentBO.SelectCustomEmploymentRegular(VDCName, EmploymentType, Organization, Country, PhoneNumber, DepartureDate, Salary,
               EmploymentStatus, RecruitmentAgency, EthnicityID, DistrictID, EventID, strOption);   
            if(dvEmploymentReport != null)
            {
                for (int i = 0; i < dvEmploymentReport.Table.Columns.Count; i++)
                {
                    BoundField boundfield = new BoundField();
                    boundfield.DataField = dvEmploymentReport.Table.Columns[i].ColumnName.ToString();
                    boundfield.HeaderText = dvEmploymentReport.Table.Columns[i].ColumnName.ToString();
                    gdvEmploymentRegularReport.Columns.Add(boundfield);
                }

                gdvEmploymentRegularReport.Width = 1200;
                gdvEmploymentRegularReport.HeaderStyle.CssClass = "header";
                gdvEmploymentRegularReport.RowStyle.CssClass = "rowstyle";
            }

            gdvEmploymentRegularReport.Columns[1].HeaderText = "Event ID";
            gdvEmploymentRegularReport.Columns[2].HeaderText = "Trade Name";
            gdvEmploymentRegularReport.Columns[3].HeaderText = "Start Date";
            gdvEmploymentRegularReport.Columns[4].HeaderText = "End Date";
            gdvEmploymentRegularReport.Columns[5].HeaderText = "Name of Trainee";
            gdvEmploymentRegularReport.Columns[6].HeaderText = "Category";


            ((BoundField)gdvEmploymentRegularReport.Columns[3]).DataFormatString = "{0:dd-MMM-yyyy}";
            ((BoundField)gdvEmploymentRegularReport.Columns[4]).DataFormatString = "{0:dd-MMM-yyyy}";

            ((BoundField)gdvEmploymentRegularReport.Columns[3]).DataFormatString = "{0:dd-MMM-yyyy}";

            gdvEmploymentRegularReport.DataSource = dvEmploymentReport;
            gdvEmploymentRegularReport.DataBind();
            Panel1.Controls.Add(gdvEmploymentRegularReport);

            //Get Record Count
            dv = TRNEmploymentBO.GetEmploymentRegularCount(strOption, EthnicityID, DistrictID, EventID);
            int count = Convert.ToInt32(dv.Table.Rows[0]["Count"]);
            lblNoOfRecords.Text = count.ToString();
        }

        protected void gdvEmploymentRegularReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvEmploymentRegularReport.PageIndex = e.NewPageIndex;
            gdvEmploymentRegularReport.DataBind();
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
        protected void btnExportEmploymentRegular_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ddlEthnicity.SelectedValue))
                EthnicityID = Convert.ToInt32(ddlEthnicity.SelectedValue);
            if (!String.IsNullOrEmpty(ddlDistrict.SelectedValue))
                DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (!String.IsNullOrEmpty(ddlTrainingEvent.SelectedValue))
                EventID = Convert.ToInt32(ddlTrainingEvent.SelectedValue);
            if (txtSearchText.Text != String.Empty)
                strOption = txtSearchText.Text;

            ExcelPackage pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("$Sheet1");

            #region CheckList Heading

            DataView dvCheckList = new TRNCheckListBO().GetAllCheckList();
            int col = 19;
            int countlist = dvCheckList.Count;
            for (int a = 0; a < countlist; a++)
            {
                ws.Cells[3, col, 4, col].Value = dvCheckList.Table.Rows[a][1].ToString();
                ws.Cells[3, col, 4, col].Merge = true;
                ws.Cells[3, col, 4, col].Style.Font.Bold = true;
                ws.Cells[3, col, 4, col].Style.WrapText = true;

                col++;
            }
           

            #region
            //ws.Cells["R3:R4"].Value = dvCheckList.Table.Rows[1][1].ToString();
            //ws.Cells["R3:R4"].Merge = true;
            //ws.Cells["R3:R4"].Style.Font.Bold = true;
            //ws.Cells["R3:R4"].Style.WrapText = true;

            //ws.Cells["S3:S4"].Value = dvCheckList.Table.Rows[2][1].ToString();
            //ws.Cells["S3:S4"].Merge = true;
            //ws.Cells["S3:S4"].Style.Font.Bold = true;
            //ws.Cells["S3:S4"].Style.WrapText = true;

            //ws.Cells["T3:T4"].Value = dvCheckList.Table.Rows[3][1].ToString();
            //ws.Cells["T3:T4"].Merge = true;
            //ws.Cells["T3:T4"].Style.Font.Bold = true;
            //ws.Cells["T3:T4"].Style.WrapText = true;

            //ws.Cells["U3:U4"].Value = dvCheckList.Table.Rows[4][1].ToString();
            //ws.Cells["U3:U4"].Merge = true;
            //ws.Cells["U3:U4"].Style.Font.Bold = true;
            //ws.Cells["U3:U4"].Style.WrapText = true;

            //ws.Cells["V3:V4"].Value = dvCheckList.Table.Rows[5][1].ToString();
            //ws.Cells["V3:V4"].Merge = true;
            //ws.Cells["V3:V4"].Style.Font.Bold = true;
            //ws.Cells["V3:V4"].Style.WrapText = true;

            //ws.Cells["W3:W4"].Value = dvCheckList.Table.Rows[6][1].ToString();
            //ws.Cells["W3:W4"].Merge = true;
            //ws.Cells["W3:W4"].Style.Font.Bold = true;
            //ws.Cells["W3:W4"].Style.WrapText = true;

            //ws.Cells["X3:X4"].Value = dvCheckList.Table.Rows[7][1].ToString();
            //ws.Cells["X3:X4"].Merge = true;
            //ws.Cells["X3:X4"].Style.Font.Bold = true;
            //ws.Cells["X3:X4"].Style.WrapText = true;
            #endregion
            #endregion

            #region Heading

            ws.Cells["A1"].Value = "Namelist of employed graduates (Regular)";
            ws.Cells[1, 1, 1, 9].Merge = true;
            ws.Cells[1, 1, 1, 9].Style.Font.Bold = true;
            ws.Cells[1, 1, 1, 9].Style.WrapText = true;

            ws.Cells["A3:A4"].Value = "S.N.";
            ws.Cells["A3:A4"].Merge = true;
            ws.Cells["A3:A4"].Style.Font.Bold = true;
            ws.Cells["A3:A4"].Style.WrapText = true;

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

            ws.Cells["H3:H4"].Value = "Name of Trainee";
            ws.Cells["H3:H4"].Merge = true;
            ws.Cells["H3:H4"].Style.Font.Bold = true;
            ws.Cells["H3:H4"].Style.WrapText = true;

            ws.Cells["I3:I4"].Value = "Cat";
            ws.Cells["I3:I4"].Merge = true;
            ws.Cells["I3:I4"].Style.Font.Bold = true;
            ws.Cells["I3:I4"].Style.WrapText = true;

            ws.Cells["J3:J4"].Value = "Gender";
            ws.Cells["J3:J4"].Merge = true;
            ws.Cells["J3:J4"].Style.Font.Bold = true;
            ws.Cells["J3:J4"].Style.WrapText = true;

            ws.Cells["K3:K4"].Value = "Age";
            ws.Cells["K3:K4"].Merge = true;
            ws.Cells["K3:K4"].Style.Font.Bold = true;
            ws.Cells["K3:K4"].Style.WrapText = true;

            ws.Cells["L3:M3"].Value = "ADDRESS & CONTACT INFO";
            ws.Cells["L3:M3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["L3:M3"].Style.Font.Bold = true;
            ws.Cells["L3:M3"].Style.WrapText = true;
            ws.Cells["L3:M3"].Merge = true;

            ws.Cells["L4"].Value = "District";
            ws.Cells["L4"].Style.Font.Bold = true;
            ws.Cells["L4"].Style.WrapText = true;

            ws.Cells["M4"].Value = "VDC";
            ws.Cells["M4"].Style.Font.Bold = true;
            ws.Cells["M4"].Style.WrapText = true;

            ws.Cells["N3:N4"].Value = "Employment Type";
            ws.Cells["N3:N4"].Style.Font.Bold = true;
            ws.Cells["N3:N4"].Style.WrapText = true;
            ws.Cells["N3:N4"].Merge = true;

            ws.Cells["O3:O4"].Value = "Employed Organization";
            ws.Cells["O3:O4"].Merge = true;
            ws.Cells["O3:O4"].Style.Font.Bold = true;
            ws.Cells["O3:O4"].Style.WrapText = true;

            ws.Cells["P3:P4"].Value = "Working Country";
            ws.Cells["P3:P4"].Style.Font.Bold = true;
            ws.Cells["P3:P4"].Style.WrapText = true;
            ws.Cells["P3:P4"].Merge = true;

            ws.Cells["Q3:Q4"].Value = "Contact No.";
            ws.Cells["Q3:Q4"].Style.Font.Bold = true;
            ws.Cells["Q3:Q4"].Style.WrapText = true;
            ws.Cells["Q3:Q4"].Merge = true;

            ws.Cells["R3:R4"].Value = "Departure Date";
            ws.Cells["R3:R4"].Style.Font.Bold = true;
            ws.Cells["R3:R4"].Style.WrapText = true;
            ws.Cells["R3:R4"].Merge = true;

            ws.Cells[3, col, 4, col].Value = "Salary";
            ws.Cells[3, col, 4, col].Merge = true;
            ws.Cells[3, col, 4, col].Style.Font.Bold = true;
            ws.Cells[3, col, 4, col].Style.WrapText = true;

            ws.Cells[3, col+1, 4, col+1].Value = "Foreign Currency";
            ws.Cells[3, col+1, 4, col+1].Merge = true;
            ws.Cells[3, col+1, 4, col+1].Style.Font.Bold = true;
            ws.Cells[3, col+1, 4, col+1].Style.WrapText = true;

            ws.Cells[3, col+2, 4, col+2].Value = "Status";
            ws.Cells[3, col+2, 4, col+2].Merge = true;
            ws.Cells[3, col+2, 4, col+2].Style.Font.Bold = true;
            ws.Cells[3, col+2, 4, col+2].Style.WrapText = true;

            ws.Cells[3, col+3, 4, col+3].Value = "Recruitment Agency";
            ws.Cells[3, col+3, 4, col+3].Merge = true;
            ws.Cells[3, col+3, 4, col+3].Style.Font.Bold = true;
            ws.Cells[3, col+3, 4, col+3].Style.WrapText = true;

            #endregion

           

            #region Employment Record

            int row = 4;
            int count = 0;
            int i = 0;

            ws.Cells[3,1,3,col+3].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
            ws.Cells[3, 1, 3, col + 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[row, 1, row, col+3].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
            ws.Cells[row, 1, row, col+3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells[row, 1, row, col+3].Style.Border.Diagonal.Style = ExcelBorderStyle.Thin;


            dv = TRNEmploymentBO.GetEmploymentRegularReport(strOption, EthnicityID, DistrictID, EventID);

            foreach (DataRowView drv in dv)
            {
                row++;
                count++;


                ws.Cells[row, 1, row, col+3].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                ws.Cells[row, 1, row, col+3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[row, 1, row, col+3].Style.Border.Diagonal.Style = ExcelBorderStyle.Thin;

                string dtStartDate = dv.Table.Rows[i]["StartDate"].ToString();
                string[] Startdate = dtStartDate.Split(' ');

                string dtEndDate = dv.Table.Rows[i]["EndDate"].ToString();
                string[] Enddate = dtEndDate.Split(' ');

                string dtDepartureDate = dv.Table.Rows[i]["DepartureDate"].ToString();
                string[] DepartureDate = dtDepartureDate.Split(' ');

                if (dv.Count > 0)
                {
                    ws.Cells[row, 1].Value = count;
                    ws.Cells[row, 2].Value = dv.Table.Rows[i]["Batch"].ToString();
                    ws.Cells[row, 3].Value = dv.Table.Rows[i]["TrainingAgency"].ToString();
                    ws.Cells[row, 4].Value = dv.Table.Rows[i]["EventID"].ToString();
                    ws.Cells[row, 5].Value = dv.Table.Rows[i]["TradeName"].ToString();
                    ws.Cells[row, 6].Value = GetDateFormated.Get(Startdate[0]);
                    ws.Cells[row, 7].Value = GetDateFormated.Get(Enddate[0]);
                    ws.Cells[row, 8].Value = dv.Table.Rows[i]["Name"].ToString();
                    ws.Cells[row, 9].Value = dv.Table.Rows[i]["EthnicityNameNP"].ToString();
                    ws.Cells[row, 10].Value = dv.Table.Rows[i]["Gender"].ToString();
                    ws.Cells[row, 11].Value = dv.Table.Rows[i]["CurrentAge"].ToString();
                    ws.Cells[row, 12].Value = dv.Table.Rows[i]["DistrictName"].ToString();
                    ws.Cells[row, 13].Value = dv.Table.Rows[i]["VDCName"].ToString();
                    ws.Cells[row, 14].Value = dv.Table.Rows[i]["EmploymentType"].ToString();
                    ws.Cells[row, 15].Value = dv.Table.Rows[i]["Organization"].ToString();
                    ws.Cells[row, 16].Value = dv.Table.Rows[i]["CountryName"].ToString();
                    ws.Cells[row, 17].Value = dv.Table.Rows[i]["PhoneNumber"].ToString();
                    ws.Cells[row, 18].Value = DepartureDate[0].ToString();

                    ws.Cells[row, col].Value = dv.Table.Rows[i]["Salary"].ToString();
                    ws.Cells[row, col + 1].Value = dv.Table.Rows[i]["Currency"].ToString();
                    ws.Cells[row, col + 2].Value = dv.Table.Rows[i]["EmploymentStatus"].ToString();
                    ws.Cells[row, col + 3].Value = dv.Table.Rows[i]["RecruitmentAgency"].ToString();

                    int TraineeID = Convert.ToInt32(dv.Table.Rows[i]["ID"]);

                    DataView objCheckList = new TRNCheckListBO().GetCheckListByTraineeID(TraineeID);
                    List<String> lstCheckList = new List<String>();

                    foreach (DataRowView drvCheckList in objCheckList)
                    {
                        string a = drvCheckList["Checklist"].ToString();
                        lstCheckList.Add(a);
                    }

                    int column = 18;
                    for (int j = 0; j < dvCheckList.Count; j++)
                    {
                        if (lstCheckList.Exists(delegate(String region) { return region == dvCheckList.Table.Rows[j][1].ToString(); }))
                        {
                            ws.Cells[row, column].Value = "√";
                        }
                        else
                            ws.Cells[row, column].Value = "NA";

                        column++;
                    }

                    i++;
                }

            }

            #endregion

            Response.Clear();
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Employment Regular Report.xlsx");
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}