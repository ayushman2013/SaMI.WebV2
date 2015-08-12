<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Training.MasterData.TRNOrganization.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidateInput() {
            if (($('#ctl00_TrainingBody_txtOrganization').val() == '') && ($('#ctl00_TrainingBody_txtCountry').val() == ''))
                return false;
            else
                return true;
        }

        function Reset() {
            $('#ctl00_TrainingBody_txtOrganization').val('');
            $('#ctl00_TrainingBody_txtCountry').val('');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">
    <div class="col-lg-12 panel-group" id="accordion">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion" data-target="#addOrganization">Add Organization</button>
                    <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion" data-target="#listOrganization">Organization List</button>
                </h4>
            </div>

            <div id="addOrganization" class="panel-collapse collapse  <% if (collapse == 0) { Response.Write(valueIn); } %>">
                <table>
                    <tr>
                        <td>
                            <label>
                                Organization</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrganization" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Country</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                            <%--<asp:Label ID="lblMessage" runat="server"></asp:Label>--%>
                        </td>
                        <td>
                            <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-default" OnClick="btnSave_Click"
                                OnClientClick="return ValidateInput();" />
                            <input type="button" value="Reset" onclick="Reset();" class="btn btn-default" />
                        </td>
                    </tr>
                </table>
                 <div><br /></div>
            </div>

            <div id="listOrganization" class="panel-collapse collapse <% if (collapse == 1) { Response.Write(valueIn); } %>">
                <asp:GridView ID="gvOrganization" OnRowCommand="gvOrganization_RowCommand" AutoGenerateColumns="false"
                    runat="server" CssClass="table table-striped table-hover">
                    <Columns>
                        <asp:BoundField DataField="Organization" HeaderText="Organization" />
                        <asp:BoundField DataField="Country" HeaderText="Country" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="EditLinkButton" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="cmdEdit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandArgument='<%# Eval("ID") %>'
                                    CommandName="cmdDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
