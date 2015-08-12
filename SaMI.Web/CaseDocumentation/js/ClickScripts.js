function ResetClick() {
        $("#ctl00_MainContent_txtRegistrationDate").datepicker();
        $("#ctl00_MainContent_txtDateofRefferal").datepicker();
        $("#ctl00_MainContent_txtCaseFollowUpDate").datepicker();
        $("#ctl00_MainContent_txtFollowUpDate").datepicker();
        $("#ctl00_MainContent_txtCaseRegisteredDate").datepicker();
        $("#ctl00_MainContent_txtTrainingStartDate").datepicker();
        $("#ctl00_MainContent_txtEmploymentStartDate").datepicker();
        $("#ctl00_MainContent_txtTrainingRegistrationDate").datepicker();
        $("#ctl00_MainContent_txtReferralDate").datepicker();
    }

    $(function () {
        $("#ctl00_MainContent_txtCompensationAmount").keypress(function (e) {
            if ((e.which != 8 && e.which != 0) && (e.which < 48 || e.which > 57)) {
                return false;
            }
        });
    });