<%@ Page Title="" Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="Attendence.aspx.cs" Inherits="HR_Attendence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">

<script type="text/javascript">
    var win = null;
    function printIt(printThis) {
        win = window.open();
        self.focus();
        win.document.open();
        win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
        win.document.write('body, td { font-family: Verdana; font-size: 10px;} th{font-family: Verdana; font-size: 12px;}');
        win.document.write('<' + '/' + 'style' + '><' + '/' + 'head' + '><' + 'body' + '>');
        win.document.write(printThis);
        win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
        win.document.close();
        win.print();
        win.close();
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
  
            <div id="divListOfEmployee" class="content-box">
                <div class="header">
                    <h3>
                        Manual Entry:</h3>
                </div>
                <div class="inner-content" style="width: 97%; overflow: scroll;">
                <dl>
                    <dt>Empoyee ID:</dt>
                    <dd> <asp:DropDownList ID="ddlAccountingUser" runat="server">
                    </asp:DropDownList></dd>
                    <dt>Time:</dt>
                   <dd> <asp:TextBox ID="txtInOutTime" runat="server"></asp:TextBox></dd>
                   <dt>&nbsp;</dt>
                   <dd> 
                   <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></dd>
                   </dl>
                    
                    
                    </div></div>
              <div id="div1" class="content-box">
                <div class="header">
                    <h3>Report :</h3>
                </div>
                <div class="inner-content" style="width: 97%; overflow: scroll;">      
                    <div style="margin-bottom:10px;">
                    <dl>
                    <dt>Date:</dt>
                    <dd> <asp:TextBox ID="txtDate" runat="server"></asp:TextBox></dd>
                    <dt>&nbsp;</dt>
                    <dd>OR</dd>
                    <dt> Date range:</dt>
                    <dd>
                     <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox> to
                    <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
                    </dd>
                    <dt>Empoyee ID</dt>
                    <dd>
                    <asp:DropDownList ID="ddlEmployee" runat="server">
                    </asp:DropDownList>
                    </dd>
                   <dt>&nbsp;</dt>
                    <dd>
                    <asp:Button ID="btnViewReport" runat="server" Text="View Report" OnClick="btnViewReport_Click" />
                    </dd>
                    
                   <dt>&nbsp;</dt>
                    <dd>
                    <span style="margin:5px; ">
                     <span style="margin:5px; padding:5px;border:1px solid black;">
                     <asp:LinkButton ID="lnkPrint" Text="Print In Out Time" runat="server" OnClientClick="javascript:printIt(document.getElementById('ctl00_MainContent_printme').innerHTML);"></asp:LinkButton>
                      </span></span>
                        
                        <span style="margin:5px; ">
                     <span style="margin:5px; padding:5px;border:1px solid black;">
                     <asp:LinkButton ID="LinkButton1" Text="Print Summary" runat="server" OnClientClick="javascript:printIt(document.getElementById('divSummary').innerHTML);"></asp:LinkButton>
                      </span></span>

                      <span style="margin:5px; ">
                     <span style="margin:5px; padding:5px;border:1px solid black;">
                     <asp:LinkButton ID="LinkButton2" Text="Print Griphical View" runat="server" OnClientClick="javascript:printIt(document.getElementById('divGraphicalPrint').innerHTML);"></asp:LinkButton>
                      </span></span>

                    </dd>

                    </dl>
                    
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom"></ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo"></ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajCal" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                   
                    </div>
                    
        <div id="printme" runat="server">
            <asp:Label ID="lblReprtHeader" runat="server" Text=""></asp:Label>
                    <asp:GridView ID="gvAttendenceDuration" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserIDDisplay") %>'>
                                    </asp:Label>
                                    <asp:HiddenField ID="hfDate" runat="server" Value='<%#Eval("OutTime","{0:yyyy-MM-dd}") %>' />
                                    <asp:HiddenField ID="hfUserID" runat="server" Value='<%#Eval("UserID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserNameDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("DateDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Office Opening Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate2" runat="server" Text='<%#Eval("StarttingOfficeTimeDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Late Come">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate4" runat="server" Text='<%#Eval("LateComeDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="In Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime2" runat="server" Text='<%#Eval("InTime","{0:hh:mm tt}") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Out Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime" runat="server" Text='<%#Eval("OutTime","{0:hh:mm tt}") %>'
                                        Visible='<%#Eval("DefaultTimeLabelVisible") %>'>
                                    </asp:Label>
                                    <asp:TextBox ID="txtOutTime" runat="server" ForeColor="Red" Text='<%#Eval("OutTime","{0:hh:mm tt}") %>' Visible='<%#Eval("DefaultTimeTextBoxVisible") %>'
                                        Width="60px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Duration">
                                <ItemTemplate>
                                    <asp:Label ID="lblInOutTime1" runat="server" Text='<%#Eval("DurationDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Office Closing Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate3" runat="server" Text='<%#Eval("EndOfficeTimeDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Early Leave">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate14" runat="server" Text='<%#Eval("EarlyLeaveDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Total Working Hour">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI" runat="server" Text='<%#Eval("TotalDuratinDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Edit" Visible="false">
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
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                    </div>
                    <br />
                    <div align="center">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    </div>
                    <br />
<div id="divSummary" >
<asp:Label ID="lblSummaryReportHeader" runat="server" Text=""></asp:Label>
            
                    <asp:GridView ID="gvTotalSummary" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="UserID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("UserIDDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserNameDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Late Come">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate4" runat="server" Text='<%#Eval("LateComeDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Early Leave">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate14" runat="server" Text='<%#Eval("EarlyLeaveDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Total working time">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI7" runat="server" Text='<%#Eval("TotalWorkingTimeDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Office time">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI71" runat="server" Text='<%#Eval("TotalOfficeTimeDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Total Over time">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI73" runat="server" Text='<%#Eval("OverTimeDisplay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI7s3" Font-Bold="true" ForeColor="Red" runat="server" Text='<%#Eval("Amount","{0:00}") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total working Day">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI8" runat="server" Text='<%#Eval("TotalWorked") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Off-Day working Day">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI6" runat="server" Text='<%#Eval("TotalOffDayWorkingDay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Total Absent Day">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI4" runat="server" Text='<%#Eval("AbsentDay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Leave Day">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI42" runat="server" Text='<%#Eval("TotalLeaveDay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Leave-Day working Day">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserI3" runat="server" Text='<%#Eval("TotalLeaveDayWorkingDay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Money" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMoney" runat="server" Text="0" Width="70px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </div>
                    <br />
                    <div align="center">
                        <asp:Button ID="btnApplyPayment" runat="server" Text="Apply"  Visible="false"
                            onclick="btnApplyPayment_Click" />
                    </div>
                    <br />
                    <asp:GridView ID="gvMonthSummary" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="UserID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%#Eval("Day","{0:dd MMM yyyy dddd}") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Leave Day">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("IsLeaveDay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Off Day">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate4" runat="server" Text='<%#Eval("IsOffDay") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Present">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate14" runat="server" Text='<%#Eval("IsPresent") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                        </Columns>
                    </asp:GridView>

                    <div id="divGraphicalPrint">
                    
<asp:Label ID="lblGriphicalReportHeader" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblGriphicalReport" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        
</asp:Content>
