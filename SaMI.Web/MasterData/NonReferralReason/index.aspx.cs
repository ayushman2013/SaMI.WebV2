using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.NonReferralReason
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadNonReferralReason();

        }

        void loadNonReferralReason()
        {
            DataView dv = NonReferralReasonsBO.GetAll();
            gvNonReferralReason.DataSource = dv;
            gvNonReferralReason.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            NonReferralReasons objNonReferralReasons = new NonReferralReasons();
            objNonReferralReasons.NonReferralReasonDesc = txtNonReferralReasonDesc.Text;
            objNonReferralReasons.Status = 1;

            if (!string.IsNullOrEmpty(hfNonReferralReasonID.Value.ToString()))
            {
                objNonReferralReasons.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objNonReferralReasons.UpdatedDate = DateTime.Now;
                objNonReferralReasons.NonReferralReasonID = Convert.ToInt32(hfNonReferralReasonID.Value);
                objNonReferralReasons.NonReferralReasonDesc = txtNonReferralReasonDesc.Text;
                NonReferralReasonsBO.UpdateNonReferralReasons(objNonReferralReasons);
            }
            else
            {
                objNonReferralReasons.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objNonReferralReasons.CreatedDate = DateTime.Now;
                NonReferralReasonsBO.InsertNonReferralReasons(objNonReferralReasons);
            }

            txtNonReferralReasonDesc.Text = string.Empty;
            loadNonReferralReason();
        }

        protected void gvNonReferralReason_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfNonReferralReasonID.Value = e.CommandArgument.ToString();
            NonReferralReasons objNonReferralReasons = new NonReferralReasons();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objNonReferralReasons = NonReferralReasonsBO.GetNonReferralReasons(Convert.ToInt32(e.CommandArgument));
                txtNonReferralReasonDesc.Text = objNonReferralReasons.NonReferralReasonDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int NonReferralReasonID = Convert.ToInt32(e.CommandArgument);
                objNonReferralReasons.NonReferralReasonID = NonReferralReasonID;
                objNonReferralReasons.Status = 0;
                NonReferralReasonsBO.DeleteNonReferralReasons(objNonReferralReasons);
                loadNonReferralReason();
            }
        }

    }
}