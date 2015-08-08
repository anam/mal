<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayHR_ProvidentfundAmount.aspx.cs" Inherits="AdminDisplayHR_ProvidentfundAmount"
    Title="HR_ProvidentfundAmount Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content-box">
        <div class="header">
            <h3>
                Tabular DataHR_ProvidentfundAmount</h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblEmployeeID" runat="server" Text="EmployeeID : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEmployeeID" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                
                
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="EmployeeID : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="TextBox1" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>


                <dt>
                    <asp:Label ID="Label2" runat="server" Text="EmployeeID : ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="TextBox2" class="txt large-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>


                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <%--<asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />--%>
                </dd>
            </dl>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvHR_ProvidentfundAmount" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss">
                <Columns>
                    <asp:TemplateField HeaderText="Providentfund Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblProvidentfundAmountID" runat="server" Text='<%#Eval("ProvidentfundAmountID") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeID" runat="server" Text='<%#Eval("EmployeeID") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="Employee Contribution Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblEmployeeContributionAmount" runat="server" Text='<%#Eval("EmployeeContributionAmount") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Company Contribution Amount">
                        <ItemTemplate>
                            <asp:Label ID="lblCompanyContributionAmount" runat="server" Text='<%#Eval("CompanyContributionAmount") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Payroll Date">
                        <ItemTemplate>
                            <asp:Label ID="lblPayrollDate" runat="server" Text='<%#Eval("PayrollDate") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ProvidentfundAmountID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"  CommandArgument='<%#Eval("ProvidentfundAmountID") %>'
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
