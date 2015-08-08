<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayACC_Journal.aspx.cs" Inherits="AdminDisplayACC_Journal"
    Title="List Of Existing Journal" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List Of Existing Journal</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvACC_Journal" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss">
                <Columns>
                    <asp:TemplateField HeaderText="Journal">
                        <ItemTemplate>
                            <asp:Label ID="lblJournalID" runat="server" Text='<%#Eval("JournalID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Head">
                        <ItemTemplate>
                            <asp:Label ID="lblHeadID" runat="server" Text='<%#Eval("HeadID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Debit">
                        <ItemTemplate>
                            <asp:Label ID="lblDebit" runat="server" Text='<%#Eval("Debit") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Credit">
                        <ItemTemplate>
                            <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Voucher">
                        <ItemTemplate>
                            <asp:Label ID="lblVoucherID" runat="server" Text='<%#Eval("VoucherID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Journal Voucher No">
                        <ItemTemplate>
                            <asp:Label ID="lblJournalVoucherNo" runat="server" Text='<%#Eval("JournalVoucherNo") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update Date">
                        <ItemTemplate>
                            <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("UpdateDate") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Row Status">
                        <ItemTemplate>
                            <asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("JournalID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("JournalID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
        </div>
    </div>
</asp:Content>
