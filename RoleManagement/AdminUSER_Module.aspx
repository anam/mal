<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminUSER_Module.aspx.cs" Inherits="AdminUSER_Module" Title="USER_Module Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Modules</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblModuleName" runat="server" Text="Module Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtModuleName" class="txt" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>Default URL :</dt>
                <dd><asp:TextBox ID="txtDefaultURL" class="txt large-input" runat="server"></asp:TextBox></dd>
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
