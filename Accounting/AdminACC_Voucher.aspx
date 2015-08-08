<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminACC_Voucher.aspx.cs" Inherits="AdminACC_Voucher" Title="Add/Update Account Voucher" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
               Add/Update Account Voucher</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblVoucherNo" runat="server" Text="Voucher No: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtVoucherNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
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
                    <asp:Label ID="lblDebitOrCredit" runat="server" Text="Debit Or Credit: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDebitOrCredit" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblFromTo" runat="server" Text="From To: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtFromTo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblOnAccountOf" runat="server" Text="On Account Of: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtOnAccountOf" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblInWord" runat="server" Text="In Word: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtInWord" TextMode="MultiLine" class="txt textarea" runat="server"
                        Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIsApproved" runat="server" Text="Is Approved: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:RadioButtonList ID="radIsApproved" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>True</asp:ListItem>
                        <asp:ListItem>False</asp:ListItem>
                    </asp:RadioButtonList>
                </dd>
                <dt>
                    <asp:Label ID="lblApprovalDate" runat="server" Text="Approval Date: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtApprovalDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblVoucherDate" runat="server" Text="Voucher Date: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtVoucherDate" class="txt large-input" runat="server" Text="">
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
                <dt>
                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" class="txt textarea" runat="server"
                        Text="">
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
