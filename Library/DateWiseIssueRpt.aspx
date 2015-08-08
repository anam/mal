<%@ Page Title="Datewise Book Report" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="DateWiseIssueRpt.aspx.cs" Inherits="DateWiseIssueRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 315px;
            height: 20px;
        }
        .style3
        {
            width: 150px;
        }
        .style5
        {
            height: 20px;
        }
        .style6
        {
            width: 230px;
            height: 20px;
        }
        .style7
        {
            width: 230px;
        }
        .style8
        {
            width: 145px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Datewise Book Report</h3>
        </div>
        <div style="padding-bottom:20px;">
            <table style="width: 100%; height: 31px;">
                <tr>
                    <td class="style5">
                        &nbsp;
                    </td>
                    <td class="style6">
                        &nbsp;
                    </td>
                    <td class="style1" colspan="3">
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:Label ID="lblPrint" runat="server"></asp:Label>
                    </td>
                    <td class="style5" width="130px">
                        <asp:DropDownList ID="DDPrintOpt" runat="server" Font-Names="Tahoma" Style="font-size: 11px"
                            Width="130px">
                            <asp:ListItem Selected="True" Value="PDF">Adobe Acrobat (PDF)</asp:ListItem>
                            <asp:ListItem Value="HTML">HTML</asp:ListItem>
                            <asp:ListItem Value="WORD">MS Word</asp:ListItem>
                            <asp:ListItem Value="EXCEL">MS Excel</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style5" align="right">
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:LinkButton ID="lnkPrint" runat="server" CssClass="button" Font-Size="12px" Height="20px"
                            OnClick="lnkPrint_Click">PRINT</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td style="text-align: right">
                        From Date:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtFromDate">
                        </asp:CalendarExtender>
                    </td>
                    <td width="100px" style="text-align: right">
                        To Date:
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtToDate">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkBtnShow" runat="server" BackColor="#336600" ForeColor="White"
                            OnClick="lnkBtnShow_Click" Width="40px">Show</asp:LinkButton>
                    </td>
                    <td class="style21" width="130px" align="center">
                        &nbsp;
                        <asp:Label ID="lbljavascript" runat="server"></asp:Label>
                    </td>
                    <td class="style26" align="right">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div class="inner-content">
                <asp:GridView ID="gvLIB_Book" class="gridCss" runat="server" AutoGenerateColumns="false"
                    CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Book ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblBookID" Visible="false" runat="server" Text='<%#Eval("BookID") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Book Name">
                            <ItemTemplate>
                                <asp:Label ID="lblBookName" runat="server" Text='<%#Eval("BookName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Author Name">
                            <ItemTemplate>
                                <asp:Label ID="lblAuthorID" runat="server" Text='<%#Eval("AuthorName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Issue Date" HeaderStyle-Width="22%">
                            <ItemTemplate>
                                <asp:Label ID="lblPublishedYear" runat="server" Text='<%#Eval("IssueDate") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>
