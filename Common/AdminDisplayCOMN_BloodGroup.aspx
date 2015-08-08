<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayCOMN_BloodGroup.aspx.cs" Inherits="AdminDisplayCOMN_BloodGroup"
    Title="List of Existing Blood Group" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Blood Group</h3>
        </div>
        <div class="inner-content">
            <div>
                <asp:Button ID="btnAddBloodGroup" runat="server" class="button button-blue" Text="Add Blood Group"
                    OnClick="btnAddBloodGroup_OnClick" />
            </div>
            <div>
                <asp:GridView ID="gvCOMN_BloodGroup" class="gridCss" runat="server" AutoGenerateColumns="false"
                    CssClass="tabel_input">
                    <HeaderStyle CssClass="heading" />
                    <RowStyle CssClass="row" />
                    <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                        <%--<asp:TemplateField HeaderText="Blood Group">
                        <ItemTemplate>
                            <asp:Label ID="lblBloodGroupID" runat="server" Text='<%#Eval("BloodGroupID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Blood Group Name">
                            <ItemTemplate>
                                <asp:Label ID="lblBloodGroupName" runat="server" Text='<%#Eval("BloodGroupName") %>'>
 	 </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit /Delete">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("BloodGroupID") %>'
                                    AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                    CommandArgument='<%#Eval("BloodGroupID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
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
