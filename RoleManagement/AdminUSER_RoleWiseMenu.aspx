<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminUSER_RoleWiseMenu.aspx.cs" Inherits="AdminUSER_RoleWiseMenu" Title="USER_RoleWiseMenu Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box" style="overflow:hidden;">
        <div class="header">
            <h3>
                RoleWise Menu Access</h3>
        </div>
        <div style="width: 25%; float: left; margin: 1%;">
            <center>
                Assigned Modules</center>
            <asp:ListBox ID="lbxModules" runat="server" Visible="false" Width="180" Height="200" Style="padding: 5px;"
                AutoPostBack="true" OnSelectedIndexChanged="lbxModules_SelectedIndexChanged">
            </asp:ListBox>
        </div>
        <div style="width: 70%; float: left; margin: 1%;">
            <dl>
                <dt>
                    <asp:Label ID="lblRoleID" runat="server" Text="Role: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRoleID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoleID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
            </dl>
            <%--<asp:UpdatePanel ID="upPageAccess" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlRoleID" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="lbxModules" EventName="SelectedIndexChanged" />
                    <asp:PostBackTrigger ControlID="btnSubmit" />
                </Triggers>
                <ContentTemplate>--%>
                    <asp:GridView ID="gvMenuAccess" runat="server" CssClass="tabel_input" AutoGenerateColumns="false"
                        Width="60%" GridLines="None" ondatabound="gvMenuAccess_DataBound">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <center>
                                        <asp:CheckBox ID="cbIsAssigned" runat="server" />
                                        <asp:HiddenField ID="hfMenuID" runat="server" Value='<%#Eval("MenuID") %>' />
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Menu Name" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="65%">
                                <ItemTemplate>
                                    <asp:Label ID="lblMenuTitle" runat="server" Text='<%#Eval("MenuTitle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <center>
                        <asp:Button ID="btnSubmit" class="button button-blue" Visible="false" runat="server" Text="Submit"
                            OnClick="btnSubmit_Click" /></center>
               <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
</asp:Content>
