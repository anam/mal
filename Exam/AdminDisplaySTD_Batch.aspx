<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/Site2Column.master"  CodeFile="AdminDisplaySTD_Batch.aspx.cs" Inherits="AdminDisplaySTD_Batch" Title="STD_Batch Insert/Update By Admin" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="content-box">
<div class="header">
<h3>Tabular DataSTD_Batch</h3>
</div>
<div class="inner-content">
	 	<asp:GridView ID="gvSTD_Batch" class="gridCss" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
	 	 	<Columns>
<asp:TemplateField HeaderText="Batch">
 	 <ItemTemplate>
 	 <asp:Label ID="lblBatchID" runat="server" Text='<%#Eval("BatchID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Batch Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblBatchName" runat="server" Text='<%#Eval("BatchName") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Year">
 	 <ItemTemplate>
 	 <asp:Label ID="lblYear" runat="server" Text='<%#Eval("Year") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="">
 	 <ItemTemplate>
 	 <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Batch Code">
 	 <ItemTemplate>
 	 <asp:Label ID="lblBatchCode" runat="server" Text='<%#Eval("BatchCode") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 1">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 2">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField2" runat="server" Text='<%#Eval("ExtraField2") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 3">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField3" runat="server" Text='<%#Eval("ExtraField3") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 4">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField4" runat="server" Text='<%#Eval("ExtraField4") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Extra Field 5">
 	 <ItemTemplate>
 	 <asp:Label ID="lblExtraField5" runat="server" Text='<%#Eval("ExtraField5") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Update Date">
 	 <ItemTemplate>
 	 <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("UpdateDate") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Row Status">
 	 <ItemTemplate>
 	 <asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>
<asp:TemplateField HeaderText="Delete">
 	 <ItemTemplate>
 	 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("BatchID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	 />
 	 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("BatchID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
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

