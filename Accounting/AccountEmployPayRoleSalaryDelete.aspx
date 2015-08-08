<%@ Page Title="Employee Pay Role Salary" Language="C#" MasterPageFile="~/Site2Column.master"
    AutoEventWireup="true" CodeFile="AccountEmployPayRoleSalaryDelete.aspx.cs" Inherits="Accounting_AccountEmployPayRoleSalary" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
                List Of Existing Employee Pay Role Salary</h3>
            <div style="width: 30%; float: right; height: 30px;display:none;">
                <asp:TextBox ID="txtSearch" runat="server" Width="150px"></asp:TextBox>
                <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_OnClick" />
            </div>
        </div>
        <div class="inner-form" style="overflow:scroll">
            Salary of :<asp:DropDownList ID="ddlSalaryOfMonth" runat="server" AutoPostBack="true" 
                onselectedindexchanged="ddlSalaryOfMonth_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:GridView ID="gvACC_EmployPayRoleSalary" runat="server" AutoGenerateColumns="false"
                OnRowDataBound="gvACC_EmployPayRoleSalary_OnRowDataBound" ShowFooter="true" CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Serial">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("EmployeeName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="UpdatedBy">
                        <ItemTemplate>
                            <asp:Label ID="lblUpdatedBy" runat="server" Text='<%#Eval("UpdatedBy") %>'>
                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Salary Of">
                        <ItemTemplate>
                            <asp:Label ID="lblSalaryOfDate" runat="server" Text='<%#Eval("SalaryOfDate") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SalaryAmount">
                        <ItemTemplate>
                            <asp:Label ID="lblSalaryAmount" runat="server" Text='<%#Eval("SalaryAmount", "{0:#0.00}") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PaidSalaryAmount">
                        <ItemTemplate>
                            <asp:Label ID="lblPaidSalaryAmount" runat="server" Text='<%#Eval("PaidSalaryAmount", "{0:#0.00}") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UnpaidSalaryAmount">
                        <ItemTemplate>
                            <asp:Label ID="lblUnpaidSalaryAmount" runat="server" Text='<%#Eval("UnpaidSalaryAmount", "{0:#0.00}") %>'>
                            
                            </asp:Label>
                            <br />
                            <asp:TextBox ID="txtSalaryAmount" runat="server" Width="100px" Text='<%#Eval("UnpaidSalaryAmount", "{0:#0.00}") %>'></asp:TextBox>
                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("EmployPayRoleSalaryID") %>' Visible="false">
                            
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="lnkPaid" runat="server" Text="Delete" CommandArgument='<%#Eval("EmployPayRoleSalaryID") %>'  OnClientClick="return confirm('Are You Sure, You Want To Delete?')" 
                                OnClick="lnkDelete_Click"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Report" Visible="false">
                        <ItemTemplate>
                            <asp:Button ID="lnkViewReport" runat="server" Text="View Report" CommandArgument='<%#Eval("EmployPayRoleSalaryID") %>'
                                OnClick="lnkViewReport_OnClick" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("EmployPayRoleSalaryID") %>'
                                OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
