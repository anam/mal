<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="StudentSearchByIDs.aspx.cs" Inherits="AdminDisplaySTD_ClassStudent" Title="Add/Update Class Student" %>
    <%@ Register src="../Control/ClassSetting.ascx" tagname="ClassSetting" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
    <script type="text/javascript">
        var win = null;
        function printIt(printThis) {
            win = window.open();
            self.focus();
            win.document.open();
            win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
            win.document.write('body, td { font-family: Verdana; font-size: 10pt;}');
            win.document.write('<' + '/' + 'style' + '><' + '/' + 'head' + '><' + 'body' + '>');
            win.document.write(printThis);
            win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
            win.document.close();
            win.print();
            win.close();
        }
</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
    <asp:HiddenField ID="hfCourseID" runat="server" Value="0" />
    <div class="content-box">
        <div class="header">
            <h3>
                Student Search By ID</h3>
        </div>
        <div class="inner-form">                                 
            <uc1:ClassSetting ID="ClassSetting1" runat="server" Visible="False" />                                 
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl style="display:none;">
                <dt>
                    <asp:Label ID="lblClassID" runat="server" Text="Class: ">
                    </asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassID" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select a Class." Text="*" ForeColor="Red"
                        ValidationGroup="required" Display="Dynamic" ControlToValidate="ddlClassID" InitialValue="0"></asp:RequiredFieldValidator>
                </dd>
            </dl>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1">
                <ajaxToolkit:TabPanel HeaderText="Student From Other Classes" ID="TabPanel1" runat="server" Visible="false">
                    <ContentTemplate>
                        <p>In this way the transfered student will be acive only in the transfered Class.</p>
                        <dl>
                            <dt>
                                <asp:Label ID="Label1" runat="server" Text="Student from Class: ">
                                </asp:Label>
                            </dt>
                            <dd>
                                <asp:DropDownList ID="ddlClassIDSearch1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClassID_SelectedIndexChanged">
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
                            <dt>Class :</dt>
                            <dd>
                                <asp:DropDownList ID="ddlClassIDSearch" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="ddlClassID_SelectedIndexChanged">
                                </asp:DropDownList>  &nbsp;OR  
                            </dd>
                            <dt>Student IDs :<br />
                                <span style="font-size: 8px;">StudentIDs seperated by (,)</span></dt>
                            <dd>
                                <asp:TextBox ID="txtStudentIDs" runat="server" Width="500px" Height="100px" 
                                    TextMode="MultiLine"></asp:TextBox></dd>
                            <dt></dt>
                            <dd>
                                <asp:Button ID="btnVerify" runat="server" class="button button-blue" Text="Search"
                                    OnClick="btnVerify_Click" />
                                <asp:Button ID="btnAdd2" Visible="False" class="button button-blue" 
                                    runat="server" Text="Add" OnClick="btnAdd2_Click" ValidationGroup="required"/>
                            </dd>
                            <dt>
                               Phone #</dt>
                            <dd>
                                <asp:TextBox ID="txtPhoneNo" runat="server" Width="500px" Height="100px" 
                                    TextMode="MultiLine"></asp:TextBox>
                            <dt>
                                Mobile #</dt>
                                <asp:TextBox ID="txtMobileNo" runat="server" Width="500px" Height="100px" 
                                    TextMode="MultiLine"></asp:TextBox></dd>
                            <dt></dt>
                        </dl>
                        <br />
                        <asp:LinkButton ID="lnkPrint" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printList').innerHTML);"></asp:LinkButton>
                        <br />
                        <div id="printList">
                        
                        
                        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" 
                                CssClass="tabel_input" EnableModelValidation="True">
                            <HeaderStyle CssClass="heading" />
                            <RowStyle CssClass="row" />
                            <AlternatingRowStyle CssClass="altrow" />
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkSelect" Checked="true" />
                                        
                                    </ItemTemplate>
                                    <ControlStyle CssClass="gridIteamCenter" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Name">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblStudentName" runat="server" Text='<%#Eval("StudentName")%>'></asp:Label>
                                        <asp:HiddenField runat="server" ID="hfStudentID" Value='<%# Eval("StudentID")  %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Student Code">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<asp:Label ID="lblStudentCode" runat="server" Text='<%#Eval("StudentCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Phone No#">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox> 
                                       <br /><%#Eval("Telephone")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile No#">
                                    <ItemTemplate>
                                         <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox> 
                                       <br /> <%#Eval("Mobile")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Photo" Visible="False">
                                    <ItemTemplate>
                                        <a href='<%#"../Student/AdminDetailsSTD_Student.aspx?ID="+Eval("StudentID") %>' target="_blank">
                                            <asp:Image ID="imgStudent" runat="server" ImageUrl='<%#Eval("PPSizePhoto") %>' Width="100" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                            <asp:Label ID="lblSavePhoneNo" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnSavePhoneNo" runat="server" class="button button-blue" 
                                Text="Save" onclick="btnSavePhoneNo_Click"
                                    />
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
    </div>
    <div class="content-box" style="display:none;">
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
