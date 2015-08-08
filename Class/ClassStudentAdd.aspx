<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="ClassStudentAdd.aspx.cs" Inherits="AdminDisplaySTD_ClassStudent" Title="Add/Update Class Student" %>
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
                Add/Update Class Student</h3>
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
                    <asp:CheckBox ID="chkClosedClasses" runat="server" 
                        Text="Load Completed Classes Also" AutoPostBack="true" 
                        oncheckedchanged="chkClosedClasses_CheckedChanged"/>
                    <br />
                    <asp:DropDownList ID="ddlClassID" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select a Class." Text="*" ForeColor="Red"
                        ValidationGroup="required" Display="Dynamic" ControlToValidate="ddlClassID" InitialValue="0"></asp:RequiredFieldValidator>
                </dd>
            </dl>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
                <ajaxToolkit:TabPanel HeaderText="Student From Other Classes" ID="TabPanel1" runat="server">
                    <ContentTemplate>
                        <p>In this way the transfered student will be acive only in the transfered Class.</p>
                        <dl>
                            <dt>
                                <asp:Label ID="Label1" runat="server" Text="Student from Class: ">
                                </asp:Label>
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlClassIDSearch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_SelectedIndexChanged">
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
                                        <asp:CheckBox runat="server" ID="chkSelect" Checked='<%#Eval("IsEnabled")%>' Enabled='<%#Eval("IsEnabled")%>'/>
                                        <asp:HiddenField runat="server" ID="hfStudentID" Value='<%# Eval("StudentID")  %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name">
                                    <ItemTemplate>
                                            &nbsp;&nbsp;<asp:Label ID="lblStudentName" Visible='<%#Eval("IsEnabled")%>' runat="server" Text='<%#Eval("StudentName")%>'></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ForeColor="Red"  Visible='<%#Eval("IsDisAbled")%>' Text='<%#Eval("StudentName")%>'></asp:Label>
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
        </div>
    </div>
    <div class="content-box">
        <div class="header">
            <h3>
                List Of Existing Class Student</h3>
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
                        <asp:TemplateField HeaderText="Class Name">
                            <ItemTemplate>
                                <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName") %>'>
                                </asp:Label>
                                <asp:Label ID="lblClassID" runat="server" Visible="false" Text='<%#Eval("ClassID") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Course">
                            <ItemTemplate>
                                <asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Name">
                            <ItemTemplate>
                                <asp:GridView ID="gvStudents" ShowHeader="false" class="gridCss" runat="server" AutoGenerateColumns="false"
                                    CssClass="gridCss">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblInstallmentNo" Text='<%# Container.DataItemIndex +1 %>' runat="server"></asp:Label>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Student Name">
                                            <ItemTemplate>
                                                    &nbsp;&nbsp;<asp:Label ID="lblStudentName" Visible='<%#Eval("IsEnabled")%>' runat="server" Text='<%#Eval("StudentName")%>'></asp:Label>
                                                    <asp:Label ID="Label2" runat="server" ForeColor="Red"  Visible='<%#Eval("IsDisAbled")%>' Text='<%#Eval("StudentName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblStudentCode" runat="server" Text='<%#Eval("StudentCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="lbDeleteClass" CommandArgument='<%#Eval("ClassStudentID") %>'  Visible='<%#Eval("IsEnabled")%>'
                                                    OnClientClick="return confirm('Are you sure to delete?');" OnClick="lbDeleteClass_Click"
                                                    AlternateText="Delete" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
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
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="panPager" runat="server">
                <div class="paging">
                    <div class="viewpageinfo">
                        Show
                    </div>
                    <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                        <asp:ListItem Text="1" Value="1" />
                        <asp:ListItem Text="2" Value="2" />
                        <asp:ListItem Text="5" Value="5" />
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
