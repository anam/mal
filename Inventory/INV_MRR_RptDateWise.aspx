<%@ Page Title="Datewise MRR Report" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="INV_MRR_RptDateWise.aspx.cs" Inherits="INV_MRR_RptDateWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 145px;
        }
        .style2
        {
            width: 254px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div class="content-box">
        <div class="header">
            <h3>
                Datewise Inventory MRR Report</h3>
        </div>
        <div class="inner-form">
            <table style="width: 100%; height: 31px;">
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td class="style40">
                        &nbsp;
                    </td>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style21">
                        <asp:Label ID="lblPrint" runat="server"></asp:Label>
                    </td>
                    <td class="style2" align="right">
                        <asp:DropDownList ID="DDPrintOpt" runat="server" Font-Names="Tahoma" Style="font-size: 11px"
                            Width="130px">
                            <asp:ListItem Selected="True" Value="PDF">Adobe Acrobat (PDF)</asp:ListItem>
                            <asp:ListItem Value="HTML">HTML</asp:ListItem>
                            <asp:ListItem Value="WORD">MS Word</asp:ListItem>
                            <asp:ListItem Value="EXCEL">MS Excel</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkPrint" runat="server" CssClass="button" Font-Size="12px" Height="20px"
                            OnClick="lnkPrint_Click">PRINT</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td class="style40">
                        &nbsp;
                    </td>
                    <td class="style1" align="right">
                        <asp:Label ID="Label1" runat="server" Text="From Date:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" Font-Bold="False"
                            Width="100px"></asp:TextBox>
                        <asp:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtFromDate">
                        </asp:CalendarExtender>
                    </td>
                    <td class="style21">
                        <asp:Label ID="Label2" runat="server" Text="To Date:"></asp:Label>
                    </td>
                    <td class="style2" align="left">
                        &nbsp;
                        <asp:TextBox ID="txtToDate" runat="server" Font-Bold="False" Width="100px"></asp:TextBox>
                        <asp:CalendarExtender ID="txtIssueDate0_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtToDate">
                        </asp:CalendarExtender>
                    </td>
                    <td>
                        &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Width="50px" OnClick="LinkButton1_Click">View</asp:LinkButton>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td class="style40">
                        &nbsp;
                    </td>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style21">
                        &nbsp;
                    </td>
                    <td class="style2" align="right">
                        <asp:Label ID="lbljavascript" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td class="style40">
                        &nbsp;
                    </td>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style21">
                        &nbsp;
                    </td>
                    <td class="style2" align="right">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvINV_MRRInfo" class="gridCss" runat="server" AutoGenerateColumns="false"
                 CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="MRR Info ID" Visible="false" HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRInfoID" runat="server" Visible="false" Text='<%#Eval("MRRInfoID") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Campus Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCampusID" runat="server" Text='<%#Eval("CampusName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--<asp:TemplateField HeaderText="MRR Info Master Name">
                    <ItemTemplate>
                        <asp:Label ID="lblMRRInfoMasterID" runat="server" Text='<%#Eval("MRRInfoMasterID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="MRR Code">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRCode" runat="server" Text='<%#Eval("MRRCode") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Name">
                        <ItemTemplate>
                            <asp:Label ID="lblIteamID" runat="server" Text='<%#Eval("Description") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tag" HeaderStyle-Width="6%">
                        <ItemTemplate>
                            <asp:Label ID="lblTagID" runat="server" Text='<%#Eval("TagID") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "Quantity")).ToString("#,##0.00;(#,##0.00); ")  %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MRR Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRAmount" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "MRRAmount")).ToString("#,##0.00;(#,##0.00); ") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sale Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblSaleAmount" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "SaleAmount")).ToString("#,##0.00;(#,##0.00); ") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MRR Date">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRDate" runat="server" Text='<%#Eval("MRRDate","{0:dd-MMM-yyyy}")  %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Store Name" HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblStoreID" runat="server" Text='<%#Eval("StoreID") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
