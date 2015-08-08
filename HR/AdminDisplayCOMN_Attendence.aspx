<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayCOMN_Attendence.aspx.cs" Inherits="AdminDisplayHR_Employee"
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
                        <dt style="display:none;">
                            <asp:Label ID="lblEmployeeNameSer" runat="server" Text="Employee Name: ">
                            </asp:Label>
                        </dt>
                        <dd style="display:none;">
                            <asp:TextBox ID="txtEmployeeNameSer" runat="server" Text="">
                            </asp:TextBox>
                        </dd>
                        <dt style="display:none;">
                            <asp:Label ID="Label1" runat="server" Text="Employee Type: ">
                            </asp:Label>
                        </dt>
                        <dd style="display:none;">
                            <asp:DropDownList ID="ddlEmployeeTypeSer" runat="server" class="small-input">
                            </asp:DropDownList>
                        </dd>
                        <dt style="display:none;">
                            <asp:Label ID="Label5" runat="server" Text="Department: ">
                            </asp:Label>
                        </dt>
                        <dd style="display:none;">
                            <asp:DropDownList ID="ddlDepartment" runat="server" class="small-input" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlDepartment_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt style="display:none;">
                            <asp:Label ID="Label2" runat="server" Text="Designation Name: ">
                            </asp:Label>
                        </dt>
                        <dd style="display:none;">
                            <asp:DropDownList ID="ddlDesignationNameSer" runat="server" class="small-input">
                            </asp:DropDownList>
                        </dd>
                        <dt style="display:none;">
                            <asp:Label ID="Label3" runat="server" Text="Jonining From Date: ">
                            </asp:Label>
                        </dt>
                        <dd style="display:none;">
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
                            <asp:Button ID="btnStatistic" class="button button-blue" runat="server" Text="Statistic" Visible="false"
                                OnClick="btnStatistic_Click" />
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
                        Attendence</h3>
                </div>
                <div class="inner-content" style="display: none;">
                    <asp:CheckBox ID="chkAllEmployee" runat="server" Checked="false" AutoPostBack="true"
                        Text="All Employee(Active and Inactive)" OnCheckedChanged="chkAllEmployee_OnCheckedChanged" />
                </div>
                <div class="inner-content" style="width: 97%; overflow: scroll;">

                Empoyee ID<asp:DropDownList ID="ddlAccountingUser" runat="server"></asp:DropDownList>
        <br />
        Time:<asp:TextBox ID="txtInOutTime" runat="server"></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" Text="Login" 
            onclick="btnLogin_Click" />
                    <asp:GridView ID="gvAttendence" runat="server" AutoGenerateColumns="false"  CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            
                            <asp:TemplateField HeaderText="UserID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="InOutTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server" Text='<%#Eval("InOutTime") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="ExtraField1">
                                <ItemTemplate>
                                    <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ExtraFileld2">
                                <ItemTemplate>
                                    <asp:Label ID="lblExtraFileld2" runat="server" Text='<%#Eval("ExtraFileld2") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbDelete_Click">
                                        Delete
                                    </asp:LinkButton>
                                     <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbSelect_Click">
                                        Select
                                    </asp:LinkButton>
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
                    Empoyee ID<asp:DropDownList ID="ddlEmployee" runat="server"></asp:DropDownList>        
                    <asp:Button ID="btnViewReport" runat="server" Text="View Report" 
                        onclick="btnViewReport_Click" />
                        <asp:GridView ID="gvAttendencePerEmployee" runat="server" AutoGenerateColumns="false"  CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            
                            <asp:TemplateField HeaderText="UserID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="InOutTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server" Text='<%#Eval("InOutTime") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="ExtraField1">
                                <ItemTemplate>
                                    <asp:Label ID="lblExtraField1" runat="server" Text='<%#Eval("ExtraField1") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ExtraFileld2">
                                <ItemTemplate>
                                    <asp:Label ID="lblExtraFileld2" runat="server" Text='<%#Eval("ExtraFileld2") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Edit" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbDelete_Click">
                                        Delete
                                    </asp:LinkButton>
                                     <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbSelect_Click">
                                        Select
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gvAttendenceDuration" runat="server" AutoGenerateColumns="false"  CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            
                            <asp:TemplateField HeaderText="UserID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("DateDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="InOutTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server" Text='<%#Eval("InTime","{0:hh:mm tt}") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Out Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server" Text='<%#Eval("OutTime","{0:hh:mm tt}") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duration">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server" Text='<%#Eval("DurationDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbDelete_Click">
                                        Delete
                                    </asp:LinkButton>
                                     <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("AttendenceID") %>'
                                        OnClick="lbSelect_Click">
                                        Select
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
