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
using SaMI.Web.Training;

namespace SaMI.Web.Reports
{
    public partial class PhoneFollowUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOptions();

                if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "KTMUSER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
                {
                    ddlDistrict.Enabled = true;
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                }
                else
                {
                    ddlDistrict.Enabled = false;
                    ddlOrganization.SelectedValue = UserAuthentication.GetSaMIOrganizationId(this.Page).ToString();
                    ddlDistrict.SelectedValue = UserAuthentication.GetDistrictId(this.Page).ToString();
                }

                if (UserAuthentication.GetUserType(this.Page) == "USER")
                {
                    ddlOrganization.SelectedValue = UserAuthentication.GetSaMIOrganizationId(this.Page).ToString();
                    ddlOrganization.Enabled = false;
                }
                else
                {
                    ddlOrganization.Enabled = true;
                }

                LoadPhoneFollowUpReport();
                
            }
        }

        // Bind Data On Grid View
        protected void LoadPhoneFollowUpReport()
        {
            gvPhoneFollowUp.DataSource = null;
            gvPhoneFollowUp.DataBind();
            
            string RegistrationDateFrom = string.Empty;
            string RegistrationDateTo = string.Empty;
            int SaMIOrganizationID = 0;
            int districtID = 0;

            if (!string.IsNullOrEmpty(txtRegistrationDateFrom.Text))
                RegistrationDateFrom = txtRegistrationDateFrom.Text;
            if (!string.IsNullOrEmpty(txtRegistrationDateTo.Text))
                RegistrationDateTo = txtRegistrationDateTo.Text;

           if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                districtID = Convert.ToInt32(ddlDistrict.SelectedValue);

           if (!string.IsNullOrEmpty(ddlOrganization.SelectedValue))
               SaMIOrganizationID = Convert.ToInt32(ddlOrganization.SelectedValue);

           DataView dvPhoneFollowUpReport = PhoneFollowUpBO.GetPhoneFollowUpRecord(districtID, SaMIOrganizationID, RegistrationDateFrom, RegistrationDateTo);


            if (dvPhoneFollowUpReport != null)
            {
                gvPhoneFollowUp.DataSource = dvPhoneFollowUpReport;
                gvPhoneFollowUp.DataBind();
            }

            //Get Record Count

            DataView dvTotalCount = PhoneFollowUpBO.CountPhoneFollowUpRecord(districtID, SaMIOrganizationID, RegistrationDateFrom, RegistrationDateTo);
            if (dvTotalCount.Count > 0)
            {
                int totalCount = Convert.ToInt32(dvTotalCount.Table.Rows[0]["Count"]);
                lblNoOfRecords.Text = totalCount.ToString();
            }
        }

        void LoadOptions()
        {
            
            if (UserAuthentication.GetUserType(this.Page) == "USER" || UserAuthentication.GetUserType(this.Page) == "CASEUSR" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                int DistrictID = UserAuthentication.GetDistrictId(this.Page);
                ddlOrganization.DataSource = SaMIOrganizationBO.GetByDistrictID(DistrictID);
                ddlOrganization.DataValueField = "SaMIOrganizationID";
                ddlOrganization.DataTextField = "SaMIOrganizationName";
                ddlOrganization.DataBind();
            }

            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();
        }

        protected void txtRegistrationDate_TextChanged(object sender, EventArgs e)
        {
            LoadPhoneFollowUpReport();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserType(this.Page) == "ADMIN")
            {
                ddlOrganization.DataSource = SaMIOrganizationBO.GetOrganizationByDistrictID(Convert.ToInt32(ddlDistrict.SelectedValue), "[Organization]");
                ddlOrganization.DataValueField = "SaMIOrganizationID";
                ddlOrganization.DataTextField = "SaMIOrganizationName";
                ddlOrganization.DataBind();
            }
            else
            {
                int DistrictID = UserAuthentication.GetDistrictId(this.Page);
                ddlOrganization.DataSource = SaMIOrganizationBO.GetOrganizationByDistrictID(DistrictID, "[Organization]");
                ddlOrganization.DataValueField = "SaMIOrganizationID";
                ddlOrganization.DataTextField = "SaMIOrganizationName";
                ddlOrganization.DataBind();
            }

            LoadPhoneFollowUpReport();
        }

        protected void ddlOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhoneFollowUpReport();
        }

        protected void gvPhoneFollowUp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPhoneFollowUp.PageIndex = e.NewPageIndex;
            LoadPhoneFollowUpReport();
            Session["pageNumber"] = e.NewPageIndex;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelPackage pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("$Sheet1");

            #region Heading

            ws.Cells["B2:E2"].Value = "ICC Phone Follow up format";
            ws.Cells["B2:E2"].Merge = true;
            ws.Cells["B2:E2"].Style.Font.Bold = true;
            ws.Cells["B2:E2"].Style.Font.Size = 20;

            ws.Cells["B3"].Value = "Working Country";
            ws.Cells["B3"].Merge = true;
            ws.Cells["B3"].Style.Font.Bold = true;
            ws.Cells["B3"].Style.WrapText = true;
            ws.Cells["B3"].Worksheet.DefaultColWidth = 20;

            ws.Cells["B4"].Value = "Name of Organization";
            ws.Cells["B4"].Merge = true;
            ws.Cells["B4"].Style.Font.Bold = true;
            ws.Cells["B4"].Style.WrapText = true;

            ws.Cells["B5"].Value = "Reporting period";
            ws.Cells["B5"].Merge = true;
            ws.Cells["B5"].Style.Font.Bold = true;
            ws.Cells["B5"].Style.WrapText = true;

            ws.Cells["A8:A9"].Value = "S.N.";
            ws.Cells["A8:A9"].Merge = true;
            ws.Cells["A8:A9"].Style.Font.Bold = true;

            ws.Cells["B8:B9"].Value = "Name & Address";
            ws.Cells["B8:B9"].Merge = true;
            ws.Cells["B8:B9"].Style.Font.Bold = true;
            ws.Cells["B8:B9"].Style.WrapText = true;

            ws.Cells["C8:C9"].Value = "ICC Visited Date";
            ws.Cells["C8:C9"].Merge = true;
            ws.Cells["C8:C9"].Style.Font.Bold = true;
            ws.Cells["C8:C9"].Style.WrapText = true;

            ws.Cells["D8:D9"].Value = "Left for foreign employment\nYes/No";
            ws.Cells["D8:D9"].Merge = true;
            ws.Cells["D8:D9"].Style.Font.Bold = true;
            ws.Cells["D8:D9"].Style.WrapText = true;

            ws.Cells["E8:I8"].Value = "If not, current status of visitors";
            ws.Cells["E8:I8"].Merge = true;
            ws.Cells["E8:I8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["E8:I8"].Style.Font.Bold = true;
            ws.Cells["E8:I8"].Style.WrapText = true;

            ws.Cells["E9"].Value = "Decided not to go";
            ws.Cells["E9"].Style.Font.Bold = true;
            ws.Cells["E9"].Style.WrapText = true;

            ws.Cells["F9"].Value = "Started working in Nepal";
            ws.Cells["F9"].Style.Font.Bold = true;
            ws.Cells["F9"].Style.WrapText = true;

            ws.Cells["G9"].Value = "In process of migration";
            ws.Cells["G9"].Style.Font.Bold = true;
            ws.Cells["G9"].Style.WrapText = true;

            ws.Cells["H9"].Value = "Unsuccess migration";
            ws.Cells["H9"].Style.Font.Bold = true;
            ws.Cells["H9"].Style.WrapText = true;

            ws.Cells["I9"].Value = "Other";
            ws.Cells["I9"].Style.Font.Bold = true;
            ws.Cells["I9"].Style.WrapText = true;

            ws.Cells["J8:J9"].Value = "If migrated contract number of destination country";
            ws.Cells["J8:J9"].Merge = true;
            ws.Cells["J8:J9"].Style.Font.Bold = true;
            ws.Cells["J8:J9"].Style.WrapText = true;

            ws.Cells["K8:K9"].Value = "Family contract number";
            ws.Cells["K8:K9"].Merge = true;
            ws.Cells["K8:K9"].Style.Font.Bold = true;
            ws.Cells["K8:K9"].Style.WrapText = true;

            ws.Cells["L8:L9"].Value = "Country of migration";
            ws.Cells["L8:L9"].Merge = true;
            ws.Cells["L8:L9"].Style.Font.Bold = true;
            ws.Cells["L8:L9"].Style.WrapText = true;

            ws.Cells["M8:M9"].Value = "Date of migration";
            ws.Cells["M8:M9"].Merge = true;
            ws.Cells["M8:M9"].Style.Font.Bold = true;
            ws.Cells["M8:M9"].Style.WrapText = true;

            ws.Cells["N8:N9"].Value = "Migrated after training\nYes/No";
            ws.Cells["N8:N9"].Merge = true;
            ws.Cells["N8:N9"].Style.Font.Bold = true;
            ws.Cells["N8:N9"].Style.WrapText = true;

            ws.Cells["O8:O9"].Value = "Name of Manpower or Agent";
            ws.Cells["O8:O9"].Merge = true;
            ws.Cells["O8:O9"].Style.Font.Bold = true;
            ws.Cells["O8:O9"].Style.WrapText = true;

            ws.Cells["P8:P9"].Value = "Amount paid for foreign employment";
            ws.Cells["P8:P9"].Merge = true;
            ws.Cells["P8:P9"].Style.Font.Bold = true;
            ws.Cells["P8:P9"].Style.WrapText = true;

            ws.Cells["Q8:Q9"].Value = "Source of investment(Self/Loan/Sale property)";
            ws.Cells["Q8:Q9"].Merge = true;
            ws.Cells["Q8:Q9"].Style.Font.Bold = true;
            ws.Cells["Q8:Q9"].Style.WrapText = true;

            ws.Cells["R8:R9"].Value = "Receipt received from manpower\nYes/No";
            ws.Cells["R8:R9"].Merge = true;
            ws.Cells["R8:R9"].Style.Font.Bold = true;
            ws.Cells["R8:R9"].Style.WrapText = true;

            ws.Cells["S8:S9"].Value = "Left document before departure\nYes/No";
            ws.Cells["S8:S9"].Merge = true;
            ws.Cells["S8:S9"].Style.Font.Bold = true;
            ws.Cells["S8:S9"].Style.WrapText = true;

            ws.Cells["T8:T9"].Value = "Same work as per agreement\nYes/No";
            ws.Cells["T8:T9"].Merge = true;
            ws.Cells["T8:T9"].Style.Font.Bold = true;
            ws.Cells["T8:T9"].Style.WrapText = true;

            ws.Cells["U8:U9"].Value = "Same salary/wage as per agreement\nYes/No";
            ws.Cells["U8:U9"].Merge = true;
            ws.Cells["U8:U9"].Style.Font.Bold = true;
            ws.Cells["U8:U9"].Style.WrapText = true;

            ws.Cells["V8:V9"].Value = "Additional information found during follow up";
            ws.Cells["V8:V9"].Merge = true;
            ws.Cells["V8:V9"].Style.Font.Bold = true;
            ws.Cells["V8:V9"].Style.WrapText = true;

            ws.Cells["W8:W9"].Value = "Recommendation";
            ws.Cells["W8:W9"].Merge = true;
            ws.Cells["W8:W9"].Style.Font.Bold = true;
            ws.Cells["W8:W9"].Style.WrapText = true;

            ws.Cells["X8:X9"].Value = "Name of informants";
            ws.Cells["X8:X9"].Merge = true;
            ws.Cells["X8:X9"].Style.Font.Bold = true;
            ws.Cells["X8:X9"].Style.WrapText = true;

            ws.Cells["Y8:Y9"].Value = "Relation with migrants";
            ws.Cells["Y8:Y9"].Merge = true;
            ws.Cells["Y8:Y9"].Style.Font.Bold = true;
            ws.Cells["Y8:Y9"].Style.WrapText = true;

            ws.Cells["Z8:Z9"].Value = "Date of follow up";
            ws.Cells["Z8:Z9"].Merge = true;
            ws.Cells["Z8:Z9"].Style.Font.Bold = true;
            ws.Cells["Z8:Z9"].Style.WrapText = true;

            ws.Cells["AA8:AA9"].Value = "Remarks";
            ws.Cells["AA8:AA9"].Merge = true;
            ws.Cells["AA8:AA9"].Style.Font.Bold = true;
            ws.Cells["AA8:AA9"].Style.WrapText = true;

            #endregion

            #region Data

            int row = 9;
            int count = 0;
            int i = 0;

            string RegistrationDateFrom = string.Empty;
            string RegistrationDateTo = string.Empty;
            int SaMIOrganizationID = 0;
            int districtID = 0;

            if (!string.IsNullOrEmpty(txtRegistrationDateFrom.Text))
                RegistrationDateFrom = txtRegistrationDateFrom.Text;
            if (!string.IsNullOrEmpty(txtRegistrationDateTo.Text))
                RegistrationDateTo = txtRegistrationDateTo.Text;

           if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                districtID = Convert.ToInt32(ddlDistrict.SelectedValue);

           if (!string.IsNullOrEmpty(ddlOrganization.SelectedValue))
               SaMIOrganizationID = Convert.ToInt32(ddlOrganization.SelectedValue);

           String district = "", organization = "";
           if (ddlDistrict.SelectedItem.Text != "[District]")
               district = ddlDistrict.SelectedItem.Text;
           if (ddlOrganization.SelectedItem.Text != "[Organization]")
               organization = ddlOrganization.SelectedItem.Text;

           ws.Cells["C3"].Value = district;
           ws.Cells["C4"].Value = organization;
           if (!string.IsNullOrEmpty(txtRegistrationDateFrom.Text))
           {
               if (!string.IsNullOrEmpty(txtRegistrationDateTo.Text))
                   ws.Cells["C5"].Value = "From " + RegistrationDateFrom + " To  " + RegistrationDateTo;
               else
                   ws.Cells["C5"].Value = "From " + RegistrationDateFrom;
           }

           DataView dv = PhoneFollowUpBO.GetPhoneFollowUpRecord(districtID, SaMIOrganizationID, RegistrationDateFrom, RegistrationDateTo);

           foreach (DataRowView drv in dv)
           {
               row++;
               count++;
               if (dv != null)
               {
                   ws.Cells[row, 1].Value = count;
                   ws.Cells[row, 2].Value = dv.Table.Rows[i]["NameAndAddress"].ToString();

                   string dtRegistrationDate = dv.Table.Rows[i]["RegistrationDate"].ToString();
                   string[] RegistrationDate = dtRegistrationDate.Split(' ');

                   ws.Cells[row, 3].Value = GetDateFormated.Get(RegistrationDate[0]);
                   ws.Cells[row, 4].Value = dv.Table.Rows[i]["LeftForFE"].ToString();
                   if(dv.Table.Rows[i]["VisitorsCurrentStatus"].ToString()=="Decidednottogo")
                        ws.Cells[row, 5].Value = "Yes";
                   else
                       ws.Cells[row, 5].Value = "";
                    if(dv.Table.Rows[i]["VisitorsCurrentStatus"].ToString()=="StartedWorkingInNepal")
                        ws.Cells[row, 6].Value = "Yes";
                   else
                       ws.Cells[row, 6].Value = "";
                    if(dv.Table.Rows[i]["VisitorsCurrentStatus"].ToString()=="Inprocessofmigration")
                        ws.Cells[row, 7].Value = "Yes";
                   else
                       ws.Cells[row, 7].Value = "";
                    if(dv.Table.Rows[i]["VisitorsCurrentStatus"].ToString()=="Unsuccessmigration")
                        ws.Cells[row, 8].Value = "Yes";
                   else
                       ws.Cells[row, 8].Value = "";
                    if(dv.Table.Rows[i]["VisitorsCurrentStatus"].ToString()=="Other")
                        ws.Cells[row, 9].Value = "Yes";
                   else
                       ws.Cells[row, 9].Value = "";
                   ws.Cells[row, 10].Value = dv.Table.Rows[i]["ContractNumber"].ToString();
                   ws.Cells[row, 11].Value = dv.Table.Rows[i]["FamilyMemberPhone"].ToString();
                   ws.Cells[row, 12].Value = dv.Table.Rows[i]["MigratedCountry"].ToString();

                   string dtMigratedDate = dv.Table.Rows[i]["MigratedDate"].ToString();
                   string[] MigratedDate = dtMigratedDate.Split(' ');

                   ws.Cells[row, 13].Value = GetDateFormated.Get(MigratedDate[0]);
                   ws.Cells[row, 14].Value = dv.Table.Rows[i]["MigratedAfterTraining"].ToString();
                   ws.Cells[row, 15].Value = dv.Table.Rows[i]["ManpowerAgent"].ToString();
                   ws.Cells[row, 16].Value = dv.Table.Rows[i]["AmountPaidforFE"].ToString();

                   string sourceOfInvestment = "";
                   if (dv.Table.Rows[i]["SourceOfInvestment"].ToString() != "")
                   {
                       if (dv.Table.Rows[i]["SourceOfInvestment"].ToString().Substring(0, 1) == ",")
                           sourceOfInvestment = dv.Table.Rows[i]["SourceOfInvestment"].ToString().Substring(1);
                       else
                           sourceOfInvestment = dv.Table.Rows[i]["SourceOfInvestment"].ToString();
                   }
                   
                   ws.Cells[row, 17].Value = sourceOfInvestment;
                   ws.Cells[row, 18].Value = dv.Table.Rows[i]["ReceiptReceivedFromManpower"].ToString();
                   ws.Cells[row, 19].Value = dv.Table.Rows[i]["LeftDocumentBeforeDeparture"].ToString();
                   ws.Cells[row, 20].Value = dv.Table.Rows[i]["SameWorkAsAgreement"].ToString();
                   ws.Cells[row, 21].Value = dv.Table.Rows[i]["SameSalaryAsAgreement"].ToString();
                   ws.Cells[row, 22].Value = dv.Table.Rows[i]["AdditionalInfo"].ToString();
                   ws.Cells[row, 23].Value = dv.Table.Rows[i]["Recommendation"].ToString();
                   ws.Cells[row, 24].Value = dv.Table.Rows[i]["InformantsName"].ToString();
                   ws.Cells[row, 25].Value = dv.Table.Rows[i]["MigrantRelation"].ToString();

                   string dtFollowUpDate = dv.Table.Rows[i]["FollowUpDate"].ToString();
                   string[] FollowUpDate = dtFollowUpDate.Split(' ');

                   ws.Cells[row, 26].Value = GetDateFormated.Get(FollowUpDate[0]);
                   //ws.Cells[row, 26].Value = dv.Table.Rows[i]["FollowUpDate"].ToString();
                   ws.Cells[row, 27].Value = dv.Table.Rows[i]["Remarks"].ToString();
               }
               i++;
           }

            #endregion

            Response.Clear();
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.AddHeader("content-disposition", "attachment;filename=Phone Follow Up.xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}