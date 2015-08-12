using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.UserType
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadUserType();
        }

        void loadUserType()
        {
            DataView dv = UserTypeBO.GetAll();
            gvUserType.DataSource = dv;
            gvUserType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserTypes objUserTypes = new UserTypes();
            objUserTypes.UserTypeDesc = txtUserTypeDesc.Text;
            objUserTypes.UserTypeCode = txtUserTypeCode.Text;

            if (!string.IsNullOrEmpty(hfUserTypeID.Value.ToString()))
            {
                objUserTypes.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objUserTypes.UpdatedDate = DateTime.Now;
                objUserTypes.UserTypeID = Convert.ToInt32(hfUserTypeID.Value);
                objUserTypes.UserTypeDesc = txtUserTypeDesc.Text;
                objUserTypes.UserTypeCode = txtUserTypeCode.Text;
                UserTypeBO.UpdateUserTypes(objUserTypes);
            }
            else
            {
                objUserTypes.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objUserTypes.CreatedDate = DateTime.Now;
                UserTypeBO.InsertUserTypes(objUserTypes);
            }


            txtUserTypeDesc.Text = string.Empty;
            txtUserTypeCode.Text = string.Empty;
            hfUserTypeID.Value = string.Empty;
            
            loadUserType();
        }

        protected void gvUserType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfUserTypeID.Value = e.CommandArgument.ToString();

            if (e.CommandName.Equals("cmdEdit"))
            {
                UserTypes objUserTypes = UserTypeBO.GetUserTypes(Convert.ToInt32(e.CommandArgument));
                txtUserTypeDesc.Text = objUserTypes.UserTypeDesc;
                txtUserTypeCode.Text = objUserTypes.UserTypeCode;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int UserTypeID = Convert.ToInt32(e.CommandArgument);
                UserTypeBO.Delete(UserTypeID);
                loadUserType();
            }
        }
    }
}