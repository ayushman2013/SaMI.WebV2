using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.ICKnowledge
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadIcKnowledge();

        }

        void loadIcKnowledge()
        {
            DataView dv = ICKnowledgesBO.GetAll();
            gvIcKnowledge.DataSource = dv;
            gvIcKnowledge.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ICKnowledges objICKnowledges = new ICKnowledges();
            objICKnowledges.ICKnowledgeDesc = txtICKnowledgeDesc.Text;
            objICKnowledges.Status = 1;

            if (!string.IsNullOrEmpty(hfICKnowlegeID.Value.ToString()))
            {
                objICKnowledges.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objICKnowledges.UpdatedDate = DateTime.Now;
                objICKnowledges.ICKnowledgeID = Convert.ToInt32(hfICKnowlegeID.Value);
                objICKnowledges.ICKnowledgeDesc = txtICKnowledgeDesc.Text;
                ICKnowledgesBO.UpdateICKnowledges(objICKnowledges);

            }
            else
            {
                objICKnowledges.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objICKnowledges.CreatedDate = DateTime.Now;
                ICKnowledgesBO.InsertICKnowledges(objICKnowledges);
            }

            txtICKnowledgeDesc.Text = string.Empty;
            hfICKnowlegeID.Value = string.Empty;
            loadIcKnowledge();

        }
        protected void gvIcKnowledge_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfICKnowlegeID.Value = e.CommandArgument.ToString();
            ICKnowledges objICKnowledges = new ICKnowledges();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objICKnowledges = ICKnowledgesBO.GetICKnowledges(Convert.ToInt32(e.CommandArgument));
                txtICKnowledgeDesc.Text = objICKnowledges.ICKnowledgeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int ICKnowlegeID = Convert.ToInt32(e.CommandArgument);
                objICKnowledges.ICKnowledgeID = ICKnowlegeID;
                objICKnowledges.Status = 0;
                ICKnowledgesBO.DeleteICKnowledges(objICKnowledges);
                loadIcKnowledge();
            }
        }
    }
}