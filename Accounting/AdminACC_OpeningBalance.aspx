<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminACC_OpeningBalance.aspx.cs" Inherits="AdminACC_OpeningBalance"
    Title="dd/Update Opening Balance" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
              Add/Update Opening Balance</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblOpeningBalanceName" runat="server" Text="Opening Balance Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtOpeningBalanceName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblAmount" runat="server" Text="Amount: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAmount" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIsUsed" runat="server" Text="Is Used: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:RadioButtonList ID="radIsUsed" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>True</asp:ListItem>
                        <asp:ListItem>False</asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
                <dt>
                    <asp:Label ID="lblHeadID" runat="server" Text="Head: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlHeadID" runat="server">
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
