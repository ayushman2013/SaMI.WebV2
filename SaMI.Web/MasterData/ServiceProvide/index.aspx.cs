using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;


namespace SaMI.Web.MasterData.ServiceProvide
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadServiceProvided();
        }

        void loadServiceProvided()
        {
            DataView dv = ServicesProvidedBO.GetAll();
            gvServiceProvided.DataSource = dv;
            gvServiceProvided.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ServicesProvided objServicesProvided = new ServicesProvided();
            objServicesProvided.ServiceProvidedDesc = txtServiceProvidedDesc.Text;
            objServicesProvided.Status = 1;

            if (!string.IsNullOrEmpty(hfServiceProvidedID.Value.ToString()))
            {
                objServicesProvided.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objServicesProvided.UpdatedDate = DateTime.Now;
                objServicesProvided.ServiceProvidedID = Convert.ToInt32(hfServiceProvidedID.Value);
                objServicesProvided.ServiceProvidedDesc = txtServiceProvidedDesc.Text;
                ServicesProvidedBO.UpdateServicesProvided(objServicesProvided);

            }
            else
            {
                objServicesProvided.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objServicesProvided.CreatedDate = DateTime.Now;
                ServicesProvidedBO.InsertServicesProvided(objServicesProvided);
            }

            txtServiceProvidedDesc.Text = string.Empty;
            hfServiceProvidedID.Value = string.Empty;
            loadServiceProvided();            
        }

        protected void gvServiceProvided_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfServiceProvidedID.Value = e.CommandArgument.ToString();
            ServicesProvided objServicesProvided = new ServicesProvided();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objServicesProvided = ServicesProvidedBO.GetServicesProvided(Convert.ToInt32(e.CommandArgument));
                txtServiceProvidedDesc.Text = objServicesProvided.ServiceProvidedDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int ServiceProvidedID = Convert.ToInt32(e.CommandArgument);
                objServicesProvided.ServiceProvidedID = ServiceProvidedID;
                objServicesProvided.Status = 0;
                ServicesProvidedBO.DeleteServicesProvided(objServicesProvided);
                loadServiceProvided();
            }
        }
    }
}