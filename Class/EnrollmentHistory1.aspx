<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="EnrollmentHistory1.aspx.cs" Inherits="AdminDisplaySTD_ClassSubject" Title="Add/Update Class Subject" %>
<%@ Register src="../Control/ClassSetting.ascx" tagname="ClassSetting" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField ID="hfCourseID" runat="server" Value="0" />
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
                    <asp:Button ID="btnVarify" Text="VerifyCode" runat="server" class="button button-blue"
                        OnClick="btnVarify_OnClick" />
                    <asp:HiddenField ID="hfStudentID" runat="server" />
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
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
                    </asp:Panel>
                </dd>
                <dt>&nbsp;</dt>
                <dd>
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
                   
                            <asp:TemplateField HeaderText="Subject">
                                <ItemTemplate>
                                    <asp:GridView ID="gvSubjects" class="gridCss" runat="server" AutoGenerateColumns="false"
                                        CssClass="gridCss" ShowHeader="false">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClassID" runat="server" Text='<%#Eval("SubjectName") %>'></asp:Label>
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
            </dd>
            </dl>
        </div>
    </div>
</asp:Content>
