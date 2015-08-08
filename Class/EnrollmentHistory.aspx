<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="EnrollmentHistory.aspx.cs" Inherits="AdminSTD_Class" Title="Add/Update Class" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
    
    <div class="content-box">
        <div class="header">
            <h3>
                Enrollment History</h3>
        </div>
        <div class="inner-form">
            <dl>
                <dt>Student ID:</dt>
                <dd>
                    <asp:TextBox ID="txtStudentCode" runat="server" CssClass="txt small-input"></asp:TextBox>
                    <asp:Button ID="btnVarify" Text="Verify ID" runat="server" class="button button-blue"
                        OnClick="btnVarify_OnClick" />
                    <asp:HiddenField ID="hfStudentID" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    <br />
                    ACCA Registration No: <asp:TextBox ID="txtAccARegistrationNo" runat="server" CssClass="txt small-input"></asp:TextBox>
                    <asp:Button ID="btnSaveRegistrationNo" Text="Save Registration No" 
                        runat="server" class="button button-blue" 
                        onclick="btnSaveRegistrationNo_Click" />
                </dd>
                <dt>&nbsp;</dt>
                <dd>
                    <asp:Panel ID="pnStudentDetails" runat="server" Visible="false">
                        <div class="inner-content" style="overflow: scroll;">
                            <table width="100%" class="tabel_input">
                                <tr>
                                    <th class="heading" style="border-right: solid 1px #ccc; height: 25px">
                                        Name
                                    </th>
                                    <th class="heading" style="border-right: solid 1px #ccc; height: 25px">
                                        Contact
                                    </th>
                                    <th class="heading" style="height: 25px">
                                        Photo
                                    </th>
                                </tr>
                                <tr>
                                    <td style="border-left: solid 1px #ccc; height: 25px">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblContact" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Image ID="imgStudent" runat="server" Height="70px" Width="70px"></asp:Image>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>&nbsp;
                </dd>
                <dt>&nbsp;</dt>
                <dd>
                   <asp:GridView ID="gvSTD_Class" class="gridCss" runat="server" AutoGenerateColumns="false"
                            OnRowDataBound="gvSTD_Class_RowDataBound"
                        CssClass="tabel_input" >
                        <headerstyle cssclass="heading" />
                        <rowstyle cssclass="row" />
                        <alternatingrowstyle cssclass="altrow" />
                        <columns>
                            <asp:TemplateField HeaderText="Class Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("ClassName") %>' Visible='<%#Eval("IsActive") %>'></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("ClassName") %>' ForeColor="Red" Visible='<%#Eval("IsHistory") %>'></asp:Label>
                                    <asp:HiddenField ID="hfIsHistory" runat="server" Value='<%#Eval("IsHistory") %>'/>
                                    <asp:HiddenField ID="hfClassID" runat="server" Value='<%#Eval("ClassID") %>'/>
                        
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:GridView ID="gvSubject"  class="gridCss" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                                        CssClass="tabel_input">
                                        <headerstyle cssclass="heading" />
                                        <rowstyle cssclass="row" />
                                        <alternatingrowstyle cssclass="altrow" />
                                        <columns>
                                            <asp:TemplateField HeaderText="Subject Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("SubjectName") %>' Visible='<%#Eval("IsActive") %>'></asp:Label>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("SubjectName") %>' ForeColor="Green" Visible='<%#Eval("IsHistory") %>'></asp:Label>
                                                    <asp:HiddenField ID="hfClassSubjectID" runat="server" Value='<%#Eval("ClassSubjectID") %>'/>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                                        CommandArgument='<%#Eval("ClassSubjectID") %>' OnClick="lbDelete_Click" AlternateText="Delete"  Visible='<%#Eval("IsActive") %>'
                                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="lbPassed" OnClientClick="return confirm('Are You Sure, S/he has Passed this subject/paper?')"
                                                        CommandArgument='<%#Eval("ClassSubjectID") %>' OnClick="lbPassed_Click" AlternateText="Passed"  Visible='<%#Eval("IsActive") %>'
                                                        ToolTip="Click here to Make this Subject Passed" ImageUrl="~/App_Themes/CoffeyGreen/images/Passed.jpg"  />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ClassID") %>'
                                        AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                                    <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                        CommandArgument='<%#Eval("ClassID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                        ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </columns>
                    </asp:GridView>
                    <br />
                    <asp:Label ID="lblDeletedHistory" runat="server" Text=""></asp:Label>
                </dd>
                <dt>Class</dt>
                <dd>
                    <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlClassID_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;
                </dd>
                <dt>Subject</dt>
                <dd>
                    <asp:HiddenField ID="hfSubjects" runat="server" Value="-"/>
                        <asp:GridView ID="gvSubjects"  class="gridCss" runat="server" AutoGenerateColumns="false"
                            CssClass="tabel_input">
                            <headerstyle cssclass="heading" />
                            <rowstyle cssclass="row" />
                            <alternatingrowstyle cssclass="altrow" />
                            <columns>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSubject" runat="server"  oncheckedchanged="chkSubject_CheckedChanged" ToolTip='<%#Eval("SubjectID") %>' Text='<%#Eval("CourseSubjectName") %>' AutoPostBack="true" /> 
                                        <asp:HiddenField ID="hfClassSubjectID" runat="server" Value='<%#Eval("ClassSubjectID") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </columns>
                        </asp:GridView>
                    <asp:Label ID="lblNoSubject" runat="server" Text="No subject is available to Add" Visible="false"></asp:Label>
                        &nbsp;
                </dd>
                <dt></dt>
                <dd>
                    
                    <asp:HiddenField ID="hfsubjectID" runat="server" />
                    <asp:Label ID="lblConfilictMessage" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Button ID="btnEnrollment" Text="Save" runat="server" Visible="false"
                        class="button button-blue" onclick="btnEnrollment_Click"/>
                </dd>
                
            </dl>

            <b style="font-size: 20px; color: #0567AD;">
                        <br />
                        Routine varification</b> 
                <asp:LinkButton ID="lnkPrint" Text="Print / or learge View" runat="server" OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);"></asp:LinkButton>

                    <div id='printThis' style="width: 780px;height:500px; overflow: scroll;">
                        <asp:Label ID="lblVerifyRoutine" runat="server" Text=""></asp:Label></div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
