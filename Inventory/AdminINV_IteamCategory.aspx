<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminINV_IteamCategory.aspx.cs" Inherits="AdminINV_IteamCategory" Title="Item Category" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Item_Category</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblIteamCategoryName" runat="server" Text="Item Category Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtIteamCategoryName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
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
