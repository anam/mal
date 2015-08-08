<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="ShowInstallment.aspx.cs" Inherits="AdminDisplaySTD_Fees" Title="Installments List" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        

    <div class="content-box">
        <div class="header">
            <h3>
                Search by Student Code</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>Student Code</dt>
                <dd>
                    <asp:TextBox ID="txtStudentID" class="txt medium-input" runat="server" Text="">
    </asp:TextBox>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnSearch" class="button button-blue" runat="server" Text="Search"
                        OnClick="btnSearch_Click" />
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                Installment</h3>
        </div>
        <div class="inner-content" style="overflow: scroll">
            <asp:GridView ID="gvSTD_Fees" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Student Name">
                        <ItemTemplate>
                            <asp:Label ID="lblStudentCode" Text='<%#Eval("StudentCode") %>' runat="server"></asp:Label>
                            <br />
                            <%--<a target="_blank" href='FeesInstallment.aspx?StudentID=<%#Eval("StudentID") %>&CourseID=<%#Eval("CourseID") %>'>--%>
                            <a target="_blank" href='../Student/AdminDetailsSTD_Student.aspx?ID=<%#Eval("StudentID") %>'>
                                <%#Eval("StudentName") %>
                            </a>
                            <br />
                            <%--<a style="font-size: 13px; color: Blue;" href='FeesInstallment.aspx?StudentID=<%#Eval("StudentID") %>&CourseID=<%#Eval("CourseID") %>'
                                target="_blank">
                                --%>
                                <%#Eval("CourseName")%>
                                <br />
                                <%#Eval("AccountName")%>
                            <%--</a>--%>
                            
                            <br />
                            <a href='mailTo:cuc@yahoo.com?Subject=Total Payment Details &body=Dear student your payment Details is given below %0A%0A Due: <%#Eval("FeesMasterDueAmount") %>%0A%0A Unpaid:<%#Eval("FeesMasterUnpaidAmount") %>%0A%0A Paid: <%#Eval("ExtraField1") %>%0A%0A%0A%0A Thanks %0A%0A//cuc ' target="_blank">Email</a>
                        
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--
                    <asp:TemplateField HeaderText="Student Code">
                        <ItemTemplate>
                            
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Photo">
                        <ItemTemplate>
                            <asp:Literal ID="ltPhone" Text='<%#Eval("Mobile") %>' runat="server"></asp:Literal>
                            <br />
                            <asp:Image ID="Image1" Width="100px" runat="server" ImageUrl='<%#Eval("PPSizePhoto") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Total Unpaid Amount">
                        <ItemTemplate>
                            <table border="0">
                                <tr style="color: Red">
                                    <td style="padding: 0px; width: 90px;">
                                        Due
                                    </td>
                                    <td style="padding: 0px; text-align: right; width: 90px;">
                                        <%#Eval("FeesMasterDueAmount") %>
                                    </td>
                                </tr>
                                <tr style="color: Blue">
                                    <td style="padding: 0px;">
                                        Unpaid
                                    </td>
                                    <td style="padding: 0px; text-align: right;">
                                        <%#Eval("FeesMasterUnpaidAmount") %>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="2" style="padding:0px;">---------------------------------</td>
                                </tr>--%>
                                <tr style="color: Blue">
                                    <td style="padding: 0px;">
                                        <span style="color: Red;">Due</span> + Unpaid
                                    </td>
                                    <td style="padding: 0px; text-align: right;">
                                        <%#Eval("ExtraField2") %>
                                    </td>
                                </tr>
                                <tr style="color: Green">
                                    <td style="padding: 0px;">
                                        Paid
                                    </td>
                                    <td style="padding: 0px; text-align: right;">
                                        <%#Eval("ExtraField1") %>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td colspan="2" style="padding:0px;">---------------------------------</td>
                                </tr>--%>
                                <tr>
                                    <td style="padding: 0px;">
                                        Total Amount
                                    </td>
                                    <td style="padding: 0px; text-align: right;">
                                        <%#Eval("TotalPaymentNeedtoPay") %>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="paging"  ID="divPaggingFeesMaster" runat="server" >
	<div class="viewpageinfo">
	<%--View 1 -10 of 13--%>
	Show
	</div>
	<asp:DropDownList ID="ddlPageSizeFeesMaster" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSizeFeesMaster_Changed">
	<asp:ListItem Text="50" Value="50" />
	<asp:ListItem Text="150" Value="150" />
	<asp:ListItem Text="200" Value="200" />
	<asp:ListItem Text="500" Value="500" />
	 </asp:DropDownList>
	<div class="pagelist">
	 <asp:Repeater ID="rptPagerFeesMaster" runat="server">
	<ItemTemplate>
	<asp:LinkButton ID="lnkPage" runat="server" Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' Enabled = '<%# Eval("Enabled") %>' OnClick = "PageFeesMaster_Changed"></asp:LinkButton>
	</ItemTemplate>
	</asp:Repeater>
	</div>
	</div>
        </div>
    </div>
     <div class="content-box">
        <div class="header">
            <h3>
                Bounched Checks</h3>
        </div>
        <div class="inner-content">
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" Font-Size="20px"></asp:Label>
            <asp:GridView ID="gvACC_Check" class="gridCss" runat="server" AutoGenerateColumns="false"  OnRowDataBound="gvACC_Check_OnRowDataBound"
                CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    <asp:TemplateField HeaderText="Check" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblCheckID" runat="server" Text='<%#Eval("CheckID") %>'>                                
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Check No">
                        <ItemTemplate>
                        <asp:HiddenField ID="hfExtraField1" runat="server" Value='<%#Eval("ExtraField1") %>'/>
                            Check # :
                            <asp:Label ID="lblCheckNo"  runat="server" Text='<%#Eval("CheckNo") %>'></asp:Label>
                            <br />
                            Account # :
                            <asp:Label ID="lblBankAccountNo" runat="server" Text='<%#Eval("BankAccountNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bank">
                        <ItemTemplate>
                            Bank :
                            <asp:Label ID="lblBankID" runat="server" Text='<%#Eval("AccountingUserName") %>'></asp:Label>
                            <br />
                            Branch:<asp:Label ID="lblBranchNOtherDetails" runat="server" Text='<%#Eval("BranchNOtherDetails") %>'></asp:Label>
                            <br />
                            Amount:<asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bank">
                        <ItemTemplate>
                            <b>Check in Hand:</b><br /><%#Eval("WhomeGiven")%><br /><b>Who gave:</b><br /><%#Eval("WhoGave")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Checked Date">
                        <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Text="Cash Check?" Checked='<%#Eval("IsCashCheck") %>' />
                            <asp:HiddenField ID="hfCheckID" runat="server" Value='<%#Eval("CheckID") %>' />
                            <asp:HiddenField ID="hfCheckOfCUCBankID" runat="server" Value='<%#Eval("ExtraField1") %>' />
                            <asp:HiddenField ID="hfToWhomItIsGivenHeadID" runat="server" Value='<%#Eval("ExtraField2") %>' />
                            <asp:HiddenField ID="hfToWhomItIsGivenJournalID" runat="server" Value='<%#Eval("ExtraField3") %>' />
                            <asp:HiddenField ID="hfWhoGivesHeadID" runat="server" Value='<%#Eval("ExtraField4") %>' />
                            <br />
                            <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("ExtraField5") %>'>
 	                            </asp:Label>
                                <br /><asp:Label ID="lblRowStatusID" runat="server" Text='<%#Eval("RowStatusName") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Process">
                        <ItemTemplate>
                            <%--<asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("CheckID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("CheckID") %>'
                                OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                            <br />--%>
                            
                            <asp:HyperLink ID="hlinkProcess" runat="server" Visible='<%#Eval("IsVisibleProcess") %>'>Process</asp:HyperLink>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Panel ID="pnPaging" runat='server'>
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
            </asp:Panel>
        </div>
    </div>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
