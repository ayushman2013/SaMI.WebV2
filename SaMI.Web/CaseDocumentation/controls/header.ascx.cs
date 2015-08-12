using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaMI.Web.CaseDocumentation.controls
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
    }
}