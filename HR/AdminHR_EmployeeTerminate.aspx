<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminHR_EmployeeTerminate.aspx.cs" Inherits="AdminHR_EmployeeTerminate"
    Title="Employee Terminate" %>

<%@ Register Src="Control/UCEmployeeInfo.ascx" TagName="UCEmployeeInfo" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="content-box">
        <div class="header">
            <h3>
                Resign or Termination</h3>
        </div>
        <div class="inner-form">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <uc1:UCEmployeeInfo ID="UCEmployeeInfo1" runat="server" />
        </div>
     </div>

    <div class="content-box">
        <div class="header">
            <h3>
              Settlement Information</h3>
        </div>
         <div class="inner-form">
            <!-- error and information messages -->
            <dl>
               <dt>
                    
                </dt>
                <dd>
                    <asp:Label ID="lblServiceLength" runat="server" Text="">
                    </asp:Label>
                    
                </dd>
             <dt>
                    <asp:Label ID="Label1" runat="server" Text="EPF Amount: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtEmpContributionAmount" class="txt medium-input" runat="server" Text="0" ReadOnly ="true">
                    </asp:TextBox>
                    
                </dd>

                 <dt>
                    <asp:Label ID="Label2" runat="server" Text="CPF Amount: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtComContributionAmount" class="txt medium-input" runat="server" Text="0" ReadOnly ="true">
                    </asp:TextBox>                    
                </dd>

                 <dt>
                    <asp:Label ID="Label3" runat="server" Text="Total Contribution: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtTotalContribution" class="txt medium-input" runat="server" Text="0" ReadOnly ="true">
                    </asp:TextBox>
                </dd>

                 <dt>
                    <asp:Label ID="Label4" runat="server" Text="CPF Fund Right's(%): ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtCPFFundRight" class="txt medium-input" runat="server" Text="" AutoPostBack = "true" OnTextChanged ="txtCPFFundRight_OnTextChanged">
                    </asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID = "ftbeCPFFundRight" runat ="server" FilterMode ="ValidChars" TargetControlID = "txtCPFFundRight" ValidChars ="1234567890"></ajaxToolkit:FilteredTextBoxExtender>
                </dd>
                <dt>
                    <asp:Label ID="Label5" runat="server" Text="Salary of this month: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSalaryOfThisMonth" class="txt medium-input" runat="server" Text="0" >
                    </asp:TextBox>
                    <br />
                    <asp:Label ID="lblSalaryBreakDown" runat="server" Text=""></asp:Label>
                </dd>
                 <dt>
                    <asp:Label ID="Label6" runat="server" Text="Advance Salary: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtAdvanceSalary" class="txt medium-input" runat="server" Text="0" >
                    </asp:TextBox>
                </dd>
                 <dt>
                    <asp:Label ID="Label8" runat="server" Text="Security Money: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtSecurityMoney" class="txt medium-input" runat="server" Text="0" >
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="Label7" runat="server" Text="Remaining Salary: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtRemainingSalary" class="txt medium-input" runat="server" Text="0">
                    </asp:TextBox>
                </dd>
                <dt>
                     <asp:Label ID ="lblEmpPortionFundText" runat = "server" Text ="Emp Portion Fund :" Visible ="false"></asp:Label>
                </dt>
                <dd>
                    <asp:Label ID ="lblEmpPortionFund" runat = "server" Text ="0" Visible ="false"></asp:Label>
                </dd>

                <dt>
                    <asp:Label ID ="lblReturnFundToCompanyText" runat = "server" Text ="Return Fund :" Visible ="false"></asp:Label>
                </dt>
                <dd>
                    <asp:Label ID ="lblReturnFundToCompany" runat = "server" Text ="0" Visible ="false"></asp:Label>
                </dd>

                <dt>
                    <asp:Label ID="lblResignDescription" runat="server" Text="Description: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtResignDescription" class="txt medium-input" runat="server" Text="">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvResignDescription" runat="server" ValidationGroup="resignGroup"
                        Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Description is empty."
                        ForeColor="Red" ControlToValidate="txtResignDescription"></asp:RequiredFieldValidator>
                </dd>
                <dt>
                    <asp:Label ID="lblResignDate" runat="server" Text="Resign Date: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtResignDate" class="txt medium-input" runat="server" Text="" AutoPostBack = "true" OnTextChanged ="txtResignDate_OnTextChanged">
                    </asp:TextBox>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="calendarResignDate" runat="server" TargetControlID="txtResignDate">
                    </ajaxToolkit:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="resignGroup"
                        Display="Dynamic" SetFocusOnError="true" Text="*" ErrorMessage="Invalid date."
                        ForeColor="Red" ControlToValidate="txtResignDate"></asp:RequiredFieldValidator>
                </dd>
                <dt>Final Amount to WithDraw</dt>
                <dd>
                    <asp:Label ID="txtFinalAmountToWithDraw" runat="server" Text="0"></asp:Label>
                    <asp:TextBox ID="txtAmountToPay" runat="server" Text="0"  AutoPostBack="true"
                        ontextchanged="txtAmountToPay_TextChanged"></asp:TextBox>
                    <asp:Label ID="lblPaidAmount" runat="server" Text="0"></asp:Label>
                </dd>
                <dt></dt>
                <dd>
                    <asp:DropDownList ID="ddlAccountForMoney" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlAccountForMoney_SelectedIndexChanged" >
                        <asp:ListItem value="1">Cash in hand</asp:ListItem>
		                <asp:ListItem value="2">Cash at Bank</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="hfEmployeeID" runat="server" />
                    <asp:HiddenField ID="hfEmployeeNo" runat="server" />
                    <asp:HiddenField ID="hfEmployeeName" runat="server" />

                    <asp:HiddenField ID="hfUserTypeID" runat="server" />
                    <asp:HiddenField ID="hfUserID" runat="server" />
                    <asp:HiddenField ID="hfUserNo" runat="server" />
                    <asp:HiddenField ID="hfUserName" runat="server" />

                    <asp:HiddenField ID="hfHeadIDMoney" runat="server" />
                    
                    <br />Head Name: <asp:Label ID="lblHeadNameMoney" runat="server" Text=""></asp:Label>
                    <br />
                    <p id="cashAtBank" runat="server" visible="false">
                    Check No:<asp:TextBox ID="txtCUCCheckNo" class="txt medium-input" runat="server" Text=""></asp:TextBox>
                    <br />Check date:<asp:TextBox ID="txtCUCCheckDate" class="txt medium-input" runat="server" Text=""></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtCUCCheckDate">
                                </ajaxToolkit:CalendarExtender>
                    <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlAccountForMoney_SelectedIndexChanged">
                    </asp:DropDownList>
                    </p>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnSave" Visible="false" class="button button-blue" runat="server" Text="Save" OnClick="btnSave_Click" />
                </dd>
                <dt>
                </dt>
                <dd>
                     <div class="inner-content">
                   
                    <asp:GridView ID="gvACC_Journal" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblHeadID" runat="server" Text='<%#Eval("HeadName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Debit">
                                <ItemTemplate>
                                    <asp:Label ID="lblDebit" runat="server" Text='<%#Eval("Debit") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Credit">
                                <ItemTemplate>
                                    <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                   <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%#Eval("JournalID") %>' OnClick="lbDeleteJournal_Click" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>                    
                    <div >
                        <div >
                        <br />
                            <asp:Label ID="lblMessageAdvanceSalaryIsBigger" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnJournalEntry" class="button button-blue" runat="server" Text="Submit"
                            Visible="false" OnClick="btnJournalEntry_Click" />
                            </div>
                    </div>
                    </div>
                </dd>
            </dl>
        </div>
    </div>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
