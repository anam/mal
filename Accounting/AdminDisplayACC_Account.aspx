<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayACC_Account.aspx.cs" Inherits="AdminDisplayACC_Account"
    Title="List Of Existing Accounts" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="upAccount" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        List Of Existing Accounts</h3>
                    <div style="width: 65%; float: right; height: 30px">
                        <span style="color: White; font-weight: bold">Basic Account: </span>
                        <asp:DropDownList ID="ddlBasicAccount" runat="server" Width="130px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlBasicAccount_OnSelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp <span style="color: White; font-weight: bold">Sub-Basic Account:
                        </span>
                        <asp:DropDownList ID="ddlSubBasicAccount" runat="server" Width="130px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlSubBasicAccount_OnSelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="inner-content">
                    <asp:GridView ID="gvACC_Account" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Account Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblAccountName" runat="server" Text='<%#Eval("AccountName") %>'>
 	                        </asp:Label>
                                    <asp:Label ID="lblAccountID" runat="server" Text='<%#Eval("AccountID") %>' Visible="false">
 	                            </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Basic Account">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubBasicAccountID" runat="server" Text='<%#Eval("SubBasicAccountName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("AccountID") %>'
                                        AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <%--<asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%#Eval("AccountID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Panel ID="pnPaging" runat="server">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
