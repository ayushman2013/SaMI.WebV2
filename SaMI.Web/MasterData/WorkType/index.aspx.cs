using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.WorkType
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadWorkType();

        }

        void loadWorkType()
        {
            DataView dv = WorkTypesBO.GetAll();
            gvWorkType.DataSource = dv;
            gvWorkType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WorkTypes objWorkTypes = new WorkTypes();
            objWorkTypes.WorkTypeDesc = txtWorkTypeDesc.Text;
            objWorkTypes.Status = 1;

            if (!string.IsNullOrEmpty(hfWorkTypeID.Value.ToString()))
            {
                objWorkTypes.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objWorkTypes.UpdatedDate = DateTime.Now;
                objWorkTypes.WorkTypeID = Convert.ToInt32(hfWorkTypeID.Value);
                objWorkTypes.WorkTypeDesc = txtWorkTypeDesc.Text;
                WorkTypesBO.UpdateWorkTypes(objWorkTypes);

            }
            else
            {
                objWorkTypes.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objWorkTypes.CreatedDate = DateTime.Now;
                WorkTypesBO.InsertWorkTypes(objWorkTypes);
            }
            
            txtWorkTypeDesc.Text = string.Empty;
            hfWorkTypeID.Value = string.Empty;
            hfWorkTypeID.Value = string.Empty;
            loadWorkType();

        }

        protected void gvWorkType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfWorkTypeID.Value = e.CommandArgument.ToString();
            WorkTypes objWorkTypes = new WorkTypes();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objWorkTypes = WorkTypesBO.GetWorkTypes(Convert.ToInt32(e.CommandArgument));
                txtWorkTypeDesc.Text = objWorkTypes.WorkTypeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int WorkTypeID = Convert.ToInt32(e.CommandArgument);
                objWorkTypes.WorkTypeID = WorkTypeID;
                objWorkTypes.Status = 0;
                WorkTypesBO.DeleteWorkTypes(objWorkTypes);
                loadWorkType();
            }
        }
    }
}