using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.Castes
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadEthnicity();
                loadCasteView();
            }

        }

        void loadEthnicity()
        {
            DataView dv = EthnicityBO.GetAll(true);
            ddlEthnicityID.DataSource = dv;
            ddlEthnicityID.DataValueField = "EthnicityID";
            ddlEthnicityID.DataTextField = "EthnicityName";
            ddlEthnicityID.DataBind();
        }

        void loadCasteView()
        {
            DataView dv = CasteBO.GetAllCustom();
            gvCaste.DataSource = dv;
            gvCaste.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Caste objCaste = new Caste();
            objCaste.CasteName = txtCasteName.Text;
            objCaste.EthnicityID = Convert.ToInt32(ddlEthnicityID.SelectedValue);
            objCaste.IsDiscriminated = Convert.ToInt32(rbDiscriminatedYes.Checked);
            objCaste.Status = 1;

            if (!string.IsNullOrEmpty(hfCasteID.Value.ToString()))
            {
                objCaste.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objCaste.UpdatedDate = DateTime.Now;
                objCaste.CasteID = Convert.ToInt32(hfCasteID.Value);
                objCaste.CasteName = txtCasteName.Text;
                objCaste.EthnicityID = Convert.ToInt32(ddlEthnicityID.SelectedValue);

                CasteBO.UpdateCaste(objCaste);

            }
            else
            {
                objCaste.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objCaste.CreatedDate = DateTime.Now;
                CasteBO.InsertCaste(objCaste);
            }
            txtCasteName.Text = string.Empty;
            
            hfCasteID.Value = string.Empty;
            loadCasteView();
            loadEthnicity();
            

        }

        protected void gvCaste_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfCasteID.Value = e.CommandArgument.ToString();
            Caste objCaste = new Caste();

            if (e.CommandName.Equals("cmdEdit"))
            {
                objCaste = CasteBO.GetCaste(Convert.ToInt32(e.CommandArgument));
                txtCasteName.Text = objCaste.CasteName;
                ddlEthnicityID.SelectedValue = objCaste.EthnicityID.ToString();
                if (objCaste.IsDiscriminated == 1)
                {
                    rbDiscriminatedYes.Checked = true;
                    rbDiscriminatedNo.Checked = false;
                }
                else
                {
                    rbDiscriminatedNo.Checked = true;
                    rbDiscriminatedYes.Checked = false;
                }
                txtCasteName.Focus();
                
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int CasteID = Convert.ToInt32(e.CommandArgument);
                objCaste.CasteID = CasteID;
                objCaste.Status = 0;
                CasteBO.DeleteCaste(objCaste);
                loadCasteView();
            }
        }
    }
}