using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaMI.Web.controls
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblLoginName.Text = UserAuthentication.GetUserFullName(this.Page) + " [" + UserAuthentication.GetUserDistrictName(this.Page) + "]";
            }
        }

        protected String GetSettingsURL()
        {
            String strOut = string.Empty;

            if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "SA")
            {
                strOut = "<li class=\"dropdown\">" +
                            "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Settings <b class=\"caret\"></b></a>" +
                            "<ul class=\"dropdown-menu\">" +
                                "<li><a href=\"/User/Index.aspx\">Users Management</a></li>" +
                                "<li><a href=\"/User/ChangePassword.aspx\">Change Password</a></li>" +
                            "</ul>" +
                         "</li>";
            }
            else
            {
                strOut += "<li><a href=\"/User/ChangePassword.aspx\">Change Password</a></li>";
            }

            return strOut;
        }

        protected String GetMasterDataURL()
        {
            String strOut = string.Empty;

            if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "SA")
            {
                strOut += "<li class=\"dropdown\"> " +
                            "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Master Data <b class=\"caret\"></b></a>" +
                            "<ul class=\"dropdown-menu\" style=\"height:500px; overflow:auto\">" +
                                "<li><a href=\"/MasterData/Organization/Index.aspx\">SaMI Organizations</a></li>" +
                                "<li><a href=\"/MasterData/Ethnicities/Index.aspx\">Ethnicity</a></li>" +
                                "<li><a href=\"/MasterData/DocumentType/Index.aspx\">Documents Types</a></li>" +
                                "<li><a href=\"/MasterData/DocumentBehind/Index.aspx\">Documents Left Types</a></li>" +
                                "<li><a href=\"/MasterData/EducationalStat/Index.aspx\">Educational Status</a></li>" +
                                "<li><a href=\"/MasterData/OccupationType/Index.aspx\">Occupation Types</a></li>" +
                                "<li><a href=\"/MasterData/DecisionStat/Index.aspx\">Decision Status</a></li>" +
                                "<li><a href=\"/MasterData/PassportStat/Index.aspx\">Passport Status</a></li>" +
                                "<li><a href=\"/MasterData/JobOfferSource/Index.aspx\">Job Agent</a></li>" +
                                "<li><a href=\"/MasterData/JobOfferType/Index.aspx\">Job Offered Types</a></li>" +
                                "<li><a href=\"/MasterData/WorkType/Index.aspx\">Job Type</a></li>" +
                                "<li><a href=\"/MasterData/ICKnowledge/Index.aspx\">Know about IC</a></li>" +
                                "<li><a href=\"/MasterData/PaymentRange/Index.aspx\">Payment Range</a></li>" +
                                "<li><a href=\"/MasterData/MoneyRange/Index.aspx\">Sending Money Range</a></li>" +
                                "<li><a href=\"/MasterData/ProblemType/Index.aspx\">Problem Faced Types</a></li>" +
                                "<li><a href=\"/MasterData/VisitFrequency/Index.aspx\">Country Visit Times</a></li>" +
                                "<li><a href=\"/MasterData/ServiceProvide/Index.aspx\">Service Provide by IC</a></li>" +
                                "<li><a href=\"/MasterData/FollowUps/Index.aspx\">Required Follow-up Types</a></li>" +
                                "<li><a href=\"/MasterData/ICRecommendation/Index.aspx\">IC Recommendation Types</a></li>" +
                                "<li><a href=\"/MasterData/AdditionalFollowupsInfo/Index.aspx\">Additional Info Documents</a></li>" +
                                "<li><a href=\"/MasterData/CounselorDifficulty/Index.aspx\">Counselor Difficulty Types</a></li>" +
                                "<li><a href=\"/MasterData/NonFollowupReason/Index.aspx\">Followup Not Possible Reasons</a></li>" +
                                "<li><a href=\"/MasterData/NonReferralReason/Index.aspx\">Non Referral Reasons</a></li>" +
                                "<li><a href=\"/MasterData/ReferralStat/Index.aspx\">Referral Organization's Status</a></li>" +
                                "<li><a href=\"/MasterData/CaseType/Index.aspx\">Case Types</a></li>" +
                                "<li><a href=\"/MasterData/StakeHolder/Index.aspx\">Partners</a></li>" +
                                "<li><a href=\"/MasterData/EvidenceType/Index.aspx\">Evidence Types</a></li>" +
                                "<li><a href=\"/MasterData/AgeGroup/Index.aspx\">Age Group</a></li>" +
                            "</ul>" +
                        "</li>";
            }
            return strOut;
        }

        protected String GetReportURL()
        {
            String strOut = string.Empty;

            if (UserAuthentication.GetUserType(this.Page) != "PARTNER")
            {
                strOut = "<li class=\"dropdown\">" +
                            "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Reports <b class=\"caret\"></b></a>" +
                            "<ul class=\"dropdown-menu\">" +
                                "<li><a href=\"/Reports/Index.aspx\">Profiles Registered</a></li>"+
                                "<li><a href=\"/Reports/SummaryReport.aspx\">Summary Report</a></li>"+
                                "<li><a href=\"/Reports/PhoneFollowUp.aspx\">Phone Follow Up</a></li>" +
                                "<li><a href=\"/Reports/ReportICC.aspx\">ICC Report</a></li>" +
                                "<li><a href=\"/Reports/ReportPhoneFollowUp.aspx\">Summary Phone Follow Up</a></li>" +
                            "</ul>" +
                         "</li>";
            }
            else
            {
                strOut += "<li><a href=\"/Reports/CaseReports.aspx\">Reports</a></li>";
            }

            return strOut;
        }
    }
}