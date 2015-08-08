<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminACC_VoucherIteam.aspx.cs" Inherits="AdminACC_VoucherIteam" Title="Add/Update Account Voucher Item" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
               Add/Update Account Voucher Item</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblVoucherIteamName" runat="server" Text="Voucher Item Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtVoucherIteamName" class="txt large-input" runat="server" Text="">
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
                    <asp:Label ID="lblIteamCode" runat="server" Text="Item Code: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtIteamCode" class="txt large-input" runat="server" Text="">
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
                    <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtUnitPrice" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtQuantity" class="txt large-input" runat="server" Text="">
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
