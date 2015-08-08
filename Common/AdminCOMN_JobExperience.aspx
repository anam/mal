<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminCOMN_JobExperience.aspx.cs" Inherits="AdminCOMN_JobExperience" Title="COMN_JobExperience Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateCOMN_JobExperience</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblUserID" runat="server" Text="User: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlUserID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblOrganizationName" runat="server" Text="Organization Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtOrganizationName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblDesignationID" runat="server" Text="Designation: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlDesignationID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblNatureofWork" runat="server" Text="Natureof Work: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtNatureofWork" TextMode="MultiLine" class="txt textarea" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblDateStart" runat="server" Text="Date Start: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtDateStart" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblDateEnds" runat="server" Text="Date Ends: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtDateEnds" class="txt large-input" runat="server" Text="">
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
     <asp:Label ID="lblReasionForLeaving" runat="server" Text="Reasion For Leaving: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtReasionForLeaving" TextMode="MultiLine" class="txt textarea" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblContact" runat="server" Text="Contact: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtContact" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblUpdatedBy" runat="server" Text="Updated By: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtUpdatedBy" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblUpdatedDate" runat="server" Text="Updated Date: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtUpdatedDate" class="txt large-input" runat="server" Text="">
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

