<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayINV_Issue.aspx.cs" Inherits="AdminDisplayINV_Issue" Title="List of Existing Issued Item" %>

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
                    <asp:Label ID="lblItemName" runat="server" Text="Item Name : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtItemName" runat="server" Text ="" class="txt medium-input">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblIssueName" runat="server" Text="Issue Name : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtIssueName" runat="server" class="txt medium-input">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblStoreName" runat="server" Text="Store : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlStoreName" runat="server" class="txt medium-input">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblIssueDate" runat="server" Text="Issue Date To : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtIssueToDate" runat="server" Text="" class="txt small-input">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="calIssueDate" runat="server" 
                        TargetControlID="txtIssueToDate">
                    </ajaxToolkit:CalendarExtender>
                    <%--</dd>
                <dt>--%>
                    <asp:Label ID="Label1" runat="server" Text="From : ">
                    </asp:Label>
                    <%--</dt>
                <dd>--%>
                    <asp:TextBox ID="txtIssueFromDate" runat="server" Text="" class="txt small-input">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" 
                        TargetControlID="txtIssueFromDate">
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
                List of Existing Issued Item</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvINV_Issue" class="gridCss" runat="server" AutoGenerateColumns="false"
                 CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Item Name">
                        <ItemTemplate>
                            <asp:Label ID="lblIssueID" runat="server" Text='<%#Eval("Description") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  <%--  <asp:TemplateField HeaderText="Campus Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCampusID" runat="server" Text='<%#Eval("CampusName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Issue Master Name">
                        <ItemTemplate>
                            <asp:Label ID="lblIssueMasterID" runat="server" Text='<%#Eval("IssueMasterName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Store Name">
                        <ItemTemplate>
                            <asp:Label ID="lblStoreID" runat="server" Text='<%#Eval("StoreName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Issue Date">
                        <ItemTemplate>
                            <asp:Label ID="lblIssueDate" runat="server" Text='<%#Eval("IssueDate","{0:dd-MMM-yyyy}") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Edit /Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("IssueID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("IssueID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div style="text-align:right;" >
            <asp:Label ID ="lblTotalItem" runat = "server" Text= "Total : 0" Font-Bold = "true"></asp:Label>
            </div>
            <div id ="showPageDiv" runat ="server" class="paging">
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
</asp:Content>
