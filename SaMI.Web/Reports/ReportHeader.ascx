<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportHeader.ascx.cs" Inherits="SaMI.Web.Reports.ReportHeader" %>
<div style="min-height: 64px;" class="page-header">
    <div data-spy="affix" data-offset-top="135" id="fix-page-header">
    <div class="container"><div class="row"><div class="col-md-12">
                <h3>Reports
                    <span class="pull-right">
                        <select id="type_of_report" class="form-control input-sm" onchange="ShowReport($('#type_of_report').val());">
                            <option value="">Profile Registered</option>
                          <%--  <option value="cases">Cases</option>--%>
                        </select>
                    </span>
                </h3>
            </div></div></div>
    </div>
</div>
