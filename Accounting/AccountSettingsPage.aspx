<%@ Page Title="Account Settings" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="AccountSettingsPage.aspx.cs" Inherits="Accounting_AccountSettingsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="content-box">
        <div class="header">
            <h3>
                Account Settings</h3>
        </div>
        <div class="inner-content">
            <table width="100%" class="gridCss">
                <tr>
                    <td>
                        <%--<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Accounting/AdminACC_BasicAccount.aspx"
                            Text="Add Basic Account"></asp:HyperLink>--%>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Accounting/AdminDisplayACC_BasicAccount.aspx"
                            Text="View Basic Account"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Accounting/AdminACC_SubBasicAccount.aspx"
                            Text="Add Sub Basic Account"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Accounting/AdminDisplayACC_SubBasicAccount.aspx"
                            Text="View Sub Basic Account"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Accounting/AdminACC_Account.aspx"
                            Text="Add Account"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Accounting/AdminDisplayACC_Account.aspx"
                            Text="View Account"></asp:HyperLink>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Accounting/AdminACC_OpeningBalance.aspx"
                            Text="Add Opening Balance"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Accounting/AdminDisplayACC_OpeningBalance.aspx"
                            Text="View Opening Balance"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Accounting/AdminACC_Head.aspx"
                            Text="Add Head"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Accounting/AdminDisplayACC_Head.aspx"
                            Text="View Head"></asp:HyperLink>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Accounting/AdminACC_BankAccount.aspx"
                            Text="Add CUC Bank Account"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Accounting/AdminDisplayACC_BankAccount.aspx"
                            Text="View CUC Bank Account"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Accounting/AdminACC_AccountingUser.aspx"
                            Text="Add Bank/Other Company"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink124" runat="server" NavigateUrl="~/Accounting/AdminDisplayACC_AccountingUser.aspx"
                            Text="View All Bank/ Other Company"></asp:HyperLink>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Fees/AdminSTD_Program.aspx"
                            Text="Add Program"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Fees/AdminDisplaySTD_Program.aspx"
                            Text="View All Program"></asp:HyperLink>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Accounting/AdminACC_AccountingUser.aspx"
                            Text="Add Accounting User"></asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Accounting/AdminDisplayACC_AccountingUser.aspx"
                            Text="View Accounting User"></asp:HyperLink>
                    </td>
                </tr>--%>
                <tr>
                    <td colspan='2'>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnCalculateSemesterFee" runat="server" 
                                        class="button button-blue"  Text="Calculate Semester Fee" 
                                        onclick="btnCalculateSemesterFee_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan='2'>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnDataBaseBackup" runat="server" 
                                        class="button button-blue"  Text="Get DataBaseBackup" 
                                        onclick="btnDataBaseBackup_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

