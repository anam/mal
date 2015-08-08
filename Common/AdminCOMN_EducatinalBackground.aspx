<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminCOMN_EducatinalBackground.aspx.cs" Inherits="AdminCOMN_EducatinalBackground"
    Title="COMN_EducatinalBackground Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Insert /UpdateCOMN_EducatinalBackground</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblUserID" runat="server" Text="User: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlUserID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblYear" runat="server" Text="Year: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtYear" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblBoardUniversity" runat="server" Text="Board University: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtBoardUniversity" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblEducationGroup" runat="server" Text="Education Group: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEducationGroup" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblMajor" runat="server" Text="Major: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMajor" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblReaultSystemID" runat="server" Text="Reault System: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlReaultSystemID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblDegree" runat="server" Text="Degree: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDegree" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblResult" runat="server" Text="Result: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtResult" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblScore" runat="server" Text="Score: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtScore" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblOutOf" runat="server" Text="Out Of: ">
    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtOutOf" class="txt large-input" runat="server" Text="">
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
