<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_ProvidentFundSetup.aspx.cs" Inherits="AdminHR_ProvidentFundSetup"
    Title="Add Provident Fund Service Length Setup By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Add Provident Fund Service Length Setup</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblServiceLenStartYear" runat="server" Text="Service Len Start Year: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtServiceLenStartYear" class="txt medium-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblServiceLenEndYear" runat="server" Text="Service Len End Year: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtServiceLenEndYear" class="txt medium-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblFundTypeID" runat="server" Text="Fund Type: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlFundTypeID" runat="server">
                    <asp:ListItem Value ="1">EPF</asp:ListItem>
                    <asp:ListItem Value ="2">CPF</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblFundPercentForEmp" runat="server" Text="Fund Percent For Emp: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtFundPercentForEmp" class="txt medium-input" runat="server" Text="">
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
