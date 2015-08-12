using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.JobOfferType
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
                loadJobOfferType();

        }
        void loadJobOfferType()
        {
            DataView dv = JobOfferedTypesBO.GetAll();
            gvJobOfferType.DataSource = dv;
            gvJobOfferType.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            JobOfferedTypes objJobOfferedTypes = new JobOfferedTypes();
            objJobOfferedTypes.JobOfferTypeDesc = txtJobOfferedTypeDesc.Text;
            objJobOfferedTypes.Status = 1;

            if (!string.IsNullOrEmpty(hfJobOfferedTypeID.Value.ToString()))
            {
                objJobOfferedTypes.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objJobOfferedTypes.UpdatedDate = DateTime.Now;
                objJobOfferedTypes.JobOfferedTypeID = Convert.ToInt32(hfJobOfferedTypeID.Value);
                objJobOfferedTypes.JobOfferTypeDesc = txtJobOfferedTypeDesc.Text;
                JobOfferedTypesBO.UpdateJobOfferedTypes(objJobOfferedTypes);

            }
            else
            {
                objJobOfferedTypes.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objJobOfferedTypes.CreatedDate = DateTime.Now;
                JobOfferedTypesBO.InsertJobOfferedTypes(objJobOfferedTypes);
            }
            
            txtJobOfferedTypeDesc.Text = string.Empty;
            loadJobOfferType();

        }

        protected void gvJobOfferType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfJobOfferedTypeID.Value = e.CommandArgument.ToString();
            JobOfferedTypes objJobOfferedTypes = new JobOfferedTypes();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objJobOfferedTypes = JobOfferedTypesBO.GetJobOfferedTypes(Convert.ToInt32(e.CommandArgument));
                txtJobOfferedTypeDesc.Text = objJobOfferedTypes.JobOfferTypeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int JobOfferTypeID = Convert.ToInt32(e.CommandArgument);
                objJobOfferedTypes.JobOfferedTypeID = JobOfferTypeID;
                objJobOfferedTypes.Status = 0;
                JobOfferedTypesBO.DeleteJobOfferedTypes(objJobOfferedTypes);
                loadJobOfferType();
            }
        }
    }
}