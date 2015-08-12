using System;
using System.Web.UI.WebControls;
using System.Data;
using SaMI.DTO;
using SaMI.Business;

namespace SaMI.Web.Training.MasterData.TRNQualification
{
    public partial class Default : System.Web.UI.Page
    {
        public string valueIn = "in";
        public int collapse = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadQualification();
        }

        private void LoadQualification()
        {
            DataView dv = new TRNEducationLevelBO().GetAllEducationLevel();
            gvQualification.DataSource = dv;
            gvQualification.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DTO.TRNEducationLevel objQualification = new DTO.TRNEducationLevel();

            if (lblID.Text != string.Empty)
            {
                objQualification.EducationalLevelID = Convert.ToInt32(lblID.Text);
                objQualification.EducationLevel = txtQualification.Text;
                objQualification.ModifiedBy = 1;
                objQualification.Status = 1;
                int result = new TRNEducationLevelBO().UpdateQualification(objQualification);
                if (result > 0)
                {
                    Clear();
                    btnSave.Text = "Save";
                    collapse = 1;
                    LoadQualification();
                }

            }
            else
            {
                objQualification.EducationLevel = txtQualification.Text;
                objQualification.CreatedBy = UserAuthentication.GetUserId(this.Page);
                objQualification.Status = 1;
                int result = new TRNEducationLevelBO().InsertQualification(objQualification);
                if (result > 0)
                {
                    Clear();
                    collapse = 1;
                    LoadQualification();
                }
            }

        }

        private void Clear()
        {
            txtQualification.Text = string.Empty;
            lblID.Text = string.Empty;
        }

        protected void gvQualification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int QualificationId = Convert.ToInt32(e.CommandArgument);
            string cmdName = e.CommandName;
            if (cmdName.Equals("cmdDelete"))
            {
                // Perform Delete Operation
                DTO.TRNEducationLevel objQualification = new DTO.TRNEducationLevel();
                objQualification.EducationalLevelID = QualificationId;
                objQualification.ModifiedBy = 1;
                objQualification.Status = 0;

                int result = new TRNEducationLevelBO().DeleteQualification(objQualification);
                LoadQualification();
            }

            if (cmdName.Equals("cmdEdit"))
            {
                // Show data to TextBoxes and controls
                DataView dvRecord = new TRNEducationLevelBO().SelectQualificationByID(QualificationId);
                if (dvRecord.Count > 0)
                {
                    lblID.Text = dvRecord.Table.Rows[0]["ID"].ToString();
                    txtQualification.Text = dvRecord.Table.Rows[0]["EducationLevel"].ToString();
                    collapse = 0;
                    btnSave.Text = "Update";
                }

            }
        }
    }
}