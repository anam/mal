<%@ Page Title="Item Receive Entry" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="ItemReceiveEntryScreen.aspx.cs" Inherits="Inventory_NewPageByKhlid" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/JavaScript">
        function checkKey() {
            if ((window.event.keyCode < 48 || window.event.keyCode > 57) && window.event.keyCode != 46) {

                alert("You hit Non-numeric :" + String.fromCharCode(window.event.keyCode));
                window.event.returnValue = false;
            }
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div class="content-box ">
        <div class="header">
            <h3>
                Item Receive Entry
            </h3>
        </div>
        <!-- Default basic forms -->
        <div class="inner-form">
            <!-- error and information messages -->
            <div style="float: right; width: 26%;">
                <asp:DropDownList ID="ddlAdobe" runat="server">
                    <asp:ListItem Selected="True" Value="PDF">Adobe Acrobat (PDF)</asp:ListItem>
                    <asp:ListItem Value="HTML">HTML</asp:ListItem>
                    <asp:ListItem Value="WORD">MS Word</asp:ListItem>
                    <asp:ListItem Value="EXCEL">MS Excel</asp:ListItem>
                </asp:DropDownList>
                <a style="float: right; color: Red; text-decoration: underline;" href="#">Print</a>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblMRRNumber" runat="server" Text="MRR No" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtMRRNo" runat="server" CssClass="targetTxtBox" Enabled="False"></asp:TextBox>
                    </span>
                </div>
            </div>
            <div style="width: 100%; overflow: hidden;">
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblMRRDate" runat="server" Text="MRR Date" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtMRRDate" runat="server" CssClass="targetTxtBox"></asp:TextBox>
                        <asp:CalendarExtender ID="txtMRRDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtMRRDate">
                        </asp:CalendarExtender>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="Label1" runat="server" Text="Store Name" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:DropDownList ID="ddlStoreID" runat="server">
                        </asp:DropDownList>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblItemList" runat="server" Text="Item List:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:DropDownList ID="ddlItemDesc" runat="server">
                        </asp:DropDownList>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblTagNumber" runat="server" Text="Tag Number" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtTag" runat="server" CssClass="targetTxtBox"></asp:TextBox></span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtQty" onkeypress="checkKey()" runat="server" CssClass="targetTxtBox"></asp:TextBox>
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblMRRRate" runat="server" Text="MRR Rate" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtMRRRate" runat="server" onkeypress="checkKey()" CssClass="targetTxtBox"></asp:TextBox></span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblSalesRate" runat="server" Text="Sales Rate" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:TextBox ID="txtSalesRate" runat="server" onkeypress="checkKey()" CssClass="targetTxtBox"></asp:TextBox>
                        <asp:Button ID="lnkBtnAdd" runat="server" Text="Add To Table" CssClass="button button-green"
                            ValidationGroup="contactus" CausesValidation="true" OnClientClick="btnsubmit_onclick"
                            OnClick="lnkBtnAdd_Click" />
                    </span>
                </div>
                <div style="width: 100%; overflow: hidden; padding-top: 5px;">
                    <asp:Label ID="lblCampus" runat="server" Text="Campus:" CssClass="targetCss"></asp:Label>
                    <span style="width: 73%; float: right;">
                        <asp:DropDownList ID="ddlCampus" runat="server">
                        </asp:DropDownList>
                    </span>
                </div>
                <div>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label></div>
            </div>
            <br />
            <div align="center" style="overflow: scroll;">
                <asp:GridView ID="gvReceive" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Font-Names="Verdana" Font-Size="12px" OnPageIndexChanging="gvReceive_PageIndexChanging"
                    OnRowDataBound="gvReceive_RowDataBound" ShowFooter="True" Width="50px">
                    <PagerSettings PageButtonCount="15" />
                    <RowStyle BackColor="#00CC99" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sl.">
                            <ItemTemplate>
                                <asp:Label ID="lblgvTrSlNo" runat="server" Font-Bold="False" Font-Size="10px" Style="text-align: right"
                                    Text='<%# Convert.ToString(Container.DataItemIndex + 1).Trim() + "." %>' Width="20px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Code" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveItemCode" runat="server" Font-Size="10px" Text='<%# DataBinder.Eval(Container.DataItem, "sircode").ToString() %>'
                                    Width="80px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Description">
                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveItemDesc" runat="server" Font-Size="10px" Text='<%# DataBinder.Eval(Container.DataItem, "sirdesc1").ToString() %>'
                                    Width="260px" Style="text-align: left"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit">
                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveUnit" runat="server" Font-Size="10px" Text='<%# DataBinder.Eval(Container.DataItem, "sirunit").ToString() %>'
                                    Width="40px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TAG No.">
                            <FooterTemplate>
                                <asp:LinkButton ID="LbtngvReceiveTrCalTotal" runat="server" Font-Bold="True" Font-Names="Verdana"
                                    Font-Size="11px" OnClick="LbtngvReceiveCalTotal_Click" Style="font-size: 11px;
                                    text-align: right; height: 13px;" Width="100px">Total Amount :</asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgvReceiveTagNo" runat="server" Font-Size="10px" Style="background-color: Transparent;
                                    border-top-style: none; border-bottom-style: none; border-left-style: none; border-right-style: none;
                                    text-align: left;" Text='<%# DataBinder.Eval(Container.DataItem, "tagid").ToString() %>'
                                    Width="80px" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit">
                            <ItemTemplate>
                                <asp:TextBox ID="txtgvReceiveUnit" runat="server" Font-Size="10px" Style="background-color: Transparent;
                                    border-top-style: none; border-bottom-style: none; border-left-style: none; border-right-style: none;
                                    text-align: right;" Text='<%# DataBinder.Eval(Container.DataItem, "sirdesc1").ToString() %>'
                                    Width="35px" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty">
                            <ItemTemplate>
                                <asp:TextBox ID="txtgvReceiveQty" runat="server" Font-Size="10px" Style="background-color: Transparent;
                                    border-top-style: none; border-bottom-style: none; border-left-style: none; border-right-style: none;
                                    text-align: right;" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "mrrqty")).ToString("#,##0.00;(#,##0.00); ") %>'
                                    Width="35px" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MRR Rate">
                            <ItemTemplate>
                                <asp:TextBox ID="txtgvReceiveMRRRate" runat="server" Font-Size="10px" Style="background-color: Transparent;
                                    border-top-style: none; border-bottom-style: none; border-left-style: none; border-right-style: none;
                                    text-align: right;" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem,"mrrrat")).ToString("#,##0.00;(#,##0.00); ") %>'
                                    Width="80px" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MRR Amt">
                            <FooterTemplate>
                                <asp:Label ID="lblgvReceiveMRRTotalAmt" runat="server" Font-Bold="True" Font-Size="11px"
                                    Style="text-align: right" Width="80px"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveMRRAmt" runat="server" Font-Size="10px" Style="text-align: right"
                                    Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "mrramt")).ToString("#,##0.00;(#,##0.00); ") %>'
                                    Width="80px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sales Rate">
                            <FooterTemplate>
                                <asp:LinkButton ID="lnkbtnFinal" runat="server" CssClass="button" Font-Underline="False"
                                    OnClick="lnkbtnFinal_Click" Width="82px">Final Update</asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgvReceiveSalesRate" runat="server" Font-Size="10px" Style="background-color: Transparent;
                                    border-top-style: none; border-bottom-style: none; border-left-style: none; border-right-style: none;
                                    text-align: right;" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "salrat")).ToString("#,##0.00;(#,##0.00); ") %>'
                                    Width="80px" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sales Amt">
                            <FooterTemplate>
                                <asp:Label ID="lblgvReceiveSalesTotalAmt" runat="server" Font-Bold="True" Font-Size="10px"
                                    Style="text-align: right" Width="80px"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveSalesAmt" runat="server" Font-Size="10px" Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "salamt")).ToString("#,##0.00;(#,##0.00); ") %>'
                                    Style="text-align: right" Width="80px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <AlternatingRowStyle BackColor="#CCFFFF" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
