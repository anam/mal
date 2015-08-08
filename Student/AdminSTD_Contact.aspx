<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_Contact.aspx.cs" Inherits="AdminSTD_Contact" Title="Add/Update Student Contact Information" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Add/Update Student Contact Information</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblStudentID" runat="server" Text="Student: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlStudentID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblName" runat="server" Text="Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblCellNo" runat="server" Text="Cell No: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtCellNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblOccupation" runat="server" Text="Occupation: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtOccupation" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblOfficeTel" runat="server" Text="Office Tel: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtOfficeTel" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblOfficeAddress" runat="server" Text="Office Address: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtOfficeAddress" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblContactTypeID" runat="server" Text="Contact Type: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlContactTypeID" runat="server">
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
