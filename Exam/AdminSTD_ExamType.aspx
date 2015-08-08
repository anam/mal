<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_ExamType.aspx.cs" Inherits="AdminSTD_ExamType" Title="Insert /Update Exam Type" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /Update Exam Type</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblExamTypeName" runat="server" Text="Exam Type Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExamTypeName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div>
 </div>
 </asp:Content>

