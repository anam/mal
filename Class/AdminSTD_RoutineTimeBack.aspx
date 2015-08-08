<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2Column.master"
    CodeFile="AdminSTD_RoutineTimeBack.aspx.cs" Inherits="AdminSTD_RoutineTime" Title="Class RoutineTime" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
    <div class="content-box">
        <div class="header">
            <h3 id='top'>
                Class RoutineTime</h3>
        </div>
        <div class="inner-form">
            <dl>
                <dt>
                    <asp:DropDownList ID="ddlRoutineTImeIDnValue" Visible="false" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="ddlRoutineTimeIDnCause" Visible="false" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="lblRoutineTimeName" runat="server" Text="Routine Time Name: " Visible="false"></asp:Label>
                </dt>
                <dd>
                    <asp:TextBox ID="txtRoutineTimeName" class="txt medium-input" runat="server" Text="" Visible="false"></asp:TextBox>
                </dd>
                 <dt>
                    <asp:Label ID="Label2" runat="server" Text="Campus: ">
                    </asp:Label>
                </dt>
                
                 <dd>

                    <asp:DropDownList ID="ddlCampus" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlCampus_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt style="display:none;">
                    <asp:Label ID="lblRoutineID" runat="server" Text="Routine: "></asp:Label>
                </dt>
                <dd style="display:none;">
                    <asp:DropDownList ID="ddlRoutineID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblRoomID" runat="server" Text="Room: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlRoomID" runat="server">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblClassID" runat="server" Text="Class: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlClassID" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlClassID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblSubjectID" runat="server" Text="Subject: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlSubjectID" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlSubjectID_SelectedIndexChanged">
                    </asp:DropDownList>
                </dd>
                <dt>
                    <asp:Label ID="lblEmployeeID" runat="server" Text="Teacher: "></asp:Label>
                </dt>
                <dd>
                    <asp:DropDownList ID="ddlEmployeeID" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlEmployeeID_SelectedIndexChanged">
                    </asp:DropDownList>

                    <asp:GridView ID="gvEmployeeSchedule" runat="server" AutoGenerateColumns="false"
                        CssClass="tabel_input">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="ClassDayID">
                                <ItemTemplate>
                                    <asp:Label ID="lblClassDayID" runat="server" Text='<%#Eval("ClassDay") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StartTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("StartTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EndTime">
                                <ItemTemplate>
                                    <asp:Label ID="lblEndTime" runat="server" Text='<%#Eval("EndTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gvWorkDayShift" class="gridCss" runat="server" AutoGenerateColumns="false" Visible="false">
                        <HeaderStyle CssClass="heading" />
                        <RowStyle CssClass="row" />
                        <AlternatingRowStyle CssClass="altrow" />
                        <Columns>
                            <asp:TemplateField HeaderText="Day" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDay" runat="server" Text='<%#Eval("Days") %>'>
 	                                </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Time" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("StartTime") %>'>
 	                                </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Time" ControlStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Label ID="lblEndTime" runat="server" Text='<%#Eval("EndTime") %>'>
 	                                </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </dd>
                
                <%--<dt>
                    <asp:Label ID="lblClassDayID" runat="server" Text="Class Day: "></asp:Label>
                </dt>--%>
                <%--<dd>
                    <asp:DropDownList ID="ddlClassDayID" runat="server">
                    </asp:DropDownList>
                </dd>--%>
                <%--<dt>
                    <asp:Label ID="lblClassTimeID" runat="server" Text="Class Time: "></asp:Label>
                </dt>--%>
                <%--<dd>
                    <asp:DropDownList ID="ddlClassTimeID" runat="server">
                    </asp:DropDownList>
                </dd>--%>
                <dt>Class Day And Time</dt>
                <dd>
                    <span  style="color:Red;">Please select the Room, Class, Teacher then Click the below button.</span>
                    <br />
                    <asp:Button ID="btnLoadDaynTime" class="button button-blue" runat="server" Text="Load Day wise Time" OnClick="btnLoadDaynTime_Click" />
                    <asp:HiddenField ID="hfDayIDTimeIDPair" runat="server" />
                    <br /><span  style="color:green;">Disabled Check box are not allowed for the above(Room, Class, Teacher) condition</span>                    
                    <br /><span  style="color:green;">Total 
                        <asp:Label ID="lblTotalNoOfClasses" runat="server" Text=""></asp:Label>
                     class hour per week(already have) = <asp:Label ID="lblHaveClassInHour" Font-Size="20px" runat="server" Text=""></asp:Label> Hour(s)</span>
                    <asp:GridView ID="gvClassDay" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                        GridLines="None" Width="100%" OnRowDataBound="OnRowDataBound_gvClassDay">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblDay" Text='<%#Eval("ClassDayName")%>' runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                                    <asp:Label ID="lblDayID" Text='<%#Eval("ClassDayID")%>' runat="server" Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hfDayID" runat="server" Value='<%#Eval("ClassDayID")%>'/>
                                    <br />
                                    <asp:DataList ID="dlTime" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" >
                                        <ItemTemplate>
                                        
                                            <asp:HiddenField ID="hfClassTimeID" runat="server" Value='<%#Eval("ClassTimeID")%>'/>
                                             S-<%#Eval("ClassTimeGroupID")%>-> <asp:CheckBox ID="chkTime" runat="server"  Text='<%#Eval("ClassTimeName")%>' Enabled='<%#Eval("IsEnabled")%>'/>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("CaseForDisabled")%>'></asp:Label>
                                            <asp:HiddenField ID="hfClassTimeName" runat="server" Value='<%#Eval("ClassTimeName")%>'/>
                                            <asp:HiddenField ID="hfExtraField3" runat="server" Value='<%#Eval("ExtraField3")%>'/>
                                                
                                        </ItemTemplate>
                                    </asp:DataList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </dd>
               
                <dt></dt>
                <dd>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </dd>
                    
                <dt></dt>
                <dd>
                    <asp:Button ID="btnVaryfyConfict" class="button button-blue" runat="server" Text="Varify Conflict" Visible="false" OnClick="btnVaryfyConfict_Click" />
                    <asp:Button ID="btnAdd" class="button button-blue" runat="server" Text="Save" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" class="button button-blue" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" Visible="false" />
                        <a class="button button-blue" href="#top">Back to top</a>
                </dd>
            </dl>
            <div>
                <asp:Label ID="lblRoutineDisplay" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
