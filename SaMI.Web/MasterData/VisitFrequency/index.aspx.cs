using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.VisitFrequency
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadVisitFrequency();
        }

        void loadVisitFrequency()
        {
            DataView dv = VisitFrequenciesBO.GetAll();
            gvVisitFrequency.DataSource = dv;
            gvVisitFrequency.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            VisitFrequencies objVisitFrequencies = new VisitFrequencies();
            objVisitFrequencies.VisitFrequencyDesc = txtVisitFrequencyDesc.Text;
            objVisitFrequencies.Status = 1;

            if (!string.IsNullOrEmpty(hfVisitFrequencyID.Value.ToString()))
            {
                objVisitFrequencies.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objVisitFrequencies.UpdatedDate = DateTime.Now;
                objVisitFrequencies.VisitFrequencyID = Convert.ToInt32(hfVisitFrequencyID.Value);
                objVisitFrequencies.VisitFrequencyDesc = txtVisitFrequencyDesc.Text;
                VisitFrequenciesBO.UpdateVisitFrequencies(objVisitFrequencies);
            }
            else
            {
                objVisitFrequencies.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objVisitFrequencies.CreatedDate = DateTime.Now;
                VisitFrequenciesBO.InsertVisitFrequencies(objVisitFrequencies);
            }

            txtVisitFrequencyDesc.Text = string.Empty;
            hfVisitFrequencyID.Value = string.Empty;
            hfVisitFrequencyID.Value = string.Empty;
            loadVisitFrequency();
        }
        protected void gvVisitFrequency_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfVisitFrequencyID.Value = e.CommandArgument.ToString();
            VisitFrequencies objVisitFrequencies = new VisitFrequencies();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objVisitFrequencies = VisitFrequenciesBO.GetVisitFrequencies(Convert.ToInt32(e.CommandArgument));
                txtVisitFrequencyDesc.Text = objVisitFrequencies.VisitFrequencyDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int VisitFrequencyID = Convert.ToInt32(e.CommandArgument);
                objVisitFrequencies.VisitFrequencyID = VisitFrequencyID;
                objVisitFrequencies.Status = 0;
                VisitFrequenciesBO.DeleteVisitFrequencies(objVisitFrequencies);
                loadVisitFrequency();
            }
        }
    }
}