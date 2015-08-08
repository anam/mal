<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="FeesInstallmentOld.aspx.cs" Inherits="AdminSTD_Fees" Title="Installment fee" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="pnInstallment" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Generate installment List</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt style="display: none;">
                            <asp:Label ID="lblFeesName" runat="server" Text="Fees Name: "></asp:Label>
                        </dt>
                        <dd style="display: none;">
                            <asp:TextBox ID="txtFeesName" class="txt large-input" runat="server" Text=""></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="Label1" runat="server" Text="Total # of payment: "></asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtNoOfInstallment" class="txt small-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="Label2" runat="server" Text="Payment Duration: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtInstallmentDuration" class="txt small-input" runat="server" Text="">
    </asp:TextBox>&nbsp;Days
                        </dd>
                        <dt>
                            <asp:Label ID="Label3" runat="server" Text="Amount: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtInstallmentAmount" class="txt small-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="Label4" runat="server" Text="Discount: ">
                        </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtDiscount" class="txt small-input" runat="server" Text="">
                    </asp:TextBox>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnGridGenerator" class="button button-blue" runat="server" Text="Generate the List"
                                OnClick="btnGridGenerator_Click" />
                        </dd>
                        <dt>
                            <asp:Label ID="lblStudentID" runat="server" Text="Student Code: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlStudentID" runat="server" Visible="false">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtStudentCode" runat="server" class="txt small-input"></asp:TextBox>
                            <asp:Button ID="btnVarify" Text="Verify ID" runat="server" class="button button-blue"
                                OnClick="btnVarify_OnClick" />
                            <asp:HiddenField ID="hfStudentID" runat="server" />
                            <asp:Label ID="lblTest" runat="server"></asp:Label>
                        </dd>
                        <dt>
                            <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCourseID" runat="server">
                            </asp:DropDownList>
                        </dd>
                        <dt style="display: none;">
                            <asp:Label ID="lblRowStatusID" runat="server" Text="Row Status: ">
                </asp:Label>
                        </dt>
                        <dd style="display: none;">
                            <asp:DropDownList ID="ddlRowStatusID" runat="server">
                            </asp:DropDownList>
                        </dd>
                        <dt style="display: none;">
                            <asp:Label ID="lblRemarks" runat="server" Text="Remarks: ">
    </asp:Label>
                        </dt>
                        <dd style="display: none;">
                            <asp:TextBox ID="txtRemarks" TextMode="MultiLine" class="txt textarea" runat="server"
                                Text="">
    </asp:TextBox>
                        </dd>
                        <dt style="display: none;">
                            <asp:Label ID="lblIsPaid" runat="server" Text="Is Paid: ">
    </asp:Label>
                        </dt>
                        <dd style="display: none;">
                            <asp:RadioButtonList ID="radIsPaid" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>True</asp:ListItem>
                                <asp:ListItem>False</asp:ListItem>
                            </asp:RadioButtonList>
                        </dd>
                    </dl>
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
                </div>
            </div>
            <div class="content-box" id="divAddNewInstallment" runat="server">
                <div class="header">
                    <h3>
                        Add more installment</h3>
                </div>
                <div class="inner-form">
                    <asp:GridView ID="gvFeesAdd" class="gridCss" runat="server" AutoGenerateColumns="false"
                        ShowFooter="true" OnRowDataBound="gvFeesAdd_OnRowDataBound" CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="" ControlStyle-CssClass="gridIteamCenter" Visible="false">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkSelect" />
                                    <asp:HiddenField runat="server" ID="hfFeesID" Value='<%# Eval("FeesID")  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Installment #">
                                <ItemTemplate>
                                    <asp:Label ID="lblInstallmentNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSubmissionDate" runat="server" Text='<%# Eval("SubmissionDate", "{0:dd MMM yyyy}")  %>'></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajCal" runat="server" TargetControlID="txtSubmissionDate">
                                    </ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotal" Text="TotalAmount=" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("Amount")  %>' AutoPostBack="true"
                                        OnTextChanged="txtAmount_OnTextChanged"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="ajFt" runat="server" FilterType="Numbers"
                                        TargetControlID="txtAmount">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Paid?" Visible="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIspaid" Enabled='<%# Eval("IsEnabled")  %>' runat="server" Checked='<%# Eval("IsPaid")  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbDeleteFees" CommandArgument='<%#Eval("FeesID") %>'
                                        OnClick="lbDeleteFees_Click" AlternateText="Delete" ToolTip="Delete" OnClientClick="return confirm('Are You Sure To Delete?')"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <dl>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        </dd>
                    </dl>
                </div>
            </div>
            <div class="content-box" id="divSearchStudent" runat="server">
                <div class="header">
                    <h3>
                        Receive Payment</h3>
                </div>
                <div class="inner-form">
                    <table width="100%">
                        <colgroup>
                            <col width="15%" />
                            <col width="35%" />
                            <col width="15%" />
                            <col width="35%" />
                        </colgroup>
                        <tr>
                            <td>
                                Student ID :
                            </td>
                            <td>
                                <asp:TextBox ID="txtStudentCodeSearch" class="txt small-input" runat="server" Text=""></asp:TextBox>
                            </td>
                            <td>
                                Amount :
                            </td>
                            <td>
                                <asp:TextBox ID="txtPaymentAmount" runat="server" CssClass="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Course ID :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCourseIDReceived" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblInstallmentSearchMessage" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnSearchStudent" class="button button-blue" runat="server" Text="Search"
                                    OnClick="btnSearchStudent_Click" />
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnPayAdvance" runat="server" Text="Pay Advance" CssClass="button button-blue"
                                    OnClick="btnPayAdvance_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-box" id="divReceivePayment" runat="server">
                <div class="header">
                    <h3>
                        Receive Payment</h3>
                </div>
                <div class="inner-form">
                    <dl>
                        <dt>Received Amount</dt>
                        <dd>
                            <asp:TextBox ID="txtReceivedAmount" class="txt small-input" runat="server" Text="">
    </asp:TextBox>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnPaymentReceive" class="button button-blue" runat="server" Text="Add"
                                OnClick="btnPaymentReceive_Click" />
                        </dd>
                    </dl>
                </div>
            </div>
            <div class="content-box" id="divShowInstallment" runat="server">
                <div class="header">
                    <h3>
                        List</h3>
                </div>
                <div class="inner-form" style="overflow: scroll">
                    <asp:Label ID="lblMessageForList" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:GridView ID="gvFeesShow" class="gridCss" runat="server" AutoGenerateColumns="false"
                        ShowFooter="true" OnRowDataBound="gvFeesShow_OnRowDataBound" CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Installment #">
                                <ItemTemplate>
                                    <asp:Label ID="lblInstallmentNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="hfFeesID" Value='<%# Eval("FeesID")  %>' />
                                    <asp:TextBox ID="txtSubmissionDate" runat="server" Width="80px" ReadOnly="true" Text='<%# Eval("SubmissionDate", "{0:dd MMM yyyy}")  %>'></asp:TextBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblPaid" Text="PaidAmount=" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblUnpaid" Text="UnpaidAmount=" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtListAmount" runat="server" Text='<%# Eval("Amount")  %>' Width="80px" ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblPaidAmount" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblUnpaidAmount" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Paid?">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIspaid" Enabled="false" runat="server" Checked='<%# Eval("IsPaid")  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" class="button button-blue" ID="lbPaid" Visible='<%# Eval("IsEnabled")  %>'
                                        CommandArgument='<%#Eval("FeesID") %>' Text="Pay" OnClick="lbPaid_Click" />
                                    <asp:ImageButton runat="server" ID="lbDelete" Visible='<%# Eval("IsEnabled")  %>'
                                        CommandArgument='<%#Eval("FeesID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Partial Amount">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPartiallyPaidAmount" runat="server" Visible='<%# Eval("IsEnabled")  %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reamining payment Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemainingSubmissionDate" runat="server" Visible='<%# Eval("IsEnabled")  %>'></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="paymentDateCalendar" runat="server" TargetControlID="txtRemainingSubmissionDate"
                                        Enabled="true">
                                    </ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button runat="server" Visible='<%# Eval("IsEnabled")  %>' class="button button-blue"
                                        ID="lbPartiallyPaid" CommandArgument='<%#Eval("FeesID") %>' Text="Partially Pay"
                                        OnClick="lbPartiallyPaid_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                    <dl>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                                OnClick="btnUpdate_Click" Visible="false" />
                        </dd>
                    </dl>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
