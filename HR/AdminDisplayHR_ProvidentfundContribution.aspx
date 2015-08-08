<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplayHR_ProvidentfundContribution.aspx.cs" Inherits="AdminDisplayHR_ProvidentfundContribution" Title="HR_ProvidentfundContribution Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Tabular DataHR_ProvidentfundContribution</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvHR_ProvidentfundContribution" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
	 	 	<Columns>
<asp:TemplateField HeaderText="Providentfund Contribution">
 	 <ItemTemplate>
 	 <asp:Label ID="lblProvidentfundContributionID" runat="server" Text='<%#Eval("ProvidentfundContributionID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Employee">
 	 <ItemTemplate>
 	 <asp:Label ID="lblEmployeeID" runat="server" Text='<%#Eval("EmployeeID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Amount">
 	 <ItemTemplate>
 	 <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("ProvidentfundContributionID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("ProvidentfundContributionID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

