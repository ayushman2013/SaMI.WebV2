using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaMI.DTO;
using SaMI.Business;
using System.Data;

namespace SaMI.Web.Training.MasterData.TRNOrganization
{
    public partial class Default : System.Web.UI.Page
    {
        public string valueIn = "in";
        public int collapse = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTRNOrganization();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           if (lblID.Text != string.Empty)
            {

                //Update the Informatioin
                DTO.TRNOrganization orgUpdate = new DTO.TRNOrganization();
                orgUpdate.OrganizationID = Convert.ToInt32(lblID.Text);
                orgUpdate.Organization = txtOrganization.Text;
                orgUpdate.Country = txtCountry.Text;
                orgUpdate.Status = 1;
                orgUpdate.ModifiedBy = 1;

             

                int result = new TRNOrganizationBO().UpdateOrganization(orgUpdate);
                if (result > 0)
                {
                    Clear();
                    btnSave.Text = "Save";
                    collapse = 1;
                    LoadTRNOrganization();                   
                  

                }

            }
            else
            {
                DTO.TRNOrganization orgInsert = new DTO.TRNOrganization();
                orgInsert.Organization = txtOrganization.Text;
                orgInsert.Country = txtCountry.Text;
                orgInsert.Status = 1;
                orgInsert.CreatedBy = 1;

                int result = new TRNOrganizationBO().InsertOrganization(orgInsert);
                if (result > 0)
                {
                    Clear();
                    collapse = 1;                   
                    LoadTRNOrganization();
                   

                }
           }
            
        }

        protected void Clear()
        {
            txtCountry.Text = string.Empty;
            txtOrganization.Text = string.Empty;
            lblID.Text = string.Empty;
           
        }

        protected void gvOrganization_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string cmdName = e.CommandName;
            if (cmdName.Equals("cmdDelete"))
            {
                DTO.TRNOrganization orgDelete = new DTO.TRNOrganization();
                orgDelete.OrganizationID = id;
                orgDelete.ModifiedBy = 1;
                orgDelete.Status = 0;

                int result = new TRNOrganizationBO().DeleteOrganization(orgDelete);
                LoadTRNOrganization();
                
            }

            if (cmdName.Equals("cmdEdit"))
            {
                DataView dvRecord = new TRNOrganizationBO().GetOrganizationByID(id);
                if (dvRecord.Count > 0)
                {
                    txtOrganization.Text = dvRecord.Table.Rows[0]["Organization"].ToString();
                    txtCountry.Text = dvRecord.Table.Rows[0]["Country"].ToString();
                    lblID.Text = dvRecord.Table.Rows[0]["ID"].ToString();
                    collapse = 0;
                    btnSave.Text = "Update";
                }
            }
        
        }

        protected void LoadTRNOrganization()
        {
            DataView dvOrganization = new TRNOrganizationBO().GetAllOrganization();
            gvOrganization.DataSource = dvOrganization;
            gvOrganization.DataBind();
        }
    }
}