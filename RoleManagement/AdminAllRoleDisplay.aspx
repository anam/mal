<%@ Page Title="Role Management" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="AdminAllRoleDisplay.aspx.cs" Inherits="RoleManagement_AdminAllRoleDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box" style="overflow: hidden;">
        <div class="header">
            <h3>
                User Roles</h3>
        </div>
        <asp:UpdatePanel ID="upMain" runat="server">
            <ContentTemplate>
                <div style="width: 25%; padding-left: 3%; float: left; margin:0;">
                    <center>
                        <asp:Label ID="lblRoleName" runat="server" Text="New Role" AssociatedControlID="txtRoleName" AccessKey="r"></asp:Label>
                        <asp:TextBox ID="txtRoleName" runat="server" Width="150px"></asp:TextBox>
                        <span style="clear:both;float:left; height:5px;width:100%;">&nbsp;</span>
                        <asp:Button ID="btnInsertRole" runat="server" Text="Insert Role" OnClick="btnInsertRole_Click"
                            CssClass="button button-blue" />
                        <br />
                        <asp:Label ID="lblRoleInfoText" runat="server"></asp:Label>
                        <h2>
                            All Roles
                        </h2>
                        <asp:ListBox ID="lbxAvailableRoles" runat="server" Width="100%" Height="300px"></asp:ListBox>
                        <br />
                        <br />
                        <asp:Label ID="lblResults" runat="server"></asp:Label>
                        <asp:Button ID="btnDeleteRole" runat="server" Text="Delete Role" CssClass="button button-green"
                            OnClick="btnDeleteRole_Click" />
                    </center>
                </div>
                <div style="width: 65%; float: left; padding: 20px 10;">
                    <table width="100%" align="left" style="text-align: left;">
                        <tr>
                            <td>
                            </td>
                            <td style="width: 200px;" align="right">
                                <asp:Label ID="lbluserId" runat="server" Text="User Name" AssociatedControlID="ddlUsername" AccessKey="u"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlUsername" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUsername_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="Assigned Roles"></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle">
                                <center>
                                    <asp:Button ID="btnAddUser" runat="server" Text="Add Role to user" OnClick="btnAddUser_Click"
                                        CssClass="button button-blue" />
                                </center>
                            </td>
                            <td>
                                <br />
                                <asp:ListBox ID="lbxUserRoles" runat="server" Width="200px" Height="300px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblUserRoleInfoText" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr style="padding-top: 20px;">
                            <td>
                            </td>
                            <td>
                                <br />
                                <asp:Button ID="btnDeleteUserFromRole" runat="server" Text="Remove User from Selected Role"
                                    OnClick="btnDeleteUserFromRole_Click" CssClass="button button-green" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
