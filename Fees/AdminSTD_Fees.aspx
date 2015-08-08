<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_Fees.aspx.cs" Inherits="AdminSTD_Fees" Title="STD_Fees Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateSTD_Fees</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblFeesName" runat="server" Text="Fees Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtFeesName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblAmount" runat="server" Text="Amount: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtAmount" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblFeesTypeID" runat="server" Text="Fees Type: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlFeesTypeID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblSubmissionDate" runat="server" Text="Submission Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtSubmissionDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblSubmitedDate" runat="server" Text="Submited Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtSubmitedDate" class="txt large-input" runat="server" Text="">
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
     <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlCourseID" runat="server">
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
    <dt>
     <asp:Label ID="lblRemarks" runat="server" Text="Remarks: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtRemarks" TextMode="MultiLine" class="txt textarea" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblIsPaid" runat="server" Text="Is Paid: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:RadioButtonList ID="radIsPaid" runat="server" 
    RepeatDirection="Horizontal">
    <asp:ListItem>True</asp:ListItem>
    <asp:ListItem>False</asp:ListItem>
    </asp:RadioButtonList>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div>
 </div>
 </asp:Content>

