using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SaMI.Business;
using SaMI.DTO;

namespace SaMI.Web.User
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                     

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Users objUsers = new Users();
            objUsers.Password = txtNewPassword.Text;
            objUsers.UserID = UserAuthentication.GetUserId(this.Page);
            objUsers.UpdatedDate = DateTime.Now;
            objUsers.SyncStatus = 0;
            if (UserBO.CheckLogin(UserBO.GetUser(objUsers.UserID).UserName, txtOldPassword.Text))
            {
                UserBO.ChangePassword(objUsers);
                lblStatus.Text = "Your password has been changed successfully!";
                lblStatus.Visible = true;
            }
            else
            {
                lblStatus.Text = "Change password unsuccessful! Please check your Old Password!";
                lblStatus.Visible = true;

            }
          //  Response.Redirect("Index.aspx");

        }
    }
}