using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.JobOfferSource
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadJobOfferSource();

        }

        void loadJobOfferSource()
        {
            DataView dv = JobOfferSourcesBO.GetAll();
            gvJobOfferSource.DataSource = dv;
            gvJobOfferSource.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            JobOfferSources objJobOfferSources = new JobOfferSources();
            objJobOfferSources.JobOfferSourceDesc = txtJobOfferSourceDesc.Text;
            objJobOfferSources.Status = 1;

            if (!string.IsNullOrEmpty(hfJobOfferSourceID.Value.ToString()))
            {
                objJobOfferSources.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objJobOfferSources.UpdatedDate = DateTime.Now;
                objJobOfferSources.JobOfferSourceID = Convert.ToInt32(hfJobOfferSourceID.Value);
                objJobOfferSources.JobOfferSourceDesc = txtJobOfferSourceDesc.Text;
                JobOfferSourcesBO.UpdateJobOfferSources(objJobOfferSources);

            }
            else
            {
                objJobOfferSources.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objJobOfferSources.CreatedDate = DateTime.Now;
                JobOfferSourcesBO.InsertJobOfferSources(objJobOfferSources);
            }

            txtJobOfferSourceDesc.Text = string.Empty;
            hfJobOfferSourceID.Value = string.Empty;
            loadJobOfferSource();
        }
        protected void gvJobOfferSource_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfJobOfferSourceID.Value = e.CommandArgument.ToString();
            JobOfferSources objJobOfferSources = new JobOfferSources();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objJobOfferSources = JobOfferSourcesBO.GetJobOfferSources(Convert.ToInt32(e.CommandArgument));
                txtJobOfferSourceDesc.Text = objJobOfferSources.JobOfferSourceDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int JobOfferSourceID = Convert.ToInt32(e.CommandArgument);
                objJobOfferSources.JobOfferSourceID = JobOfferSourceID;
                objJobOfferSources.Status = 0;
                JobOfferSourcesBO.DeleteJobOfferSources(objJobOfferSources);
                loadJobOfferSource();
            }
        }
    }
}