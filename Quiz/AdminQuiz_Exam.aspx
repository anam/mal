<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminQuiz_Exam.aspx.cs" Inherits="AdminQuiz_Exam" Title="Quiz_Exam Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateQuiz_Exam</h3>
</div>
<div class="inner-form">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblExamName" runat="server" Text="Exam Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExamName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
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
    <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
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
    <dt>
     <asp:Label ID="lblExamTimeDuration" runat="server" Text="Exam Time Duration: ">
    </asp:Label>
     </dt>
    <dd>
     Hour :&nbsp;<asp:DropDownList ID="ddlExamHour" runat="server" Width="50">
                    </asp:DropDownList>
                    &nbsp;:&nbsp;
                    <asp:DropDownList ID="ddlExamMin" runat="server" Width="50">
                    </asp:DropDownList>
     </dd>
    
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl>
 
        </ContentTemplate>
    </asp:UpdatePanel>

 </div>
 </div>
 </asp:Content>

