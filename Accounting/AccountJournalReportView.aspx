<%@ Page Title="Trail Balance" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AccountJournalReportView.aspx.cs" Inherits="Accounting_AccountJournalReportView" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header" style="margin: 10px">
            <h3>
                Trail Balance</h3>
        </div>
        <div class="inner-form">
            From: &nbsp;&nbsp;<asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcl" runat="server" TargetControlID="txtStartDate">
            </ajaxToolkit:CalendarExtender>
            To: &nbsp;&nbsp;<asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate">
            </ajaxToolkit:CalendarExtender>
            <asp:Button ID="btnAccountJournalView" Text="View Report" runat="server" OnClick="btnAccountJournalView_OnClick" />
        </div>
        <div style="width: 98%; margin: 0px auto; min-height: 350px; overflow: scroll">
            <CR:CrystalReportViewer ID="crvTrialBalance" runat="server" AutoDataBind="true" ToolPanelView="None"
                HasCrystalLogo="False" />
        </div>
    </div>
</asp:Content>
