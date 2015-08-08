<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master.master"  CodeFile="AdminSTD_ExamStudent.aspx.cs" Inherits="AdminSTD_ExamStudent" Title="STD_ExamStudent Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateSTD_ExamStudent</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblExamStudent" runat="server" Text="Exam Student: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExamStudent" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExamID" runat="server" Text="Exam: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlExamID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblStudentID" runat="server" Text="Student: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlStudentID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblObtainedMark" runat="server" Text="Obtained Mark: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtObtainedMark" class="txt large-input" runat="server" Text="">
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

