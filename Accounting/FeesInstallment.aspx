<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="FeesInstallment.aspx.cs" Inherits="AdminSTD_Fees" Title="Students fee" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
    <style type="text/css">
    #tblFeesMaster td{padding:5px;}
    .gridTextBox{font-family:Verdana;}
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="pnInstallment" runat="server">
        <ContentTemplate>
        <div class="content-box" id="divSearchStudent" runat="server">
                <div class="header">
                    <h3>
                        Student Fees</h3>
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
                            <td colspan="2">
                                <asp:TextBox ID="txtStudentCodeSearch" class="txt small-input" runat="server" Text=""></asp:TextBox>
                               
                            <asp:Button ID="btnSearchStudent" class="button button-blue" runat="server" Text="Search"
                                    OnClick="btnSearchStudent_Click" />
                                <asp:HiddenField ID="hfIsRefund" runat="server" value="0"/>
                                
                                   Total unpaid :<asp:Label ID="lblTotalAllUnpaidAmount" ForeColor="Red" Font-Size="30px" runat="server" Text="0"></asp:Label>
                            </td> 
                            <td>
                           </td>
                        </tr>
                        <tr>
                            <td>
                                Program :
                            </td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlCourseIDReceived" runat="server">
                                </asp:DropDownList>
                            
                               

                           </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td>
                                
                                <asp:HiddenField ID="hfStudentID" runat="server" />
                                <asp:Button ID="btnAddNewInsatallation" runat="server" 
                                    Text="Add New Fess (List)" onclick="btnAddNewInsatallation_Click" class="button button-blue"  />
                            </td>
                            <td colspan="2">
                                <asp:Label ID="lblTest" runat="server"></asp:Label>
                                <asp:Label ID="lblInstallmentSearchMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        
                    </table>
               <%-- </div>
            </div>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Fees details</h3>
                </div>
                <div class="inner-form">--%>
                    <!-- error and information messages -->
                    <dl id="divFeesDetailsPerStudent" runat="server" visible="false">
                    <dt>
                        &nbsp;
                    </dt>
                    <dd>
                        &nbsp;
                       
                             
                    </dd>
                        <dt>
                            <asp:GridView ID="gvSTD_SubjectStudent" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                           
                            <asp:TemplateField HeaderText="Course">
                                <ItemTemplate>
                                    <asp:Label ID="lblCourse" runat="server" Text='<%#Eval("CourseName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubjectID" runat="server" Text='<%#Eval("SubjectName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete"  >
                                <ItemTemplate>
                                    <%--<asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("SubjectStudentID") %>'
                                        AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />--%>
                                    <asp:ImageButton runat="server" ID="lbDelete" Visible='<%#Eval("IsActive") %>' CommandArgument='<%#Eval("SubjectStudentID") %>'  OnClientClick="return confirm('Are You Sure To Delete?')"
                                        OnClick="lbDeleteStudentSubject_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                        </dt>
                        <dd>&nbsp;
                            <asp:Panel ID="pnStudentDetails" runat="server" Visible="false">
                        <div class="inner-content" style="overflow: scroll;">
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
                        </dl>
                        </div>
                        </div>
            <div class="content-box" id="divAddNewInstallationProcess" runat="server" visible="false">
                <div class="header">
                    <h3>
                        Add new fees (list)</h3>
                </div>
                <div class="inner-form">
                <dl>
                        
                        <dt>
                            <asp:Label ID="Label3" runat="server" Text="Fees Type: "></asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlAccountID" runat="server" AutoPostBack="true"
                                onselectedindexchanged="ddlAccountID_SelectedIndexChanged"></asp:DropDownList>
                        </dd>
                        <dt id="dtPerSubjectfee" runat="server">
                            <asp:Label ID="Label4" runat="server" Text="Subject/Paper: "></asp:Label>
                        </dt>
                        <dd id="ddPerSubjectfee" runat="server">
                             <asp:DropDownList ID="ddlSubjectID" runat="server" >
                                </asp:DropDownList>
                            <asp:TextBox ID="txtPerSubject" runat="server" Text="20000"></asp:TextBox>  
                                <asp:Button ID="btnAddSubjectStudent" runat="server" Text="Add Paper/Subject" 
                                    onclick="btnAddSubjectStudent_Click" />
                            <asp:HiddenField ID="hfSubjects" runat="server" />
                            <asp:TextBox ID="txtRemarkForReceipt" runat="server" TextMode="MultiLine" Height="75px" 
                                 Width="366px"></asp:TextBox>
                        </dd>
                       <dt id="initialPaymentlbl" runat="server">
                            <asp:Label ID="Label1" runat="server" Text="Admission Fee: "></asp:Label>
                        </dt>
                        <dd id="initialPaymentTxt" runat="server" >
                            <asp:TextBox ID="txtInitialPaymentAmount" class="txt small-input" runat="server" Text="30000"  AutoPostBack="true" ontextchanged="txtCalculateAmount_TextChanged"></asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblNoOfInstallment" runat="server" Text="No of Installment: " ></asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtNoOfInstallment" class="txt small-input" runat="server" Text="1" AutoPostBack="true" ontextchanged="txtCalculateAmount_TextChanged">
                            </asp:TextBox>
                        </dd>
                        
                        <dt>
                            <asp:Label ID="lblInstallmentDuration" runat="server" Text="Payment Duration: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtInstallmentDuration" class="txt small-input" runat="server" Text="1">
    </asp:TextBox><span id="spanInstalationDuration" runat="server">&nbsp;Months</span>
                        </dd>
                        <dt style="display:none;">
                            <asp:Label ID="lblInstallmentAmount" runat="server" Text="Amount per installment: "></asp:Label>
                        </dt>
                        <dd style="display:none;">
                            <asp:TextBox ID="txtInstallmentAmount" class="txt small-input" runat="server" Text="0" AutoPostBack="true" ontextchanged="txtCalculateAmount_TextChanged">
    </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount: "></asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtTotalAmount" class="txt small-input" runat="server" Text="0" AutoPostBack="true"
                                ontextchanged="txtTotalAmount_TextChanged" >
    </asp:TextBox>
                        </dd>
                        
                        <dt>
                            <asp:Label ID="lblDiscount" runat="server" Text="Discount: ">
                        </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtDiscount" class="txt small-input" runat="server" Text="0" 
                                AutoPostBack="true" ontextchanged="txtDiscount_TextChanged" >
                            </asp:TextBox>

                        </dd>
                        <dt>
                            <asp:Label ID="Label2" runat="server" Text="Total Amount Need to Pay: ">
                        </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtTotalAmountNeedToPay" class="txt small-input" runat="server" Text="">
                            </asp:TextBox>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnGridGenerator" class="button button-blue" runat="server" Text="Generate the List"
                                OnClick="btnGridGenerator_Click" />
                            <asp:Label ID="lblDiscountMessage" runat="server" Text=""></asp:Label>
                        </dd>
                        <dt style="display:none;">
                            <asp:Label ID="lblStudentID" runat="server" Text="Student Code: ">
                        </asp:Label>
                        </dt>
                        <dd style="display:none;">
                            <asp:DropDownList ID="ddlStudentID" runat="server" Visible="false">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtStudentCode" runat="server" class="txt small-input"></asp:TextBox>
                            <asp:Button ID="btnVarify" Text="Verify ID" runat="server" class="button button-blue"
                                OnClick="btnVarify_OnClick" />
                            
                        </dd>
                        <dt style="display: none;">
                            <asp:Label ID="lblCourseID" runat="server" Text="Course: ">
    </asp:Label>
                        </dt>
                        <dd style="display: none;">
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
                    
                 <%--   
                </div>
            </div>
            <div class="content-box" id="divAddNewInstallment" runat="server">
                <div class="header">
                    <h3>
                        Add more installment</h3>
                </div>
                <div class="inner-form">--%>
                <dt >&nbsp;</dt>
                        <dd>&nbsp;
                        <b ID="bGenerateInstallationFees" runat="server">Installment # 0 is the initial payment.. Others are periodic Installemnt.</b>
                        <div ID="divAddNewInstallment" runat="server">

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
                                    <asp:Label ID="lblInstallmentNo" Text='<%# Container.DataItemIndex + 1 -1 %>' runat="server"></asp:Label>
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
                                    <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("Amount")  %>' CssClass="gridTextBox" AutoPostBack="true"
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
                    </asp:GridView></div>
                    </dd>
                        <dt>&nbsp;</dt>
                        <dd>
                            <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:HiddenField ID="hfIsAdmissionFees" runat="server" Value="0"/>
                        </dd>
                    </dl>
                </div>
            </div>
            
        
            <div class="content-box" id="divShowInstallment" runat="server">
                <div class="header">
                    <h3>
                       Fees List</h3>
                    
                </div>
                <div class="inner-form" style="overflow: scroll">
                    <asp:Label ID="lblMessageForList" runat="server" Text="" Visible="false"></asp:Label>
                    <br />
                     <asp:GridView ID="gvSTD_FeesMaster" class="gridCss" runat="server" 
                        AutoGenerateColumns="false" CssClass="gridCss" ShowHeader="false" GridLines="Horizontal"
                        onrowdatabound="gvSTD_FeesMaster_RowDataBound">
	 	 	                <Columns>
                                <asp:TemplateField >
                                <ItemTemplate>
                                    <table cellpadding="5" style="width:600px;">
                                    <tr>
                                        <td style="border-top:1px solid Black;padding-top:5px;">
                                             <table cellpadding="5">
                                             <tr>
                                                    <td >
                                                        </td><td><a target="_blank" href='FeesInstallmentEdit.aspx?FeesMasterID=<%#Eval("FeesMasterID") %>&StudentID=<%#Eval("StudentID") %>&FeesTypeID=<%#Eval("FeesTypeID") %>&CourseID=<%#Eval("CourseID") %>'>Edit</a></asp:Label>                                                        
                                                   </td></tr>
                                                    <tr>
                                                    <td >
                                                        Fees Type:</td><td><asp:Label ID="lblFeesTypeID" runat="server" Text='<%#Eval("FeesTypeName") %>'></asp:Label>                                                        
                                                   </td></tr><tr><td>
                                                      Program:</td><td><asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                                                    </td></tr><tr><td>
                                                        Total payment:</td><td><asp:Label ID="lblTotalPayment" runat="server" Text='<%#Eval("TotalPayment") %>'></asp:Label>
                                                    </td></tr><tr><td>
                                                        Discount:</td><td><asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'></asp:Label>
                                                    </td></tr><tr style="Color:Green;"><td>
                                                        Paid Amount:</td><td><asp:Label ID="lblTotalPaidAmount" runat="server" Text='<%#Eval("ExtraField1") %>'></asp:Label>
                                                     </td></tr><tr style="Color:Red;"><td>
                                                        Due Amount:</td><td><asp:Label ID="lblDueAmount" runat="server" ></asp:Label>
                                                     </td></tr><tr style="Color:Blue;"><td>
                                                        Unpaid Amount:</td><td><asp:Label ID="lblUnpaidAmount" runat="server" ></asp:Label>
                                                     </td></tr><tr style="Color:Purple;"><td>
                                                     Total Unpaid Amount:</td><td ><asp:Label ID="lblTotalUnPaidAmount" Font-Size="30px" runat="server" Text='<%#Eval("ExtraField2") %>'></asp:Label>
                                                    </td></tr><tr><td>
                                                    Total Amount:</td><td><asp:Label ID="lblTotalPaymentNeedtoPay" runat="server" Text='<%#Eval("TotalPaymentNeedtoPay") %>'></asp:Label>
                                                    
                                                   
                                                    <%--<td>
                                                        <asp:Label ID="lblSubmissionDate" runat="server" Text='<%#Eval("SubmissionDate") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSubmitedDate" runat="server" Text='<%#Eval("SubmitedDate") %>'></asp:Label>
                                                    </td>--%>
                                                    <%--</td>
                                                    <td style="display:none;">--%>
 	                                                        <asp:Label ID="lblPaymentStatusID" Visible="false" runat="server" Text='<%#Eval("PaymentStatusID") %>'></asp:Label>
                                                            
                                                            <asp:HiddenField ID="hfCourseID" runat="server" Value='<%#Eval("CourseID") %>'/>
                                                            <asp:HiddenField ID="hfFeesMasterID" runat="server" Value='<%#Eval("FeesMasterID") %>'/>
                                                            <asp:HiddenField ID="hfFeesTypeID" runat="server" Value='<%#Eval("FeesTypeID") %>'/>
                                                            <asp:HiddenField ID="hfStudentID" runat="server" Value='<%#Eval("StudentID") %>'/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        <asp:GridView ID="gvFeesShow" class="gridCss" runat="server" AutoGenerateColumns="false"
                                            ShowFooter="false" CssClass="tabel_input">
                                            <HeaderStyle CssClass="heading" />
                                            <RowStyle CssClass="row" />
                                            <AlternatingRowStyle CssClass="altrow" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Fees #">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallmentNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:HiddenField runat="server" ID="hfFeesID" Value='<%# Eval("FeesID")  %>' />
                                                        <asp:TextBox ID="txtSubmissionDate" runat="server" Width="80px" ReadOnly="true" Text='<%# Eval("SubmissionDate", "{0:dd MMM yyyy}")  %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <%--<FooterTemplate>
                                                        <asp:Label ID="lblPaid" Text="PaidAmount=" runat="server"></asp:Label><br />
                                                        <asp:Label ID="lblUnpaid" Text="UnpaidAmount=" runat="server"></asp:Label>
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Paid Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPaidAmount" runat="server" Text='<%# Eval("Remarks")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unpaid Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnpaidAmount" runat="server" Text='<%# Eval("UnpaidAmount")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtListAmount" runat="server" Text='<%# Eval("Amount")  %>' Width="80px" ReadOnly="true"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <%--<FooterTemplate>
                                                        <asp:Label ID="lblPaidAmount" runat="server"></asp:Label><br />
                                                        <asp:Label ID="lblUnpaidAmount" runat="server"></asp:Label>
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                               
                                                <asp:TemplateField HeaderText="Paid?">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkIspaid" Enabled="false" runat="server" Checked='<%# Eval("IsPaid")  %>' Visible="false"/>
                                                        <asp:Label ID="lblPaymentStatus" runat="server" Text='<%# Eval("PaymentStatus")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField>
                                                    <ItemTemplate>--%>
                                                        <%--<asp:Button runat="server" class="button button-blue" ID="lbPaid" Text="Pay" Visible='<%# Eval("IsEnabled")  %>'
                                                            CommandArgument='<%#Eval("FeesID") %>' OnClick="lbPaid_Click" />--%>
                                                        <%--<asp:ImageButton runat="server" ID="lbDelete" Visible='<%# Eval("IsEnabled")  %>'
                                                            CommandArgument='<%#Eval("FeesID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                                            ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />--%>
                                                    <%--</ItemTemplate>
                                                </asp:TemplateField>--%>
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
                                       
                                        <asp:Label ID="lblMessage" Text="Installment # 0 is the initial payment.. Others are periodic Installemnt." runat="server"></asp:Label>
                                        
                                        <asp:GridView ID="gvFeesShowForInstallment" class="gridCss" runat="server" AutoGenerateColumns="false"
                                            ShowFooter="false" CssClass="tabel_input">
                                            <HeaderStyle CssClass="heading" />
                                            <RowStyle CssClass="row" />
                                            <AlternatingRowStyle CssClass="altrow" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Installment #">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInstallmentNo" Text='<%# Container.DataItemIndex + 1 -1 %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:HiddenField runat="server" ID="hfFeesID" Value='<%# Eval("FeesID")  %>' />
                                                        <asp:TextBox ID="txtSubmissionDate" runat="server" Width="80px" ReadOnly="true" Text='<%# Eval("SubmissionDate", "{0:dd MMM yyyy}")  %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                    <%--<FooterTemplate>
                                                        <asp:Label ID="lblPaid" Text="PaidAmount=" runat="server"></asp:Label><br />
                                                        <asp:Label ID="lblUnpaid" Text="UnpaidAmount=" runat="server"></asp:Label>
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Paid Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPaidAmount" runat="server" Text='<%# Eval("Remarks")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unpaid Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnpaidAmount" runat="server" Text='<%# Eval("UnpaidAmount")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtListAmount" runat="server" Text='<%# Eval("Amount")  %>' Width="80px" ReadOnly="true"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <%--<FooterTemplate>
                                                        <asp:Label ID="lblPaidAmount" runat="server"></asp:Label><br />
                                                        <asp:Label ID="lblUnpaidAmount" runat="server"></asp:Label>
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                
                                                
                                                <asp:TemplateField HeaderText="Paid?">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkIspaid" Enabled="false" runat="server" Checked='<%# Eval("IsPaid")  %>' Visible="false"/>
                                                        <asp:Label ID="lblPaymentStatus" runat="server" Text='<%# Eval("PaymentStatus")  %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField>
                                                    <ItemTemplate>--%>
                                                        <%--<asp:Button runat="server" class="button button-blue" ID="lbPaid" Text="Pay" Visible='<%# Eval("IsEnabled")  %>'
                                                            CommandArgument='<%#Eval("FeesID") %>' OnClick="lbPaid_Click" />--%>
                                                        <%--<asp:ImageButton runat="server" ID="lbDelete" Visible='<%# Eval("IsEnabled")  %>'
                                                            CommandArgument='<%#Eval("FeesID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                                            ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />--%>
                                                    <%--</ItemTemplate>
                                                </asp:TemplateField>--%>
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
                                        
                                        </td>
                                    </tr>
                                    </table>
                                </ItemTemplate>
                                </asp:TemplateField>
                                

                                <%--<asp:TemplateField HeaderText="Delete">
 	                                 <ItemTemplate>
 	                                 <asp:ImageButton runat="server" ID="lbSelect"  CommandArgument='<%#Eval("FeesMasterID") %>' AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png"
 	                                 />
 	                                 <asp:ImageButton runat="server" ID="lbDelete"  CommandArgument='<%#Eval("FeesMasterID") %>' OnClick="lbDelete_Click"  AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
 	                                  />
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
            <div class="content-box" id="divReceivePayment" runat="server" visible="false">
                <div class="header">
                    <h3>
                        Receive Fees</h3>
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
                                Amount :
                            </td>
                            <td>
                                <asp:TextBox ID="txtPaymentAmount" runat="server" CssClass="txt"></asp:TextBox>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr id="trFeesMaster" runat="server">
                            <td>
                                Select fess :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFeesMaster" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlFeesTypeID" runat="server" Visible="false">
                                </asp:DropDownList>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div style="display:none;"><asp:CheckBox ID="chkAddNewSemisterFee" runat="server" Text="Add a Semister fee after 6 months"/></div>
                                <br />
                                <asp:Button ID="btnPayAdvance" runat="server" Text="Pay" CssClass="button button-blue"
                                    OnClick="btnPayAdvance_Click" />
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                Refund Amount :
                            </td>
                            <td>
                                max(<asp:Label ID="lblRefundAmount" runat="server" Text=""></asp:Label> tk)
                                <asp:TextBox ID="txtRefundAmount" runat="server" CssClass="txt"></asp:TextBox>
                                <asp:HiddenField ID="hfRefundAmount" runat="server" value="0"/>

                                <br />
                                <asp:Button ID="btnRefund" runat="server" Text="Refund" CssClass="button button-blue"
                                    OnClick="btnRefund_Click" />
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </div>
           </div>
           <div class="content-box" id="divPaymentHistory" runat="server" visible="false">
                <div class="header">
                    <h3>
                        Payment History</h3>
                </div>
                <div class="inner-form">
                    <asp:Label ID="lblJournal" runat="server" Text=""></asp:Label>
                    
                    <br />
                    <asp:HiddenField ID="hfMaximumUnHistoryAmount" runat="server" />
                    Date:  <asp:TextBox ID="txtJournalHistoryDate" runat="server" Text=""></asp:TextBox>
                        <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajCal" runat="server" TargetControlID="txtJournalHistoryDate">
                        </ajaxToolkit:CalendarExtender>     
                    Amount 
                            <asp:TextBox ID="txtJournalHistoryAmount" runat="server"></asp:TextBox>
                    
                    <asp:Button ID="btnAddInstallment" class="button button-blue" runat="server" 
                                Text="Add Previous Payment History" 
                        onclick="btnAddInstallment_Click"/>
                </div>
           </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
