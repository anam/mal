<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminACC_Journal.aspx.cs" Inherits="AdminACC_Journal" Title="Add/Update Journal" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Add/Update Journal</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblHeadID" runat="server" Text="Head: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlHeadID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblDebit" runat="server" Text="Debit: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDebit" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblCredit" runat="server" Text="Credit: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtCredit" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblVoucherID" runat="server" Text="Voucher: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlVoucherID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblJournalVoucherNo" runat="server" Text="Journal Voucher No: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtJournalVoucherNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
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
