<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="SubjectEmployeeAdd.aspx.cs" Inherits="AdminDisplaySTD_ClassStudent" Title="Add/Update Class Student" %>
   
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
                Add/Update Subject teacher</h3>
        </div>
        
        <div class="inner-form">
            <dl>
                <dt>
                    <asp:Label ID="lblClassID" runat="server" Text="Subject: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectIDTop_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select a Class." Text="*" ForeColor="Red"
                        ValidationGroup="required" Display="Dynamic" ControlToValidate="ddlSubjectID" InitialValue="0"></asp:RequiredFieldValidator>
                </dd>
            </dl>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2">
                <ajaxToolkit:TabPanel HeaderText="Teacher From Other Subjects" ID="TabPanel1" runat="server">
                    <ContentTemplate>
                        <dl>
                            <dt>
                                <asp:Label ID="Label1" runat="server" Text="Student from Class: ">
                                </asp:Label>
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlSubjectIDSearch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjectID_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ImageButton ID="imgRefresh" runat="server" ImageUrl="http://money.livemint.com/App_Themes/images/Refresh.gif"
                                    OnClick="imgRefresh_Click" />
                            </dd>
                        </dl>
                        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                            <HeaderStyle CssClass="heading" />
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="altrow" />
                            <Columns>
                                <asp:TemplateField HeaderText="" ControlStyle-CssClass="gridIteamCenter">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkSelect" Checked="true" />
                                        <asp:HiddenField runat="server" ID="hfStudentID" Value='<%# Eval("EmployeeID")  %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee ID">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("EmployeeNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <asp:Image ID="imgStudent" runat="server" ImageUrl='<%#"../HR/upload/employeer/"+Eval("Photo") %>' Width="100" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <dl>
                            <dt>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="required" ShowMessageBox="true" ShowSummary="false"/>
                            </dt>
                            <dd>
                                <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd_Click" CausesValidation="true" ValidationGroup="required" />
                                <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                                    OnClick="btnUpdate_Click" Visible="false" />
                            </dd>
                        </dl>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel HeaderText="Teachers by IDs" ID="TabPanel2" runat="server">
                    <ContentTemplate>
                        <dl>
                            <dt>Teacher IDs :<br />
                                <span style="font-size: 8px;">TeacherIDs seperated by (,)</span></dt>
                            <dd>
                                <asp:TextBox ID="txtStudentIDs" runat="server" Width="500" Height="100" TextMode="MultiLine"></asp:TextBox></dd>
                            <dt></dt>
                            <dd>
                                <asp:Button ID="btnVerify" runat="server" class="button button-blue" Text="Verify"
                                    OnClick="btnVerify_Click" />
                                <asp:Button ID="btnAdd2" class="button button-blue" runat="server" Text="Add" OnClick="btnAdd2_Click" CausesValidation="true" ValidationGroup="required"/>
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
                                        <asp:HiddenField runat="server" ID="hfStudentID" Value='<%# Eval("EmployeeID")  %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee ID">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("EmployeeNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <asp:Image ID="imgStudent" runat="server" ImageUrl='<%#"~/HR/upload/employeer/"+Eval("Photo") %>' Width="100" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel HeaderText="All Teacher List" ID="TabPanel3" runat="server">
                    <ContentTemplate>
                       
                        <asp:GridView ID="gvAllEmployeeList" runat="server" AutoGenerateColumns="false" CssClass="tabel_input">
                            <HeaderStyle CssClass="heading" />
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="altrow" />
                            <Columns>
                                <asp:TemplateField HeaderText="" ControlStyle-CssClass="gridIteamCenter">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkSelect"  />
                                        <asp:HiddenField runat="server" ID="hfStudentID" Value='<%# Eval("EmployeeID")  %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee ID">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("EmployeeNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <asp:Image ID="imgStudent" runat="server" ImageUrl='<%#"~/HR/upload/employeer/"+Eval("Photo") %>' Width="100" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         <dl>
                            <dt></dt>
                            <dd>
                                <asp:Button ID="Button2" class="button button-blue" runat="server" Text="Save" OnClick="btnAdd3_Click" CausesValidation="true" ValidationGroup="required"/>
                            </dd>
                        </dl>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                List Of Existing Subject-wise Teacher</h3>
        </div>
        <div class="inner-content">
            <dl>
                <dt>Class : </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassesToDisplay" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassesToDisplay_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="btnLoadAllClass" runat="server" Text="Load All Class" 
                        onclick="btnLoadAllClass_Click" />
                </dd>
            </dl>
            <asp:Panel ID="panAllClass" runat="server">
                <asp:GridView ID="gvSTD_Class" class="gridCss" runat="server" AutoGenerateColumns="false"
                    OnRowDataBound="productsGridView_RowDataBound" CssClass="tabel_input">
                    <HeaderStyle CssClass="heading" />
                    <RowStyle CssClass="row" />
                    <AlternatingRowStyle CssClass="altrow" />
                    <Columns>
                        <asp:TemplateField HeaderText="Subject Name">
                            <ItemTemplate>
                                <asp:Label ID="lblSubjectName" runat="server" Text='<%#Eval("SubjectName") %>'>
                                </asp:Label>
                                <asp:Label ID="lblSubjectID" runat="server" Visible="false" Text='<%#Eval("SubjectID") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Course">
                            <ItemTemplate>
                                <asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Teacher">
                            <ItemTemplate>
                                <asp:GridView ID="gvStudents" ShowHeader="false" class="gridCss" runat="server" AutoGenerateColumns="false"
                                    CssClass="gridCss">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeNo" runat="server" Text='<%#Eval("EmployeeNo") %>'></asp:Label> --
                                                <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="lbDeleteClass" CommandArgument='<%#Eval("SubjectEmployeeID") %>'
                                                    OnClientClick="return confirm('Are you sure to delete?');" OnClick="lbDeleteClass_Click"
                                                    AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Class Status">
                            <ItemTemplate>
                                <asp:Label ID="lblClassStatusID" runat="server" Text='<%#Eval("ClassStatusName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="panPager" runat="server">
                <div class="paging">
                    <div class="viewpageinfo">
                        Show
                    </div>
                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
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
            </asp:Panel>
        </div>
    </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
