using System;
using System.Web.UI.WebControls;
using System.Data;
using SaMI.DTO;
using SaMI.Business;

namespace SaMI.Web.Training.MasterData.TRNEmploymentStatus
{
    public partial class Default : System.Web.UI.Page
    {
        public string valueIn = "in";
        public int collapse = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadEmploymentStatus();
        }

        private void LoadEmploymentStatus()
        {
            DataView dv = new TRNEmploymentStatusBO().GetAllEmploymentStatus();
            gvEmploymentStatus.DataSource = dv;
            gvEmploymentStatus.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DTO.TRNEmploymentStatus objEmploymentStatus = new DTO.TRNEmploymentStatus();

            if (lblID.Text != string.Empty)
            {
                objEmploymentStatus.EmploymentStatusID = Convert.ToInt32(lblID.Text);
                objEmploymentStatus.EmploymentStatus = txtEmploymentStatus.Text;
                objEmploymentStatus.ModifiedBy = 1;
                objEmploymentStatus.Status = 1;
                int result = new TRNEmploymentStatusBO().UpdateEmploymentStatus(objEmploymentStatus);
                if (result > 0)
                {
                    Clear();
                    btnSave.Text = "Save";
                    collapse = 1;
                    LoadEmploymentStatus();
                }

            }
            else
            {
                objEmploymentStatus.EmploymentStatus = txtEmploymentStatus.Text;
                objEmploymentStatus.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objEmploymentStatus.Status = 1;
                int result = new TRNEmploymentStatusBO().InsertEmploymentStatus(objEmploymentStatus);
                if (result > 0)
                {
                    Clear();
                    collapse = 1;
                    LoadEmploymentStatus();
                }
            }

        }

        private void Clear()
        {
            txtEmploymentStatus.Text = string.Empty;
            lblID.Text = string.Empty;
        }

        protected void gvEmploymentStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int EmploymentStatusId = Convert.ToInt32(e.CommandArgument);
            string cmdName = e.CommandName;
            if (cmdName.Equals("cmdDelete"))
            {
                // Perform Delete Operation
                DTO.TRNEmploymentStatus objEmploymentStatus = new DTO.TRNEmploymentStatus();
                objEmploymentStatus.EmploymentStatusID = EmploymentStatusId;
                objEmploymentStatus.ModifiedBy = 1;
                objEmploymentStatus.Status = 0;

                int result = new TRNEmploymentStatusBO().DeleteEmploymentStatus(objEmploymentStatus);
                LoadEmploymentStatus();
            }

            if (cmdName.Equals("cmdEdit"))
            {
                // Show data to TextBoxes and controls
                DataView dvRecord = new TRNEmploymentStatusBO().SelectEmploymentStatusByID(EmploymentStatusId);
                if (dvRecord.Count > 0)
                {
                    lblID.Text = dvRecord.Table.Rows[0]["ID"].ToString();
                    txtEmploymentStatus.Text = dvRecord.Table.Rows[0]["EmploymentStatus"].ToString();
                    btnSave.Text = "Update";
                    collapse = 0;
                }

            }
        }
    }
}