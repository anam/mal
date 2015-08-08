<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_LunchRule.aspx.cs" Inherits="AdminHR_LunchRule" Title="HR_LunchRule Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_LunchRule</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
   
    <dt>
     <asp:Label ID="lblLunchOutTimeHours" runat="server" Text="Lunch Out Time Hours: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtLunchOutTimeHours" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblLunchOutTimeMins" runat="server" Text="Lunch Out Time Mins: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtLunchOutTimeMins" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblLunchFlexibleTimeHours" runat="server" Text="Lunch Flexible Time Hours: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtLunchFlexibleTimeHours" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblLunchFlexibleTimeMins" runat="server" Text="Lunch Flexible Time Mins: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtLunchFlexibleTimeMins" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblLunchTimeAllowed" runat="server" Text="Lunch Time Allowed: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtLunchTimeAllowed" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblLunchFlag" runat="server" Text="Lunch Flag: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:RadioButtonList ID="radLunchFlag" runat="server" 
    RepeatDirection="Horizontal">
    <asp:ListItem>Allowed </asp:ListItem>
    <asp:ListItem>Not Allowed</asp:ListItem>
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

