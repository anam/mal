<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="ClassSubjectAddStudent.aspx.cs" Inherits="AdminDisplaySTD_ClassTeacher"
    Title="Add Subject For Students" %>

<%@ Register Src="../Control/ClassSetting.ascx" TagName="ClassSetting" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .hCss
        {
            border-bottom: solid 1px #ccc;
            padding: 7px;
        }
        .headerCss
        {
            border-bottom: solid 1px #ccc;
            padding: 7px 35px 7px 0px;
            border-right: solid 1px #ccc;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="upClassSubjectStudent" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hfCourseID" runat="server" Value="0" />
            <div class="content-box">
                <div class="header">
                    <h3>
                        Add Subject For Students</h3>
                </div>
                <div class="inner-form">
                    <uc1:ClassSetting ID="ClassSetting1" runat="server" />
                </div>
                <div class="inner-form">
                    <table width="80%">
                        <tr>
                            <td colspan="2" style="padding-bottom: 30px;">
                                <asp:Panel ID="pnCheck" runat="server" Visible="false">
                                    <asp:Label ID="lblCheck" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>&nbsp;
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblClassID" runat="server" Text="Class: ">
                                </asp:Label>
                            </td>
                            <td>
                    <asp:CheckBox ID="chkClosedClasses" runat="server" 
                        Text="Load Completed Classes Also" AutoPostBack="true" 
                        oncheckedchanged="chkClosedClasses_CheckedChanged"/>
                    <br />
                    
                                <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
                                </asp:Label>
                            </td>
                            <td>
                                <asp:GridView ID="gvSubject" runat="server" AutoGenerateColumns="false" GridLines="None"
                                    CellSpacing="1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="hfSubjectID" Value='<%# Eval("SubjectID")  %>' />
                                                <asp:HiddenField runat="server" ID="hfClassSubjectID" Value='<%# Eval("ClassSubjectID")  %>' />
                                                <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# Eval("SubjectID")  %>'></asp:Label>
                                                <asp:Label ID="lblSubjectName" runat="server" Text='<%# Eval("SubjectName")  %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="border: none">
                                <asp:Label ID="Label1" runat="server" Text="Students: ">
                                </asp:Label>
                            </td>
                            <td style="border: none">
                                <asp:GridView ID="gvStudentSubject" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvStudentSubject_RowDataBound"
                                    CssClass="tabel_input">
                                    <HeaderStyle CssClass="heading" />
                                    <RowStyle CssClass="row" />
                                    <AlternatingRowStyle CssClass="altrow" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="" ControlStyle-CssClass="gridIteamCenter">
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="hfIsActive" Value='<%# Eval("IsActive")  %>' />
                                                <asp:HiddenField runat="server" ID="hfStudentID" Value='<%# Eval("StudentID")  %>' />
                                                <%--<asp:HiddenField runat="server" ID="hfClassStudentID" Value='<%# Eval("ClassStudentID")  %>' />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Serial">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student">
                                            <ItemTemplate>
                                                <a title="Click here to check Enrollment History" target="_blank" href='EnrollmentHistory.aspx?StudentCode=<%# Eval("StudentCode")  %>'><asp:Label ID="Label3" runat="server" Visible='<%# Eval("IsActive")  %>' Text='<%# Eval("StudentName")  %>'></asp:Label></a>
                                                <a title="Click here to check Enrollment History" target="_blank" href='EnrollmentHistory.aspx?StudentCode=<%# Eval("StudentCode")  %>'><asp:Label ID="Label2" ForeColor="Red" runat="server" Visible='<%# Eval("IsHistory")  %>'  Text='<%# Eval("StudentName")  %>'></asp:Label></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                               <a title="Click here to check Enrollment History" target="_blank" href='EnrollmentHistory.aspx?StudentCode=<%# Eval("StudentCode")  %>'><%# Eval("StudentCode")  %></a> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:GridView ID="gvSubjects" runat="server"  AutoGenerateColumns="false" ShowHeader="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" Enabled='<%# Eval("IsEnabled")%>' runat="server" Checked='<%# Eval("IsChecked")%>' ValidationGroup='<%#Eval("StudentID")%>'
                                                                    ToolTip='<%# Eval("SubjectName")  %>' OnCheckedChanged="OnCheckedChanged_chkSelect"  Text='<%# Eval("SubjectName")  %>'
                                                                    AutoPostBack="false" />
                                                                <asp:HiddenField runat="server" ID="hfClassSubjectStudentID" Value='<%# Eval("ClassSubjectStudentID")  %>' />
                                                                <asp:HiddenField runat="server" ID="hfClassSubjectID" Value='<%# Eval("ClassSubjectID")  %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject Passed">
                                            <ItemTemplate>
                                                <asp:GridView ID="gvSubjectsPassed" runat="server"  AutoGenerateColumns="false" ShowHeader="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSelect" Enabled='<%# Eval("IsEnabled")%>' runat="server"  ValidationGroup='<%#Eval("StudentID")%>'
                                                                    ToolTip='<%# Eval("SubjectName")  %>' OnCheckedChanged="OnCheckedChanged_chkSelect"  Text='<%# Eval("SubjectName")  %>'
                                                                    AutoPostBack="false" />
                                                                <asp:HiddenField runat="server" ID="hfClassSubjectStudentID" Value='<%# Eval("ClassSubjectStudentID")  %>' />
                                                                <asp:HiddenField runat="server" ID="hfClassSubjectID" Value='<%# Eval("ClassSubjectID")  %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Photo">
                                            <ItemTemplate>
                                                <asp:Image ID="imgPhoto" ImageUrl='<%#Eval("PPSizePhoto")%>' runat="server" Height="100px"
                                                    Width="100px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:HiddenField ID="hfClassSubjectStudentID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="padding: 10px 0px 0px 120px">
                                <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Save" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                                    OnClick="btnUpdate_Click" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
