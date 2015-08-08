<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="JournalDoubleEntryCommon.aspx.cs" Inherits="AdminACC_Voucher" Title="Journal Double Entry" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Journal Double Entry</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt>----------->>>>------------- </dt>
                        <dd>
                            <b style="font-size: 20px; color: #0567AD;">
                                <asp:Label ID="lblToTransaction" runat="server" Text="Transaction entry"></asp:Label>
                            </b> -----------------------------------------------------------------------------
                        </dd>
                        <dt>
                            <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlDebitOrCredit" runat="server" Visible="false">
                                <asp:ListItem Value="Dr">Debit</asp:ListItem>
                                <asp:ListItem Value="Cr">Credit</asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblMessageOtherTransactiondt" runat="server" Text=" "></asp:Label>
                        </dt>
                        <dd>
                            <asp:Label ID="lblMessageOtherTransactiondd" runat="server" Text="For other Transaction If there are no (Cash / Check / Bank) Transaction then you can use this part multiple times for Journal Entry"></asp:Label>
                        </dd>
                        <dt>
                            <asp:Label ID="lblBasicAccountID" runat="server" Text="Account: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlBasicAccountID" runat="server" OnSelectedIndexChanged="ddlBasicAccountID_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <%--</dd>
                        <dt>
                            <asp:Label ID="lblSubBasicAccountID" runat="server" Text="Account: ">
                    </asp:Label>
                        </dt>
                        <dd>--%>
                            <asp:DropDownList ID="ddlSubBasicAccountID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubBasicAccountID_SelectedIndexChanged">
                            </asp:DropDownList>
                            <%--</dd>
                <dt>
                    <asp:Label ID="lblAccountID" runat="server" Text="Account : ">
         </asp:Label>
                </dt>
                <dd>--%>
                            <asp:DropDownList ID="ddlAccountID" runat="server">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="lblUserTypeID" runat="server" Text="User: "></asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlUserTypeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserTypeID_SelectedIndexChanged">
                            </asp:DropDownList>
                            <%--</dd>
                <dt>
                    <asp:Label ID="Label1" runat="server" Text="User: ">
    </asp:Label>
                </dt>
                <dd>--%>
                            <asp:DropDownList ID="ddlAccountingUser" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountingUser_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hfStudentID" runat="server" />
                            <asp:TextBox ID="txtStudentCode" runat="server" CssClass="txt small-input" Visible="false"
                                OnTextChanged="txtStudentCode_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                            <div runat="server" id="divNewCompany" visible="false">
                                <br />
                                <asp:TextBox ID="txtNewCompany" class="txt small-input" Visible="false" runat="server"
                                    Text=""></asp:TextBox></div>
                            <asp:Button ID="ibtnRefresh" Text="Add New Company" Visible="false" runat="server"
                                class="button button-blue" OnClick="addNewCompay_Click" />
                            <asp:ImageButton ID="ibtnRefreshOld" runat="server" Visible="false" ImageUrl="~/App_Themes/CoffeyGreen/images/Refresh.gif"
                                OnClick="ibtnRefresh_Click" />
                            <asp:Button ID="btnVarify" Text="Verify Student" runat="server" class="button button-blue"
                                OnClick="btnVarify_OnClick" Visible="false" />
                            <asp:Panel ID="pnStudentDetails" runat="server" Visible="false">
                                <div class="inner-content" style="overflow: scroll;">
                                    <%--<h1 class="heading" style="width: 100%">
                            Student Details</h1>--%>
                                    <table width="100%" class="tabel_input">
                                        <tr>
                                            <th class="heading" style="border-right: solid 1px #ccc; height: 25px">
                                                Name
                                            </th>
                                            <th class="heading" style="border-right: solid 1px #ccc; height: 25px">
                                                Contact
                                            </th>
                                            <th class="heading" style="height: 25px">
                                                Photo
                                            </th>
                                        </tr>
                                        <tr>
                                            <td style="border-left: solid 1px #ccc; height: 25px">
                                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblContact" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Image ID="imgStudent" runat="server" Height="70px" Width="70px"></asp:Image>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </dd>
                        <dt>
                            <asp:Label ID="lblHeadID" runat="server" Text="Account Head: "></asp:Label>
                        </dt>
                        <dd>
                            &nbsp;<asp:Label ID="lblHeadName" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfHeadID" runat="server" />
                        </dd>
                        <dt>
                            <asp:Label ID="lblVoucherNo" runat="server" Text="Amount: "></asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtAmount" class="txt small-input" runat="server" Text=""></asp:TextBox>
                            <asp:DropDownList ID="ddlDrCrOtherTransaction" runat="server" Visible="false" 
                                onselectedindexchanged="ddlDrCrOtherTransaction_SelectedIndexChanged" 
                                AutoPostBack="True">
                                <asp:ListItem Value="Dr">Debit</asp:ListItem>
                                <asp:ListItem Value="Cr">Credit</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Save" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                                OnClick="btnUpdate_Click" Visible="false" />
                            <asp:Label ID="lblUser" runat="server"></asp:Label>
                        </dd>
                        <dt>----------->>>>------------- </dt>
                        <dd>
                            <b style="font-size: 20px; color: #0567AD;">
                                <asp:Label ID="lblFromTransaction" runat="server" Text="Money entry"></asp:Label>
                            </b> ---------------------------------------------------------------------------------------
                        </dd>
                        <dt>
                            <asp:Label ID="Label3" runat="server" Text=" ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlDebitOrCreditMoney" runat="server" Visible="false">
                                <asp:ListItem Value="Dr">Debit</asp:ListItem>
                                <asp:ListItem Value="Cr">Credit</asp:ListItem>
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="Label5" runat="server" Text="Account : "></asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlAccountForMoney" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountForMoney_SelectedIndexChanged">
                                <asp:ListItem value="0">Select Account >></asp:ListItem>
		                        <asp:ListItem value="1">Cash in hand</asp:ListItem>
		                        <%--<asp:ListItem value="2">Cash at Bank(By cash)</asp:ListItem>--%>
		                        <asp:ListItem value="2">Cash at Bank</asp:ListItem>
		                        <asp:ListItem value="42">Check in Hand</asp:ListItem>
                            </asp:DropDownList>
                            <div id="divMoneyReceivibale" runat="server" visible="false">
                                <asp:HiddenField ID="hfcheckIDs" runat="server" />
                                <table id="Table1" runat="server" width="650px">
                                    <tr>
                                        <td style="width: 70px;">
                                            From / To
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCheckFrom" runat="server">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hfCheckFrom" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 70px;">
                                            Check Type
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkCashCheck" runat="server" Text="Cash Check?" Checked="true"
                                                AutoPostBack="true" OnCheckedChanged="chkCashCheck_CheckedChanged" />
                                            <div id="divPayToBank" runat="server" visible="false">
                                                CUC Bank Account<asp:DropDownList ID="ddlBankAccountID" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 70px;">
                                            Account #
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAccountNo" class="txt small-input" runat="server" Text=""></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Check #
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCheckNo" class="txt small-input" runat="server" Text=""></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Bank
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <div visible="false" runat="server" id="divNewBank">
                                                Enter New Bank Name:
                                                <asp:TextBox ID="txtNewBank" class="txt small-input" Visible="false" runat="server"
                                                    Text=""></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Branch
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtBranchInfo" class="txt small-input" runat="server" Text="" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCheckDate" class="txt small-input" runat="server" Text=""></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajCal" runat="server" TargetControlID="txtCheckDate">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divCUCBankAccount" runat="server" visible="false">
                                <asp:HiddenField ID="hfCUCCheck" runat="server" />
                                <table id="Table2" runat="server" width="650px">
                                    <tr>
                                        <td>
                                            Check #
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCUCCheckNo" class="txt medium-input" runat="server" Text=""></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCUCCheckDate" class="txt medium-input" runat="server" Text=""></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtCUCCheckDate">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </dd>
                        <dt>
                            <asp:Label ID="Label6" runat="server" Text="User Type: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlUserTypeIDMoney" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserTypeIDMoney_SelectedIndexChanged">
                               </asp:DropDownList>&nbsp;
                            <%--</dd>
                <dt>
                    <asp:Label ID="Label7" runat="server" Text="User: ">
    </asp:Label>
                </dt>
                <dd>--%><asp:Label ID="Label7" runat="server" Text=" "></asp:Label>
                            <asp:DropDownList ID="ddlAccountingUserMoney" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlAccountingUserMoney_SelectedIndexChanged">
                            </asp:DropDownList>
                            <div runat="server" id="divNewCompanyMoney" visible="false">
                                <br />
                                <asp:TextBox ID="txtNewCompanyMoney" class="txt small-input" Visible="false" runat="server"
                                    Text=""></asp:TextBox></div>
                            <asp:TextBox ID="txtStudentCodeMoney" runat="server" CssClass="txt small-input" Visible="false"
                                OnTextChanged="txtStudentCodeMoney_OnTextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:ImageButton ID="ibtnRefreshMoney" runat="server" Visible="false" ImageUrl="~/App_Themes/CoffeyGreen/images/Refresh.gif"
                                OnClick="ibtnRefreshMoney_Click" />
                            <asp:Button ID="btnMoneyVerify" Text="Verify ID" runat="server" class="button button-blue"
                                OnClick="btnMoneyVerify_OnClick" />
                        </dd>
                        <dt>
                            <asp:Label ID="Label8" runat="server" Text="Account Head: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            &nbsp;<asp:Label ID="lblHeadNameMoney" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hfHeadIDMoney" runat="server" />
                        </dd>
                        <dt>
                            <asp:Label ID="Label4" runat="server" Text="Amount: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtAmountMoney" class="txt small-input" runat="server" Text=""></asp:TextBox>
                            <asp:Button ID="btnMoneyAdd" class="button button-blue" runat="server" Text="Save"
                                OnClick="btnMoney_Click" />
                            <asp:Button ID="btnMoneyUpdate" class="button button-blue" runat="server" Text="Update"
                                OnClick="btnUpdate_Click" Visible="false" />
                            <asp:Label ID="lblUserMoney" runat="server"></asp:Label>
                        </dd>
                        <dt>----------->>>>------------- </dt>
                        <dd>
                            <b style="font-size: 20px; color: #0567AD;">Journal View</b> ---------------------------------------------------------------------------------------
                        </dd>
                    </dl>
                </div>
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
                                    <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("JournalID") %>'
                                        Visible="False" AlternateText="Edit" OnClick="lbSelectJournal_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <%--<asp:ImageButton runat="server" ID="ImageButton1" CommandArgument='<%#Eval("JournalID") %>' Visible='<%#Eval("IsNotCheck") %>'
                                AlternateText="Edit" OnClick="lbSelectJournal_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />--%>
                                    <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%#Eval("JournalID") %>' OnClick="lbDeleteJournal_Click" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfJournalID" runat="server" />
                    <asp:HiddenField ID="hfIsMoney" runat="server" />
                    Debit =
                    <asp:Label ID="lblDebit" runat="server" Text="0"></asp:Label>
                    <br />
                    Credit =
                    <asp:Label ID="lblCredit" runat="server" Text="0"></asp:Label>
                    <br />
                    <asp:Label ID="lblJournalEntry" runat="server" Text="Debit and credit amount need to be equal"></asp:Label>
                    <br />
                    Remarks:(for the Money recept of student fees)<asp:CheckBox ID="chkAddInMoneyReceipt" runat="server" Checked="true" Text="Print in Money Receipt"/>
                    <br />
                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="400px" Text=""></asp:TextBox>
                    <%--<br />
                    (Following subjects will be added with the Remarks text)
                    <br />
                    <asp:CheckBox ID="chkFA1" runat="server" Text="FA1"/>
                    <asp:CheckBox ID="chkMA1" runat="server" Text="MA1"/>
                    <asp:CheckBox ID="chkFA2" runat="server" Text="FA2"/>
                    <asp:CheckBox ID="chkMA2" runat="server" Text="MA2"/>
                    <asp:CheckBox ID="chkFAB" runat="server" Text="FAB"/>
                    <asp:CheckBox ID="chkFFA" runat="server" Text="FFA"/>
                    <asp:CheckBox ID="chkFMA" runat="server" Text="FMA"/>
                    <asp:CheckBox ID="chkFAU" runat="server" Text="FAU"/>
                    <asp:CheckBox ID="chkFTX" runat="server" Text="FTX"/>
                    <asp:CheckBox ID="chkFFM" runat="server" Text="FFM"/>
                    --%>
                    <div style="overflow:hidden; height:32px;">
                        <div style="float:right; margin-right:20px;">
                        <asp:Button ID="btnJournalEntry" class="button button-blue" runat="server" Text="Submit"
                            Visible="false" OnClick="btnJournalEntry_Click" />
                            </div>
                    </div>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
