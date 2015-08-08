<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminDisplaySTD_ClassSubjectEmployeeStudent.aspx.cs" Inherits="AdminDisplaySTD_ClassSubjectEmployeeStudent"
    Title="STD_ClassSubjectEmployeeStudent Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="upAttendant" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Student's Class Attendant Sheet</h3>
                </div>
                <div class="inner-form-search">
                    <div style="width:100%; float: left">
                        <dl>
                            <dt>
                                <asp:Label ID="lblClassID" runat="server" Text="Class: ">
                                </asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0"
                                    ControlToValidate="ddlClassID" Text="*" ErrorMessage="Select Class." Display="Dynamic"
                                    ValidationGroup="required"></asp:RequiredFieldValidator>
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </dd>
                        </dl>
                        <dl>
                            <dt>
                                <asp:Label ID="lblSubject" runat="server" Text="Subject: ">
                                </asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0"
                                    ControlToValidate="ddlSubjectID" Text="*" ErrorMessage="Select Subject." Display="Dynamic"
                                    ValidationGroup="required"></asp:RequiredFieldValidator>
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                                </asp:DropDownList>
                            </dd>
                        </dl>
                        <dl>
                            <dt>
                                <asp:Label ID="lblTeacher" runat="server" Text="Teacher: ">
                                </asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0"
                                    ControlToValidate="ddlEmployeeID" Text="*" ErrorMessage="Select Employee." Display="Dynamic"
                                    ValidationGroup="required"></asp:RequiredFieldValidator>
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlEmployeeID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployeeID_SelectedIndexChanged">
                                </asp:DropDownList>
                            </dd>
                        </dl>
                        <dl>
                            <dt>
                                &nbsp;
                            </dt>
                            <dd>
                                <asp:CheckBox ID="chkLoadFromMachine" runat="server" Text="Load from Machine Data" 
                                    AutoPostBack="True" oncheckedchanged="chkLoadFromMachine_CheckedChanged" />
                            </dd>
                        </dl>
                        <dl style="display:none;">
                            <dt>
                                Old Sheet IDs:
                            </dt>
                            <dd>
                            Given the ids coma(,) separated, also ends with a coma(,)<br />
                                <asp:TextBox ID="txtIDFormPreviousAttendenceSheet" TextMode="MultiLine" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnOldSystemVirification" runat="server"  
                                    class="button button-blue"  Text="Adjust" 
                                    onclick="btnOldSystemVirification_Click"/>
                                    <br />
                                <asp:HiddenField ID="hfSoftwareIds" runat="server" />
                                <asp:Label ID="lblNeedOperation" runat="server" Text=""></asp:Label>

                            </dd>
                        </dl>
                        <dl>
                            <dt></dt>
                            <dd>
                                <asp:Button ID="btnShowAttendant" runat="server"  class="button button-blue"  Text="Generate Attendant"
                                     OnClick="btnShowAttendant_Click" />
                                <asp:TextBox ID="txtPrintAttendenceSheet" runat="server" AutoPostBack="true"
                                    CssClass="txt small-input" ontextchanged="txtPrintAttendenceSheet_TextChanged"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPrintAttendenceSheet"
                                    Format="dd MMM, yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <asp:Label ID="lblPrint" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblAttendenceReport" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:ValidationSummary ID="summary1" runat="server" ShowMessageBox="true" ShowSummary="false"
                                    ValidationGroup="required" />
                            </dd>
                        </dl>
                    </div>
                    <asp:Panel ID="pnAttendantDate" runat="server" Visible="false">
                        <div style="float: left; width: 40%; border: solid 1px #ccc; height: 150px; margin-left: 20px;
                            margin-top: 10px; overflow: scroll; padding-left: 15px">
                            <span style="font-size: 20px; font-weight: bold">(<asp:Label ID="lblNoAttendant"
                                runat="server" ForeColor="Red"></asp:Label>) Classes are taken. </span>
                            <asp:GridView ID="gvSTD_AttendantTime"  runat="server" GridLines="Both" ShowHeader="false" 
                                AutoGenerateColumns="false">
                                <Columns>
                                   <asp:TemplateField HeaderText="No Of Student">
                                        <ItemTemplate>
                                           <asp:Label ID="lblNoOfStudent" Text='<%#Eval("noOfStudents")%>' runat="server"></asp:Label> - 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class Time" >
                                        <ItemTemplate>
                                           <a target="_blank" href='AttendantSheetAttended.aspx?classID=<%#Eval("ClassID")%>&subjectID=<%#Eval("SubjectID")%>&employeeID=<%#Eval("EmployeeID")%>&DateRoutineTime=<%#Eval("ExtraField1")%>'> <asp:Label ID="lblAttendantDate" Text='<%#Eval("ExtraField1")%>'
                                                runat="server"></asp:Label></a>
                                            <a  onclick="return confirm('Are You Sure, You Want To Delete?')" target="_blank" href='AttendantSheetAttendedDelete.aspx?classID=<%#Eval("ClassID")%>&subjectID=<%#Eval("SubjectID")%>&employeeID=<%#Eval("EmployeeID")%>&DateRoutineTime=<%#Eval("ExtraField1")%>'>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png"/>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                           
                        </div>
                        <div style="float: left; width: 40%; border: solid 1px #ccc; height: 150px; margin-left: 20px;
                            margin-top: 10px; overflow: scroll; padding-left: 15px">
                            <span style="font-size: 20px; font-weight: bold">(<asp:Label ID="lblNoAttendantAlready"
                                runat="server" ForeColor="Red"></asp:Label>) Classes Remaining. </span>
                            
                            <asp:GridView ID="gvClassFromRoutine" class="gridCss" runat="server" GridLines="None" ShowHeader="false"
                                AutoGenerateColumns="false">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Attendant Date(No Of Student)." HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAttendantDate" Text='<%#Eval("Date","{0:dd MMM, yyyy (ddd)}")%>'
                                                runat="server"></asp:Label>
                                            (<asp:Label ID="lblNoOfStudent" Text='<%#Eval("ClassTimeName")%>' runat="server"></asp:Label>)
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnAttendenceDateTime" runat="server" Text='<%#Eval("DateClassTimeName")%>' OnClick="lbSelect_Click" />
                                            <%--<asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ClassDayID") %>'
                                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                                CommandArgument='<%#Eval("ClassDayID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                                ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>                            
                            <asp:HiddenField ID="hfAttendenceDataTime" runat="server" />
                        </div>
                    </asp:Panel>
                </div>
                <div class="inner-content">
                <div style="float: right;text-align:right; width: 95%; padding: 10px;border:1px solid #0D73BB;">
                    <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select / DisSelect All" Checked="true"
                        AutoPostBack="true" oncheckedchanged="chkSelectAll_CheckedChanged"/>
                </div>
                    <div style="float: left; width: 100%; margin: 10px">
                        <asp:GridView ID="gvSTD_ClassSubjectEmployeeStudent" class="gridCss" runat="server"
                            AutoGenerateColumns="false" CssClass="tabel_input">
                            <HeaderStyle CssClass="heading" />
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="altrow" />
                            <Columns>
                                <asp:TemplateField HeaderText="Serial" HeaderStyle-Width="5%">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID No." HeaderStyle-Width="15%">
                                    <ItemTemplate>
                                       <a href='EnrollmentHistory.aspx?StudentCode=<%#Eval("StudentCode")%>' target="_blank"> 
                                       <asp:Label ID="Label1" Visible='<%#Eval("ExtraField2")%>' Text='<%#Eval("StudentCode")%>'
                                            runat="server"></asp:Label>
                                        <asp:Label ID="lblStudentCode" Visible='<%#Eval("ExtraField1")%>' ForeColor="Red"
                                            Text='<%#Eval("StudentCode")%>' runat="server"></asp:Label></a>
                                        <asp:Label ID="lblClassSubjectEmloyeeID" Text='<%#Eval("ClassSubjectEmployeeID")%>'
                                            runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblStudentID" Text='<%#Eval("StudentID")%>' runat="server" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student">
                                    <ItemTemplate>
                                         <a href='../Student/StudentRegistration.aspx?studentID=<%#Eval("StudentID")%>' target="_blank"><%#Eval("StudentName") %></a>
                                <br />
                                Remark: 
                                <asp:TextBox ID="txtRemark" runat="server" Width="400px" Height="20px" Text='<%#Eval("Remark")%>' TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Attendence">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chbAttendants" runat="server" Checked="true"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="inner-content">
                    <dl>
                        <dt style="width: 50px">
                            <asp:Label ID="lblDate" runat="server" Text="Date: ">
                            </asp:Label>
                            <asp:RequiredFieldValidator ID="requiredField1" runat="server" ControlToValidate="txtAttendantDate"
                                Text="*" ErrorMessage="Enter Date & Time." Display="Dynamic" ValidationGroup="required"></asp:RequiredFieldValidator>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtAttendantDate" runat="server" CssClass="txt small-input"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="ajxCal" runat="server" TargetControlID="txtAttendantDate"
                                Format="dd MMM, yyyy">
                            </ajaxToolkit:CalendarExtender>
                            &nbsp;&nbsp; Start time
                            <asp:DropDownList ID="ddlStartHour" runat="server">
                                <asp:ListItem Value="0">0</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                            </asp:DropDownList>
                            :
                            <asp:DropDownList ID="ddlStartMin" runat="server">
                                <asp:ListItem Value="00">00</asp:ListItem>
                                <asp:ListItem Value="05">05</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="25">25</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="35">35</asp:ListItem>
                                <asp:ListItem Value="40">40</asp:ListItem>
                                <asp:ListItem Value="45">45</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                                <asp:ListItem Value="55">55</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:DropDownList ID="ddlStartAMPM" runat="server">
                                <asp:ListItem Value="AM">AM</asp:ListItem>
                                <asp:ListItem Value="PM">PM</asp:ListItem>
                            </asp:DropDownList>
                            End time
                            <asp:DropDownList ID="ddlEndHour" runat="server">
                                <asp:ListItem Value="0">0</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                            </asp:DropDownList>
                            :
                            <asp:DropDownList ID="ddlEndMin" runat="server">
                                <asp:ListItem Value="00">00</asp:ListItem>
                                <asp:ListItem Value="05">05</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="25">25</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="35">35</asp:ListItem>
                                <asp:ListItem Value="40">40</asp:ListItem>
                                <asp:ListItem Value="45">45</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                                <asp:ListItem Value="55">55</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:DropDownList ID="ddlEndAMPM" runat="server" >
                                <asp:ListItem Value="AM">AM</asp:ListItem>
                                <asp:ListItem Value="PM">PM</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:CheckBox ID="chkManualDataEntry" runat="server" Text="Manual Data Entry?" Visible="false"  AutoPostBack="true"
                                oncheckedchanged="chkManualDataEntry_CheckedChanged"/>
                            
                        </dd>
                    </dl>
                    <br />
                    Covered Syllabus:<asp:TextBox ID="txtCoveredSyllabus" runat="server"></asp:TextBox>
                    
                    <br />

                    <asp:CheckBox ID="chkExamTaken" runat="server" Text="Exam taken Today?"  />
                    <asp:Button ID="btnAddAttendant" runat="server" Text="Add Attendant" ValidationGroup="required" 
                        CausesValidation="true" Width="140px" class="button button-blue" OnClick="btnAddAttendant_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnViewAttendant" ValidationGroup="required" CausesValidation="true" Visible="false"
                        runat="server" Text="View Attendant" Width="140px" class="button button-blue"
                        OnClick="btnViewAttendant_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
