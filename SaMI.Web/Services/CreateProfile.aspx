<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="SaMI.Web.Services.CreateProfile" %>
<script type="text/javascript" src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
<script type="text/javascript">
    jsonData = '{ "dateStamp":"2010_01_01", "stringParam": "hello" }';
    $(document).ready(function () {
        $.ajax({
            url: 'Profile.ashx',
            data: jsonData,
            dataType: 'json',
            type: 'POST',
            success: function (response) {
                for (var i = 0; i < response.Data.length; i++) {
                    alert(response.Data[i]);
                }
            },
            error: function (data, status, jqXHR) {
                alert('There was an error.');
            }
        });
    });
</script>
