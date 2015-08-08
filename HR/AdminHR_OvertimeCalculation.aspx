<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="AdminHR_OvertimeCalculation.aspx.cs" Inherits="HR_AdminHR_OvertimeCalculation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                HR_Overtime Calculation</h3>
        </div>
        <div class="inner-content">
            <div style="width: 98%; margin: 0 auto; overflow: hidden;">
                <table>
                    <tr>
                        <td>
                            <label>
                                Employee</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEmployeeID" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                From Date</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="txt small-input"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="calendarFromDate" runat="server"
                                TargetControlID="txtFromDate">
                            </ajaxToolkit:CalendarExtender>
                            <label>
                                To Date</label>
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="txt small-input"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="calendarToDate" runat="server"
                                TargetControlID="txtToDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnCalculate" runat="server" Text="Calculation" CssClass="button button-blue"
                                OnClick="btnCalculate_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Total Overtime</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalOvertime" runat="server" CssClass="txt small-input" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                TK/Hour</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTKHour" runat="server" CssClass="txt small-input" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>
                                Total taka</label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalTaka" runat="server" CssClass="txt small-input" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnPay" runat="server" Text="Pay" CssClass="button button-blue" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
