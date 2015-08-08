<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminQuiz_Chapter.aspx.cs" Inherits="AdminQuiz_Chapter" Title="Quiz Chapter" %>

<%--<%@ OutputCache Duration="20" VaryByParam="None" %>--%>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Quiz Chapter</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCourseID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblChapterName" runat="server" Text="Chapter Name: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtChapterName" class="txt large-input" runat="server" Text="">
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
