<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminACC_Account.aspx.cs" Inherits="AdminACC_Account" Title="Add/Update Account" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
        
    <div class="content-box">
        <div class="header">
            <h3>
                Add/Update Account</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblAccountName" runat="server" Text="Account Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAccountName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblDescription" runat="server" Text="Description: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" class="txt textarea" runat="server"
                        Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblBasicAccountID" runat="server" Text="Basic Account: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlBasicAccountID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBasicAccountID_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubBasicAccountID" runat="server" Text="Sub Basic Account: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubBasicAccountID" runat="server">
                    </asp:DropDownList>
                </dd>
                <%--<dt>
                    <asp:Label ID="lblAccountCode" runat="server" Text="Account Code: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAccountCode" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblRowStatusID" runat="server" Text="Row Status: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRowStatusID" runat="server">
                    </asp:DropDownList>
                </dd>--%>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
