using SaMI.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaMI.Web.Reports
{
    public partial class ReportICC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDistrict();
                GetTotalVisitorsRecord();
                //GetTotalVisitorsDistrictRecord();
            }
        }

        private void LoadDistrict()
        {
            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();

            ddlDistrictVisitors.DataSource = DistrictBO.GetAll(true);
            ddlDistrictVisitors.DataValueField = "DistrictID";
            ddlDistrictVisitors.DataTextField = "DistrictName";
            ddlDistrictVisitors.DataBind();
        }

        private void GetRecord()
        {
            int NoOfMen = 0;
            int NoOfWomen = 0;
            int monthIndex;
            string date = "";
            string dateValue = "";

            if (txtDate.Text != String.Empty)
            {
                dateValue = txtDate.Text;
                string[] dateArray = dateValue.Split(' ');
                string Month = dateArray[0];
                string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                monthIndex = Array.IndexOf(MonthNames, Month) + 1;

                if (monthIndex < 10)
                {
                    date = dateArray[1] + "-0" + monthIndex.ToString();
                }
                else
                {
                    date = dateArray[1] + "-" + monthIndex.ToString();
                }
            }
            
            List<List<String>> lstRecords = new List<List<string>>();

            lstRecords = SaMIProfileBO.GetCountRecord("Dalit", "M", date, 0);
            if (lstRecords.Count > 0)
            {
                lblDalitHillMale.Text = lstRecords[1][0];
                lblDalitMadheshMale.Text = lstRecords[1][1];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Dalit", "F", date, 0);
            if (lstRecords.Count > 0)
            {
                lblDalitHillFemale.Text = lstRecords[1][0];
                lblDalitMadheshFemale.Text = lstRecords[1][1];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Janajati", "M", date, 0);
            if (lstRecords.Count > 0)
            {
                lblJanajatiMountainMale.Text = lstRecords[1][0];
                lblJanajatiHillMale.Text = lstRecords[1][1];
                lblJanajatiMadheshMale.Text = lstRecords[1][2];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]) + Convert.ToInt32(lstRecords[1][2]);
            }


            lstRecords = SaMIProfileBO.GetCountRecord("Janajati", "F", date, 0);
            if (lstRecords.Count > 0)
            {
                lblJanajatiMountainFemale.Text = lstRecords[1][0];
                lblJanajatiHillFemale.Text = lstRecords[1][1];
                lblJanajatiMadheshFemale.Text = lstRecords[1][2];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]) + Convert.ToInt32(lstRecords[1][2]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Janajati Newar", "M", date, 0);
            if (lstRecords.Count > 0)
            {
                lblJanajatiNewarDiscMale.Text = lstRecords[1][0];
                lblJanajatiNewarNonDiscMale.Text = lstRecords[1][1];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Janajati Newar", "F", date, 0);
            if (lstRecords.Count > 0)
            {
                lblJanajatiNewarDiscFemale.Text = lstRecords[1][0];
                lblJanajatiNewarNonDiscFemale.Text = lstRecords[1][1];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Brahmin", "M", date, 0);
            if (lstRecords.Count > 0)
            {
                lblBrahminHillMale.Text = lstRecords[1][0];
                lblBrahminMadheshMale.Text = lstRecords[1][1];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Brahmin", "F", date, 0);
            if (lstRecords.Count > 0)
            {
                lblBrahminHillFemale.Text = lstRecords[1][0];
                lblBrahminMadheshFemale.Text = lstRecords[1][1];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Chhetri", "M", date, 0);
            if (lstRecords.Count > 0)
            {
                lblChhetriHillMale.Text = lstRecords[1][0];
                lblChhetriMadheshMale.Text = lstRecords[1][1];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Chhetri", "F", date, 0);
            if (lstRecords.Count > 0)
            {
                lblChhetriHillFemale.Text = lstRecords[1][0];
                lblChhetriMadheshFemale.Text = lstRecords[1][1];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Thakuri", "M", date, 0);
            if (lstRecords.Count > 0)
            {
                lblThakuriHillMale.Text = lstRecords[1][0];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Thakuri", "F", date, 0);
            if (lstRecords.Count > 0)
            {
                lblThakuriHillFemale.Text = lstRecords[1][0];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Other Madesh Caste and Ethnicity", "M", date, 0);
            if (lstRecords.Count > 0)
            {
                lblOtherMale.Text = lstRecords[1][0];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Other Madesh Caste and Ethnicity", "F", date, 0);
            if (lstRecords.Count > 0)
            {
                lblOtherFemale.Text = lstRecords[1][0];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]);
            }

            lblNoOfMen.Text = NoOfMen.ToString();
            lblNoOfFemale.Text = NoOfWomen.ToString();
            lblGrandTotal.Text = (Convert.ToInt32(NoOfMen.ToString()) + Convert.ToInt32(NoOfWomen.ToString())).ToString();
            lblNoOfParticipants.Text = lblGrandTotal.Text;
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            //int monthIndex;
            //string RegistrationDate = "";
            //if (txtDate.Text != String.Empty)
            //{
            //    date = txtDate.Text;
            //    string[] dateArray = date.Split(' ');
            //    string Month = dateArray[0];
            //    string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            //    monthIndex = Array.IndexOf(MonthNames, Month) + 1;

            //    if (monthIndex < 10)
            //    {
            //        RegistrationDate = dateArray[1] + "-0" + monthIndex.ToString();
            //    }
            //    else
            //    {
            //        RegistrationDate = dateArray[1] + "-" + monthIndex.ToString();
            //    }
            //}
            //else
            //{
            //    RegistrationDate = "";
            //}
            GetRecord();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRecordForYearAndDistrict();
        }

        protected void txtDateDistrict_TextChanged(object sender, EventArgs e)
        {
            GetRecordForYearAndDistrict();
        }

        private void GetRecordForYearAndDistrict()
        {
            int NoOfMen = 0;
            int NoOfWomen = 0;
            int District = 0;
            int monthIndex;
            string date = "";
            string dateValue = "";

            if (txtDateDistrict.Text != "")
            {
                dateValue = txtDateDistrict.Text;
                string[] dateArray = dateValue.Split(' ');
                string Month = dateArray[0];
                string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                monthIndex = Array.IndexOf(MonthNames, Month) + 1;

                if (monthIndex < 10)
                {
                    date = dateArray[1] + "-0" + monthIndex.ToString();
                }
                else
                {
                    date = dateArray[1] + "-" + monthIndex.ToString();
                }
            }
            if (!string.IsNullOrEmpty(ddlDistrict.SelectedValue))
                District = Convert.ToInt32(ddlDistrict.SelectedValue);
            
            List<List<String>> lstRecords = new List<List<string>>();

            lstRecords = SaMIProfileBO.GetCountRecord("Dalit", "M", date, District);
            if (lstRecords.Count > 0)
            {
                lblDalitHillMaleDistrict.Text = lstRecords[1][0];
                lblDalitMadheshMaleDistrict.Text = lstRecords[1][1];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Dalit", "F", date, District);
            if (lstRecords.Count > 0)
            {
                lblDalitHillFemaleDistrict.Text = lstRecords[1][0];
                lblDalitMadheshFemaleDistrict.Text = lstRecords[1][1];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Janajati", "M", date, District);
            if (lstRecords.Count > 0)
            {
                lblJanajatiMountainMaleDistrict.Text = lstRecords[1][0];
                lblJanajatiHillMaleDistrict.Text = lstRecords[1][1];
                lblJanajatiMadheshMaleDistrict.Text = lstRecords[1][2];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]) + Convert.ToInt32(lstRecords[1][2]);
            }


            lstRecords = SaMIProfileBO.GetCountRecord("Janajati", "F", date, District);
            if (lstRecords.Count > 0)
            {
                lblJanajatiMountainFemaleDistrict.Text = lstRecords[1][0];
                lblJanajatiHillFemaleDistrict.Text = lstRecords[1][1];
                lblJanajatiMadheshFemaleDistrict.Text = lstRecords[1][2];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]) + Convert.ToInt32(lstRecords[1][2]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Janajati Newar", "M", date, District);
            if (lstRecords.Count > 0)
            {
                lblJanajatiNewarDiscMaleDistrict.Text = lstRecords[1][0];
                lblJanajatiNewarNonDiscMaleDistrict.Text = lstRecords[1][1];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Janajati Newar", "F", date, District);
            if (lstRecords.Count > 0)
            {
                lblJanajatiNewarDiscFemaleDistrict.Text = lstRecords[1][0];
                lblJanajatiNewarNonDiscFemaleDistrict.Text = lstRecords[1][1];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Brahmin", "M", date, District);
            if (lstRecords.Count > 0)
            {
                lblBrahminHillMaleDistrict.Text = lstRecords[1][0];
                lblBrahminMadheshMaleDistrict.Text = lstRecords[1][1];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Brahmin", "F", date, District);
            if (lstRecords.Count > 0)
            {
                lblBrahminHillFemaleDistrict.Text = lstRecords[1][0];
                lblBrahminMadheshFemaleDistrict.Text = lstRecords[1][1];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Chhetri", "M", date, District);
            if (lstRecords.Count > 0)
            {
                lblChhetriHillMaleDistrict.Text = lstRecords[1][0];
                lblChhetriMadheshMaleDistrict.Text = lstRecords[1][1];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Chhetri", "F", date, District);
            if (lstRecords.Count > 0)
            {
                lblChhetriHillFemaleDistrict.Text = lstRecords[1][0];
                lblChhetriMadheshFemaleDistrict.Text = lstRecords[1][1];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]) + Convert.ToInt32(lstRecords[1][1]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Thakuri", "M", date, District);
            if (lstRecords.Count > 0)
            {
                lblThakuriHillMaleDistrict.Text = lstRecords[1][0];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Thakuri", "F", date, District);
            if (lstRecords.Count > 0)
            {
                lblThakuriHillFemaleDistrict.Text = lstRecords[1][0];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Other Madesh Caste and Ethnicity", "M", date, District);
            if (lstRecords.Count > 0)
            {
                lblOtherMaleDistrict.Text = lstRecords[1][0];
                NoOfMen = NoOfMen + Convert.ToInt32(lstRecords[1][0]);
            }

            lstRecords = SaMIProfileBO.GetCountRecord("Other Madesh Caste and Ethnicity", "F", date, District);
            if (lstRecords.Count > 0)
            {
                lblOtherFemaleDistrict.Text = lstRecords[1][0];
                NoOfWomen = NoOfWomen + Convert.ToInt32(lstRecords[1][0]);
            }

            lblNoOfMenDistrict.Text = NoOfMen.ToString();
            lblNoOfFemaleDistrict.Text = NoOfWomen.ToString();
            lblGrandTotalDistrict.Text = (Convert.ToInt32(NoOfMen.ToString()) + Convert.ToInt32(NoOfWomen.ToString())).ToString();
            lblNoOfParticipantsDistrict.Text = lblGrandTotalDistrict.Text;
        }

        public string GetTotalVisitorsRecord()
        {
            DataView dvDate = SaMIProfileBO.GetDate();
            String date = "";
            String tdData = "";
            DataView dvTotalVisitors;

            foreach (DataRowView drvDate in dvDate)
            {
                date = drvDate["Date"].ToString();
                dvTotalVisitors = SaMIProfileBO.GetTotalVisitorsRecord(date);
                tdData += "<tr>";
                tdData += "<td>" + date + "</td>";
                tdData += "<td>" + dvTotalVisitors.Table.Rows[0]["TotalMen"].ToString() + "</td>";
                tdData += "<td>" + dvTotalVisitors.Table.Rows[0]["TotalFemale"].ToString() + "</td>";
                tdData += "<td>" + dvTotalVisitors.Table.Rows[0]["Total"].ToString() + "</td>";
                tdData += "</tr>";
            }
            return tdData;
        }

        public string GetTotalVisitorsDistrictRecord()
        {
            DataView dvDate = SaMIProfileBO.GetDate();
            String date = "";
            String tdDistrictData = "";
            int districtID = 0;
            DataView dvTotalVisitorsDistrict;
            DataView dvTotalVisitors;
            if (ddlDistrictVisitors.SelectedIndex > 0)
            {
                districtID = Convert.ToInt32(ddlDistrictVisitors.SelectedValue);
            }

            if (districtID > 0)
            {
                foreach (DataRowView drvDate in dvDate)
                {
                    date = drvDate["Date"].ToString();
                    dvTotalVisitorsDistrict = SaMIProfileBO.GetTotalVisitorsDistrictRecord(date, districtID);
                    tdDistrictData += "<tr>";
                    tdDistrictData += "<td>" + date + "</td>";
                    tdDistrictData += "<td>" + dvTotalVisitorsDistrict.Table.Rows[0]["TotalMen"].ToString() + "</td>";
                    tdDistrictData += "<td>" + dvTotalVisitorsDistrict.Table.Rows[0]["TotalFemale"].ToString() + "</td>";
                    tdDistrictData += "<td>" + dvTotalVisitorsDistrict.Table.Rows[0]["Total"].ToString() + "</td>";
                    tdDistrictData += "</tr>";
                }
            }
            else
            {
                foreach (DataRowView drvDate in dvDate)
                {
                    date = drvDate["Date"].ToString();
                    dvTotalVisitors = SaMIProfileBO.GetTotalVisitorsRecord(date);
                    tdDistrictData += "<tr>";
                    tdDistrictData += "<td>" + date + "</td>";
                    tdDistrictData += "<td>" + dvTotalVisitors.Table.Rows[0]["TotalMen"].ToString() + "</td>";
                    tdDistrictData += "<td>" + dvTotalVisitors.Table.Rows[0]["TotalFemale"].ToString() + "</td>";
                    tdDistrictData += "<td>" + dvTotalVisitors.Table.Rows[0]["Total"].ToString() + "</td>";
                    tdDistrictData += "</tr>";
                    //lblVisitorsYearDistrict.Text = date;
                    //lblVisitorsMenDistrict.Text = dvTotalVisitors.Table.Rows[0]["TotalMen"].ToString();
                    //lblVisitorsWomenDistrict.Text = dvTotalVisitors.Table.Rows[0]["TotalFemale"].ToString();
                    //lblVisitorsTotalDistrict.Text = dvTotalVisitors.Table.Rows[0]["Total"].ToString();
                }
            }
            return tdDistrictData;
        }

        protected void ddlDistrictVisitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetTotalVisitorsDistrictRecord();
        }
    }
}