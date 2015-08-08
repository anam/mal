<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true" CodeFile="InvItemReceve.aspx.cs" Inherits="InvItemReceve" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/JavaScript">
     function checkKey() {
         if ((window.event.keyCode < 48 || window.event.keyCode > 57) && window.event.keyCode != 46) {

             alert("You hit Non-numeric :" + String.fromCharCode(window.event.keyCode));
             window.event.returnValue = false;
         }
     }
        
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="content-box">
<div class="header">
<h3>Material Reseve</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
 <div>
                <asp:Panel ID="Panel1" runat="server"  Width="100%">
                <div align="center">
                <table bgcolor="#006699" width="620px">
                <tr>
             
             <td class="style55">
                 &nbsp;</td>
             <td align="right" class="style40">
                 <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="16px" 
                     ForeColor="White" 
                     style="font-weight: 700; font-family: Verdana; font-size: 12px; text-align: right;" 
                     Text="MRR Date:" Width="80px"></asp:Label>
             </td>
             <td class="style42">
                 <asp:TextBox ID="txtMRRDate" runat="server" BorderStyle="None" 
                     CausesValidation="false" ReadOnly="false" style="font-size: 12px" 
                     Width="100px"></asp:TextBox>
                 <asp:CalendarExtender ID="txtMRRDate_CalendarExtender" runat="server" 
                     Enabled="True" TargetControlID="txtMRRDate">
                 </asp:CalendarExtender>
             </td>
             <td>
                 <asp:DropDownList ID="ddlStoreID" runat="server" Font-Bold="False" 
                     Font-Size="12px" Width="120px">                  
                 </asp:DropDownList>
             </td>
             <td>
                 <asp:Label ID="Label3" runat="server" ForeColor="White" 
                     style="font-family: Verdana; font-weight: 700; font-size: 12px; text-align: right;" 
                     Text=" MRR No:" Width="80px"></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="txtMRRNo" runat="server" BorderStyle="None" ReadOnly="True" 
                     style="font-size: 12px" Width="100px"></asp:TextBox>
             </td>
             <td class="style22">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td class="style52">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
                    
                    <tr>
                        <td class="style47">
                            &nbsp;</td>
                        <td align="right" class="style51">
                            <asp:LinkButton ID="lbtnItem" runat="server" onclick="lbtnItem_Click" 
                                style="color: #FFFFFF; font-weight: 700; text-align: right" Width="80px">Item 
                            List</asp:LinkButton>
                        </td>
                        <td>
                            <asp:TextBox ID="txtItemSearch" runat="server" BorderStyle="None" Width="100px"></asp:TextBox>
                        </td>
                        <td align="right" class="style24" colspan="4">
                            <asp:DropDownList ID="ddlItemDesc" runat="server" Font-Bold="False" 
                                Font-Size="16px" style="font-size: 12px" Width="400px" AutoPostBack="True" 
                                onselectedindexchanged="ddlItemDesc_SelectedIndexChanged">
                            </asp:DropDownList>
                           
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style47">
                            &nbsp;</td>
                        <td class="style51">
                            <asp:Label ID="Label9" runat="server" ForeColor="White" 
                                style="font-weight: 700; text-align: right; font-family: Verdana; font-size: 12px" 
                                Text="TAG No:" Width="100px"></asp:Label>
                        </td>
                        <td class="style42">
                            <asp:TextBox ID="txtTag" runat="server" BorderStyle="None" 
                                style="font-size: 12px" Width="100px"></asp:TextBox>
                        </td>
                        <td class="style24">
                            <asp:Label ID="Label4" runat="server" ForeColor="White" 
                                style="font-family: Verdana; font-size: 12px; font-weight: 700; text-align: right;" 
                                Text="Quantity:" Width="80px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox onkeypress="checkKey()"  ID="txtQty" runat="server" BorderStyle="None" 
                                style="font-family: Verdana; font-size: 12px; border-style: None" 
                                Width="100px"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblUnit" runat="server" ForeColor="White" 
                                style="font-weight: 700; font-family: Verdana; font-size: 12px" Text="Unit" 
                                Width="80px"></asp:Label>
                        </td>
                        <td class="style22">
                            <asp:Label ID="Label18" runat="server" Width="100px"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style47">
                            &nbsp;</td>
                        <td class="style51">
                            <asp:Label ID="Label7" runat="server" 
                                style="text-align: right; font-family: Verdana; font-size: 12px; color: #FFFFFF; font-weight: 700" 
                                Text="MRR Rate:" Width="100px"></asp:Label>
                        </td>
                        <td class="style42">
                            <asp:TextBox onkeypress="checkKey()" ID="txtMRRRate" runat="server" BorderStyle="None" 
                                style="font-family: Verdana; font-size: 12px; border-style: None" Width="100px"></asp:TextBox>
                        </td>
                        <td class="style32">
                            <asp:Label ID="Label10" runat="server" ForeColor="White" 
                                style="text-align: right; font-weight: 700" Text="Sales Rate:" 
                                Width="80px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox onkeypress="checkKey()" ID="txtSalesRate" runat="server" BorderStyle="None" 
                                style="font-size: 12px" Width="100px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkBtnAdd" runat="server" CssClass="button" 
                                Font-Size="12px" onclick="lnkBtnAdd_Click" Width="100px">Add To Table</asp:LinkButton>
                        </td>
                        <td class="style34">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style31">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style47">
                            &nbsp;</td>
                        <td class="style51">
                            <asp:Label ID="Label19" runat="server" 
                                style="text-align: right; font-family: Verdana; font-size: 12px; color: #FFFFFF; font-weight: 700" 
                                Text="Campus:" Width="100px"></asp:Label>
                        </td>
                        <td class="style42">
                            <asp:DropDownList ID="ddlCampus" runat="server" Font-Bold="False" 
                                Font-Size="12px" Width="100px">
                            </asp:DropDownList>
                        </td>
                        <td class="style32" colspan="3">
                            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="14px" 
                                ForeColor="#FF0066"></asp:Label>
                        </td>
                        <td class="style34">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td class="style31">
                            &nbsp;</td>
                    </tr>
                </table>
                </div>
       </asp:Panel>
   <div align="center">
                <asp:GridView ID="gvReceive" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" Font-Names="Verdana" Font-Size="12px" 
                onpageindexchanging="gvReceive_PageIndexChanging" 
                    onrowdatabound="gvReceive_RowDataBound" ShowFooter="True" Width="50px">
                <PagerSettings PageButtonCount="15" />
                    <RowStyle BackColor="#00CC99" />
                    <Columns>
                    <asp:TemplateField HeaderText="Sl.">
                        <ItemTemplate>
                            <asp:Label ID="lblgvTrSlNo" runat="server" Font-Bold="False" Font-Size="10px" 
                                style="text-align: right" 
                                Text='<%# Convert.ToString(Container.DataItemIndex + 1).Trim() + "." %>' 
                                Width="20px"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="Item Code" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveItemCode" runat="server" Font-Size="10px" 
                                    Text='<%# DataBinder.Eval(Container.DataItem, "sircode").ToString() %>'
                                    Width="80px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Description">
                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveItemDesc" runat="server" Font-Size="10px" 
                                    Text='<%# DataBinder.Eval(Container.DataItem, "sirdesc1").ToString() %>'
                                    Width="330px" style="text-align: left"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit">
                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveUnit" runat="server" Font-Size="10px" 
                                    Text='<%# DataBinder.Eval(Container.DataItem, "sirunit").ToString() %>'
                                    Width="40px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TAG No.">
                            <FooterTemplate>
                                <asp:LinkButton ID="LbtngvReceiveTrCalTotal" runat="server" Font-Bold="True" 
                                    Font-Names="Verdana" Font-Size="11px" OnClick="LbtngvReceiveCalTotal_Click" 
                                    Style="font-size: 11px; text-align: right; height: 13px;" Width="100px">Total Amount :</asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgvReceiveTagNo" runat="server" Font-Size="10px"
                                    style="background-color:Transparent; border-top-style:none; border-bottom-style:none; border-left-style:none; border-right-style:none; text-align:left;"                                
                                    Text='<%# DataBinder.Eval(Container.DataItem, "tagid").ToString() %>' 
                                    Width="80px" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty">
                            <ItemTemplate>
                                <asp:TextBox ID="txtgvReceiveQty" runat="server" Font-Size="10px"
                                    style="background-color:Transparent; border-top-style:none; border-bottom-style:none; border-left-style:none; border-right-style:none; text-align:right;"                                
                                    Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "mrrqty")).ToString("#,##0.00;(#,##0.00); ") %>' 
                                    Width="35px" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                                   
                        <asp:TemplateField HeaderText="MRR Rate">
                            <ItemTemplate>
                                <asp:TextBox ID="txtgvReceiveMRRRate" runat="server" Font-Size="10px"
                                    style="background-color:Transparent; border-top-style:none; border-bottom-style:none; border-left-style:none; border-right-style:none; text-align:right;"
                                    Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem,"mrrrat")).ToString("#,##0.00;(#,##0.00); ") %>' 
                                    Width="80px" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MRR Amt">
                            <FooterTemplate>
                                <asp:Label ID="lblgvReceiveMRRTotalAmt" runat="server" Font-Bold="True" Font-Size="11px" 
                                    style="text-align: right" Width="80px"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveMRRAmt" runat="server" Font-Size="10px" 
                                style="text-align: right"
                                    Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "mrramt")).ToString("#,##0.00;(#,##0.00); ") %>'
                                    Width="80px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sales Rate">
                            <FooterTemplate>
                                <asp:LinkButton ID="lnkbtnFinal" runat="server" CssClass="button" 
                                    Font-Underline="False" onclick="lnkbtnFinal_Click" Width="82px">Final Update</asp:LinkButton>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtgvReceiveSalesRate" runat="server" Font-Size="10px"
                                style="background-color:Transparent; border-top-style:none; border-bottom-style:none; border-left-style:none; border-right-style:none; text-align:right;"
                                    Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "salrat")).ToString("#,##0.00;(#,##0.00); ") %>' 
                                    Width="80px" BorderStyle="None"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sales Amt">
                            <FooterTemplate>
                                <asp:Label ID="lblgvReceiveSalesTotalAmt" runat="server" Font-Bold="True" Font-Size="10px" 
                                    style="text-align: right" Width="80px"></asp:Label>
                            </FooterTemplate>

                            <ItemTemplate>
                                <asp:Label ID="lblgvReceiveSalesAmt" runat="server" Font-Size="10px" 
                                    Text='<%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "salamt")).ToString("#,##0.00;(#,##0.00); ") %>'
                                    style="text-align: right" Width="80px"></asp:Label>
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
 </div>
</asp:Content>

