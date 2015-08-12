function OnLoad() {
    /*********** Employment ************************/
    $("#ctl00_TrainingBody_chkUnEmployment").attr('checked', 'checked');
    $("#ctl00_TrainingBody_txtSelfEmploymentIncome").attr("disabled", "disabled");
    $('#ctl00_TrainingBody_txtSelfEmploymentIncome').val('');

    /*************** Current Job *************************/
    $("#ctl00_TrainingBody_rbCurrentCountryNo").attr('checked', 'checked');
    $("#ctl00_TrainingBody_ddlWhichCountry").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtWorkingYears").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtWorkingMonths").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtOccupation").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtPreviousMonthlySalary").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtPreviousReturnDate").attr("disabled", "disabled");

    $("#ctl00_TrainingBody_ddlWhichCountry").val('0');
    $("#ctl00_TrainingBody_txtWorkingYears").val('');
    $("#ctl00_TrainingBody_txtWorkingMonths").val('');
    $("#ctl00_TrainingBody_txtOccupation").val('');
    $("#ctl00_TrainingBody_txtPreviousMonthlySalary").val('');
    $("#ctl00_TrainingBody_txtPreviousReturnDate").val('');

    /*************** Abroad Job *************************/
    $("#ctl00_TrainingBody_ddlCountry").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtDepartureDate").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtPastRecruitmentAgency").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtCompany").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_ddlEmploymentType").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_ddlEmploymentStatus").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtJobDoneMonth").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtEmploymentPeriod").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtMonthlySalary").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtForeignCurrency").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtReturnDate").attr("disabled", "disabled");
    $('#ctl00_TrainingBody_hfTraineeCheckList').val('');
    $("#ctl00_TrainingBody_ddlTraineeCheckList").attr("disabled", "disabled");

    $("#ctl00_TrainingBody_ddlCountry").val('0');
    $("#ctl00_TrainingBody_txtDepartureDate").val('');
    $("#ctl00_TrainingBody_txtPastRecruitmentAgency").val('');
    $("#ctl00_TrainingBody_txtCompany").val('');
    $("#ctl00_TrainingBody_ddlEmploymentType").val('0');
    $("#ctl00_TrainingBody_ddlEmploymentStatus").val('0');
    $("#ctl00_TrainingBody_txtEmploymentPeriod").val('');
    $("#ctl00_TrainingBody_txtJobDoneYear").val('');
    $("#ctl00_TrainingBody_txtMonthlySalary").val('');
    $("#ctl00_TrainingBody_txtForeignCurrency").val('');
    $("#ctl00_TrainingBody_txtReturnDate").val('');
    $("#ctl00_TrainingBody_ddlTraineeCheckList option:selected").removeAttr("selected");
    $('.selectpicker').selectpicker('refresh');

    /**************** Previous foreign Employment *****************/
    $("#ctl00_TrainingBody_txtTrainingName").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtTrainingYear").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtTrainingInstituteName").attr("disabled", "disabled");
    $("#ctl00_TrainingBody_txtTrainingDuration").attr("disabled", "disabled");
}


function ResetClick() {
    
        $("input#ctl00_TrainingBody_chkUnEmployment").click(function () {
            if ($(this).is(":checked")) {

                $("#ctl00_TrainingBody_txtSelfEmploymentIncome").attr("disabled", "disabled");

                $('#ctl00_TrainingBody_txtSelfEmploymentIncome').val('');

            } else {
                $("#ctl00_TrainingBody_txtSelfEmploymentIncome").removeAttr("disabled");

            }

        });

        $("input#ctl00_TrainingBody_rbCurrentCountryYes").click(function () {
            $("#ctl00_TrainingBody_ddlWhichCountry").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtWorkingYears").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtWorkingMonths").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtOccupation").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtPreviousMonthlySalary").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtPreviousReturnDate").removeAttr("disabled");
            $('.selectpicker').selectpicker('refresh');
        });

        $("input#ctl00_TrainingBody_rbCurrentCountryNo").click(function () {
            $("#ctl00_TrainingBody_ddlWhichCountry").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtWorkingYears").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtWorkingMonths").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtOccupation").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtPreviousMonthlySalary").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtPreviousReturnDate").attr("disabled", "disabled");
            $('.selectpicker').selectpicker('refresh');
        });

//         $("input#ctl00_TrainingBody_rdoAbroadYes").click(function () {
//             $("#ctl00_TrainingBody_txtCompany").removeAttr("disabled");
//             $("#ctl00_TrainingBody_txtCurrentRecruitmentAgency").removeAttr("disabled");
//        });

        $("input#ctl00_TrainingBody_rdoAbroadNo").click(function () {
            $("#ctl00_TrainingBody_ddlCountry").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtDepartureDate").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtPastRecruitmentAgency").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtCompany").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_ddlEmploymentType").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_ddlEmploymentStatus").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtEmploymentPeriod").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtMonthlySalary").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtForeignCurrency").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtReturnDate").attr("disabled", "disabled");
            $('#ctl00_TrainingBody_hfTraineeCheckList').val('');
            $("#ctl00_TrainingBody_ddlTraineeCheckList").attr("disabled", "disabled");

            $("#ctl00_TrainingBody_ddlCountry").val('0');
            $("#ctl00_TrainingBody_txtDepartureDate").val('');
            $("#ctl00_TrainingBody_txtPastRecruitmentAgency").val('');
            $("#ctl00_TrainingBody_txtCompany").val('');
            $("#ctl00_TrainingBody_ddlEmploymentType").val('0');
            $("#ctl00_TrainingBody_ddlEmploymentStatus").val('0');
            $("#ctl00_TrainingBody_txtEmploymentPeriod").val('');
            $("#ctl00_TrainingBody_txtMonthlySalary").val('');
            $("#ctl00_TrainingBody_txtForeignCurrency").val('');
            $("#ctl00_TrainingBody_txtReturnDate").val('');
            
            $("#ctl00_TrainingBody_ddlTraineeCheckList option:selected").removeAttr("selected");
            $('.selectpicker').selectpicker('refresh');
        });

        $("input#ctl00_TrainingBody_rdoAbroadYes").click(function () {
            $("#ctl00_TrainingBody_ddlCountry").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtDepartureDate").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtPastRecruitmentAgency").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtCompany").removeAttr("disabled");
            $("#ctl00_TrainingBody_ddlEmploymentType").removeAttr("disabled");
            $("#ctl00_TrainingBody_ddlEmploymentStatus").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtEmploymentPeriod").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtMonthlySalary").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtMonthlySalary").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtForeignCurrency").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtReturnDate").removeAttr("disabled");
            $("#ctl00_TrainingBody_ddlTraineeCheckList").removeAttr("disabled");
            $("#ctl00_TrainingBody_ddlTraineeCheckList option:selected").attr("selected");
            $('button').removeClass('disabled');
            $('.selectpicker li').each(function () {
                $(this).removeAttr('class');
            });

        });

        $("input#ctl00_TrainingBody_rbHavePreviousTrainingNo").click(function () {
            $("#ctl00_TrainingBody_txtTrainingName").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtTrainingYear").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtTrainingInstituteName").attr("disabled", "disabled");
            $("#ctl00_TrainingBody_txtTrainingDuration").attr("disabled", "disabled");

            $("#ctl00_TrainingBody_txtTrainingName").val('');
            $("#ctl00_TrainingBody_txtTrainingYear").val('');
            $("#ctl00_TrainingBody_txtTrainingInstituteName").val('');
            $("#ctl00_TrainingBody_txtTrainingDuration").val('');
        });

        $("input#ctl00_TrainingBody_rbHavePreviousTrainingYes").click(function () {
            $("#ctl00_TrainingBody_txtTrainingName").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtTrainingYear").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtTrainingInstituteName").removeAttr("disabled");
            $("#ctl00_TrainingBody_txtTrainingDuration").removeAttr("disabled");
        });
}