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
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int userID = Convert.ToInt32(Request.QueryString.Get("ID"));

                Users objUsers = new Users();
                objUsers = UserBO.GetUser(userID);
                txtFullName.Text = objUsers.FullName;
                txtUserName.Text = objUsers.UserName;

            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            Users objUsers = new Users();
            int userID = Convert.ToInt32(Request.QueryString.Get("ID"));
            objUsers.UserID = userID;

            DataView dvUsers = UserBO.SelectByUserId(userID);
            if (!String.IsNullOrEmpty(dvUsers.Table.Rows[0]["UserTypeID"].ToString()))
                objUsers.UserTypeID = Convert.ToInt32(dvUsers.Table.Rows[0]["UserTypeID"]);
            objUsers.FullName = txtFullName.Text;
            if (!String.IsNullOrEmpty(dvUsers.Table.Rows[0]["DistrictID"].ToString()))
                objUsers.DistrictID = Convert.ToInt32(dvUsers.Table.Rows[0]["DistrictID"]);
            if (!String.IsNullOrEmpty(dvUsers.Table.Rows[0]["PartnerID"].ToString()))
                objUsers.PartnerID = Convert.ToInt32(dvUsers.Table.Rows[0]["PartnerID"]);
            if (!String.IsNullOrEmpty(dvUsers.Table.Rows[0]["SaMIOrganizationID"].ToString()))
                objUsers.SaMIOrganizationID = Convert.ToInt32(dvUsers.Table.Rows[0]["SaMIOrganizationID"]);
            objUsers.Password = txtNewPassword.Text;
            if (!String.IsNullOrEmpty(objUsers.Password))
                objUsers.Password = AppCommonBO.EncodeUserPassword(objUsers.Password);

            objUsers.UpdatedBy = UserAuthentication.GetUserId(this.Page);
            objUsers.UpdatedDate = DateTime.Now;
            objUsers.SyncStatus = 0;

            UserBO.UpdateUser(objUsers);
            //UserBO.ChangePassword(objUsers);
            Response.Redirect("Index.aspx");
        }
    }
}