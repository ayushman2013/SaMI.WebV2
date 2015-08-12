<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="SaMI.Web.Training.Controls.Header" %>
<header class="navbar navbar-default" role="banner"> <!-- navbar-fixed-top bs-docs-nav -->
    <div class="container">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".bs-navbar-collapse">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="/DashBoard.aspx"><img src="/images/logo-SaMi.gif" alt="Logo" /></a>
        </div>

         <!-- Collect the nav links, forms, and other content for toggling -->
        <nav class="collapse navbar-collapse bs-navbar-collapse" role="navigation">
        <ul class="nav navbar-nav">
            <li><a href="/Training/Default.aspx">Trainee Profile</a></li> 
             <li><a href="/Training/TRNEvent/Default.aspx">Event</a></li>
            <li><a href="/Training/RecTrainee/Default.aspx">Referred Trainee</a></li>     
            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Master Data <b class="caret"></b></a>
                <ul class="dropdown-menu" style="overflow:auto">
                    <li><a href="/Training/MasterData/TRNAgency/Default.aspx">Training Agency</a></li>
                    <li><a href="/Training/MasterData/TRNTrade/Default.aspx">Trade</a></li>
                    <li><a href="/Training/MasterData/TRNQualification/Default.aspx">Qualification</a></li>
                    <li><a href="/Training/MasterData/TRNEmploymentStatus/Default.aspx">Employment Status</a></li>
                    <li><a href="/Training/MasterData/TRNEmpType/Default.aspx">Employment Type</a></li>  
                    <%--<li><a href="/Training/MasterData/TRNOrganization/Default.aspx">Training Organization</a></li> 
                    <li><a href="/Training/MasterData/TRNRecAgency/Default.aspx">Recruitment Agency</a></li>--%> 
                    <li><a href="/Training/MasterData/TRNChkList/Default.aspx">Check List</a></li> 
                </ul>
            </li>
             <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">Report <b class="caret"></b></a>
                <ul class="dropdown-menu" style="overflow:auto">
                    <li><a href="/Training/TrnReport/TrainingRegular.aspx">Training Regular Report</a></li>
                    <li><a href="/Training/TrnReport/TrainingCostSharing.aspx">Training Cost Sharing Report</a></li>
                    <li><a href="/Training/TrnReport/EmploymentRegular.aspx">Employment Regular Report</a></li>
                    <li><a href="/Training/TrnReport/EmploymentCostSharing.aspx">Employment Cost Sharing Report</a></li>
                </ul>
            </li>
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
