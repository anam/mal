<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_ClassSubjectEmployeeStudent.aspx.cs" Inherits="AdminSTD_ClassSubjectEmployeeStudent" Title="STD_ClassSubjectEmployeeStudent Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateSTD_ClassSubjectEmployeeStudent</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblClassSubjectEmployeeID" runat="server" Text="Class Subject Employee: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlClassSubjectEmployeeID" runat="server">
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

