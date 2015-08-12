using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.DocumentType
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            loadDocumentType();

        }

        void loadDocumentType()
        {
            DataView dv = DocumentTypesBO.GetAll();
            gvDocumentType.DataSource = dv;
            gvDocumentType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DocumentTypes objDocumentTypes = new DocumentTypes();
            objDocumentTypes.DocumentTypeDesc = txtDocumentTypeDesc.Text;
            objDocumentTypes.Status = 1;


            if (!string.IsNullOrEmpty(hfDocumentTypeID.Value.ToString()))
            {
                objDocumentTypes.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objDocumentTypes.UpdatedDate = DateTime.Now;
                objDocumentTypes.DocumentTypeID = Convert.ToInt32(hfDocumentTypeID.Value);
                objDocumentTypes.DocumentTypeDesc = txtDocumentTypeDesc.Text;
                DocumentTypesBO.UpdateDocumentTypes(objDocumentTypes);

            }
            else
            {
                objDocumentTypes.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objDocumentTypes.CreatedDate = DateTime.Now;
                DocumentTypesBO.InsertDocumentTypes(objDocumentTypes);
            }

            txtDocumentTypeDesc.Text = string.Empty;
            hfDocumentTypeID.Value = string.Empty;
            loadDocumentType();

        }

        protected void gvDocumentType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfDocumentTypeID.Value = e.CommandArgument.ToString();
            DocumentTypes objDocumentTypes = new DocumentTypes();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objDocumentTypes = DocumentTypesBO.GetDocumentTypes(Convert.ToInt32(e.CommandArgument));
                txtDocumentTypeDesc.Text = objDocumentTypes.DocumentTypeDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int DocumentTypeID = Convert.ToInt32(e.CommandArgument);
                objDocumentTypes.DocumentTypeID = DocumentTypeID;
                objDocumentTypes.Status = 0;
                DocumentTypesBO.DeleteDocumentTypes(objDocumentTypes);
                loadDocumentType();
            }
        }
    }
}