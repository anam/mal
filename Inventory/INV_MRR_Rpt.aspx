<%@ Page Title="MRR Report" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="INV_MRR_Rpt.aspx.cs" Inherits="Inventory_INV_MRR_Rpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 145px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                MRR Report</h3>
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
                    <td class="style26" align="right">
                        <asp:DropDownList ID="DDPrintOpt" runat="server" Font-Names="Tahoma" Style="font-size: 11px"
                            Width="130px">
                            <asp:ListItem Selected="True" Value="PDF">Adobe Acrobat (PDF)</asp:ListItem>
                            <asp:ListItem Value="HTML">HTML</asp:ListItem>
                            <asp:ListItem Value="WORD">MS Word</asp:ListItem>
                            <asp:ListItem Value="EXCEL">MS Excel</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkPrint" runat="server" CssClass="button" Font-Size="12px" Height="20px"
                            OnClick="lnkPrint_Click">PRINT</asp:LinkButton>
                    </td>
                </tr>
                <%-- <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td class="style40">
                        &nbsp;
                    </td>
                    <td class="style1" align="right">
                        <asp:Label ID="Label1" runat="server" Text="Select MRR:"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style21">
                        <asp:DropDownList ID="ddlMRRInfoMasterID" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="style26" align="right">
                        <asp:LinkButton ID="LinkButton1" runat="server" Width="50px" OnClick="LinkButton1_Click">View</asp:LinkButton>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>--%>
                <tr>
                    <td class="style41">
                        &nbsp;
                    </td>
                    <td class="style40">
                        &nbsp;
                    </td>
                    <td class="style1" align="right">
                        <asp:Label ID="Label2" runat="server" Text="Select MRR:"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="style21">
                        <asp:DropDownList ID="ddlMRRInfoMasterID" runat="server" Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td class="style26">
                        <asp:LinkButton ID="LinkButton2" runat="server" Width="50px" OnClick="LinkButton1_Click"
                            BackColor="#669900" ForeColor="White">View</asp:LinkButton>
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
                    <td class="style26" align="right">
                        <asp:Label ID="lbljavascript" runat="server"></asp:Label>
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
                    <td class="style26" align="right">
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
                    <%--<asp:TemplateField HeaderText="MRR">
                    <ItemTemplate>
                        <asp:Label ID="lblMRRInfoID" runat="server" Text='<%#Eval("MRRInfoID") %>'>
 	 </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Campus Name" HeaderStyle-Width="14%">
                        <ItemTemplate>
                            <asp:Label ID="lblCampusID" runat="server" Text='<%#Eval("CampusName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MRR Code" HeaderStyle-Width="17%">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRCode" runat="server" Text='<%#Eval("MRRCode") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Name" HeaderStyle-Width="13%">
                        <ItemTemplate>
                            <asp:Label ID="lblIteamID" runat="server" Text='<%#Eval("Description") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="9%">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "Quantity")).ToString("#,##0.0;(#,##0.0);")%>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MRR Amount" HeaderStyle-Width="13%">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRAmount" runat="server" Text='<%#Convert.ToDouble(DataBinder.Eval(Container.DataItem, "MRRAmount")).ToString("#,##0.00;(#,##0.00);") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sale Amount" HeaderStyle-Width="13%">
                        <ItemTemplate>
                            <asp:Label ID="lblSaleAmount" runat="server" Text='<%#Convert.ToDouble(DataBinder.Eval(Container.DataItem, "SaleAmount")).ToString("#,##0.00;(#,##0.00);") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MRR Date" HeaderStyle-Width="12%">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRDate" runat="server" Text='<%#Eval("MRRDate","{0:M-dd-yyyy}") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Store Name">
                        <ItemTemplate>
                            <asp:Label ID="lblStoreID" runat="server" Text='<%#Eval("StoreName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
