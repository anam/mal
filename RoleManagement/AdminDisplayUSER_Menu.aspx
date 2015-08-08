<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayUSER_Menu.aspx.cs" Inherits="AdminDisplayUSER_Menu" Title="USER_Menu Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Menu</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt><label>Module :</label></dt>
                <dd><asp:DropDownList ID="ddlModules" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlModules_SelectedIndexChanged"></asp:DropDownList></dd>
            </dl>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvUSER_Menu" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input" OnRowDataBound="gvUSER_Menu_RowDataBound">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <%--<asp:TemplateField HeaderText="Menu">
                        <ItemTemplate>
                            <asp:Label ID="lblMenuID" runat="server" Text='<%#Eval("MenuID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <%--<asp:TemplateField HeaderText="Page">
                        <ItemTemplate>
                            <asp:Label ID="lblPageID" runat="server" Text='<%#Eval("PageID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Menu Title">
                        <ItemTemplate>
                            <asp:Label ID="lblMenuTitle" runat="server" Text='<%#Eval("MenuTitle") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Upper Menu">
                        <ItemTemplate>
                            <asp:Label ID="lblParentMenuTitle" runat="server" Text='<%#Eval("ParentMenuID") %>'>
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
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("MenuID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("MenuID") %>'
                                OnClick="lbDelete_Click" OnClientClick="return confirm('Are you sure to delete?');" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:PlaceHolder ID="phPaging" runat="server">
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
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
