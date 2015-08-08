<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminUSER_Menu.aspx.cs" Inherits="AdminUSER_Menu" Title="USER_Menu Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Menus</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>Module : </dt>
                <dd><asp:DropDownList ID="ddlModules" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlModules_SelectedIndexChanged"></asp:DropDownList></dd>
                <dt>
                    <asp:Label ID="lblPageID" runat="server" Text="Page: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlPageID" runat="server" Width="400">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblMenuTitle" runat="server" Text="Menu Title: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMenuTitle" class="txt" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>Parent Menu :</dt>
                <dd><asp:DropDownList ID="ddlParentMenu" runat="server"></asp:DropDownList></dd>
                <dt>
                    <asp:Label ID="lblRowStatusID" runat="server" Text="Row Status: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRowStatusID" runat="server">
                        <asp:ListItem Value="0" Text="...Row Status..."></asp:ListItem>
                        <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Deleted"></asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
</asp:Content>
