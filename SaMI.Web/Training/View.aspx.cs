using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaMI.Business;
using SaMI.DTO;
using System.Data;


namespace SaMI.Web.Training
{
    public partial class View : System.Web.UI.Page
    {
        public int TraineeID = 0;
        public int ethnicityID;
        public List<int> list = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString.Get("ID")))
                TraineeID = Convert.ToInt32(Request.QueryString.Get("ID"));

            if (!Page.IsPostBack)
            {
                LoadOptions();
                LoadAllData(TraineeID);
            }
        }

        void LoadOptions()
        {
            //GeoBased Ethnicity
            rbValidRegions.DataSource = EthnicityBO.SelectGeoBasedEthnicity();
            rbValidRegions.DataValueField = "GeoBasedEthnicityID";
            rbValidRegions.DataTextField = "GeoBasedEthnicityDesc";
            rbValidRegions.DataBind();
        }

        void LoadGeoBasedEthnicity()
        {
            rbValidRegions.DataSource = EthnicityBO.SelectGeoBasedEthnicity();
            rbValidRegions.DataValueField = "GeoBasedEthnicityID";
            rbValidRegions.DataTextField = "GeoBasedEthnicityDesc";
            rbValidRegions.DataBind();
        }

        private void LoadAllData(int TraineeID)
        {
            LoadTrainee(TraineeID);
            LoadCurrentEmployment(TraineeID);
            LoadEmployment(TraineeID);
            LoadPreviousTraining(TraineeID);
        }

        void LoadValidRegions()
        {
            List<int> lstValidRegions = EthnicityBO.SelectValidRegionForEthnicity(ethnicityID);

            if (lstValidRegions.Count > 0)
            {

                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {

                    if (lstValidRegions.Exists(delegate(int region) { return region == Convert.ToInt32(rbValidRegions.Items[j].Value); }))
                    {
                    }
                    else
                        list.Add(j);

                }
                foreach (int a in list)
                {
                    rbValidRegions.Items[a].Attributes.Add("hidden", "hidden");
                }

            }
            else
            {
                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {
                    rbValidRegions.Items[j].Attributes.Add("hidden", "hidden");

                }
            }
        }

        private void LoadTrainee(int TraineeID)
        {
            TRNTrainee objTrainee = TRNTraineeBO.GetTraineeByID(TraineeID);

            ethnicityID = EthnicityBO.GetEthnicity(objTrainee.EthnicityID).EthnicityID;
            LoadValidRegions();
            txtQualification.Text = TRNEducationLevelBO.GetAll(objTrainee.EducationLevelID).EducationLevel;
            txtInformationSource.Text = TRNInformaitonSourceBO.GetAll(objTrainee.InformationSourceID).InformationSource;
            txtDistrict.Text = DistrictBO.GetDistrict(objTrainee.DistrictID).DistrictName;
            txtVDC.Text = VDCBO.GetVDC(objTrainee.VDCID).VDCName;
            txtEthnicity.Text = EthnicityBO.GetEthnicity(objTrainee.EthnicityID).EthnicityName;

            List<int> lstValidRegions = EthnicityBO.SelectValidRegionsForTrainee(ethnicityID, TraineeID);


            if (lstValidRegions.Count > 0)
            {
                for (int j = 0; j < rbValidRegions.Items.Count; j++)
                {
                    if (lstValidRegions.Exists(delegate(int region) { return region == Convert.ToInt32(rbValidRegions.Items[j].Value); }))
                    {
                        rbValidRegions.Items[j].Selected = true;
                    }

                }
            }


            txtFeedDurationType.Text = FeedDurationTypeBO.GetFeedDurationType(objTrainee.FeedDurationTypeID).FeedDurationTypeDesc;
            txtCitizenshipIssuedDistict.Text = DistrictBO.GetDistrict(objTrainee.CitizenshipIssueDistictID).DistrictName;
            txtGender.Text = objTrainee.Gender;
            txtMaritalStatus.Text = objTrainee.MaritalStatus;
            

            txtFirstName.Text = objTrainee.FirstName;
            txtLastName.Text = objTrainee.LastName;
            txtDateOfBirthAD.Text = objTrainee.DateOfBirthAD;
            txtDateOfBirthBS.Text = objTrainee.DateOfBirthBS;
            txtAge.Text = objTrainee.CurrentAge;
            hfSpecialCase.Value = objTrainee.SpecialCase;
            txtSpecialCase.Text = objTrainee.SpecialCase;
            txtTol.Text = objTrainee.Tole;
            txtWardNumber.Text = objTrainee.WardNumber;
            txtPhoneNumberHouse.Text = objTrainee.PhoneNumber;
            txtMobile.Text = objTrainee.MobileNumber;
            txtCitizenshipNumber.Text = objTrainee.CitizenshipNumber;
            txtPassportNumber.Text = objTrainee.PassportNumber;
            txtFathersName.Text = objTrainee.FatherName;
            txtFathersContactNumber.Text = objTrainee.FatherTelephone;
            txtContactPerson.Text = objTrainee.ContactPerson;
            txtContactPersonContactTelephone.Text = objTrainee.ContactPersonTelephone;
            ImgPrv.ImageUrl = objTrainee.Photo;
            if (Convert.ToInt32(objTrainee.Unemployment) == 1)
            {
                chkUnEmployment.Checked = true;
                txtSelfEmploymentIncome.Enabled = false;
            }
            else
            {
                chkUnEmployment.Checked = false;
                txtSelfEmploymentIncome.Text = objTrainee.SelfEmployment.ToString();
            }

            txtWageIncome.Text = objTrainee.Wage.ToString();
            txtAgricultureIncome.Text = objTrainee.Agriculture.ToString();
            txtForeignIncome.Text = objTrainee.ForeignEmploymentIncome.ToString();
            txtOtherIncome.Text = objTrainee.Other.ToString();

            //txtTrainingRegistrationDate.Text = objTrainee.RegisteredDate.ToShortDateString();
            txtFamilyMember.Text = objTrainee.NoOfFamilyMember.ToString();

            txtReferredBy.Text = objTrainee.ReferredBy;

        }

        private void LoadCurrentEmployment(int TraineeID)
        {
            DataView dvCurrentEmploymentInfo = TRNCurrentEmploymentBO.GetByID(TraineeID);
            if (dvCurrentEmploymentInfo.Count > 0)
            {
                if (dvCurrentEmploymentInfo.Table.Rows[0]["CountryID"].ToString() != "")
                {
                    rbCurrentCountryYes.Checked = true;
                    txtWhichCountry.Text = dvCurrentEmploymentInfo.Table.Rows[0]["CountryName"].ToString();
                    txtWorkingYears.Text = dvCurrentEmploymentInfo.Table.Rows[0]["WorkingYear"].ToString();
                    txtWorkingMonths.Text = dvCurrentEmploymentInfo.Table.Rows[0]["WorkingMonth"].ToString();
                    txtOccupation.Text = dvCurrentEmploymentInfo.Table.Rows[0]["Occupation"].ToString();
                    txtPreviousMonthlySalary.Text = dvCurrentEmploymentInfo.Table.Rows[0]["MonthlySalary"].ToString();
                    txtPreviousReturnDate.Text = dvCurrentEmploymentInfo.Table.Rows[0]["ReturnDate"].ToString();
                }
                else
                {
                    rbCurrentCountryNo.Checked = true;
                }
            }
            else
            {
                rbCurrentCountryNo.Checked = true;
            }
        }

        private void LoadEmployment(int TraineeID)
        {
            DataView dvEmploymentInfo = TRNEmploymentBO.GetByID(TraineeID);
            if (dvEmploymentInfo.Count > 0)
            {
                if (dvEmploymentInfo.Table.Rows[0]["CountryID"].ToString() != "")
                {
                    rdoAbroadYes.Checked = true;

                    txtCountry.Text = dvEmploymentInfo.Table.Rows[0]["CountryName"].ToString();
                    txtRecruitmentAgency.Text = dvEmploymentInfo.Table.Rows[0]["RecruitmentAgency"].ToString();
                    txtOrganization.Text = dvEmploymentInfo.Table.Rows[0]["Organization"].ToString();
                    txtEmploymentStatus.Text = dvEmploymentInfo.Table.Rows[0]["EmploymentStatus"].ToString();
                    txtEmploymentType.Text = dvEmploymentInfo.Table.Rows[0]["EmploymentType"].ToString();
                    txtDepartureDate.Text = dvEmploymentInfo.Table.Rows[0]["DepartureDate"].ToString();
                    txtEmploymentPeriod.Text = dvEmploymentInfo.Table.Rows[0]["EmploymentPeriod"].ToString();
                    txtMonthlySalary.Text = dvEmploymentInfo.Table.Rows[0]["Salary"].ToString();
                    txtForeignCurrency.Text = dvEmploymentInfo.Table.Rows[0]["Currency"].ToString();
                    txtReturnDate.Text = dvEmploymentInfo.Table.Rows[0]["ReturnDate"].ToString();

                    if (dvEmploymentInfo.Table.Rows[0]["Unemployment"].ToString() == "1")
                    {
                        chkUnEmployment.Checked = true;
                    }
                    else
                    {
                        chkUnEmployment.Checked = false;
                    }

                    DataView dvCheckList = TRNEmploymentBO.GetCheckList(TraineeID);
                    string value = "";
                    foreach (DataRowView drv in dvCheckList)
                    {
                        if (drv["ChecklistID"] != null)
                        {

                            value += drv["ChecklistID"] + ",";
                        }
                    }

                    hfTraineeCheckList.Value = value;
                    txtTraineeCheckList.Text = value;
                }

                else
                {
                    rdoAbroadNo.Checked = true;
                }
            }
            else
            {
                rdoAbroadNo.Checked = true;
            }

        }

        private void LoadPreviousTraining(int TraineeID)
        {
            DataView dvPreviousTrainingInfo = TRNPreviousTrainingBO.GetPreviousTrainingInfoByID(TraineeID);
            if (dvPreviousTrainingInfo.Count > 0)
            {
                if (dvPreviousTrainingInfo.Table.Rows[0]["Name"].ToString() != "")
                {
                    rbHavePreviousTrainingYes.Checked = true;

                    txtTrainingName.Text = dvPreviousTrainingInfo.Table.Rows[0]["Name"].ToString();
                    txtTrainingYear.Text = dvPreviousTrainingInfo.Table.Rows[0]["Year"].ToString();
                    txtTrainingInstituteName.Text = dvPreviousTrainingInfo.Table.Rows[0]["Institute"].ToString();
                    txtTrainingDuration.Text = dvPreviousTrainingInfo.Table.Rows[0]["Duration"].ToString();

                }
                else
                {
                    rbHavePreviousTrainingNo.Checked = true;
                    txtTrainingName.Enabled = false;
                    txtTrainingYear.Enabled = false;
                    txtTrainingInstituteName.Enabled = false;
                    txtTrainingDuration.Enabled = false;
                }
            }
            else
            {
                rbHavePreviousTrainingNo.Checked = true;
                txtTrainingName.Enabled = false;
                txtTrainingYear.Enabled = false;
                txtTrainingInstituteName.Enabled = false;
                txtTrainingDuration.Enabled = false;
            }
        }
        
    }
}