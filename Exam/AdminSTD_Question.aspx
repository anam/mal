<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_Question.aspx.cs" Inherits="AdminSTD_Question" Title="STD_Question Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Add/Update Questions</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblQuestionTypeID" runat="server" Text="Question Type: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlQuestionTypeID" runat="server">
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
     <asp:Label ID="lblMark" runat="server" Text="Mark: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtMark" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>

 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div></div>
 </asp:Content>

