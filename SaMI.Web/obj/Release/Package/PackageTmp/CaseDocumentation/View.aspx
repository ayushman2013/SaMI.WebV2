<%@ Page Title="" Language="C#" MasterPageFile="~/CaseMaster.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="SaMI.Web.CaseDocumentation.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="min-height: 64px;" class="page-header">
    <div data-spy="affix" data-offset-top="135" id="fix-page-header">
        <div class="container"><div class="row"><div class="col-md-12">
            <h3>View Case
                    <button class="btn btn-default" onclick="$(location).attr('href','Index.aspx');return false;">Cancel</button>
            </h3>
        </div></div></div>
    </div>
</div>
    <div class="clearfix"></div>
    <div class="container" style="">
        <div class="row">
            <div class="clearfix">
            </div>
            <div class="col-md-12">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#profile" data-toggle="tab">Profile</a></li>
                </ul>
                <!-- Tab panes -->
                <div class="tab-content" style="margin-top: 30px;">
                    <div class="tab-pane active" id="profile">
                        <div class="col-lg-6">
                            <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                <tbody>
                                    <tr>
                                        <td>
                                            <label>
                                                First Name</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Middle Name</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMiddleName" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Last Name</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLastName" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                District</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDistrict" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                VDC</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVDC" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                         
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-lg-6">
                            <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                <tbody>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Type :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTypeOfCase" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                         
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Number :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCaseNumber" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Name of opponent :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtNameOfOpponent" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Problem faced :</label>
                                        </td>
                                        <td>
                                            <span class="col-md-6">
                                                <asp:TextBox ID="txtCaseDesc" TextMode="MultiLine" runat="server" ReadOnly="true" CssClass="form-control input-sm"
                                                    Rows="4" Style="word-wrap: break-word; resize: vertical;" placeholder="Description"></asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-lg-6">
                            <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                <tbody>
                                    <tr>
                                        <td>
                                            <label>
                                                Case Registered Date :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCaseRegisteredDate" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Partner :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStackeHolder" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Registered At:</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCaseRegistrar" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                         
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Responsible staff :</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtResponsibleStaff" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>
                                                Status :</label>
                                        </td>
                                        <td>
                                        <asp:TextBox ID="txtCaseStatusType" runat="server" ReadOnly="true" CssClass="form-control input-sm"></asp:TextBox>
                                           
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="col-lg-6">
                            <table width="100%" cellpadding="5" cellspacing="0" border="0" class="table-tab">
                                <tbody>
                                    <asp:Panel ID="pnlCaseOutput" runat="server" Visible="false">
                                        <tr>
                                            <td>
                                                <label>
                                                    Compensated?:</label>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbCompensationYes" Text="Yes" Checked="false" GroupName="compensation"
                                                    runat="server" />
                                                <asp:RadioButton ID="rbCompensationNo" Text="No" Checked="false" GroupName="compensation"
                                                    runat="server" />
                                                Compensation Amount:
                                                <asp:TextBox ID="txtCompensationAmount" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label>
                                                    Output Details:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOutputDetails" runat="server" CssClass="form-control input-sm"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td colspan="2">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <label>
                                                        Evidences?&nbsp;</label>
                                                </div>
                                                <asp:CheckBoxList ID="cblEvidenceTypes" runat="server" RepeatColumns="3">
                                                </asp:CheckBoxList>
                                                <div class="panel-body">
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
