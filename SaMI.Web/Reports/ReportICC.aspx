<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportICC.aspx.cs" Inherits="SaMI.Web.Reports.ReportICC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .ui-datepicker-calendar {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $("#ctl00_MainContent_txtDate").datepicker({
                dateFormat: "MM yy",
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                showAnim: "",
                showButtonPanel: true,
                //beforeShow: function (theDate, inst) {
                //    if ((datestr = $("#ctl00_MainContent_txtDate").val()).length > 0) {
                //        var year = datestr.substring(datestr.length - 4, datestr.length);
                //        var month = jQuery.inArray(datestr.substring(0, datestr.length - 5), $("#ctl00_MainContent_txtDate").datepicker('option', 'monthNamesShort'));
                //        $("#ctl00_MainContent_txtDate").datepicker('option', 'defaultDate', new Date(year, month, 1));
                //        $("#ctl00_MainContent_txtDate").datepicker('setDate', new Date(year, month, 1));
                //        if (inst.input)
                //            inst.input.trigger('change');
                //    }
                //},
                onClose: function (theDate, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $("#ctl00_MainContent_txtDate").datepicker('option', 'defaultDate');
                    $("#ctl00_MainContent_txtDate").datepicker('setDate', new Date(year, month, 1));
                    if (inst.input)
                        inst.input.trigger('change');
                }
            });

            $("#ctl00_MainContent_txtDateDistrict").datepicker({
                dateFormat: "MM yy",
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                showAnim: "",
                showButtonPanel: true,
                onClose: function (theDate, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $("#ctl00_MainContent_txtDateDistrict").datepicker('option', 'defaultDate');
                    $("#ctl00_MainContent_txtDateDistrict").datepicker('setDate', new Date(year, month, 1));
                    if (inst.input)
                        inst.input.trigger('change');
                }
            });
        });
    </script>

    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="clearfix">
    </div>
    <div style="min-height: 64px;" class="page-header">
        <div data-spy="affix" data-offset-top="135" id="fix-page-header">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3>ICC Report
                        </h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container" style="">
                <%--Template 1 Year/Month--%>
                <div class="col-md-12">
                    <h4>Report - Template 1
                    </h4>
                </div>
                <div class="well" style="display: inline-block; float: left; margin: 5px; overflow: hidden;">
                    <div class="clearfix">
                    </div>
                    <div class="col-lg-3">

                        <table width="100%" cellpadding="5" cellspacing="0">
                            <tr>
                                <td>
                                    <label>Date</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="date_input form-control input-group-sm" AutoPostBack="true"
                                        OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>

                    </div>
                    <div class="col-md-12">
                        <table width="100%" cellpadding="5" cellspacing="0" border="1" class="table table-bordered">
                            <thead style="font-weight: 100; font-size: small">
                                <tr>
                                    <td style="text-align: center">No. of Participants</td>
                                    <td style="text-align: center" colspan="4">Dalit</td>
                                    <td style="text-align: center" colspan="6">Janajati</td>
                                    <td style="text-align: center" colspan="4">Janajati Newar</td>
                                    <td style="text-align: center" colspan="4">Brahmin</td>
                                    <td style="text-align: center" colspan="4">Chhetri</td>
                                    <td style="text-align: center" colspan="2">Thakuri</td>
                                    <td style="text-align: center" colspan="2">Other Madhesh Caste and Ethnicity</td>
                                    <td style="text-align: center">Total Men</td>
                                    <td style="text-align: center">Total Women</td>
                                    <td style="text-align: center">Grand Total</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2">Madhesh/Terai</td>
                                    <td colspan="2">Mountain</td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2">Madhesh/Terai</td>
                                    <td colspan="2">Discriminated</td>
                                    <td colspan="2">Non Discriminated</td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2">Madhesh/Terai</td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2">Madhesh/Terai</td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2"></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNoOfParticipants" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDalitHillMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDalitHillFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDalitMadheshMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDalitMadheshFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiMountainMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiMountainFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiHillMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiHillFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiMadheshMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiMadheshFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiNewarDiscMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiNewarDiscFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiNewarNonDiscMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiNewarNonDiscFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblBrahminHillMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblBrahminHillFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblBrahminMadheshMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblBrahminMadheshFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblChhetriHillMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblChhetriHillFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblChhetriMadheshMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblChhetriMadheshFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblThakuriHillMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblThakuriHillFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblOtherMale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblOtherFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblNoOfMen" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblNoOfFemale" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblGrandTotal" runat="server"></asp:Label></td>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>

                <%--Template 2 Year/Month and District--%>
                <div class="col-md-12">
                    <h4>Report - Template 2
                    </h4>
                </div>
                <div class="well" style="display: inline-block; float: left; margin: 5px; overflow: hidden;">
                    <div class="clearfix">
                    </div>
                    <div class="col-lg-6">
                        <table width="100%" cellpadding="5" cellspacing="0">
                            <tr>
                                <td>
                                    <label>Date</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateDistrict" runat="server" CssClass="date_input form-control input-group-sm"
                                        OnTextChanged="txtDateDistrict_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </td>
                                <td>
                                    <label>District</label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-12">
                        <table width="100%" cellpadding="5" cellspacing="0" border="1" class="table table-bordered">
                            <thead style="font-weight: 100; font-size: small">
                                <tr>
                                    <td style="text-align: center">No. of Participants</td>
                                    <td style="text-align: center" colspan="4">Dalit</td>
                                    <td style="text-align: center" colspan="6">Janajati</td>
                                    <td style="text-align: center" colspan="4">Janajati Newar</td>
                                    <td style="text-align: center" colspan="4">Brahmin</td>
                                    <td style="text-align: center" colspan="4">Chhetri</td>
                                    <td style="text-align: center" colspan="2">Thakuri</td>
                                    <td style="text-align: center" colspan="2">Other Madhesh Caste and Ethnicity</td>
                                    <td style="text-align: center">Total Men</td>
                                    <td style="text-align: center">Total Women</td>
                                    <td style="text-align: center">Grand Total</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2">Madhesh/Terai</td>
                                    <td colspan="2">Mountain</td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2">Madhesh/Terai</td>
                                    <td colspan="2">Discriminated</td>
                                    <td colspan="2">Non Discriminated</td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2">Madhesh/Terai</td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2">Madhesh/Terai</td>
                                    <td colspan="2">Hill</td>
                                    <td colspan="2"></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td>M</td>
                                    <td>W</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNoOfParticipantsDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDalitHillMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDalitHillFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDalitMadheshMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDalitMadheshFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiMountainMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiMountainFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiHillMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiHillFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiMadheshMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiMadheshFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiNewarDiscMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiNewarDiscFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiNewarNonDiscMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJanajatiNewarNonDiscFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblBrahminHillMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblBrahminHillFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblBrahminMadheshMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblBrahminMadheshFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblChhetriHillMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblChhetriHillFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblChhetriMadheshMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblChhetriMadheshFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblThakuriHillMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblThakuriHillFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblOtherMaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblOtherFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblNoOfMenDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblNoOfFemaleDistrict" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblGrandTotalDistrict" runat="server"></asp:Label></td>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>

                 </div>
        </ContentTemplate>
    </asp:UpdatePanel>
                <%--Template 3 Total visitors--%>
                <%--<asp:UpdatePanel ID="visitors" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                         <div class="col-md-12">
                    <h4>Template 3: Total Visitors
                    </h4>
                </div>
                <div class="well" style="display: inline-block; float: left; margin: 5px; overflow: hidden; width:510px">
                    <div class="clearfix"></div>
                    <div class="col-md-12">
                        <table width="100%" cellpadding="5" cellspacing="0" border="1" class="table table-bordered">
                            <thead style="font-weight: 100; font-size: small">
                                <tr>
                                    <td style="text-align: center">Year</td>
                                    <td style="text-align: center">Men</td>
                                    <td style="text-align: center">Women</td>
                                    <td style="text-align: center">Total</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <%Response.Write(GetTotalVisitorsRecord()); %>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
               

                <%--Template 4 Total visitors District--%>
                <%--<asp:UpdatePanel ID="visitorsDistrict" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                        <div class="col-md-12">
                            <h4>Template 4: Total Visitors District
                            </h4>
                        </div>
                        <div class="well" style="display: inline-block; float: left; margin: 5px; overflow: hidden; width:510px">
                            <div class="clearfix"></div>
                            <div class="col-lg-6">
                                <table width="100%" cellpadding="5" cellspacing="0">
                                    <tr>
                                        <td>
                                            <label>District</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDistrictVisitors" runat="server" CssClass="form-control" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlDistrictVisitors_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-12">
                                <table width="100%" cellpadding="5" cellspacing="0" border="1" class="table table-bordered">
                                    <thead style="font-weight: 100; font-size: small">
                                        <tr>
                                            <td style="text-align: center">Year</td>
                                            <td style="text-align: center">Men</td>
                                            <td style="text-align: center">Women</td>
                                            <td style="text-align: center">Total</td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%Response.Write(GetTotalVisitorsDistrictRecord()); %>
                                        <%--<tr>
                                            <td><asp:Label runat="server" ID="lblVisitorsYearDistrict"></asp:Label></td>
                                            <td><asp:Label runat="server" ID="lblVisitorsMenDistrict"></asp:Label></td>
                                            <td><asp:Label runat="server" ID="lblVisitorsWomenDistrict"></asp:Label></td>
                                            <td><asp:Label runat="server" ID="lblVisitorsTotalDistrict"></asp:Label></td>
                                        </tr>--%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>

           

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args) {
            $("#ctl00_MainContent_txtDate").datepicker({
                dateFormat: "MM yy",
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                showAnim: "",
                showButtonPanel: true,
                //beforeShow: function (theDate, inst) {
                //    if ((datestr = $("#ctl00_MainContent_txtDate").val()).length > 0) {
                //        var year = datestr.substring(datestr.length - 4, datestr.length);
                //        var month = jQuery.inArray(datestr.substring(0, datestr.length - 5), $("#ctl00_MainContent_txtDate").datepicker('option', 'monthNamesShort'));
                //        $("#ctl00_MainContent_txtDate").datepicker('option', 'defaultDate', new Date(year, month, 1));
                //        $("#ctl00_MainContent_txtDate").datepicker('setDate', new Date(year, month, 1));
                //        if (inst.input)
                //            inst.input.trigger('change');
                //    }
                //},
                onClose: function (theDate, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $("#ctl00_MainContent_txtDate").datepicker('option', 'defaultDate');
                    $("#ctl00_MainContent_txtDate").datepicker('setDate', new Date(year, month, 1));
                    if (inst.input)
                        inst.input.trigger('change');
                }
            });
            $("#ctl00_MainContent_txtDateDistrict").datepicker({
                dateFormat: "MM yy",
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                showAnim: "",
                showButtonPanel: true,
                onClose: function (theDate, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $("#ctl00_MainContent_txtDateDistrict").datepicker('option', 'defaultDate');
                    $("#ctl00_MainContent_txtDateDistrict").datepicker('setDate', new Date(year, month, 1));
                    if (inst.input)
                        inst.input.trigger('change');
                }
            });
        }

        function EndRequestHandler(sender, args) {
            $("#ctl00_MainContent_txtDate").datepicker({
                dateFormat: "MM yy",
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                showAnim: "",
                showButtonPanel: true,
                //beforeShow: function (theDate, inst) {
                //    if ((datestr = $("#ctl00_MainContent_txtDate").val()).length > 0) {
                //        var year = datestr.substring(datestr.length - 4, datestr.length);
                //        var month = jQuery.inArray(datestr.substring(0, datestr.length - 5), $("#ctl00_MainContent_txtDate").datepicker('option', 'monthNamesShort'));
                //        $("#ctl00_MainContent_txtDate").datepicker('option', 'defaultDate', new Date(year, month, 1));
                //        $("#ctl00_MainContent_txtDate").datepicker('setDate', new Date(year, month, 1));
                //        if (inst.input)
                //            inst.input.trigger('change');
                //    }
                //},
                onClose: function (theDate, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $("#ctl00_MainContent_txtDate").datepicker('option', 'defaultDate');
                    $("#ctl00_MainContent_txtDate").datepicker('setDate', new Date(year, month, 1));
                    if (inst.input)
                        inst.input.trigger('change');
                }
            });
            $("#ctl00_MainContent_txtDateDistrict").datepicker({
                dateFormat: "MM yy",
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                showAnim: "",
                showButtonPanel: true,
                onClose: function (theDate, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $("#ctl00_MainContent_txtDateDistrict").datepicker('option', 'defaultDate');
                    $("#ctl00_MainContent_txtDateDistrict").datepicker('setDate', new Date(year, month, 1));
                    if (inst.input)
                        inst.input.trigger('change');
                }
            });

        }
    </script>
</asp:Content>
