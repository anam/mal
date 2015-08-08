<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayHR_ProvidentFundSetup.aspx.cs" Inherits="AdminDisplayHR_ProvidentFundSetup"
    Title="Provident Fund Setup By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
               List of Service Length wise Provident Fund Setup</h3>
        </div>
        <div class="inner-content">
        <div>
        <asp:Button ID = "btnAdd" runat = "server" Text = "Add New Setup" class="button button-blue" OnClick = "btnAdd_Click" />
        </div>
            <asp:GridView ID="gvHR_ProvidentFundSetup" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss" OnRowDataBound ="gvHR_ProvidentFundSetup_OnRowDataBound">
                <Columns>
                   <%-- <asp:TemplateField HeaderText="Provident Fund Setup">
                        <ItemTemplate>
                            <asp:Label ID="lblProvidentFundSetupID" runat="server" Text='<%#Eval("ProvidentFundSetupID") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Service Len Start Year">
                        <ItemTemplate>
                            <asp:Label ID="lblServiceLenStartYear" runat="server" Text='<%#Eval("ServiceLenStartYear") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Service Len End Year">
                        <ItemTemplate>
                            <asp:Label ID="lblServiceLenEndYear" runat="server" Text='<%#Eval("ServiceLenEndYear") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fund Type">
                        <ItemTemplate>
                            <asp:Label ID="lblFundTypeID" runat="server" Text='<%#Eval("FundTypeID")%>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fund Percent For Emp">
                        <ItemTemplate>
                            <asp:Label ID="lblFundPercentForEmp" runat="server" Text='<%#Eval("FundPercentForEmp") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Extra Field 1">
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
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ProvidentFundSetupID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("ProvidentFundSetupID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
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
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
