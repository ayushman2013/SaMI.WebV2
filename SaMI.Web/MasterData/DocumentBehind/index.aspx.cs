using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.DocumentBehind
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            loadDocumentBehind();

        }

        void loadDocumentBehind()
        {

            DataView dv = DocumentsBehindBO.GetAll();
            gvDocumentBehindType.DataSource = dv;
            gvDocumentBehindType.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            DocumentsBehind objDocumentsBehind = new DocumentsBehind();
            objDocumentsBehind.DocumentBehindDesc = txtDocumentBehindDesc.Text;
            objDocumentsBehind.Status = 1;

            if (!string.IsNullOrEmpty(hfDocumentBehindID.Value.ToString()))
            {
                objDocumentsBehind.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objDocumentsBehind.UpdatedDate = DateTime.Now;
                objDocumentsBehind.DocumentBehindID = Convert.ToInt32(hfDocumentBehindID.Value);
                objDocumentsBehind.DocumentBehindDesc = txtDocumentBehindDesc.Text;
                DocumentsBehindBO.UpdateDocumentsBehind(objDocumentsBehind);

            }
            else
            {
                objDocumentsBehind.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objDocumentsBehind.CreatedDate = DateTime.Now;
                DocumentsBehindBO.InsertDocumentsBehind(objDocumentsBehind);
            }

            txtDocumentBehindDesc.Text = string.Empty;
            hfDocumentBehindID.Value = string.Empty;
            loadDocumentBehind();
        }

        protected void gvDocumentBehindType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfDocumentBehindID.Value = e.CommandArgument.ToString();
            DocumentsBehind objDocumentsBehind = new DocumentsBehind();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objDocumentsBehind = DocumentsBehindBO.GetDocumentBehind(Convert.ToInt32(e.CommandArgument));
                txtDocumentBehindDesc.Text = objDocumentsBehind.DocumentBehindDesc;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int DocumentBehindID = Convert.ToInt32(e.CommandArgument);
                objDocumentsBehind.DocumentBehindID = DocumentBehindID;
                objDocumentsBehind.Status = 0;
                DocumentsBehindBO.DeleteDocumentsBehind(objDocumentsBehind);
                loadDocumentBehind();
            }
        }
    }
}