<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="InvItemSales.aspx.cs" Inherits="InvItemSales" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
  <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div class="content-box">
<div class="header">
<h3>Material Reseve</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
 <div>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="center">
            <table bgcolor="#006699" width="820px">
                <tr>
                    <td class="style24">
                        &nbsp;</td>
                    <td class="style24">
                        &nbsp;</td>
                    <td class="style27">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td colspan="3">
                        <asp:Label ID="lblCheck" runat="server" ForeColor="#FF3399" 
                            style="font-weight: 700; font-size: 16px" Visible="False"></asp:Label>
                    </td>
                    <td class="style20">
                        &nbsp;</td>
                    <td class="style33">
                        &nbsp;</td>
                    <td class="style31">
                        &nbsp;</td>
                    <td class="style31">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style37">
                        &nbsp;</td>
                    <td class="style37">
                        <asp:Label ID="Label36" runat="server" Font-Bold="True" Font-Size="16px" 
                            ForeColor="White" style="font-family: 'Times New Roman', Times, serif" 
                            Text="Sales  Point :" Width="100px"></asp:Label>
                    </td>
                    <td class="style38" align="right">
                        <asp:DropDownList ID="ddlStoreID" runat="server" Font-Bold="False" 
                            Width="120px">
                        </asp:DropDownList>
                    </td>
                    <td class="style39">
                        </td>
                    <td class="style40">
                        <asp:Label ID="Label25" runat="server" ForeColor="White" 
                            style="font-size: 16px; font-family: 'Times New Roman', Times, serif; font-weight: 700; text-align: right;" 
                            Text="Date:" Width="98px"></asp:Label>
                    </td>
                    <td class="style41" align="left">
                        <asp:TextBox ID="txtDate" runat="server" BorderStyle="None" Font-Bold="False" 
                            Width="140px"></asp:TextBox>

                    </td>
                    <td class="style42" align="right">
                        <asp:Label ID="Label19" runat="server" ForeColor="White" 
                            style="font-family: 'Times New Roman'; font-weight: 700; font-size: 16px" 
                            Text="Invoice:" Width="55px"></asp:Label>
                    </td>
                    <td class="style43">
                        <asp:TextBox ID="txtInvoice" runat="server" BorderStyle="None" 
                            Font-Bold="False" Width="110px" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                    <td align="left">
                        &nbsp;</td>
                    <td class="style39">
                        </td>
                    <td class="style39">
                        </td>
                </tr>
            
                <tr>
                    <td class="style24">
                        &nbsp;</td>
                    <td class="style24">
                        <asp:Label ID="Label21" runat="server" CssClass="style25" ForeColor="White" 
                            Text="Remarks:" Width="75px"></asp:Label>
                    </td>
                    <td class="style27" colspan="4">
                        <asp:TextBox ID="txtAddress" runat="server" BorderStyle="None"
                            Width="380px"></asp:TextBox>
                    </td>
                    <td class="style22">
                        <asp:Label ID="Label40" runat="server" 
                            style="text-align: right; font-family: Verdana; font-size: 12px; color: #FFFFFF; font-weight: 700" 
                            Text="Campus:" Width="100px"></asp:Label>
                    </td>
                    <td class="style22">
                        <asp:DropDownList ID="ddlCampus" runat="server" Font-Bold="False" 
                            Font-Size="12px" Width="100px">
                        </asp:DropDownList>
                    </td>
                    <td class="style22">
                        &nbsp;</td>
                    <td class="style31">
                        &nbsp;</td>
                    <td class="style31">
                        &nbsp;</td>
                </tr>
            </table>
            <asp:Panel ID="pnlItemInfo" runat="server">
                
                <table bgcolor="#339966" width="820px">
                    <tr>
                        <td class="style24">
                            &nbsp;</td>
                        <td class="style27">
                            &nbsp;</td>
                        <td class="style23" colspan="3" align="right">
                            &nbsp;</td>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style33">
                            &nbsp;</td>
                        <td class="style31">
                            &nbsp;</td>
                        <td class="style31">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:LinkButton ID="lnkbtnList" runat="server" CssClass="button" Height="20px" 
                                onclick="lnkbtnList_Click1" Width="80px">Item List</asp:LinkButton>
                        </td>
                        <td class="style27">
                            <asp:TextBox ID="txtItemSearch" runat="server" BorderStyle="None" 
                                Font-Bold="False" Width="120px"></asp:TextBox>
                        </td>
                        <td align="left" colspan="4">
                            <asp:DropDownList ID="ddlItemDesc" runat="server" AutoPostBack="True" 
                                Font-Bold="False" 
                                onselectedindexchanged="ddlItemDesc_SelectedIndexChanged" Width="380px">
                            </asp:DropDownList>
                        </td>
                        <td class="style33" align="right">
                            <asp:Label ID="Label4" runat="server" align="right" CssClass="style25" 
                                ForeColor="White" Text="Tag ID :" Width="60px"></asp:Label>
                        </td>
                        <td class="style31">
                            <asp:TextBox ID="txtTagID" runat="server" BorderStyle="None" 
                                Width="100px" MaxLength="14"></asp:TextBox>
                        </td>
                        <td class="style31">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" class="style35">
                            <asp:Label ID="Label22" runat="server" CssClass="style25" ForeColor="White" 
                                Text="Warrenty:"></asp:Label>
                        </td>
                        <td class="style27">
                            <asp:TextBox onkeypress="PhoneOnlyDigit()" ID="txtWarrenty" runat="server" BorderStyle="None" 
                                Font-Bold="False" 
                                style="text-align: left; " Width="70px" MaxLength="2"></asp:TextBox>
                            <asp:Label ID="Label39" runat="server" Font-Bold="True" Font-Size="12px" 
                                ForeColor="White" Text="(Month)"></asp:Label>
                        </td>
                        <td class="style32">
                            <asp:Label ID="Label35" runat="server" ForeColor="White" 
                                style="font-weight: 700; font-family: 'Times New Roman', Times, serif; font-size: 16px;" 
                                Text="Quantity:"></asp:Label>
                        </td>
                        <td align="left" class="style44">
                            <asp:TextBox onkeypress="checkKey()" ID="txtQty" runat="server" 
                                BorderStyle="None" Font-Bold="False" style="text-align: left; " Width="80px" 
                                MaxLength="4"></asp:TextBox>
                        </td>
                        <td class="style22">
                            <asp:Label ID="Label23" runat="server" CssClass="style25" ForeColor="White" 
                                Text="Unit Price:" Width="75px"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox onkeypress="checkKey()" ID="txtUnitPrice" runat="server" BorderStyle="None" 
                                Font-Bold="False" style="text-align: left; " 
                                Width="100px" MaxLength="7"></asp:TextBox>
                        </td>
                        <td class="style33">
                            <asp:Label ID="Label24" runat="server" CssClass="style25" ForeColor="White" 
                                Text="Total Price:" Width="80px"></asp:Label>
                        </td>
                        <td align="center" class="style31">
                            <asp:TextBox ID="txtTotalPrice" runat="server" BorderStyle="None" 
                                Font-Bold="False"  Width="100px"></asp:TextBox>
                        </td>
                        <td align="left" class="style31">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style24">
                            &nbsp;</td>
                        <td class="style27">
                            &nbsp;</td>
                        <td class="style32" colspan="2">
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#FF0066"></asp:Label>
                        </td>
                        <td class="style22">
                            &nbsp;</td>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style33">
                            &nbsp;</td>
                        <td class="style31">
                            <asp:LinkButton ID="btnAddToTable" runat="server" CssClass="button" 
                                Font-Underline="False" Height="20px" onclick="btnAddToTable_Click" 
                                style="font-size: 16px; font-family: 'Times New Roman', Times, serif" 
                                Width="95px">Add To Table</asp:LinkButton>
                        </td>
                        <td class="style31">
                            &nbsp;</td>
                    </tr>
                </table>
                </asp:Panel>
            <asp:GridView ID="gvSales" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" GridLines="Vertical" Font-Size="12px" PageSize="5" 
                
         
                    style="text-align: center" 
                    ShowFooter="True" Width="820px">
                <RowStyle BackColor="#00CC99" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <asp:Label ID="Label32" runat="server" 
                                Text="<%# Convert.ToString(Container.DataItemIndex+1) %>" Width="30px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Code">
                        <ItemTemplate>
                            <asp:Label ID="gvlblSircode" runat="server" 
                                Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "sircode")) %>' 
                                Width="100px" style="text-align: left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Description">
                        <ItemTemplate>
                            <asp:Label ID="Label27" runat="server" 
                                Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "itemdesc")) %>' 
                                Width="230px" style="text-align: left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tag ID">
                        <FooterTemplate>
                            <asp:LinkButton ID="btnSalesUpdate" runat="server" Font-Bold="True" 
                                Font-Size="14px" onclick="btnSalesUpdate_Click" Width="50px">Update</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label28" runat="server" 
                                Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "tagid")) %>' 
                                Width="80px" style="text-align: left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Warrenty">
                        <ItemTemplate>
                            <asp:TextBox ID="gvtxtWarrenty" runat="server" BackColor="Transparent" 
                                BorderColor="Blue" BorderStyle="None" BorderWidth="1px" 
                                Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "warrenty")) %>' 
                                Width="70px" Font-Size="11px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="gvtxtQty" runat="server" BackColor="Transparent" 
                                BorderStyle="None" 
                                Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "quantity")).ToString("#,##0.00;(#,##0.00); ") %>' 
                                Width="70px" Font-Size="11px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit Price">
                        <FooterTemplate>
                            <asp:LinkButton ID="btnFinalUpdate" runat="server" CssClass="button" 
                                Font-Underline="False" Height="20px" onclick="btnFinalUpdate_Click" 
                                Width="82px">Final Update</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="gvtxtPrice" runat="server" BackColor="Transparent" 
                                BorderStyle="None" 
                                Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "unitprice")).ToString("#,##0.00;(#,##0.00); ") %>' 
                                Width="60px" Font-Size="11px" style="text-align: right"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Price">
                        <FooterTemplate>
                            <asp:Label ID="gvlblTotal" runat="server" Font-Size="12px" ForeColor="Blue" 
                                style="font-weight: 700; text-align: right;" Text="Label" Width="60px"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label31" runat="server" 
                                Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "totalprice")).ToString("#,##0.00;(#,##0.00); ") %>' 
                                Width="60px" style="text-align: right"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="Black" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#DCDCDC" />
            </asp:GridView>
                
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
 </div> 	
 </div>
 </div>
</asp:Content>

