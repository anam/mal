<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayINV_IteamDelete.aspx.cs" Inherits="AdminDisplayINV_Iteam" Title="List of Existing Item" %>

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
                    <asp:Label ID="lblDescription" runat="server" Text="Barcode :(, seperated) ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtDescription" runat="server" Text ="" class="txt medium-input" TextMode="MultiLine">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="User : ">
                    </asp:Label>
                </dt>
                <dd>
                   <asp:TextBox ID="txtUser" runat="server" Text ="" class="txt small-input">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblItemCode" runat="server" Text="Item Code : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlItemCode" runat="server" class="txt medium-input">
                    <asp:ListItem Value="0">Any</asp:ListItem>
                        <asp:ListItem>In Store</asp:ListItem>
                        <asp:ListItem>Sold</asp:ListItem>
                        <asp:ListItem>Free</asp:ListItem>
                        <asp:ListItem>Issued</asp:ListItem>
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="ItemSubCategory" runat="server" Text="Item Sub Category : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlItemSubCategory" runat="server" class="txt medium-input">
                    </asp:DropDownList>
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
                List of Existing Item</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvINV_Iteam" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" Checked="true"/>
                            <asp:HiddenField ID="hfIteamID" runat="server" Value='<%#Eval("IteamID") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Code">
                        <ItemTemplate>
                            <asp:Label ID="lblitemID" runat="server" Text='<%#Eval("IteamID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Store">
                        <ItemTemplate>
                            <asp:Label ID="lblCampusID" runat="server" Text='<%#Eval("StoreName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblIteamCode" runat="server" Text='<%#Eval("IteamCode") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Sub Category">
                        <ItemTemplate>
                            <asp:Label ID="lblIteamSubCategory" runat="server" Text='<%#Eval("IteamSubCategoryName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cost">
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price","{0:0}") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sale Price">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" Width="50px" runat="server" Text='<%#Eval("Quantity","{0:0}") %>'></asp:TextBox>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User">
                        <ItemTemplate>
                            <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("Unit") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit /Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("IteamID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')" 
                                CommandArgument='<%#Eval("IteamID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div style="text-align:right;" >
            <asp:Label ID ="lblTotalItem" runat = "server" Text= "Total Item : 0" Font-Bold = "true"></asp:Label>
            <br />
            Total Cost : <asp:Label ID ="lblTotalCost" runat = "server" Text= "0" Font-Bold = "true"></asp:Label>
            <br />
            Total Sale Price : <asp:Label ID ="lblTotalSalePrice" runat = "server" Text= "0" Font-Bold = "true"></asp:Label>

            </div>
            <div id ="showPageDiv" runat ="server" class="paging">
                <div class="viewpageinfo">
                    <%--</div>--%>Show
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
            <br />
            <asp:Button ID="btnDeleteALl" runat="server" onclick="btnDeleteALl_Click" 
                Text="Delelte All" />
            <br />
            
            
            Process To:
           
            <asp:TextBox ID="txtActionTo" runat="server" Width="100px"></asp:TextBox>
            
            <asp:DropDownList ID="ddlAction" runat="server" >
                <asp:ListItem Value="Free">Free</asp:ListItem>
                <asp:ListItem Value="Sold">Sale</asp:ListItem>
                <asp:ListItem Value="Issued">Issue</asp:ListItem>
                <asp:ListItem Value="In Store">Return to Store</asp:ListItem>
                <asp:ListItem Value="In Store">Transfer to another Store</asp:ListItem>
                
            </asp:DropDownList>
            <asp:DropDownList ID="ddlCampusID" runat="server">
                    </asp:DropDownList>
            <asp:Button ID="btnAction" runat="server" Text="Process" 
                onclick="btnAction_Click" />
        </div>
    </div>
    <%--</div>--%>
</asp:Content>
