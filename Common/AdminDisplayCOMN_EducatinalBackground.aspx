<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplayCOMN_EducatinalBackground.aspx.cs" Inherits="AdminDisplayCOMN_EducatinalBackground" Title="COMN_EducatinalBackground Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Tabular DataCOMN_EducatinalBackground</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvCOMN_EducatinalBackground" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
	 	 	<Columns>
<asp:TemplateField HeaderText="Educational Bacground">
 	 <ItemTemplate>
 	 <asp:Label ID="lblEducationalBacgroundID" runat="server" Text='<%#Eval("EducationalBacgroundID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="User">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Year">
 	 <ItemTemplate>
 	 <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Board University">
 	 <ItemTemplate>
 	 <asp:Label ID="lblBoardUniversity" runat="server" Text='<%#Eval("BoardUniversity") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Education Group">
 	 <ItemTemplate>
 	 <asp:Label ID="lblEducationGroup" runat="server" Text='<%#Eval("EducationGroup") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Major">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMajor" runat="server" Text='<%#Eval("Major") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Reault System">
 	 <ItemTemplate>
 	 <asp:Label ID="lblReaultSystemID" runat="server" Text='<%#Eval("ReaultSystemID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Degree">
 	 <ItemTemplate>
 	 <asp:Label ID="lblDegree" runat="server" Text='<%#Eval("Degree") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Result">
 	 <ItemTemplate>
 	 <asp:Label ID="lblResult" runat="server" Text='<%#Eval("Result") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Score">
 	 <ItemTemplate>
 	 <asp:Label ID="lblScore" runat="server" Text='<%#Eval("Score") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Out Of">
 	 <ItemTemplate>
 	 <asp:Label ID="lblOutOf" runat="server" Text='<%#Eval("OutOf") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("EducationalBacgroundID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("EducationalBacgroundID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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
</div>
 </asp:Content>

