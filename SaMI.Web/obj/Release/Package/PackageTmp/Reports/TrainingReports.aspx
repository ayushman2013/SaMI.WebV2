<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrainingReports.aspx.cs" Inherits="SaMI.Web.Reports.TrainingReports" %>
<%@ Register src="ReportHeader.ascx" tagname="RH" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/jscript" src="js/JScript.js"></script>
<script type="text/javascript">
    $(function () {
        $("#ctl00_MainContent_txtFromDate").datepicker();
        $("#ctl00_MainContent_txtToDate").datepicker();
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<uc1:RH ID="ReportHeader1" runat="server" />
<asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="container">

    <div class="row">
        <div class="col-md-2">
            <div class="tdtitle col-md-12"><h3>Filters</h3></div>           
            
            <div class="col-md-12 filter-menu">
                <asp:DropDownList ID="ddlGender" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" onselectedindexchanged="ddlGender_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="filter-menu col-md-12">
                <asp:DropDownList ID="ddlDistrict" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="filter-menu col-md-12">
                <asp:DropDownList ID="ddlVDC" runat = "server" CssClass="form-control" 
            AutoPostBack="True" onselectedindexchanged="ddlVDC_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="filter-menu col-md-12">
                <asp:DropDownList ID="ddlEthnicity" runat = "server" CssClass="form-control" 
                    AutoPostBack="True" onselectedindexchanged="ddlEthnicity_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="filter-menu col-md-12">
                <asp:DropDownList ID="ddlCaste" runat = "server" 
                CssClass="form-control" AutoPostBack="True" 
                    onselectedindexchanged="ddlCaste_SelectedIndexChanged" ></asp:DropDownList>
            </div>
        </div>
        <div class="col-md-10 headerDivider-left">
            
            <div class="col-md-7" style="margin-left:0px; margin-bottom:10px;">    
                <h3>Trainings</h3>
                    <span class="col-md-4">
                        <asp:TextBox ID="txtFromDate" runat="server"  CssClass="form-control input-sm" placeholder="From: MM/DD/YYYY"></asp:TextBox>
                    </span>
                    <span class="col-md-4">
                        <asp:TextBox ID="txtToDate" runat="server"  CssClass="form-control input-sm" placeholder="To: MM/DD/YYYY"></asp:TextBox>
                    </span>
                    <span class="col-md-3">                              
                        <asp:Button ID="btnSearch" runat="server" Text="Search"  CssClass = "btn btn-default" OnClientClick = "return ValidateDateInput();" 
                         onclick="btnSearch_Click" />
                    </span>
                
            </div>

           <div class="clearfix">&nbsp;</div>

            <div class="col-md-10">

            
            <asp:GridView ID="gvEmploymentSkills" runat="server" ShowHeaderWhenEmpty="True"
            AllowPaging="True" OnPageIndexChanging = "gvEmploymentSkills_PageIndexChanging" PageSize="20"
                   AutoGenerateColumns="False" ShowHeader="True" CssClass="table table-hover table-condensed">            
                <Columns>
                    <asp:BoundField DataField="FullName" HeaderText="Client"/>                
                    <asp:BoundField DataField="TrainingSubject" HeaderText="Subject"  />
                    <asp:BoundField DataField="TrainingLocation" HeaderText="Location"  />
                     <asp:BoundField DataField="TrainingStratDate" HeaderText="Start Date"  />
                     <asp:BoundField DataField="TrainingReasonTypeDesc" HeaderText="Service provided"  />
                     <asp:BoundField DataField="PreviousTraining" HeaderText="Previous Training?"  />
                </Columns>            
            </asp:GridView>
            </div>
        </div>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>
<div class="modal fade" id="validationModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="H4">Please correct the error(s) below:</h4>
            </div>
            
            <div class="modal-body">
                <div id="modal-body-text" style="color:Red; font-weight:bold;">
                
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>                
            </div>
            
        </div><!-- /.modal-content -->
    </div>
</div>
<script type="text/javascript">
    GetSelected('trainings');

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
</asp:Content>
