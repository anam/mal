<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplayHR_EmployeeLeave.aspx.cs" Inherits="AdminDisplayHR_EmployerType"
    Title="List of Existing Employee Type" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="content-box">
        <div class="header">
            <h3>
                List of Existing Leave Type</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>
                    <asp:Label ID="Label6" runat="server" Text="Employee: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlAccountingUser" runat="server">
                    </asp:DropDownList>
                     <br />
                    or Select Employee
                    <br />
                    <div style="height:300px;overflow:scroll;">
                    
                     <asp:GridView ID="gvEmpoyeeList" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmpployee" runat="server" Checked="false"/>
                                    <asp:HiddenField   ID="hfEmployeeID" runat="server" Value='<%#Eval("EmployeeID") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("EmployeeNo") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Image runat="server" ID="imgPhoto" ImageUrl='<%#Eval("Photo") %>' ImageAlign="Middle"
                                            Width="65" Height="80" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            
                            </Columns>
                    </asp:GridView>
                    </div>
                    <asp:HiddenField ID="hfEmployeeLeaveID" runat="server" />
                    <br />
                    or Enter Employee ID (, separated)
                    <br />
                    <asp:TextBox ID="txtEmployeeIDs" TextMode="MultiLine" runat="server"></asp:TextBox>
                </dd>
                <dt>
                    
                    <asp:Label ID="Label1" runat="server" Text="Date: ">
                    </asp:Label>
                </dt>
                <dd>
                    Single Date:<asp:TextBox ID="txtDate" runat="server" Text="">
                    </asp:TextBox>
                    <br />
                    or
                    <br />
                    From:<asp:TextBox ID="txtFromDateLeave" runat="server"></asp:TextBox>
                    To:<asp:TextBox ID="txtToDateLeave" runat="server"></asp:TextBox>
                    <br />
                     or Enter Multiple Date(, separated format is [Month/Day/Year])
                    <br />
                    <asp:TextBox ID="txtMultipleDate" TextMode="MultiLine" runat="server"></asp:TextBox>
                </dd>
                <dt>                    
                    <asp:Label ID="Label4" runat="server" Text="Leave Type: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlLeaveType" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    &nbsp;
                </dt>
                <dd>
                    <asp:Button ID="btnLeave" runat="server" Text="Add Leave" 
                        onclick="btnLeave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update Leave" 
                        onclick="btnUpdate_Click"/>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </dd>
                <dt>
                    <asp:Label ID="Label2" runat="server" Text="Date: ">
                    </asp:Label>
                </dt>
                <dd>
                    From:<asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>
                    To:<asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>

                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom"></ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo"></ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender3" runat="server" TargetControlID="txtFromDateLeave"></ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender4" runat="server" TargetControlID="txtToDateLeave"></ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajCal" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                </dd>
                <dt>
                    <asp:Label ID="Label3" runat="server" Text="Employee: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlEmployee" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    &nbsp;
                </dt>
                <dd>
                    <asp:Button ID="btnShow" runat="server" Text="Show Leave" 
                        onclick="btnShow_Click" />
                    
                </dd>
            </dl>
             <div style="height:300px;overflow:scroll;">
        <asp:GridView ID="gvEmployeeLeave" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
            <Columns>
                <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <asp:Label ID="lblInstallmentNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                <asp:TemplateField HeaderText="EmployeeID">
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeID" runat="server" Text='<%#Eval("EmployeeNo") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeID1" runat="server" Text='<%#Eval("EmployeeName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LeaveDate">
                    <ItemTemplate>
                        <asp:Label ID="lblLeaveDate" runat="server" Text='<%#Eval("LeaveDate","{0:dd MMM yyyy}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Leave Type">
                    <ItemTemplate>
                        <asp:Label ID="lblLeaveTypeID" runat="server" Text='<%#Eval("LeaveName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit /Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("EmployeeLeaveID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                CommandArgument='<%#Eval("EmployeeLeaveID") %>' OnClick="lbDelete_Click"
                                AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
