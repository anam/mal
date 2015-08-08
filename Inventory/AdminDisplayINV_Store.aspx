<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayINV_Store.aspx.cs" Inherits="AdminDisplayINV_Store" Title="List of Existing Store" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Store</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvINV_Store" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <%--<asp:TemplateField HeaderText="Store ID">
                        <ItemTemplate>
                            <asp:Label ID="lblStoreID" runat="server" Text='<%#Eval("StoreID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Store Name">
                        <ItemTemplate>
                            <asp:Label ID="lblStoreName" runat="server" Text='<%#Eval("StoreName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Campus Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCampusID" runat="server" Text='<%#Eval("CampusName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Updated By">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUpdatedBy" runat="server" Text='<%#Eval("UpdatedBy") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Updated Date">
                        <ItemTemplate>
                            <asp:Label ID="lblUpdatedDate" runat="server" Text='<%#Eval("UpdatedDate","{0:dd-MMM-yyyy}") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit /Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("StoreID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("StoreID") %>'
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
