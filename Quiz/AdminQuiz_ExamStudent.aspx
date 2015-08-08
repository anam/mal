<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminQuiz_ExamStudent.aspx.cs" Inherits="AdminQuiz_ExamStudent" Title="Quiz_ExamStudent Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateQuiz_ExamStudent</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblExamStudentName" runat="server" Text="Exam Student Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExamStudentName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
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
     <asp:Label ID="lblClassSubjectID" runat="server" Text="Class Subject: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlClassSubjectID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblSTDExamDetailsID" runat="server" Text="STD Exam Details: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlSTDExamDetailsID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblQuizExamID" runat="server" Text="Quiz Exam: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlQuizExamID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField1" runat="server" Text="Extra Field 1: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField1" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField2" runat="server" Text="Extra Field 2: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField2" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField3" runat="server" Text="Extra Field 3: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField3" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField4" runat="server" Text="Extra Field 4: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField4" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField5" runat="server" Text="Extra Field 5: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField5" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblRowStatusID" runat="server" Text="Row Status: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlRowStatusID" runat="server">
     </asp:DropDownList>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div>
 </div>
 </asp:Content>

