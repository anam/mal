<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="BookIssue.aspx.cs" Inherits="BookIssue" Title="BookIssue " %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Book Issue</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblBookID" runat="server" Text="Book: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlBookID" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
                </dd>
                <dt>
                    <asp:Label ID="lblIsStudent" runat="server" Text="Is Student: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:RadioButtonList ID="radIsStudent" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="true" OnSelectedIndexChanged="radIsStudent_SelectedIndexChanged">
                        <asp:ListItem>True</asp:ListItem>
                        <asp:ListItem>False</asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
                <dt>
                    <asp:Label ID="lblIssedToID" runat="server" Text="Issue To: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlIssedToID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt style="display: none;">
                    <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date: ">
    </asp:Label>
                </dt>
                <dd style="display: none;">
                    <asp:TextBox ID="txtIssueDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt style="display: none;">
                    <asp:Label ID="lblReturnDate" runat="server" Text="Return Date: ">
    </asp:Label>
                </dt>
                <dd style="display: none;">
                    <asp:TextBox ID="txtReturnDate" class="txt large-input" runat="server" Text="">
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
    </div>
</asp:Content>
