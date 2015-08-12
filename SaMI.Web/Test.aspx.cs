using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;

namespace SaMI.Web
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String encrypt = AppCommonBO.EncodeUserPassword("suresh");
            //encrypt = AppCommonBO.EncodeUserPassword("ayushman");
            //encrypt = AppCommonBO.EncodeUserPassword("surendra");

            String encrypt = AppCommonBO.EncodeUserPassword("A");
            lbltest.Text = encrypt;
        }
    }
}