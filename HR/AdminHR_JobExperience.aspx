<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_JobExperience.aspx.cs" Inherits="AdminHR_JobExperience" Title="HR_JobExperience Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_JobExperience</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    
    <dt>
     <asp:Label ID="lblOrganization" runat="server" Text="Organization: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtOrganization" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblPosition" runat="server" Text="Position: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtPosition" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblYearStart" runat="server" Text="Year Start: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtYearStart" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblYearEnd" runat="server" Text="Year End: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtYearEnd" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblReasonForLeaving" runat="server" Text="Reason For Leaving: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtReasonForLeaving" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblContactPerson" runat="server" Text="Contact Person: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtContactPerson" class="txt large-input" runat="server" Text="">
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

