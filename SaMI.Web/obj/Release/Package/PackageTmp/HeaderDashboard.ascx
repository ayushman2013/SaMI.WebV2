<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderDashboard.ascx.cs" Inherits="SaMI.Web.HeaderDashboard" %>
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
                        <a class="navbar-brand" href="#"><img src="/images/logo-SaMi.gif"></a>
                    </div>

                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <nav class="collapse navbar-collapse bs-navbar-collapse" role="navigation">
                        <ul class="nav navbar-nav">
                         
                        </ul>
                        
                        <ul class="nav navbar-nav navbar-right">
                         
                            <li>
                                <a><asp:Label ID="lblLoginName" runat="server" Text=""></asp:Label></a>
                            </li>
                            <li><a href="/Login.aspx">Log Out</a></li>
                                     
                            <%Response.Write(GetSettingsURL()); %>
                        </ul>
                    </nav><!-- /.navbar-collapse -->
            </div>
        </header>

       