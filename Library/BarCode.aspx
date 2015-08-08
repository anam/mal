<%@ Page Title="Book Barcode" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="BarCode.aspx.cs" Inherits="BarCode" %>

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
                Book Barcode</h3>
        </div>
        <div style="padding-bottom: 20px;">
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
                        Book Code:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtBookCode" runat="server"></asp:TextBox>
                    </td>
                    <td width="100px" style="text-align: right">
                        Quantity:
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
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
        </div>
    </div>
</asp:Content>
