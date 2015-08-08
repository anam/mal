<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="StudentClassSubjectAdd.aspx.cs" Inherits="AdminDisplaySTD_ClassStudent"
    Title="Assign Class and Subject to single student" %>

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
                        Student Class Subject Process</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt>
                            <asp:Label ID="lblClassID" runat="server" Text="Student ID: ">
                            </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtStudentCode" runat="server" CssClass="txt small-input" AutoPostBack="true"
                                OnTextChanged="OnTextChanged_txtStudentCode"></asp:TextBox>
                            <asp:Button ID="btnVarify" Text="VerifyCode" runat="server" class="button button-blue"
                                OnClick="btnVarify_OnClick" />
                            <asp:HiddenField ID="hfStudentID" runat="server" />
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </dd>
                        <dt>
                            <asp:Label ID="lblCourseID" runat="server" Text="Course: "></asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlCourseID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourseID_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="Label1" runat="server" Text="Subject: "></asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt>
                            <asp:Label ID="Label2" runat="server" Text="Class: "></asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_OnSelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Button ID="btnVarifyRoutine" Text="Varify Routine" runat="server" class="button button-blue"
                                OnClick="btnVarifyRoutine_Click" />
                            <asp:Button ID="btnAddClass" Text="Add" runat="server" class="button button-blue"
                                OnClick="btnAddClass_Click" />
                            
                            <asp:Button ID="btnUpdateClass" Text="Update" runat="server" class="button button-blue"
                                OnClick="btnUpdateClass_Click" Visible="false" />
                        </dd>
                        <dt>&nbsp;
                        </dt>
                        <dd>&nbsp;
                            <asp:Label ID="lblConfilictMessage" runat="server" Text=""></asp:Label>
                        </dd>
                    </dl>
                    <b style="font-size: 20px; color: #0567AD;">
                        <br />
                        Classes already in the Routine</b>
                    <div style="width: 780px; overflow: scroll;">
                        <asp:Label ID="lblRoutineDisplayForStudent" runat="server" Text=""></asp:Label></div>
                    <b style="font-size: 20px; color: #0567AD;">
                        <br />
                        Routine for the selected Class And Subject</b>
                    <div style="width: 780px; overflow: scroll;">
                        <asp:Label ID="lblRoutineDisplayForSelectedClassNSubject" runat="server" Text=""></asp:Label></div>
                    <b style="font-size: 20px; color: #0567AD;">
                        <br />
                        Routine varification</b>
                    <div style="width: 780px; overflow: scroll;">
                        <asp:Label ID="lblVerifyRoutine" runat="server" Text=""></asp:Label></div>
                </div>
            </div>
            <div class="content-box">
                <div class="header">
                    <h3>
                        List Of the Class Of a subject</h3>
                </div>
                <asp:HiddenField ID="hfclassSubjectIDs" runat="server" />
                <asp:HiddenField ID="hfclassIDs" runat="server" />
                <div class="inner-content">
                    <dl>
                        <dt></dt>
                        <dd>
                            <asp:GridView ID="gvSTD_ClassSubjectStudent" class="gridCss" runat="server" AutoGenerateColumns="false"
                                CssClass="tabel_input">
                                <HeaderStyle CssClass="heading" />
                                <RowStyle CssClass="row" />
                                <AlternatingRowStyle CssClass="altrow" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Class Subject Student" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassSubjectStudentID" runat="server" Text='<%#Eval("ClassSubjectStudentID") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class Subject Student Name" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassSubjectStudentName" runat="server" Text='<%#Eval("ClassSubjectStudentName") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Student" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStudentID" runat="server" Text='<%#Eval("StudentID") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subject">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubjectName" runat="server" Text='<%#Eval("SubjectName") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Class Subject" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassSubjectID" runat="server" Text='<%#Eval("ClassSubjectID") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Update Date" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUpdateDate" runat="server" Text='<%#Eval("UpdateDate") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <%--<asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ClassSubjectStudentID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />--%>
                                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                                CommandArgument='<%#Eval("ClassSubjectStudentID") %>' OnClick="lbDelete_Click"
                                                AlternateText="Delete" ToolTip='<%#Eval("ID") %>' ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnSave" class="button button-blue" runat="server" Text="Save" OnClick="btnSave_Click" />
                        </dd>
                    </dl>
                </div>
            </div>
            <asp:HiddenField ID="hfClassStudentSubjectID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
