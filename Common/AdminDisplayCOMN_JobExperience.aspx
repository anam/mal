<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplayCOMN_JobExperience.aspx.cs" Inherits="AdminDisplayCOMN_JobExperience" Title="COMN_JobExperience Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Tabular DataCOMN_JobExperience</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvCOMN_JobExperience" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
	 	 	<Columns>
<asp:TemplateField HeaderText="Job Experience">
 	 <ItemTemplate>
 	 <asp:Label ID="lblJobExperienceID" runat="server" Text='<%#Eval("JobExperienceID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="User">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Organization Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblOrganizationName" runat="server" Text='<%#Eval("OrganizationName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Designation">
 	 <ItemTemplate>
 	 <asp:Label ID="lblDesignationID" runat="server" Text='<%#Eval("DesignationID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Natureof Work">
 	 <ItemTemplate>
 	 <asp:Label ID="lblNatureofWork" runat="server" Text='<%#Eval("NatureofWork") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Date Start">
 	 <ItemTemplate>
 	 <asp:Label ID="lblDateStart" runat="server" Text='<%#Eval("DateStart") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Date Ends">
 	 <ItemTemplate>
 	 <asp:Label ID="lblDateEnds" runat="server" Text='<%#Eval("DateEnds") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Duration">
 	 <ItemTemplate>
 	 <asp:Label ID="lblDuration" runat="server" Text='<%#Eval("Duration") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Reasion For Leaving">
 	 <ItemTemplate>
 	 <asp:Label ID="lblReasionForLeaving" runat="server" Text='<%#Eval("ReasionForLeaving") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Contact">
 	 <ItemTemplate>
 	 <asp:Label ID="lblContact" runat="server" Text='<%#Eval("Contact") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Updated By">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUpdatedBy" runat="server" Text='<%#Eval("UpdatedBy") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Updated Date">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUpdatedDate" runat="server" Text='<%#Eval("UpdatedDate") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("JobExperienceID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("JobExperienceID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

