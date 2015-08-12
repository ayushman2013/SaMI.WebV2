using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaMI.Web
{
    public partial class Trainings : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserAuthentication.GetUserId(this.Page) <= 0)
            {
                Response.Redirect("/Login.aspx");
            }
        }
    }
}