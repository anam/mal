<%@ Page Title="Daily Transaction Report" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="DailyTransactionReport.aspx.cs" Inherits="Accounting_DailyTransactionReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header" style="margin: 10px">
            <h3>
                Daily Transaction Report</h3>
        </div>
        <div class="inner-form">
            From Date:
            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcs" runat="server" TargetControlID="txtStartDate"></ajaxToolkit:CalendarExtender>
            To Date:
            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajce" runat="server" TargetControlID="txtEndDate"></ajaxToolkit:CalendarExtender>
            <asp:Button ID="btnDailyReport" runat="server" Text="View Report" CssClass="button button-blue" OnClick="btnDailyReport_OnClick" /><br />
            <br />
        </div>
       
    </div>
</asp:Content>
