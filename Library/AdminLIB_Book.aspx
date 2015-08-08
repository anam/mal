<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminLIB_Book.aspx.cs" Inherits="AdminLIB_Book" Title="Book" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div class="content-box">
        <div class="header">
            <h3>
                Book</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblPublisherID" runat="server" Text="Publisher: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlPublisherID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblAuthorID" runat="server" Text="Author: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlAuthorID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblCategory" runat="server" Text="Category: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubCategory" runat="server" Text="Sub Category: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubCategory" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblBookName" runat="server" Text="Book Name: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBookName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblBookISBN" runat="server" Text="Book ISBN: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBookISBN" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="txtBookISBN_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" TargetControlID="txtBookISBN" 
                        ValidChars="0123456789">
                    </asp:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblPublishedYear" runat="server" Text="Published Year: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtPublishedYear" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="txtPublishedYear_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" TargetControlID="txtPublishedYear" 
                        ValidChars="0123456789">
                    </asp:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="lblBookNo" runat="server" Text="Book No: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBookNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="txtBookNo_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" TargetControlID="txtBookNo" 
                        ValidChars="0123456789">
                    </asp:FilteredTextBoxExtender>
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
