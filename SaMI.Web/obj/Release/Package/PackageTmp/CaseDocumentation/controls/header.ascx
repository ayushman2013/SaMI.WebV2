<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="SaMI.Web.CaseDocumentation.controls.header" %>

<header class="navbar navbar-default navbar-fixed-top bs-docs-nav" role="banner">
            <div class="container">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".bs-navbar-collapse">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" href="/DashBoard.aspx"><img src="/images/logo-SaMi.gif"></a>
                    </div>

                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <nav class="collapse navbar-collapse bs-navbar-collapse" role="navigation">
                        <ul class="nav navbar-nav">
                         
                        <li><a href="/CaseDocumentation/Index.aspx">Case Profile</a></li>
                        <li><a href="/CaseDocumentation/RecruitmentList.aspx">Recruitment List</a></li>
                          
                        </ul>
                        
                        <ul class="nav navbar-nav navbar-right">
                            <li>
                                <a href="#" onclick="$('#divReminder').modal('show');return false;"><span class="glyphicon glyphicon-warning-sign" style="color:Red; font-size:17px;"></span></a>
                            </li>
                            <li>
                                <a><asp:Label ID="lblLoginName" runat="server" Text=""></asp:Label></a>
                            </li>
                            <li><a href="/Login.aspx">Log Out</a></li>
                                     
                            <%Response.Write(GetSettingsURL()); %>
                        </ul>
                    </nav><!-- /.navbar-collapse -->
            </div>
        </header>

       
