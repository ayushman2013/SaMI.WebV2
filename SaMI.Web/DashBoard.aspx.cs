using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaMI.Web
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void btnICC_Click(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "USER" ||
                UserAuthentication.GetUserType(this.Page) == "KTMUSER" || UserAuthentication.GetUserType(this.Page) == "DPC" || UserAuthentication.GetUserType(this.Page) == "CASEUSR")
            {
                Response.Redirect("~/Profile/Index.aspx");
            }
        }

        protected void btnSkillandEmployment_Click(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "PARTNER")
            {
                Response.Redirect("~/Training/Default.aspx");
            }
        }

        protected void btnFreeLegalAidClinic_Click(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserType(this.Page) == "ADMIN" || UserAuthentication.GetUserType(this.Page) == "CASEUSR")
            {
                Response.Redirect("~/CaseDocumentation/Index.aspx");
            }
        }
    }
}