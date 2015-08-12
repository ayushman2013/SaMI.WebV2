using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaMI.DTO;
using SaMI.Business;
using System.Data;

namespace SaMI.Web.Training.MasterData.TRNAgency
{
    public partial class Default : System.Web.UI.Page
    {
        int result =0;
        public string valueIn = "in";
        public int collapse = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAgencyInforamtion();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (lblID.Text != "")
            {
                TRNTrainingAgency agencyUpdate = new TRNTrainingAgency();
                agencyUpdate.TrainingAgency = txtTrainingAgency.Text;
                agencyUpdate.Address = txtAddress.Text;
                agencyUpdate.Phone = txtPhone.Text;
                agencyUpdate.ContactPerson = txtContactPerson.Text;
                agencyUpdate.ModifiedBy = 1;
                agencyUpdate.Status = 1;
                agencyUpdate.AgencyID = Convert.ToInt32(lblID.Text);
                result = new TRNTrainingAgencyBO().UpdateTrainingAgency(agencyUpdate);
                if (result > 0)
                {
                    Clear();

                    btnSave.Text = "Save";
                    collapse = 1;
                    LoadAgencyInforamtion();

                }
            }
            else
            {
                TRNTrainingAgency agency = new TRNTrainingAgency();
                agency.TrainingAgency = txtTrainingAgency.Text;
                agency.Address = txtAddress.Text;
                agency.Phone = txtPhone.Text;
                agency.ContactPerson = txtContactPerson.Text;
                agency.CreatedBy = 1;
                agency.Status = 1;

                result = new TRNTrainingAgencyBO().InsertTrainingAgency(agency);

                if (result > 0)
                {
                    Clear();
                    collapse = 1;
                    LoadAgencyInforamtion();
                }
            }
        }

        protected void LoadAgencyInforamtion()
        {
            DataView dvAgency = new TRNTrainingAgencyBO().GetAllTraingAgency();
            gvTrainingAgency.DataSource = dvAgency;
            gvTrainingAgency.DataBind();
        }

        protected void gvTrainingAgency_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdDelete"))
            {
                TRNTrainingAgency AgencyDelete = new TRNTrainingAgency();
                AgencyDelete.AgencyID = Convert.ToInt32(e.CommandArgument);
                AgencyDelete.Status = 0;
                int result = new TRNTrainingAgencyBO().DeleteTrainingAgency(AgencyDelete);
                LoadAgencyInforamtion();
            }
            if (e.CommandName.Equals("cmdEdit"))
            {
                DataView dvRecord = new TRNTrainingAgencyBO().GetTrainingAgencyByID(Convert.ToInt32(e.CommandArgument));
                if (dvRecord.Count > 0)
                {
                    txtTrainingAgency.Text = dvRecord.Table.Rows[0]["TrainingAgency"].ToString();
                    txtAddress.Text = dvRecord.Table.Rows[0]["Address"].ToString();
                    txtPhone.Text = dvRecord.Table.Rows[0]["Phone"].ToString();
                    txtContactPerson.Text = dvRecord.Table.Rows[0]["ContactPerson"].ToString();
                    lblID.Text = dvRecord.Table.Rows[0]["ID"].ToString();
                    collapse = 0;
                    btnSave.Text = "Update";
                }
                LoadAgencyInforamtion();
            }
        }

        protected void Clear()
        {
            txtTrainingAgency.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            lblID.Text = string.Empty;
        }
       
    }
}