<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Services.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script type="text/javascript">
        function CallHandler() {
            $.ajax({
                url: "RequestHandler.ashx",
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                dataType: "json",
                data: JSON.stringify([{ "registrationNumber": "REG-1234", "howYouKnowIC": "Social Mobilizer(LGCDP/PAF)", "frequencyOfVisit": "Once", "reasonForVisiting": "General Inquiry", "permanentVDC": "Amahibelaha", "phone": "1234567", "permanentWard": "8", "gpsLongitude": "10.22222222220", "maritalStatus": "Divorced", "gpsLatitude": "30.033333333", "informationSource": "Self", "familyMembersC": "Select", "id": "2", "familyMembersD": "Select", "familyMembersA": "Select", "familyMembersB": "Select", "registrationDate": "3\/30\/2014", "age": "18-20", "gender": "Male", "district": "Jhapa", "fname": "kabindra", "phoneFamily": "", "mname": "", "temporaryDistrict": "Sunsari", "temporaryVDC": "Amahibelaha", "lname": "shrestha", "isDiscriminated": "false", "permanentDetails": "kkjjaghhhhhh", "uploaded": "false", "casteCaste": "Biswas", "presentOccupation": "Mason", "picture": "", "temporaryWard": "8", "permanentDistrict": "Sunsari", "educationalStatus": "Less than class 5", "casteEthnicity": "Indigenous", "fullName": "kabindra shrestha", "temporaryDetails": "kkjj", "temporarySameAsPermanent": "true"}]),
                success: OnComplete,
                error: OnFail,
                beforeSend: setHeader
            });
            return false;
        }

        function OnComplete(result) {
            var obj = jQuery.parseJSON(JSON.stringify(result));
            alert(obj.data)
        }
        function OnFail(result) {
            alert('Request Failed');
        }
        function setHeader(xhr) {
            alert('test');
            xhr.setRequestHeader('Authorization', 'YWRtaW46SGVsdmV0YXMxIQ==');
        }
        CallHandler();
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
