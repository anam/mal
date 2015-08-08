<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_QuestionAnswer.aspx.cs" Inherits="AdminSTD_QuestionAnswer" Title="STD_QuestionAnswer Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Add/Update Question's Answer</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblQuestionID" runat="server" Text="Question: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlQuestionID" runat="server">
     </asp:DropDownList>
     </dd>
  
    <dt>
     <asp:Label ID="lblIsCorrectQuestionAnswer" runat="server" Text="Is Correct Question Answer: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:RadioButtonList ID="radIsCorrectQuestionAnswer" runat="server" 
    RepeatDirection="Horizontal">
    <asp:ListItem>True</asp:ListItem>
    <asp:ListItem>False</asp:ListItem>
    </asp:RadioButtonList>
     </dd>
    <dt>
     <asp:Label ID="lblDescription" runat="server" Text="Description: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtDescription" TextMode="MultiLine" class="txt textarea" runat="server" Text="">
    </asp:TextBox>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div></div>
 </asp:Content>

