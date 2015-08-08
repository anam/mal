<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplayHR_LunchRule.aspx.cs" Inherits="AdminDisplayHR_LunchRule" Title="HR_LunchRule Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Tabular DataHR_LunchRule</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvHR_LunchRule" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
	 	 	<Columns>
<asp:TemplateField HeaderText="Lunch Rule">
 	 <ItemTemplate>
 	 <asp:Label ID="lblLunchRuleID" runat="server" Text='<%#Eval("LunchRuleID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Employee">
 	 <ItemTemplate>
 	 <asp:Label ID="lblEmployeeID" runat="server" Text='<%#Eval("EmployeeID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Lunch Out Time Hours">
 	 <ItemTemplate>
 	 <asp:Label ID="lblLunchOutTimeHours" runat="server" Text='<%#Eval("LunchOutTimeHours") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Lunch Out Time Mins">
 	 <ItemTemplate>
 	 <asp:Label ID="lblLunchOutTimeMins" runat="server" Text='<%#Eval("LunchOutTimeMins") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Lunch Flexible Time Hours">
 	 <ItemTemplate>
 	 <asp:Label ID="lblLunchFlexibleTimeHours" runat="server" Text='<%#Eval("LunchFlexibleTimeHours") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Lunch Flexible Time Mins">
 	 <ItemTemplate>
 	 <asp:Label ID="lblLunchFlexibleTimeMins" runat="server" Text='<%#Eval("LunchFlexibleTimeMins") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Lunch Time Allowed">
 	 <ItemTemplate>
 	 <asp:Label ID="lblLunchTimeAllowed" runat="server" Text='<%#Eval("LunchTimeAllowed") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Lunch Flag">
 	 <ItemTemplate>
 	 <asp:Label ID="lblLunchFlag" runat="server" Text='<%#Eval("LunchFlag") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("LunchRuleID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("LunchRuleID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

