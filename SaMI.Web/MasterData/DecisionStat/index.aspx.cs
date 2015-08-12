using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.DecisionStat
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadDecisionStatus();
            }

        }

        void loadDecisionStatus()
        {
            DataView dv = DecisionStatusBO.GetAll();
            gvDecisionStatus.DataSource = dv;
            gvDecisionStatus.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DecisionStatus objDecisionStatus = new DecisionStatus();
            objDecisionStatus.DecisionStatusDesc = txtDecisionStatusDesc.Text;
            objDecisionStatus.Status = 1;

            if (!string.IsNullOrEmpty(hfDecisionStatusID.Value.ToString()))
            {
                objDecisionStatus.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objDecisionStatus.UpdatedDate = DateTime.Now;
                objDecisionStatus.DecisionStatusID = Convert.ToInt32(hfDecisionStatusID.Value);
                objDecisionStatus.DecisionStatusDesc = txtDecisionStatusDesc.Text;
                DecisionStatusBO.UpdateDecisionStatus(objDecisionStatus);

            }
            else
            {
                objDecisionStatus.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objDecisionStatus.CreatedDate = DateTime.Now;
                DecisionStatusBO.InsertDecisionStatus(objDecisionStatus);
            }
            txtDecisionStatusDesc.Text = string.Empty;
            hfDecisionStatusID.Value = string.Empty;
            loadDecisionStatus();

        }

        protected void gvDecisionStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfDecisionStatusID.Value = e.CommandArgument.ToString();
            DecisionStatus objDecisionStatus = new DecisionStatus();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objDecisionStatus = DecisionStatusBO.GetDecisionStatus(Convert.ToInt32(e.CommandArgument));
                txtDecisionStatusDesc.Text = objDecisionStatus.DecisionStatusDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int DecisionStatusID = Convert.ToInt32(e.CommandArgument);
                objDecisionStatus.DecisionStatusID = DecisionStatusID;
                objDecisionStatus.Status = 0;
                DecisionStatusBO.DeleteDecisionStatus(objDecisionStatus);
                loadDecisionStatus();
            }
        }

       
    }
}