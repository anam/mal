<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayACC_Check.aspx.cs" Inherits="AdminDisplayACC_Check" Title="Check Processing" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Search Check</h3>
        </div>
        <div class="inner-content" style="width: 98%">
            <table>
                <tr>
                    <td>
                         Check in Hand:
                    </td>
                    <td>
                        <asp:TextBox ID="txtWhomUser" runat="server" CssClass="txt medium-input" Width="75%"></asp:TextBox>
                        <asp:CheckBox ID="chkEmployee" runat="server" Text="Employee?" Checked="true"/>
                    </td>
                    <td>
                        Who gave the check:
                    </td>
                    <td>
                        <asp:TextBox ID="txtWhoUser" runat="server" CssClass="txt medium-input" Width="75%"></asp:TextBox>
                        <asp:CheckBox ID="chkStudent" runat="server" Text="Student?" Checked="true"/>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        Check No:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCheckNo" runat="server" CssClass="txt medium-input" Width="75%"></asp:TextBox>
                    </td>
                    <td>
                        Bank:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBank" runat="server" CssClass="txt medium-input" Width="75%">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlDefaultCUCBank" runat="server" Visible="false">
                            </asp:DropDownList>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        Status:
                    </td>
                    <td colspan='3'>
                        <asp:DropDownList ID="ddlCheckStatus" runat="server">
                            <asp:ListItem Value="1">Unpaid</asp:ListItem>
                            <asp:ListItem Value="8">Bounched</asp:ListItem>
                            <asp:ListItem Value="9">Transaction Completed</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        Check Date:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCheckDate" runat="server" CssClass="txt medium-input" Width="75%"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal" runat="server" TargetControlID="txtCheckDate">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                    <td>
                        Status:
                    </td>
                    <td >
                        <asp:DropDownList ID="ddlCheckStatus" runat="server">
                            <asp:ListItem Value="1">Unpaid</asp:ListItem>
                            <asp:ListItem Value="8">Bounched</asp:ListItem>
                            <asp:ListItem Value="9">Transaction Completed</asp:ListItem>
                            <asp:ListItem Value="11">Processed after Bounched</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="padding-left: 200px">
                        <asp:Button ID="btnSeach" runat="server" class="button button-blue" Text="Search"
                            OnClick="btnSeach_OnClick" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                Check Processing</h3>
        </div>
        <div class="inner-content">
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Size="20px"></asp:Label>
            <asp:GridView ID="gvACC_Check" class="gridCss" runat="server" AutoGenerateColumns="false"  OnRowDataBound="gvACC_Check_OnRowDataBound"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Check" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblCheckID" runat="server" Text='<%#Eval("CheckID") %>'>                                
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Check No">
                        <ItemTemplate>
                        <asp:HiddenField ID="hfExtraField1" runat="server" Value='<%#Eval("ExtraField1") %>'/>
                            Check # :
                            <asp:Label ID="lblCheckNo"  runat="server" Text='<%#Eval("CheckNo") %>'></asp:Label>
                            <br />
                            Account # :
                            <asp:Label ID="lblBankAccountNo" runat="server" Text='<%#Eval("BankAccountNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bank">
                        <ItemTemplate>
                            Bank :
                            <asp:Label ID="lblBankID" runat="server" Text='<%#Eval("AccountingUserName") %>'></asp:Label>
                            <br />
                            Branch:<asp:Label ID="lblBranchNOtherDetails" runat="server" Text='<%#Eval("BranchNOtherDetails") %>'></asp:Label>
                            <br />
                            Amount:<asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bank">
                        <ItemTemplate>
                            <b>Check in Hand:</b><br /><%#Eval("WhomeGiven")%>
                            <br />
                            <b>Who gave:</b><br /><%#Eval("WhoGave")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Checked Date">
                        <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Text="Cash Check?" Checked='<%#Eval("IsCashCheck") %>' />
                            <asp:HiddenField ID="hfCheckID" runat="server" Value='<%#Eval("CheckID") %>' />
                            <asp:HiddenField ID="hfCheckOfCUCBankID" runat="server" Value='<%#Eval("ExtraField1") %>' />
                            <asp:HiddenField ID="hfToWhomItIsGivenHeadID" runat="server" Value='<%#Eval("ExtraField2") %>' />
                            <asp:HiddenField ID="hfToWhomItIsGivenJournalID" runat="server" Value='<%#Eval("ExtraField3") %>' />
                            <asp:HiddenField ID="hfWhoGivesHeadID" runat="server" Value='<%#Eval("ExtraField4") %>' />
                            <br />
                            <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("ExtraField5") %>'>
 	                            </asp:Label>
                                <br /><asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusName") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <%--<asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("CheckID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("CheckID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                            <br />--%>
                            <asp:DropDownList ID="ddlCUCBank" runat="server" Width="152px">
                            </asp:DropDownList>
                            <asp:HyperLink ID="hlinkProcess" runat="server" Visible='<%#Eval("IsVisibleProcess") %>'>Process</asp:HyperLink>
                            <asp:Button ID="btnTransactionCompleted" class="button button-blue" runat="server" Visible='<%#Eval("IsVisibleTransaction") %>'
                                Text="Transaction Completed" CommandArgument='<%#Eval("CheckID") %>' OnClick="btnTransactionCompleted_Click" />
                            <br />
                            <asp:Button ID="btnBounch" class="button button-blue" runat="server" Text="Bounch"  Visible='<%#Eval("IsVisibleBounch") %>'
                                CommandArgument='<%#Eval("CheckID") %>' OnClick="btnBounch_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Panel ID="pnPaging" runat='server'>
                <div class="paging">
                    <div class="viewpageinfo">
                        <%--View 1 -10 of 13--%>
                        Show
                    </div>
                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="25" Value="25" />
                        <asp:ListItem Text="50" Value="50" />
                    </asp:DropDownList>
                    <div class="pagelist">
                        <asp:Repeater ID="rptPager" runat="server">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                    Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
