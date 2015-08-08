<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="SalesManagementScreen.aspx.cs" Inherits="Inventory_SalesManagementScreen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box ">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        <div class="header">
            <h3>
                Sales Management Screen</h3>
        </div>
        <div class="inner-form">
            <div style="float: right; width: 26%;">
                <asp:DropDownList ID="ddlAdobe" runat="server">
                    <asp:ListItem Selected="True" Value="PDF">Adobe Acrobat (PDF)</asp:ListItem>
                    <asp:ListItem Value="HTML">HTML</asp:ListItem>
                    <asp:ListItem Value="WORD">MS Word</asp:ListItem>
                    <asp:ListItem Value="EXCEL">MS Excel</asp:ListItem>
                </asp:DropDownList>
                <asp:LinkButton ID="btnPrint" runat="server" CssClass="button" Height="20px" 
                    onclick="lnkPrint_Click">PRINT</asp:LinkButton>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="Label2" runat="server" Text="Invoice:" CssClass="targetCss"></asp:Label>
                    <span style="width: 74%; float: right;">
                        <asp:TextBox ID="txtInvoice" runat="server" CssClass="targetTxtBox" 
                        ReadOnly="True"></asp:TextBox>
                    </span>
                    
                </div>
                <div>
                <asp:Label ID="lblPrint" runat="server"></asp:Label>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden;">
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblSalesPoint" runat="server" Text="Sales Point:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:DropDownList ID="ddlStoreID" runat="server">
                        </asp:DropDownList>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblDate" runat="server" Text="Date:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="targetTxtBox"></asp:TextBox>
                        <asp:CalendarExtender ID="txtMRRDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtDate">
                        </asp:CalendarExtender>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblCustomerName" runat="server" Text="Remark:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="targetTxtBox"></asp:TextBox></span>
                </div>
               <%-- <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="Label1" runat="server" Text="Campus:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:DropDownList ID="ddlCampus" runat="server">
                        </asp:DropDownList>
                    </span>
                </div>--%>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblItemList" runat="server" Text="Item List:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:DropDownList ID="ddlItemDesc" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlItemDesc_SelectedIndexChanged1">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtAvaQtyCheck" runat="server" CssClass="targetTxtBox" 
                        Enabled="False"></asp:TextBox>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblTagID" runat="server" Text="TagID:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtTagID" runat="server" CssClass="targetTxtBox"></asp:TextBox></span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblWarrenty" runat="server" Text="Warrenty:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtWarrenty" runat="server" CssClass="targetTxtBox"></asp:TextBox>
                        <asp:Label ID="Label39" runat="server" Text="(Month)"></asp:Label>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtQty" runat="server" CssClass="targetTxtBox"></asp:TextBox></span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="targetTxtBox"></asp:TextBox></span>
                </div>
                
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="targetTxtBox"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Add To Table" CssClass="button button-green"
                            ValidationGroup="contactus" CausesValidation="true" OnClientClick="btnsubmit_onclick"
                            OnClick="btnAddToTable_Click" />
                    </span>
                </div>
                <div>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label></div>
            </div>
            <div style="overflow:scroll;">
            <asp:GridView ID="gvSales" runat="server" AutoGenerateColumns="False" BackColor="White"
                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
                Font-Size="12px" PageSize="5" Style="text-align: center" ShowFooter="True" Width="820px">
                <RowStyle BackColor="#33CC99" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <asp:Label ID="Label32" runat="server" Text="<%# Convert.ToString(Container.DataItemIndex+1) %>"
                                Width="30px"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Code">
                        <ItemTemplate>
                            <asp:Label ID="gvlblSircode" runat="server" Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "sircode")) %>'
                                Width="80px" Style="text-align: left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Description">
                        <ItemTemplate>
                            <asp:Label ID="Label27" runat="server" Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "itemdesc")) %>'
                                Width="200px" Style="text-align: left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tag ID">
                        <FooterTemplate>
                            <asp:LinkButton ID="btnSalesUpdate" runat="server" Font-Bold="True" Font-Size="14px"
                                OnClick="btnSalesUpdate_Click" Width="50px">Update</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label28" runat="server" Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "tagid")) %>'
                                Width="80px" Style="text-align: left"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Warrenty">
                        <ItemTemplate>
                            <asp:TextBox ID="gvtxtWarrenty" runat="server" BackColor="Transparent" BorderColor="Blue"
                                BorderStyle="None" BorderWidth="1px" Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "warrenty")) %>'
                                Width="70px" Font-Size="11px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="gvtxtQty" runat="server" BackColor="Transparent" BorderStyle="None"
                                Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "quantity")).ToString("#,##0.00;(#,##0.00); ") %>'
                                Width="70px" Font-Size="11px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unit Price">
                        <FooterTemplate>
                            <asp:LinkButton ID="btnFinalUpdate" runat="server" CssClass="button" Font-Underline="False"
                                Height="20px" OnClick="btnFinalUpdate_Click" Width="82px">Final Update</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="gvtxtPrice" runat="server" BackColor="Transparent" BorderStyle="None"
                                Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "unitprice")).ToString("#,##0.00;(#,##0.00); ") %>'
                                Width="60px" Font-Size="11px" Style="text-align: right"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Price">
                        <FooterTemplate>
                            <asp:Label ID="gvlblTotal" runat="server" Font-Size="12px" ForeColor="Blue" Style="font-weight: 700;
                                text-align: right;" Text="Label" Width="60px"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label31" runat="server" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "totalprice")).ToString("#,##0.00;(#,##0.00); ") %>'
                                Width="60px" Style="text-align: right"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="Black" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#F0FFFF" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#87CEFA" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#DCDCDC" />
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
