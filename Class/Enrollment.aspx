<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="Enrollment.aspx.cs" Inherits="AdminDisplaySTD_ClassStudent" Title="Add/Update Class Student" %>
    <%@ Register src="../Control/ClassSetting.ascx" tagname="ClassSetting" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
    <asp:HiddenField ID="hfCourseID" runat="server" Value="0" />
    <div class="content-box">
        <div class="header">
            <h3>
                Enrollment</h3>
        </div>        
        <div class="inner-form">
           
                   <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
               
                <ajaxToolkit:TabPanel HeaderText="Student by IDs" ID="TabPanel2" runat="server">
                    <ContentTemplate>
                        <p>In this way the 1 Student will be active in multiple class</p>
                        <dl>
                            <dt>Student IDs :<br />
                                <span style="font-size: 8px;">StudentIDs seperated by (,)</span></dt>
                            <dd>
                                <asp:TextBox ID="txtStudentIDs" runat="server" Width="500" Height="100" TextMode="MultiLine"></asp:TextBox></dd>
                            <dt></dt>
                            <dd>
                                <asp:Button ID="btnVerify" runat="server" class="button button-blue" Text="Verify"
                                    OnClick="btnVerify_Click" />
                                <asp:Button ID="btnAdd2" class="button button-blue" runat="server" Visible="false" Text="Add" OnClick="btnAdd2_Click" CausesValidation="true" ValidationGroup="required"/>
                            </dd>
                        </dl>
                        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                            <HeaderStyle CssClass="heading" />
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="altrow" />
                            <Columns>
                                <asp:TemplateField HeaderText="" ControlStyle-CssClass="gridIteamCenter">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkSelect" Checked="true" />
                                        <asp:HiddenField runat="server" ID="hfStudentID" Value='<%# Eval("StudentID")  %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Code">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblStudentCode" runat="server" Text='<%#Eval("StudentCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone No#">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblStudentMobile" runat="server" Text='<%#Eval("Mobile")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <a href='<%#"../Student/AdminDetailsSTD_Student.aspx?ID="+Eval("StudentID") %>' target="_blank">
                                            <asp:Image ID="imgStudent" runat="server" ImageUrl='<%#Eval("PPSizePhoto") %>' Width="100" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
 <dl id="addClass" runat="server" visible="false">
                <dt>
                    Class Name
                </dt>
                <dd>
                    <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>
                </dd>

                <dt>
                Course
                </dt>
                <dd>
                   
            <asp:DropDownList ID="ddlCourseID" runat="server" AutoPostBack="true"
                onselectedindexchanged="ddlCourseID_SelectedIndexChanged">
                    </asp:DropDownList> 
                </dd>

                <dt>
                 Subject: 
                </dt>
                <dd>
                   <asp:GridView ID="gvSubject" runat="server" AutoGenerateColumns="false"  OnRowDataBound="gvSubject_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="" ControlStyle-CssClass="gridIteamCenter">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkSelect" />
                                    <asp:HiddenField runat="server" ID="hfSubjectID" Value='<%# Eval("SubjectID")  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subjects">
                                <ItemTemplate>
                                    <%#String.Format("{0}",Eval("SubjectName"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Teacher">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlTeacherID" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal" runat="server" TargetControlID="txtStartDate">
                                    </ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal1" runat="server" TargetControlID="txtEndDate">
                                    </ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:DropDownList ID="ddlTeacher" runat="server" Visible="false">
                    </asp:DropDownList>  
                </dd>

                <dt>
                    &nbsp;
                </dt>
                <dd>
                    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />  
                </dd>

           </dl>
    
           
        </div>
    </div>
   
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
