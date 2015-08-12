function ValidateInput(validatePassword) {
    var validation = true;
    var message = '<ul>';


    if ($('#ctl00_MainContent_ddlUserType').val() == '0') {
        validation = false;
        message += "<li>Please select User Type.</li>";
    } else if ($('#ctl00_MainContent_ddlUserType option:selected').text() == 'Case Partner') {
        if ($('#ctl00_MainContent_ddlPartner').val() == 0) {
            validation = false;
            message += "<li>Please select Partner.</li>";
        }
    } else if ($('#ctl00_MainContent_ddlUserType option:selected').text() == 'Skill Partner') {
        if ($('#ctl00_MainContent_ddlSkillPartner').val() == 0) {
            validation = false;
            message += "<li>Please select Skill Partner.</li>";
        }
    }
    
    if ($('#ctl00_MainContent_ddlDistrict').val() == '0') {
        validation = false;
        message += "<li>Please select District.</li>";
    }
    if ($('#ctl00_MainContent_txtFullName').val() == '') {
        validation = false;
        message += "<li>Full Name is empty.</li>";
    }
    if ($('#ctl00_MainContent_txtUserName').val() == '') {
        validation = false;
        message += "<li>User Name is empty.</li>";
    }
    if ($('#ctl00_MainContent_txtPassword').val() == '') {
        validation = false;
        message += "<li>Password is empty.</li>";
    }

    if (validatePassword) {
        if ($('#ctl00_MainContent_txtPassword').val() == '') {
            validation = false;
            message += "<li>Password is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtConfirmPassword').val() == '') {
            validation = false;
            message += "<li>Confirm Password is empty.</li>";
        }
        if ($('#ctl00_MainContent_txtPassword').val() != '' && $('#ctl00_MainContent_txtConfirmPassword').val() != '') {
            if ($('#ctl00_MainContent_txtConfirmPassword').val() != $('#ctl00_MainContent_txtPassword').val()) {
                validation = false;
                message += "<li>Password & Confirm Password mis-matched.</li>";
            }
        }
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }
    
    return true;


}


function ValidateChangePassword() {
    var validation = true;
    var message = '<ul>';

    if ($('#ctl00_MainContent_txtOldPassword').val() == '') {
        validation = false;
        message += "<li>Old Password is empty.</li>";
    }
    if ($('#ctl00_MainContent_txtNewPassword').val() == '') {
        validation = false;
        message += "<li>New Password is empty.</li>";
    }
    if ($('#ctl00_MainContent_txtConfirmNewPassword').val() == '') {
        validation = false;
        message += "<li>Confirm New Password is empty.</li>";
    }
    if ($('#ctl00_MainContent_txtNewPassword').val() != '' && $('#ctl00_MainContent_txtConfirmNewPassword').val() != '') {
        if ($('#ctl00_MainContent_txtNewPassword').val() != $('#ctl00_MainContent_txtConfirmNewPassword').val()) {
            validation = false;
            message += "<li>New Password & Confirm New Password mis-matched.</li>";
        }
    }

    if (!validation) {
        message += "</ul>";
        $('#modal-body-text').html(message);
        $('#validationModal').modal('show');
        return false;
    }

    return true;
}

function EnableDisablePartner() {

    if ($('#ctl00_MainContent_ddlUserType option:selected').text() == 'Case Partner') {
        $('#ctl00_MainContent_ddlPartner').removeAttr('disabled');
        $('#ctl00_MainContent_ddlSaMIOrganization').attr('disabled', 'disabled');
        $('#ctl00_MainContent_ddlSaMIOrganization').val('0');

    }
    else {
        $('#ctl00_MainContent_ddlPartner').val('0');
        $('#ctl00_MainContent_ddlPartner').attr('disabled', 'disabled');
        $('#ctl00_MainContent_ddlSaMIOrganization').removeAttr('disabled');
    }

    if ($('#ctl00_MainContent_ddlUserType option:selected').text() == 'Skill Partner') {
        $('#ctl00_MainContent_ddlSkillPartner').removeAttr('disabled');
        $('#ctl00_MainContent_ddlSaMIOrganization').attr('disabled', 'disabled');
        $('#ctl00_MainContent_ddlSaMIOrganization').val('0');
    }
    else {
        $('#ctl00_MainContent_ddlSkillPartner').val('0');
        $('#ctl00_MainContent_ddlSkillPartner').attr('disabled', 'disabled');
        $('#ctl00_MainContent_ddlSaMIOrganization').removeAttr('disabled');
    }
}