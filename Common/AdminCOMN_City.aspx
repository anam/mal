<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminCOMN_City.aspx.cs" Inherits="AdminCOMN_City" Title="City" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                City</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblCityName" runat="server" Text="City Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtCityName" class="txt large-input" runat="server" Text="">
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
                    <asp:Label ID="lblCountryID" runat="server" Text="Country: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCountryID" runat="server">
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
