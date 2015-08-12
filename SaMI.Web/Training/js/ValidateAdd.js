function ValidateTraineeProfile() {
    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_TrainingBody_txtFirstName').val() == '') {
        validation = false;
        message += "<li>First Name is empty.</li>";
    }

    if ($('#ctl00_TrainingBody_txtLastName').val() == '') {
        validation = false;
        message += "<li>Last Name is empty.</li>";
    }

    if ($('#ctl00_TrainingBody_ddlGender').val() == '0') {
        validation = false;
        message += "<li>Please select Gender.</li>";
    }

    if ($('#ctl00_TrainingBody_ddlMaritalStatus').val() == '0') {
        validation = false;
        message += "<li>Please select Marital Status.</li>";
    }

    if ($('#ctl00_TrainingBody_txtDateOfBirthBS').val() == '') {
        validation = false;
        message += "<li>Please select Date of Birth (BS).</li>";
    }

    if ($('#ctl00_TrainingBody_ddlQualification').val() == '0') {
        validation = false;
        message += "<li>Please select Qualification.</li>";
    }

    if ($('#ctl00_TrainingBody_ddlCastEthinicity').val() == null || $('#ctl00_TrainingBody_ddlCastEthinicity').val() == '0') {
        validation = false;
        message += "<li>Please select Ethnicity</li>";
    }

    message += "<br/>";


    if ($('#ctl00_TrainingBody_ddlDistrict').val() == '0') {
        validation = false;
        message += "<li>Please select District.</li>";
    }

    if ($('#ctl00_TrainingBody_ddlVDC').val() == '0') {
        validation = false;
        message += "<li>Please select VDC.</li>";
    }

    if ($('#ctl00_TrainingBody_txtWardNumber').val() == '') {
        validation = false;
        message += "<li>Ward is empty.</li>";
    }

    if ($('#ctl00_TrainingBody_txtPhoneNumberHouse').val() == '') {
        validation = false;
        message += "<li>Phone Number is Empty.</li>";
    }

    if ($('#ctl00_TrainingBody_txtFathersName').val() == '') {
        validation = false;
        message += "<li>Father's Name is empty.</li>";
    }

    if ($('#ctl00_TrainingBody_txtCitizenshipNumber').val() == '') {
        validation = false;
        message += "<li>Citizenship No. is empty.</li>";
    }

    if ($('#ctl00_TrainingBody_ddlCitizenshipIssuedDistict').val() == '0') {
        validation = false;
        message += "<li>Please select Citizenship Issued District.</li>";
    }
    
    if ($('#ctl00_TrainingBody_txtReferredBy').val() == '') {
        validation = false;
        message += "<li>Referred By is empty.</li>";
    }

    message += "<br/>";


    
    if ($('#ctl00_TrainingBody_ddlInformationSource').val() == '0') {
        validation = false;
        message += "<li>Please select Information Source.</li>";
    }

    message += "<br/>";

    if ($('#ctl00_TrainingBody_txtFamilyMember').val() == '') {
        validation = false;
        message += "<li>Family Member is empty.</li>";
    }

   

    if ($('#ctl00_TrainingBody_ddlFeedDurationTypeID').val() == '') {
        validation = false;
        message += "<li>Please select Feed Duratation Type.</li>";
    }

    message += "<br/>";

    if ($('#ctl00_TrainingBody_rdoAbroadYes').is(':checked')) {
        if ($('#ctl00_TrainingBody_txtDepartureDate').val() == '') {
            validation = false;
            message += "<li>Departure Date is empty.</li>";
        }
        if ($('#ctl00_TrainingBody_ddlCountry').val() == '0') {
            validation = false;
            message += "<li>Please select Country</li>";
        }
        if ($('#ctl00_TrainingBody_ddlRecruitmentAgency').val() == '0') {
            validation = false;
            message += "<li>Please select Recruitment Agency</li>";
        }
        if ($('#ctl00_TrainingBody_ddlOrganization').val() == '0') {
            validation = false;
            message += "<li>Please select Organization.</li>";
        }
        if ($('#ctl00_TrainingBody_ddlEmploymentType').val() == '0') {
            validation = false;
            message += "<li>Please select Employment Type.</li>";
        }
        if ($('#ctl00_TrainingBody_ddlEmploymentStatus').val() == '0') {
            validation = false;
            message += "<li>Please select Employment Status</li>";
        }
        if ($('#ctl00_TrainingBody_txtMonthlySalary').val() == '') {
            validation = false;
            message += "<li>Monthly salary is empty.</li>";
        }
        if ($('#ctl00_TrainingBody_hfTraineeCheckList').val() == '') {
            validation = false;
            message += "<li>Please select Check List.</li>";
        }
        else {
            validation = true;
        }
    }

    message += "<br/>";

    if ($('#ctl00_TrainingBody_rbHavePreviousTrainingYes').is(':checked')) {
        if ($('#ctl00_TrainingBody_txtTrainingName').val() == '') {
            validation = false;
            message += "<li>Training Name is empty.</li>";
        }
        if ($('#ctl00_TrainingBody_txtTrainingYear').val() == '') {
            validation = false;
            message += "<li>Training Year is empty.</li>";
        }
        if ($('#ctl00_TrainingBody_txtTrainingInstituteName').val() == '') {
            validation = false;
            message += "<li>Institute Name is empty.</li>";
        }
        if ($('#ctl00_TrainingBody_txtTrainingDuration').val() == '') {
            validation = false;
            message += "<li>Training Duration is empty.</li>";
        }
       

    }


    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return validation;
}