using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.FollowUps
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadFollowUp();
        }

        void loadFollowUp()
        {
            DataView dv = FollowUpBO.GetAll();
            gvFollowUp.DataSource = dv;
            gvFollowUp.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            FollowUp objfollowup = new FollowUp();
            objfollowup.FollowUpDesc = txtFollowUpDesc.Text;
            objfollowup.Status = 1;

            if (!string.IsNullOrEmpty(hfFollowUpID.Value.ToString()))
            {
                objfollowup.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objfollowup.UpdatedDate = DateTime.Now;
                objfollowup.FollowUpID = Convert.ToInt32(hfFollowUpID.Value);
                objfollowup.FollowUpDesc = txtFollowUpDesc.Text;
                FollowUpBO.UpdateFollowUp(objfollowup);

            }
            else
            {
                objfollowup.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objfollowup.CreatedDate = DateTime.Now;
                FollowUpBO.InsertFollowUp(objfollowup);
            }

            txtFollowUpDesc.Text = string.Empty;
            hfFollowUpID.Value = string.Empty;
            loadFollowUp();
        }

        protected void gvFollowUp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfFollowUpID.Value = e.CommandArgument.ToString();
            FollowUp objfollowup = new FollowUp();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objfollowup = FollowUpBO.GetFollowUp(Convert.ToInt32(e.CommandArgument));
                txtFollowUpDesc.Text = objfollowup.FollowUpDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int FollowUpID = Convert.ToInt32(e.CommandArgument);
                objfollowup.FollowUpID = FollowUpID;
                objfollowup.Status = 0;
                FollowUpBO.DeleteFollowUp(objfollowup);
                loadFollowUp();
            }
        }

       
    }
}