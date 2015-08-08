<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplaySTD_Student.aspx.cs" Inherits="AdminDisplaySTD_Student"
    Title="Search Student" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="upSearchStudent" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Search Student</h3>
                </div>
                <div class="inner-content" style="width: 98%">
                    <table>
                        <tr>
                            <td>
                                Student Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtStudentName" runat="server" CssClass="txt medium-input" Width="75%"></asp:TextBox>
                            </td>
                            <td>
                                Student Code:
                            </td>
                            <td>
                                <asp:TextBox ID="txtStudentCode" runat="server" CssClass="txt medium-input" Width="75%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Batch No:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBatchID" runat="server" CssClass="txt medium-input" Width="75%"></asp:DropDownList>
                               
                            </td>
                            <td>
                                Mobile:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="txt medium-input" Width="75%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                From Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txt medium-input" Width="75%"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal" runat="server" TargetControlID="txtFromDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                To Date:
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txt medium-input" Width="75%"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding-left: 200px">
                                <asp:Button ID="btnSeach" runat="server" class="button button-blue" Text="Search"
                                    OnClick="btnSeach_OnClick" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Show Student</h3>
                </div>
                <div class="inner-content" style="overflow: scroll">
                    <asp:GridView ID="gvSTD_Student" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Student Name">
                                <ItemTemplate>
                                <asp:Label ID="lblStudentCode" Font-Bold="true" ForeColor="Red" runat="server" Text='<%#Eval("StudentCode") %>'>
                                    </asp:Label><br />
                                    <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PP Size Photo">
                                <ItemTemplate>
                                    <asp:Image ID="lblPPSizePhoto" runat="server" ImageUrl='<%#Eval("PPSizePhoto") %>'
                                        Height="70px" Width="70px"></asp:Image>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Student Code">
                                <ItemTemplate>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Contact Info">
                                <ItemTemplate>
                                    <%--Tel:
                                    <asp:Label ID="lblTelephone" runat="server" Text='<%#Eval("Telephone") %>'></asp:Label>--%>
                                    Mob:
                                    <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile") %>'> </asp:Label>
                                    <br />Email:
                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="DOB">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateofBirth" runat="server" Text='<%#Eval("DateofBirth","{0:dd MMM yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="M/F">
                                <ItemTemplate>
                                    <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Registration Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegistrationDate" runat="server" Text='<%#Eval("AddedDate","{0:dd MMM yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Registration No">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegistrationNo" runat="server" Text='<%#Eval("RegistrationNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Process">
                                <ItemTemplate>
                                    <%--<a href='../Accounting/FeesInstallment.aspx?StudentCode=<%#Eval("StudentCode") %>' target="_blank">Payment_Details</a>
                                    <br />--%>
                                    <a href='../Class/StudentClassSubjectAdd.aspx?StudentCode=<%#Eval("StudentCode") %>'  target="_blank">Assign_Class</a>
                                <br />
                                    <a href='../Class/AttendantSheetAttendedReportPerStudent.aspx?studentID=<%#Eval("StudentID") %>'  target="_blank">Attendence</a>

                                
                             </ItemTemplate>
                            </asp:TemplateField>       
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("StudentID") %>'
                                        AlternateText="Edit" OnClick="lbSelect_Click" ToolTip="Edit" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <%--<asp:ImageButton runat="server" ID="lbDelete" ToolTip="Delete" CommandArgument='<%#Eval("StudentID") %>'
                                        OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"
                                        OnClientClick="return confirm('Are You Sure, You Want To Delete?')" />--%>
                                    <asp:LinkButton ID="lnkDetails" runat="server" Text="Details" CommandArgument='<%#Eval("StudentID") %>'
                                        OnClick="lnkDetails_OnClick"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="paging" id="pageID" runat="server">
                        <div class="viewpageinfo">
                            <%--View 1 -10 of 13--%>
                            Show
                        </div>
                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                            <asp:ListItem Text="50" Value="50" />
	                        <asp:ListItem Text="150" Value="150" />
	                        <asp:ListItem Text="200" Value="200" />
	                        <asp:ListItem Text="500" Value="500" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
