<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminSTD_ClassTimeGroup.aspx.cs" Inherits="AdminSTD_ClassTimeGroup" Title="STD_ClassTimeGroup Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateSTD_ClassTimeGroup</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblClassTimeGroupName" runat="server" Text="Class Time Group Name: ">
    </asp:Label>
     </dt>
    <dd >
        <asp:TextBox ID="txtClassTimeGroupName" class="txt small-input" runat="server" Text="" Width="30px">
        </asp:TextBox>
        <asp:TextBox ID="txtExtraField3"  runat="server" Text=""  Width="30px" Enabled="false">
        (Do not use - or anything just word)
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblStartTime" runat="server" Text="Start Time: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtStartTime" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblEndTime" runat="server" Text="End Time: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtEndTime" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField1" runat="server" Text="Extra Field 1: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtExtraField1" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField2" runat="server" Text="Extra Field 2: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtExtraField2" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField3" runat="server" Text="Extra Field 3: ">
        </asp:Label>
     </dt>
    <dd style="display:none;">
     
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField4" runat="server" Text="Extra Field 4: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtExtraField4" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt style="display:none;">
     <asp:Label ID="lblExtraField5" runat="server" Text="Extra Field 5: ">
    </asp:Label>
     </dt>
    <dd style="display:none;">
     <asp:TextBox ID="txtExtraField5" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblRowStatusID" runat="server" Text="Row Status: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlRowStatusID" runat="server">
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

