using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.ReferralStat
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadReferralStatus();
        }

        void loadReferralStatus()
        {
            DataView dv = ReferralStatusBO.GetAll();
            gvReferralStatus.DataSource = dv;
            gvReferralStatus.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            ReferralStatus objReferralStatus = new ReferralStatus();
            objReferralStatus.ReferralStatusDesc = txtReferralStatusDesc.Text;
            if (!string.IsNullOrEmpty(hfReferralStausID.Value.ToString()))
            {
                objReferralStatus.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objReferralStatus.UpdatedDate = DateTime.Now;
                objReferralStatus.ReferralStausID = Convert.ToInt32(hfReferralStausID.Value);
                objReferralStatus.ReferralStatusDesc = txtReferralStatusDesc.Text;
                ReferralStatusBO.UpdateReferralStatus(objReferralStatus);
            }
            else
            {
                objReferralStatus.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objReferralStatus.CreatedDate = DateTime.Now;
                ReferralStatusBO.InsertReferralStatus(objReferralStatus);
            }

            txtReferralStatusDesc.Text = string.Empty;
            hfReferralStausID.Value = string.Empty;
            loadReferralStatus();
        }

        protected void gvReferralStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfReferralStausID.Value = e.CommandArgument.ToString();

            if (e.CommandName.Equals("cmdEdit"))
            {
                ReferralStatus objReferralStatus = ReferralStatusBO.GetReferralStatus(Convert.ToInt32(e.CommandArgument));
                txtReferralStatusDesc.Text = objReferralStatus.ReferralStatusDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int ReferralStausID = Convert.ToInt32(e.CommandArgument);
                ReferralStatusBO.Delete(ReferralStausID);
                loadReferralStatus();
            }
        }
    }
}