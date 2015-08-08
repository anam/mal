<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayACC_Head.aspx.cs" Inherits="AdminDisplayACC_Head" Title="List Of Existing  Account Head" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List Of Existing  Account Head</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvACC_Head" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    
                    <asp:TemplateField HeaderText="Head Name">
                        <ItemTemplate>
                            <asp:Label ID="lblHeadName" runat="server" Text='<%#Eval("HeadName") %>'>
 	                        </asp:Label>
                            <asp:Label ID="lblHeadID" runat="server" Text='<%#Eval("HeadID") %>' Visible="false">
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Head Code">
                        <ItemTemplate>
                            <asp:Label ID="lblHeadCode" runat="server" Text='<%#Eval("HeadCode") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account">
                        <ItemTemplate>
                            <asp:Label ID="lblAccountID" runat="server" Text='<%#Eval("AccountName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Row Status">
                        <ItemTemplate>
                            <asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("HeadID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("HeadID") %>'
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
