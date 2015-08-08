<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_Bank.aspx.cs" Inherits="AdminHR_Bank" Title="HR_Bank Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateHR_Bank</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblEmployeeID" runat="server" Text="Employee: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlEmployeeID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblBankAccountName" runat="server" Text="Bank Account Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBankAccountName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblBankName" runat="server" Text="Bank Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBankName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblBankAddress" runat="server" Text="Bank Address: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBankAddress" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblBankTelephone" runat="server" Text="Bank Telephone: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBankTelephone" class="txt large-input" runat="server" Text="">
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
