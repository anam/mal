<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminUSER_Roles.aspx.cs" Inherits="AdminUSER_Roles" Title="USER_Roles Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Roles</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblRowStatusID" runat="server" Text="Row Status: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRowStatusID" runat="server">
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
