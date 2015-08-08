<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminACC_Check.aspx.cs" Inherits="AdminACC_Check" Title="ACC_Check Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Insert /UpdateACC_Check</h3>
</div>
<div class="inner-form">
<!-- error and information messages -->
  	<dl>
    <dt>
     <asp:Label ID="lblCheckNo" runat="server" Text="Check No: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtCheckNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblBankAccountNo" runat="server" Text="Bank Account No: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtBankAccountNo" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblBankID" runat="server" Text="Bank: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:DropDownList ID="ddlBankID" runat="server">
     </asp:DropDownList>
     </dd>
    <dt>
     <asp:Label ID="lblBranchNOtherDetails" runat="server" Text="Branch N Other Details: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtBranchNOtherDetails" TextMode="MultiLine" class="txt textarea" runat="server" Text="">
    </asp:TextBox>
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
     <asp:Label ID="lblIsCashCheck" runat="server" Text="Is Cash Check: ">
    </asp:Label>
     </dt>
    <dd>
    <asp:RadioButtonList ID="radIsCashCheck" runat="server" 
    RepeatDirection="Horizontal">
    <asp:ListItem>True</asp:ListItem>
    <asp:ListItem>False</asp:ListItem>
    </asp:RadioButtonList>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField1" runat="server" Text="Extra Field 1: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField1" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField2" runat="server" Text="Extra Field 2: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField2" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField3" runat="server" Text="Extra Field 3: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField3" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField4" runat="server" Text="Extra Field 4: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtExtraField4" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>
    <dt>
     <asp:Label ID="lblExtraField5" runat="server" Text="Extra Field 5: ">
    </asp:Label>
     </dt>
    <dd>
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

