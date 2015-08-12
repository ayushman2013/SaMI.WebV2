function PopulateCastes() {
    $("#ctl00_MainContent_ddlCaste").attr("disabled", "disabled");
    if ($('#ctl00_MainContent_ddlEthnicity').val() == "0") {
        $('#ctl00_MainContent_ddlCaste').empty().append('<option selected="selected" value="0">[Select Caste]</option>');
    }
    else {
        $('#ctl00_MainContent_ddlCaste').empty().append('<option selected="selected" value="0">Loading...</option>');
        $.ajax({
            type: "POST",
            url: pageUrl + '/PopulateCastes',
            data: '{ethnicityID: ' + $('#ctl00_MainContent_ddlEthnicity').val() + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnCastesPopulated,
            failure: function (response) {
                alert(response.d);
            }
        });
    }
}
function OnCastesPopulated(response) {
    PopulateControl(response.d, $("#ctl00_MainContent_ddlCaste"), '[Caste]');
}

function PopulateControl(list, control, msg) {
    if (list.length > 0) {
        control.removeAttr("disabled");
        control.empty().append('<option selected="selected" value="0">' + msg + '</option>');
        $.each(list, function () {
            control.append($("<option></option>").val(this['Value']).html(this['Text']));
        });
    }
    else {
        control.empty().append('<option selected="selected" value="0">Not available<option>');
    }
}

