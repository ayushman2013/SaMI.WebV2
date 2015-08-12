using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SaMI.Business;
using SaMI.DTO;
using System.Data;

namespace SaMI.Web.MasterData.FamilyMember
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadFamilyMember();
            
        }

        void loadFamilyMember()
        {
            DataView dv = FamilyMembersBO.GetAll();
            gvFamilyMember.DataSource = dv;
            gvFamilyMember.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            FamilyMembers objFamilyMembers = new FamilyMembers();
            objFamilyMembers.FamilyMemberName = txtFamilyMemberName.Text;

            if (!string.IsNullOrEmpty(hfFamilyMemberID.Value.ToString()))
            {
                objFamilyMembers.UpdatedBy = UserAuthentication.GetUserId(this.Page);
                objFamilyMembers.UpdatedDate = DateTime.Now;
                objFamilyMembers.FamilyMemberID = Convert.ToInt32(hfFamilyMemberID.Value);
                objFamilyMembers.FamilyMemberName = txtFamilyMemberName.Text;
                FamilyMembersBO.UpdateFamilyMembers(objFamilyMembers);

            }
            else
            {
                objFamilyMembers.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objFamilyMembers.CreatedDate = DateTime.Now;
                FamilyMembersBO.InsertFamilyMembers(objFamilyMembers);
            }

            txtFamilyMemberName.Text = string.Empty;
            hfFamilyMemberID.Value = string.Empty;
            loadFamilyMember();

        }

        protected void gvCaseType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hfFamilyMemberID.Value = e.CommandArgument.ToString();

            if (e.CommandName.Equals("cmdEdit"))
            {
                FamilyMembers objFamilyMembers = FamilyMembersBO.GetFamilyMembers(Convert.ToInt32(e.CommandArgument));
                txtFamilyMemberName.Text = objFamilyMembers.FamilyMemberName;
            }
            else if (e.CommandName.Equals("cmdDelete"))
            {
                int FamilyMemberID = Convert.ToInt32(e.CommandArgument);
                //Proceed Delete
            }
        }


    }
}