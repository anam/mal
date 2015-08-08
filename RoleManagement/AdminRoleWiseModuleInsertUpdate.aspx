<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="AdminRoleWiseModuleInsertUpdate.aspx.cs" Inherits="RoleManagement_AdminRoleWiseModuleInsertUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box" style="overflow: hidden;">
        <div class="header">
            <h3>
                Module Rolewise
            </h3>
        </div>
        <div style="width: 25%; float: left; margin: 1% 1% 1% 8%;">
            <center>
                Available Modules</center>
            <asp:ListBox ID="lbxModules" runat="server" Width="180" Height="200" Style="padding: 5px;" SelectionMode="Multiple"></asp:ListBox>
        </div>
        <div style="width: 25%; float: left; margin: 1%;">
            <center>
                Roles<br />
                <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <br />
                <asp:Button ID="btnAddModule" runat="server" Text="Add Module To Role>>" CssClass="button button-blue" OnClick="btnAddModule_Click"/>
                <br />
                <br />
                <asp:Button ID="btnRemoveModule" runat="server" Text="<< Remove From Role" CssClass="button button-blue" OnClick="btnRemoveModule_Click"/>
            </center>
        </div>
        <div style="width: 30%; float: left; margin: 1%; padding: 20px 10;">
            <center>
                Assigned Modules</center>
            <asp:ListBox ID="lbxRoleWiseModules" runat="server" Width="200px" Height="200px">
            </asp:ListBox>
        </div>
    </div>
</asp:Content>
