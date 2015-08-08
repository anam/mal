<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_BloodGroup.aspx.cs" Inherits="AdminHR_BloodGroup" Title="HR_BloodGroup Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
<div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_BloodGroup</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblBloodGroupName" runat="server" Text="Blood Group Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtBloodGroupName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
 <dt></dt>
 <dd>
<asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />
 </dd>
 </dl></div></div>
 </ContentTemplate>
     </asp:UpdatePanel>
 </asp:Content>

