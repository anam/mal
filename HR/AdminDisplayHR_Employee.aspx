<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayHR_Employee.aspx.cs" Inherits="AdminDisplayHR_Employee"
    Title="Display Employee" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Search Employee</h3>
                </div>
                <div class="inner-content">
                    <%-- <asp:UpdatePanel ID="updatePanel" runat = "server" UpdateMode = "Conditional">
         <ContentTemplate>--%>
                    <%--<div>
            </div>--%>
                    <dl>
                        <dt>
                            <asp:Label ID="Label6" runat="server" Text="Employee ID: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmployeeNo" runat="server" Text="">
                            </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="lblEmployeeNameSer" runat="server" Text="Employee Name: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtEmployeeNameSer" runat="server" Text="">
                            </asp:TextBox>
                        </dd>
                        <dt>
                            <asp:Label ID="Label1" runat="server" Text="Employee Type: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlEmployeeTypeSer" runat="server" class="small-input">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="Label5" runat="server" Text="Department: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlDepartment" runat="server" class="small-input" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlDepartment_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="Label2" runat="server" Text="Designation Name: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlDesignationNameSer" runat="server" class="small-input">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="Label3" runat="server" Text="Jonining From Date: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtJoiningFromDate" runat="server" ReadOnly="false" class="small-input"
                                Text="">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="calendarJoiningDate" runat="server"
                                TargetControlID="txtJoiningFromDate">
                            </ajaxToolkit:CalendarExtender>
                            &nbsp; &nbsp;
                            <asp:Label ID="Label4" runat="server" Text="To Date: "></asp:Label>
                            <asp:TextBox ID="txtJoiningToDate" runat="server" ReadOnly="false" class="small-input"
                                Text="">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server"
                                TargetControlID="txtJoiningToDate">
                            </ajaxToolkit:CalendarExtender>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnSearch" class="button button-blue" runat="server" Text="Search"
                                OnClick="btnSearch_Click" />
                            <asp:Button ID="btnStatistic" class="button button-blue" runat="server" Text="Statistic"
                                OnClick="btnStatistic_Click" />
                                <a href="ListOfAllEmployeePrint.aspx"  class="button button-blue" target="_blank">Print List of All Employee</a>
                        </dd>
                    </dl>
                    <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
                </div>
            </div>
            <div id="divStatistic" runat="server" visible="false" class="content-box">
                <div class="header">
                    <h3>
                        Statistic</h3>
                </div>
                <div class="inner-content">
                    <div>
                        <asp:Button ID="btnHideStatistic" runat="server" Text="Hide" OnClick="btnHideStatistic_Click" />
                        <asp:Button ID="btnEmpIDCard" runat="server" Text="ID Card" OnClick="btnEmpIDCard_Click" />
                    </div>
                    <div>
                        <asp:HiddenField ID="departmentID" runat="server" />
                        <asp:Label ID="lblDepartmentName" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblTotalDesignation" runat="server"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblTotalEmployee" runat="server"></asp:Label>
                    </div>
                    <asp:GridView ID="gvStatisticOfEmp" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Designation Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationName" runat="server" Text='<%#Eval("DesignationName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Employee">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalEmployee" runat="server" Text='<%#Eval("TotalEmployee") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div id="divListOfEmployee" class="content-box">
                <div class="header">
                    <h3>
                        List Of Employee</h3>
                </div>
                <div class="inner-content">
                    <asp:CheckBox ID="chkAllEmployee" runat="server" Checked="false" AutoPostBack="true"
                        Text="All Employee(Active and Inactive)" OnCheckedChanged="chkAllEmployee_OnCheckedChanged" />
                </div>
                <div class="inner-content" style="width: 97%; overflow: scroll;">
                    <asp:GridView ID="gvHR_Employee" runat="server" AutoGenerateColumns="false" CssClass="tabel_input"
                        OnRowDataBound="gvHR_Employee_RowDataBound" 
                        onselectedindexchanged="gvHR_Employee_SelectedIndexChanged">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="R/T">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lblEmployerResign" Text="R/T" Font-Size="Smaller"
                                        Font-Underline="true" ForeColor="Blue" NavigateUrl='<%#String.Format("~/HR/AdminHR_EmployeeTerminate.aspx?ID={0}", Eval("EmployeeID"))%>'>
                               <%-- <asp:Image runat="server" ID="imgPhoto" ImageUrl='<%#Eval("Photo") %>' ImageAlign="Middle"
                                    Width="75" Height="75" />--%> 
                                     
                                    </asp:HyperLink>
                                    <br />
                                    <a href='AppointmentLetter.aspx?EmployeeNo=<%#Eval("EmployeeNo")%>' target="_blank">AL</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="lblIDCard" Text="ID" Font-Size="Smaller" Font-Underline="true"
                                        ForeColor="Blue" NavigateUrl='<%#String.Format("~/idCardPage.aspx?EmpID={0}", Eval("EmployeeID"))%>'>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Flag")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emp ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("EmployeeNo") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeType" runat="server" Text='<%#Eval("EmployeeType") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationID" runat="server" Text='<%#Eval("DesignationName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rank">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeRank" runat="server" Text='<%#Eval("EmployeeRank") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <asp:Label ID="lblGenderID" runat="server" Text='<%#Eval("GenderID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Religion">
 	 <ItemTemplate>
 	 <asp:Label ID="lblReligionID" runat="server" Text='<%#Eval("ReligionID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="Maritual Status">
 	 <ItemTemplate>
 	 <asp:Label ID="lblMaritualStatusID" runat="server" Text='<%#Eval("MaritualStatusID") %>'>
 	 </asp:Label>
  		</ItemTemplate>
 	</asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Photo">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoto" Visible="false" runat="server" Text='<%#Eval("Photo") %>'>
                                    </asp:Label>
                                    <asp:HyperLink runat="server" ID="lblEmployerView" NavigateUrl='<%#String.Format("~/HR/AdminHR_EmployeeDetails.aspx?ID={0}", Eval("EmployeeID"))%>'>
                                        <asp:Image runat="server" ID="imgPhoto" ImageUrl='<%#Eval("Photo") %>' ImageAlign="Middle"
                                            Width="65" Height="80" />
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("EmployeeID") %>'
                                        AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <%--<asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                CommandArgument='<%#Eval("EmployeeID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <%--<asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("EmployeeID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />--%>
                                    <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%#Eval("EmployeeID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div style="text-align: right;">
                        <asp:Label ID="lblGrandTotalEmployee" runat="server" Text="Total : 0" Font-Bold="true"></asp:Label>
                    </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
