<%@ Page Title="Account Journal" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="AccountReportView.aspx.cs" Inherits="Accounting_AccountReportView" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="upLedger" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-box">
                <div class="header" style="margin: 10px">
                    <h3>
                        Account Ledger</h3>
                </div>
                <div class="inner-form" style="z-index: 500">
                    <table>
                        <tr>
                            <td>
                                From Date
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcl" runat="server" TargetControlID="txtStartDate">
                                </ajaxToolkit:CalendarExtender>
                                To Date:
                                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server"
                                    TargetControlID="txtEndDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Account
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan='3'>
                                <asp:DropDownList ID="ddlBasicAccountID" runat="server" OnSelectedIndexChanged="ddlBasicAccountID_SelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlSubBasicAccountID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubBasicAccountID_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlAccount" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td colspan="3">
                                <asp:Button ID="btnAccountJournalView" Text="View Report" runat="server" OnClick="btnAccountJournalView_OnClick" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 98%; margin: 0px auto; min-height: 350px; overflow: scroll;">
                    <CR:CrystalReportViewer ID="crvAccountView" runat="server" AutoDataBind="true" ToolPanelView="None"
                        HasCrystalLogo="False" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAccountJournalView" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
