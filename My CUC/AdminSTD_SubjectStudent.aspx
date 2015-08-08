<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_SubjectStudent.aspx.cs" Inherits="AdminSTD_SubjectStudent"
    Title="STD_SubjectStudent Insert/Update By Admin" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="upClassSubject" runat="server">
        <ContentTemplate>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Class Enrolment By Students</h3>
                </div>
                <div class="inner-form">
                    <!-- error and information messages -->
                    <dl>
                        <dt>
                            <asp:Label ID="lblStudentID" runat="server" Text="Student: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:TextBox ID="txtStudentCode" runat="server" class="txt small-input"></asp:TextBox>
                            <asp:HiddenField ID="hfStudentID" runat="server" />
                        </dd>
                        <dt>
                            <asp:Label ID="lblSubject" runat="server" Text="Subject: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_OnSelectedIndexChanged">
                            </asp:DropDownList>
                        </dd>
                        <dt style="display: none;">
                            <asp:Label ID="lblRowStatusID" runat="server" Text="Row Status: ">
    </asp:Label>
                        </dt>
                        <dt>
                            <asp:Label ID="lblSubjectStudentName" runat="server" Text="Class: ">
    </asp:Label>
                        </dt>
                        <dd>
                            <asp:CheckBox ID="chkLoadAvailableClass" Checked="true" runat="server" Text="Load only the Classes where the selected Subject going on"
                                AutoPostBack="True" OnCheckedChanged="chkLoadAvailableClass_CheckedChanged" />
                            <br />
                            <asp:DropDownList ID="ddlClassID" runat="server">
                            </asp:DropDownList>
                        </dd>
                        <dd style="display: none;">
                            <asp:DropDownList ID="ddlRowStatusID" runat="server">
                            </asp:DropDownList>
                        </dd>
                        <dt></dt>
                        <dd>
                            <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                                OnClick="btnUpdate_Click" Visible="false" />
                        </dd>
                        <dt>&nbsp;</dt>
                        <dd>
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        </dd>
                    </dl>
                </div>
            </div>
            <div class="content-box">
                <div class="header">
                    <h3>
                        Student</h3>
                </div>
                <div class="inner-content">
                    <asp:HiddenField ID="hfSubjects" runat="server" />
                    <asp:GridView ID="gvSTD_SubjectStudent" class="gridCss" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            
                            <asp:TemplateField HeaderText="Student">
                                <ItemTemplate>
                                    <asp:Label ID="lblStudentCode" runat="server" Text='<%#Eval("StudentCode") %>'>
 	 </asp:Label>&nbsp;-&nbsp;
                                    <asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Course">
                                <ItemTemplate>
                                    <asp:Label ID="lblCourse" runat="server" Text='<%#Eval("CourseName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubjectID" runat="server" Text='<%#Eval("SubjectName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Class">
                                <ItemTemplate>
                                    <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("ClassName") %>'>
 	 </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("SubjectStudentID") %>'
                                        AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <asp:ImageButton runat="server" ID="lbDelete" CommandArgument='<%#Eval("SubjectStudentID") %>'
                                        OnClick="lbDelete_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="paging" style="display: none;">
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
