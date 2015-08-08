<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminLIB_Publisher.aspx.cs" Inherits="AdminLIB_Publisher" Title="Publisher" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Publisher</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblAddress" runat="server" Text="Address: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAddress" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPublisherName" runat="server" Text="Publisher Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPublisherName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblEmail" runat="server" Text="Email: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEmail" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblPhone" runat="server" Text="Phone: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPhone" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblMobile" runat="server" Text="Mobile: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMobile" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblCountry" runat="server" Text="Country: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtCountry" class="txt large-input" runat="server" Text="">
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
