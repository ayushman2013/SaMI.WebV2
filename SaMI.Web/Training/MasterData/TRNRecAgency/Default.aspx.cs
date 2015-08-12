using System;
using System.Web.UI.WebControls;
using System.Data;
using SaMI.DTO;
using SaMI.Business;

namespace SaMI.Web.Training.MasterData.TRNRecAgency
{
    public partial class Default : System.Web.UI.Page
    {
        public string valueIn = "in";
        public int collapse = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRecruitmentAgency();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblID.Text != string.Empty)
            {
                TRNRecruitmentAgency RecAgencyUpdate = new TRNRecruitmentAgency();
                RecAgencyUpdate.RecAgencyID = Convert.ToInt32(lblID.Text);
                RecAgencyUpdate.RecruitmentAgency = txtRecruitmentAgency.Text;
                RecAgencyUpdate.ModifiedBy = 1;
                RecAgencyUpdate.Status = 1;
                int result = new TRNRecruitmentAgencyBO().UpdateRecruitmentAgency(RecAgencyUpdate);
                if (result > 0)
                {
                    Clear();
                    btnSave.Text = "Save";
                    LoadRecruitmentAgency();
                }
               
            }
            else
            {
                TRNRecruitmentAgency RecAgencyInsert = new TRNRecruitmentAgency();
                RecAgencyInsert.RecruitmentAgency = txtRecruitmentAgency.Text;
                RecAgencyInsert.CreatedBy = 1;
                RecAgencyInsert.Status = 1;
                int result = new TRNRecruitmentAgencyBO().InsertRecruitmentAgency(RecAgencyInsert);
                if (result > 0)
                {
                    Clear();
                    LoadRecruitmentAgency();
                }
              
            }

        }

        protected void LoadRecruitmentAgency()
        {
            DataView dvRecAgency = new TRNRecruitmentAgencyBO().GetAllRecruitmentAgency();
            gvRecAgency.DataSource = dvRecAgency;
            gvRecAgency.DataBind();
        }

        protected void Clear()
        {
            txtRecruitmentAgency.Text = string.Empty;
            lblID.Text = string.Empty;

        }

        protected void gvRecAgency_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            string cmdName = e.CommandName;
            if (cmdName.Equals("cmdDelete"))
            {
                // Perform Delete Operation
                TRNRecruitmentAgency RecAgencyID = new TRNRecruitmentAgency();
                RecAgencyID.RecAgencyID = id;
                RecAgencyID.ModifiedBy = 1;
                RecAgencyID.Status = 0;

                int result = new TRNRecruitmentAgencyBO().DeleteRecruitmentAgency(RecAgencyID);
                LoadRecruitmentAgency();
            }

            if (cmdName.Equals("cmdEdit"))
            {
                // Show data to TextBoxes and controls
                DataView dvRecord = new TRNRecruitmentAgencyBO().GetRecruitmentAgencyByID(id);
                if (dvRecord.Count > 0)
                {
                    lblID.Text = dvRecord.Table.Rows[0]["ID"].ToString();
                    txtRecruitmentAgency.Text = dvRecord.Table.Rows[0]["RecruitmentAgency"].ToString();
                    btnSave.Text = "Save";
                }

            }
        }
    }
}