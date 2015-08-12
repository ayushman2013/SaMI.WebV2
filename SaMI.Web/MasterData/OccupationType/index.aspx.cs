using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.OccupationType
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadOccupationType();
        }

        void loadOccupationType()
        {
            DataView dv = OccupationTypeBO.GetAll();
            gvOccupationType.DataSource = dv;
            gvOccupationType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OccupationTypes objOccupationTypes = new OccupationTypes();
            objOccupationTypes.OccupationTypeDesc = txtOccupationTypeDesc.Text;
            objOccupationTypes.Status = 1;

            if (!string.IsNullOrEmpty(hfOccupationTypeID.Value.ToString()))
            {
                objOccupationTypes.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objOccupationTypes.UpdatedDate = DateTime.Now;
                objOccupationTypes.OccupationTypeID = Convert.ToInt32(hfOccupationTypeID.Value);
                objOccupationTypes.OccupationTypeDesc = txtOccupationTypeDesc.Text;
                OccupationTypeBO.UpdateOccupationTypes(objOccupationTypes);
            }
            else
            {
                objOccupationTypes.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objOccupationTypes.CreatedDate = DateTime.Now;
                OccupationTypeBO.InsertOccupationType(objOccupationTypes);
            }
            
            txtOccupationTypeDesc.Text = string.Empty;
            hfOccupationTypeID.Value = string.Empty;
            loadOccupationType();
        }
        protected void gvOccupationType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfOccupationTypeID.Value = e.CommandArgument.ToString();
            OccupationTypes objOccupationTypes = new OccupationTypes();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objOccupationTypes = OccupationTypeBO.GetOccupationType(Convert.ToInt32(e.CommandArgument));
                txtOccupationTypeDesc.Text = objOccupationTypes.OccupationTypeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int OccupationTypeID = Convert.ToInt32(e.CommandArgument);
                objOccupationTypes.OccupationTypeID = OccupationTypeID;
                objOccupationTypes.Status = 0;
                OccupationTypeBO.DeleteOccupationTypes(objOccupationTypes);
                loadOccupationType();
            }
        }


    }
}