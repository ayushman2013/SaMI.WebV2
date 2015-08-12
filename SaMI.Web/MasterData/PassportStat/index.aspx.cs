using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.PassportStat
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadPassportStatus();
        }

        void loadPassportStatus()
        {
            DataView dv = PassportStatusBO.GetAll();
            gvPassportStatus.DataSource = dv;
            gvPassportStatus.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PassportStatus objPassportStatus = new PassportStatus();
            objPassportStatus.PassportStatusDesc = txtPassportStatusDesc.Text;
            objPassportStatus.Status = 1;

            if (!string.IsNullOrEmpty(hfPassportStatusID.Value.ToString()))
            {
                objPassportStatus.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objPassportStatus.UpdatedDate = DateTime.Now;
                objPassportStatus.PassportStatusID = Convert.ToInt32(hfPassportStatusID.Value);
                objPassportStatus.PassportStatusDesc = txtPassportStatusDesc.Text;
                PassportStatusBO.UpdatePassportStatus(objPassportStatus);
            }
            else
            {
                objPassportStatus.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objPassportStatus.CreatedDate = DateTime.Now;
                PassportStatusBO.InsertPassportStatus(objPassportStatus);
            }
            
            txtPassportStatusDesc.Text = string.Empty;
            hfPassportStatusID.Value = string.Empty;
            loadPassportStatus();
        }

        protected void gvPassportStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfPassportStatusID.Value = e.CommandArgument.ToString();
            PassportStatus objPassportStatus = new PassportStatus();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objPassportStatus = PassportStatusBO.GetPassportStatus(Convert.ToInt32(e.CommandArgument));
                txtPassportStatusDesc.Text = objPassportStatus.PassportStatusDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int PassportStatusID = Convert.ToInt32(e.CommandArgument);
                objPassportStatus.PassportStatusID = PassportStatusID;
                objPassportStatus.Status = 0;
                PassportStatusBO.DeletePassportStatus(objPassportStatus);
                loadPassportStatus();
            }
        }


    }
}