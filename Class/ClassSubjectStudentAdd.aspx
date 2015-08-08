<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="ClassSubjectStudentAdd.aspx.cs" Inherits="AdminDisplaySTD_ClassSubjectStudent"
    Title="Add/Update Class Subject For Student" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField ID="hfCourseID" runat="server" Value="0" />
    <div class="content-box">
        <div class="header">
            <h3>
            Add/Update Class Subject For Student/h3>
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <%--<dt>
     <asp:Label ID="lblClassSubjectName" runat="server" Text="Class Subject Name: ">
    </asp:Label>
     </dt>
    <dd>
     <asp:TextBox ID="txtClassSubjectName" class="txt large-input" runat="server" Text="">
    </asp:TextBox>
     </dd>--%>
                <dt>
                    <asp:Label ID="lblClassID" runat="server" Text="Class: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassSubjectIDMain" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
                    </asp:Label>
                </dt>
                <dd>
                    <%-- <asp:DropDownList ID="ddlSubjectID" runat="server">
                    </asp:DropDownList>--%>
                    Search student
                    <asp:DropDownList ID="ddlClassSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassSubjectID_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    From<asp:TextBox ID="txtStudentCodeFrom" runat="server"></asp:TextBox>
                    To<asp:TextBox ID="txtStudentCodeTo" runat="server"></asp:TextBox>
                    <br />
                    <asp:GridView ID="gvSubject" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="" ControlStyle-CssClass="gridIteamCenter">
                                <ItemTemplate>
                                    <%--<asp:CheckBox runat="server" ID="chkSelect" Checked='<%# Eval("IsChecked")  %>' />--%>
                                    <asp:CheckBox runat="server" ID="chkSelect" />
                                    <asp:HiddenField runat="server" ID="hfStudentID" Value='<%# Eval("StudentID")  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Students">
                                <ItemTemplate>
                                    <%#String.Format("{0}", Eval("StudentName"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                Tabular DataSTD_Class</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvSTD_Class" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss" OnRowDataBound="productsGridView_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Class">
                        <ItemTemplate>
                            <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("ClassID") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Name">
                        <ItemTemplate>
                            <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Course">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Type">
                        <ItemTemplate>
                            <asp:Label ID="lblClassTypeID" runat="server" Text='<%#Eval("ClassTypeID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Type">
                        <ItemTemplate>
                            <asp:GridView ID="gvSubjects" class="gridCss" runat="server" AutoGenerateColumns="false"
                                CssClass="gridCss">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("StudentName") %>'></asp:Label>
                                            --
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("SubjectName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--<asp:ImageButton runat="server" ID="lbSelectClass" CommandArgument='<%#Eval("ClassSubjectID") %>'
                                                AlternateText="Edit" OnClick="lbSelectClass_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />--%>
                                            <asp:ImageButton runat="server" ID="lbDeleteClass" CommandArgument='<%#Eval("ClassSubjectStudentID") %>'
                                                OnClick="lbDeleteClass_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Status">
                        <ItemTemplate>
                            <asp:Label ID="lblClassStatusID" runat="server" Text='<%#Eval("ClassStatusID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%--<asp:ImageButton runat="server" ID="lbSelectClass" CommandArgument='<%#Eval("ClassID") %>'
                                AlternateText="Edit" OnClick="lbSelectClass_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />--%>
                            <%--<asp:ImageButton runat="server" ID="lbDeleteClass" CommandArgument='<%#Eval("ClassID") %>'
                                OnClick="lbDeleteClass_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
</asp:Content>
