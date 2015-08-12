using SaMI.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaMI.Web.Reports
{
    public partial class ReportPhoneFollowUp : System.Web.UI.Page
    {
        String Year2 = String.Empty;
        int DistrictId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDistricts();
            }
        }

        private void LoadDistricts()
        {
            ddlDistrict.DataSource = DistrictBO.GetAll(true);
            ddlDistrict.DataValueField = "DistrictID";
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataBind();
        }

        protected void ddlYear1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Year1 = String.Empty;
            if (ddlYear1.SelectedIndex > 0)
            {
                Year1 = ddlYear1.Text;
                LoadPhoneFollowUpReport(Year1);
            }
        }

        protected void ddlYear2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhoneFollowUpReportYearAndDistrict();
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhoneFollowUpReportYearAndDistrict();
        }

        private void LoadPhoneFollowUpReport(string Year1)
        {
            DataView dvMale = PhoneFollowUpBO.GetReport("M", Year1, 0);
            DataView dvFemale = PhoneFollowUpBO.GetReport("F", Year1, 0);
            DataView dvTotal = PhoneFollowUpBO.GetReport("", Year1, 0);
            DataView dvTotalTraineePerYear = PhoneFollowUpBO.GetTotalTrainee(Year1, 0);
            int total = Convert.ToInt32(dvTotalTraineePerYear.Table.Rows[0]["TotalTrainee"]);

            #region Male
            if (dvMale.Count>0)
            {
                lblFollowUpMale.Text = dvMale.Table.Rows[0]["FollowUpNo"].ToString();
                lblLeftForFEMale.Text = dvMale.Table.Rows[0]["LeftForFENo"].ToString();
                //lblSkillTraineeMale.Text = dvMale.Table.Rows[0][""].ToString();
                lblLeftDocumentsMale.Text = dvMale.Table.Rows[0]["LeftDocumentNo"].ToString();
                //lblAskedReceiptsMale.Text = dvMale.Table.Rows[0][""].ToString();
                lblGotReceiptsMale.Text = dvMale.Table.Rows[0]["ReceiptReceivedNo"].ToString();
                lblPaidLessMale.Text = dvMale.Table.Rows[0]["PaidLessNo"].ToString();
                //lblPaidWithinGovtCeilingMale.Text = dvMale.Table.Rows[0][""].ToString();
                lblNotDecidedMale.Text = dvMale.Table.Rows[0]["NotDecidedMigratingNo"].ToString();
                lblNotLeftMale.Text = dvMale.Table.Rows[0]["NotLeftYetNo"].ToString();
                lblNotDecidedToGoMale.Text = dvMale.Table.Rows[0]["DecidedNotToGoNo"].ToString();
            }
            else
            {
                ClearRecordForMale();
            }
            #endregion
            #region Female
            if (dvFemale.Count > 0)
            {
                lblFollowUpFemale.Text = dvFemale.Table.Rows[0]["FollowUpNo"].ToString();
                lblLeftForFEFemale.Text = dvFemale.Table.Rows[0]["LeftForFENo"].ToString();
                //lblSkillTraineeFemale.Text = dvFemale.Table.Rows[0][""].ToString();
                lblLeftDocumentsFemale.Text = dvFemale.Table.Rows[0]["LeftDocumentNo"].ToString();
                //lblAskedReceiptsFemale.Text = dvFemale.Table.Rows[0][""].ToString();
                lblGotReceiptsFemale.Text = dvFemale.Table.Rows[0]["ReceiptReceivedNo"].ToString();
                lblPaidLessFemale.Text = dvFemale.Table.Rows[0]["PaidLessNo"].ToString();
                //lblPaidWithinGovtCeilingFemale.Text = dvFemale.Table.Rows[0][""].ToString();
                lblNotDecidedFemale.Text = dvFemale.Table.Rows[0]["NotDecidedMigratingNo"].ToString();
                lblNotLeftFemale.Text = dvFemale.Table.Rows[0]["NotLeftYetNo"].ToString();
                lblNotDecidedToGoFemale.Text = dvFemale.Table.Rows[0]["DecidedNotToGoNo"].ToString();
            }
            else
            {
                ClearRecordForFemale();
            }
            #endregion
            #region Total
            if (dvTotal.Count > 0)
            {
                lblFollowUpTotal.Text = dvTotal.Table.Rows[0]["FollowUpNo"].ToString();
                lblLeftForFETotal.Text = dvTotal.Table.Rows[0]["LeftForFENo"].ToString();
                //lblSkillTraineeTotal.Text = dvTotal.Table.Rows[0][""].ToString();
                lblLeftDocumentsTotal.Text = dvTotal.Table.Rows[0]["LeftDocumentNo"].ToString();
                //lblAskedReceiptsTotal.Text = dvTotal.Table.Rows[0][""].ToString();
                lblGotReceiptsTotal.Text = dvTotal.Table.Rows[0]["ReceiptReceivedNo"].ToString();
                lblPaidLessTotal.Text = dvTotal.Table.Rows[0]["PaidLessNo"].ToString();
                //lblPaidWithinGovtCeilingTotal.Text = dvTotal.Table.Rows[0][""].ToString();
                lblNotDecidedTotal.Text = dvTotal.Table.Rows[0]["NotDecidedMigratingNo"].ToString();
                lblNotLeftTotal.Text = dvTotal.Table.Rows[0]["NotLeftYetNo"].ToString();
                lblNotDecidedToGoTotal.Text = dvTotal.Table.Rows[0]["DecidedNotToGoNo"].ToString();

                #region Percentage
                lblFollowUpPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0]["FollowUpNo"]) / total) * 100).ToString();
                lblLeftForFEPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0]["LeftForFENo"]) / total) * 100).ToString();
                //lblSkillTraineePercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0][""])/total)*100).ToString();
                lblLeftDocumentsPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0]["LeftDocumentNo"]) / total) * 100).ToString();
                //lblAskedReceiptsPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0][""])/total)*100).ToString();
                lblGotReceiptsPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0]["ReceiptReceivedNo"]) / total) * 100).ToString();
                lblPaidLessPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0]["PaidLessNo"]) / total) * 100).ToString();
                //lblPaidWithinGovtCeilingPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0][""])/total)*100).ToString();
                lblNotDecidedPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0]["NotDecidedMigratingNo"]) / total) * 100).ToString();
                lblNotLeftPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0]["NotLeftYetNo"]) / total) * 100).ToString();
                lblNotDecidedToGoPercentage.Text = ((Convert.ToInt32(dvTotal.Table.Rows[0]["DecidedNotToGoNo"]) / total) * 100).ToString();
                #endregion
            }
            else
            {
                ClearTotalPerYear();
                ClearTotalPerYearPercentage();
            }
            #endregion
        }

        private void LoadPhoneFollowUpReportYearAndDistrict()
        {
            if (ddlYear2.SelectedIndex > 0)
            {
                Year2 = ddlYear2.Text;
            }
            if (ddlDistrict.SelectedIndex > 0)
            {
                DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
            }
            DataView dvMaleYearAndDistrict = PhoneFollowUpBO.GetReport("M", Year2, DistrictId);
            DataView dvFemaleYearAndDistrict = PhoneFollowUpBO.GetReport("F", Year2, DistrictId);
            DataView dvTotalYearAndDistrict = PhoneFollowUpBO.GetReport("", Year2, DistrictId);
            DataView dvTotal = PhoneFollowUpBO.GetTotalTrainee(Year2, DistrictId);
            int total = Convert.ToInt32(dvTotal.Table.Rows[0]["TotalTrainee"]);

            if (dvMaleYearAndDistrict.Count > 0)
            {
                lblFollowUpMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0]["FollowUpNo"].ToString();
                lblLeftForFEMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0]["LeftForFENo"].ToString();
                //lblSkillTraineeMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0][""].ToString();
                lblLeftDocumentsMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0]["LeftDocumentNo"].ToString();
                //lblAskedReceiptsMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0][""].ToString();
                lblGotReceiptsMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0]["ReceiptReceivedNo"].ToString();
                lblPaidLessMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0]["PaidLessNo"].ToString();
                //lblPaidWithinGovtCeilingMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0][""].ToString();
                lblNotDecidedMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0]["NotDecidedMigratingNo"].ToString();
                lblNotLeftMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0]["NotLeftYetNo"].ToString();
                lblNotDecidedToGoMaleDistrict.Text = dvMaleYearAndDistrict.Table.Rows[0]["DecidedNotToGoNo"].ToString();

            }
            else
            {
                ClearYearAndDistrictMale();
            }
            if (dvFemaleYearAndDistrict.Count > 0)
            {
                lblFollowUpFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0]["FollowUpNo"].ToString();
                lblLeftForFEFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0]["LeftForFENo"].ToString();
                //lblSkillTraineeFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0][""].ToString();
                lblLeftDocumentsFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0]["LeftDocumentNo"].ToString();
                //lblAskedReceiptsFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0][""].ToString();
                lblGotReceiptsFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0]["ReceiptReceivedNo"].ToString();
                lblPaidLessFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0]["PaidLessNo"].ToString();
                //lblPaidWithinGovtCeilingFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0][""].ToString();
                lblNotDecidedFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0]["NotDecidedMigratingNo"].ToString();
                lblNotLeftFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0]["NotLeftYetNo"].ToString();
                lblNotDecidedToGoFemaleDistrict.Text = dvFemaleYearAndDistrict.Table.Rows[0]["DecidedNotToGoNo"].ToString();
            }
            else
            {
                ClearYearAndDistrictFemale();
            }
            if (dvTotalYearAndDistrict.Count > 0)
            {
                lblFollowUpTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0]["FollowUpNo"].ToString();
                lblLeftForFETotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0]["LeftForFENo"].ToString();
                //lblSkillTraineeTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0][""].ToString();
                lblLeftDocumentsTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0]["LeftDocumentNo"].ToString();
                //lblAskedReceiptsTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0][""].ToString();
                lblGotReceiptsTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0]["ReceiptReceivedNo"].ToString();
                lblPaidLessTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0]["PaidLessNo"].ToString();
                //lblPaidWithinGovtCeilingTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0][""].ToString();
                lblNotDecidedTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0]["NotDecidedMigratingNo"].ToString();
                lblNotLeftTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0]["NotLeftYetNo"].ToString();
                lblNotDecidedToGoTotalDistrict.Text = dvTotalYearAndDistrict.Table.Rows[0]["DecidedNotToGoNo"].ToString();

                #region Percentage
                lblFollowUpPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0]["FollowUpNo"]) / total) * 100).ToString();
                lblLeftForFEPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0]["LeftForFENo"]) / total) * 100).ToString();
                //lblSkillTraineePercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0][""])/total)*100).ToString();
                lblLeftDocumentsPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0]["LeftDocumentNo"]) / total) * 100).ToString();
                //lblAskedReceiptsPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0][""])/total)*100).ToString();
                lblGotReceiptsPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0]["ReceiptReceivedNo"]) / total) * 100).ToString();
                lblPaidLessPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0]["PaidLessNo"]) / total) * 100).ToString();
                //lblPaidWithinGovtCeilingPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0][""])/total)*100).ToString();
                lblNotDecidedPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0]["NotDecidedMigratingNo"]) / total) * 100).ToString();
                lblNotLeftPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0]["NotLeftYetNo"]) / total) * 100).ToString();
                lblNotDecidedToGoPercentageDistrict.Text = ((Convert.ToInt32(dvTotalYearAndDistrict.Table.Rows[0]["DecidedNotToGoNo"]) / total) * 100).ToString();
                #endregion
            }
            else
            {
                ClearYearAndDistrictTotal();
                ClearYearAndDistrictPercentage();
            }
        }

        

        #region Clear Fields
        public void ClearRecordForMale()
        {
            lblFollowUpMale.Text = "";
            lblLeftForFEMale.Text = "";
            //lblSkillTraineeMale.Text = "";
            lblLeftDocumentsMale.Text = "";
            //lblAskedReceiptsMale.Text = "";
            lblGotReceiptsMale.Text = "";
            lblPaidLessMale.Text = "";
            //lblPaidWithinGovtCeilingMale.Text = "";
            lblNotDecidedMale.Text = "";
            lblNotLeftMale.Text = "";
            lblNotDecidedToGoMale.Text = "";
        }

        public void ClearRecordForFemale()
        {
            lblFollowUpFemale.Text = "";
            lblLeftForFEFemale.Text = "";
            //lblSkillTraineeFemale.Text = "";
            lblLeftDocumentsFemale.Text = "";
            //lblAskedReceiptsFemale.Text = "";
            lblGotReceiptsFemale.Text = "";
            lblPaidLessFemale.Text = "";
            //lblPaidWithinGovtCeilingFemale.Text = "";
            lblNotDecidedFemale.Text = "";
            lblNotLeftFemale.Text = "";
            lblNotDecidedToGoFemale.Text = "";
        }

        private void ClearTotalPerYear()
        {
            lblFollowUpTotal.Text = "";
            lblLeftForFETotal.Text = "";
            //lblSkillTraineeTotal.Text = "";
            lblLeftDocumentsTotal.Text = "";
            //lblAskedReceiptsTotal.Text = "";
            lblGotReceiptsTotal.Text = "";
            lblPaidLessTotal.Text = "";
            //lblPaidWithinGovtCeilingTotal.Text = "";
            lblNotDecidedTotal.Text = "";
            lblNotLeftTotal.Text = "";
            lblNotDecidedToGoTotal.Text = "";
        }

        private void ClearTotalPerYearPercentage()
        {

            lblFollowUpPercentage.Text = "";
            lblLeftForFEPercentage.Text = "";
            //lblSkillTraineePercentage.Text = "";
            lblLeftDocumentsPercentage.Text = "";
            //lblAskedReceiptsPercentage.Text = "";
            lblGotReceiptsPercentage.Text = "";
            lblPaidLessPercentage.Text = "";
            //lblPaidWithinGovtCeilingPercentage.Text = "";
            lblNotDecidedPercentage.Text = "";
            lblNotLeftPercentage.Text = "";
            lblNotDecidedToGoPercentage.Text = "";
        }

        public void ClearYearAndDistrictMale()
        {
            lblFollowUpMaleDistrict.Text = "";
            lblLeftForFEMaleDistrict.Text = "";
            //lblSkillTraineeMaleDistrict.Text = "";
            lblLeftDocumentsMaleDistrict.Text = "";
            //lblAskedReceiptsMaleDistrict.Text = "";
            lblGotReceiptsMaleDistrict.Text = "";
            lblPaidLessMaleDistrict.Text  = "";
            //lblPaidWithinGovtCeilingMaleDistrict.Text = "";
            lblNotDecidedMaleDistrict.Text = "";
            lblNotLeftMaleDistrict.Text = "";
            lblNotDecidedToGoMaleDistrict.Text = "";
        }

        public void ClearYearAndDistrictFemale()
        {
            lblFollowUpFemaleDistrict.Text = "";
            lblLeftForFEFemaleDistrict.Text = "";
            //lblSkillTraineeFemaleDistrict.Text = "";
            lblLeftDocumentsFemaleDistrict.Text = "";
            //lblAskedReceiptsFemaleDistrict.Text = "";
            lblGotReceiptsFemaleDistrict.Text = "";
            lblPaidLessFemaleDistrict.Text = "";
            //lblPaidWithinGovtCeilingFemaleDistrict.Text = "";
            lblNotDecidedFemaleDistrict.Text = "";
            lblNotLeftFemaleDistrict.Text = "";
            lblNotDecidedToGoFemaleDistrict.Text = "";
        }

        private void ClearYearAndDistrictTotal()
        {
            lblFollowUpTotalDistrict.Text = "";
            lblLeftForFETotalDistrict.Text = "";
            //lblSkillTraineeTotalDistrict.Text = "";
            lblLeftDocumentsTotalDistrict.Text = "";
            //lblAskedReceiptsTotalDistrict.Text = "";
            lblGotReceiptsTotalDistrict.Text = "";
            lblPaidLessTotalDistrict.Text = "";
            //lblPaidWithinGovtCeilingTotalDistrict.Text = "";
            lblNotDecidedTotalDistrict.Text = "";
            lblNotLeftTotalDistrict.Text = "";
            lblNotDecidedToGoTotalDistrict.Text = "";
        }

        

        private void ClearYearAndDistrictPercentage()
        {
            lblFollowUpPercentageDistrict.Text = "";
            lblLeftForFEPercentageDistrict.Text = "";
            //lblSkillTraineePercentageDistrict.Text = "";
            lblLeftDocumentsPercentageDistrict.Text = "";
            //lblAskedReceiptsPercentageDistrict.Text = "";
            lblGotReceiptsPercentageDistrict.Text = "";
            lblPaidLessPercentageDistrict.Text = "";
            //lblPaidWithinGovtCeilingPercentageDistrict.Text = "";
            lblNotDecidedPercentageDistrict.Text = "";
            lblNotLeftPercentageDistrict.Text = "";
            lblNotDecidedToGoPercentageDistrict.Text = "";
        }
        #endregion
    }
}