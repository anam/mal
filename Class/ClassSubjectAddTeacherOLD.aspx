<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="ClassSubjectAddTeacherOLD.aspx.cs" Inherits="AdminDisplaySTD_ClassTeacher"
    Title="Fixing Teacher for the Class" %>
<%@ Register src="../Control/ClassSetting.ascx" tagname="ClassSetting" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField ID="hfCourseID" runat="server" Value="0" />
    <div class="content-box">
        <div class="header">
            <h3>Fixing Teacher for the Class</h3>
        </div>
        <div class="inner-form">                                 
            <uc1:ClassSetting ID="ClassSetting1" runat="server" />                                 
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblClassID" runat="server" Text="Class: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Teacher: ">
                    </asp:Label>
                </dt>
                <dd>
                    <%-- <asp:DropDownList ID="ddlSubjectID" runat="server">
                    </asp:DropDownList>--%>
                    <a id="a_AddSubjectToAddCourse" href="ClassSubjectAdd.aspx?ID=" runat="server" visible="false">
                        Add Subject for the course of this Class</a>
                    <asp:GridView ID="gvSubject" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvSubject_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="" ControlStyle-CssClass="gridIteamCenter">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" Enabled="false" ID="chkSelect" Checked='<%# Eval("IsChecked")  %>' />
                                    <asp:HiddenField runat="server" ID="hfSubjectID" Value='<%# Eval("SubjectID")  %>' />
                                    <asp:HiddenField runat="server" ID="hfClassSubjectID" Value='<%# Eval("ClassSubjectID")  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Teacher">
                                <ItemTemplate>
                                    <%# Eval("SubjectName")  %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Teacher">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlTeacherID" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:DropDownList ID="ddlTeacher" runat="server" Visible="false">
                    </asp:DropDownList>
                </dd>
                <dt></dt>
                <dd>
                    <span style="color:Green;">Select the Class 1st..</span>
                    <br /><asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Save" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                List Of Teacher of Classes </h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvSTD_Class" class="gridCss" runat="server" AutoGenerateColumns="false"
                OnRowDataBound="productsGridView_RowDataBound" CssClass="tabel_input">
                <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                <Columns>
                    
                    <asp:TemplateField HeaderText="Class Name">
                        <ItemTemplate>
                            <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName") %>'>
                            </asp:Label>
                            <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("ClassID") %>' Visible="false">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Course">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Class Type">
                        <ItemTemplate>
                            <asp:Label ID="lblClassTypeID" runat="server" Text='<%#Eval("ClassTypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Teacher">
                        <ItemTemplate>
                            <asp:GridView ID="gvSubjects" class="gridCss" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                CssClass="gridCss">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("SubjectName") %>'></asp:Label>
                                            --
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("EmployeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField >
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="lbSelectClass" CommandArgument='<%#Eval("ClassSubjectID") %>'
                                                AlternateText="Edit" OnClick="lbSelectClass_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                            <asp:ImageButton runat="server" ID="lbDeleteClass" CommandArgument='<%#Eval("ClassID") %>'
                                                OnClick="lbDeleteClass_Click" AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Status">
                        <ItemTemplate>
                            <asp:Label ID="lblClassStatusID" runat="server" Text='<%#Eval("ClassStatusName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='ClassSubjectAddTeacher.aspx?ID=<%#Eval("ClassID") %>'>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" /></a>
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
