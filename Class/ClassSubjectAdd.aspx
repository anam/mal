<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="ClassSubjectAdd.aspx.cs" Inherits="AdminDisplaySTD_ClassSubject" Title="Add/Update Class Subject" %>
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
                Add/Update Class Subject</h3>
        </div>
        <div class="inner-form">                                 
            <uc1:ClassSetting ID="ClassSetting1" runat="server" />                                 
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
                    <asp:CheckBox ID="chkClosedClasses" runat="server" 
                        Text="Load Completed Classes Also" AutoPostBack="true" 
                        oncheckedchanged="chkClosedClasses_CheckedChanged"/>
                    <br />
                    <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: ">
    </asp:Label>
                </dt>
                <dd>
                    <%-- <asp:DropDownList ID="ddlSubjectID" runat="server">
                    </asp:DropDownList>--%>
                    <a id="a_AddSubjectToAddCourse" href="SubjectAdd.aspx?CourseID=" runat="server" visible="false">
                        Add Subject for the course</a>
                    <asp:GridView ID="gvSubject" runat="server" AutoGenerateColumns="false"  CssClass="tabel_input">
                    <HeaderStyle CssClass="heading" />
                <RowStyle CssClass="row" />
                <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="" ControlStyle-CssClass="gridIteamCenter">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkSelect" Checked='<%# Eval("IsChecked")  %>'  />
                                    <asp:HiddenField runat="server" ID="hfSubjectID" Value='<%# Eval("SubjectID")  %>' />
                                    <asp:HiddenField runat="server" ID="hfPreviouslyChecked" Value='<%# Eval("IsChecked")  %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subjects">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" ForeColor="Green" Visible='<%# Eval("IsHistory")  %>' Text='<%#String.Format("{0} -- Completed", Eval("SubjectName"))%>'></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Visible='<%# Eval("IsNotHistory")  %>' Text='<%# Eval("SubjectName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btnUndoClose" class="button button-blue"  Visible='<%# Eval("IsHistory")  %>' runat="server" Text="Undo Close" OnClientClick="return confirm('Are You Sure, You Want To Undo Close?')" OnClick="btnUndoClose_Click" CommandArgument='<%# Eval("ClassSubjectID")  %>'/>
                                    <asp:Button ID="btnClose" class="button button-blue"  Visible='<%# Eval("IsChecked")  %>' runat="server" Text="Close" OnClientClick="return confirm('Are You Sure, You Want To Close?')" OnClick="btnCloseSubject_Click" CommandArgument='<%# Eval("ClassSubjectID")  %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtStartDate" runat="server" Text='<%#String.Format("{0}",Eval("ExtraField1"))%>'></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal" runat="server" TargetControlID="txtStartDate">
                                    </ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEndDate" runat="server" Text='<%#String.Format("{0}",Eval("ExtraField2"))%>'></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd MMM yyyy" ID="ajcal1" runat="server" TargetControlID="txtEndDate">
                                    </ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </dd>
                <dt></dt>
                <dd>
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Save" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                </dd>
            </dl>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                List Of Existing Class Subject
            </h3>
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
                            <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("ClassID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Course">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Subject---- | ----Start Date-- | --End Date--">
                        <ItemTemplate>
                            <asp:GridView ID="gvSubjects" class="gridCss" runat="server" AutoGenerateColumns="false"
                                CssClass="gridCss" ShowHeader="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("SubjectName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%#Eval("ExtraField1") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%#Eval("ExtraField2") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Status">
                        <ItemTemplate>
                            <asp:Label ID="lblClassStatusID" runat="server" Text='<%#Eval("ClassStatusName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelectClass" CommandArgument='<%#Eval("ClassID") %>'
                                AlternateText="Edit" OnClick="lbSelectClass_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
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
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
