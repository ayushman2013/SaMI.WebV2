<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SaMI.Web.MasterData.YearRange.Index" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <table style="width: 100%;">
                <tr>
                    <td align="right">Label</td>
                    <td>&nbsp;<asp:TextBox ID="txtLabel" runat="server" CssClass="form-control input-sm"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">From</td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="date_input form-control input-sm"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">To</td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="date_input form-control input-sm"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:CheckBox ID="chkDefault" Text="Make Default" runat="server" CssClass="form-control" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                </tr>
            </table>
        </div>
    </div>


</asp:Content>
