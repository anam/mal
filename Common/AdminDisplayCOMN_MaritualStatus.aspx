<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayCOMN_MaritualStatus.aspx.cs" Inherits="AdminDisplayCOMN_MaritualStatus"
    Title="List of Existing Marital Status" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Marital Status</h3>
        </div>
        <div class="inner-content">
            <div>
                <asp:Button ID="btnAddMaritalStatus" runat="server" class="button button-blue" Text="Add Marital Status"
                    OnClick="btnAddMaritalStatus_OnClick" />
            </div>
            <asp:GridView ID="gvCOMN_MaritualStatus" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <%--<asp:TemplateField HeaderText="Marital Status">
                        <ItemTemplate>
                            <asp:Label ID="lblMaritualStatusID" runat="server" Text='<%#Eval("MaritualStatusID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Marital Status Name">
                        <ItemTemplate>
                            <asp:Label ID="lblMaritualStatusName" runat="server" Text='<%#Eval("MaritualStatusName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit /Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("MaritualStatusID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                CommandArgument='<%#Eval("MaritualStatusID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
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
