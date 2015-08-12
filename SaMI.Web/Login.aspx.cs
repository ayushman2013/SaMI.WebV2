using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.DTO;
using SaMI.Business;
using System.Data;

namespace SaMI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserAuthentication.DestroySession(this.Page, AppSettings.GetUserSessionName());
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataView dvUserInfo = UserBO.GetUserInfoByUserNamePassword(txtUserName.Text, txtPassword.Text);
            if (UserBO.CheckLogin(txtUserName.Text, txtPassword.Text))
            {
                UserAuthentication.SetSession(this.Page, AppSettings.GetUserSessionName(), UserBO.SetAppUserDetails(txtUserName.Text.ToString()));

                if (UserAuthentication.GetUserType(this.Page) == "CASEUSR")
                {
                    if (dvUserInfo.Count > 0)
                    {
                        if (dvUserInfo.Table.Rows[0]["StakeHolderName"].ToString() == "PNCC")
                            Response.Redirect("~/DashBoard.aspx");
                    }
                    Response.Redirect("~/CaseDocumentation/Index.aspx");
                }
                else if (UserAuthentication.GetUserType(this.Page) == "PARTNER")
                    Response.Redirect("~/Training/Default.aspx");
                
                //Response.Redirect("~/Training/Default.aspx");
                else
                    Response.Redirect("~/DashBoard.aspx");
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "<div class=\"alert alert-danger\">Your login attempt was not successful.Please try again.</div>";
            }
        }
    }
}