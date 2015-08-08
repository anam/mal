<%@ Page Language="C#" MasterPageFile="~/Site2Column.master" AutoEventWireup="true"
    CodeFile="ClassAdd.aspx.cs" Inherits="Class_ClassAdd" Title="Add Class" %>

<%@ Register Src="../Control/ClassSetting.ascx" TagName="ClassSetting" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" type="text/css" href="../App_Themes/CoffeyGreen/css/grid.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div class="content-box">
        <div class="header">
            <h3>
                Add Class</h3>
        </div>
        <div class="inner-form">
            <uc1:classsetting id="ClassSetting1" runat="server" />
        </div>
        <div class="inner-form">
            <!-- error and information messages -->
            <dl>
                <dt>
                    <asp:Label ID="lblClassName" runat="server" Text="Class Name: "></asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtClassName" class="txt medium-input" runat="server" Text="">
                    </asp:TextBox>
                </dd>
                <dt>
                    <asp:Label ID="lblCourseID" runat="server" Text="Course: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlCourseID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblClassTypeID" runat="server" Text="Class Type: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassTypeID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblClassStatusID" runat="server" Text="Class Status: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassStatusID" runat="server" AutoPostBack="True" onselectedindexchanged="ddlClassStatusID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <asp:Panel id="pnClassStatus" runat="server" visible="false">
                    <dt>
                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date: "></asp:Label>
                    </dt>
                    <dd>
                        <asp:TextBox id="txtStartDate" runat="server">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="ajcal" runat="server" TargetControlID="txtStartDate" Format="dd MMM, yyyy"></ajaxToolkit:CalendarExtender>
                    </dd>
                </asp:Panel>
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
                List Of Existing Class</h3>
        </div>
        <div class="inner-content">
        Class Name / Status:<asp:TextBox ID="txtClassForSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" class="button button-blue" runat="server" 
                Text="Search" onclick="btnSearch_Click"  /><br />
            <asp:GridView ID="gvSTD_Class" class="gridCss" runat="server" AutoGenerateColumns="false"
                CssClass="tabel_input">
                <headerstyle cssclass="heading" />
                <rowstyle cssclass="row" />
                <alternatingrowstyle cssclass="altrow" />
                <columns>
                    
                    <asp:TemplateField HeaderText="Class Name">
                        <ItemTemplate>
                            <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Status">
                        <ItemTemplate>
                            <asp:Label ID="lblClassStatusID" runat="server" Text='<%#Eval("ClassStatusName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Course">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseID" runat="server" Text='<%#Eval("CourseName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Class Type">
                        <ItemTemplate>
                            <asp:Label ID="lblClassTypeID" runat="server" Text='<%#Eval("ClassTypeName") %>'>
 	 </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                  
                    <asp:TemplateField HeaderText="Process">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("ClassID") %>'
                                AlternateText="Edit" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                            <asp:ImageButton runat="server" ID="lbClose"  class="button button-blue" CommandArgument='<%#Eval("ClassID") %>'  OnClientClick="return confirm('Are You Sure, You Want To Close?')"
                                AlternateText="Close" OnClick="lbClose_Click"  />

                                <asp:ImageButton runat="server" ID="lbUndoClose"  class="button button-blue" CommandArgument='<%#Eval("ClassID") %>'  OnClientClick="return confirm('Are You Sure, You Want To Undo?')"
                                AlternateText="Undo Close" OnClick="lbUndoClose_Click"  />
                            <asp:ImageButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure, You Want To Delete?')"
                                CommandArgument='<%#Eval("ClassID") %>' OnClick="lbDelete_Click" AlternateText="Delete"
                                ImageUrl="~/App_Themes/CoffeyGreen/images/icon-delete.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </columns>
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
                        <itemtemplate>
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                        </itemtemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
