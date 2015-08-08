<%@ Page Title="View Employ Pay Role Salary" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AccountEmployPayRoleSalaryReport.aspx.cs" Inherits="Accounting_AccountEmployPayRoleSalaryReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header" style="margin:10px">
            <h3>
               View Employ Pay Role Salary</h3>
        </div>
        <div style="width: 98%; margin: 0px auto; min-height: 350px; overflow: scroll">
            <CR:CrystalReportViewer ID="crvSalaryStatement" runat="server" AutoDataBind="true"
                ToolPanelView="None" HasCrystalLogo="False" />
        </div>
    </div>
</asp:Content>
