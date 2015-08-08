<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master.master"  CodeFile="AdminSTD_ExamInfoDetail.aspx.cs" Inherits="AdminSTD_ExamInfoDetail" Title="STD_ExamInfoDetail Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateSTD_ExamInfoDetail</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblExamInfoID" runat="server" Text="Exam Info: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlExamInfoID" runat="server">
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
     <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlSubjectID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblExamStartTime" runat="server" Text="Exam Start Time: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExamStartTime" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExamDuration" runat="server" Text="Exam Duration: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExamDuration" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExamDate" runat="server" Text="Exam Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExamDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExamMarks" runat="server" Text="Exam Marks: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExamMarks" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblObtainMarks" runat="server" Text="Obtain Marks: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtObtainMarks" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
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

