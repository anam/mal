<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminHR_ChildrenInfo.aspx.cs" Inherits="AdminHR_ChildrenInfo" Title="HR_ChildrenInfo Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateHR_ChildrenInfo</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>

    <dt>
     <asp:Label ID="lblChildrenInfoName" runat="server" Text="Children Name: "> </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtChildrenInfoName" class="txt large-input" runat="server" Text=""> </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblChildrenDateOfBirth" runat="server" Text="Children Date Of Birth: "> </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtChildrenDateOfBirth" class="txt large-input" runat="server" Text=""> </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblSex" runat="server" Text="Sex: "> </asp:Label>
     </dt>
    <dd>
                     <asp:DropDownList ID="ddlSex" runat="server">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
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

