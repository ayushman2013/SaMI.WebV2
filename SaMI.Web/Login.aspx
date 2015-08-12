<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SaMI.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if lt IE 7 ]><html class="ie ie6" lang="en"> <![endif]-->
<!--[if IE 7 ]><html class="ie ie7" lang="en"> <![endif]-->
<!--[if IE 8 ]><html class="ie ie8" lang="en"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!-->
<html xmlns="http://www.w3.org/1999/xhtml">
<!--<![endif]-->
<head runat="server">
     <!-- Basic Page Needs
          ================================================== -->
        <meta charset="utf-8">
        <meta name="description" content="">
        <meta name="author" content="">
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
        <title>SaMII - HELVETAS Nepal :: Login</title>
        <link rel="stylesheet" href="assets/css/bootstrap.min.css">
        <link rel="stylesheet" href="assets/css/bootstrap-theme.min.css">
        <link rel="stylesheet" href="assets/css/layout.css">
        <script type="text/javascript" src="assets/js/jquery.js"></script>
        <script type="text/javascript" src="assets/js/jquery.validate.min.js"></script>
        <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    
</head>
<body>
    
     <div class="container well loginBox" style="margin: 10px auto 0; border:  1px solid #ccc; width:500px; background-color: #f5f5f5 ; z-index:1000;position: relative;">
            <div class="col-md-5" style="margin-top:20px;">
                <a class="navbar-brand" href="#"><img src="/images/logo-SaMi.gif"></a>
               <div style="width: 100%; clear:both; padding:0px;">                        
                    <div><h4>Web-based Monitoring System</h4></div>
                </div>
            </div>
            
            <div class="col-md-7" style="border-left:1px solid #aaa;">                
                <div>
                    <div style="width: 100%;">
                        <h2 style="margin: 0 0 0 0;">USER LOGIN</h2>
                    </div>
                </div>
                <div style="margin-top: 20px;">
                    <form id="form1" runat="server" class="validate">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control input-sm required" placeholder="User Name" ></asp:TextBox>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control input-sm required" placeholder="Password" TextMode="Password"></asp:TextBox>
                        
                        <div style="margin: 5px 0 0 0;">
                            <asp:Button ID="btnLogin" CssClass="btn btn-primary" Text="LOG IN" runat="server" 
                                style="margin: 0 auto 0; width: 100%" onclick="btnLogin_Click" />
                            
                        </div>
                    </form>
                    <a href="#">Forget your password</a>                    
                        <asp:Label ID="lblStatus" CssClass="errorTxt" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                $('.validate').validate({
                    errorPlacement: function () {
                        return false;
                    },
                    rules: {
                        txtUserName: {
                            required: true
                        },
                        txtPassword: {
                            required: true
                        }
                    }
                });
            });
        </script>
    
</body>
</html>
