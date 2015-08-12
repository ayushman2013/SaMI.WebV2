<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="SaMI.Web.Reports.Index" %>

<%@ Register Src="ReportHeader.ascx" TagName="RH" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="Stylesheet" href="../assets/css/gridview-pagination.css" />
    <script type="text/jscript" src="js/JScript.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            $('#ctl00_MainContent_txtRegistrationDateFrom').datepicker({ dateFormat: 'yy-mm-dd', changeYear: true, changeMonth: true });
            $('#ctl00_MainContent_txtRegistrationDateTo').datepicker({ dateFormat: 'yy-mm-dd', changeYear: true, changeMonth: true });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:RH ID="ReportHeader1" runat="server" />
    <div class="col-md-3 pull-left">
        <div class="col-md-3">
            <asp:Button ID="btnExport" runat="server" Text="Export" CssClass="btn btn-primary"
                OnClick="btnExport_Click" />
        </div>
    </div>
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-3 pull-right">
                        <div class="col-md-8">
                            <asp:TextBox ID="txtSearchText" runat="server" CssClass="form-control" placeholder="Search by Name"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default"
                                OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="clearfix">
                &nbsp</div>
            <div class="clearfix">
                &nbsp</div>
            <div class="col-lg-12">
                <asp:CheckBoxList ID="chkOptions" runat="server" OnSelectedIndexChanged="chkOptions_SelectedIndexChanged"
                    AutoPostBack="true" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                        <div class="tdtitle col-md-12">
                            <h3>
                                Filters</h3>
                        </div>
                        <%--<div class="filter-menu col-md-12">
                <asp:TextBox ID="txtRegistrationDate" runat = "server" CssClass="form-control" Placeholder="[Registration Date]"
                    AutoPostBack="True" OnTextChanged="txtRegistrationDate_TextChanged" ></asp:TextBox>
            </div>--%>
            <div class="filter-menu col-md-12">
                            <asp:TextBox ID="txtRegistrationDateFrom" runat="server" CssClass="form-control"
                                Placeholder="[Registration From]" AutoPostBack="True" OnTextChanged="txtRegistrationDate_TextChanged"></asp:TextBox>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:TextBox ID="txtRegistrationDateTo" runat="server" CssClass="form-control" Placeholder="[Registration To]"
                                AutoPostBack="True" OnTextChanged="txtRegistrationDate_TextChanged"></asp:TextBox>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlOrganization" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                                <asp:ListItem Text="[Organization]" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlWillingCountry" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlAgeGroup" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlEducationalStatus" runat="server" CssClass="form-control"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlFrequencyOfVisit" runat="server" CssClass="form-control"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="[Visit Frequency]"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Once"></asp:ListItem>
                                <asp:ListItem Value="2" Text="More than once"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlReasonForVisiting" runat="server" CssClass="form-control"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="[Visit Reason]"></asp:ListItem>
                                <asp:ListItem Value="1" Text="General Information"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Specific Inquiry"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlDecisionStatus" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlPassportStatus" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlJobOfferSource" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlWorkType" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-12 filter-menu">
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlVDC" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlEthnicity" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlEthnicity_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="filter-menu col-md-12">
                            <asp:DropDownList ID="ddlRecommendationByICC" runat="server" CssClass="form-control"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlRecommendationByICC_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        
                    </div>
                    <div class="col-md-10 headerDivider-left">
                        <h3>
                            Profile Registered</h3>
                        <h6 class="col-md-3 pull-right" style="margin-top: -30px">
                            Total No. of Records:
                            <asp:Label ID="lblNoOfRecords" runat="server"></asp:Label>
                        </h6><br />
                        <h6 class="col-md-3 pull-right" style="margin-top: -30px">
                            Total No. of Male:
                            <asp:Label ID="lblNoOfMaleRecords" runat="server"></asp:Label>
                        </h6><br />
                        <h6 class="col-md-3 pull-right" style="margin-top: -30px">
                            Total No. of Female:
                            <asp:Label ID="lblNoOfFemaleRecord" runat="server"></asp:Label>
                        </h6>
                        <asp:Panel runat="server" ID="Panel1">
                            <asp:GridView ID="gvSaMIProfile" runat="server" ShowHeaderWhenEmpty="True" AllowPaging="True"
                                OnPageIndexChanging="gvSaMIProfile_PageIndexChanging" PageSize="20" PagerStyle-CssClass="paging"
                                AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">
                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="<<" LastPageText=">>"
                                    NextPageText="&gt;" PreviousPageText="<" />
                            </asp:GridView>
                        </asp:Panel>
                        <%--<asp:GridView ID="gvSaMIProfile" runat="server" ShowHeaderWhenEmpty="True"
           AllowPaging="True" OnPageIndexChanging = "gvSaMIProfile_PageIndexChanging" PageSize="20"
           AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">            
        <Columns>
            <asp:BoundField DataField="SaMIProfileNumber" HeaderText="Profile Number" ItemStyle-Width="200px" />                
            <asp:BoundField DataField="Name" HeaderText="Name"  />
             <asp:BoundField DataField="VisitorPhone" HeaderText="Phone"  />
            <asp:BoundField DataField="DistrictName" HeaderText="District"  />
            <asp:BoundField DataField="VDCName" HeaderText="VDC"  />
            <asp:BoundField DataField="FollowUpStatus" HeaderText="Follow-up"  />
        </Columns>            
    </asp:GridView>--%>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        GetSelected('');
    </script>
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args) {
            $('#ctl00_MainContent_txtRegistrationDateFrom').datepicker({ dateFormat: 'yy-mm-dd', changeYear: true, changeMonth: true });
            $('#ctl00_MainContent_txtRegistrationDateTo').datepicker({ dateFormat: 'yy-mm-dd', changeYear: true, changeMonth: true });

        }

        function EndRequestHandler(sender, args) {
            $('#ctl00_MainContent_txtRegistrationDateFrom').datepicker({ dateFormat: 'yy-mm-dd', changeYear: true, changeMonth: true });
            $('#ctl00_MainContent_txtRegistrationDateTo').datepicker({ dateFormat: 'yy-mm-dd', changeYear: true, changeMonth: true });

        }
    </script>
</asp:Content>
