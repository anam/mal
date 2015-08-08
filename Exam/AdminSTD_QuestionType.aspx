<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_QuestionType.aspx.cs" Inherits="AdminSTD_QuestionType" Title="STD_QuestionType Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Add/Update Question Type</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblQuestionTypeName" runat="server" Text="Question Type Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtQuestionTypeName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
 
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div></div>
 </asp:Content>

