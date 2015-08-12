<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PhoneFollowUp.aspx.cs" Inherits="SaMI.Web.Reports.PhoneFollowUp" %>

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
    <div style="min-height: 64px; margin:10px 0px 10px;" class="page-header">
        <div data-spy="affix" data-offset-top="135" id="fix-page-header">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Phone Follow Up
                        </h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
                    <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="tdtitle col-md-12">
                            <h3>
                                Filters</h3>
                        </div>
                        
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
                                OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged">
                                <asp:ListItem Text="[Organization]" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        </div>
                    
                    <div class="col-md-10 headerDivider-left">
                        <h3>
                            Phone Follow Up</h3>
                        <h6 class="col-md-3 pull-right" style="margin-top: -30px">
                            Total No. of Records:
                            <asp:Label ID="lblNoOfRecords" runat="server"></asp:Label>
                        </h6><br />
                       
                        <asp:GridView ID="gvPhoneFollowUp" runat="server" ShowHeaderWhenEmpty="True"
           AllowPaging="True" OnPageIndexChanging="gvPhoneFollowUp_PageIndexChanging" PageSize="20"
           AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">            
        <Columns>
            <asp:TemplateField HeaderText="S.No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:BoundField DataField="NameAndAddress" HeaderText="Name & Address" />                
            <asp:BoundField DataField="RegistrationDate" HeaderText="ICC Visited Date" DataFormatString="{0:dd-MMM-yyyy}" />
             <asp:BoundField DataField="LeftForFE" HeaderText="Left For Foreign Employment"  />
            <asp:BoundField DataField="FollowUpDate" HeaderText="Date of Follow Up"  DataFormatString="{0:dd-MMM-yyyy}" />
        </Columns>            
    </asp:GridView>
                    </div>
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
