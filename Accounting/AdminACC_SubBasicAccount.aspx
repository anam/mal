<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminACC_SubBasicAccount.aspx.cs" Inherits="AdminACC_SubBasicAccount"
    Title="Add/Update Sub Basic Account" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
               Add/Update Sub Basic Account</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                
                <dt>
                    <asp:Label ID="lblSubBasicAccountName" runat="server" Text="Sub Basic Account Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSubBasicAccountName" class="txt large-input" runat="server" Text="">
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
                    <asp:DropDownList ID="ddlBasicAccountID" runat="server">
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
