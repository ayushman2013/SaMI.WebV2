<%@ Page Title="New Profile" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="SaMI.Web.Profile.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="js/ClickScript.js"></script>
    <script type="text/javascript">
        var pageUrl = '<%=ResolveUrl("Add.aspx")%>';

        PFEClickScript();

        $(function () {
            $("#ctl00_MainContent_txtRegistrationDate").datepicker();
            $("input#ctl00_MainContent_rbFemale").click(function () {
                $('input:radio[id=ctl00_MainContent_rbDiscriminated]').prop('checked', true);
            });
            $("input#ctl00_MainContent_rbMale").click(function () {
                $('input:radio[id=ctl00_MainContent_rbDiscriminated]').prop('checked', false);
            });


            $("#ctl00_MainContent_txtWard").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });
            $("#ctl00_MainContent_txtWardTemp").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    return false;
                }
            });

           
        });

       
               
    </script>
    <script type="text/javascript" src="js/CasteDropDown.js"></script>
    <script type="text/javascript" src="js/ValidateAdd.js"></script>
    <script type="text/javascript" src="js/JScriptEdit.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="clearfix">
    </div>
    <div style="min-height: 64px;" class="page-header">
        <div id="page-header">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3>
                            New Profile
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-default"
                                OnClientClick="return SaveProfile();" />
                            
                            <button class="btn btn-default" onclick="$(location).attr('href','Index.aspx');return false;">
                                Cancel</button>
                        </h3>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container" style="">
        <div class="row">
            <div class="clearfix">
            </div>
            <div class="col-md-12">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#home" data-toggle="tab">General Information</a></li>
                    <li class="disabled"><a href="#profile" data-toggle="">Foreign Employment</a></li>
                    <li class="disabled"><a href="#servicesandfollowup" data-toggle="">Follow-up</a></li>
                    <li class="disabled"><a href="#phonefollowup" data-toggle="">Phone Follow-up</a></li>
                    <%--  <li class="pull-right disabled"><a href="#casedocumentation" data-toggle="">Case Documentation</a></li>--%>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content" style="margin-top: 30px;">
                    <div class="tab-pane active" id="home">
                        <asp:UpdatePanel ID="UpdatePanelAdd" runat="server">
                            <ContentTemplate>
                                <div class="col-md-6">
                                    <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                       <%-- <tr>
                                            <td width="30%">
                                                <label>
                                                    Profile Number</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSaMIProfileNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <label>
                                                    Registration Date :</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegistrationDate" runat="server" CssClass="date_input form-control input-sm"
                                                    placeholder="MM/DD/YYYY"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    District :</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control input-sm pull-left"
                                                    OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Gender :</label>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbMale" Text="Male" Checked="False" GroupName="gender" runat="server" />
                                                <asp:RadioButton ID="rbFemale" Text="Female" Checked="False" GroupName="gender" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Name :</label>
                                            </td>
                                            <td class="tablespan">
                                                <span class="col-md-4">
                                                    <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" CssClass="form-control input-sm"></asp:TextBox></span>
                                                <span class="col-md-4">
                                                    <asp:TextBox ID="txtMiddleName" runat="server" placeholder="Middle Name" CssClass="form-control input-sm"></asp:TextBox></span>
                                                <span class="col-md-4">
                                                    <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" CssClass="form-control input-sm"></asp:TextBox></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Age :</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAgeGroup" runat="server" CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Ethnicity/Caste:</label>
                                            </td>
                                            <td class="tablespan">
                                                <span class="col-md-4">
                                                    <asp:DropDownList ID="ddlEthnicity" runat="server" CssClass="form-control input-sm"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEthnicity_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rbValidRegions" runat="server" RepeatDirection="Horizontal">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Phone :</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtVisitorPhone" runat="server" CssClass="form-control input-sm"
                                                    placeholder="Phone"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFamilyMemberPhone" runat="server" CssClass="form-control input-sm"
                                                    placeholder="Family Phone"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Mailing Address :</label>
                                            </td>
                                            <td class="tablespan">
                                                <span class="col-md-12 padding padding-first padding-last"><span class="col-md-4 padding padding-first">
                                                    <asp:DropDownList ID="ddlAddressDistrict" runat="server" CssClass="form-control input-sm"
                                                        placeholder="[District]" AutoPostBack="True" OnSelectedIndexChanged="ddlAddressDistrict_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </span><span class="col-md-3 padding">
                                                    <asp:DropDownList ID="ddlVDC" runat="server" CssClass="form-control input-sm" placeholder="[VDC]">
                                                        <asp:ListItem Text="[VDC]" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span class="col-md-2 padding">
                                                    <asp:TextBox ID="txtWard" runat="server" CssClass="form-control input-sm" placeholder="Ward"></asp:TextBox></span>
                                                    <span class="col-md-3 padding padding-last">
                                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm" placeholder="Details"></asp:TextBox></span>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="col-md-6">
                            <asp:UpdatePanel ID="UpdatePanelAddressDistrict" runat="server">
                                <ContentTemplate>
                                    <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                        <tr>
                                            <td colspan="2">
                                                <h4>
                                                    &raquo; Other Background</h4>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <label>
                                                    Family Head :</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFamilyHeadName" runat="server" CssClass="form-control input-sm">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                         <tr>
                                            <td>
                                                <label>
                                                    Relation with Family Head :</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFamilyHeadRelation" runat="server" CssClass="form-control input-sm">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Educational Status :</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlEducationalStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Marital Status :</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="form-control input-sm pull-left">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlIC" runat="server">
                                            <tr>
                                                <td>
                                                    <label>
                                                        How do you know about ICC?</label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlICKnowledge" runat="server" CssClass="form-control input-sm pull-left">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Frequency Of Visit to ICC :</label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFrequencyOfVisit" runat="server" CssClass="form-control input-sm pull-left">
                                                        <%--<asp:ListItem Value="0" Text="[Select]"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Once"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="More than Once"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>
                                                        Reason For Visiting to ICC?</label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlReasonOfVisit" runat="server" CssClass="form-control input-sm pull-left">
                                                       <%-- <asp:ListItem Value="0" Text="[Select]"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="General Information"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Specific Inquiry"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Case"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Visa verification"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </table>
                                    <table width="100%" cellpadding="5" cellspacing="0" border="0">
                                        <tr>
                                            <td colspan="2">
                                                <h4>
                                                    &raquo; Previous foreign employment experience</h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <h5>
                                                    Do you have previous foreign employment experience? &nbsp;
                                                    <asp:RadioButton ID="rbPrevFEExperienceYes" Text="Yes" runat="server" Checked="false" Enabled="false"
                                                        GroupName="rbGroup" />
                                                    &nbsp;
                                                    <asp:RadioButton ID="rbPrevFEExperienceNo" Text="No" runat="server" Checked="false" Enabled="false"
                                                        GroupName="rbGroup" />
                                                   <%-- &nbsp;
                                                    <button class="btn btn-default" data-toggle="modal" data-target="#PreviousFEExperience">
                                                        Add</button>--%>
                                                </h5>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="updatepanel" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvPFE" runat="server" ShowHeader="true" AutoGenerateColumns="false"
                                        ViewStateMode="Enabled" ShowHeaderWhenEmpty="true" OnRowCommand="gvPFE_RowCommand"
                                        CssClass="table table-hover table-condensed">
                                        <Columns>
                                            <asp:BoundField DataField="CountryName" HeaderText="Country" />
                                            <asp:BoundField DataField="JobOfferedTypeDesc" HeaderText="JobOffered Type" />
                                            <asp:BoundField DataField="StayDuration" HeaderText="StayDuration" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("ForeignEmploymentExperienceID") %>'
                                                        CommandName="cmdEdit" Text="Edit" OnClientClick="$('#PreviousFEExperience').modal('show');"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("ForeignEmploymentExperienceID") %>'
                                                        CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Label ID="lblPreviousID" runat="server" Visible="false"></asp:Label>
                            <asp:HiddenField ID="hfSaMIProfileID" runat="server" Value="" />
                            <asp:HiddenField ID="hfPreviousFEEID" runat="server" Value="" />
                        </div>
                    </div>
                    <div class="tab-pane" id="profile">
                    </div>
                    <div class="tab-pane" id="optional">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Previous Foreign Employment Experience Popup Modal-->
    <div class="modal fade" id="PreviousFEExperience" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H1">
                        Previous Foreign Employment Experience</h4>
                </div>
                <asp:UpdatePanel ID="updatePFEExperience" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="col-md-12">
                                <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <label>
                                                    Which Country?</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control input-sm pull-left">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    What Type of Job?</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control input-sm pull-left">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Stay Duration</label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlStayDuration" runat="server" CssClass="form-control input-sm pull-left">
                                                    <asp:ListItem Value="0" Text="[Select]"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Cancel</button>
                            <asp:Button ID="btnAddPFEExperience" CssClass="btn btn-default" runat="server" Text="Save"
                                OnClick="btnAddPFEExperience_Click" OnClientClick="return AddPreviousFEExperience();" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!--Validation Modal-->
    <div class="modal fade" id="validationModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title" id="H3">
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
            <!-- /.modal-content -->
        </div>
    </div>

    <div class="modal fade" id="divProgressBar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <div id="divProgressBarText">
                        <img src="../images/loading.gif" alt="" style="margin-right: 10px;" />
                        <strong>Saving Please Wait.........</strong>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="divSaveMessage" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <div id="div2">
                        <strong>Saved Successfully!</strong>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);

        function BeginRequestHandler(sender, args) {
            $("#ctl00_MainContent_txtRegistrationDate").datepicker();
            PFEClickScript();
        }

        function EndRequestHandler(sender, args) {
            $("#ctl00_MainContent_txtRegistrationDate").datepicker();
            $('#divProgressBar').modal('hide');

            
            setTimeout(function () { $('#divSaveMessage').modal('hide') }, 1000);

            PFEClickScript();

            $(function () {
                $("#ctl00_MainContent_txtRegistrationDate").datepicker();
                $("input#ctl00_MainContent_rbFemale").click(function () {
                    $('input:radio[id=ctl00_MainContent_rbDiscriminated]').prop('checked', true);
                });
                $("input#ctl00_MainContent_rbMale").click(function () {
                    $('input:radio[id=ctl00_MainContent_rbDiscriminated]').prop('checked', false);
                });
            });

        }
    </script>
</asp:Content>
