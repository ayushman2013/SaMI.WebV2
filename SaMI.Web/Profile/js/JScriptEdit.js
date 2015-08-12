function showSaveStatus() {

}
function AddCaseFollowUp() {
    if (ValidateCaseFollowUp()) {
        $('#casefollowup').modal('hide')
        return true;
    }
    else
        return false;
    
}

function AddOtherCase() {
    if (ValidateOtherCase()) {
        $('#casedocumentationothercases').modal('hide')
        return true;
    }
    else
        return false;
}

function AddOtherFollowUp() {
    if (ValidateOtherFollowUp()) {
        $('#followupservices').modal('hide')
        return true;
    }
    else
        return false;
   
}

function AddOtherMigrant() {
    if (ValidateOtherMigrant()) {
        $('#myModal').modal('hide')
        return true;
    }
    else
        return false;

}

function AddEmployment() {
    if (ValidateEmployment()) {
        $('#employment').modal('hide')
        return true;
    }
    else
        return false;
}


function SaveProfile() {
    if (ValidateGeneranlInfo()) {
        $('#divProgressBar').modal('show')
        setTimeout(function () { $('#divSaveMessage').modal('show') }, 800);
        //setTimeout(function () { $('#divProgressBar').modal('hide') }, 2000);
        return true;
    }
    else return false;
}

function SaveForeignEmployment() {
    if (ValidateForeignEmployment()) {
        $('#divProgressBar').modal('show')
        setTimeout(function () { $('#divSaveMessage').modal('show') }, 800);
        //setTimeout(function () { $('#divProgressBar').modal('hide') }, 2000);
        return true;
    }
    else return false;
}

function SaveOptionalInformation() {
    if (ValidateOptionalInfo()) {
        $('#divProgressBar').modal('show')
        setTimeout(function () { $('#divSaveMessage').modal('show') }, 800);
        //setTimeout(function () { $('#divProgressBar').modal('hide') }, 2000);
        return true;
    }
    else return false;
}

function SaveServices() {
    if (ValidateServices()) {
        $('#divProgressBar').modal('show')
        setTimeout(function () { $('#divSaveMessage').modal('show') }, 800);
        //setTimeout(function () { $('#divProgressBar').modal('hide') }, 2000);
        return true;
    }
    else return false;
}

function SaveCaseDocumentation() {
    if (ValidateCaseRefferal()) {
        $('#divProgressBar').modal('show')
        //setTimeout(function () { $('#divProgressBar').modal('hide') }, 2000);
        return true;
    }
    else return false;
}

function SaveSkill() {
    if (ValidateSkill()) {
        $('#divProgressBar').modal('show')
        return true;
    }
    else return false;
}

function AddPerviousForeignExperience() {
    if (ValidatePerviousForeignExperience()) {
        $('#preFeExperienceModal').modal('hide')
        return true;
    }
    else return false;
}

function AddCaseReferralHistory() {
    if (ValidateCaseReferralHistory()) {
        $('#casereferrals').modal('hide')
        return true;
    }
    else return false;
}

function ShowHideButton(name) {
    
            if (name == 'general') {
                $("#ctl00_MainContent_btnSave").show();
                $("#ctl00_MainContent_btnSaveForeignEmployment").hide();
                $("#ctl00_MainContent_btnSaveOptionalInformation").hide();
                $("#ctl00_MainContent_btnSaveServices").hide();
                $("#ctl00_MainContent_btnSaveCaseDocumentation").hide();
                $("#ctl00_MainContent_btnSaveSkills").hide();
                $("#ctl00_MainContent_btnSavePhoneFollowUp").hide();
            }
            else if (name == 'foreign') {

                $("#ctl00_MainContent_btnSaveForeignEmployment").show();
                $("#ctl00_MainContent_btnSave").hide();
                $("#ctl00_MainContent_btnSaveOptionalInformation").hide();
                $("#ctl00_MainContent_btnSaveServices").hide();
                $("#ctl00_MainContent_btnSaveCaseDocumentation").hide()
                $("#ctl00_MainContent_btnSaveSkills").hide();
                $("#ctl00_MainContent_btnSavePhoneFollowUp").hide();
            }

            else if (name == 'optional') {
                $("#ctl00_MainContent_btnSaveOptionalInformation").show();
                $("#ctl00_MainContent_btnSave").hide();
                $("#ctl00_MainContent_btnSaveForeignEmployment").hide();
                $("#ctl00_MainContent_btnSaveServices").hide();
                $("#ctl00_MainContent_btnSaveCaseDocumentation").hide();
                $("#ctl00_MainContent_btnSaveSkills").hide();
                $("#ctl00_MainContent_btnSavePhoneFollowUp").hide();
            }
            else if (name == 'casedocumentation') {
                $("#ctl00_MainContent_btnSaveCaseDocumentation").show();
                $("#ctl00_MainContent_btnSave").hide();
                $("#ctl00_MainContent_btnSaveForeignEmployment").hide();
                $("#ctl00_MainContent_btnSaveOptionalInformation").hide();
                $("#ctl00_MainContent_btnSaveServices").hide();
                $("#ctl00_MainContent_btnSaveSkills").hide();
                $("#ctl00_MainContent_btnSavePhoneFollowUp").hide();
            }
            else if (name == 'servicesandfollowup') {
                $("#ctl00_MainContent_btnSaveServices").show();
                $("#ctl00_MainContent_btnSave").hide();
                $("#ctl00_MainContent_btnSaveForeignEmployment").hide();
                $("#ctl00_MainContent_btnSaveOptionalInformation").hide();
                $("#ctl00_MainContent_btnSaveCaseDocumentation").hide();
                $("#ctl00_MainContent_btnSaveSkills").hide();
                $("#ctl00_MainContent_btnSavePhoneFollowUp").hide();
            }
            else if (name == 'skills') {
                $("#ctl00_MainContent_btnSaveSkills").show();
                $("#ctl00_MainContent_btnSave").hide();
                $("#ctl00_MainContent_btnSaveForeignEmployment").hide();
                $("#ctl00_MainContent_btnSaveOptionalInformation").hide();
                $("#ctl00_MainContent_btnSaveCaseDocumentation").hide();
                $("#ctl00_MainContent_btnSaveServices").hide();
                $("#ctl00_MainContent_btnSavePhoneFollowUp").hide();
            }
            else if (name == 'tabemployment') {
                $("#ctl00_MainContent_btnSaveSkills").hide();
                $("#ctl00_MainContent_btnSave").hide();
                $("#ctl00_MainContent_btnSaveForeignEmployment").hide();
                $("#ctl00_MainContent_btnSaveOptionalInformation").hide();
                $("#ctl00_MainContent_btnSaveCaseDocumentation").hide();
                $("#ctl00_MainContent_btnSaveServices").hide();
                $("#ctl00_MainContent_btnSavePhoneFollowUp").hide();
            }
            else if (name == 'phonefollowup') {
                $("#ctl00_MainContent_btnSavePhoneFollowUp").show();
                $("#ctl00_MainContent_btnSaveSkills").hide();
                $("#ctl00_MainContent_btnSave").hide();
                $("#ctl00_MainContent_btnSaveForeignEmployment").hide();
                $("#ctl00_MainContent_btnSaveOptionalInformation").hide();
                $("#ctl00_MainContent_btnSaveCaseDocumentation").hide();
                $("#ctl00_MainContent_btnSaveServices").hide();
            }
}

function SavePhoneFollowUp() {
    if (ValidatePhoneFollowUp()) {
        $('#divProgressBar').modal('show')
        setTimeout(function () { $('#divSaveMessage').modal('show') }, 600);
        //setTimeout(function () { $('#divProgressBar').modal('hide') }, 2000);
        return true;
    }
    else return false;
}

function AddPhoneFollowUp() {
    if (ValidatePhoneFollowUpInfo()) {
        $('#divProgressBar').modal('show')
        setTimeout(function () { $('#divSaveMessage').modal('show') }, 600);
        $('#PhoneFollowUpInfo').modal('hide');
        return true;
    }
    else
        return false;

}
