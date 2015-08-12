<%@ Page Title="" Language="C#" MasterPageFile="~/Trainings.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SaMI.Web.Training.MasterData.TRNQualification.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TrainingBody" runat="server">
    <div class="col-lg-12 panel-group" id="accordion">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion" data-target="#addQualification">Add Qualification</button>
                    <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion" data-target="#listQualification">Qualification List</button>
                </h4>
            </div>
            <div id="addQualification" class="panel-collapse collapse  <% if (collapse == 0) { Response.Write(valueIn); } %>">
                <div class="col-lg-6">
                    <table>
                        <tr>
                            <td>
                                <label>
                                    Qualification</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="btn btn-default" OnClick="btnSave_Click" />
                                <input type="reset" value="Reset" class="btn btn-default" />
                            </td>
                        </tr>
                    </table>
                     <div><br /></div>
                </div>
            </div>

            <div id="listQualification" class="panel-collapse collapse  <% if (collapse == 1) { Response.Write(valueIn); } %>">
                <div>
                    <br />
                </div>
                <asp:GridView ID="gvQualification" OnRowCommand="gvQualification_RowCommand" AutoGenerateColumns="false"
                    runat="server" CssClass="table table-striped table-hover">
                    <Columns>
                        <asp:BoundField DataField="EducationLevel" HeaderText="Qualification" />
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
