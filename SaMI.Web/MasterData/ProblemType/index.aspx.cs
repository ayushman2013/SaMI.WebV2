using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.ProblemType
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadProblemTypes();

        }

        void loadProblemTypes()
        {
            DataView dv = ProblemTypesBO.GetAll();
            gvProblemType.DataSource = dv;
            gvProblemType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ProblemsTypes objProblemTypes = new ProblemsTypes();
            objProblemTypes.ProblemTypeDesc = txtProblemTypeDesc.Text;
            objProblemTypes.Status = 1;

            if (!string.IsNullOrEmpty(hfProblemTypeID.Value.ToString()))
            {
                objProblemTypes.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objProblemTypes.UpdatedDate = DateTime.Now;
                objProblemTypes.ProblemTypeID = Convert.ToInt32(hfProblemTypeID.Value);
                objProblemTypes.ProblemTypeDesc = txtProblemTypeDesc.Text;
                ProblemTypesBO.UpdateProblemsTypes(objProblemTypes);

            }
            else
            {
                objProblemTypes.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objProblemTypes.CreatedDate = DateTime.Now;
                ProblemTypesBO.InsertProblemTypes(objProblemTypes);
            }
            
            txtProblemTypeDesc.Text = string.Empty;
            hfProblemTypeID.Value = string.Empty;
            loadProblemTypes();
        }

        protected void gvProblemType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfProblemTypeID.Value = e.CommandArgument.ToString();
            ProblemsTypes objProblemTypes = new ProblemsTypes();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objProblemTypes = ProblemTypesBO.GetProblemsTypes(Convert.ToInt32(e.CommandArgument));
                txtProblemTypeDesc.Text = objProblemTypes.ProblemTypeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int ProblemTypeID = Convert.ToInt32(e.CommandArgument);
                objProblemTypes.ProblemTypeID = ProblemTypeID;
                objProblemTypes.Status = 0;
                ProblemTypesBO.DeleteProblemsTypes(objProblemTypes);
                loadProblemTypes();
            }
        }
    }
}