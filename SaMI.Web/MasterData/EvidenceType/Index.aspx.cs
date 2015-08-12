using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.EvidenceType
{
    public partial class Index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadCaseType();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EvidenceTypes objEvidenceTypes = new EvidenceTypes();
            objEvidenceTypes.EvidenceTypeDesc = txtEvidenceTypeDesc.Text;
            objEvidenceTypes.Status = 1;

            if (!string.IsNullOrEmpty(hfEvidenceTypeID.Value.ToString()))
            {
                objEvidenceTypes.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objEvidenceTypes.UpdatedDate = DateTime.Now;
                objEvidenceTypes.EvidenceTypeID = Convert.ToInt32(hfEvidenceTypeID.Value);
                objEvidenceTypes.EvidenceTypeDesc = txtEvidenceTypeDesc.Text;
                EvidenceTypeBO.UpdateEvidenceTypes(objEvidenceTypes);

            }
            else
            {
                objEvidenceTypes.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objEvidenceTypes.CreatedDate = DateTime.Now;
                EvidenceTypeBO.InsertEvidenceTypes(objEvidenceTypes);
            }


            txtEvidenceTypeDesc.Text = string.Empty;
            hfEvidenceTypeID.Value = string.Empty;
            LoadCaseType();

        }

        void LoadCaseType()
        {
            DataView dv = EvidenceTypeBO.GetAll();

            gvEvidenceType.DataSource = dv;
            gvEvidenceType.DataBind();
        }

        protected void gvEvidenceType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfEvidenceTypeID.Value = e.CommandArgument.ToString();
            EvidenceTypes objEvidenceTypes = new EvidenceTypes();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objEvidenceTypes = EvidenceTypeBO.GetEvidenceTypes(Convert.ToInt32(e.CommandArgument));
                txtEvidenceTypeDesc.Text = objEvidenceTypes.EvidenceTypeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int EvidenceTypeID = Convert.ToInt32(e.CommandArgument);
                objEvidenceTypes.EvidenceTypeID = EvidenceTypeID;
                objEvidenceTypes.Status = 0;
                EvidenceTypeBO.DeleteEvidenceTypes(objEvidenceTypes);
                LoadCaseType();
            }
        }

    }
}