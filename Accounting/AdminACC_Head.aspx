<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminACC_Head.aspx.cs" Inherits="AdminACC_Head" Title="Add/Update Account Head" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
               Add/Update Account Head</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblHeadName" runat="server" Text="Head Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtHeadName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblHeadCode" runat="server" Text="Head Code: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtHeadCode" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblAccountID" runat="server" Text="Account: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlAccountID" runat="server">
                    </asp:DropDownList>
                </dd>
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
