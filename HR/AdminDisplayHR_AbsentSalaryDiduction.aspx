<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayHR_AbsentSalaryDiduction.aspx.cs" Inherits="AdminDisplayHR_Bank" Title="HR_Bank Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
        
    <div class="content-box">
        <div class="header">
            <h3>
                Absent Salary Diduction List</h3>
        </div>
        <div class="inner-content">
           <asp:GridView ID="gvAbsendSalaryDiduction" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
           <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("AbsendSalaryDiductionID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee No">
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeID" runat="server" Text='<%#Eval("EmployeeNo") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SalaryOfMonth">
                    <ItemTemplate>
                        <asp:Label ID="lblSalaryOfMonth" runat="server" Text='<%#Eval("SalaryOfMonth") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NoOfDays">
                    <ItemTemplate>
                        <asp:Label ID="lblNoOfDays" runat="server" Text='<%#Eval("NoOfDays") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TotalSalary">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalSalary" runat="server" Text='<%#Eval("TotalSalary") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SalaryDeduction">
                    <ItemTemplate>
                        <asp:Label ID="lblSalaryDeduction" runat="server" Text='<%#Eval("SalaryDeduction") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("AbsendSalaryDiductionID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
