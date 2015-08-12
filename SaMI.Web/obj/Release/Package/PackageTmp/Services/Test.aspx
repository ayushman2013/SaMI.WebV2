<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Services.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script type="text/javascript">
        function CallHandler() {
            $.ajax({
                url: "testHandler.ashx",
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                dataType: "json",
                data: JSON.stringify([{"registered" : "111"}]),
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
