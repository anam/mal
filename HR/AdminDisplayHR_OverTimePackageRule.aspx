<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplayHR_OverTimePackageRule.aspx.cs" Inherits="AdminDisplayHR_OverTimePackageRule" Title="HR_OverTimePackageRule Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Tabular DataHR_OverTimePackageRule</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvHR_OverTimePackageRule" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
	 	 	<Columns>
<asp:TemplateField HeaderText="Over Time Rule">
 	 <ItemTemplate>
 	 <asp:Label ID="lblOverTimeRuleID" runat="server" Text='<%#Eval("OverTimeRuleID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Over Time Package">
 	 <ItemTemplate>
 	 <asp:Label ID="lblOverTimePackageID" runat="server" Text='<%#Eval("OverTimePackageID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Over Time Rule Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblOverTimeRuleName" runat="server" Text='<%#Eval("OverTimeRuleName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Over Time Rule Value">
 	 <ItemTemplate>
 	 <asp:Label ID="lblOverTimeRuleValue" runat="server" Text='<%#Eval("OverTimeRuleValue") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Over Time Rule Operator">
 	 <ItemTemplate>
 	 <asp:Label ID="lblOverTimeRuleOperator" runat="server" Text='<%#Eval("OverTimeRuleOperator") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("OverTimeRuleID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("OverTimeRuleID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
 	  />
  		</ItemTemplate>
 	</asp:TemplateField>
	 	 	</Columns>
	 	 </asp:GridView>
	<div class="paging">
	<div class="viewpageinfo">
	<%--View 1 -10 of 13--%>
	Show
	</div>
	<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
	 <asp:ListItem Text="10" Value="10" />
	<asp:ListItem Text="25" Value="25" />
	<asp:ListItem Text="50" Value="50" />
	 </asp:DropDownList>
	<div class="pagelist">
	 <asp:Repeater ID="rptPager" runat="server">
	<ItemTemplate>
	<asp:LinkButton ID="lnkPage" runat="server" Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed"></asp:LinkButton>
	</ItemTemplate>
	</asp:Repeater>
	</div>
	</div>
</div>
</div>
 </asp:Content>

