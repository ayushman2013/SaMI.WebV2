using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.NonFollowupReason
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadNonFollowupReason();
        }

        void loadNonFollowupReason()
        {
            DataView dv = NonFollowUpReasonsBO.GetAll();
            gvNonFollowUpReason.DataSource = dv;
            gvNonFollowUpReason.DataBind();           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            NonFollowUpReasons objNonFollowUpReasons = new NonFollowUpReasons();
            objNonFollowUpReasons.NonFollowUpReasonDesc = txtNonFollowUpReasonDesc.Text;
            objNonFollowUpReasons.Status = 1;

            if (!string.IsNullOrEmpty(hfNonFollowUpReasonID.Value.ToString()))
            {
                objNonFollowUpReasons.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objNonFollowUpReasons.UpdatedDate = DateTime.Now;
                objNonFollowUpReasons.NonFollowUpReasonID = Convert.ToInt32(hfNonFollowUpReasonID.Value);
                objNonFollowUpReasons.NonFollowUpReasonDesc = txtNonFollowUpReasonDesc.Text;
                NonFollowUpReasonsBO.UpdateNonFollowUpReasons(objNonFollowUpReasons);
            }
            else
            {
                objNonFollowUpReasons.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objNonFollowUpReasons.CreatedDate = DateTime.Now;
                NonFollowUpReasonsBO.InsertNonFollowUpReasons(objNonFollowUpReasons);
            }
            
            txtNonFollowUpReasonDesc.Text = string.Empty;
            hfNonFollowUpReasonID.Value = string.Empty;
            loadNonFollowupReason();
        }
        protected void gvNonFollowUpReason_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfNonFollowUpReasonID.Value = e.CommandArgument.ToString();
            NonFollowUpReasons objNonFollowUpReasons = new NonFollowUpReasons();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objNonFollowUpReasons = NonFollowUpReasonsBO.GetNonFollowUpReasons(Convert.ToInt32(e.CommandArgument));
                txtNonFollowUpReasonDesc.Text = objNonFollowUpReasons.NonFollowUpReasonDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int NonFollowUpReasonID = Convert.ToInt32(e.CommandArgument);
                objNonFollowUpReasons.NonFollowUpReasonID = NonFollowUpReasonID;
                objNonFollowUpReasons.Status = 0;
                NonFollowUpReasonsBO.DeleteNonFollowUpReasons(objNonFollowUpReasons);
                loadNonFollowupReason();
            }
        }
    }
}