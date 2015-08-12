using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.CaseType
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                LoadCaseType();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CaseTypes objCaseType = new CaseTypes();
            objCaseType.CaseTypeDesc = txtCaseTypeDesc.Text;
            objCaseType.Status = 1;

            if (!string.IsNullOrEmpty(hfCaseTypeID.Value.ToString()))
            {
                objCaseType.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objCaseType.UpdatedDate = DateTime.Now;
                objCaseType.CaseTypeID = Convert.ToInt32(hfCaseTypeID.Value);
                objCaseType.CaseTypeDesc = txtCaseTypeDesc.Text;
                CaseTypesBO.UpdateCaseTypes(objCaseType);

            }
            else
            {
                objCaseType.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objCaseType.CreatedDate = DateTime.Now;
                CaseTypesBO.InsertCaseTypes(objCaseType);
            }
            
            
            txtCaseTypeDesc.Text = string.Empty;
            hfCaseTypeID.Value = string.Empty;
            LoadCaseType();

        }

        void LoadCaseType()
        {
            DataView dv = CaseTypesBO.GetAll();

            gvCaseType.DataSource = dv;
            gvCaseType.DataBind();
        }

        protected void gvCaseType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfCaseTypeID.Value = e.CommandArgument.ToString();
            CaseTypes objCaseType = new CaseTypes();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objCaseType = CaseTypesBO.GetCaseType(Convert.ToInt32(e.CommandArgument));
                txtCaseTypeDesc.Text = objCaseType.CaseTypeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int caseTypeID = Convert.ToInt32(e.CommandArgument);
                objCaseType.CaseTypeID = caseTypeID;
                objCaseType.Status = 0;
                CaseTypesBO.DeleteCaseTypes(objCaseType);
                LoadCaseType();
            }
        }

    }
}