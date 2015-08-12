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
    public partial class passwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            string pass = AppCommonBO.EncodeUserPassword(txtPass.Text.Trim());
            Response.Write(pass);
        }
    }
}