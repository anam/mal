<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="InvItemIssue.aspx.cs" Inherits="InvItemIssue" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="content-box">
<div class="header">
<h3>Material Reseve</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
     <table style="width: 100%; height: 31px;">
        <tr>
            <td class="style41">
                &nbsp;</td>
            <td class="style40">
                &nbsp;</td>
            <td class="style19">
                <asp:Label ID="Label2" runat="server" BackColor="#996666" ForeColor="Navy" 
                    style="font-size: 18px; font-family: 'Times New Roman', Times, serif; text-align: center" 
                    Text="ITEM ISSUE ENTRY SCREEN" Width="300px" Font-Bold="True" 
                    Font-Size="20px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td class="style21">
                <asp:Label ID="lblPrint" runat="server"></asp:Label>
            </td>
            <td class="style26" align="right">
                    <asp:DropDownList ID="DDPrintOpt" runat="server" Font-Names="Tahoma" 
                        Style="font-size: 11px" Width="130px">
                        <asp:ListItem Selected="True" Value="PDF">Adobe Acrobat (PDF)</asp:ListItem>
                        <asp:ListItem Value="HTML">HTML</asp:ListItem>
                        <asp:ListItem Value="WORD">MS Word</asp:ListItem>
                        <asp:ListItem Value="EXCEL">MS Excel</asp:ListItem>
                    </asp:DropDownList>
                </td>
            <td>
                <asp:LinkButton ID="lnkPrint" runat="server" CssClass="button" Font-Size="12px" 
                    Height="20px" onclick="lnkPrint_Click">PRINT</asp:LinkButton>
            </td>
        </tr>
       </table>  

                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td class="style25">
                                    &nbsp;</td>
                                <td class="style20">
                                    &nbsp;</td>
                                <td class="style32">
                                    &nbsp;</td>
                                <td class="style24">
                                    &nbsp;</td>
                                <td class="style31">
                                    &nbsp;</td>
                                <td class="style28">
                                    &nbsp;</td>
                                <td class="style21">
                                    &nbsp;</td>
                                <td class="style27">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style25" colspan="9">
                                    <asp:Panel ID="PanelProduct" runat="server" BorderStyle="None">
                                        <div align="center">
                                        <table bgcolor="#006699" width="690px">
                                            <tr>
                                                <td class="style12">
                                                    &nbsp;</td>
                                                <td class="style34">
                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="16px" 
                                                        ForeColor="White" style="font-family: 'Times New Roman', Times, serif" 
                                                        Text="Store ID:"></asp:Label>
                                                </td>
                                                <td class="style43">
                                                    <asp:DropDownList ID="ddlStoreFromID" runat="server" Font-Bold="False" 
                                                        Width="110px">
                                                        
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="style21" align="right">
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="12px" 
                                                        ForeColor="White" style="font-size: 16px; font-family: 'Times New Roman', Times, serif;" 
                                                        Text="Issue Date:" Width="95px"></asp:Label>
                                                </td>
                                                <td class="style36">
                                                    <asp:TextBox ID="txtIssueDate" runat="server" BorderStyle="None" 
                                                        Font-Bold="False" Width="100px"></asp:TextBox>

                                              <asp:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server" 
                                                    Enabled="True" TargetControlID="txtIssueDate">
                                             </asp:CalendarExtender>
                                                 
                                                </td>
                                                <td class="style47" align="right">
                                                    <asp:Label ID="Label4" runat="server" BorderStyle="None" Font-Bold="True" 
                                                        Font-Size="12px" ForeColor="White" 
                                                        style="margin-left: 0px; font-size: 16px; font-family: 'Times New Roman', Times, serif;" 
                                                        Text="Issue No:" Width="90px"></asp:Label>
                                                </td>
                                                <td class="style37">
                                                    <asp:TextBox ID="txtIssueNo" runat="server" AutoCompleteType="Disabled" 
                                                        BorderStyle="None" Font-Bold="False" style="margin-left: 0px" 
                                                        Width="110px" ReadOnly="True"></asp:TextBox>
                                                </td>
                                                <td class="style39">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style12">
                                                    &nbsp;</td>
                                                <td class="style34">
                                                    &nbsp;</td>
                                                <td class="style42">
                                                    &nbsp;</td>
                                                <td class="style35" align="right" colspan="4">
                                                    &nbsp;</td>
                                                <td class="style39">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style12">
                                                    &nbsp;</td>
                                                <td class="style34">
                                                    <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Size="12px" 
                                                        ForeColor="White" Height="19px" 
                                                        style="text-align: left; font-size: 16px; font-family: 'Times New Roman', Times, serif;" 
                                                        Text="Remark:" Width="75px"></asp:Label>
                                                </td>
                                                <td class="style42">
                                                    <asp:TextBox ID="txtRemark" runat="server" BorderStyle="None" Font-Bold="True" 
                                                        onkeypress="checkKey()" style="text-align: left"  Width="108px"></asp:TextBox>
                                                </td>
                                                <td class="style35" align="left">
                                                    <asp:Label ID="Label22" runat="server" 
                                                        style="text-align: right; font-family: Verdana; font-size: 12px; color: #FFFFFF; font-weight: 700" 
                                                        Text="Campus:" Width="100px"></asp:Label>
                                                </td>
                                                <td class="style36">
                                                    <asp:DropDownList ID="ddlCampus" runat="server" Font-Bold="False" 
                                                        Font-Size="12px" Width="100px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="style47" >
                                                    &nbsp;</td>
                                                <td class="style37" align="right">
                                                    &nbsp;</td>
                                                <td class="style39">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style12">
                                                    &nbsp;</td>
                                                <td class="style34">
                                                    &nbsp;</td>
                                                <td class="style42" >
                                                    &nbsp;</td>
                                                <td class="style35" colspan="2">
                                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" 
                                                        style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td class="style47">
                                                    &nbsp;</td>
                                                <td class="style37">
                                                    &nbsp;</td>
                                                <td class="style39">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="style25" colspan="9">
                                    <asp:Panel ID="PanelItem" runat="server"  BorderStyle="None">
                                        <div align="center">
                                        <table bgcolor="#006699" width="690px">
                                            <tr>
                                                <td class="style50">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style20">
                                                    <asp:LinkButton ID="lnkbtnFind" runat="server" CssClass="button" 
                                                        onclick="lnkbtnFind_Click" Height="19px" Width="60px">Item List</asp:LinkButton>
                                                </td>
                                                <td class="style51">
                                                    <asp:TextBox ID="txtFind" runat="server" Width="108px" BorderStyle="None"></asp:TextBox>
                                                </td>
                                                <td colspan="3" align="left">
                                                    <asp:DropDownList ID="ddlItemList" runat="server" style="margin-left: 0px" 
                                                        Width="420px" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlItemList_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style48">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style50">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style20">
                                                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                                        ForeColor="White" Text="Tag ID:" 
                                                        style="font-family: 'Times New Roman', Times, serif"></asp:Label>
                                                </td>
                                                <td class="style51">
                                                    <asp:TextBox ID="txtTagID" runat="server" BorderStyle="None" Width="108px" 
                                                        style="text-align: left"></asp:TextBox>
                                                </td>
                                                <td class="style45">
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                                        Font-Size="16px" ForeColor="White" Text="Quantity:" 
                                                        style="font-family: 'Times New Roman', Times, serif"></asp:Label>
                                                </td>
                                                <td align="left" class="style49">
                                                    <asp:TextBox onkeypress="checkKey()" ID="txtQty" runat="server" 
                                                        BorderStyle="None" Width="80px" style="text-align: left"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style48">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style50">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblFinalMessage" runat="server" ForeColor="Red" 
                                                        style="font-weight: 700"></asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="right">
                                                    <asp:LinkButton ID="lnkbtnSubmitItem" runat="server" BorderStyle="Groove" 
                                                        CssClass="button" Height="20px" onclick="lnkbtnSubmitItem_Click" Width="100px">Add 
                                                    To Table</asp:LinkButton>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style48">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <div align="center">
                     <asp:GridView ID="gvIssue" runat="server" AutoGenerateColumns="False" 
                            CellPadding="3" Width="690px" Font-Size="12px" 
                                onrowcancelingedit="gvIssue_RowCancelingEdit"        
                                GridLines="Vertical" BackColor="White" BorderColor="#999999" 
                                BorderStyle="None" BorderWidth="1px" ShowFooter="True" 
                                onselectedindexchanged="gvIssue_SelectedIndexChanged">
                         <RowStyle BackColor="#00CC99" ForeColor="Black" />
                         <Columns>
                             <asp:TemplateField HeaderText="SL">
                                 <ItemTemplate>
                                     <asp:Label ID="Label10" runat="server" 
                                         Text='<%# Convert.ToString(Container.DataItemIndex+1)+"." %>' 
                                         Width="30px"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Item Code">
                                 <ItemTemplate>
                                     <asp:Label ID="Label11" runat="server" 
                                         Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "itemcode")) %>' 
                                         Width="80px" style="text-align: left"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Item Description ">
                                 <FooterTemplate>
                                     <asp:LinkButton ID="btnIssueUpdate" runat="server" Font-Bold="True" 
                                         Font-Size="12px" onclick="btnIssueUpdate_Click" Width="50px">Update</asp:LinkButton>
                                 </FooterTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label12" runat="server" 
                                         Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "itemdesc")) %>' 
                                         Width="300px" style="text-align: left"></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             
                             <asp:TemplateField HeaderText="Tag ID">
                                 <FooterTemplate>
                                     <asp:LinkButton ID="LinkFinalUpdate" runat="server" CssClass="button" 
                                         Height="20px" onclick="LinkFinalUpdate_Click">Final Update</asp:LinkButton>
                                 </FooterTemplate>
                                 <ItemTemplate>
                                     
                                     <asp:Label ID="Label19" runat="server" 
                                         Text='<%# Convert.ToString(DataBinder.Eval(Container.DataItem, "tagid")) %>' 
                                         Width="80px" style="text-align: left"></asp:Label>
                                     
                                 </ItemTemplate>
                             </asp:TemplateField>
                             
                             <asp:TemplateField HeaderText="Quantity">
                                 <FooterTemplate>
                                     <asp:Label ID="gvlblTotalQty" runat="server" Text="Label" Font-Bold="True" 
                                         Font-Size="12px" ForeColor="Blue" Width="50px" style="text-align: right"></asp:Label>
                                 </FooterTemplate>
                                 <ItemTemplate>
                                     <asp:TextBox ID="gvtxtQty" runat="server" BorderStyle="None" 
                                         style="text-align: right" 
                                         Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "qty")).ToString("#,##0.00;(#,##0.00); ") %>' 
                                         Width="50px" BackColor="Transparent"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             
                             
                             
                         </Columns>
                         <FooterStyle BackColor="#B5C7DE" ForeColor="Black" />
                         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                         <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="White" />
                         <AlternatingRowStyle BackColor="#DCDCDC" />
                     </asp:GridView> 
                     </div>
                        &nbsp;&nbsp; 
                    </ContentTemplate>
                </asp:UpdatePanel> 	
 </div>
 </div>
</asp:Content>

