using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.ReferralTos
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadReferralTo();

        }

        void loadReferralTo()
        {
            DataView dv = ReferralToBO.GetAll();
            gvReferralToDesc.DataSource = dv;
            gvReferralToDesc.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ReferralTo objReferralTo = new ReferralTo();
            objReferralTo.ReferralToDesc = txtReferralToDesc.Text;

            if (!string.IsNullOrEmpty(hfReferralToID.Value.ToString()))
            {
                objReferralTo.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objReferralTo.UpdatedDate = DateTime.Now;
                objReferralTo.ReferralToID = Convert.ToInt32(hfReferralToID.Value);
                objReferralTo.ReferralToDesc = txtReferralToDesc.Text;
                ReferralToBO.UpdateReferralTo(objReferralTo);

            }
            else
            {
                objReferralTo.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objReferralTo.CreatedDate = DateTime.Now;
                ReferralToBO.InsertReferralTo(objReferralTo);
            }
            
            txtReferralToDesc.Text = string.Empty;
            hfReferralToID.Value = string.Empty;
            loadReferralTo();
        }

        protected void gvReferralToDesc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfReferralToID.Value = e.CommandArgument.ToString();

            if (e.CommandName.Equals("cmdEdit"))
            {
                ReferralTo objReferralTo = ReferralToBO.GetReferralTo(Convert.ToInt32(e.CommandArgument));
                txtReferralToDesc.Text = objReferralTo.ReferralToDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int ReferralToID = Convert.ToInt32(e.CommandArgument);
                ReferralToBO.Delete(ReferralToID);
                loadReferralTo();
            }
        }
    }
}