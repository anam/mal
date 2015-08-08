<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="CBEExam.aspx.cs" Inherits="Fees_CBEExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:UpdatePanel ID="upCBESearch" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Search CBE Exam</h3>
                </div>
                <div class="inner-content" style="width: 98%">
                    <table>
                    <tr>
                        <td colspan="5">Bank Deposit/withdraw</td>
                      </tr>
                        <tr>
                            <td>
                                Bank
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBank" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Bank
                            </td>
                            <td>
                                <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkisDeposit" runat="server" Text="Deposit?" Checked="true"/>
                            </td>
                            </tr><tr>
                            <td>
                                Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="ajcal" runat="server" TargetControlID="txtDate"
                                    Format="dd MMM yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" Text="Submit" onclick="btnAdd_Click" />
                            </td>
                        </tr>
                    </table>
                      <table>
                      <tr>
                        <td colspan="5">Other Expense</td>
                      </tr>
                        <tr>
                            <td>
                                Head
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHead" runat="server" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                New
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewHead" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkExpence" runat="server" Text="Expence?" Checked="true"/>
                            </td>
                            </tr><tr>
                            <td>
                                Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txtExpenceAmount" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtExpenceDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExpenceDate"
                                    Format="dd MMM yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="btnOtherAccounts" runat="server" Text="Submit" 
                                    onclick="btnOtherAccounts_Click"  />
                            </td>
                        </tr>
                    </table>
                    <table>
                      <tr>
                        <td colspan="5">Transaction</td>
                      </tr>
                        <tr>
                            <td>
                                From
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                    Format="dd MMM yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                To
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtToDate"
                                    Format="dd MMM yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="btnReprt" runat="server" Text="Submit" onclick="btnReprt_Click" 
                                     />
                            </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:Label ID="lblLink" runat="server" Text=""></asp:Label>
                        </td>
                      </tr>
                    </table>
                </div>

            </div>
         </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

