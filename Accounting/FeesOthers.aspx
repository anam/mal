<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="FeesOthers.aspx.cs" Inherits="AdminSTD_Fees" Title="STD_Fees Insert/Update By Admin" %>
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
     <asp:Label ID="lblAmount" runat="server" Text="Amount: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtAmount" class="txt large-input" runat="server" Text="">
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
     <asp:Label ID="lblRemarks" runat="server" Text="Remarks: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtRemarks" TextMode="MultiLine" class="txt textarea" runat="server" Text="">
    </asp:TextBox>
     </dd>
      <dt>
     <asp:Label ID="Label1" runat="server" Text="Next Submission? ">
    </asp:Label>
     </dt>
    <dd>
     
    <asp:CheckBox ID="chkNextSubmission" runat="server" />
     </dd>
    <dt>
     <asp:Label ID="lblSubmissionDate" runat="server" Text="Next Submission Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtNextSubmissionDate" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblSubmitedDate" runat="server" Text="Amount: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtNextSubmissionAmount" class="txt large-input" runat="server" Text="">
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

