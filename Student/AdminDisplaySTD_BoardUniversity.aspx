<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplaySTD_BoardUniversity.aspx.cs" Inherits="AdminDisplaySTD_BoardUniversity"
    Title="List of Existing Board/University" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Board/University</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvSTD_BoardUniversity" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    
                    <asp:TemplateField HeaderText="Board University Name">
                        <ItemTemplate>
                            <asp:Label ID="lblBoardUniversityName" runat="server" Text='<%#Eval("BoardUniversityName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit /Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("BoardUniversityID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("BoardUniversityID") %>'
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
    </div>
</asp:Content>
