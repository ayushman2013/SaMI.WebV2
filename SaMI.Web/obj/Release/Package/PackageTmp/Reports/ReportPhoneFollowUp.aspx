<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportPhoneFollowUp.aspx.cs" Inherits="SaMI.Web.Reports.ReportPhoneFollowUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="clearfix">
    </div>
    <div style="min-height: 64px; margin:10px 0px 10px;" class="page-header">
        <div data-spy="affix" data-offset-top="135" id="fix-page-header">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Phone Follow Up Report
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
                <div class="col-md-6">
                    <div style="min-height: 10px; margin:0px 0px 10px;" class="page-header">
                        <div data-spy="affix" data-offset-top="10" id="fix-page-header">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h4>Phone Follow Up (Year and Total)</h4>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <label>Year</label> &nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlYear1" runat="server" Style="width: 70px; border-radius: 100px; height: 25px" 
                            OnSelectedIndexChanged="ddlYear1_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="2000">2000</asp:ListItem>
                                            <asp:ListItem Value="2001">2001</asp:ListItem>
                                            <asp:ListItem Value="2002">2002</asp:ListItem>
                                            <asp:ListItem Value="2003">2003</asp:ListItem>
                                            <asp:ListItem Value="2004">2004</asp:ListItem>
                                            <asp:ListItem Value="2005">2005</asp:ListItem>
                                            <asp:ListItem Value="2006">2006</asp:ListItem>
                                            <asp:ListItem Value="2007">2007</asp:ListItem>
                                            <asp:ListItem Value="2008">2008</asp:ListItem>
                                            <asp:ListItem Value="2009">2009</asp:ListItem>
                                            <asp:ListItem Value="2010">2010</asp:ListItem>
                                            <asp:ListItem Value="2011">2011</asp:ListItem>
                                            <asp:ListItem Value="2012">2012</asp:ListItem>
                                            <asp:ListItem Value="2013">2013</asp:ListItem>
                                            <asp:ListItem Value="2014">2014</asp:ListItem>
                                            <asp:ListItem Value="2015" Selected="True">2015</asp:ListItem>
                                            <asp:ListItem Value="2016">2016</asp:ListItem>
                                            <asp:ListItem Value="2017">2017</asp:ListItem>
                                            <asp:ListItem Value="2018">2018</asp:ListItem>
                                            <asp:ListItem Value="2019">2019</asp:ListItem>
                                            <asp:ListItem Value="2020">2020</asp:ListItem>
                                            <asp:ListItem Value="2021">2021</asp:ListItem>
                                            <asp:ListItem Value="2022">2022</asp:ListItem>
                                            <asp:ListItem Value="2023">2023</asp:ListItem>
                                            <asp:ListItem Value="2024">2024</asp:ListItem>
                                            <asp:ListItem Value="2025">2025</asp:ListItem>
                                        </asp:DropDownList>
                        <br />
                    </div>
                    <br /><br />
                    <asp:UpdatePanel ID="UpdatePanelYear" runat="server">
                        <ContentTemplate>
                            <table width="100%" cellpadding="5" cellspacing="0" border="1">
                                <thead style="font-weight: 100; font-size: small">
                                    <tr>
                                        <td>Results</td>
                                        <td>Men</td>
                                        <td>Women</td>
                                        <td>Total Number</td>
                                        <td>Percentage of Total</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Number of clients follow up
                                        </td>
                                        <td style="width: 60px">
                                            <asp:Label ID="lblFollowUpMale" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 60px">
                                            <asp:Label ID="lblFollowUpFemale" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 70px">
                                            <asp:Label ID="lblFollowUpTotal" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 80px">
                                            <asp:Label ID="lblFollowUpPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients left for foreign employment 
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftForFEMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftForFEFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftForFETotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftForFEPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who took skills training  
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSkillTraineeMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSkillTraineeFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSkillTraineeTotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSkillTraineePercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who left documents at home  
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftDocumentsMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftDocumentsFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftDocumentsTotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftDocumentsPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who asked for receipts  
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAskedReceiptsMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAskedReceiptsFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAskedReceiptsTotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAskedReceiptsPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who really got receipts   
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGotReceiptsMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGotReceiptsFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGotReceiptsTotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGotReceiptsPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who paid less    
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidLessMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidLessFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidLessTotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidLessPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>No of clients who paid  within the govt. ceiling    
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidWithinGovtCeilingMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidWithinGovtCeilingFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidWithinGovtCeilingTotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidWithinGovtCeilingPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>No of clients who have not yet decided     
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedTotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>No of clients who have not left yet       
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotLeftMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotLeftFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotLeftTotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotLeftPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients decided not to go       
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedToGoMale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedToGoFemale" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedToGoTotal" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedToGoPercentage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>

                <div class="col-md-6">
                    <div style="min-height: 10px; margin:0px 0px 10px;" class="page-header">
                        <div data-spy="affix" data-offset-top="10" id="fix-page-header">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h4>Phone Follow Up (Year and District)</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                                        <label>Year</label> &nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlYear2" runat="server" Style="width: 70px; border-radius: 100px; height: 25px" 
                            OnSelectedIndexChanged="ddlYear2_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="2000">2000</asp:ListItem>
                                            <asp:ListItem Value="2001">2001</asp:ListItem>
                                            <asp:ListItem Value="2002">2002</asp:ListItem>
                                            <asp:ListItem Value="2003">2003</asp:ListItem>
                                            <asp:ListItem Value="2004">2004</asp:ListItem>
                                            <asp:ListItem Value="2005">2005</asp:ListItem>
                                            <asp:ListItem Value="2006">2006</asp:ListItem>
                                            <asp:ListItem Value="2007">2007</asp:ListItem>
                                            <asp:ListItem Value="2008">2008</asp:ListItem>
                                            <asp:ListItem Value="2009">2009</asp:ListItem>
                                            <asp:ListItem Value="2010">2010</asp:ListItem>
                                            <asp:ListItem Value="2011">2011</asp:ListItem>
                                            <asp:ListItem Value="2012">2012</asp:ListItem>
                                            <asp:ListItem Value="2013">2013</asp:ListItem>
                                            <asp:ListItem Value="2014">2014</asp:ListItem>
                                            <asp:ListItem Value="2015" Selected="True">2015</asp:ListItem>
                                            <asp:ListItem Value="2016">2016</asp:ListItem>
                                            <asp:ListItem Value="2017">2017</asp:ListItem>
                                            <asp:ListItem Value="2018">2018</asp:ListItem>
                                            <asp:ListItem Value="2019">2019</asp:ListItem>
                                            <asp:ListItem Value="2020">2020</asp:ListItem>
                                            <asp:ListItem Value="2021">2021</asp:ListItem>
                                            <asp:ListItem Value="2022">2022</asp:ListItem>
                                            <asp:ListItem Value="2023">2023</asp:ListItem>
                                            <asp:ListItem Value="2024">2024</asp:ListItem>
                                            <asp:ListItem Value="2025">2025</asp:ListItem>
                                        </asp:DropDownList>
                    </div>
                     <div class="col-lg-8">
                                        <label>District</label> &nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlDistrict" runat="server" Style="width: 170px; border-radius: 100px; height: 25px" 
                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                         </div>
                    <br /><br />
                    <asp:UpdatePanel ID="UpdatePanelYearAndDistrict" runat="server">
                        <ContentTemplate>
                            <table width="100%" cellpadding="5" cellspacing="0" border="1">
                                <thead style="font-weight: 100; font-size: small">
                                    <tr>
                                        <td>Results</td>
                                        <td>Men</td>
                                        <td>Women</td>
                                        <td>Total Number</td>
                                        <td>Percentage of Total</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Number of clients follow up
                                        </td>
                                        <td style="width: 60px">
                                            <asp:Label ID="lblFollowUpMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 60px">
                                            <asp:Label ID="lblFollowUpFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 70px">
                                            <asp:Label ID="lblFollowUpTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 80px">
                                            <asp:Label ID="lblFollowUpPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients left for foreign employment 
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftForFEMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftForFEFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftForFETotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftForFEPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who took skills training  
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSkillTraineeMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSkillTraineeFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSkillTraineeTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSkillTraineePercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who left documents at home  
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftDocumentsMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftDocumentsFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftDocumentsTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLeftDocumentsPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who asked for receipts  
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAskedReceiptsMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAskedReceiptsFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAskedReceiptsTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAskedReceiptsPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who really got receipts   
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGotReceiptsMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGotReceiptsFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGotReceiptsTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGotReceiptsPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients who paid less    
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidLessMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidLessFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidLessTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidLessPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>No of clients who paid  within the govt. ceiling    
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidWithinGovtCeilingMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidWithinGovtCeilingFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidWithinGovtCeilingTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPaidWithinGovtCeilingPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>No of clients who have not yet decided     
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>No of clients who have not left yet       
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotLeftMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotLeftFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotLeftTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotLeftPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Number of clients decided not to go       
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedToGoMaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedToGoFemaleDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedToGoTotalDistrict" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNotDecidedToGoPercentageDistrict" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
