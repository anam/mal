<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_QuestionChapter.aspx.cs" Inherits="AdminSTD_QuestionChapter" Title="STD_QuestionChapter Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Add/Update Chapterwise Questions</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblQuestionID" runat="server" Text="Question: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlQuestionID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblChapterID" runat="server" Text="Chapter: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlChapterID" runat="server">
     </asp:DropDownList>
     </dd>

 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div></div>
 </asp:Content>

