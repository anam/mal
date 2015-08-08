<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayINV_MRRInfo.aspx.cs" Inherits="AdminDisplayINV_MRRInfo"
    Title="List of Existing MRR Information" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Search</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>
                    <asp:Label ID="lblCampusName" runat="server" Text="Campus : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCampusName" runat="server" class="txt medium-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblMRRCode" runat="server" Text="MRR Code : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMRRCode" runat="server" class="txt medium-input">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblItemCode" runat="server" Text="Item Code : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtItemCode" runat="server" Text="" class="txt medium-input">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblMRRToDate" runat="server" Text="MRR Date To : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtMRRToDate" runat="server" Text="" class="txt small-input">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="calIssueDate" runat="server" 
                        TargetControlID="txtMRRToDate">
                    </ajaxToolkit:CalendarExtender>
                    <%--</dd>
                <dt>--%>
                    <asp:Label ID="Label1" runat="server" Text="From : ">
                    </asp:Label>
                    <%--</dt>
                <dd>--%>
                    <asp:TextBox ID="txtMRRFromDate" runat="server" Text="" class="txt small-input">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" 
                        TargetControlID="txtMRRFromDate">
                    </ajaxToolkit:CalendarExtender>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnIssueSearch" class="button button-blue" runat="server" Text="Search"
                        OnClick="btnIssueSearch_Click" />
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing MRR Information</h3>
        </div>
        <div class="inner-content" style="overflow: scroll;">
            <asp:GridView ID="gvINV_MRRInfo" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <%--<asp:TemplateField HeaderText="MRR Info Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMRRInfoID" runat="server" Text='<%#Eval("MRRInfoID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Campus Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCampusID" runat="server" Text='<%#Eval("CampusName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="MRR Info Master Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMRRInfoMasterID" runat="server" Text='<%#Eval("MRRInfoMasterID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="MRR Code">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRCode" runat="server" Text='<%#Eval("MRRCode") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Code">
                        <ItemTemplate>
                            <asp:Label ID="lblIteamID" runat="server" Text='<%#Eval("IteamCode") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Tag">
                        <ItemTemplate>
                            <asp:Label ID="lblTagID" runat="server" Text='<%#Eval("TagID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Convert.ToDouble(DataBinder.Eval(Container.DataItem, "Quantity")).ToString("#,##0.00;(#,##0.00); ") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MRR Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRAmount" runat="server" Text='<%#Convert.ToDouble(DataBinder.Eval(Container.DataItem, "MRRAmount")).ToString("#,##0.00;(#,##0.00); ") %>'>

 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sale Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblSaleAmount" runat="server" Text='<%#Convert.ToDouble(DataBinder.Eval(Container.DataItem, "SaleAmount")).ToString("#,##0.00;(#,##0.00); ") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MRR Date">
                        <ItemTemplate>
                            <asp:Label ID="lblMRRDate" runat="server" Text='<%#Eval("MRRDate","{0:dd-MMM-yyyy}")  %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Store Name">
 	 <ItemTemplate>
 	 <asp:Label ID="lblStoreID" runat="server" Text='<%#Eval("StoreID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("MRRInfoID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <%-- <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("MRRInfoID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
 	  />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div style = "text-align : right">
            <asp:Label ID = "lblTotalItem" runat = "server" Font-Bold = "true" Text =""></asp:Label>
            </div>
            <div id="showPageDiv" runat="server" class="paging">
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
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
