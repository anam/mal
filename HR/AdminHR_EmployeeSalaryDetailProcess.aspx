<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master" CodeFile="AdminHR_EmployeeSalaryDetailProcess.aspx.cs" Inherits="AdminHR_EmployeeSalaryDetailProcess" Title="Employee Salary Detail Process" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode = "Conditional">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Employee Salary Detail Process</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                   
                       
                    
                    <div style="width: 100%; padding: 20px 0; overflow: hidden;">
                    <div style="width: 90%; padding-left: 20%; float: left;">
                    <asp:Label ID = "lblMassage" runat = "server" Text =""></asp:Label>
                    </div>
                        <div style="width: 90%; padding-left: 20%; float: left;">
                        <label>Select Month :</label>
                           <asp:DropDownList ID="ddlMonths" runat="server">
                            </asp:DropDownList>                           
                            &nbsp;&nbsp;
                             <asp:DropDownList ID="ddlYears" runat="server">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                             <asp:Button ID="btnSalaryProcessDetails" runat="server" class="button button-blue"
                            Text="Generate Salary" OnClick="btnSalaryProcessDetails_OnClick" />

                            <asp:Button ID="btnSelaryPreview" runat="server" class="button button-blue"
                            Text="Salary Preview" OnClick="btnSelaryPreview_OnClick" Visible="false" />
                            <br /> <br />
                            Salary of :<asp:DropDownList ID="ddlSalaryOfMonth" runat="server" AutoPostBack="true" ></asp:DropDownList>
                            Extra Salary:<asp:TextBox ID="txtExtraSalary" runat="server"></asp:TextBox>
                            <asp:DropDownList ID="ddlExployeeID" runat="server"></asp:DropDownList>
                            <asp:Button ID="btnExtraSalary" runat="server" Text="Pay Extra Salary"  
                                class="button button-blue" onclick="btnExtraSalary_Click"/>
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="gvSalaryDetailBreakdown" Style="font-size: small;" Width="95%"
                            runat="server" AutoGenerateColumns="false" OnRowDataBound="gvSalaryDetailBreakdown_RowDataBound"
                            OnSelectedIndexChanged="gvSalaryDetailBreakdown_OnSelectedIndexChanged" CssClass="tabel_input"
                            ShowFooter="True">
                            <HeaderStyle CssClass="heading" />
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="altrow" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBoxSelect" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee No"  ItemStyle-CssClass ="txtLeftDisplay">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("EmployeeNo") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name" ItemStyle-CssClass ="txtLeftDisplay">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfEmployID" runat="server" Value='<%#Eval("EmployeeID") %>' />
                                        <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation" ItemStyle-CssClass ="txtLeftDisplay">
                                    <ItemTemplate>
                                    <asp:Label ID="lblDepartmentName" runat="server" Text='<%#Eval("DepartmentName") %>'>
                                        </asp:Label>
                                        <br />
                                        (
                                        <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation") %>'>
                                        </asp:Label>
                                        )
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Salary Detail">
                                    <ItemTemplate>
                                        <asp:GridView ID="gvSalaryOnly" class="gridCss" Style="font-size: xx-small;" runat="server"
                                            AutoGenerateColumns="false" CssClass="gridCss" ShowHeader="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="" HeaderStyle-BackColor="GhostWhite">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("PackageRulesName") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" HeaderStyle-BackColor="GhostWhite">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSalaryValue" runat="server" Text='<%#Eval("PackageID") %>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gross" ItemStyle-CssClass ="txtRightDisplay">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSalary" runat="server" Text='<%#Eval("TotalSalary") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    <div style="text-align: right; padding-right: 5px;">
                                        <asp:Label ID="lblTotalGross" runat="server" Font-Bold="True" Text="Gross"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Salary Diduction" ItemStyle-CssClass ="txtRightDisplay">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalaryDiduction" runat="server" Text='<%#Eval("SalaryDiduction") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    <div style="text-align: right; padding-right: 5px;">
                                        <asp:Label ID="lblTotalSalaryDiduction" runat="server" Font-Bold="True" Text="SalaryDiduction"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PF Amount or Security Amount" ItemStyle-CssClass ="txtRightDisplay">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPFAmount" runat="server" Text='<%#Eval("PFAmount") %>'>
                                        </asp:Label>
                                        <br />----------<br />
                                        <asp:Label ID="lblSecurityAmount" runat="server" Text='<%#Eval("SecurityAmount") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    <div style="text-align: right; padding-right: 5px;">
                                        <asp:Label ID="lblTotalPFAmount" runat="server" Font-Bold="True" Text="PFAmount"></asp:Label>
                                     </div>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Adv. Salary" ItemStyle-CssClass ="txtRightDisplay">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLoanAmount" runat="server" Text='<%#Eval("LoanAmount") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loan Deduction" ItemStyle-CssClass ="txtRightDisplay">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtLoanDeduction" runat="server" Text="" CssClass="textRightDisplay"
                                            Width="80px" OnTextChanged="txtLoanDeduction_OnTextChanged" AutoPostBack="true">
                                        </asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbeLoanDeduction" runat="server" ValidChars=".0123456789"
                                            FilterMode="ValidChars" TargetControlID="txtLoanDeduction">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    <div style="text-align: right; padding-right: 5px;">
                                        <asp:Label ID="lblTotalLoanDeduction" runat="server" Font-Bold="True" Text="Deduction"></asp:Label>
                                     </div>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Grand Total" ItemStyle-CssClass ="txtRightDisplay">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrandTotal" runat="server" Text='<%#Eval("GrandTotal") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>                                        
                                        <div style="text-align: right; padding-right: 5px;">
                                            <asp:Label ID="lblTotalSalaryPayToEmp" runat="server" Font-Bold="True" Text="TotalSalary"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div>
                        <dl>
                            <dt></dt>
                            <dd>
                                <asp:Button ID="btnPost" class="button button-blue" runat="server" Text="Post" OnClick="btnPost_Click" />
                            </dd>
                        </dl>
                    </div>
                    <div style="width: 100%; padding: 20px 0; overflow: hidden;">
                        <asp:Literal ID="litSummary" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
