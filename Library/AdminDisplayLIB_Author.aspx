<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayLIB_Author.aspx.cs" Inherits="AdminDisplayLIB_Author" Title="List of Existing Author" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Author</h3>
        </div>
        <div class="inner-content" style="overflow: scroll;">
            <asp:GridView ID="gvLIB_Author" class="gridCss" runat="server" AutoGenerateColumns="false"
                 CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <%--<asp:TemplateField HeaderText="Author">
                        <ItemTemplate>
                            <asp:Label ID="lblAuthorID" runat="server" Text='<%#Eval("AuthorID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Author Name">
                        <ItemTemplate>
                            <asp:Label ID="lblAuthorName" runat="server" Text='<%#Eval("AuthorName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone">
                        <ItemTemplate>
                            <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile">
                        <ItemTemplate>
                            <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Country">
                        <ItemTemplate>
                            <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("Country") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit /Delete" HeaderStyle-Width="12%">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("AuthorID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("AuthorID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
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
    </div>
</asp:Content>
