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
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserId(this.Page) <= 0)
                Response.Redirect("/Login.aspx");

            //if (!Page.IsPostBack)
            //    ShowCaseFollowupReminder();
            if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                Response.Redirect("/Training/Default.aspx");
            }

        }

        public void ShowCaseFollowupReminder()
        {
            String UserType = UserAuthentication.GetUserType(this.Page);
            
            int districtID = 0;

            if (UserType == "USER")
                districtID = UserAuthentication.GetDistrictId(this.Page);
            int partnerID = UserAuthentication.GetPartnerId(this.Page);
            DataView dvCaseFollowUpReminder = CaseBO.GetCaseFollowUpRemider(-15, districtID, partnerID);
            DataView dvCaseFollowUpUpdateReminder = CaseFollowUpBO.GetCaseFollowUpUpdateRemider(-3, districtID);

            gvCaseFollowUpReminder.DataSource = dvCaseFollowUpReminder;
            gvCaseFollowUpReminder.DataBind();

            gvCaseFollowUpUpdateReminder.DataSource = dvCaseFollowUpUpdateReminder;
            gvCaseFollowUpUpdateReminder.DataBind();

            if(UserType == "PARTNER")
                pnlCaseUpdate.Visible = false;

            if (dvCaseFollowUpReminder.Count > 0 || dvCaseFollowUpUpdateReminder.Count > 0)
            {
                string url = HttpContext.Current.Request.Url.AbsolutePath;

                if (url.ToLower() == "/default.aspx" || url.ToLower() == "/caseindex.aspx")
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script language='javascript'>");
                    sb.Append(@"$('#divReminder').modal('show')");
                    sb.Append(@"</script>");

                    if (!Page.ClientScript.IsStartupScriptRegistered("JSScript"))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "JSScript", sb.ToString());
                    }
                }
            }
        }
       
    }
}
