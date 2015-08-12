<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SaMI.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {
            $("#ctl00_MainContent_txtFromDate").datepicker();
            $("#ctl00_MainContent_txtToDate").datepicker();
        });
        function ValidateDateInput() {

            var validation = true;
            var message = '<ul>';

            if ($('#ctl00_MainContent_txtFromDate').val() == '' && $('#ctl00_MainContent_txtToDate').val() == '') {
                validation = false;
                message += "<li>Date field is empty.</li>";

            }
            else if (!checkDateDifference($('#ctl00_MainContent_txtFromDate').val(), $('#ctl00_MainContent_txtToDate').val())) {
                validation = false;
                message += "<li>FROM DATE must be Less than OR Eqaul to TO DATE.</li>";
            }

            if (!validation) {
                message += "</ul>";
                $('#modal-body-text').html(message);
                $('#validationModal').modal('show');
                return false;
            }

            return validation;

        }
        function checkDateDifference(startDate, endDate) {
            startDate = $.datepicker.parseDate('mm/dd/yy', startDate);
            endDate = $.datepicker.parseDate('mm/dd/yy', endDate);

            var difference = (endDate - startDate) / (86400000);

            if (difference < 0)
                return false;
            else
                return true;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 40px;">
        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="col-md-5">
            <h1>
                Registered Profile
                <div class="btn-group">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                        More <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu">
                        <li>
                            <asp:Button ID="btnExportProfilePDF" runat="server" Text="Export PDF" Style="background: none;
                                border: none;" OnClick="btnExportProfilePDF_Click" /></li>
                        <li>
                            <asp:Button ID="btnExportProfileExcel" runat="server" Text="Export Excel" OnClick="btnExportProfileExcel_Click"
                                Style="background: none; border: none;" /></li>
                    </ul>
                </div>
                <h1>
                </h1>
            </h1>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col-md-7 text-right">
                    <h1>
                        <span class="col-md-3">
                            <asp:DropDownList ID="ddlEthnicity" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlEthnicity_SelectedIndexChanged">
                            </asp:DropDownList>
                        </span><span class="col-md-3">
                            <asp:DropDownList ID="ddlCaste" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlCaste_SelectedIndexChanged" placeholder="Caste">
                            </asp:DropDownList>
                        </span><span class="col-md-3">
                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                            </asp:DropDownList>
                        </span><span class="col-md-3">
                            <asp:DropDownList ID="ddlFollowUpStatus" runat="server" CssClass="form-control" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlFollowUpStatus_SelectedIndexChanged">
                            </asp:DropDownList>
                        </span>
                    </h1>
                </div>
                <div class="clearfix">
                </div>
                <div class="col-md-12" style="padding: 0px;">
                    <div style="margin-top: 10px;">
                        <span class="col-md-2">
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control input-sm" OnSelectedIndexChanged="ddlPeriod_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </span><span class="col-md-3">
                            <asp:DropDownList ID="ddlPeriod" runat="server" CssClass="form-control input-sm"
                                OnSelectedIndexChanged="ddlPeriod_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </span><span class="col-md-2">
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </span><span class="col-md-2">
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </span><span class="col-md-3">
                            <asp:Button ID="btnSearchByDate" runat="server" CssClass="btn btn-default input-sm"
                                OnClick="btnSearchByDate_Click" Text="Search" OnClientClick="return ValidateDateInput();" />
                        </span>
                    </div>
                </div>
                <div class="clearfix">
                    &nbsp;</div>
                <div class="col-md-12">
                    <asp:GridView ID="gvSaMIProfile" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                        AllowPaging="True" OnPageIndexChanging="gvSaMIProfile_PageIndexChanging" PageSize="10"
                        ShowHeader="True" CssClass="table table-striped table-hover">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SaMIProfileNumber" HeaderText="Profile Number" ItemStyle-Width="200px" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="AgeGroupDesc" HeaderText="Age Group" />
                            <asp:BoundField DataField="DistrictName" HeaderText="District" />
                            <asp:BoundField DataField="Discriminated" HeaderText="Discriminated" />
                        </Columns>
                    </asp:GridView>
                    <div class="clearfix">
                    </div>
                    <asp:GridView ID="gvProfileSummary" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                        ShowHeader="True" CssClass="table table-striped table-hover">
                        <Columns>
                            <asp:BoundField DataField="MaleCount" HeaderText="Male" />
                            <asp:BoundField DataField="FemaleCount" HeaderText="Female" />
                            <asp:BoundField DataField="DiscriminationCount" HeaderText="Discriminated" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clearfix">
        </div>
        <div class="col-md-5">
            <h1>
                Returnee's Profile
                <div class="btn-group">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                        More <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu">
                        <li>
                            <asp:Button ID="btnExportRerurneePDF" runat="server" Text="Export PDF" Style="background: none;
                                border: none;" OnClick="btnExportRerurneePDF_Click" />
                        </li>
                        <li>
                            <asp:Button ID="btnExportReturneeExcel" runat="server" Text="Export Excel" Style="background: none;
                                border: none;" OnClick="btnExportReturneeExcel_Click" /></li>
                    </ul>
                </div>
                <h1>
                </h1>
            </h1>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="col-md-12">
                    <asp:GridView ID="gvReturnee" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                        AllowPaging="True" OnPageIndexChanging="gvReturnee_PageIndexChanging" PageSize="10"
                        ShowHeader="True" CssClass="table table-striped table-hover">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SaMIProfileNumber" HeaderText="Registraton Number" ItemStyle-Width="200px" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="AgeGroupDesc" HeaderText="Age Group" />
                            <asp:BoundField DataField="DistrictName" HeaderText="District" />
                            <asp:BoundField DataField="Discriminated" HeaderText="Discriminated" />
                            <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        </Columns>
                    </asp:GridView>
                    <div class="clearfix">
                    </div>
                    <asp:GridView ID="gvReturneeSummary" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"
                        ShowHeader="True" CssClass="table table-striped table-hover">
                        <Columns>
                            <asp:BoundField DataField="MaleCount" HeaderText="Male" />
                            <asp:BoundField DataField="FemaleCount" HeaderText="Female" />
                            <asp:BoundField DataField="DiscriminationCount" HeaderText="Discriminated" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="modal fade" id="validationModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H4">
                        Please correct the error(s) below:</h4>
                </div>
                <div class="modal-body">
                    <div id="modal-body-text" style="color: Red; font-weight: bold;">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
        <script type="text/javascript">

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(BeginRequestHandler);
            prm.add_endRequest(EndRequestHandler);

            function BeginRequestHandler(sender, args) {

            }

            function EndRequestHandler(sender, args) {
                $(function () {
                    $("#ctl00_MainContent_txtFromDate").datepicker();
                    $("#ctl00_MainContent_txtToDate").datepicker();
                });
            }
        </script>
    </div>
    
</asp:Content>
