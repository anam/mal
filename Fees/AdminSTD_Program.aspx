<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_Program.aspx.cs" Inherits="AdminSTD_Program" Title="STD_Program Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /Update Program</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblProgramName" runat="server" Text="Program Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtProgramName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlCourseID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblDescription" runat="server" Text="Description: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtDescription" TextMode="MultiLine" class="txt textarea" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblDuration" runat="server" Text="Duration: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtDuration" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblCost" runat="server" Text="Cost: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtCost" class="txt large-input" runat="server" Text="">
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

