<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master.master"  CodeFile="AdminSTD_ExamInfo.aspx.cs" Inherits="AdminSTD_ExamInfo" Title="STD_ExamInfo Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateSTD_ExamInfo</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblCampusID" runat="server" Text="Campus: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlCampusID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblBatchID" runat="server" Text="Batch: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlBatchID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblSemesterID" runat="server" Text="Semester: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlSemesterID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblSubjectTeacherID" runat="server" Text="Subject Teacher: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlSubjectTeacherID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblExamTypeID" runat="server" Text="Exam Type: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlExamTypeID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblExamInfoName" runat="server" Text="Exam Info Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExamInfoName" class="txt large-input" runat="server" Text="">
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

